package edu.nps.moves.xmlpg;

import java.util.*;
import java.io.*;

/**
 * Given the input object, something of an abstract syntax tree, this generates
 * a source code file in the java language. It has ivars, getters,  setters,
 * and serialization/deserialization methods.
 *
 * @author DMcG
 */
public class JavaGenerator extends Generator
{
    /** Maps the primitive types listed in the XML file to the java types */
    Properties types = new Properties();
    
    /** What primitive types should be marshalled as. This may be different from
     * the Java get/set methods, ie an unsigned short might have ints as the getter/setter,
     * but is marshalled as a short.
    */
    Properties marshalTypes = new Properties();
    
    /** Similar to above, but used on unmarshalling. There are some special cases (unsigned
     * types) to be handled here.
     */
    Properties unmarshalTypes = new Properties();
    
    /** sizes of various primitive types */
    Properties primitiveSizes = new Properties();
    
    /** A property list that contains java-specific code generation information, such
     * as package names, imports, etc.
     */
    Properties javaProperties;
    
    public JavaGenerator(HashMap pClassDescriptions, String pDirectory, Properties pJavaProperties)
    {
        super(pClassDescriptions, pDirectory, pJavaProperties);
        
        // Set up a mapping between the strings used in the XML file and the strings used
        // in the java file, specifically the data types. This could be externalized to
        // a properties file, but there's only a dozen or so and an external props file
        // would just add some complexity.
        types.setProperty("unsigned short", "int");
        types.setProperty("unsigned byte", "short");
        types.setProperty("unsigned int", "long");
		types.setProperty("unsigned long", "long"); // This is wrong; java doesn't have an unsigned long. Placeholder for a later BigInt or similar type
        
        types.setProperty("byte", "byte");
        types.setProperty("short", "short");
        types.setProperty("int", "int");
        types.setProperty("long", "long");
        
        types.setProperty("double", "double");
        types.setProperty("float", "float");
        
        // Set up the mapping between primitive types and marshal types.
        
        marshalTypes.setProperty("unsigned short", "short");
        marshalTypes.setProperty("unsigned byte", "byte");
        marshalTypes.setProperty("unsigned int", "int");
		marshalTypes.setProperty("unsigned long", "long"); // This is wrong; no unsigned long type in java. Fix with a BigInt or similar
        
        marshalTypes.setProperty("byte", "byte");
        marshalTypes.setProperty("short", "short");
        marshalTypes.setProperty("int", "int");
        marshalTypes.setProperty("long", "long");
        
        marshalTypes.setProperty("double", "double");
        marshalTypes.setProperty("float", "float");
        
        // Unmarshalling types
        unmarshalTypes.setProperty("unsigned short", "UnsignedShort");
        unmarshalTypes.setProperty("unsigned byte", "UnsignedByte");
        unmarshalTypes.setProperty("unsigned int", "int");
		unmarshalTypes.setProperty("unsigned long", "long"); // ^^^ This is wrong--should be unsigned
        
        unmarshalTypes.setProperty("byte", "byte");
        unmarshalTypes.setProperty("short", "short");
        unmarshalTypes.setProperty("int", "int");
        unmarshalTypes.setProperty("long", "long");
        
        unmarshalTypes.setProperty("double", "double");
        unmarshalTypes.setProperty("float", "float");
        
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
     * Generate the classes and write them to a directory
     */
    public void writeClasses()
    {
        this.createDirectory();
        
        Iterator it = classDescriptions.values().iterator();
        
        while(it.hasNext())
        {
            try
           {
              GeneratedClass aClass = (GeneratedClass)it.next();
              String name = aClass.getName();
              
              // Create package structure, if any
              String pack = languageProperties.getProperty("package");
              String fullPath;
              
              // If we have a package specified, replace the dots in the package name (edu.nps.moves.dis)
              // with slashes (edu/nps/moves/dis and create that directory
              if(pack != null)
              {
                  pack = pack.replace(".", "/");
                  fullPath = directory + "/" + pack + "/" + name + ".java";
                  //System.out.println("full path is " + fullPath);
              }
              else
             {
                   fullPath = directory + "/" + name + ".java";
             }
			 //System.out.println("Creating Java source code file for " + fullPath);
              
              // Create the new, empty file, and create printwriter object for output to it
              File outputFile = new File(fullPath);
              outputFile.getParentFile().mkdirs();
              outputFile.createNewFile();
              PrintWriter pw = new PrintWriter(outputFile);
              
              // print the source code of the class to the file
              this.writeClass(pw, aClass);
           }
           catch(Exception e)
           {
               System.out.println("error creating source code " + e);
           }
            
        } // End while
    
    } // End write classes
    
      /**
     * Generate a source code file with getters, setters, ivars, and marshal/unmarshal
     * methods for one class. 
     */
    private void writeClass(PrintWriter pw, GeneratedClass aClass)
    {
        this.writeImports(pw, aClass);
		pw.flush();
        this.writeClassComments(pw, aClass);
		pw.flush();
        this.writeClassDeclaration(pw, aClass);
		pw.flush();
        this.writeIvars(pw, aClass);
		pw.flush();
        this.writeConstructor(pw, aClass);
		pw.flush();
        this.writeGetMarshalledSizeMethod(pw, aClass);
		pw.flush();
        this.writeGettersAndSetters(pw, aClass);
		pw.flush();
        this.writeMarshalMethod(pw, aClass);
		pw.flush();
        this.writeUnmarshallMethod(pw, aClass);
		pw.flush();
        this.writeMarshalMethodWithByteBuffer(pw, aClass);
		pw.flush();
        this.writeUnmarshallMethodWithByteBuffer(pw, aClass);
		pw.flush();
        if( aClass.getName().equals("Pdu") )
		{
            this.writeMarshalMethodToByteArray(pw, aClass);
			pw.flush();
        }
        
        if(aClass.isXmlRootElement())
        {
            this.writeXmlRootMarshallMethod(pw, aClass);
        }
        
        //this.writeXmlMarshallMethod(pw, aClass);
        this.writeEqualityMethod(pw, aClass);
        
        pw.println("} // end of class");
        pw.flush();
        pw.close();
    }
    
    /**
     * Writes the package and package import code at the top of the Java source file
     * 
     * @param pw
     * @param aClass
     */
    private void writeImports(PrintWriter pw, GeneratedClass aClass)
    {
         // Write the package name
        String packageName = languageProperties.getProperty("package");
        if(packageName != null)
        {
             pw.println("package " + packageName + ";" );
        }
        
        
        pw.println();
        
        // Write the various import statements
        String imports = languageProperties.getProperty("imports");
        StringTokenizer tokenizer = new StringTokenizer(imports, ", ");
        while(tokenizer.hasMoreTokens())
        {
            String aPackage = (String)tokenizer.nextToken();
            pw.println("import " + aPackage + ";");
        }
        if(aClass.isXmlRootElement())
        {
            pw.println("import javax.xml.bind.*;");
        }
        pw.println();
    }
    
    /**
     * Write the class comments block
     * @param pw
     * @param aClass
     */
    private void writeClassComments(PrintWriter pw, GeneratedClass aClass)
    {
         // Print class comments header
         pw.println("/**");
         if(aClass.getClassComments() != null)
          {
              pw.println(" * " + aClass.getClassComments());
              pw.println(" *");
              pw.println(" * Copyright (c) 2008, MOVES Institute, Naval Postgraduate School. All rights reserved.");
              pw.println(" * This work is licensed under the BSD open source license, available at https://www.movesinstitute.org/licenses/bsd.html");
              pw.println(" *");
              pw.println(" * @author DMcG");
          }
         pw.println(" */");
    }
    
    /**
     * Writes the class declaration, including any inheritence and interfaces
     * 
     * @param pw
     * @param aClass
     */
    private void writeClassDeclaration(PrintWriter pw, GeneratedClass aClass)
    {
        // Class declaration
         String parentClass = aClass.getParentClass();
         if(parentClass.equalsIgnoreCase("root"))
         {
               parentClass = "Object";
         }
         
         /** Used in XML marshalling--if this is the top level container, mark up the class for jaxb */
         if(aClass.isXmlRootElement() == true)
         {
             pw.println("@XmlRootElement");
         }
         pw.println("public class " + aClass.getName() + " extends " + parentClass + " implements Serializable");
         
        pw.println("{");
    }
    
    private void writeIvars(PrintWriter pw, GeneratedClass aClass)
    {
        List ivars = aClass.getClassAttributes();
        for(int idx = 0; idx < ivars.size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)ivars.get(idx);
            
            // This attribute is a primitive. 
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                // The primitive type--we need to do a lookup from the abstract type in the
                // xml to the java-specific type. The output should look something like
                //
                // /** This is a comment */
                // protected int foo;
                //
                String attributeType = types.getProperty(anAttribute.getType());
                if(anAttribute.getComment() != null)
                {
                    pw.println("   /** " + anAttribute.getComment() + " */");
                }
                
                String defaultValue = anAttribute.getDefaultValue();
    
                pw.print("   protected " + attributeType + "  " + anAttribute.getName());
                if(defaultValue != null)
                    pw.print(" = " + defaultValue);
                pw.println(";\n");
            } // end of primitive attribute type
            
            // this attribute is a reference to another class defined in the XML document, The output should look like
            //
            // /** This is a comment */
            // protected AClass foo = new AClass();
            //
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                String attributeType = anAttribute.getType();
                if(anAttribute.getComment() != null)
                {
                    pw.println("   /** " + anAttribute.getComment() + " */");
                }
                
                pw.println("   protected " + attributeType + "  " + anAttribute.getName() + " = new " + attributeType + "(); \n");
            }
        
