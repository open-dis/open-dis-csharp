
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for InputSource
 * The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
 * obtained from http://discussions.sisostds.org/default.asp?action=10&fd=31<p>
 *
 * Note that this has two ways to look up an enumerated instance from a value: a fast
 * but brittle array lookup, and a slower and more garbage-intensive, but safer, method.
 * if you want to minimize memory use, get rid of one or the other.<p>
 *
 * Copyright 2008-2009. This work is licensed under the BSD license, available at
 * http://www.movesinstitute.org/licenses<p>
 *
 * @author DMcG, Jason Nelson
 * Modified for use with C#:
 * Peter Smith (Naval Air Warfare Center - Training Systems Division)
 */

namespace DISnet 
{

    public partial class DISEnumerations
    {

        public enum InputSource 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Pilot")]
     PILOT = 1,

     [Description("Copilot")]
     COPILOT = 2,

     [Description("First Officer")]
     FIRST_OFFICER = 3,

     [Description("Driver")]
     DRIVER = 4,

     [Description("Loader")]
     LOADER = 5,

     [Description("Gunner")]
     GUNNER = 6,

     [Description("Commander")]
     COMMANDER = 7,

     [Description("Digital Data Device")]
     DIGITAL_DATA_DEVICE = 8,

     [Description("Intercom")]
     INTERCOM = 9
     }

    } //End Parial Class

} //End Namespace
