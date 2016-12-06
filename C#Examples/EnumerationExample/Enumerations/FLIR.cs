
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for FLIR
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

        public enum FLIR 
        {

     [Description("Generic 3-5")]
     GENERIC_3_5 = 0,

     [Description("Generic 8-12")]
     GENERIC_8_12 = 1,

     [Description("ASTAMIDS I")]
     ASTAMIDS_I = 2,

     [Description("ASTAMIDS II")]
     ASTAMIDS_II = 3,

     [Description("GSTAMIDS 3-5")]
     GSTAMIDS_3_5 = 4,

     [Description("GSTAMIDS 8-12")]
     GSTAMIDS_8_12 = 5,

     [Description("HSTAMIDS 3-5")]
     HSTAMIDS_3_5 = 6,

     [Description("HSTAMIDS 8-12")]
     HSTAMIDS_8_12 = 7,

     [Description("COBRA 3-5")]
     COBRA_3_5 = 8,

     [Description("COBRA 8-12")]
     COBRA_8_12 = 9
     }

    } //End Parial Class

} //End Namespace
