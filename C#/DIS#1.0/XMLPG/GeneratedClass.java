package edu.nps.moves.xmlpg;

import java.util.*;

/**
 * Represents one generated class. A generated class has a series of attributes, the
 * order of which is significant. These attributes are used to create instance 
 * variables, getters and setters, and serialization code.
 *
 * @author DMcG
 */

public class GeneratedClass 
{
    /** A list of all the attributes (ivars) of one class */
    protected List classAttributes = new ArrayList();
    
    /** A list of attribute names and initial values for those attributes. */
    protected List initialValues = new ArrayList();
    
    /** comments for this generated class */
    private String comment;
    
    /** Name of generated class */
    protected String name;
    
    /** parent class */
    protected String parentClass;
    
    /** Whether this is an XmlRootElement; used only with XML marshalling */
    protected boolean xmlRootElement = false;
    
    /** Constructor */
    public GeneratedClass()
    {
        
    }
    
    public void setParentClass(String pParentClass)
    {
        parentClass = pParentClass;
    }
    
    public String getParentClass()
    {
        return parentClass;
    }
    
    public String getName()
    {
        return name;
    }
    
    public void setName(String pName)
    {
        name = pName;
    }
    
    /** Add one ivar/attribute to the class */
    public void addClassAttribute(ClassAttribute anAttribute)
    {
        classAttributes.add(anAttribute);
    }
    
    /** Return a list of all the attributes of the class */
    public List getClassAttributes()
    {
        return classAttributes;
    }
    
    /** Add one initial value to the class */
    public void addInitialValue(InitialValue anInitialValue)
    {
        initialValues.add(anInitialValue);
    }
    
    /** Return a list of all the initial values of the class */
    public List getInitialValues()
    {
        return initialValues;
    }
    
    /** Set the comments associated with this class */
    public void setComment(String comments)
    {
        comment = comments;
    }
    
    
    
    /** get the comments associated with this class */
    public String getClassComments()
    {
        return comment;
    }
    
    public String toString()
    {
        String result = new String();
        
        result = "Name: " + name + "\n" + "Comment: " + comment + "\n";
        
        for(int idx = 0; idx < classAttributes.size(); idx++)
        {
            ClassAttribute attribute = (ClassAttribute)classAttributes.get(idx);
            String anAttribute = "  Name: " + attribute.getName() + " Comment: " + attribute.getComment() + 
                                 " Kind: " + attribute.getAttributeKind() + " Type:" + attribute.getType() + "\n";
            result = result + anAttribute;
        }
        return result;
    }

    public boolean isXmlRootElement()
    {
        return xmlRootElement;
    }

    public void setXmlRootElement(boolean isXmlRootElement)
    {
        this.xmlRootElement = isXmlRootElement;
    }

}
