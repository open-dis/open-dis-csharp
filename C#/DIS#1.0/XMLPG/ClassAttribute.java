package edu.nps.moves.xmlpg;

/**
 * Represents one attribute of a class, ie an instance variable. this may be a 
 * primitive type, a class defined elsewhere in the document, a list, or an
 * array.
 *
 * @author DMcG
 */

public class ClassAttribute 
{
    /**
     * The various things an attribute can be: a primitive type (int, short, byte, etc), 
     * a reference to another class defined in this document, a list of fixed length, aka
     * an array, or a list of variable length, 
     */
    public enum ClassAttributeType { UNSET, PRIMITIVE, CLASSREF, FIXED_LIST, VARIABLE_LIST };
    
    /** Name of this attribute, winds up as the ivar name */
    protected String name;
    
    /** What attribute class this is: primitive, list, array, etc */
    protected ClassAttributeType attributeKind = ClassAttributeType.UNSET;
    
    /** the type of the attribute: a short, class, etc. */
    protected String type;
    
    /** Comment, can be carried over to the source code generated */
    String comment;
    
    /** Used only if this is a list attibute */
    protected int listLength = 0;
    
    /** If this is a variable list length field, when unmarshalling we need to know how many
     * to unmarshal. This is the name of the filed that contains that count.
     */
    protected String countFieldName;
    
    /** If this is a primitive type (specifically some sort of integer) we may be the count
     * field for a variable length list. If that's the case, the getter method is different,
     * and there is no setter method. Instead we simply use the current actual length of
     * the dynamic list.
     */
    protected boolean isDynamicListLengthField = false;
    
    /** If this is a dynamic length list field, we also need the field that this tells the 
     * length for.
     */
    protected ClassAttribute dynamicListClassAttribute = null;
    
    /**
     * The default value for this attribute if it is a primitive.
     */
    protected String defaultValue = null;
    
    /** If this is a list of some sort, this is true if the list consists of primitives, false if the list 
     * consists of classes
     */
    protected boolean underlyingTypeIsPrimitive = false;
    
    /** If this is a list of some sort, this is true if the list consists of class references, false if the list 
     * consists of primitives
     */
    protected boolean underlyingTypeIsClass = false;
    
    /** Some fields, such as Marking, could have arrays that are treated a C strings. At least on the set
     *  method, if we pass in an array we can have an alternate method that treats the input string as
     * a c-style string, with a terminating null character. This is not strictly compliant with the DIS
     * standard, which makes no assumptions about null-terminated strings, but it happens often enough
     * in the C world to special case it.
     */
    protected boolean couldBeString = false;
    
    /** Get the name of the class attribute/iname*/
    public String getName()
    {
        return name;
    }
    
    public void setName(String pName)
    {
        name = pName;
    }
   
    /** get the kind of the attribute (primitive, list, array, etc. */
    public ClassAttributeType getAttributeKind()
    {
        return attributeKind;
    }
    
    public void setAttributeKind(ClassAttributeType pKind)
    {
        attributeKind = pKind;
    }
    
    /** Get the type of the field */
    public String getType()
    {
        return type;
    }
    
    public void setType(String pType)
    {
        type = pType;
    }
    
    /** Comment */
    public String getComment()
    {
        return comment;
    }
    
    public void setComment(String pComment)
    {
        comment = pComment;
    }
    
    public void setListLength(int pListLength)
    {
        listLength = pListLength;
    }
    public int getListLength()
    {
        return listLength;
    }
    
    public String getCountFieldName()
    {
        return countFieldName;
    }
    
    public void setCountFieldName(String pFieldName)
    {
        countFieldName = pFieldName;
    }
    
    /** 
     * Returns true if 1) this is a list,  either fixed or variable, and 2) contains a class
     */
    public boolean listIsClass()
    {
        if(! ((attributeKind == ClassAttributeType.FIXED_LIST) || (attributeKind == ClassAttributeType.VARIABLE_LIST)))
            return false;
        
        if(underlyingTypeIsPrimitive)
            return false;
        
        return true;
    }
    
    /**
     * Set the default value for a primitive type 
     */
    public String getDefaultValue()
    {
        return defaultValue;
    }
    
    /** 
     * Return the default value for a primitive type
     */
    public void setDefaultValue(String pValue)
    {
        defaultValue = pValue;
    }
    
    /**
     * sets true if the underlying type of a list is a primitive, false if it is a class
     */
    public void setUnderlyingTypeIsPrimitive(boolean newValue)
    {
        underlyingTypeIsPrimitive = newValue;
    }
    
    /**
     * returns true if this is a list and the underlying type is a primitive, false if it is a class
     */
    public boolean getUnderlyingTypeIsPrimitive()
    {
        return underlyingTypeIsPrimitive;
    }
    
    public boolean getCouldBeString()
    {
        return couldBeString;
    }
    
    public void setCouldBeString(boolean couldBeString)
    {
        this.couldBeString = couldBeString;
    }
    
    public void setIsDynamicListLengthField(boolean flag)
    {
        isDynamicListLengthField = flag;
    }
    
    public boolean getIsDynamicListLengthField()
    {
        return isDynamicListLengthField;
    }
    
    public void setDynamicListClassAttribute(ClassAttribute attr)
    {
        dynamicListClassAttribute = attr;
    }
    
    public ClassAttribute getDynamicListClassAttribute()
    {
        return dynamicListClassAttribute;
    }
}
