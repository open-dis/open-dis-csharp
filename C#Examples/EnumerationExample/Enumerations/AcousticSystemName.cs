
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for AcousticSystemName
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

        public enum AcousticSystemName 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("AN/BQQ-5")]
     AN_BQQ_5 = 1,

     [Description("AN/SSQ-62")]
     AN_SSQ_62 = 2,

     [Description("AN/SQS-23")]
     AN_SQS_23 = 3,

     [Description("AN/SQS-26")]
     AN_SQS_26 = 4,

     [Description("AN/SQS-53")]
     AN_SQS_53 = 5,

     [Description("ALFS")]
     ALFS = 6,

     [Description("LFA")]
     LFA = 7,

     [Description("AN/AQS-901")]
     AN_AQS_901 = 8,

     [Description("AN/AQS-902")]
     AN_AQS_902 = 9
     }

    } //End Parial Class

} //End Namespace
