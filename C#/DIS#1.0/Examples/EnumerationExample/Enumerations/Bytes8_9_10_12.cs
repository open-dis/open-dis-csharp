
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for Bytes8_9_10_12
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

        public enum Bytes8_9_10_12 
        {

     [Description("0-9")]
     X_0_9 = 0,

     [Description("0-9")]
     X_0_9_1 = 10,

     [Description("E")]
     E = 69,

     [Description("Underscore E")]
     UNDERSCORE_E = 101,

     [Description("S")]
     S = 83,

     [Description("Underscore S")]
     UNDERSCORE_S = 115,

     [Description("X")]
     X = 88,

     [Description("Underscore X")]
     UNDERSCORE_X = 120,

     [Description("Blank")]
     BLANK = 32
     }

    } //End Parial Class

} //End Namespace
