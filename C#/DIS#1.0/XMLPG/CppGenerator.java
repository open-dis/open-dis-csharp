package edu.nps.moves.xmlpg;

import java.io.*;
import java.util.*;

/*
 * Generates the c++ language source code files needed to read and write a protocol described
 * by an XML file. This is a counterpart to the JavaGenerator. This should generate .h and
 * .cpp files with ivars, getters, setters, marshaller, unmarshaler, constructors, and
 * destructors.
 *
 * John Grant specified the desired features of the C++ files.
 *
 * @author DMcG
 */

public class CppGenerator extends Generator
{
    /**
     * ivars are often preceded by a special character. This sets what that character is, 
     * so that instance variable names will be preceded by a "_".
     */
    public static final String IVAR_PREFIX ="_";
    
    /** Maps the primitive types listed in the XML file to the cpp types */
    Properties types = new Properties();
    
    /** What primitive types should be marshalled as. This may be different from
    * the cpp get/set methods, ie an unsigned short might have ints as the getter/setter,
    * but is marshalled as a short.
    */
    Properties marshalTypes = new Properties();
    
    /** sizes of various primitive types */
    Properties primitiveSizes = new Properties();
    
    /** A property list that contains cpp-specific code generation information, such
        * as package names, includes, etc.
        */
    Properties cppProperties;
    
    public CppGenerator(HashMap pClassDescriptions, String pDirectory, Properties pCppProperties)
    {
        super(pClassDescriptions, pDirectory, pCppProperties);
        
        // Set up a mapping between the strings used in the XML file and the strings used
        // in the java file, specifically the data types. This could be externalized to
        // a properties file, but there's only a dozen or so and an external props file
        // would just add some complexity.
        types.setProperty("unsigned short", "unsigned short");
        types.setProperty("unsigned byte", "unsigned char");
        types.setProperty("unsigned int", "unsigned int");
		types.setProperty("unsigned long", "long");
        
        types.setProperty("byte", "char");
        types.setProperty("short", "short");
        types.setProperty("int", "int");
        types.setProperty("long", "long");
        
        types.setProperty("double", "double");
        types.setProperty("float", "float");
        
        // Set up the mapping between primitive types and marshal types.
        
        marshalTypes.setProperty("unsigned short", "unsigned short");
        marshalTypes.setProperty("unsigned byte", "unsigned char");
        marshalTypes.setProperty("unsigned int", "unsigned int");
		marshalTypes.setProperty("unsigned long", "long");
        
        marshalTypes.setProperty("byte", "char");
        marshalTypes.setProperty("short", "short");
        marshalTypes.setProperty("int", "int");
        marshalTypes.setProperty("long", "long");
        
        marshalTypes.setProperty("double", "double");
        marshalTypes.setProperty("float", "float");
        
        // How big various primitive types are
        primitiveSizes.setProperty("unsigned short", "2");
        primitiveSizes.setProperty("unsigned byte", "1");
        primitiveSizes.setProperty("unsigned int", "4");
		primitiveSizes.setProperty("unsigned long", "8");
        
        primitiveSizes.setProperty("byte", "1");
        primitiveSizes.setProperty("short", "2");
        primitiveSizes.setProperty("int", "4");
        primitiveSizes.setProperty("long", "8");
        
        primitiveSizes.setProperty("double", "8");
        primitiveSizes.setProperty("float", "4");
        
    }
    
    /**
     * Generates the cpp source code classes
     */
    public void writeClasses()
    {
        this.createDirectory();
        
        this.writeMacroFile();
        
        Iterator it = classDescriptions.values().iterator();
        
        // Loop through all the class descriptions, generating a header file and cpp file for each.
        while(it.hasNext())
        {
            try
           {
              GeneratedClass aClass = (GeneratedClass)it.next();
			  // System.out.println("Generating class " + aClass.getName());
              this.writeHeaderFile(aClass);
              this.writeCppFile(aClass);
           }
           catch(Exception e)
           {
                System.out.println("error creating source code " + e);
           }
            
        } // End while
        
    }
   
