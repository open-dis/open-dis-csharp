
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for FirstCavHighLevelUnit
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

        public enum FirstCavHighLevelUnit 
        {

     [Description("1-7CAV")]
     X_1_7CAV = 1,

     [Description("2-5CAV")]
     X_2_5CAV = 2,

     [Description("2-8CAV")]
     X_2_8CAV = 3,

     [Description("3-32AR")]
     X_3_32AR = 4,

     [Description("1-5CAV")]
     X_1_5CAV = 5,

     [Description("1-8CAV")]
     X_1_8CAV = 6,

     [Description("1-32AR")]
     X_1_32AR = 7,

     [Description("1-67AR")]
     X_1_67AR = 8,

     [Description("3-67AR")]
     X_3_67AR = 9,

     [Description("3-41INF")]
     X_3_41INF = 10,

     [Description("1-82F")]
     X_1_82F = 20,

     [Description("3-82F")]
     X_3_82F = 21,

     [Description("1-3F")]
     X_1_3F = 22,

     [Description("21F")]
     X_21F = 23,

     [Description("92F")]
     X_92F = 24,

     [Description("8E")]
     X_8E = 30,

     [Description("20E")]
     X_20E = 31,

     [Description("91E")]
     X_91E = 32,

     [Description("1-227AVN")]
     X_1_227AVN = 34,

     [Description("4-227AVN")]
     X_4_227AVN = 35,

     [Description("F-227AVN")]
     F_227AVN = 36,

     [Description("4-5ADA")]
     X_4_5ADA = 37,

     [Description("15MSB")]
     X_15MSB = 40,

     [Description("27FSB")]
     X_27FSB = 41,

     [Description("115FSB")]
     X_115FSB = 42,

     [Description("215FSB")]
     X_215FSB = 43,

     [Description("312MI")]
     X_312MI = 45,

     [Description("13S")]
     X_13S = 46,

     [Description("545MP")]
     X_545MP = 47,

     [Description("68CML")]
     X_68CML = 48,

     [Description("1CAV")]
     X_1CAV = 50,

     [Description("XBDE")]
     XBDE = 51,

     [Description("AVNBDE")]
     AVNBDE = 55,

     [Description("E")]
     E = 56,

     [Description("F")]
     F = 57,

     [Description("DSC")]
     DSC = 58
     }

    } //End Parial Class

} //End Namespace
