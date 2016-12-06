package edu.nps.moves.xmlpg;

import java.io.File;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Properties;
import java.util.StringTokenizer;

/**
 * Given the input object, something of an abstract syntax tree, this generates
 * a source code file in the C# language. It has ivars, getters,  setters,
 * and serialization/deserialization methods.
 *
 * @author DMcG
 * modified by Peter Smith (Naval Air Warfare Center - Training Systems Division
 */
public class CsharpGenerator extends Generator {

    /** Maps the primitive types listed in the XML file to the C# types */
    Properties types = new Properties();
    /** What primitive types should be marshalled as. This may be different from
     * the C# get/set methods, ie an unsigned short might have ints as the getter/setter,
     * but is marshalled as a short.
     */
    Properties marshalTypes = new Properties();
    /** Similar to above, but used on unmarshalling. There are some special cases (unsigned
     * types) to be handled here.
     */
    Properties unmarshalTypes = new Properties();
    /** sizes of various primitive types */
    Properties primitiveSizes = new Properties();
    /** A property list that contains c#-specific code generation information, such
     * as namespace which correlates to package names, using which correlates to imports, etc.
     */
    Properties csharpProperties;
    //PES 02/10/2009 Added to save all classes linked to Upper Class (PDU)
    //Will be used to allow automatic setting of Length when Marshall method called
    Map<String, String> classesInstantiated = new HashMap<String, String>();

    public CsharpGenerator(HashMap pClassDescriptions, String pDirectory, Properties pCsharpProperties) {
        super(pClassDescriptions, pDirectory, pCsharpProperties);

        //System.out.println("CsharpProperties : ");
        //pCsharpProperties.list(System.out);

        // Set up a mapping between the strings used in the XML file and the strings used
        // in the C# file, specifically the data types. This could be externalized to
        // a properties file, but there's only a dozen or so and an external props file
        // would just add some complexity.
        types.setProperty("unsigned short", "ushort"); //int
        types.setProperty("unsigned byte", "byte"); //short
        types.setProperty("unsigned int", "uint"); //long
        types.setProperty("unsigned long", "ulong"); //unsigned long PES 05/01/2008 added for ulong support

        types.setProperty("byte", "byte");
        types.setProperty("short", "short"); //short
        types.setProperty("int", "uint");
        types.setProperty("long", "long");

        types.setProperty("double", "double");
        types.setProperty("float", "float");

        // Set up the mapping between primitive types and marshal types.

        marshalTypes.setProperty("unsigned short", "ushort"); //short
        marshalTypes.setProperty("unsigned byte", "byte");
        marshalTypes.setProperty("unsigned int", "uint"); //int
        marshalTypes.setProperty("unsigned long", "ulong"); //unsigned long PES 05/01/2008 added for ulong support

        marshalTypes.setProperty("byte", "byte");
        marshalTypes.setProperty("short", "short");
        marshalTypes.setProperty("int", "uint");
        marshalTypes.setProperty("long", "long");

        marshalTypes.setProperty("double", "double");
        marshalTypes.setProperty("float", "float");

        // Unmarshalling types
        unmarshalTypes.setProperty("unsigned short", "ushort");
        unmarshalTypes.setProperty("unsigned byte", "byte");
        unmarshalTypes.setProperty("unsigned int", "uint");
        unmarshalTypes.setProperty("unsigned long", "ulong");

        unmarshalTypes.setProperty("byte", "byte");
        unmarshalTypes.setProperty("short", "short");
        unmarshalTypes.setProperty("int", "uint");
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
    public void writeClasses() {
        this.createDirectory();

        Iterator it = classDescriptions.values().iterator();

        System.out.println("Creating C# source code.");



        //PES 02/10/2009 used to store all classes
        Iterator it2 = classDescriptions.values().iterator();

        while (it2.hasNext()) {
            GeneratedClass aClass = (GeneratedClass) it2.next();
            String name = aClass.getName();

            String parentClass = aClass.getParentClass();

            if (parentClass.equalsIgnoreCase("root")) {
                parentClass = "Object";
            }

            classesInstantiated.put(aClass.getName(), parentClass);
        }

        //END storing all Classes

        while (it.hasNext()) {
            try {
                GeneratedClass aClass = (GeneratedClass) it.next();
                String name = aClass.getName();

                // Create namespace structure, if any
                String namespace = languageProperties.getProperty("namespace");
                String fullPath;

                // If we have a namespace specified, replace the dots in the namespace name
                // with slashes and create that directory
                if (namespace != null) {
                    namespace = namespace.replace(".", "/");
                    fullPath = directory + "/" + name + ".cs";
                    //System.out.println("full path is " + fullPath);
                } else {
                    fullPath = directory + "/" + name + ".cs";
                }
                //System.out.println("Creating Csharp source code file for " + fullPath);

                // Create the new, empty file, and create printwriter object for output to it
                File outputFile = new File(fullPath);
                //outputFile.getParentFile().mkdirs(); //NEW
                outputFile.createNewFile();
                PrintWriter pw = new PrintWriter(outputFile);

                PrintStringBuffer psw = new PrintStringBuffer(); //PES 05/01/2009

                //PES 05/01/2009 modified to print data to a stringbuilder prior to output to a file
                //will use this to post process any changes
                this.writeClass(psw, aClass);

                //See if any post processing is needed
                this.postProcessData(psw, aClass);

                // print the source code of the class to the file
                pw.print(psw.toString());
                pw.flush();
                pw.close();

            } catch (Exception e) {
                System.out.println("error creating source code " + e);
            }

        } // End while

    } // End write classes

    /**
     * Generate a source code file with getters, setters, ivars, and marshal/unmarshal
     * methods for one class.
     */
    public void writeClass(PrintStringBuffer pw, GeneratedClass aClass) {
        // Write the namespace
        //Note inside of the DIS XML1998 or XML1995 file the following needs to be inserted
        //<csharp namespace="DIS1998net" />  DIS1998net can be renamed to whatever the namespace is needed.

        String namespace = languageProperties.getProperty("namespace");

        this.writeLicenseNotice(pw);
        this.writeImports(pw, aClass);
        this.writeClassComments(pw, aClass, 1);
        this.writeClassDeclaration(pw, aClass, 1);
        this.writeIvars(pw, aClass, 2);
        this.writeConstructor(pw, aClass, 2);
        this.writeGetMarshalledSizeMethod(pw, aClass, 2);
        this.writeGettersAndSetters(pw, aClass, 2);
        this.writeMarshalMethod(pw, aClass, 2);
        this.writeUnmarshallMethod(pw, aClass, 2);
        this.writeReflectionMethod(pw, aClass, 2);

        //For C# - do not believe these are necessary as the MemoryStream used in previous MarshalMethod
        //should provide the same type features.
        //this.writeMarshalMethodWithByteBuffer(pw, aClass);
        //this.writeUnmarshallMethodWithByteBuffer(pw, aClass);
        //if (aClass.getName().equals("Pdu"))
        //{
        //    this.writeMarshalMethodToByteArray(pw, aClass);
        //}

        this.writeEqualityMethod(pw, aClass, 2);


        pw.println(1, "} // end of class");
        pw.println("} // end of namespace");
        //pw.flush(); //PES 05/01/2009 moved to within While statement above
        //pw.close();

    }

    /**
     * Writes the namespace and namespace using code at the top of the C# source file
     *
     * @param pw
     * @param aClass
     */
    private void writeImports(PrintStringBuffer pw, GeneratedClass aClass) {

        // Write the various import statements
        String using = languageProperties.getProperty("using");
        StringTokenizer tokenizer = new StringTokenizer(using, ", ");
        while (tokenizer.hasMoreTokens()) {
            String aPackage = (String) tokenizer.nextToken();
            pw.println("using " + aPackage + ";");
        }

        String namespace = languageProperties.getProperty("namespace");

        //if missing create default name
        if (namespace == null) {
            namespace = "DISnet";
        }

        pw.println();
        pw.println("namespace " + namespace + "\n{");
        pw.println();
    }

    /**
     * Write the class comments block
     * @param pw
     * @param aClass
     */
    private void writeClassComments(PrintStringBuffer pw, GeneratedClass aClass, int indent) {
        // Print class comments header
        pw.println(indent, "/**");
        if (aClass.getClassComments() != null) {
            pw.println(indent, " * " + aClass.getClassComments());
            pw.println(indent, " *");
            pw.println(indent, " * Copyright (c) 2008, MOVES Institute, Naval Postgraduate School. All rights reserved.");
            pw.println(indent, " * This work is licensed under the BSD open source license, available at https://www.movesinstitute.org/licenses/bsd.html");
            pw.println(indent, " *");
            pw.println(indent, " * @author DMcG");
            pw.println(indent, " * Modified for use with C#:");
            pw.println(indent, " * Peter Smith (Naval Air Warfare Center - Training Systems Division)");
        }
        pw.println(indent, " */");
    }

    /**
     * Writes the class declaration, including any inheritence and interfaces
     *
     * @param pw
     * @param aClass
     */
    private void writeClassDeclaration(PrintStringBuffer pw, GeneratedClass aClass, int indent) {
        // Class declaration
        String parentClass = aClass.getParentClass();
        if (parentClass.equalsIgnoreCase("root")) {
            parentClass = "Object";
        }


        //Added serializable attribute, additional tags will be needed for non-serializable and
        //if XML serialization will be used
        pw.println(indent, "[Serializable]");
        pw.println(indent, "[XmlRoot]");	//PES added for XML compatiblity

        //Following will find the classes that are referenced within the current class being processed
        //These will then be added to the Xmlinclude attribute to allow the reflection of those classes
        List ivars = aClass.getClassAttributes();
        List referencedClasses = new ArrayList();

        for (int idx = 0; idx < ivars.size(); idx++) {
            ClassAttribute anAttribute = (ClassAttribute) ivars.get(idx);

            String attributeType = types.getProperty(anAttribute.getType());

            //if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE)
            //{

            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF) {
                if (!referencedClasses.contains(anAttribute.getType())) {
                    referencedClasses.add(anAttribute.getType());
                    pw.println(indent, "[XmlInclude(typeof(" + anAttribute.getType() + "))]");
                }

                //pw.println("   protected " + attributeType + "  " + anAttribute.getName() + " = new " + attributeType + "(); \n");
            }
            //}

            if (anAttribute.listIsClass() == true) {
                pw.println(indent, "[XmlInclude(typeof(" + anAttribute.getType() + "))]");
            }
        }

        pw.println(indent, "public partial class " + aClass.getName() + " : " + parentClass); //PES 12-02-2009 added based upon user "Rogier" request


        pw.println(indent, "{");
    }

