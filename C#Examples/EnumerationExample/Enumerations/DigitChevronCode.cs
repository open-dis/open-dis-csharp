
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for DigitChevronCode
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

        public enum DigitChevronCode 
        {

     [Description("0-9")]
     X_0_9 = 0,

     [Description("Underscore 0-9")]
     UNDERSCORE_0_9 = 10,

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
     BLANK = 32,

     [Description("^")]
     _CARET_ = 94,

     [Description(">")]
     _GT_ = 62,

     [Description("inverted carrot")]
     INVERTED_CARROT = 86,

     [Description("<")]
     _LT_ = 60,

     [Description("^ and inverted carrot")]
     _CARET_AND_INVERTED_CARROT = 126,

     [Description("< >")]
     _LT_GT_ = 61
     }

    } //End Parial Class

} //End Namespace
