package edu.nps.moves.xmlpg;

import java.io.*;
import java.util.*;
import javax.xml.parsers.*;
import org.w3c.dom.*;
import org.xml.sax.*;
import org.xml.sax.helpers.*;

/**
 * A class that reads an XML file in a specific format, and spits out a Java or C++
 * class that does <i>most</i> of the work of the class.<p>
 *
 * This can probably be done via an XSLT, but the learning curve on that looks fairly
 * steep for the small, short-term project I'm working on. <p>
 *
 * There is a huge risk of 
 * name overloading here, as many of the terms such as "class" are also used
 * by java or c++. <p>
 *
 * In effect this is sort of like generating an abstract syntax tree, then
 * compiling it to some "target" language, in this case either C++ or Java.
 *
 * @author DMcG
 */
public class Xmlpg 
{
    /** Contains the database of all the classes described by the XML document */
    protected HashMap generatedClassNames = new HashMap();
    
    /** The language types we generate */
    public enum LanguageType {C, JAVA, CSHARP, OBJECTIVEC }
    
    /** As we parse the XML document, this is the class we are currently working on */
    private GeneratedClass currentGeneratedClass = null;
    
    /** As we parse the XML document, this is the current attribute */
    private ClassAttribute currentClassAttribute = null;
    
    /** Java properties--imports, packages, etc. */
    Properties javaProperties = new Properties();
    
    /** C++ properties--includes, etc. */
    Properties cppProperties = new Properties();
    
    //PES
	/** C# properties--using, namespace, etc. */
	Properties csharpProperties = new Properties();

    /** Objective-C properties */
    Properties objcProperties = new Properties();
    
    /** Hash table of all the primitive types we can use (short, long, byte, etc.)*/
    private HashSet primitiveTypes = new HashSet();
    
    /** Directory in which the java class package is created */
    private String javaDirectory = null;
    
    /** Directory in which the C++ classes are created */
    private String cppDirectory = null;
    
    //PES
	/** Directory in which the C# classes are created */
	private String csharpDirectory = null;

    /** Director in which the objc classes are created */
    private String objcDirectory = null;
   
    /**
     * Create a new collection of Java objects by reading an XML file; these
     * java objects can be used to generate code templates of any language,
     * once you write the translator.
     */
    public Xmlpg(String xmlDescriptionFileName, 
                 String pJavaDirectory,
                 String pCppDirectory,
                 String pCsharpDirectory,
                 String objcDirectory)
    {
        try
        {
            DefaultHandler handler = new MyHandler();
            
            SAXParserFactory factory = SAXParserFactory.newInstance();
            factory.setValidating(false);
            factory.newSAXParser().parse(new File(xmlDescriptionFileName), handler);
        }
        catch(Exception e)
        {
            System.out.println(e);
        }
        
        javaDirectory = pJavaDirectory;
        cppDirectory = pCppDirectory;
        //PES added for C#
		csharpDirectory = pCsharpDirectory;
        
        Iterator iterator = generatedClassNames.values().iterator();
        
        /*
        while(iterator.hasNext())
        {
            System.out.println(iterator.next());
        }
         */
        
        if(!this.astIsPlausible())
        {
            System.out.println("There are one or more errors in the XML file. See output for details.");
            System.exit(1);
        }
        
        System.out.println("putting java files in " + javaDirectory);
        
        // Create a new generator object to write out the source code for all the classes in java
        JavaGenerator javaGenerator = new JavaGenerator(generatedClassNames, javaDirectory, javaProperties );
        javaGenerator.writeClasses();
        
        // Use the same information to generate classes in C++
        CppGenerator cppGenerator = new CppGenerator(generatedClassNames, cppDirectory, cppProperties);
        cppGenerator.writeClasses();
        
        //PES added for C#
		// Create a new generator object to write out the source code for all the classes in csharp
		CsharpGenerator csharpGenerator = new CsharpGenerator(generatedClassNames, csharpDirectory, csharpProperties);
		csharpGenerator.writeClasses();

        // create a new generator object for objc
        ObjcGenerator objcGenerator = new ObjcGenerator(generatedClassNames, objcDirectory, objcProperties);
        objcGenerator.writeClasses();
    }
    
