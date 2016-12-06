
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for ForceID
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

        public enum ForceID 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Friendly")]
     FRIENDLY = 1,

     [Description("Opposing")]
     OPPOSING = 2,

     [Description("Neutral")]
     NEUTRAL = 3,

     [Description("Friendly 2")]
     FRIENDLY_2 = 4,

     [Description("Opposing 2")]
     OPPOSING_2 = 5,

     [Description("Neutral 2")]
     NEUTRAL_2 = 6,

     [Description("Friendly 3")]
     FRIENDLY_3 = 7,

     [Description("Opposing 3")]
     OPPOSING_3 = 8,

     [Description("Neutral 3")]
     NEUTRAL_3 = 9,

     [Description("Friendly 4")]
     FRIENDLY_4 = 10,

     [Description("Opposing 4")]
     OPPOSING_4 = 11,

     [Description("Neutral 4")]
     NEUTRAL_4 = 12,

     [Description("Friendly 5")]
     FRIENDLY_5 = 13,

     [Description("Opposing 5")]
     OPPOSING_5 = 14,

     [Description("Neutral 5")]
     NEUTRAL_5 = 15,

     [Description("Friendly 6")]
     FRIENDLY_6 = 16,

     [Description("Opposing 6")]
     OPPOSING_6 = 17,

     [Description("Neutral 6")]
     NEUTRAL_6 = 18,

     [Description("Friendly 7")]
     FRIENDLY_7 = 19,

     [Description("Opposing 7")]
     OPPOSING_7 = 20,

     [Description("Neutral 7")]
     NEUTRAL_7 = 21,

     [Description("Friendly 8")]
     FRIENDLY_8 = 22,

     [Description("Opposing 8")]
     OPPOSING_8 = 23,

     [Description("Neutral 8")]
     NEUTRAL_8 = 24,

     [Description("Friendly 9")]
     FRIENDLY_9 = 25,

     [Description("Opposing 9")]
     OPPOSING_9 = 26,

     [Description("Neutral 9")]
     NEUTRAL_9 = 27,

     [Description("Friendly 10")]
     FRIENDLY_10 = 28,

     [Description("Opposing 10")]
     OPPOSING_10 = 29,

     [Description("Neutral 10")]
     NEUTRAL_10 = 30
     }

    } //End Parial Class

} //End Namespace