            // The attribute is a fixed list, ie an array of some type--maybe primitve, maybe a class.
            
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST) )
            {
                String attributeType = anAttribute.getType();
                int listLength = anAttribute.getListLength();
                String listLengthString = (new Integer(listLength)).toString();
                
                if(anAttribute.getComment() != null)
                {
                    pw.println("   /** " + anAttribute.getComment() + " */");
                }
                
                if(anAttribute.getUnderlyingTypeIsPrimitive() == true)
                {
                    pw.println("   protected " + types.getProperty(attributeType) + "[]  " + anAttribute.getName() + " = new " + 
                               types.getProperty(attributeType) + "[" + listLengthString + "]" + "; \n");
                }
                else if(anAttribute.listIsClass() == true) 
                {
                    pw.println("   protected " + attributeType + "[]  " + anAttribute.getName() + " = new " + 
                               attributeType + "[" + listLengthString + "]" + "; \n");
                }
            }
            
            // The attribute is a variable list of some kind. 
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) )
            {
                String attributeType = anAttribute.getType();
                int listLength = anAttribute.getListLength();
                String listLengthString = (new Integer(listLength)).toString();
                
                if(anAttribute.getComment() != null)
                {
                    pw.println("   /** " + anAttribute.getComment() + " */");
                }
                
                pw.println("   protected List< " + attributeType + "> " + anAttribute.getName() + " = new ArrayList<" + attributeType + ">(); ");
            }
        } // End of loop through ivars
    }
    
    private void writeConstructor(PrintWriter pw, GeneratedClass aClass)
    {
        List ivars = aClass.getClassAttributes();
        
         // Write a constructor
        pw.println();
        pw.println("/** Constructor */");
        pw.println(" public " + aClass.getName() + "()");
        pw.println(" {");
        
        // Set primitive types with initial values
        List inits = aClass.getInitialValues();
        for(int idx = 0; idx < inits.size(); idx++)
        {
            InitialValue anInit = (InitialValue)inits.get(idx);
            
            // This is irritating. we have to match up the attribute name with the type,
            // so we can do a cast. Otherwise java pukes because it wants to interpret all
            // numeric strings as ints or doubles, and the attribute may be a short.
            
            boolean found = false;
            GeneratedClass currentClass = aClass;
            String aType = null;
            
            while(currentClass != null)
            {
                List thisClassesAttributes = currentClass.getClassAttributes();
                for(int jdx = 0; jdx < thisClassesAttributes.size(); jdx++)
                {
                    ClassAttribute anAttribute = (ClassAttribute)thisClassesAttributes.get(jdx);
                    //System.out.println("--checking " + anAttribute.getName() + " against inital value " + anInitialValue.getVariable());
                    if(anInit.getVariable().equals(anAttribute.getName()))
                    {
                        found = true;
                        aType = anAttribute.getType();
                        break;
                    }
                }
                currentClass = (GeneratedClass)classDescriptions.get(currentClass.getParentClass());
            }
            if(!found)
            {
                System.out.println("Could not find initial value matching attribute name for " + anInit.getVariable() + " in class " + aClass.getName());
            }
            else
            {
                pw.println("    " + anInit.getSetterMethodName() + "( (" +  types.getProperty(aType) + ")" + anInit.getVariableValue() + " );");
            }
        } // End initialize initial values
        
        // If we have fixed lists with object instances in them, initialize those

        for(int idx = 0; idx < ivars.size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)ivars.get(idx);
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            {
                //System.out.println("Generating constructor fixed list for " + anAttribute.getName() + " listIsClass:" + anAttribute.listIsClass());
                if(anAttribute.listIsClass() == true)
                {
                    pw.println("\n     for(int idx = 0; idx < " + anAttribute.getName() + ".length; idx++)");
                    pw.println("     {");
                    pw.println("         " + anAttribute.getName() + "[idx] = new " + anAttribute.getType() + "();");
                    pw.println("     }\n");
                }
            }
                
        }
        pw.println(" }");
        
    }
    
    public void writeGetMarshalledSizeMethod(PrintWriter pw, GeneratedClass aClass)
    {
        List ivars = aClass.getClassAttributes();
         // Create a getMarshalledSize() method
        pw.println();
        pw.println("public int getMarshalledSize()");
        pw.println("{");
        pw.println("   int marshalSize = 0; ");
        pw.println();
        
        // Size of superclass is the starting point
        if(!aClass.getParentClass().equalsIgnoreCase("root"))
        {
            pw.println("   marshalSize = super.getMarshalledSize();");
        }
        
        for(int idx = 0; idx < ivars.size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)ivars.get(idx);
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                pw.print("   marshalSize = marshalSize + ");
                pw.println(primitiveSizes.get(anAttribute.getType()) + ";  // " + anAttribute.getName());
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                pw.print("   marshalSize = marshalSize + ");
                pw.println(anAttribute.getName() + ".getMarshalledSize();  // " + anAttribute.getName());
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            {
                //System.out.println("Generating fixed list for " + anAttribute.getName() + " listIsClass:" + anAttribute.listIsClass());
                // If this is a fixed list of primitives, it's the list size times the size of the primitive.
                if(anAttribute.getUnderlyingTypeIsPrimitive() == true)
                {
                    pw.println( "   marshalSize = marshalSize + " + anAttribute.getListLength() + " * " + primitiveSizes.get(anAttribute.getType()) + ";  // " + anAttribute.getName());
                }
                else if(anAttribute.listIsClass() == true)
                {
                    pw.println("\n   for(int idx = 0; idx < " + anAttribute.getName() + ".length; idx++)");
                    pw.println("   {");
                    pw.println("       marshalSize = marshalSize + " + anAttribute.getName() + "[idx].getMarshalledSize();");
                    pw.println("   }\n");
                }
                else
                {
                    //pw.println( anAttribute.getListLength() + " * " +  " new " + anAttribute.getType() + "().getMarshalledSize()"  + ";  // " + anAttribute.getName());
                    pw.println(" THIS IS A CONDITION NOT HANDLED BY XMLPG: a fixed list array of lists. That's  why you got the compile error.");
                }
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
            {
                // If this is a dynamic list of primitives, it's the list size times the size of the primitive.
                if(anAttribute.getUnderlyingTypeIsPrimitive() == true)
                {
                    pw.println( anAttribute.getName() + ".size() " + " * " + primitiveSizes.get(anAttribute.getType()) + ";  // " + anAttribute.getName());
                }
                else
                {
                    pw.println("   for(int idx=0; idx < " + anAttribute.getName() + ".size(); idx++)");
                    pw.println("   {");
                    //pw.println( anAttribute.getName() + ".size() " + " * " +  " new " + anAttribute.getType() + "().getMarshalledSize()"  + ";  // " + anAttribute.getName());
                    pw.println("        " + anAttribute.getType() + " listElement = " + anAttribute.getName() + ".get(idx);");
                    pw.println("        marshalSize = marshalSize + listElement.getMarshalledSize();");
                    pw.println("   }");
                }
            }
            
        }
        
        pw.println();
        pw.println("   return marshalSize;");
        pw.println("}");
        pw.println();
    }
    
    private void writeGettersAndSetters(PrintWriter pw, GeneratedClass aClass)
    {
        List ivars = aClass.getClassAttributes();
        
         pw.println();
        
        for(int idx = 0; idx < ivars.size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)ivars.get(idx);
            
            // The setter method should be of the form
            //
            // public void setName(AType pName)
            // { name = pName;
            // }
            //
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                if(anAttribute.getIsDynamicListLengthField() == false)
                {
                    String beanType = types.getProperty(anAttribute.getType());
                    pw.println("public void set" + this.initialCap(anAttribute.getName()) + "(" + beanType + " p" + this.initialCap(anAttribute.getName()) + ")");
                    pw.println("{ " + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                    pw.println("}");
                    
                    pw.println();
                    
                    pw.println("@XmlAttribute");
                    pw.println("public " + beanType + " get" + this.initialCap(anAttribute.getName()) + "()");
                    pw.println("{ return " + anAttribute.getName() + "; \n}");
                    pw.println();   
                }
                else // This is the count field for a dynamic list
                {
                    String beanType = types.getProperty(anAttribute.getType());
                    ClassAttribute listAttribute = anAttribute.getDynamicListClassAttribute();
                    
                    pw.println("@XmlAttribute");
                    pw.println("public " + beanType + " get" + this.initialCap(anAttribute.getName()) + "()");
                    pw.println("{ return (" + beanType + ")" + listAttribute.getName() + ".size();");
                    pw.println("}");
                    pw.println();
                    
                    pw.println("/** Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.");
                    pw.println(" * The get" + anAttribute.getName() + " method will also be based on the actual list length rather than this value. ");
                    pw.println(" * The method is simply here for java bean completeness.");
                    pw.println(" */");
                    pw.println("public void set" + this.initialCap(anAttribute.getName()) + "(" + beanType + " p" + this.initialCap(anAttribute.getName()) + ")");
                    pw.println("{ " + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                    pw.println("}");
                    pw.println();
                    
                }
            } // End is primitive
            
            // The attribute is a class of some sort. Generate getters and setters.
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                pw.println("public void set" + this.initialCap(anAttribute.getName()) + "(" + anAttribute.getType() + " p" + this.initialCap(anAttribute.getName()) + ")");
                pw.println("{ " + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                pw.println("}");
                
                pw.println();
                
                pw.println("@XmlElement");
                pw.println("public " + anAttribute.getType() + " get" + this.initialCap(anAttribute.getName()) + "()");
                pw.println("{ return " + anAttribute.getName() + "; \n}");
                pw.println();
                
            }
            
            // The attribute is an array of some sort. Generate getters and setters.
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST) )
            {
                if(anAttribute.getUnderlyingTypeIsPrimitive())
                {
                    pw.println("public void set" + this.initialCap(anAttribute.getName()) + "(" + types.getProperty(anAttribute.getType()) + "[] p" + this.initialCap(anAttribute.getName()) + ")");
                    pw.println("{ " + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                    pw.println("}");
                    
                    pw.println();
                    
                    pw.println("@XmlElement(name=\"" + anAttribute.getName() + "\" )");
                    pw.println("public " + types.getProperty(anAttribute.getType()) + "[] get" + this.initialCap(anAttribute.getName()) + "()");
                    pw.println("{ return " + anAttribute.getName() + "; }");
                    pw.println();                    
                }
                 else if(anAttribute.listIsClass() == true)
                {
                    pw.println("public void set" + this.initialCap(anAttribute.getName()) + "(" + anAttribute.getType() + "[] p" + this.initialCap(anAttribute.getName()) + ")");
                    pw.println("{ " + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                    pw.println("}");
                    
                    pw.println();
                    
                    pw.println("@XmlElementWrapper(name=\"" + anAttribute.getName() + "Array\" )");
                    pw.println("public " + anAttribute.getType() + "[] get" + this.initialCap(anAttribute.getName()) + "()");
                    pw.println("{ return " + anAttribute.getName() + "; }");
                    pw.println();         
       
                }
                
            }
                
            
             if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) )
             {
                 pw.println("public void set" + this.initialCap(anAttribute.getName()) + "(List<" + anAttribute.getType() + ">" + " p" + this.initialCap(anAttribute.getName()) + ")");
                 pw.println("{ " + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                 pw.println("}");
                 
                 pw.println();
                 
                 pw.println("@XmlElementWrapper(name=\"" + anAttribute.getName() + "List\" )");
                 pw.println("public List<" + anAttribute.getType() + ">"  + " get" + this.initialCap(anAttribute.getName()) + "()");
                 pw.println("{ return " + anAttribute.getName() + "; }");
                 pw.println();
                 
             }
        } // End of loop trough writing getter/setter methods
        
    }
    
    private void writeMarshalMethod(PrintWriter pw, GeneratedClass aClass)
    {
        List ivars = aClass.getClassAttributes();
        
        pw.println();
        pw.println("public void marshal(DataOutputStream dos)");
        pw.println("{");
         
        // If we're a sublcass of another class, we should first call super
        // to make sure the superclass's ivars are marshaled out.
        
        String superclassName = aClass.getParentClass();
        if(!(superclassName.equalsIgnoreCase("root")))
        {
            pw.println("    super.marshal(dos);");
        }
        
       
        pw.println("    try \n    {");
        
        // Loop through the class attributes, generating the output for each.
        
        ivars = aClass.getClassAttributes();
        for(int idx = 0; idx < ivars.size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)ivars.get(idx);
        
            // Write out a method call to serialize a primitive type
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                String capped = this.initialCap(marshalType);
                
                // If we're a normal primitivetype, marshal out directly; otherwise, marshall out
                // the list length.
                if(anAttribute.getIsDynamicListLengthField() == false)
                {
                     pw.println("       dos.write" + capped + "( (" + marshalType + ")" + anAttribute.getName() + ");");
                }
               else
               {
                   ClassAttribute listAttribute = anAttribute.getDynamicListClassAttribute();
                   pw.println("       dos.write" + capped + "( (" + marshalType + ")" + listAttribute.getName() + ".size());");
               }
                
            }
            
            // Write out a method call to serialize a class.
            if( anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF )
            {
                String marshalType = anAttribute.getType();
            
                pw.println("       " + anAttribute.getName() + ".marshal(dos);" );
            }
            
            // Write out the method call to marshal a fixed length list, aka an array.
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST) )
            {
                pw.println();
                pw.println("       for(int idx = 0; idx < " + anAttribute.getName() + ".length; idx++)");
                pw.println("       {");
                
                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.
                
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                
                if(anAttribute.getUnderlyingTypeIsPrimitive())
                {
                    String capped = this.initialCap(marshalType);
                    pw.println("           dos.write" + capped + "(" + anAttribute.getName() + "[idx]);");
                }
                else
                {
                     pw.println("           " + anAttribute.getName() + "[idx].marshal(dos);" );
                }
            
                pw.println("       } // end of array marshaling");
                pw.println();
            }
            
            // Write out a section of code to marshal a variable length list. The code should look like
            //
            // for(int idx = 0; idx < attrName.size(); idx++)
            // { anAttribute.marshal(dos);
            // }
            //    
            
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) )
            {
                pw.println();
                pw.println("       for(int idx = 0; idx < " + anAttribute.getName() + ".size(); idx++)");
                pw.println("       {");
                
                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.
                
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                
                if(anAttribute.getUnderlyingTypeIsPrimitive())
                {
                    String capped = this.initialCap(marshalType);
                    pw.println("           dos.write" + capped + "(" + anAttribute.getName() + ");");
                }
                else
                {
                    pw.println("            " + anAttribute.getType() + " a" + initialCap(anAttribute.getType() + " = " +
                                                                                     anAttribute.getName() + ".get(idx);"));
                    pw.println("            a" + initialCap(anAttribute.getType()) + ".marshal(dos);" );
                }
                
                pw.println("       } // end of list marshalling");
                pw.println();
            }   
        } // End of loop through the ivars for a marshal method
        
        pw.println("    } // end try \n    catch(Exception e)");
        pw.println("    { \n      System.out.println(e);}");
        
        pw.println("    } // end of marshal method");
    }
    
    private void writeUnmarshallMethod(PrintWriter pw, GeneratedClass aClass)
    {
        List ivars = aClass.getClassAttributes();
        String superclassName;
        
		pw.println();
        pw.println("public void unmarshal(DataInputStream dis)");
        pw.println("{");
		pw.flush();
        
        superclassName = aClass.getParentClass();
        if(!(superclassName.equalsIgnoreCase("root")))
        {
            pw.println("     super.unmarshal(dis);\n");
        }
        
        
        pw.println("    try \n    {");
        
        // Loop through the class attributes, generating the output for each.
        
        ivars = aClass.getClassAttributes();
        for(int idx = 0; idx < ivars.size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)ivars.get(idx);
            
            // Write out a method call to deserialize a primitive type
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                String marshalType = unmarshalTypes.getProperty(anAttribute.getType());
                String capped = this.initialCap(marshalType);
                if(marshalType.equalsIgnoreCase("UnsignedByte"))
                    pw.println("       " + anAttribute.getName() + " = (short)dis.read" + capped + "();");
                else if (marshalType.equalsIgnoreCase("UnsignedShort"))
                    pw.println("       " + anAttribute.getName() + " = (int)dis.read" + capped + "();");
				else if(marshalType.equalsIgnoreCase("UnsignedLong"))
					pw.println("       " + anAttribute.getName() + " = (int)dis.readLong" + "();"); // ^^^This is wrong; need to read unsigned here
                else
                    pw.println("       " + anAttribute.getName() + " = dis.read" + capped + "();");
                pw.flush();
            }
            
            // Write out a method call to deserialize a class.
            if( anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                String marshalType = anAttribute.getType();
                
                pw.println("       " + anAttribute.getName() + ".unmarshal(dis);" );
            }
            
            // Write out the method call to unmarshal a fixed length list, aka an array.
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST) )
            {
                pw.println("       for(int idx = 0; idx < " + anAttribute.getName() + ".length; idx++)");
                pw.println("       {");
                
                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.
                
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                
                if(marshalType == null) // It's a class
                {
                    pw.println("           " + anAttribute.getName() + "[idx].unmarshal(dis);" );
                }
                else // It's a primitive
                {
                    String capped = this.initialCap(marshalType);
                    pw.println("                " +  anAttribute.getName() + "[idx] = dis.read" + capped + "();");
                }
                
                pw.println("       } // end of array unmarshaling");
            } // end of array unmarshalling
            
            // Unmarshall a variable length array.
            
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) )
            {
                pw.println("       for(int idx = 0; idx < " + anAttribute.getCountFieldName() + "; idx++)");
                pw.println("       {");
                
                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.
                
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                
                if(marshalType == null) // It's a class
                {
                    pw.println("           " + anAttribute.getType() + " anX = new " + anAttribute.getType() + "();");
                    pw.println("           anX.unmarshal(dis);");
                    pw.println("           " + anAttribute.getName() + ".add(anX);");
                }
                else // It's a primitive
                {
                    String capped = this.initialCap(marshalType);
                    pw.println("           dis.read" + capped + "(" + anAttribute.getName() + ");");
                }
                pw.println("       }");
                pw.println();
            } // end of unmarshalling a variable list
            
        } // End of loop through ivars for writing the unmarshal method
        
        pw.println("    } // end try \n   catch(Exception e)");
        pw.println("    { \n      System.out.println(e); \n    }");
        
        pw.println(" } // end of unmarshal method \n");
        
    }



    private void writeMarshalMethodWithByteBuffer(PrintWriter pw, GeneratedClass aClass)
    {
        List ivars = aClass.getClassAttributes();
        
        pw.println();
        pw.println("/**");
        pw.println(" * Packs a Pdu into the ByteBuffer.");
        pw.println(" * @throws java.nio.BufferOverflowException if buff is too small");
        pw.println(" * @throws java.nio.ReadOnlyBufferException if buff is read only");
        pw.println(" * @see java.nio.ByteBuffer");
        pw.println(" * @param buff The ByteBuffer at the position to begin writing");
        pw.println(" * @since ??");
        pw.println(" */");
        pw.println("public void marshal(java.nio.ByteBuffer buff)");
        pw.println("{");

        // If we're a sublcass of another class, we should first call super
        // to make sure the superclass's ivars are marshaled out.

        String superclassName = aClass.getParentClass();
        if(!(superclassName.equalsIgnoreCase("root")))
        {
            pw.println("       super.marshal(buff);");
        }


        //pw.println("    try \n    {");

        // Loop through the class attributes, generating the output for each.

        ivars = aClass.getClassAttributes();
        for(int idx = 0; idx < ivars.size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)ivars.get(idx);

            // Write out a method call to serialize a primitive type
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                String capped = this.initialCap(marshalType);
                if( capped.equals("Byte") ){
                    capped = "";    // ByteBuffer just has put() for bytesf
                }

                // If we're a normal primitivetype, marshal out directly; otherwise, marshall out
                // the list length.
                if(anAttribute.getIsDynamicListLengthField() == false)
                {
                     //pw.println("       dos.write" + capped + "( (" + marshalType + ")" + anAttribute.getName() + ");");
                     pw.println("       buff.put" + capped + "( (" + marshalType + ")" + anAttribute.getName() + ");");
                }
               else
               {
                   ClassAttribute listAttribute = anAttribute.getDynamicListClassAttribute();
                   //pw.println("       dos.write" + capped + "( (" + marshalType + ")" + listAttribute.getName() + ".size());");
                   pw.println("       buff.put" + capped + "( (" + marshalType + ")" + listAttribute.getName() + ".size());");
               }

            }

            // Write out a method call to serialize a class.
            if( anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF )
            {
                String marshalType = anAttribute.getType();

                //pw.println("       " + anAttribute.getName() + ".marshal(dos);" );
                pw.println("       " + anAttribute.getName() + ".marshal(buff);" );
            }

            // Write out the method call to marshal a fixed length list, aka an array.
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST) )
            {
                pw.println();
                pw.println("       for(int idx = 0; idx < " + anAttribute.getName() + ".length; idx++)");
                pw.println("       {");

                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.

                String marshalType = marshalTypes.getProperty(anAttribute.getType());

                if(anAttribute.getUnderlyingTypeIsPrimitive())
                {
                    String capped = this.initialCap(marshalType);
                    if( capped.equals("Byte") ){
                        capped = "";    // ByteBuffer just has put() for bytesf
                    }
                    //pw.println("           dos.write" + capped + "(" + anAttribute.getName() + "[idx]);");
                    pw.println("           buff.put" + capped + "(" + anAttribute.getName() + "[idx]);");
                }
                else
                {
                     //pw.println("           " + anAttribute.getName() + "[idx].marshal(dos);" );
                     pw.println("           " + anAttribute.getName() + "[idx].marshal(buff);" );
                }

                pw.println("       } // end of array marshaling");
                pw.println();
            }

            // Write out a section of code to marshal a variable length list. The code should look like
            //
            // for(int idx = 0; idx < attrName.size(); idx++)
            // { anAttribute.marshal(dos);
            // }
            //

            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) )
            {
                pw.println();
                pw.println("       for(int idx = 0; idx < " + anAttribute.getName() + ".size(); idx++)");
                pw.println("       {");

                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.

                String marshalType = marshalTypes.getProperty(anAttribute.getType());

                if(anAttribute.getUnderlyingTypeIsPrimitive())
                {
                    String capped = this.initialCap(marshalType);
                    if( capped.equals("Byte") ){
                        capped = "";    // ByteBuffer just uses put() for bytes
                    }
                    //pw.println("           dos.write" + capped + "(" + anAttribute.getName() + ");");
                    pw.println("           buff.put" + capped + "(" + anAttribute.getName() + ");");
                }
                else
                {
                    //pw.println("            " + anAttribute.getType() + " a" + initialCap(anAttribute.getType() + " = (" + anAttribute.getType() + ")" +
                    //                                                                 anAttribute.getName() + ".get(idx);"));
                    //pw.println("            a" + initialCap(anAttribute.getType()) + ".marshal(dos);" );
                    pw.println("            " + anAttribute.getType() + " a" + initialCap(anAttribute.getType() + " = (" + anAttribute.getType() + ")" +
                                                                                     anAttribute.getName() + ".get(idx);"));
                    pw.println("            a" + initialCap(anAttribute.getType()) + ".marshal(buff);" );
                }

                pw.println("       } // end of list marshalling");
                pw.println();
            }
        } // End of loop through the ivars for a marshal method

        //pw.println("    } // end try \n    catch(Exception e)");
        //pw.println("    { \n      System.out.println(e);}");

        pw.println("    } // end of marshal method");
    }

    private void writeUnmarshallMethodWithByteBuffer(PrintWriter pw, GeneratedClass aClass)
    {
        List ivars = aClass.getClassAttributes();
        String superclassName;

        pw.println();
        pw.println("/**");
        pw.println(" * Unpacks a Pdu from the underlying data.");
        pw.println(" * @throws java.nio.BufferUnderflowException if buff is too small");
        pw.println(" * @see java.nio.ByteBuffer");
        pw.println(" * @param buff The ByteBuffer at the position to begin reading");
        pw.println(" * @since ??");
        pw.println(" */");
        pw.println("public void unmarshal(java.nio.ByteBuffer buff)");
        pw.println("{");

        superclassName = aClass.getParentClass();
        if(!(superclassName.equalsIgnoreCase("root")))
        {
            pw.println("       super.unmarshal(buff);\n");
        }


        //pw.println("    try \n    {");

        // Loop through the class attributes, generating the output for each.

        ivars = aClass.getClassAttributes();
        for(int idx = 0; idx < ivars.size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)ivars.get(idx);

            // Write out a method call to deserialize a primitive type
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                String marshalType = unmarshalTypes.getProperty(anAttribute.getType());
                String capped = this.initialCap(marshalType);
                if( capped.equals("Byte") ){
                    capped = "";
                }
                if(marshalType.equalsIgnoreCase("UnsignedByte")){
                    //pw.println("       " + anAttribute.getName() + " = (short)dis.read" + capped + "();");
                    pw.println("       " + anAttribute.getName() + " = (short)(buff.get() & 0xFF);");
                }
                else if (marshalType.equalsIgnoreCase("UnsignedShort")){
                    //pw.println("       " + anAttribute.getName() + " = (int)dis.read" + capped + "();");
                    pw.println("       " + anAttribute.getName() + " = (int)(buff.getShort() & 0xFFFF);");
                }
                else{
                    //pw.println("       " + anAttribute.getName() + " = dis.read" + capped + "();");
                    pw.println("       " + anAttribute.getName() + " = buff.get" + capped + "();");
                }

            }

            // Write out a method call to deserialize a class.
            if( anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                String marshalType = anAttribute.getType();

                //pw.println("       " + anAttribute.getName() + ".unmarshal(dis);" );
                pw.println("       " + anAttribute.getName() + ".unmarshal(buff);" );
            }

            // Write out the method call to unmarshal a fixed length list, aka an array.
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST) )
            {
                pw.println("       for(int idx = 0; idx < " + anAttribute.getName() + ".length; idx++)");
                pw.println("       {");

                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.

                String marshalType = marshalTypes.getProperty(anAttribute.getType());

                if(marshalType == null) // It's a class
                {
                    //pw.println("           " + anAttribute.getName() + "[idx].unmarshal(dis);" );
                    pw.println("           " + anAttribute.getName() + "[idx].unmarshal(buff);" );
                }
                else // It's a primitive
                {
                    String capped = this.initialCap(marshalType);
                    if( capped.equals("Byte") ){
                        capped = "";
                    }
                    pw.println("                " +  anAttribute.getName() + "[idx] = buff.get" + capped + "();");
                }

                pw.println("       } // end of array unmarshaling");
            } // end of array unmarshalling

            // Unmarshall a variable length array.

            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) )
            {
                pw.println("       for(int idx = 0; idx < " + anAttribute.getCountFieldName() + "; idx++)");
                pw.println("       {");

                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.

                String marshalType = marshalTypes.getProperty(anAttribute.getType());

                if(marshalType == null) // It's a class
                {
                    pw.println("            " + anAttribute.getType() + " anX = new " + anAttribute.getType() + "();");
                    //pw.println("            anX.unmarshal(dis);");
                    pw.println("            anX.unmarshal(buff);");
                    pw.println("            " + anAttribute.getName() + ".add(anX);");
                }
                else // It's a primitive
                {
                    String capped = this.initialCap(marshalType);
                    if( capped.equals("Byte") ){
                        capped = "";
                    }
                    //pw.println("           dis.read" + capped + "(" + anAttribute.getName() + ");");
                    pw.println("           buff.get" + capped + "(" + anAttribute.getName() + ");");
                }
                pw.println("       }");
                pw.println();
            } // end of unmarshalling a variable list

        } // End of loop through ivars for writing the unmarshal method

        //pw.println("    } // end try \n   catch(Exception e)");
        //pw.println("    { \n      System.out.println(e); \n    }");

        pw.println(" } // end of unmarshal method \n");

    }



    /**
     * Placed in the {@link Pdu} class, this method provides a convenient,
     * though inefficient way to marshal a Pdu. Better is to reuse a
     * ByteBuffer and pass it along to the similarly-named method, but
     * still, there's something to be said for convenience.
     *
     * <pre>public byte[] marshal(){
     *     byte[] data = new byte[getMarshalledSize()];
     *     java.nio.ByteBuffer buff = java.nio.ByteBuffer.wrap(data);
     *     marshal(buff);
     *     return data;
     * }</pre>
     *
     * @param pw
     * @param aClass
     */
    private void writeMarshalMethodToByteArray(PrintWriter pw, GeneratedClass aClass)
    {
        pw.println();
        pw.println("/**");
        pw.println(" * A convenience method for marshalling to a byte array.");
        pw.println(" * This is not as efficient as reusing a ByteBuffer, but it <em>is</em> easy.");
        pw.println(" * @return a byte array with the marshalled {@link Pdu}");
        pw.println(" * @since ??");
        pw.println(" */");
        pw.println("public byte[] marshal()");
        pw.println("{");
        pw.println("    byte[] data = new byte[getMarshalledSize()];");
        pw.println("    java.nio.ByteBuffer buff = java.nio.ByteBuffer.wrap(data);");
        pw.println("    marshal(buff);");
        pw.println("    return data;");
        pw.println("}");

    }
    
  
    
    /**
     * Generate a constructor that takes a jaxb-equivalent object and returns an open-dis object
     */
    
    public void writeJaxbObjectConstructor(PrintWriter pw, GeneratedClass aClass)
    {
        
        // Write method head
        pw.println();
        pw.println("/** ");
        pw.println(" * Constructor--takes a parallel jaxb object and returns an open-dis object ");
        pw.println(" * 1.4_sed_bait_start */");
        pw.println(" public " + aClass.getName() + "(edu.nps.moves.jaxb.dis." + aClass.getName() + " x)");
        pw.println(" {");
        
        // Write superclass constructor call, if any
        String superclassName = aClass.getParentClass();
        if(!(superclassName.equalsIgnoreCase("root")))
        {
            pw.println("     super(x); // Call superclass constructor");
            pw.println();
        }
           
        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
            
            // A primitive type; just copy it with setter method
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                String attributeName = anAttribute.getName();
                String capped = this.initialCap(anAttribute.getName());
                
                // Copy over  the primitive value
                pw.println("     this." + anAttribute.getName() + " = x.get" + capped + "();");
            } // End primitive attribute type
            
            // A class reference--create a new class instance. This can be tricky, since very often jaxb will have null objects
            // for internal structures that have default XML representations. IN that case the x.getFoo() method will return
            // null. To prevent this, we check to see if the value is null, and if so create an object for it.
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                pw.println();
                pw.println("     edu.nps.moves.dis." + anAttribute.getType() + " foo_" + idx + ";");
                pw.println("     if(x.get" + this.initialCap(anAttribute.getName()) + "() == null)");
                pw.println("        foo_" + idx + " = new edu.nps.moves.dis." + anAttribute.getType() +"();");
                pw.println("      else");
                pw.println("        foo_" + idx + " = new edu.nps.moves.dis." + anAttribute.getType() + "(x.get" +  this.initialCap(anAttribute.getName()) + "() );");
                
                pw.println("     this.set" + this.initialCap(anAttribute.getName()) +"(foo_" + idx + ");");
               // pw.println("     System.out.println(this.get" + this.initialCap(anAttribute.getName()) + "());");
                pw.println();
            }
            
            // A fixed length type--copy it to a new array
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            {
                String attributeType = anAttribute.getType();
                int listLength = anAttribute.getListLength();
                String listLengthString = (new Integer(listLength)).toString();
 
                pw.println("     this." + anAttribute.getName() + " = new " + 
                               attributeType + "[" + listLengthString + "];");
                
                pw.println("     for(int idx = 0; idx < " + listLengthString + "; idx++)");
                pw.println("     {");
                pw.println("         " + anAttribute.getType() + "[] y = x.get" + this.initialCap(anAttribute.getName()) + "();");
                pw.println("         this." + anAttribute.getName() + "[idx] = y[idx];");
                pw.println("     }");
            }
            
            // If a variable length list--copy the elements of the list
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) )
            {
                String attributeType = anAttribute.getType();
                pw.println("     this." + anAttribute.getName() + " = new ArrayList();");
                pw.println("     for(int idx = 0; idx < x.get" + this.initialCap(anAttribute.getName()) +"().size(); idx++)");
                pw.println("     {");
                pw.println("        this." + anAttribute.getName() + ".add( new edu.nps.moves.dis." + anAttribute.getType() + "((edu.nps.moves.jaxb.dis." + anAttribute.getType() + ") x.get" + this.initialCap(anAttribute.getName()) + "().get(idx)));");
                pw.println("     }");
            }
            
        }
                
        pw.println(" }");
        pw.println("/* 1.4_sed_bait_end */");

        pw.println();
    }
    
    /**
     * Writes a method that returns a jaxb object from the open-dis object
     */
    public void writeJaxbObjectGetter(PrintWriter pw, GeneratedClass aClass)
    {
        
        // Write method head
        pw.println();
        pw.println("/**");
        pw.println(" * returns a jaxb object intialized from this object, given an empty jaxb object");
        pw.println(" * 1.4_sed_bait_start **/");
        pw.println(" public edu.nps.moves.jaxb.dis." + aClass.getName() + " initializeJaxbObject(edu.nps.moves.jaxb.dis." + aClass.getName() + " x)");

        pw.println(" {");
        
        // Write superclass call, if any
        String superclassName = aClass.getParentClass();
        if(!(superclassName.equalsIgnoreCase("root")))
        {
            pw.println("     super.initializeJaxbObject(x); // Call superclass initializer");
            pw.println();
        }
        
        
        // Factory object
       // pw.println("     System.out.println(\"In iniializeJaxbObject for object " + aClass.getName() + "\");");
        pw.println("     ObjectFactory factory = new ObjectFactory();");
        pw.println();
       
               
        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
            
            // A primitive type; just copy it with setter method
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                String attributeName = anAttribute.getName();
                String capped = this.initialCap(anAttribute.getName());
                
                // Copy over  the primitive value
                pw.println("     x.set" + capped +"( this.get" + capped + "() );");
            } // End primitive attribute type
            
            // A class reference--create a new class instance
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                pw.println("     x.set" + this.initialCap(anAttribute.getName()) + 
                               "( this.get" + this.initialCap(anAttribute.getName() + "().initializeJaxbObject(factory.create" + this.initialCap(anAttribute.getType() + "()) );")));   
                //pw.println("System.out.println( x.get" + this.initialCap(anAttribute.getName()) + "() );");
            }
            
            // A fixed length type--copy it to a new array
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            {
                String attributeType = anAttribute.getType();
                int listLength = anAttribute.getListLength();
                String listLengthString = (new Integer(listLength)).toString();
                
                pw.println("     x.set" + this.initialCap(anAttribute.getName()) + "( new " + 
                           attributeType + "[" + listLengthString + "]);");
                
                pw.println("     for(int idx = 0; idx < " + listLengthString + "; idx++)");
                pw.println("     {");
               // pw.println("         " + anAttribute.getType() + "[] y = x.get" + this.initialCap(anAttribute.getName()) + "();");
                pw.println("         x.get" + this.initialCap(anAttribute.getName()) + "()[idx] = this." + anAttribute.getName() + "[idx];");
                pw.println("     }");
            }
            
            // If a variable length list--copy the elements of the list
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) )
            {
                String attributeType = anAttribute.getType();
                pw.println();
                pw.println("     List " + anAttribute.getName() + "_1 = x.get" + this.initialCap(anAttribute.getName()) + "();");
                pw.println("     for(int idx = 0; idx < " + anAttribute.getName() +".size(); idx++)");
                pw.println("     {");
                pw.println("         " + anAttribute.getType() + " a = (edu.nps.moves.dis." + anAttribute.getType() + ")" + anAttribute.getName() + ".get(idx);");
                pw.println("         " + anAttribute.getName() + "_1.add(a.initializeJaxbObject(factory.create" + anAttribute.getType() + "()));");
                pw.println("     }");
            }
            
        }
        
        pw.println("   return x;");
        pw.println(" }");
        pw.println("/* 1.4_sed_bait_end */");
        
        pw.println();
    }
        
    
    /**
     * Generate method to write out data in XML format.
     */