    private void writeIvars(PrintStringBuffer pw, GeneratedClass aClass, int indent) {
        List ivars = aClass.getClassAttributes();
        for (int idx = 0; idx < ivars.size(); idx++) {
            ClassAttribute anAttribute = (ClassAttribute) ivars.get(idx);

            // This attribute is a primitive.
            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE) {
                // The primitive type--we need to do a lookup from the abstract type in the
                // xml to the C#-specific type. The output should look something like
                //
                // /** This is a comment */
                // protected int foo;
                //
                String attributeType = types.getProperty(anAttribute.getType());
                if (anAttribute.getComment() != null) {
                    pw.println(indent, "/** " + anAttribute.getComment() + " */");
                }

                String defaultValue = anAttribute.getDefaultValue();

                pw.print(indent, "protected " + attributeType + "  _" + anAttribute.getName()); //Create standard type using underscore
                if (defaultValue != null) {
                    pw.print(" = " + defaultValue);
                }
                pw.println(";\n");
            } // end of primitive attribute type

            // this attribute is a reference to another class defined in the XML document, The output should look like
            //
            // /** This is a comment */
            // protected AClass foo = new AClass();
            //
            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF) {
                String attributeType = anAttribute.getType();
                if (anAttribute.getComment() != null) {
                    pw.println(indent, "/** " + anAttribute.getComment() + " */");
                }

                pw.println(indent, "protected " + attributeType + "  _" + anAttribute.getName() + " = new " + attributeType + "(); \n");
            }

            // The attribute is a fixed list, ie an array of some type--maybe primitve, maybe a class.

            if ((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)) {
                String attributeType = anAttribute.getType();
                int listLength = anAttribute.getListLength();
                String listLengthString = (new Integer(listLength)).toString();

                if (anAttribute.getComment() != null) {
                    pw.println(indent, "/** " + anAttribute.getComment() + " */");
                }

                if (anAttribute.getUnderlyingTypeIsPrimitive() == true) {
                    pw.println(indent, "protected " + types.getProperty(attributeType) + "[]  _" + anAttribute.getName() + " = new " +
                            types.getProperty(attributeType) + "[" + listLengthString + "]" + "; \n");
                } else if (anAttribute.listIsClass() == true) {
                    pw.println(indent, "protected " + attributeType + "[]  _" + anAttribute.getName() + " = new " +
                            attributeType + "[" + listLengthString + "]" + "; \n");
                }
            }

