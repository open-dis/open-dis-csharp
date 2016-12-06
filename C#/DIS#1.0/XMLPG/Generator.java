package edu.nps.moves.xmlpg;

import java.io.*;
import java.util.*;

/**
 * Abstract superclass for all the concrete language generators, such as java, c++, etc.
 *
 * @author DMcG
 */

public abstract class Generator 
{
    /** Contains abstract descriptions of all the classes, key = name, value = object
    */
    protected HashMap classDescriptions;
    
    /** Directory in which to write the class code */
    protected String  directory;
    
    protected Properties languageProperties;
    
    /**
     * Constructor
     */
    public Generator(HashMap pClassDescriptions, String pDirectory, Properties pLanguageProperties)
    {
        classDescriptions = pClassDescriptions;
        directory = pDirectory;
        languageProperties = pLanguageProperties;
    }
    
    /**
     * Overridden by the subclasses to generate the code specific to that language.
     */
    public abstract void writeClasses();
    
    /**
     * Create the directory in which to put the generated source code files
     */
    protected void createDirectory()
    {
        System.out.println("creating directory");
        
        boolean success = (new File(directory)).mkdirs();
        
    }
    

}
