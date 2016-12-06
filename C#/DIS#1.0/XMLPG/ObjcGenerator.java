package edu.nps.moves.xmlpg;

import java.io.*;
import java.util.*;

/*
 * Generates the Objective-C 2.0 language source code files needed to read and write a protocol described
 * by an XML file. This is a counterpart to the JavaGenerator. This should generate .h and
 * .m files with ivars, properties, etc. This is very closely tied to the Apple implementation
 * of Objc, and should work on OSX and the iPhone.<p>
 *
 * The Objective-C 2.0 language is specified at http://developer.apple.com
 *
 * @author DMcG
 */

public class ObjcGenerator extends Generator
{
    /**
     * ivars are often preceded by a special character. This sets what that character is,
     * so that instance variable names will be preceded by a "_".
     */
    public static final String IVAR_PREFIX ="";

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
    Properties objcProperties;

    public ObjcGenerator(HashMap pClassDescriptions, String pDirectory, Properties pObjcProperties)
    {
        super(pClassDescriptions, pDirectory, pObjcProperties);

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

        marshalTypes.setProperty("unsigned short", "unsignedShort");
        marshalTypes.setProperty("unsigned byte", "unsignedByte");
        marshalTypes.setProperty("unsigned int", "unsignedInt");
		marshalTypes.setProperty("unsigned long", "long");

        marshalTypes.setProperty("byte", "byte");
        marshalTypes.setProperty("short", "short");
        marshalTypes.setProperty("int", "int");
        marshalTypes.setProperty("long", "long");

        marshalTypes.setProperty("double", "double");
        marshalTypes.setProperty("float", "float");

        // How big various primitive types are. This may be wrong for 64 bit hosts
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
        
        Iterator it = classDescriptions.values().iterator();

        // Loop through all the class descriptions, generating a header file and cpp file for each.
        while(it.hasNext())
        {
            try
           {
              GeneratedClass aClass = (GeneratedClass)it.next();
			  // System.out.println("Generating class " + aClass.getName());
              this.writeHeaderFile(aClass);
              this.writeObjcFile(aClass);
           }
           catch(Exception e)
           {
                System.out.println("error creating source code " + e);
           }

        } // End while

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

        // Write includes for any classes we may reference. this generates multiple #includes if we
        // use a class multiple times, but that's innocuous. We could sort and do a unqiue to prevent
        // this if so inclined.

        boolean hasVariableLengthList = false;

        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);

            // If this attribute is a class, we need to do an import on that class
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                pw.println("#import \"" + anAttribute.getType() + ".h\"");
            }

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
            {
                hasVariableLengthList = true;
                pw.println("#import \"" + anAttribute.getType() + ".h\"");
            }
        }

        pw.println("#import <Foundation/Foundation.h>");
        

        // if we inherit from another class we need to do an include on it
        if(!(aClass.getParentClass().equalsIgnoreCase("root")))
        {
             pw.println("#import \"" + aClass.getParentClass() + ".h\"");
        }

         pw.println("#import \"DataInput.h\"");
         pw.println("#import \"DataOutput.h\"");

        pw.println();
        pw.println();

        // Print out the class comments, if any
        if(aClass.getClassComments() != null)
        {
            pw.println("// " + aClass.getClassComments() );
            pw.println();
            pw.println("// Copyright (c) 2007-2009, MOVES Institute, Naval Postgraduate School. All rights reserved. ");
            pw.println("//");
            pw.println("// @author DMcG");
            pw.println();
        }

         // Print out class header and ivars

        if(aClass.getParentClass().equalsIgnoreCase("root"))
            pw.println("@interface  " + aClass.getName() + ": NSObject");
        else
            pw.println("@interface " + aClass.getName() + " : " + aClass.getParentClass());

        pw.println("{");

        // Print out ivars. 

        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                if(anAttribute.getComment() != null)
                    pw.println("  " + "/** " + anAttribute.getComment() + " */");

                pw.println("  " + types.get(anAttribute.getType()) + " " + anAttribute.getName() + "; ");
                pw.println();

            }

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                if(anAttribute.getComment() != null)
                    pw.println("  " + "/** " + anAttribute.getComment() + " */");

                 pw.println("  " + anAttribute.getType() + " " + "*" + anAttribute.getName() + "; ");
                 pw.println();
            }

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            {
                if(anAttribute.getComment() != null)
                    pw.println("  " + "/** " + anAttribute.getComment() + " */");

                pw.println("  " + types.get(anAttribute.getType()) + " " + anAttribute.getName() + "[" + anAttribute.getListLength() + "]; ");
                pw.println("  // Length of the above array");
                pw.println("  int " + anAttribute.getName() + "Length;");
                pw.println("  // Ptr to the array (fixes a syntax types problem with properties)");
                pw.println("   " + types.get(anAttribute.getType()) + " * " + anAttribute.getName() + "Ptr; ");
                pw.println();
            }

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
            {
                if(anAttribute.getComment() != null)
                    pw.println("  " + "/** " + anAttribute.getComment() + " */");

                pw.println("  NSMutableArray *" + anAttribute.getName() + "; ");
                pw.println();
            }
        } // end ivars

        pw.println("}");
        pw.println();

        // Do properties
         for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
         {
             // @property(readwrite, assign) unsigned char protocolVersion;
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
               pw.println("@property(readwrite, assign) " + types.get(anAttribute.getType()) + " "  + anAttribute.getName() + "; ");
            }

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
               pw.println("@property(readwrite, retain) " + anAttribute.getType() + "* "  + anAttribute.getName() + "; ");
            }

            if((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST))
            {
                pw.println("@property(readwrite) " + types.get(anAttribute.getType()) + "* " + anAttribute.getName() + "Ptr;");
                pw.println("@property(readonly) int " + anAttribute.getName() + "Length;");
            }

            if((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) )
            {
               pw.println("@property(readwrite, retain) " + "NSMutableArray*" + anAttribute.getName() + "; ");
            }

         } // end of properties      

        pw.println();

        pw.println("-(id)init; // Initializer");
        pw.println("-(void)dealloc;");

        // Marshal and unmarshal methods
        pw.println("-(void)marshalUsingStream:(DataOutput*) dataStream;");
        pw.println("-(void)unmarshalUsingStream:(DataInput*) dataStream;");

        // Generate a getMarshalledSize() method header
        pw.println();
        pw.println("-(int)getMarshalledSize;");
        pw.println();
        pw.println("@end");
        pw.println();
        
        this.writeLicenseNotice(pw);

        pw.flush();
        pw.close();
    } // End of try
    catch(Exception e)
    {
        System.out.println(e);
    }

} // End write header file