    /**
     * entry point. Pass in two arguments, the language you want to generate for and the XML file
     * that describes the classes
     */
    public static void main(String args[])
    {
        String language = null;
        
        if(args.length < 4) //PES changed to accomodate additional arg for C#
        {
			System.out.println("Usage: Xmlpg xmlFile javaDirectoryName cppDirectoryName csharpDirectoryName objcDirectoryName"); //PES modified to print out correct help
            System.exit(0);
        }
        
        // Should preflight the args here
		Xmlpg gen = new Xmlpg(args[0], args[1], args[2], args[3], args[4]); //PES added one more arg for C#
        
        
                
    } // end of main
    
    /**
     * Returns true if the information parsed from the protocol description XML file
     * is "plausible" in addition to being syntactically correct. This means that:
     * <ul>
     * <li>references to other classes in the file are correct; if a class attribute
     * refers to a "EntityID", there's a class by that name elsewhere in the document;
     * <li> The primitive types belong to a list of known correct primitive types,
     * eg short, unsigned short, etc
     *
     * AST is a reference to "abstract syntax tree", which this really isn't, but
     * sort of is.
     */
    private boolean astIsPlausible()
    {
        
        // Create a list of primitive types we can use to check against
        primitiveTypes.add("byte");
        primitiveTypes.add("short");
        primitiveTypes.add("int");
        primitiveTypes.add("long");
        primitiveTypes.add("unsigned byte");
        primitiveTypes.add("unsigned short");
        primitiveTypes.add("unsigned int");
		primitiveTypes.add("unsigned long");
        primitiveTypes.add("float");
        primitiveTypes.add("double");
        
        // trip through every class specified
        Iterator iterator = generatedClassNames.values().iterator();
        while(iterator.hasNext())
        {
            GeneratedClass aClass = (GeneratedClass)iterator.next();
            
            // Trip through every class attribute in this class and confirm that the type is either a primitive or references
            // another class defined in the document.
            List attribs = aClass.getClassAttributes();
            for(int idx = 0; idx < attribs.size(); idx++)
            {
                ClassAttribute anAttribute = (ClassAttribute)attribs.get(idx);
                
                ClassAttribute.ClassAttributeType kindOfNode = anAttribute.getAttributeKind();
                
                // The primitive type is on the known list of primitives.
                if(kindOfNode == ClassAttribute.ClassAttributeType.PRIMITIVE)
                {
                    if(primitiveTypes.contains(anAttribute.getType()) == false)
                    {
                        System.out.println("Cannot find a primitive type of " + anAttribute.getType());
                        return false;
                    }
                }
            
                // The class referenced is available elsewehere in the document
                if(kindOfNode == ClassAttribute.ClassAttributeType.CLASSREF)
                {
                    if(generatedClassNames.get(anAttribute.getType()) == null)
                    {
                        //System.out.println("Makes reference to a class of name " + anAttribute.getType() + " but no user-defined class of that type can be found in the document");
                        return false;
                    }
                    
                }
            } // end of trip through one class' attributes
            
            // Run through the list of initial values, ensuring that the initial values mentioned actually exist as attributes
            // somewhere up the inheritance chain.
            
            List initialValues = aClass.getInitialValues();
                       
            for(int idx = 0; idx < initialValues.size(); idx++)
            {
                InitialValue anInitialValue = (InitialValue)initialValues.get(idx);
                GeneratedClass currentClass = aClass;
                boolean found = false;
                
                //System.out.println("----Looking for matches of inital value " + anInitialValue.getVariable());
                while(currentClass != null)
                {
                    List thisClassesAttributes = currentClass.getClassAttributes();
                    for(int jdx = 0; jdx < thisClassesAttributes.size(); jdx++)
                    {
                        ClassAttribute anAttribute = (ClassAttribute)thisClassesAttributes.get(jdx);
                        //System.out.println("--checking " + anAttribute.getName() + " against inital value " + anInitialValue.getVariable());
                        if(anInitialValue.getVariable().equals(anAttribute.getName()))
                        {
                            found = true;
                            break;
                        }
                    }
                    currentClass = (GeneratedClass)generatedClassNames.get(currentClass.getParentClass());
                }
                if(!found)
                {
                    System.out.println("Could not find initial value matching attribute name for " + anInitialValue.getVariable() + " in class " + aClass.getName());
                }
                    
                    
                    
            } // end of for loop thorugh initial values

        } // End of trip through classes
        
        return true;
    } // end of astIsPlausible
    