/*
    private void writeXmlMarshallMethod(PrintWriter pw, GeneratedClass aClass)
    {
        pw.println();
        pw.println("public void marshalXml(PrintWriter textWriter)");
        pw.println("{");
         
        // If we're a sublcass of another class, we should first call super
        // to make sure the superclass's ivars are marshaled out. after we
        // marshall all of our stuff out, we need to call the superclass again
        // to get the close tag.
        
        String superclassName = aClass.getParentClass();
        if(!(superclassName.equalsIgnoreCase("root")))
        {
            pw.println("    super.marshalXml(textWriter);");
            pw.println();
        }
        
       
        pw.println("    try \n    {");
        
        // Loop through the class attributes, generating the output for each.
        
        List ivars = aClass.getClassAttributes();
        
        // write the tag for this class, eg <header
        System.out.println("        textWriter.print(\"<" + aClass.getName());
        
        // First, we need to write out all the primitive values in this class as attributes. We
        // have to loop through all the attributes, selecting only the primitive types. If we
        // want to be official, we should short the names alphabetically as well to conform
        // to canonical XML.
        for(int idx = 0; idx < ivars.size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)ivars.get(idx);
        
            // Write out a method call to serialize a primitive type
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                // If we're a normal primitive type, marshal out directly; otherwise, marshall out
                // the list length.
                if(anAttribute.getIsDynamicListLengthField() == false)
                {
                     pw.print( "      textWriter.print(" "" + anAttribute.getName() + "" + "="" " + "this.get" + this.initialCap(anAttribute.getName()) + "();");
                }
               else
               {
                   ClassAttribute listAttribute = anAttribute.getDynamicListClassAttribute();
                   //pw.println("       dos.write" + capped + "( (" + marshalType + ")" + listAttribute.getName() + ".size());");
               }
                
            }
        } // End of loop through primitive types
 */      
        /*
            // Write out a method call to serialize a class.
            if( anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF )
            {
                String marshalType = anAttribute.getType();
            
                pw.println("       " + anAttribute.getName() + ".marshal(dos);" );
            }
            
            // Write out the method call to marshal a fixed length list, aka an array.
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST) )
            {
                pw.println();
                pw.println("       for(int idx = 0; idx < " + anAttribute.getName() + ".length; idx++)");
                pw.println("       {");
                
                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.
                
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                
                if(anAttribute.getUnderlyingTypeIsPrimitive())
                {
                    String capped = this.initialCap(marshalType);
                    pw.println("           dos.write" + capped + "(" + anAttribute.getName() + "[idx]);");
                }
                else
                {
                     pw.println("           " + anAttribute.getName() + "[idx].marshal(dos);" );
                }
            
                pw.println("       } // end of array marshaling");
                pw.println();
            }
            
            // Write out a section of code to marshal a variable length list. The code should look like
            //
            // for(int idx = 0; idx < attrName.size(); idx++)
            // { anAttribute.marshal(dos);
            // }
            //    
            
            if( (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) )
            {
                pw.println();
                pw.println("       for(int idx = 0; idx < " + anAttribute.getName() + ".size(); idx++)");
                pw.println("       {");
                
                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.
                
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                
                if(anAttribute.getUnderlyingTypeIsPrimitive())
                {
                    String capped = this.initialCap(marshalType);
                    pw.println("           dos.write" + capped + "(" + anAttribute.getName() + ");");
                }
                else
                {
                    pw.println("            " + anAttribute.getType() + " a" + initialCap(anAttribute.getType() + " = (" + anAttribute.getType() + ")" +
                                                                                     anAttribute.getName() + ".get(idx);"));
                    pw.println("            a" + initialCap(anAttribute.getType()) + ".marshal(dos);" );
                }
                
                pw.println("       } // end of list marshalling");
                pw.println();
            }   
        } // End of loop through the ivars for a marshal method
        */
       /* 
        pw.println("    } // end try \n    catch(Exception e)");
        pw.println("    { \n      System.out.println(e);}");
        
        pw.println("    } // end of marshalXml method");
        
        
    }
   */
 
    /**
     * Write the code for an equality operator. This allows you to compare
     * two objects for equality.
     * The code should look like
     * 
     * bool operator ==(const ClassName& rhs)
     * return (_ivar1==rhs._ivar1 && _var2 == rhs._ivar2 ...)
     *
     */
    public void writeEqualityMethod(PrintWriter pw, GeneratedClass aClass)
    {
        try
    {
        pw.println();
        pw.println(" /**");
        pw.println("  * The equals method doesn't always work--mostly it works only on classes that consist only of primitives. Be careful.");
        pw.println("  */");
        pw.println(" public boolean equals(" + aClass.getName() + " rhs)");
        pw.println(" {");
        pw.println("     boolean ivarsEqual = true;");
        pw.println();
        
        pw.println("    if(rhs.getClass() != this.getClass())");
        pw.println("        return false;");
        pw.println();
            
        //pw.println("      ivarsEqual = this.super().equals(rhs.super());");
        //pw.println("      if(ivarsEqual == false)");
        // pw.println("           return false;");
        //pw.println();
        
        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                pw.println("     if( ! ("  + anAttribute.getName() + " == rhs." + anAttribute.getName() + ")) ivarsEqual = false;");
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                pw.println("     if( ! ("  + anAttribute.getName() + ".equals( rhs." + anAttribute.getName() + ") )) ivarsEqual = false;");
            }
            
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            {
                pw.println();
                pw.println("     for(int idx = 0; idx < " + anAttribute.getListLength() + "; idx++)");
                pw.println("     {");
                pw.println("          if(!(" + anAttribute.getName() + "[idx] == rhs." + anAttribute.getName() + "[idx])) ivarsEqual = false;");
                pw.println("     }");
                pw.println();
            }
            
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
            {
                pw.println();
                pw.println("     for(int idx = 0; idx < " + anAttribute.getName() + ".size(); idx++)");
                pw.println("     {");
                //pw.println("        " + anAttribute.getType() + " x = (" + anAttribute.getType() + ")" +  anAttribute.getName() + ".get(idx);");
                pw.println("        if( ! ( " + anAttribute.getName() + ".get(idx).equals(rhs." + anAttribute.getName() + ".get(idx)))) ivarsEqual = false;");
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
 * This should be needed only for the XmlRoot class(es). 
 * @param pw
 * @param aClass
 * @param allClasses
 */
private void writeXmlRootMarshallMethod(PrintWriter pw, 
                                        GeneratedClass aClass)
{
   pw.println("/**");
   pw.println("* JAXB marshalls (by default) only classes that are marked with @XmlRootElement.");
   pw.println("* This is a convienience method for marshalling the top level root element. ");
   pw.println("* Note that this requires the presence of jaxb.index in the package directory.");
   pw.println("*/");
   pw.println("public void marshallToXml(String filename)");
   pw.println("{");
   pw.println("  try\n   {");
   pw.println("       JAXBContext context = JAXBContext.newInstance();");
   pw.println("      Marshaller marshaller = context.createMarshaller();");
   pw.println("      marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);");
   pw.println("      marshaller.marshal(this, new FileOutputStream(filename));"); 
   pw.println("    } // End try");
   pw.println("    catch(Exception e) {System.out.println(e);\n};");
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
}
