
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for FirstInfHighLevelUnit
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

        public enum FirstInfHighLevelUnit 
        {

     [Description("1-16INF")]
     X_1_16INF = 1,

     [Description("2-16INF")]
     X_2_16INF = 2,

     [Description("1-34AR")]
     X_1_34AR = 3,

     [Description("2-34AR")]
     X_2_34AR = 4,

     [Description("3-37AR")]
     X_3_37AR = 5,

     [Description("4-37AR")]
     X_4_37AR = 6,

     [Description("1-118INF")]
     X_1_118INF = 7,

     [Description("4-118INF")]
     X_4_118INF = 8,

     [Description("2-265AR")]
     X_2_265AR = 9,

     [Description("2-136IF")]
     X_2_136IF = 10,

     [Description("1-5F")]
     X_1_5F = 20,

     [Description("4-5F")]
     X_4_5F = 21,

     [Description("1-178F")]
     X_1_178F = 22,

     [Description("6F")]
     X_6F = 23,

     [Description("25F")]
     X_25F = 24,

     [Description("1E")]
     X_1E = 30,

     [Description("70E")]
     X_70E = 31,

     [Description("4-1AVN")]
     X_4_1AVN = 32,

     [Description("1-1AVN")]
     X_1_1AVN = 33,

     [Description("2-3ADA")]
     X_2_3ADA = 34,

     [Description("1-4CAV")]
     X_1_4CAV = 35,

     [Description("701MSB")]
     X_701MSB = 40,

     [Description("101FSB")]
     X_101FSB = 41,

     [Description("201FSB")]
     X_201FSB = 42,

     [Description("163FSB")]
     X_163FSB = 43,

     [Description("101MI")]
     X_101MI = 45,

     [Description("121S")]
     X_121S = 46,

     [Description("1MP")]
     X_1MP = 47,

     [Description("12CML")]
     X_12CML = 48,

     [Description("1INF")]
     X_1INF = 50,

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