    /**
     * inner class that handles the SAX parsing of the XML file. This is relatively simnple, if
     * a little verbose. Basically we just create the appropriate objects as we come across the
     * XML elements in the file.
     */
    public class MyHandler extends DefaultHandler
    {
        /** We've come across a start element
        */
        public void startElement(String uri, String localName, String qName, Attributes attributes)
        {
            // java element--place all the attributes and values into a property list
            if(qName.compareToIgnoreCase("java") == 0)
            {
                for(int idx = 0; idx < attributes.getLength(); idx++)
                {
                    javaProperties.setProperty(attributes.getQName(idx), attributes.getValue(idx));
                }
            }
            
            // c++ element--place all the attributes and values into a property list
            if(qName.compareToIgnoreCase("cpp") == 0)
            {
                for(int idx = 0; idx < attributes.getLength(); idx++)
                {
                    cppProperties.setProperty(attributes.getQName(idx), attributes.getValue(idx));
                }
            }

            // objc element--place all the attributes and values into a property list
            if(qName.compareToIgnoreCase("objc") == 0)
            {
                for(int idx = 0; idx < attributes.getLength(); idx++)
                {
                    objcProperties.setProperty(attributes.getQName(idx), attributes.getValue(idx));
                }
            }
            
            //PES added to pick up any attributes needed for Csharp
			// c# element--place all the attributes and values into a property list
			if (qName.compareToIgnoreCase("csharp") == 0)
			{
				for (int idx = 0; idx < attributes.getLength(); idx++)
				{
					csharpProperties.setProperty(attributes.getQName(idx), attributes.getValue(idx));
				}
			}
            
            
            // We've hit the start of a class element. Pick up the attributes of this (name, and any comments)
            // and then prepare for reading attributes.
            if(qName.compareToIgnoreCase("class") == 0)
            {
               
                currentGeneratedClass = new GeneratedClass();
                
                // The default is that this inherits from Object
                currentGeneratedClass.setParentClass("root");
                
                // Trip through all the attributes of the class tag
                for(int idx = 0; idx < attributes.getLength(); idx++)
                {
                    // class name
                    if(attributes.getQName(idx).compareToIgnoreCase("name") == 0)
                    {
                        currentGeneratedClass.setName(attributes.getValue(idx));
                        //System.out.println("in class " + attributes.getValue(idx));
                    }
                    
                    // Class comment
                    if(attributes.getQName(idx).compareToIgnoreCase("comment") == 0)
                    {
                        //System.out.println("comment is " + attributes.getValue(idx));
                        currentGeneratedClass.setComment(attributes.getValue(idx));
                    }
                    
                    // Inherits from
                    if(attributes.getQName(idx).compareToIgnoreCase("inheritsFrom") == 0)
                    {
                        //System.out.println("inherits from " + attributes.getValue(idx));
                        currentGeneratedClass.setParentClass(attributes.getValue(idx));
                    }
                    
                     // XML root element--used for marshalling to XML with JAXB
                    if(attributes.getQName(idx).equalsIgnoreCase("xmlRootElement"))
                    {
                        //System.out.println("is root element " + attributes.getValue(idx));
                        if(attributes.getValue(idx).equalsIgnoreCase("true"))
                        {
                            currentGeneratedClass.setXmlRootElement(true);
                        }
                        // by default it is false unless specified otherwise
                            
                    }
                    
                }
            }
            
            // We've hit an initial value element. This is used to initialize attributes in the
            // constructor. 
            if(qName.equalsIgnoreCase("initialValue"))
            {
                String anAttributeName = null;
                String anInitialValue = null;
                
                // Attributes on the initial value tag
                for(int idx = 0; idx < attributes.getLength(); idx++)
                {
                    // Name of class attribute
                    if(attributes.getQName(idx).compareToIgnoreCase("name") == 0)
                    {
                        anAttributeName = attributes.getValue(idx);
                        //System.out.println("in attribute " + attributes.getValue(idx));
                    }
                    
                    // Initial value
                    if(attributes.getQName(idx).compareToIgnoreCase("value") == 0)
                    {
                        anInitialValue = attributes.getValue(idx);
                    }
                }
                
                if((anAttributeName != null) && (anInitialValue != null))
                {
                    InitialValue aValue = new InitialValue(anAttributeName, anInitialValue);
                    currentGeneratedClass.addInitialValue(aValue);
                    //System.out.println("---Added intial value named " + anAttributeName + " in class " + currentGeneratedClass.getName());
                }
                
                
                
            }
            
            // We've hit an Attribute element. Read in the value, then the attributes associated
            // with it (name and comments).
            if(qName.compareToIgnoreCase("attribute") == 0)
            {
                currentClassAttribute = new ClassAttribute();
                
                // Attributes on the attribute tag.
                for(int idx = 0; idx < attributes.getLength(); idx++)
                {
                    // Name of class attribute
                    if(attributes.getQName(idx).compareToIgnoreCase("name") == 0)
                    {
                       // System.out.println("in attribute " + attributes.getValue(idx));
                        currentClassAttribute.setName(attributes.getValue(idx));
                    }
                    
                    // Comment on class attribute
                    if(attributes.getQName(idx).compareToIgnoreCase("comment") == 0)
                    {
                        //System.out.println("attribute comment:" + attributes.getValue(idx));
                        currentClassAttribute.setComment(attributes.getValue(idx));
                    }
                }
            }
            
            // We've hit a primitive description type. This may be either a simple primitive, or
            // nested inside of a list element. To trap this situation we check to see if the
            // attribute kind (primitive, classRef, list) has already been set. If so, we
            // leave it alone.
            
            if(qName.compareToIgnoreCase("primitive") == 0)
            {
               if(currentClassAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.UNSET)
               {
                   currentClassAttribute.setAttributeKind(ClassAttribute.ClassAttributeType.PRIMITIVE);
                   currentClassAttribute.setUnderlyingTypeIsPrimitive(true);
               }
               else
               {
                   currentClassAttribute.setUnderlyingTypeIsPrimitive(true);
               }
                
                for(int idx = 0; idx < attributes.getLength(); idx++)
                {
                    if(attributes.getQName(idx).equalsIgnoreCase("type"))
                    {
                        currentClassAttribute.setType(attributes.getValue(idx));
                    }
                    
                    if(attributes.getQName(idx).equalsIgnoreCase("defaultValue"))
                    {
                        currentClassAttribute.setDefaultValue(attributes.getValue(idx));
                    }
                }
            }
            
            // A reference to another class in the same document
            if(qName.compareToIgnoreCase("classRef") == 0)
            {
                // The classref may occur inside a List element; if that's the case, we want to 
                // respect the existing list type.
                if(currentClassAttribute.getAttributeKind() == ClassAttribute.ClassAttributeType.UNSET)
                {
                    currentClassAttribute.setAttributeKind(ClassAttribute.ClassAttributeType.CLASSREF);
                    currentClassAttribute.setUnderlyingTypeIsPrimitive(false);
                }
                
                
                for(int idx = 0; idx < attributes.getLength(); idx++)
                {
                    if(attributes.getQName(idx).compareToIgnoreCase("name") == 0)
                    {
                        currentClassAttribute.setType(attributes.getValue(idx));
                    }
                }
            }
            
            // A list element, of either fixed length (generally an array) or variable length (a list of some sort).
            if(qName.compareToIgnoreCase("list") == 0)
            {
                for(int idx = 0; idx < attributes.getLength(); idx++)
                {
                    //System.out.println("list attribute name: " + attributes.getQName(idx));
                    
                    if(attributes.getQName(idx).compareToIgnoreCase("type") == 0)
                    {
                        String listType = attributes.getValue(idx);
                        
                        if(listType.equalsIgnoreCase("fixed"))
                        {
                            currentClassAttribute.setAttributeKind(ClassAttribute.ClassAttributeType.FIXED_LIST);
                        }
                        if(listType.equalsIgnoreCase("variable"))
                        {
                            currentClassAttribute.setAttributeKind(ClassAttribute.ClassAttributeType.VARIABLE_LIST);
                        }
                    } // end of type
                    
                    // Variable list length fields require a name of another field that contains how many
                    // there are. This is used in unmarshalling.
                    if(attributes.getQName(idx).equalsIgnoreCase("countFieldName"))
                    {
                        currentClassAttribute.setCountFieldName(attributes.getValue(idx));
                        
                        // We also want to inform the attribute associated with countFieldName that
                        // it is keeping track of a list--this modifies the getter method and
                        // eliminates the setter method. This code assumes that the count field
                        // attribute has already been processed.
                        List ats = currentGeneratedClass.getClassAttributes();
                        boolean atFound = false;
                        
                        for(int jdx = 0; jdx < ats.size(); jdx++)
                        {
                            ClassAttribute at = (ClassAttribute)ats.get(jdx);
                            if(at.getName().equals(attributes.getValue(idx)))
                            {
                                at.setIsDynamicListLengthField(true);
                                at.setDynamicListClassAttribute(currentClassAttribute);
                                atFound = true;
                                break;
                            }
                        }
                        
                        if(atFound == false)
                        {
                            System.out.println("Could not find a matching attribute for the length field for " + attributes.getValue(idx));
                        }
                        
                    }
                    
                    if(attributes.getQName(idx).equalsIgnoreCase("couldBeString"))
                    {
                        String val = attributes.getValue(idx);
                        
                        if(val.equalsIgnoreCase("true"))
                           {
                              currentClassAttribute.setCouldBeString(true);  
                           }
                    }
                    
                    
                    if(attributes.getQName(idx).equalsIgnoreCase("length"))
                    {
                        String length = attributes.getValue(idx);
                        
                        try
                        {
                           int listLen = Integer.parseInt(length);
                            currentClassAttribute.setListLength(listLen);
                        }
                        catch(Exception e)
                        {
                            System.out.println("Invalid list length found. Bad format for integer " + length);
                            currentClassAttribute.setListLength(0);
                        }
                    } // end of attribute length
                } // End of element list
            }
           
        } // end of startElement
        
        public void endElement(String uri, String localName, String qName) 
        {
            // We've reached the end of a class element. The class should be complete; add it to the hash table.
            if(qName.compareToIgnoreCase("class") == 0)
            {
                generatedClassNames.put(currentGeneratedClass.getName(), currentGeneratedClass);
            }
            
            // Reached the end on an attribute. Add the attribute to whatever the current class is.
            if(qName.compareToIgnoreCase("attribute") == 0)
            {
                currentGeneratedClass.addClassAttribute(currentClassAttribute);
            }
        }
    }

}