    /**
     * Microsoft C++ requires a macro file to generate dlls. The preprocessor will import this and
     * resolve it to an empty string in the gcc/unix world. In the Microsoft C++ world, the macro
     * will resolve and do something useful about creating libraries.
     */
    public void writeMacroFile()
    {
        System.out.println("Creating microsoft library macro file");
        
        /*
        String headerFile = languageProperties.getProperty("microsoftLibHeaderMacro");
        
        if(headerFile == null)
            return;
         */
        
        String headerFile = "msLibMacro";
        
        try
        {
            String headerFullPath = directory + "/" + headerFile + ".h";
            File outputFile = new File(headerFullPath);
            outputFile.createNewFile();
            PrintWriter pw = new PrintWriter(outputFile);
            
            String libMacro = languageProperties.getProperty("microsoftLibMacro");
            String library = languageProperties.getProperty("microsoftLibDef");
            
            pw.println("#ifndef " + headerFile.toUpperCase() + "_H");
            pw.println("#define " + headerFile.toUpperCase() + "_H");
            
            pw.println("#if defined(_MSC_VER) || defined(__CYGWIN__) || defined(__MINGW32__) || defined( __BCPLUSPLUS__)  || defined( __MWERKS__)");
            pw.println("#  ifdef EXPORT_LIBRARY");
            pw.println("#    define " + "EXPORT_MACRO"  + " __declspec(dllexport)");
            pw.println("#  else");
            pw.println("#    define EXPORT_MACRO  __declspec(dllimport)");
            pw.println("#  endif");
            pw.println("#else");
            pw.println("#  define " + "EXPORT_MACRO");
            pw.println("#endif");
            
            pw.println("#endif");
            
            pw.flush();
            pw.close();
        }
        catch(Exception e)
        {
            System.out.println(e);
        }
}

/**
 * Generate a c++ header file for the classes
 */
public void writeHeaderFile(GeneratedClass aClass)
{
    try
    {
        String name = aClass.getName();
        //System.out.println("Creating cpp and .h source code files for " + name);
        String headerFullPath = directory + "/" + name + ".h";
        File outputFile = new File(headerFullPath);
        outputFile.createNewFile();
        PrintWriter pw = new PrintWriter(outputFile);
        
        // Write the usual #ifdef to prevent multiple inclusions by the preprocessor
        pw.println("#ifndef " + aClass.getName().toUpperCase() + "_H");
        pw.println("#define " + aClass.getName().toUpperCase() + "_H");
        pw.println();
        
        // Write includes for any classes we may reference. this generates multiple #includes if we
        // use a class multiple times, but that's innocuous. We could sort and do a unqiue to prevent
        // this if so inclined.
        
        String namespace = languageProperties.getProperty("namespace");
        if(namespace == null)
            namespace = "";
        else
            namespace = namespace + "/";
        
        boolean hasVariableLengthList = false;
        
        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
            
            // If this attribute is a class, we need to do an import on that class
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            { 
                pw.println("#include <" + namespace + anAttribute.getType() + ".h>");
            }
            
            // if this attribute is a variable-length list that holds a class, we need to
            // do an import on the class that is in the list.
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
            { 
                pw.println("#include <" + namespace + anAttribute.getType() + ".h>");
                hasVariableLengthList = true;
            }
        }
        
        if(hasVariableLengthList == true)
        {
           pw.println("#include <vector>");
        }
        
        // if we inherit from another class we need to do an include on it
        if(!(aClass.getParentClass().equalsIgnoreCase("root")))
        {
             pw.println("#include <" + namespace + aClass.getParentClass() + ".h>");
        }
           
        // "the usual" includes.
        // pw.println("#include <vector>");
        //pw.println("#include <iostream>");
        pw.println("#include <" + namespace + "DataStream.h>");
        
         // This is a macro file included only for microsoft compilers. set in the cpp properties tag.
        String msMacroFile = "msLibMacro";
        
        if(msMacroFile != null)
        {
            pw.println("#include <" + namespace + msMacroFile + ".h>");
        }
        
        pw.println();

        pw.println();
        
        // Print out namespace, if any
        namespace = languageProperties.getProperty("namespace");
        if(namespace != null)
        {
            pw.println("namespace " + namespace);
            pw.println("{");
        }
       
        
        // Print out the class comments, if any
        if(aClass.getClassComments() != null)
        {
            pw.println("// " + aClass.getClassComments() );
            pw.println();
            pw.println("// Copyright (c) 2007-2009, MOVES Institute, Naval Postgraduate School. All rights reserved. ");
            pw.println("//");
            pw.println("// @author DMcG, jkg");
            pw.println();
        }
        
         // Print out class header and ivars
        
        String macroName = languageProperties.getProperty("microsoftLibMacro");
        
        if(aClass.getParentClass().equalsIgnoreCase("root"))
            pw.println("class EXPORT_MACRO " + aClass.getName());
        else
            pw.println("class EXPORT_MACRO " + aClass.getName() + " : public " + aClass.getParentClass());
        
        pw.println("{");
         
        // Print out ivars. These are made protected for now.
        pw.println("protected:");
            
        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            { 
                if(anAttribute.getComment() != null)
                    pw.println("  " + "/** " + anAttribute.getComment() + " */");
                  
                pw.println("  " + types.get(anAttribute.getType()) + " " + IVAR_PREFIX + anAttribute.getName() + "; ");
                pw.println();

            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            { 
                if(anAttribute.getComment() != null)
                    pw.println("  " + "/** " + anAttribute.getComment() + " */");
                
                 pw.println("  " + anAttribute.getType() + " " + IVAR_PREFIX + anAttribute.getName() + "; ");
                 pw.println();
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            { 
                if(anAttribute.getComment() != null)
                    pw.println("  " + "/** " + anAttribute.getComment() + " */");
                
                pw.println("  " + types.get(anAttribute.getType()) + " " + IVAR_PREFIX + anAttribute.getName() + "[" + anAttribute.getListLength() + "]; ");
                pw.println();
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
            { 
                if(anAttribute.getComment() != null)
                    pw.println("  " + "/** " + anAttribute.getComment() + " */");
                
                pw.println("  std::vector<" + anAttribute.getType() + "> " + IVAR_PREFIX + anAttribute.getName() + "; ");
                pw.println();
            }
        }
        
        
        // Delcare ctor and dtor in the public area
        pw.println("\n public:");
        // Constructor
        pw.println("    " + aClass.getName() + "();");
        
        
        // Destructor
        pw.println("    virtual ~" + aClass.getName() + "();");
        pw.println();
       
        
        // Marshal and unmarshal methods
        pw.println("    virtual void marshal(DataStream& dataStream) const;");
        pw.println("    virtual void unmarshal(DataStream& dataStream);");
        pw.println();
        
        // Getter and setter methods for each ivar
        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            { 
                pw.println("    " + types.get(anAttribute.getType()) + " " + "get" + this.initialCap(anAttribute.getName()) + "() const; ");
                if(anAttribute.getIsDynamicListLengthField() == false)
                {
                     pw.println("    void " + "set" + this.initialCap(anAttribute.getName()) + "(" + types.get(anAttribute.getType()) + " pX); ");
                }
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            { 
                pw.println("    " + anAttribute.getType() + "& " + "get" + this.initialCap(anAttribute.getName()) + "(); ");
                pw.println("    const " + anAttribute.getType() + "&  get" + this.initialCap(anAttribute.getName()) + "() const; ");
                pw.println("    void set" + this.initialCap(anAttribute.getName()) + "(const " + anAttribute.getType() + "    &pX);");
            } 
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            { 
                // Sleaze. We need to figure out what type of array we are, and this is slightly complex. 
                String arrayType = this.getArrayType(anAttribute.getType());
                pw.println("    " + arrayType + "*  get" + this.initialCap(anAttribute.getName()) + "(); ");
                pw.println("    const " + arrayType + "*  get" + this.initialCap(anAttribute.getName()) + "() const; ");
                pw.println("    void set" + this.initialCap(anAttribute.getName()) + "( const " + arrayType + "*    pX);");
                if(anAttribute.getCouldBeString() == true)
                {
                    pw.println("    void " + "setByString" + this.initialCap(anAttribute.getName()) + "(const " + arrayType + "* pX);");
                }

            }
            
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
            { 
                pw.println("    std::vector<" + anAttribute.getType() + ">& " + "get" + this.initialCap(anAttribute.getName()) + "(); ");
                pw.println("    const std::vector<" + anAttribute.getType() + ">& " + "get" + this.initialCap(anAttribute.getName()) + "() const; ");
                pw.println("    void set" + this.initialCap(anAttribute.getName()) + "(const std::vector<" + anAttribute.getType() + ">&    pX);");
            }
            
            pw.println();
        }    
        
        // Generate a getMarshalledSize() method header
        pw.println();
        pw.println("virtual int getMarshalledSize() const;");
        pw.println();
        
        // Generate an equality operator 
        pw.println("     bool operator  ==(const " + aClass.getName() + "& rhs) const;");
        
        pw.println("};");
        
        // Close out namespace brace, if any
        if(namespace != null)
        {
            pw.println("}");
        }
        
        // Close if #ifndef statement that prevents multiple #includes
        pw.println("\n#endif");
        
        this.writeLicenseNotice(pw);
        
        pw.flush();
        pw.close();
    } // End of try
    catch(Exception e)
    {
        System.out.println(e);
    }
                
} // End write header file

public void writeCppFile(GeneratedClass aClass)
{
    try
   {
        String name = aClass.getName();
        //System.out.println("Creating cpp and .h source code files for " + name);
        String headerFullPath = directory + "/" + name + ".cpp";
        File outputFile = new File(headerFullPath);
        outputFile.createNewFile();
        PrintWriter pw = new PrintWriter(outputFile);
         
        String namespace = languageProperties.getProperty("namespace");
        if(namespace==null)
            namespace ="";
        else
            namespace=namespace +"/";
        
        pw.println("#include <" + namespace + aClass.getName() + ".h> ");
        pw.println();
        
        namespace = languageProperties.getProperty("namespace");
        if(namespace != null)
        {
            pw.println("using namespace " + namespace + ";\n");
        }
        
        pw.println();
        
        // Write ctor 
        this.writeCtor(pw, aClass);
        this.writeDtor(pw, aClass);
        
        // Write the getter and setter methods for each of the attributes
        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
            this.writeGetterMethod(pw, aClass, anAttribute);
            this.writeSetterMethod(pw, aClass, anAttribute);
        }
        
        // Write marshal and unmarshal methods
        this.writeMarshalMethod(pw, aClass);
        this.writeUnmarshalMethod(pw, aClass);
        
        // Write a comparision operator
        this.writeEqualityOperator(pw, aClass);
        
        // Method to determine the marshalled length of the PDU
        this.writeGetMarshalledSizeMethod(pw, aClass);
        
        // License notice
        this.writeLicenseNotice(pw);
       
        pw.flush();
        pw.close();
    }
    catch(Exception e)
    {
        System.out.println(e);
    }
}

/**
 * Write the code for an equality operator. This allows you to compare
 * two objects for equality.
 * The code should look like
 * 
 * bool operator ==(const ClassName& rhs)
 * return (_ivar1==rhs._ivar1 && _var2 == rhs._ivar2 ...)
 *
 */
public void writeEqualityOperator(PrintWriter pw, GeneratedClass aClass)
{
    try
    {
        pw.println();
        pw.println("bool " + aClass.getName() + "::operator ==(const " + aClass.getName() + "& rhs) const");
        pw.println(" {");
        pw.println("     bool ivarsEqual = true;");
        pw.println();
        
        // Handle the superclass, if any
        String parentClass = aClass.getParentClass();
        if(!(parentClass.equalsIgnoreCase("root")) )
        {
            pw.println("     ivarsEqual = " + parentClass + "::operator==(rhs);");
            pw.println();
        }
        
        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE || anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                if(anAttribute.getIsDynamicListLengthField() == false)
                {
                    pw.println("     if( ! (" + IVAR_PREFIX + anAttribute.getName() + " == rhs." + IVAR_PREFIX + anAttribute.getName() + ") ) ivarsEqual = false;");
                }
                /*
                else
                {
                    pw.println("     if( ! (  this.get" + this.initialCap(anAttribute.getName()) + "() == rhs.get" + this.initialCap(anAttribute.getName()) + "()) ) ivarsEqual = false;");
                }
                 */
                
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            {
                String indexType = (String)types.get(anAttribute.getType());
                
                pw.println();
                pw.println("     for(" + indexType + " idx = 0; idx < " + anAttribute.getListLength() + "; idx++)");
                pw.println("     {");
                pw.println("          if(!(" + IVAR_PREFIX + anAttribute.getName() + "[idx] == rhs." + IVAR_PREFIX + anAttribute.getName() + "[idx]) ) ivarsEqual = false;");
                pw.println("     }");
                pw.println();
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
            {
                pw.println();
                pw.println("     for(size_t idx = 0; idx < " + IVAR_PREFIX + anAttribute.getName() + ".size(); idx++)");
                pw.println("     {");
               // pw.println("        " + aClass.getName() + " x = " + IVAR_PREFIX + anAttribute.getName() + "[idx];");
                pw.println("        if( ! ( " + IVAR_PREFIX + anAttribute.getName() + "[idx] == rhs." + IVAR_PREFIX + anAttribute.getName() + "[idx]) ) ivarsEqual = false;");
                pw.println("     }");
                pw.println();
            }
            
        }
        
        
        pw.println();
        pw.println("    return ivarsEqual;");
        pw.println(" }");
    }
    catch(Exception e)
    {
        System.out.println(e);
    }
    
}

/**
 * Write the code for a method that marshals out the object into a DIS format
 * byte array.
 */
public void writeMarshalMethod(PrintWriter pw, GeneratedClass aClass)
{
    try
    {
        pw.println("void " + aClass.getName() + "::" + "marshal(DataStream& dataStream) const");
        pw.println("{");
        
        // If this inherits from one of our classes, we should call the superclasses' 
        // marshal method first. The syntax for this is SuperclassName::marshal(dataStream).
        
        // If it's not already a root class
        if(!(aClass.getParentClass().equalsIgnoreCase("root")))
        {
            String superclassName = aClass.getParentClass();
            pw.println("    " + superclassName + "::marshal(dataStream); // Marshal information in superclass first");
        }
            
        
        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
            
            // Write out the code to marshal this, depending on the type of attribute
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            { 
                if(anAttribute.getIsDynamicListLengthField() == false)
                {
                     pw.println("    dataStream << " +  IVAR_PREFIX + anAttribute.getName() + ";");
                }
                else
                {
                     ClassAttribute listAttribute = anAttribute.getDynamicListClassAttribute();
                     pw.println("    dataStream << ( " + types.get(anAttribute.getType()) + " )" +  IVAR_PREFIX + listAttribute.getName() + ".size();");
                }
               
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            { 
                pw.println("    " +  IVAR_PREFIX + anAttribute.getName() + ".marshal(dataStream);");
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            { 
                pw.println();
                pw.println("     for(size_t idx = 0; idx < " + anAttribute.getListLength() + "; idx++)");
                pw.println("     {");
                
                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.
                
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                
                if(marshalType == null) // It's a class
                {
                    pw.println("     " +  IVAR_PREFIX + anAttribute.getName() + "[idx].marshal(dataStream);");
                }
                else
                {
                    pw.println("        dataStream << " +  IVAR_PREFIX + anAttribute.getName() + "[idx];");
                }
                
                pw.println("     }");
                pw.println();
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
            { 
                pw.println();
                pw.println("     for(size_t idx = 0; idx < " +  IVAR_PREFIX + anAttribute.getName() + ".size(); idx++)");
                pw.println("     {");
                
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                
                if(marshalType == null) // It's a class
                {
                    pw.println("        " + anAttribute.getType() + " x = " +  IVAR_PREFIX + anAttribute.getName() + "[idx];");
                    pw.println("        x.marshal(dataStream);");
                }
                else // it's a primitive
                {
                    pw.println("        " + anAttribute.getType() + " x = " +  IVAR_PREFIX + anAttribute.getName() + "[idx];");
                    pw.println("    dataStream <<  x;"); 
                }
               
                    pw.println("     }");
                    pw.println();
            }
        }
        pw.println("}");
        pw.println();
    
    }
  catch(Exception e)
  {
      System.out.println(e);
  }
}

public void writeUnmarshalMethod(PrintWriter pw, GeneratedClass aClass)
{
  try
  {
    pw.println("void " + aClass.getName() + "::" + "unmarshal(DataStream& dataStream)");
    pw.println("{");
    
    // If it's not already a root class
    if(!(aClass.getParentClass().equalsIgnoreCase("root")))
    {
        String superclassName = aClass.getParentClass();
        pw.println("    " + superclassName + "::unmarshal(dataStream); // unmarshal information in superclass first");
    }
    
    for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
    {
        ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
        
        // Write out the code to marshal this, depending on the type of attribute
        
        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
        { 
            pw.println("    dataStream >> " +  IVAR_PREFIX + anAttribute.getName() + ";");
        }
        
        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
        { 
            pw.println("    " +  IVAR_PREFIX + anAttribute.getName() + ".unmarshal(dataStream);");
        }
        
        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
        { 
            pw.println();
            pw.println("     for(size_t idx = 0; idx < " + anAttribute.getListLength() + "; idx++)");
            pw.println("     {");
            pw.println("        dataStream >> " +  IVAR_PREFIX + anAttribute.getName() + "[idx];");
            pw.println("     }");
            pw.println();
        }
        
        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
        { 
            pw.println();
            pw.println("     " + IVAR_PREFIX + anAttribute.getName() + ".clear();"); // Clear out any existing objects in the list
            pw.println("     for(size_t idx = 0; idx < " + IVAR_PREFIX + anAttribute.getCountFieldName() + "; idx++)");
            pw.println("     {");
            
            // This is some sleaze. We're an list, but an list of what? We could be either a
            // primitive or a class. We need to figure out which. This is done via the expedient
            // but not very reliable way of trying to do a lookup on the type. If we don't find
            // it in our map of primitives to marshal types, we assume it is a class.
            
            String marshalType = marshalTypes.getProperty(anAttribute.getType());
            
            if(marshalType == null) // It's a class
            {
                pw.println("        " + anAttribute.getType() + " x;");
                pw.println("        x.unmarshal(dataStream);" );
                pw.println("        " +  IVAR_PREFIX + anAttribute.getName() + ".push_back(x);");
            }
            else // It's a primitive
            {
                pw.println("       " +  IVAR_PREFIX + anAttribute.getName() + "[idx] << dataStream");
            }

            pw.println("     }");
        }
    }
    
    pw.println("}");
    pw.println();
    
}
catch(Exception e)
{
    System.out.println(e);
}
}

/** 
 * Write a constructor. This uses an initialization list to initialize the various object
* ivars in the class. God, C++ is a PITA. The result should be something like
* Foo::Foo() : bar(Bar(), baz(Baz()
*/
private void writeCtor(PrintWriter pw, GeneratedClass aClass)
{
    boolean colonForInitializerListUsed = false;
    
    pw.print(aClass.getName() + "::" + aClass.getName() + "()");
    
    // Need to do a pre-flight here; cycle throguh the attributes and get a count
    // of the attribtes that are either primitives or objects. The variable lists
    // and fixed length lists are not initialized in the initializer list.
    int attributeCount = 0;
    
    for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
    {
        ClassAttribute attribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
        if((attribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE) ||
           (attribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF))
        {
            attributeCount++;
        }
    }
        
        // If this has a superclass, class the constructor for that (via the initializer list)
        if(!(aClass.getParentClass().equalsIgnoreCase("root")))
        {
             // Do an initailizer list for the ctor    
            pw.print(" : "); // Start initializer list
            colonForInitializerListUsed = true;
            pw.print(aClass.getParentClass() + "()");
            if(attributeCount > 0)
                pw.print(",");
            pw.println();
        }
        
       // If we have one or more things in the initializer list, and if we haven't already started an
       // initializer list with the superclass, print the colon that starts the initializer list
       if((attributeCount > 0) && (colonForInitializerListUsed == false))
           pw.println(":");
    
        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);   
            
            // This is a primitive type; initialize it to either the default value specified in 
            // the XML file or to zero. Tends to minimize the possiblity
            // of bad stack-allocated values hosing the system.
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            { 
                
                String defaultValue = anAttribute.getDefaultValue();
                String initialValue = "0";
                String ivarType = anAttribute.getType();
                if( (ivarType.equalsIgnoreCase("float")) || (ivarType.equalsIgnoreCase("double")))
                    initialValue = "0.0";
                
                if(defaultValue != null)
                    initialValue = defaultValue;
                
                pw.print("   " + IVAR_PREFIX + anAttribute.getName() + "(" + initialValue + ")");
                
                attributeCount--;
                if(attributeCount != 0)
                {
                    pw.println(", "); // Every initiailizer list element should have a following comma except the last
                }
                         
            }
            
                       
            // We need to allcoate ivars that are objects....
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            { 
               // pw.print(" " + anAttribute.getName() + "( " + anAttribute.getType() + "())" );
                pw.print("   " +  IVAR_PREFIX + anAttribute.getName() + "()" );
                attributeCount--;
                if(attributeCount != 0)
                {
                    pw.println(", "); // Every initiailizer list element should have a following comma except the last
                }
            }
        } // end of loop through attributes
    
    pw.println("\n{");
        
        // Set initial values
        List inits = aClass.getInitialValues();
        for(int idx = 0; idx < inits.size(); idx++)
        {
            InitialValue anInitialValue = (InitialValue)inits.get(idx);
            String setterName = anInitialValue.getSetterMethodName();
            pw.println("    " + setterName + "( " + anInitialValue.getVariableValue() + " );");
        }
    
       for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
       {
          ClassAttribute attribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
        
          // We need to initialize primitive array types
          if(attribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
          {
              pw.println("     // Initialize fixed length array");
              int arrayLength = attribute.getListLength();
              String indexName = "length" + attribute.getName();
              pw.println("     for(int " + indexName + "= 0; " + indexName + " < " + arrayLength + "; " + indexName + "++)");
              pw.println("     {");
              pw.println("         _" + attribute.getName() + "[" + indexName + "] = 0;");
              pw.println("     }");
              pw.println();
          }
       }
    
    pw.println("}\n");
}

/**
 * Generate a destructor method, which deallocates objects
 */
private void writeDtor(PrintWriter pw, GeneratedClass aClass)
{
    pw.println(aClass.getName() + "::~" + aClass.getName() + "()");
    pw.println("{");
    
    for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
    {
        ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
        
        // We need to deallocate ivars that are objects....
        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
        { 
           pw.println("    " +  IVAR_PREFIX + anAttribute.getName() + ".clear();");
        } // end of if object
    } // end of loop through attributes
    
    pw.println("}\n");
}

private void writeGetterMethod(PrintWriter pw, GeneratedClass aClass, ClassAttribute anAttribute)
{
    if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
    { 
        pw.println(types.get(anAttribute.getType()) + " " + aClass.getName()  +"::" + "get" + this.initialCap(anAttribute.getName()) + "() const");
        pw.println("{");
        if(anAttribute.getIsDynamicListLengthField() == false)
        {
            pw.println("    return " +  IVAR_PREFIX + anAttribute.getName() + ";");
        }
        else
        {
            ClassAttribute listAttribute = anAttribute.getDynamicListClassAttribute();
            pw.println( "   return " +  IVAR_PREFIX + listAttribute.getName() + ".size();");
        }
        
        pw.println("}\n");
    }
    
    if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
    { 
        pw.println(anAttribute.getType() + "& " + aClass.getName()  +"::" + "get" + this.initialCap(anAttribute.getName()) + "() ");
        pw.println("{");
        pw.println("    return " +  IVAR_PREFIX + anAttribute.getName() + ";");
        pw.println("}\n");
        
        pw.println("const " + anAttribute.getType() + "& " + aClass.getName()  +"::" + "get" + this.initialCap(anAttribute.getName()) + "() const");
        pw.println("{");
        pw.println("    return " +  IVAR_PREFIX + anAttribute.getName() + ";");
        pw.println("}\n");
    }
    
    if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
    { 
        pw.println(this.getArrayType(anAttribute.getType()) + "* " + aClass.getName()  +"::" + "get" + this.initialCap(anAttribute.getName()) + "() ");
        pw.println("{");
        pw.println("    return " +  IVAR_PREFIX + anAttribute.getName() + ";");
        pw.println("}\n");
        
        pw.println("const " + this.getArrayType(anAttribute.getType()) + "* " + aClass.getName()  +"::" + "get" + this.initialCap(anAttribute.getName()) + "() const");
        pw.println("{");
        pw.println("    return " +  IVAR_PREFIX + anAttribute.getName() + ";");
        pw.println("}\n");
        
    }
    
    
    if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
    { 
        pw.println("std::vector<" + anAttribute.getType() + ">& " + aClass.getName()  +"::" + "get" + this.initialCap(anAttribute.getName()) + "() ");
        pw.println("{");
        pw.println("    return " + IVAR_PREFIX +  anAttribute.getName() + ";");
        pw.println("}\n");
        
        pw.println("const std::vector<" + anAttribute.getType() + ">& " + aClass.getName()  +"::" + "get" + this.initialCap(anAttribute.getName()) + "() const");
        pw.println("{");
        pw.println("    return " +  IVAR_PREFIX + anAttribute.getName() + ";");
        pw.println("}\n");
    }
    
    //pw.println(aClass.getName() + "::get" + aClass.getName() + "()");
   //pw.println("{");
    
}

public void writeSetterMethod(PrintWriter pw, GeneratedClass aClass, ClassAttribute anAttribute)
{
    if((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE) && (anAttribute.getIsDynamicListLengthField() == false))
    { 
        pw.println("void " + aClass.getName()  + "::" + "set" + this.initialCap(anAttribute.getName()) + "(" + types.get(anAttribute.getType()) + " pX)");
        pw.println("{");
        if(anAttribute.getIsDynamicListLengthField() == false)
        pw.println( "    " +  IVAR_PREFIX + anAttribute.getName() + " = pX;");
        pw.println("}\n");
    }
    
    if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
    { 
        pw.println("void " + aClass.getName()  + "::" + "set" + this.initialCap(anAttribute.getName()) + "(const " + anAttribute.getType() + " &pX)");
        pw.println("{");
        pw.println( "    " +  IVAR_PREFIX + anAttribute.getName() + " = pX;");
        pw.println("}\n");
    }
    
    if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
    { 
        pw.println("void " + aClass.getName()  + "::" + "set" + this.initialCap(anAttribute.getName()) + "(const " + this.getArrayType(anAttribute.getType()) + "* x)");
        pw.println("{");
        
        // The safest way to handle this is to set up a loop and individually copy over the array in a for loop. This makes
        // primitives and objects handling orthogonal, vs. doing a memcpy, which is faster but may or may not work.

        pw.println("   for(int i = 0; i < " + anAttribute.getListLength() + "; i++)");
        pw.println("   {");
        pw.println("        " +  IVAR_PREFIX + anAttribute.getName() + "[i] = x[i];");
        pw.println("   }");
        pw.println("}\n");
        
        // An alternative that is c-string friendly
        
        if(anAttribute.getCouldBeString() == true)
        {
            pw.println("// An alternate method to set the value if this could be a string. This is not strictly comnpliant with the DIS standard.");
            pw.println("void " + aClass.getName()  + "::" + "setByString" + this.initialCap(anAttribute.getName()) + "(const " + this.getArrayType(anAttribute.getType()) + "* x)");
            pw.println("{");
            pw.println("   strncpy(_" + anAttribute.getName() + ", x, " + anAttribute.getListLength() + "-1);");
            pw.println("   _" + anAttribute.getName() + "[" + anAttribute.getListLength() + " -1] = '\\0';");
            pw.println("}");
            pw.println();
        }
    }
    
    
    if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
    { 
        pw.println("void " + aClass.getName()  + "::" + "set" + this.initialCap(anAttribute.getName()) + "(const std::vector<" + anAttribute.getType() + ">& pX)");
        pw.println("{");
        pw.println( "     " +  IVAR_PREFIX + anAttribute.getName() + " = pX;");
        pw.println("}\n");
    }
}

public void writeGetMarshalledSizeMethod(PrintWriter pw, GeneratedClass aClass)
{
    List ivars = aClass.getClassAttributes();
    
    // Generate a getMarshalledLength() method header
    pw.println();
    pw.println("int " + aClass.getName()  + "::" + "getMarshalledSize() const");
    pw.println("{");
    pw.println("   int marshalSize = 0;");
    pw.println();

    // Size of superclass is the starting point
    if(!aClass.getParentClass().equalsIgnoreCase("root"))
    {
        pw.println("   marshalSize = " + aClass.getParentClass() + "::getMarshalledSize();");
    }
    
    for(int idx = 0; idx < ivars.size(); idx++)
    {
        ClassAttribute anAttribute = (ClassAttribute)ivars.get(idx);
    
        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
        {
            pw.print("   marshalSize = marshalSize + ");
            pw.println(primitiveSizes.get(anAttribute.getType()) + ";  // " + IVAR_PREFIX + anAttribute.getName());
        }
        
        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
        {
            pw.print("   marshalSize = marshalSize + ");
            pw.println(IVAR_PREFIX + anAttribute.getName() + ".getMarshalledSize();  // " + IVAR_PREFIX + anAttribute.getName());
        }
        
        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
        {
            pw.print("   marshalSize = marshalSize + ");
            // If this is a fixed list of primitives, it's the list size times the size of the primitive.
            if(anAttribute.getUnderlyingTypeIsPrimitive() == true)
            {
                pw.println( anAttribute.getListLength() + " * " + primitiveSizes.get(anAttribute.getType()) + ";  // " + IVAR_PREFIX + anAttribute.getName());
            }
            else
            {
                //pw.println( anAttribute.getListLength() + " * " +  " new " + anAttribute.getType() + "().getMarshalledSize()"  + ";  // " + anAttribute.getName());
                pw.println(" THIS IS A CONDITION NOT HANDLED BY XMLPG: a fixed list array of objects. That's  why you got the compile error.");
            }
        }
        
        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
        {
            // If this is a dynamic list of primitives, it's the list size times the size of the primitive.
            if(anAttribute.getUnderlyingTypeIsPrimitive() == true)
            {
                pw.println( anAttribute.getName() + ".size() " + " * " + primitiveSizes.get(anAttribute.getType()) + ";  // " + IVAR_PREFIX + anAttribute.getName());
            }
            else
            {
                pw.println();
                pw.println("   for(int idx=0; idx < " + IVAR_PREFIX + anAttribute.getName() + ".size(); idx++)");
                pw.println("   {");
                //pw.println( anAttribute.getName() + ".size() " + " * " +  " new " + anAttribute.getType() + "().getMarshalledSize()"  + ";  // " + anAttribute.getName());
                pw.println("        " + anAttribute.getType() + " listElement = " + IVAR_PREFIX + anAttribute.getName() + "[idx];");
                pw.println("        marshalSize = marshalSize + listElement.getMarshalledSize();");
                pw.println("    }");
                pw.println();
            }
        }
        
    }
    pw.println("    return marshalSize;");
    pw.println("}");
    pw.println();
    
    
    
     
}
    
/** 
* returns a string with the first letter capitalized. 
*/
public String initialCap(String aString)
{
    StringBuffer stb = new StringBuffer(aString);
    stb.setCharAt(0, Character.toUpperCase(aString.charAt(0)));
    
    return new String(stb);
}

/**
 * Returns true if this class consists only of instance variables that are
 * primitives, such as short, int, etc. Things that are not allowed include
 * ivars that are classes, arrays, or variable length lists. If a class
 * contains any of these, false is returned.
 */
private boolean classHasOnlyPrimitives(GeneratedClass aClass)
{
    boolean isAllPrimitive = true;
    
    // Flip flag to false if anything is not a primitive.
    for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
    {
        ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
        if(anAttribute.getAttributeKind() != ClassAttribute.ClassAttributeType.PRIMITIVE)
        {
            isAllPrimitive = false;
            System.out.println("Not primitive for class " + aClass.getName() + " and attribute " + anAttribute.getName() + " " + anAttribute.getAttributeKind());
        }
    }
    
    return isAllPrimitive;
}

/**
 * Some code to figure out the characters to use for array types. We may have arrays of either primitives
 * or classes; this figures out which it is and returns the right string.
 */
private String getArrayType(String xmlType)
{
    String marshalType = marshalTypes.getProperty(xmlType);
    
    if(marshalType == null) // It's a class
    {
        return xmlType;
    }
    else // It's a primitive
    {
        return marshalType;
    }
    
}
                       
private void writeLicenseNotice(PrintWriter pw)
{
        pw.println("// Copyright (c) 1995-2009 held by the author(s).  All rights reserved.");
       
        pw.println("// Redistribution and use in source and binary forms, with or without");
        pw.println("// modification, are permitted provided that the following conditions");
        pw.println("//  are met:");
        pw.println("// ");
        pw.println("//  * Redistributions of source code must retain the above copyright");
        pw.println("// notice, this list of conditions and the following disclaimer.");
        pw.println("// * Redistributions in binary form must reproduce the above copyright");
        pw.println("// notice, this list of conditions and the following disclaimer");
        pw.println("// in the documentation and/or other materials provided with the");
        pw.println("// distribution.");
        pw.println("// * Neither the names of the Naval Postgraduate School (NPS)");
        pw.println("//  Modeling Virtual Environments and Simulation (MOVES) Institute");
        pw.println("// (http://www.nps.edu and http://www.MovesInstitute.org)");
        pw.println("// nor the names of its contributors may be used to endorse or");
        pw.println("//  promote products derived from this software without specific");
        pw.println("// prior written permission.");
        pw.println("// ");
        pw.println("// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS");
        pw.println("// AS IS AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT");
        pw.println("// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS");
        pw.println("// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE");
        pw.println("// COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,");
        pw.println("// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,");
        pw.println("// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;");
        pw.println("// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER");
        pw.println("// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT");
        pw.println("// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN");
        pw.println("// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE");
        pw.println("// POSSIBILITY OF SUCH DAMAGE.");
                       
}


}