            // The attribute is a variable list of some kind.
            if ((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)) {
                String attributeType = anAttribute.getType();
                int listLength = anAttribute.getListLength();
                String listLengthString = (new Integer(listLength)).toString();

                if (anAttribute.getComment() != null) {
                    pw.println(indent, "/** " + anAttribute.getComment() + " */");
                }

                //PES 04/29/2009  Added to speed up unboxing of data
                if (anAttribute.getType().equalsIgnoreCase("OneByteChunk")) {
                    pw.println(indent, "protected byte[] _" + anAttribute.getName() + "; ");
                } else {
                    //Make the list referenced to the type that will be stored within 01/21/2009 PES
                    pw.println(indent, "protected List<" + anAttribute.getType() + "> _" + anAttribute.getName() + " = new List<" + anAttribute.getType() + ">(); ");
                }
            }
        } // End of loop through ivars
    }

    private void writeConstructor(PrintStringBuffer pw, GeneratedClass aClass, int indent) {
        List ivars = aClass.getClassAttributes();

        // Write a constructor
        pw.println();
        pw.println(indent, "/** Constructor */");
        if (aClass.getClassComments() != null) { //PES 01/22/2009  Added for intellisense support

            pw.println(indent, "///<summary>");
            pw.println(indent, "///" + aClass.getClassComments());
            pw.println(indent, "///</summary>");
        }
        pw.println(indent, "public " + aClass.getName() + "()");
        pw.println(indent, "{");

        // Set primitive types with initial values
        List inits = aClass.getInitialValues();
        for (int idx = 0; idx < inits.size(); idx++) {
            InitialValue anInit = (InitialValue) inits.get(idx);

            // This is irritating. we have to match up the attribute name with the type,
            // so we can do a cast. Otherwise java pukes because it wants to interpret all
            // numeric strings as ints or doubles, and the attribute may be a short.

            boolean found = false;
            GeneratedClass currentClass = aClass;
            String aType = null;

            while (currentClass != null) {
                List thisClassesAttributes = currentClass.getClassAttributes();
                for (int jdx = 0; jdx < thisClassesAttributes.size(); jdx++) {
                    ClassAttribute anAttribute = (ClassAttribute) thisClassesAttributes.get(jdx);

                    if (anInit.getVariable().equals(anAttribute.getName())) {
                        found = true;
                        aType = anAttribute.getType();
                        break;
                    }
                }
                currentClass = (GeneratedClass) classDescriptions.get(currentClass.getParentClass());
            }
            if (!found) {

                System.out.println("Could not find initial value matching attribute name for " + anInit.getVariable() + " in class " + aClass.getName());
            } else {
                //PES modified the InitalValue.java class to provide a method name that would work with the changes made in this file
                pw.println(indent + 1, anInit.getSetterMethodNameCSharp() + " = (" + types.getProperty(aType) + ")" + anInit.getVariableValue() + ";");
            }
        } // End initialize initial values

        // If we have fixed lists with object instances in them, initialize thos

        for (int idx = 0; idx < ivars.size(); idx++) {
            ClassAttribute anAttribute = (ClassAttribute) ivars.get(idx);

            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST) {
                //System.out.println("Generating constructor fixed list for " + anAttribute.getName() + " listIsClass:" + anAttribute.listIsClass());
                if (anAttribute.listIsClass() == true) {
                    pw.println(indent + 1, "");
                    pw.println(indent + 1, "for(int idx = 0; idx < " + anAttribute.getName() + ".Length; idx++)");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, anAttribute.getName() + "[idx] = new " + anAttribute.getType() + "();");
                    pw.println(indent + 1, "}");
                }
            }
        }
        pw.println(indent, "}");
    }

    public void writeGetMarshalledSizeMethod(PrintStringBuffer pw, GeneratedClass aClass, int indent) {
        List ivars = aClass.getClassAttributes();

        String newKeyword = ""; //PES 032209 added to remove warning from C# compiler
        //PES 032209 added to remove warning from C# compiler
        if (!aClass.getParentClass().equalsIgnoreCase("root")) {
            newKeyword = "new ";
        } else {
            newKeyword = "";
        }

        // Create a getMarshalledSize() method
        pw.println();
        pw.println(indent, newKeyword + "public int getMarshalledSize()");
        pw.println(indent, "{");
        pw.println(indent + 1, "int marshalSize = 0; ");
        pw.println();

        // Size of superclass is the starting point
        if (!aClass.getParentClass().equalsIgnoreCase("root")) {
            pw.println(indent + 1, "marshalSize = base.getMarshalledSize();");
        }

        for (int idx = 0; idx < ivars.size(); idx++) {
            ClassAttribute anAttribute = (ClassAttribute) ivars.get(idx);

            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE) {
                pw.print(indent + 1, "marshalSize = marshalSize + ");
                pw.println(primitiveSizes.get(anAttribute.getType()) + ";  // _" + anAttribute.getName());
            }

            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF) {
                pw.print(indent + 1, "marshalSize = marshalSize + ");
                pw.println("_" + anAttribute.getName() + ".getMarshalledSize();  // _" + anAttribute.getName());
            }

            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST) {
                //System.out.println("Generating fixed list for " + anAttribute.getName() + " listIsClass:" + anAttribute.listIsClass());
                // If this is a fixed list of primitives, it's the list size times the size of the primitive.
                if (anAttribute.getUnderlyingTypeIsPrimitive() == true) {
                    pw.println(indent + 1, "marshalSize = marshalSize + " + anAttribute.getListLength() + " * " + primitiveSizes.get(anAttribute.getType()) + ";  // _" + anAttribute.getName());
                } else if (anAttribute.listIsClass() == true) {
                    pw.println("");
                    pw.println(indent + 1, "for(int idx = 0; idx < _" + anAttribute.getName() + ".Length; idx++)");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, "marshalSize = marshalSize + _" + anAttribute.getName() + "[idx].getMarshalledSize();");
                    pw.println(indent + 1, "}");
                    pw.println(indent + 1, "");
                } else {
                    //pw.println( anAttribute.getListLength() + " * " +  " new " + anAttribute.getType() + "().getMarshalledSize()"  + ";  // _" + anAttribute.getName());
                    pw.println(indent + 1, "THIS IS A CONDITION NOT HANDLED BY XMLPG: a fixed list array of lists. That's  why you got the compile error.");
                }
            }

            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) {
                // If this is a dynamic list of primitives, it's the list size times the size of the primitive.
                if (anAttribute.getUnderlyingTypeIsPrimitive() == true) {
                    pw.println(indent + 1, "_" + anAttribute.getName() + ".Count " + " * " + primitiveSizes.get(anAttribute.getType()) + ";  // " + anAttribute.getName());
                } else {
                    //PES 04/29/2009  Added to speed up unboxing of data, using byte[] vice unboxing of a Class ie. OneByteChunk
                    if (anAttribute.getType().equalsIgnoreCase("OneByteChunk")) {
                        pw.println(indent + 1, "marshalSize = marshalSize + _" + anAttribute.getName() + ".Length;");
                    } else {
                        pw.println(indent + 1, "for(int idx=0; idx < _" + anAttribute.getName() + ".Count; idx++)");
                        pw.println(indent + 1, "{");
                        pw.println(indent + 2, anAttribute.getType() + " listElement = (" + anAttribute.getType() + ")_" + anAttribute.getName() + "[idx];");
                        pw.println(indent + 2, "marshalSize = marshalSize + listElement.getMarshalledSize();");
                        pw.println(indent + 1, "}");
                    }
                }
            }
        }
        pw.println();
        pw.println(indent + 1, "return marshalSize;");
        pw.println(indent, "}");
        pw.println();
    }

    private void writeClassAttributeSummary(PrintStringBuffer pw, ClassAttribute anAttribute, int indent) {
        if (anAttribute.getComment() != null) { //PES 01/22/2009  Added for intellisense support
            pw.println(indent, "///<summary>");
            pw.println(indent, "///" + anAttribute.getComment());
            pw.println(indent, "///</summary>");
        }
    }

    private void writeGettersAndSetters(PrintStringBuffer pw, GeneratedClass aClass, int indent) {
        List ivars = aClass.getClassAttributes();

        pw.println();
        String classNameConflictModifier;

        for (int idx = 0; idx < ivars.size(); idx++) {
            ClassAttribute anAttribute = (ClassAttribute) ivars.get(idx);

            classNameConflictModifier = ""; //Used to modify the get/set public accessor if class name is the same

            //Check to see if conflict with Class name or C# key words.  Appended underscore as a temporary workaround.  Also note that
            //the key words and class names should be put into a collection to make future testing easier.
            if (aClass.getName().equals(this.initialCap(anAttribute.getName())) || anAttribute.getName().equalsIgnoreCase("system")) {
                classNameConflictModifier = "_";
            }

            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE) {
                if (anAttribute.getIsDynamicListLengthField() == false) {
                    String beanType = types.getProperty(anAttribute.getType());


                    writeClassAttributeSummary(pw, anAttribute, indent);
                    pw.println(indent, "public void set" + this.initialCap(anAttribute.getName()) + "(" + beanType + " p" + this.initialCap(anAttribute.getName()) + ")");
                    pw.println(indent, "{ ");
                    pw.println(indent + 1, "_" + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                    pw.println(indent, "}");

                    pw.println();

                    pw.println(indent, "[XmlElement(Type= typeof(" + beanType + "), ElementName=\"" + anAttribute.getName() + "\")]");
                    pw.println(indent, "public " + beanType + " " + this.initialCap(anAttribute.getName()) + classNameConflictModifier);
                    pw.println(indent, "{");
                    pw.println(indent + 1, "get");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, "return _" + anAttribute.getName() + ";");
                    pw.println(indent + 1, "}");
                    pw.println(indent + 1, "set");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, "_" + anAttribute.getName() + " = value;");
                    pw.println(indent + 1, "}");
                    pw.println(indent, "}");
                    pw.println();
                } else // This is the count field for a dynamic list
                {//PES 01/21/2009 added back in to account for getting length on dynamic lists
                    String beanType = types.getProperty(anAttribute.getType());
                    ClassAttribute listAttribute = anAttribute.getDynamicListClassAttribute();

                    pw.println(indent, "/// <summary>");
                    pw.println(indent, "/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.");
                    pw.println(indent, "/// The get" + anAttribute.getName() + " method will also be based on the actual list length rather than this value. ");
                    pw.println(indent, "/// The method is simply here for completeness and should not be used for any computations.");
                    pw.println(indent, "/// </summary>");
                    pw.println(indent, "public void set" + this.initialCap(anAttribute.getName()) + "(" + beanType + " p" + this.initialCap(anAttribute.getName()) + ")");
                    pw.println(indent, "{");
                    pw.println(indent + 1, "_" + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                    pw.println(indent, "}");

                    pw.println();

                    pw.println(indent, "/// <summary>");
                    pw.println(indent, "/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.");
                    pw.println(indent, "/// The get" + anAttribute.getName() + " method will also be based on the actual list length rather than this value. ");
                    pw.println(indent, "/// The method is simply here for completeness and should not be used for any computations.");
                    pw.println(indent, "/// </summary>");
                    pw.println(indent, "[XmlElement(Type= typeof(" + beanType + "), ElementName=\"" + anAttribute.getName() + "\")]");
                    pw.println(indent, "public " + beanType + " " + this.initialCap(anAttribute.getName()) + classNameConflictModifier);
                    pw.println(indent, "{");
                    pw.println(indent + 1, "get");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, "return _" + anAttribute.getName() + ";");
                    pw.println(indent + 1, "}");
                    pw.println(indent + 1, "set");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, "_" + anAttribute.getName() + " = value;");
                    pw.println(indent + 1, "}");
                    pw.println(indent, "}");
                    pw.println();
                }

            } // End is primitive

            // The attribute is a class of some sort. Generate getters and setters.

            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF) {
                writeClassAttributeSummary(pw, anAttribute, indent);
                pw.println(indent, "public void set" + this.initialCap(anAttribute.getName()) + "(" + anAttribute.getType() + " p" + this.initialCap(anAttribute.getName()) + ")");
                pw.println(indent, "{ ");
                pw.println(indent + 1, "_" + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                pw.println(indent, "}");
                pw.println();

                writeClassAttributeSummary(pw, anAttribute, indent);
                pw.println(indent, "public " + anAttribute.getType() + " get" + this.initialCap(anAttribute.getName()) + "()");
                pw.println(indent, "{");
                pw.println(indent + 1, "return _" + anAttribute.getName() + ";");
                pw.println(indent, "}");
                pw.println();

                writeClassAttributeSummary(pw, anAttribute, indent);
                pw.println(indent, "[XmlElement(Type= typeof(" + anAttribute.getType() + "), ElementName=\"" + anAttribute.getName() + "\")]");
                pw.println(indent, "public " + anAttribute.getType() + " " + this.initialCap(anAttribute.getName()) + classNameConflictModifier);
                pw.println(indent, "{");
                pw.println(indent + 1, "get");
                pw.println(indent + 1, "{");
                pw.println(indent + 2, "return _" + anAttribute.getName() + ";");
                pw.println(indent + 1, "}");
                pw.println(indent + 1, "set");
                pw.println(indent + 1, "{");
                pw.println(indent + 2, "_" + anAttribute.getName() + " = value;");
                pw.println(indent + 1, "}");
                pw.println(indent, "}");
                pw.println();
            }

            // The attribute is an array of some sort. Generate getters and setters.
            if ((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)) {
                if (anAttribute.getUnderlyingTypeIsPrimitive()) {
                    writeClassAttributeSummary(pw, anAttribute, indent);
                    pw.println(indent, "public void set" + this.initialCap(anAttribute.getName()) + "(" + types.getProperty(anAttribute.getType()) + "[] p" + this.initialCap(anAttribute.getName()) + ")");
                    pw.println(indent, "{");
                    pw.println(indent + 1, "_" + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                    pw.println(indent, "}");
                    pw.println();

                    writeClassAttributeSummary(pw, anAttribute, indent);
                    //pw.println("@XmlElement(name=\"" + anAttribute.getName() + "\" )");
                    pw.println(indent, "public " + types.getProperty(anAttribute.getType()) + "[] get" + this.initialCap(anAttribute.getName()) + "()");
                    pw.println(indent, "{");
                    pw.println(indent + 1, "return _" + anAttribute.getName() + ";");
                    pw.println(indent, "}");
                    pw.println();

                    writeClassAttributeSummary(pw, anAttribute, indent);
                    pw.println(indent, "[XmlArray(ElementName=\"" + anAttribute.getName() + "\")]");
                    pw.println(indent, "public " + types.getProperty(anAttribute.getType()) + "[] " + this.initialCap(anAttribute.getName()) + classNameConflictModifier);
                    pw.println(indent, "{");
                    pw.println(indent+1, "get");
                    pw.println(indent+1, "{");
                    pw.println(indent+2, "return _" + anAttribute.getName() + ";");
                    pw.println(indent+1, "}");
                    pw.println(indent+1, "set");
                    pw.println(indent+1, "{");
                    pw.println(indent+2, "_" + anAttribute.getName() + " = value;");
                    pw.println(indent+1, "}");
                    pw.println("}");
                    pw.println();

                } else if (anAttribute.listIsClass() == true) {
                    writeClassAttributeSummary(pw, anAttribute, indent);
                    pw.println(indent, "public void set" + this.initialCap(anAttribute.getName()) + "(" + anAttribute.getType() + "[] p" + this.initialCap(anAttribute.getName()) + ")");
                    pw.println(indent, "{");
                    pw.println(indent + 1, "_" + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                    pw.println(indent, "}");
                    pw.println();

                    writeClassAttributeSummary(pw, anAttribute, indent);
                    //pw.println("@XmlElementWrapper(name=\"" + anAttribute.getName() + "Array\" )");
                    pw.println(indent, "public " + anAttribute.getType() + "[] get" + this.initialCap(anAttribute.getName()) + "()");
                    pw.println(indent, "{");
                    pw.println(indent + 1, "return _" + anAttribute.getName() + ";");
                    pw.println(indent, "}");
                    pw.println();

                    writeClassAttributeSummary(pw, anAttribute, indent);
                    pw.println(indent, "[XmlArrayItem(ElementName = \"" + anAttribute.getName() + "Array\",DataType=\"" + anAttribute.getType() + "\"))]");
                    pw.println(indent, "public " + anAttribute.getType() + "[] " + this.initialCap(anAttribute.getName()));
                    pw.println(indent, "{");
                    pw.println(indent + 1, "get");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, "          return _" + anAttribute.getName() + ";");
                    pw.println(indent + 1, "}");
                    pw.println(indent + 1, "set");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, "_" + anAttribute.getName() + " = value;");
                    pw.println(indent + 1, "}");
                    pw.println(indent, "}");
                    pw.println();
                }
            }

            if ((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)) {	//Set List to the actual type 01/21/2009 PES

                writeClassAttributeSummary(pw, anAttribute, indent);
                //PES 04/29/2009  Added to speed up unboxing of data, using byte[] vice unboxing of a Class ie. OneByteChunk
                if (anAttribute.getType().equalsIgnoreCase("OneByteChunk")) {
                    pw.println(indent, "public void set" + this.initialCap(anAttribute.getName()) + "(byte[] p" + this.initialCap(anAttribute.getName()) + ")");
                    pw.println(indent, "{");
                    pw.println(indent + 1, "_" + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                    pw.println(indent, "}");
                    pw.println();

                    //Set List to actual type 01/21/2009 PES
                    //pw.println("@XmlElementWrapper(name=\"" + anAttribute.getName() + "List\" )");
                    writeClassAttributeSummary(pw, anAttribute, indent);
                    pw.println(indent, "public byte[] get" + this.initialCap(anAttribute.getName()) + "()");
                    pw.println(indent, "{");
                    pw.println(indent + 1, "return _" + anAttribute.getName() + ";");
                    pw.println(indent, "}");
                    pw.println();

                    writeClassAttributeSummary(pw, anAttribute, indent);
                    pw.println(indent, "[XmlElement(ElementName = \"" + anAttribute.getName() + "List\", DataType = \"hexBinary\")]");
                    pw.println(indent, "public byte[] " + this.initialCap(anAttribute.getName()));
                    pw.println(indent, "{");
                    pw.println(indent + 1, "get");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, "return _" + anAttribute.getName() + ";");
                    pw.println(indent + 1, "}");
                    pw.println(indent + 1, "set");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, "_" + anAttribute.getName() + " = value;");
                    pw.println(indent + 1, "}");
                    pw.println(indent, "}");
                    pw.println();

                } else {
                    pw.println(indent, "public void set" + this.initialCap(anAttribute.getName()) + "(List<" + anAttribute.getType() + ">" + " p" + this.initialCap(anAttribute.getName()) + ")");
                    pw.println(indent, "{");
                    pw.println(indent + 1, "_" + anAttribute.getName() + " = p" + this.initialCap(anAttribute.getName()) + ";");
                    pw.println(indent, "}");
                    pw.println();

                    //Set List to actual type 01/21/2009 PES
                    //pw.println("@XmlElementWrapper(name=\"" + anAttribute.getName() + "List\" )");
                    writeClassAttributeSummary(pw, anAttribute, indent);
                    pw.println(indent, "public List<" + anAttribute.getType() + ">" + " get" + this.initialCap(anAttribute.getName()) + "()");
                    pw.println(indent, "{");
                    pw.println(indent + 1, "return _" + anAttribute.getName() + ";");
                    pw.println(indent, "}");
                    pw.println();

                    writeClassAttributeSummary(pw, anAttribute, indent);
                    pw.println(indent, "[XmlElement(ElementName = \"" + anAttribute.getName() + "List\",Type = typeof(List<" + anAttribute.getType() + ">))]");
                    pw.println(indent, "public List<" + anAttribute.getType() + "> " + this.initialCap(anAttribute.getName()));
                    pw.println(indent, "{");
                    pw.println(indent + 1, "get");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, "return _" + anAttribute.getName() + ";");
                    pw.println(indent + 1, "}");
                    pw.println(indent + 1, "set");
                    pw.println(indent + 1, "{");
                    pw.println(indent + 2, "_" + anAttribute.getName() + " = value;");
                    pw.println(indent + 1, "}");
                    pw.println(indent, "}");
                    pw.println();
                }
            }
        } // End of loop trough writing getter/setter methods

    }

    private void writeMarshalMethod(PrintStringBuffer pw, GeneratedClass aClass, int indent) {
        List ivars = aClass.getClassAttributes();
        String baseclassName = aClass.getParentClass();
        String newKeyword = ""; //PES 032209 added to remove warning from C# compiler

        //PES 02/10/2009 Added to support auto setting of length field
        if (!baseclassName.equalsIgnoreCase("root")) {
            boolean exitLoop = false;
            boolean foundMatch = true;
            String matchValue = baseclassName;
            String key = "";

            if (!matchValue.equalsIgnoreCase("pdu")) {
                do {
                    key = "";
                    foundMatch = false;

                    if (classesInstantiated.containsKey(matchValue)) {
                        key = classesInstantiated.get(matchValue);
                    } else {
                        //No match to key, get out
                        break;
                    }

                    //There was a key test if the upper class is PDU.
                    //If so then can add new method to retrieve pdu length
                    if (!key.equals(null)) {
                        matchValue = key;
                        foundMatch = true;

                        if (key.equalsIgnoreCase("pdu")) {
                            exitLoop = true;
                        }
                    }

                    //If match not found at this point then get out
                    if (foundMatch == false) {
                        exitLoop = true;
                    }

                } while (exitLoop == false);

            }

            if (foundMatch == true) {
                //System.out.println("Found PDU writing data");

                //PES 032209 added to remove warning from C# compiler
                if (!baseclassName.equalsIgnoreCase("pdu")) {
                    newKeyword = "new ";
                } else {
                    newKeyword = "";
                }

                pw.println(indent, "///<summary>");
                pw.println(indent, "///Automatically sets the length of the marshalled data, then calls the marshal method.");
                pw.println(indent, "///</summary>");
                pw.println(indent, newKeyword + "public void marshalAutoLengthSet(DataOutputStream dos)");
                pw.println(indent, "{");
                pw.println(indent + 1, "//Set the length prior to marshalling data");
                pw.println(indent + 1, "this.setLength((ushort)this.getMarshalledSize());");
                pw.println(indent + 1, "this.marshal(dos);");
                pw.println(indent, "}");
            }

        }

        if (!baseclassName.equalsIgnoreCase("root")) {
            newKeyword = "new ";
        } else {
            newKeyword = "";
        }

        pw.println();
        pw.println(indent, "///<summary>");
        pw.println(indent, "///Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method");
        pw.println(indent, "///</summary>");
        pw.println(indent, newKeyword + "public void marshal(DataOutputStream dos)");
        pw.println(indent, "{");

        // If we're a base class of another class, we should first call base
        // to make sure the base's ivars are marshaled out.
        if (!(baseclassName.equalsIgnoreCase("root"))) {
            pw.println(indent + 1, "base.marshal(dos);");
        }
        pw.println(indent + 1, "try");
        pw.println(indent + 1, "{");
        // Loop through the class attributes, generating the output for each.
        ivars = aClass.getClassAttributes();

        //This is a way to make sure that the variable used to store the count uses the .Length nomenclature.  There was no way
        //for me to determine if the OneByteChunk was used as it defaulted to a short data type.
        ArrayList<String> variableListfix = new ArrayList<String>();
        for (int idx = 0; idx < ivars.size(); idx++) {
            ClassAttribute anAttribute = (ClassAttribute) ivars.get(idx);
            if (anAttribute.getType().equalsIgnoreCase("OneByteChunk")) {
                variableListfix.add(anAttribute.getName());
            }
        }


        for (int idx = 0; idx < ivars.size(); idx++) {
            ClassAttribute anAttribute = (ClassAttribute) ivars.get(idx);

            // Write out a method call to serialize a primitive type
            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE) {
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                String capped = this.initialCap(marshalType);

                // If we're a normal primitivetype, marshal out directly; otherwise, marshall out
                // the list length.
                if (anAttribute.getIsDynamicListLengthField() == false) {
                    pw.println(indent + 2, "dos.write" + capped + "((" + marshalType + ")_" + anAttribute.getName() + ");");
                } else {
                    ClassAttribute listAttribute = anAttribute.getDynamicListClassAttribute();

                    //This was determined not to be working due to the fact that the OneByteChunk class is never referenced for the
                    //data length field.  See above for work around
                    //PES 04/29/2009  Added to speed up unboxing of data, using byte[] vice unboxing of a Class ie. OneByteChunk
                    //if (anAttribute.getType().equalsIgnoreCase("OneByteChunk"))
                    //{
                    //	pw.println("       dos.write" + capped + "((" + marshalType + ")_" + listAttribute.getName() + ".Length);");
                    //}
                    //else
                    //{
                    if (variableListfix.contains(listAttribute.getName()) == true) {
                        pw.println(indent + 2, "dos.write" + capped + "((" + marshalType + ")_" + listAttribute.getName() + ".Length);");
                    } else {
                        pw.println(indent + 2, "dos.write" + capped + "((" + marshalType + ")_" + listAttribute.getName() + ".Count);");
                    }
                    //}
                }

            }

            // Write out a method call to serialize a class.
            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF) {
                String marshalType = anAttribute.getType();

                pw.println(indent + 2, "_" + anAttribute.getName() + ".marshal(dos);");
            }

            // Write out the method call to marshal a fixed length list, aka an array.
            if ((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)) {
                pw.println();
                pw.println(indent + 2, "for(int idx = 0; idx < _" + anAttribute.getName() + ".Length; idx++)");
                pw.println(indent + 2, "{");

                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.

                String marshalType = marshalTypes.getProperty(anAttribute.getType());

                //String attributeArrayModifier = "";
                //if (anAttribute.getUnderlyingTypeIsPrimitive() == true)
                //{
                //    attributeArrayModifier = "[]";
                //}

                if (anAttribute.getUnderlyingTypeIsPrimitive()) {
                    String capped = this.initialCap(marshalType);
                    pw.println(indent + 3, "dos.write" + capped + "(_" + anAttribute.getName() + "[idx]);");
                } else {
                    pw.println(indent + 3, "_" + anAttribute.getName() + "[idx].marshal(dos);");
                }

                pw.println(indent + 2, "} // end of array marshaling");
                pw.println();
            }

            // Write out a section of code to marshal a variable length list. The code should look like
            //
            // for(int idx = 0; idx < attrName.size(); idx++)
            // { anAttribute.marshal(dos);
            // }
            //

            if ((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)) {
                //PES 04/29/2009  Added to speed up unboxing of data, using byte[] vice unboxing of a Class ie. OneByteChunk
                if (anAttribute.getType().equalsIgnoreCase("OneByteChunk")) {
                    pw.println(indent + 2, "dos.writeByte (_" + anAttribute.getName() + ");");

                } else {
                    pw.println();
                    pw.println(indent + 2, "for(int idx = 0; idx < _" + anAttribute.getName() + ".Count; idx++)");
                    pw.println(indent + 2, "{");

                    // This is some sleaze. We're an array, but an array of what? We could be either a
                    // primitive or a class. We need to figure out which. This is done via the expedient
                    // but not very reliable way of trying to do a lookup on the type. If we don't find
                    // it in our map of primitives to marshal types, we assume it is a class.

                    String marshalType = marshalTypes.getProperty(anAttribute.getType());

                    if (anAttribute.getUnderlyingTypeIsPrimitive()) {
                        String capped = this.initialCap(marshalType);
                        pw.println(indent + 3, "dos.write" + capped + "(_" + anAttribute.getName() + ");");
                    } else {
                        pw.println(indent + 3, anAttribute.getType() + " a" + initialCap(anAttribute.getType() + " = (" + anAttribute.getType() + ")_" +
                                anAttribute.getName() + "[idx];"));
                        pw.println(indent + 3, "a" + initialCap(anAttribute.getType()) + ".marshal(dos);");
                    }

                    pw.println(indent + 2, "} // end of list marshalling");
                    pw.println();
                }
            }
        } // End of loop through the ivars for a marshal method

        pw.println(indent + 1, "} // end try");
        pw.println(indent + 1, "catch(Exception e)");
        pw.println(indent + 1, "{");
        pw.println(indent + 2, "Trace.WriteLine(e);");
        pw.println(indent + 2, "Trace.Flush();");
        pw.println(indent + 1, "}");
        pw.println(indent, "} // end of marshal method");
    }

    private void writeUnmarshallMethod(PrintStringBuffer pw, GeneratedClass aClass, int indent) {
        List ivars = aClass.getClassAttributes();
        String baseclassName;

        String newKeyword = ""; //PES 032209 added to remove warning from C# compiler

        //PES 032209 added to remove warning from C# compiler
        if (!aClass.getParentClass().equalsIgnoreCase("root")) {
            newKeyword = "new ";
        } else {
            newKeyword = "";
        }

        pw.println();
        pw.println(indent, newKeyword + "public void unmarshal(DataInputStream dis)");
        pw.println(indent, "{");

        baseclassName = aClass.getParentClass();
        if (!(baseclassName.equalsIgnoreCase("root"))) {
            pw.println(indent + 1, "base.unmarshal(dis);\n");
        }


        pw.println(indent + 1, "try");
        pw.println(indent + 1, "{");

        // Loop through the class attributes, generating the output for each.

        ivars = aClass.getClassAttributes();
        for (int idx = 0; idx < ivars.size(); idx++) {
            ClassAttribute anAttribute = (ClassAttribute) ivars.get(idx);

            // Write out a method call to deserialize a primitive type
            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE) {
                String marshalType = unmarshalTypes.getProperty(anAttribute.getType());
                String capped = this.initialCap(marshalType);
                if (marshalType.equalsIgnoreCase("UnsignedByte")) {
                    pw.println(indent + 2, "_" + anAttribute.getName() + " = (short)dis.read" + capped + "();");
                } else if (marshalType.equalsIgnoreCase("UnsignedShort")) {
                    pw.println(indent + 2, "_" + anAttribute.getName() + " = (int)dis.read" + capped + "();");
                } else {
                    pw.println(indent + 2, "_" + anAttribute.getName() + " = dis.read" + capped + "();");
                }
            }

            // Write out a method call to deserialize a class.
            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF) {
                String marshalType = anAttribute.getType();

                pw.println(indent + 2, "_" + anAttribute.getName() + ".unmarshal(dis);");
            }

            // Write out the method call to unmarshal a fixed length list, aka an array.
            if ((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)) {
                pw.println(indent + 2, "for(int idx = 0; idx < _" + anAttribute.getName() + ".Length; idx++)");
                pw.println(indent + 2, "{");

                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.

                String marshalType = marshalTypes.getProperty(anAttribute.getType());

                if (marshalType == null) // It's a class
                {
                    pw.println(indent + 3, "_" + anAttribute.getName() + "[idx].unmarshal(dis);");
                } else // It's a primitive
                {
                    String capped = this.initialCap(marshalType);
                    pw.println(indent + 3, "_" + anAttribute.getName() + "[idx] = dis.read" + capped + "();");
                }

                pw.println(indent + 2, "} // end of array unmarshaling");
            } // end of array unmarshalling

            // Unmarshall a variable length array.

            if ((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)) {
                String marshalType = marshalTypes.getProperty(anAttribute.getType());

                //PES 04/29/2009  Added to speed up unboxing of data, using byte[] vice unboxing of a Class ie. OneByteChunk
                if (anAttribute.getType().equalsIgnoreCase("OneByteChunk")) {
                    pw.println(indent + 2, "_" + anAttribute.getName() + " = dis.readByteArray" + "(_" + anAttribute.getCountFieldName() + ");");
                } else {
                    pw.println(indent + 2, "for(int idx = 0; idx < _" + anAttribute.getCountFieldName() + "; idx++)");
                    pw.println(indent + 2, "{");

                    // This is some sleaze. We're an array, but an array of what? We could be either a
                    // primitive or a class. We need to figure out which. This is done via the expedient
                    // but not very reliable way of trying to do a lookup on the type. If we don't find
                    // it in our map of primitives to marshal types, we assume it is a class.


                    if (marshalType == null) // It's a class
                    {
                        pw.println(indent + 3, anAttribute.getType() + " anX = new " + anAttribute.getType() + "();");
                        pw.println(indent + 3, "anX.unmarshal(dis);");
                        pw.println(indent + 3, "_" + anAttribute.getName() + ".Add(anX);");
                    } else // It's a primitive
                    {
                        String capped = this.initialCap(marshalType);
                        pw.println(indent + 3, "dis.read" + capped + "(_" + anAttribute.getName() + ");");
                    }
                    pw.println(indent + 2, "};");
                    pw.println();
                }
            } // end of unmarshalling a variable list

        } // End of loop through ivars for writing the unmarshal method

        pw.println(indent + 1, "} // end try");
        pw.println(indent + 1, "catch(Exception e)");
        pw.println(indent + 1, "{");
        pw.println(indent + 2, "Trace.WriteLine(e);");
        pw.println(indent + 2, "Trace.Flush();");
        pw.println(indent + 1, "}");
        pw.println(indent, "} // end of unmarshal method");

    }

    //Generate listing of all parameters using psuedo reflection.  This method needs to be further refined as it is only useful for
    //printing out all the data, the format used is not nice.  This method however will display faster than using the XML reflection method provided.
    //Only used for debugging purposes until a better method could be developed.
    private void writeReflectionMethod(PrintStringBuffer pw, GeneratedClass aClass, int indent) {
        List ivars = aClass.getClassAttributes();
        String tab = "\\t ";

        String newKeyword = ""; //PES 032209 added to remove warning from C# compiler

        //PES 032209 added to remove warning from C# compiler
        if (!aClass.getParentClass().equalsIgnoreCase("root")) {
            newKeyword = "new ";
        } else {
            newKeyword = "";
        }


        pw.println();
        pw.println(indent, "///<summary>");
        pw.println(indent, "///This allows for a quick display of PDU data.  The current format is unacceptable and only used for debugging.");
        pw.println(indent, "///This will be modified in the future to provide a better display.  Usage: ");
        pw.println(indent, "///pdu.GetType().InvokeMember(\"reflection\", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { sb });");
        pw.println(indent, "///where pdu is an object representing a single pdu and sb is a StringBuilder.");
        pw.println(indent, "///Note: The supplied Utilities folder contains a method called 'DecodePDU' in the PDUProcessor Class that provides this functionality");
        pw.println(indent, "///</summary>");
        pw.println(indent, newKeyword + "public void reflection(StringBuilder sb)");
        pw.println(indent, "{");
        pw.println(indent + 1, "sb.Append(\"<" + aClass.getName() + ">\"  + System.Environment.NewLine);");

        // If we're a base class of another class, we should first call base
        // to make sure the base's ivars are reflected out.
        String baseclassName = aClass.getParentClass();
        if (!(baseclassName.equalsIgnoreCase("root"))) {
            pw.println(indent + 1, "base.reflection(sb);");
        }

        pw.println(indent + 1, "try");
        pw.println(indent + 1, "{");
        // Loop through the class attributes, generating the output for each.

        ivars = aClass.getClassAttributes();

        //This is a way to make sure that the variable used to store the count uses the .Length nomenclature.  There was no way
        //for me to determine if the OneByteChunk was used as it defaulted to a short data type.
        ArrayList<String> variableListfix = new ArrayList<String>();
        for (int idx = 0; idx < ivars.size(); idx++) {
            ClassAttribute anAttribute = (ClassAttribute) ivars.get(idx);
            if (anAttribute.getType().equalsIgnoreCase("OneByteChunk")) {
                variableListfix.add(anAttribute.getName());
            }
        }


        for (int idx = 0; idx < ivars.size(); idx++) {
            ClassAttribute anAttribute = (ClassAttribute) ivars.get(idx);

            // Write out a method call to reflect a primitive type
            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE) {
                String marshalType = marshalTypes.getProperty(anAttribute.getType());
                String capped = this.initialCap(marshalType);

                // If we're a normal primitivetype, marshal out directly; otherwise, marshall out
                // the list length.
                if (anAttribute.getIsDynamicListLengthField() == false) {
                    //pw.println("           sb.Append(\"" + marshalType + tab + "_" + anAttribute.getName() + tab + "\" + _" + anAttribute.getName() + ".ToString() + System.Environment.NewLine);");
                    pw.println(indent + 2, "sb.Append(\"<" + anAttribute.getName() + " type=\\\"" + marshalType + "\\\">\" + _" + anAttribute.getName() + ".ToString() + \"</" + anAttribute.getName() + "> \" + System.Environment.NewLine);");

                } else {
                    ClassAttribute listAttribute = anAttribute.getDynamicListClassAttribute();

                    //PES 04/29/2009  Added to speed up unboxing of data, using byte[] vice unboxing of a Class ie. OneByteChunk
                    if (variableListfix.contains(listAttribute.getName()) == true) {
                        pw.println(indent + 2, "sb.Append(\"<" + listAttribute.getName() + " type=\\\"" + marshalType + "\\\">\" + _" + listAttribute.getName() + ".Length.ToString() + \"</" + listAttribute.getName() + "> \" + System.Environment.NewLine);");
                    } else {
                        pw.println(indent + 2, "sb.Append(\"<" + listAttribute.getName() + " type=\\\"" + marshalType + "\\\">\" + _" + listAttribute.getName() + ".Count.ToString() + \"</" + listAttribute.getName() + "> \" + System.Environment.NewLine);");
                    }
                }

            }

            // Write out a method call to reflect another class.
            if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF) {
                String marshalType = anAttribute.getType();
                pw.println(indent + 2, "sb.Append(\"<" + anAttribute.getName() + ">\"  + System.Environment.NewLine);");
                pw.println(indent + 2, "_" + anAttribute.getName() + ".reflection(sb);");
                pw.println(indent + 2, "sb.Append(\"</" + anAttribute.getName() + ">\"  + System.Environment.NewLine);");
            }

            // Write out the method call to marshal a fixed length list, aka an array.
            if ((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST)) {
                //pw.println("    sb.Append(\"</" + anAttribute.getName() + ">\"  + System.Environment.NewLine);");

                pw.println();
                pw.println(indent + 2, "for(int idx = 0; idx < _" + anAttribute.getName() + ".Length; idx++)");
                pw.println(indent + 2, "{");

                // This is some sleaze. We're an array, but an array of what? We could be either a
                // primitive or a class. We need to figure out which. This is done via the expedient
                // but not very reliable way of trying to do a lookup on the type. If we don't find
                // it in our map of primitives to marshal types, we assume it is a class.

                String marshalType = marshalTypes.getProperty(anAttribute.getType());

                if (anAttribute.getUnderlyingTypeIsPrimitive()) {
                    String capped = this.initialCap(marshalType);
                    pw.println(indent + 2, "sb.Append(\"<" + anAttribute.getName() + "\"+ idx.ToString() + \" type=\\\"" + marshalType + "\\\">\" + _" + anAttribute.getName() + "[idx] + \"</" + anAttribute.getName() + "\"+ idx.ToString() + \"> \" + System.Environment.NewLine);");
                    //pw.println("           sb.Append(\"" + marshalType + tab + "\" + _" + anAttribute.getName() + "[idx] + System.Environment.NewLine);");
                } else {
                    pw.println(indent + 2, "sb.Append(\"<" + anAttribute.getName() + "\"+ idx.ToString() + \" type=\\\"" + anAttribute.getType() + "\\\">\" + _" + anAttribute.getName() + "[ \"+ idx.ToString() + \"] + System.Environment.NewLine);");
                    pw.println(indent + 2, "_" + anAttribute.getName() + "[idx].reflection(sb);");
                    pw.println(indent + 2, "sb.Append(\"</" + anAttribute.getName() + "\"+ idx.ToString() + \">\" + System.Environment.NewLine);");
                }

                pw.println(indent + 1, "} // end of array reflection");
                pw.println();
            }

            if ((anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST)) {
                pw.println();

                //This will fix the OneByteChunk problem where the arrays length is correctly set to Length vice Count.  This is needed as
                //there was no way to determine if the underlining data referenced the OneByteChunk class
                //PES 04/29/2009  Added to speed up unboxing of data, using byte[] vice unboxing of a Class ie. OneByteChunk
                if (variableListfix.contains(anAttribute.getName()) == true) {
                    pw.println(indent + 1, "sb.Append(\"<" + anAttribute.getName() + " type=\\\"byte[]\\\">\" + System.Environment.NewLine);");
                    pw.println(indent + 1, "foreach (byte b in _" + anAttribute.getName() + ") sb.Append(b.ToString(\"X2\"));");
                    pw.println(indent + 2, "sb.Append(\"</" + anAttribute.getName() + ">\" + System.Environment.NewLine);");

                } else {

                    pw.println(indent + 1, "for(int idx = 0; idx < _" + anAttribute.getName() + ".Count; idx++)");
                    pw.println(indent + 1, "{");

                    // This is some sleaze. We're an array, but an array of what? We could be either a
                    // primitive or a class. We need to figure out which. This is done via the expedient
                    // but not very reliable way of trying to do a lookup on the type. If we don't find
                    // it in our map of primitives to marshal types, we assume it is a class.

                    String marshalType = marshalTypes.getProperty(anAttribute.getType());

                    if (anAttribute.getUnderlyingTypeIsPrimitive()) {
                        String capped = this.initialCap(marshalType);

                        pw.println(indent + 2, "sb.Append(\"<" + anAttribute.getName() + "\"+ idx.ToString() + \" type=\\\"" + anAttribute.getType() + "\\\">\" + _" + anAttribute.getName() + "[idx].ToString() + System.Environment.NewLine);");
                        pw.println(indent + 2, "sb.Append(\"</" + anAttribute.getName() + "\"+ idx.ToString() + \">\" + System.Environment.NewLine);");

                        //pw.println("           sb.Append(\"" + marshalType + tab + "\" + _" + anAttribute.getName() + "  + System.Environment.NewLine);");
                    } else {
                        pw.println(indent + 2, "sb.Append(\"<" + anAttribute.getName() + "\"+ idx.ToString() + \" type=\\\"" + anAttribute.getType() + "\\\">\" + System.Environment.NewLine);");
                        pw.println(indent + 2, anAttribute.getType() + " a" + initialCap(anAttribute.getType() + " = (" + anAttribute.getType() + ")_" + anAttribute.getName() + "[idx];"));
                        pw.println(indent + 2, "a" + initialCap(anAttribute.getType()) + ".reflection(sb);");
                        pw.println(indent + 2, "sb.Append(\"</" + anAttribute.getName() + "\"+ idx.ToString() + \">\" + System.Environment.NewLine);");
                    }
                    pw.println(indent + 1, "} // end of list marshalling");
                    pw.println();
                }
            }
        } // End of loop through the ivars for a marshal method

        pw.println(indent + 2, "sb.Append(\"</" + aClass.getName() + ">\"  + System.Environment.NewLine);");

        pw.println(indent + 1, "} // end try");
        pw.println(indent + 1, "catch(Exception e)");
        pw.println(indent + 1, "{");
        pw.println(indent + 2, "Trace.WriteLine(e);");
        pw.println(indent + 2, "Trace.Flush();");
        pw.println(indent + 1, "}");
        pw.println(indent, "} // end of reflection method");
    }

    public void writeEqualityMethod(PrintStringBuffer pw, GeneratedClass aClass, int indent) {
        try {

            /**Added override method for != and == for C#   09142009 **/
            pw.println();
            pw.println(indent, "public static bool operator !=(" + aClass.getName() + " a, " + aClass.getName() + " b)");
            pw.println(indent, "{");
            pw.println(indent + 1, "return !(a == b);");
            pw.println(indent, "}");

            pw.println();
            pw.println(indent, "public static bool operator ==(" + aClass.getName() + " a, " + aClass.getName() + " b)");
            pw.println(indent, "{");
            pw.println(indent + 1, "if (System.Object.ReferenceEquals(a, b))");
            pw.println(indent + 1, "{");
            pw.println(indent + 2, "return true;");
            pw.println(indent + 1, "}");
            pw.println();
            pw.println(indent + 1, "if (((object)a == null) || ((object)b == null))");
            pw.println(indent + 1, "{");
            pw.println(indent + 2, "return false;");
            pw.println(indent + 1, "}");
            pw.println();
            pw.println(indent + 1, "return a.equals(b);");
            pw.println(indent, "}");
            pw.println();


		//** added to override the Equals 12082009
            pw.println();
            pw.println(indent, "public override bool Equals(object obj)");
            pw.println(indent, "{");
            pw.println(indent + 1, "return this == obj as " + aClass.getName() + ";");
            pw.println(indent, "}");
            pw.println();


            pw.println();
            pw.println(indent, "/**");
            pw.println(indent, " * Compares for reference equality and value equality.");
            pw.println(indent, " */");
            pw.println(indent, "public bool equals(" + aClass.getName() + " rhs)");
            pw.println(indent, "{");
            pw.println(indent + 1, "bool ivarsEqual = true;");
            pw.println();

            pw.println(indent + 1, "if(rhs.GetType() != this.GetType())");
            pw.println(indent + 2, "return false;");
            pw.println();

	    //If the class is PDU then do not use the base.Equals as it defaults to the base API version which will return a false
           String parentClass = aClass.getParentClass();
           if (!parentClass.equalsIgnoreCase("root")) {
	    	pw.println(indent + 1, "ivarsEqual = base.Equals(rhs);");
	    }

	    pw.println();

            for (int idx = 0; idx < aClass.getClassAttributes().size(); idx++) {
                ClassAttribute anAttribute = (ClassAttribute) aClass.getClassAttributes().get(idx);

                if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE) {
                    pw.println(indent + 1, "if( ! (_" + anAttribute.getName() + " == rhs._" + anAttribute.getName() + ")) ivarsEqual = false;");
                }

                if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF) {
                    pw.println(indent + 1, "if( ! (_" + anAttribute.getName() + ".Equals( rhs._" + anAttribute.getName() + ") )) ivarsEqual = false;");
                }


                if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST) {
    
			//PES 12082009 Added to account for issue with comparison of fields that are not marshalled.  Such as when creating two identical PDUs then
			//comparing them.  The _numberofxxx variables will contain 0 as they only get filled when marshalling.
 
                    pw.println();
                   
                    //pw.println(indent + 1, "if( ! (_" + anAttribute.getListLength() + " == rhs._" + anAttribute.getName() + ")) ivarsEqual = false;");
                   pw.println(indent + 1, "if( ! (rhs._" + anAttribute.getName() + ".Length == " + anAttribute.getListLength() + ")) ivarsEqual = false;");

	
			//If ivars is false then do not iterate through loop
                    pw.println(indent + 1, "if(ivarsEqual)");
		    pw.println(indent + 1, "{");

                    pw.println();
                    pw.println(indent + 2, "for(int idx = 0; idx < " + anAttribute.getListLength() + "; idx++)");
                    pw.println(indent + 2, "{");
                    pw.println(indent + 3, "if(!(_" + anAttribute.getName() + "[idx] == rhs._" + anAttribute.getName() + "[idx])) ivarsEqual = false;");
                    pw.println(indent + 2, "}");

	            pw.println(indent + 1, "}");
                    pw.println();
                }

                if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) {
                    //PES 04/29/2009  Added to speed up unboxing of data, using byte[] vice unboxing of a Class ie. OneByteChunk
                    if (anAttribute.getType().equalsIgnoreCase("OneByteChunk")) {
                        pw.println(indent + 1, "if( ! ( _" + anAttribute.getName() + ".Equals(rhs._" + anAttribute.getName() + "))) ivarsEqual = false;");

                    } else {
                        pw.println();
	
	                pw.println(indent + 1, "if( ! (_" + anAttribute.getName() + ".Count == rhs._" + anAttribute.getName() + ".Count)) ivarsEqual = false;");

			//If ivars is false then do not iterate through loop
             	        pw.println(indent + 1, "if(ivarsEqual)");
			pw.println(indent + 1, "{");

                        pw.println(indent + 2, "for(int idx = 0; idx < _" + anAttribute.getName() + ".Count; idx++)");
                        pw.println(indent + 2, "{");
			//PES 12102009 Do not believe this line is needed so commented out
                        //pw.println(indent + 3, anAttribute.getType() + " x = (" + anAttribute.getType() + ")_" + anAttribute.getName() + "[idx];");
                        pw.println(indent + 3, "if( ! ( _" + anAttribute.getName() + "[idx].Equals(rhs._" + anAttribute.getName() + "[idx]))) ivarsEqual = false;");
                        pw.println(indent + 2, "}");

 			pw.println(indent + 1, "}");
                        pw.println();
                    }
                }
            }
            pw.println();
            pw.println(indent + 1, "return ivarsEqual;");
            pw.println(indent, "}");



	    pw.println();
            pw.println(indent, "/**");
            pw.println(indent, " * HashCode Helper");
            pw.println(indent, " */");
            pw.println(indent, "private int GenerateHash(int hash)");
            pw.println(indent, "{");
            pw.println(indent + 1, "hash = hash << 5 + hash;");
            pw.println(indent + 1, "return(hash);");
	    pw.println(indent, "}");
            pw.println();




	    pw.println();
            pw.println(indent, "/**");
            pw.println(indent, " * Return Hash");
            pw.println(indent, " */");
            pw.println(indent, "public override int GetHashCode()");
            pw.println(indent, "{");
            pw.println(indent + 1, "int result = 0;");
	    pw.println();

	    //PES 12102009 needed to ensure that the base GetHashCode was not executed on a root class otherwise it returns random results
	    if (!parentClass.equalsIgnoreCase("root")) {
	      pw.println(indent + 1, "result = GenerateHash(result) ^ base.GetHashCode();");
	      pw.println();
	    }

            
            for (int idx = 0; idx < aClass.getClassAttributes().size(); idx++) {
                ClassAttribute anAttribute = (ClassAttribute) aClass.getClassAttributes().get(idx);

                if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.PRIMITIVE) {
                    pw.println(indent + 1, "result = GenerateHash(result) ^ _" + anAttribute.getName() + ".GetHashCode();");
                }

                if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.CLASSREF) {
                    pw.println(indent + 1, "result = GenerateHash(result) ^ _" + anAttribute.getName() + ".GetHashCode();");
                }


                if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.FIXED_LIST) {
     
                   pw.println();
                   
                   pw.println(indent + 1, "if(" + anAttribute.getListLength() + " > 0)");
		   pw.println(indent + 1, "{");

                    pw.println();
                    pw.println(indent + 2, "for(int idx = 0; idx < " + anAttribute.getListLength() + "; idx++)");
                    pw.println(indent + 2, "{");
                    pw.println(indent + 3, "result = GenerateHash(result) ^ _" + anAttribute.getName() + "[idx].GetHashCode();");
                    pw.println(indent + 2, "}");

	            pw.println(indent + 1, "}");
                    pw.println();
                }

                if (anAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.VARIABLE_LIST) {

                    if (anAttribute.getType().equalsIgnoreCase("OneByteChunk")) {
			//PES need to modify as onebytechunks are represented as byte[] therefore need to change code slightly
                        pw.println();
	
	                pw.println(indent + 1, "if(_" + anAttribute.getName() + ".Length > 0)");
			pw.println(indent + 1, "{");

                        pw.println(indent + 2, "for(int idx = 0; idx < _" + anAttribute.getName() + ".Length; idx++)");
                        pw.println(indent + 2, "{");
                        
                        pw.println(indent + 3, "result = GenerateHash(result) ^ _" + anAttribute.getName() + "[idx].GetHashCode();");
                        pw.println(indent + 2, "}");

 			pw.println(indent + 1, "}");
                        pw.println();

                    } else {
                        pw.println();
	
	                pw.println(indent + 1, "if(_" + anAttribute.getName() + ".Count > 0)");
			pw.println(indent + 1, "{");

                        pw.println(indent + 2, "for(int idx = 0; idx < _" + anAttribute.getName() + ".Count; idx++)");
                        pw.println(indent + 2, "{");
                        //PES 12102009 Do not believe this line is needed so commented out
			//pw.println(indent + 3, anAttribute.getType() + " x = (" + anAttribute.getType() + ")_" + anAttribute.getName() + "[idx];");
                        pw.println(indent + 3, "result = GenerateHash(result) ^ _" + anAttribute.getName() + "[idx].GetHashCode();");
                        pw.println(indent + 2, "}");

 			pw.println(indent + 1, "}");
                        pw.println();
		    }
                    
                }
            }
            pw.println();
            pw.println(indent + 1, "return result;");
            pw.println(indent, "}");




        } catch (Exception e) {
            System.out.println(e);
        }
    }

    /**
     * returns a string with the first letter capitalized. 
     */
    public String initialCap(String aString) {
        StringBuffer stb = new StringBuffer(aString);
        stb.setCharAt(0, Character.toUpperCase(aString.charAt(0)));

        return new String(stb);
    }

    public void postProcessData(PrintStringBuffer pw, GeneratedClass aClass) {
        //aClass.getName()

        if (aClass.getName().equalsIgnoreCase("VariableDatum")) {

            postProcessVariableDatum(pw);
        }

        if (aClass.getName().equalsIgnoreCase("SignalPdu")) {
            postProcessSignalPdu(pw);
        }
    }

    public void postProcessSignalPdu(PrintStringBuffer pw) {
        int startfind, endfind;
        String findString;
        String newString;

        findString = "_data = dis.readByteArray(_dataLength);";
        newString = "_data = dis.readByteArray((_dataLength / 8) + (_dataLength % 8 > 0 ? 1 : 0));  //09062009 Post processed. Needed to convert from bits to bytes";  //PES changed to reflex that the datalength should hold bits

        startfind = pw.sb.indexOf(findString);
        pw.sb.replace(startfind, startfind + findString.length(), newString);





        findString = "dos.writeShort((short)_data.Length);";
        newString = "dos.writeShort((short)((_dataLength == 0 && _data.Length > 0) ? _data.Length * 8 : _dataLength)); //09062009 Post processed.  If value is zero then default to every byte will use all 8 bits";  //09062009 PES changed to reflex that the datalength should be set by user and not automatically as this value is the number of bits in the data field that should be used

        startfind = pw.sb.indexOf(findString);
        pw.sb.replace(startfind, startfind + findString.length(), newString);


        findString = "/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.";

        newString = "/// This value must be set to the number of bits that will be used from the Data field.  Normally this value would be in increments of 8.  If this is the case then multiply the number of bytes used in the Data field by 8 and store that number here.";

        startfind = pw.sb.indexOf(findString);
        pw.sb.replace(startfind, startfind + 326, newString);

        ///Do this twice as there are two occurences
        startfind = pw.sb.indexOf(findString);
        pw.sb.replace(startfind, startfind + 326, newString);



    }

    public void postProcessVariableDatum(PrintStringBuffer pw) {
        ///String findString1 = "/// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
/// The getvariableDatumLength method will also be based on the actual list length rather than this value. 
/// The method is simply here for completeness and should not be used for any computations.

        int startfind, endfind;
        String findString;
        String newString;

        for (int i = 0; i < 2; i++) {
            startfind = pw.sb.indexOf("Note that");
            endfind = pw.sb.indexOf("for any computations.");
            pw.sb.replace(startfind, endfind + 21, "This value must be set for any PDU using it to work!" + pw.newline + "/// This value should be the number of bits used.");
        }

        startfind = pw.sb.indexOf("dos.writeUint((uint)_variableDatums.Count);");
        pw.sb.replace(startfind, startfind + 43, "dos.writeUint((uint)_variableDatumLength); //Post processed");

        findString = "_variableDatumLength = dis.readUint();";
        newString = pw.newline + "        int variableCount = (int)(_variableDatumLength / 64) + (_variableDatumLength % 64 > 0 ? 1 : 0);  //Post processed";
        startfind = pw.sb.indexOf(findString);
        pw.sb.insert(startfind + findString.length() + 1, newString);

        findString = "for(int idx = 0; idx < _variableDatumLength; idx++)";
        newString = "for(int idx = 0; idx < variableCount; idx++)";
        startfind = pw.sb.indexOf(findString);
        pw.sb.replace(startfind, startfind + findString.length(), newString);

    }

    private void writeLicenseNotice(PrintStringBuffer pw) {
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
        pw.println();

    }
}

/**
 * Created to do post processing of any changes
 */
class PrintStringBuffer {

    public StringBuilder sb = new StringBuilder();
    public static String newline = System.getProperty("line.separator");

    public PrintStringBuffer() {
    }

    public void print(int nrOfIndents, String s) {
        sb.append(getPaddingOfLength(nrOfIndents) + s);
    }

    public void print(String s) {
        sb.append(s);
    }

    public void println() {
        sb.append(newline);
    }

    private StringBuffer getPaddingOfLength(int pIndent) {
        StringBuffer buf = new StringBuffer();
        for (int i = 0; i < 4 * pIndent; i++) {
            buf.append(' ');
        }
        return buf;
    }

    public void println(String s) {
        sb.append(s + newline);
    }

    /**
     * Indents and prints a line including a newline
     * @param nrOfIndents Number of 4 space indents to use to indent the code
     * @param s line to print
     */
    public void println(int nrOfIndents, String s) {
        sb.append(getPaddingOfLength(nrOfIndents) + s + newline);
    }

    public String toString() {
        return sb.toString();
    }
}