public void writeObjcFile(GeneratedClass aClass)
{
    try
   {
        String name = aClass.getName();
        System.out.println("Creating Objc .m and .h source code files for " + name);
        String headerFullPath = directory + "/" + name + ".m";
        File outputFile = new File(headerFullPath);
        outputFile.createNewFile();
        PrintWriter pw = new PrintWriter(outputFile);

        pw.println("#import \"" + aClass.getName() + ".h\" ");
        pw.println();

        pw.println();

        pw.println("@implementation " + aClass.getName());

        pw.println();
        // Write the synthesize decl for the properties
        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);
            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            {
                pw.println("@synthesize " + anAttribute.getName() + "Ptr;");
                pw.println("@synthesize " + anAttribute.getName() + "Length;");
            }
            else
            {
                pw.println("@synthesize " + anAttribute.getName() + ";");
            }
        }
        pw.println();

        // Write fixed array access methods. Irritatingly, it doesn't seem to be
        // possible to do this via properties.

        // Write initalizer
        this.writeInitializer(pw, aClass);
        this.writeDeallocMethod(pw, aClass);

       

        // Write marshal and unmarshal methods
        this.writeMarshalMethod(pw, aClass);
        this.writeUnmarshalMethod(pw, aClass);

        // Write a comparision operator
        //this.writeEqualityOperator(pw, aClass);

        // Method to determine the marshalled length of the PDU
        this.writeGetMarshalledSizeMethod(pw, aClass);
        pw.println("@end\n");
        pw.println("\n");

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
                    pw.println("     if( ! ("  + anAttribute.getName() + " == rhs." + anAttribute.getName() + ") ) ivarsEqual = false;");
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
                pw.println("          if(!("  + anAttribute.getName() + "[idx] == rhs." + anAttribute.getName() + "[idx]) ) ivarsEqual = false;");
                pw.println("     }");
                pw.println();
            }

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
            {
                pw.println();
                pw.println("     for(int idx = 0; idx < "  + anAttribute.getName() + ".size(); idx++)");
                pw.println("     {");
               // pw.println("        " + aClass.getName() + " x = " + IVAR_PREFIX + anAttribute.getName() + "[idx];");
                pw.println("        if( ! ( " + anAttribute.getName() + "[idx] == rhs."  + anAttribute.getName() + "[idx]) ) ivarsEqual = false;");
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
        pw.println("-(void) " + "marshalUsingStream:(DataOutput*) dataStream");
        pw.println("{");

        // If this inherits from one of our classes, we should call the superclasses'
        // marshal method first. The syntax for this is SuperclassName::marshal(dataStream).

        // If it's not already a root class
        if(!(aClass.getParentClass().equalsIgnoreCase("root")))
        {
            String superclassName = aClass.getParentClass();
            pw.println("    [super marshalUsingStream:dataStream]; // Marshal information in superclass first");
        }


        for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
        {
            ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);

            // Write out the code to marshal this, depending on the type of attribute

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            {
                if(anAttribute.getIsDynamicListLengthField() == false)
                {
                     String marshalType = marshalTypes.getProperty(anAttribute.getType());
                     String capped = this.initialCap(marshalType);
                     pw.println("    [dataStream write" + capped + ":" + anAttribute.getName() + "];");
                }
                else
                {
                     ClassAttribute listAttribute = anAttribute.getDynamicListClassAttribute();
                     String marshalType = marshalTypes.getProperty(anAttribute.getType());
                     String capped = this.initialCap(marshalType);
                     //pw.println("    dataStream << ( " + types.get(anAttribute.getType()) + " )"  + listAttribute.getName() + ".size();");
                     pw.println("    [dataStream write" + capped + ":[" + listAttribute.getName() + " count]];");
                }

            }

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
            {
                pw.println("    ["  + anAttribute.getName() + " marshalUsingStream:dataStream];");
            }

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
            {
                pw.println();
                pw.println("     for(int idx = 0; idx < " + anAttribute.getListLength() + "; idx++)");
                pw.println("     {");

                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.

                String marshalType = marshalTypes.getProperty(anAttribute.getType());

                if(marshalType == null) // It's a class
                {
                    pw.println("     [dataStream " +  anAttribute.getName() + "[idx].marshal(dataStream);");
                }
                else
                {
                    String capped = this.initialCap(marshalType);
                    pw.println("    [dataStream write" + capped + ":" + anAttribute.getName() + "[idx]];");
                }

                pw.println("     }");
                pw.println();
            }

            if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
            {
                pw.println();
                pw.println("     for(int idx = 0; idx < ["  + anAttribute.getName() + " count]; idx++)");
                pw.println("     {");

                String marshalType = marshalTypes.getProperty(anAttribute.getType());

                if(marshalType == null) // It's a class
                {
                    pw.println("        " + anAttribute.getType() + "* x = [" + anAttribute.getName() + " objectAtIndex:idx];");
                    pw.println("        [x marshalUsingStream:dataStream];");
                }
                else // it's a primitive
                {
                    pw.println("        " + anAttribute.getType() + " x = " + anAttribute.getName() + "[idx];");
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
    pw.println("-(void) " + "unmarshalUsingStream:(DataInput*)dataStream;");
    pw.println("{");

    // If it's not already a root class
    if(!(aClass.getParentClass().equalsIgnoreCase("root")))
    {
        String superclassName = aClass.getParentClass();
        pw.println("    [super unmarshalUsingStream:dataStream]; // unmarshal information in superclass first");
    }

    for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
    {
        ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);

        // Write out the code to marshal this, depending on the type of attribute

        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
        {
            String t = marshalTypes.getProperty(anAttribute.getType());
            t = this.initialCap(t);
            pw.println("    " + anAttribute.getName() + " = " + "[dataStream read"  + t + "];");
        }

        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
        {
            pw.println("    [" + anAttribute.getName() + " unmarshalUsingStream:dataStream];");
        }

        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
        {
            String t = marshalTypes.getProperty(anAttribute.getType());
            t = this.initialCap(t);
            pw.println();
            pw.println("     for(int idx = 0; idx < " + anAttribute.getListLength() + "; idx++)");
            pw.println("     {");
            pw.println("          " + anAttribute.getName() + "[idx] = [dataStream read" + t + "];");
            pw.println("     }");
            pw.println();
        }

        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
        {
            pw.println();
            pw.println("     [" + anAttribute.getName() + " removeAllObjects];"); // Clear out any existing objects in the list
            pw.println("     for(int idx = 0; idx < " + anAttribute.getCountFieldName() + "; idx++)");
            pw.println("     {");

            // This is some sleaze. We're an list, but an list of what? We could be either a
            // primitive or a class. We need to figure out which. This is done via the expedient
            // but not very reliable way of trying to do a lookup on the type. If we don't find
            // it in our map of primitives to marshal types, we assume it is a class.

            String marshalType = marshalTypes.getProperty(anAttribute.getType());

            if(marshalType == null) // It's a class
            {
                pw.println("        " + anAttribute.getType() + "* x;");
                pw.println("        [x unmarshalUsingStream:dataStream];" );
                pw.println("        ["  + anAttribute.getName() + " addObject:x];");
            }
            else // It's a primitive; not supported
            {
                // pw.println("       "  + anAttribute.getName() + "[idx] << dataStream");
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
private void writeInitializer(PrintWriter pw, GeneratedClass aClass)
{
    pw.println("-(id)init");
    pw.println("{");

    pw.println("  self = [super init];");
    pw.println("  if(self)");
    pw.println("  {");
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

        // Set initial values
        List usedValues = new ArrayList();

        List inits = aClass.getInitialValues();
        for(int idx = 0; idx < inits.size(); idx++)
        {
            InitialValue anInitialValue = (InitialValue)inits.get(idx);
            String setterName = anInitialValue.getSetterMethodName();
            pw.println("    [self " + setterName + ":" + anInitialValue.getVariableValue() + "];");
            usedValues.add(anInitialValue.getVariable());
        }

       for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
       {
          ClassAttribute attribute = (ClassAttribute)aClass.getClassAttributes().get(idx);

          // Every primitive that doesn't have an initial value gets set to zero
          if(attribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
          {
              if(!usedValues.contains(attribute.getName()))
              {
                 pw.println("    " + attribute.getName() + " = 0;");
              }
          }
          // We need to initialize class instances

          if(attribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
          {
              pw.println("    " + attribute.getName() + " = [[" + attribute.getType() + " alloc] init];");
          }
          if(attribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
          {
              pw.println("     // Initialize fixed length array");
              int arrayLength = attribute.getListLength();
              String indexName = "length" + attribute.getName();
              pw.println("     int " + indexName + ";");
              pw.println("     for(" + indexName + " = 0; " + indexName + " < " + arrayLength + "; " + indexName + "++)");
              pw.println("     {");
              pw.println("         " + attribute.getName() + "[" + indexName + "] = 0;");
              pw.println("     }");
              pw.println("     " + attribute.getName() + "Ptr = &" + attribute.getName() + "[0];");
              pw.println();
          }
          if(attribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)
          {
              pw.println("    " + attribute.getName() + " = [NSMutableArray arrayWithCapacity:1];");
          }
          
       }
       pw.println("  } // end if(self)");

       pw.println("  return self;");

    pw.println("}\n");
}

public void writeGetMarshalledSizeMethod(PrintWriter pw, GeneratedClass aClass)
{
    List ivars = aClass.getClassAttributes();

    // Generate a getMarshalledLength() method header
    pw.println();
    pw.println("-(int)getMarshalledSize");
    pw.println("{");
    pw.println("   int marshalSize = 0;");
    pw.println();

    // Size of superclass is the starting point
    if(!aClass.getParentClass().equalsIgnoreCase("root"))
    {
        pw.println("   marshalSize = [super getMarshalledSize];");
    }

    for(int idx = 0; idx < ivars.size(); idx++)
    {
        ClassAttribute anAttribute = (ClassAttribute)ivars.get(idx);

        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
        {
            pw.print("   marshalSize = marshalSize + ");
            pw.println(primitiveSizes.get(anAttribute.getType()) + ";  // "  + anAttribute.getName());
        }

        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF)
        {
            pw.print("   marshalSize = marshalSize + ");
            pw.println("[" + anAttribute.getName() + " getMarshalledSize];");
        }

        if(anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)
        {
            pw.print("   marshalSize = marshalSize + ");
            // If this is a fixed list of primitives, it's the list size times the size of the primitive.
            if(anAttribute.getUnderlyingTypeIsPrimitive() == true)
            {
                pw.println( anAttribute.getListLength() + " * " + primitiveSizes.get(anAttribute.getType()) + ";  // "  + anAttribute.getName());
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
                pw.println( anAttribute.getName() + ".size() " + " * " + primitiveSizes.get(anAttribute.getType()) + ";  // " + anAttribute.getName());
            }
            else
            {
                pw.println();
                pw.println("   for(int idx=0; idx < ["  + anAttribute.getName() + " count]; idx++)");
                pw.println("   {");
                //pw.println( anAttribute.getName() + ".size() " + " * " +  " new " + anAttribute.getType() + "().getMarshalledSize()"  + ";  // " + anAttribute.getName());
                pw.println("        " + anAttribute.getType() + "* listElement = [" + anAttribute.getName() + " objectAtIndex:idx];");
                pw.println("        marshalSize = marshalSize + [listElement getMarshalledSize];");
                pw.println("    }");
                pw.println();
            }
        }

    }
    pw.println("    return marshalSize;");
    pw.println("}");
    pw.println();
}

public void writeDeallocMethod(PrintWriter pw, GeneratedClass aClass)
{
    pw.println();
    pw.println("-(void)dealloc");
    pw.println("{");
    for(int idx = 0; idx < aClass.getClassAttributes().size(); idx++)
    {
        ClassAttribute anAttribute = (ClassAttribute)aClass.getClassAttributes().get(idx);

        ClassAttribute.ClassAttributeType kind = anAttribute.getAttributeKind();

        if( (kind == anAttribute.attributeKind.CLASSREF) ||
            (kind == anAttribute.attributeKind.VARIABLE_LIST))
        {
             pw.println("  [" + anAttribute.getName() + " release];" );
        }
    }
    pw.println("  [super dealloc];");
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
