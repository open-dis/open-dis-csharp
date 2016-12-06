
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for RestStatus
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

        public enum RestStatus 
        {

     [Description("Not rested (Has not slept in the last three days)")]
     NOT_RESTED_HAS_NOT_SLEPT_IN_THE_LAST_THREE_DAYS = 0,

     [Description("Has slept an average of 1 hour per day in the last three days.")]
     HAS_SLEPT_AN_AVERAGE_OF_1_HOUR_PER_DAY_IN_THE_LAST_THREE_DAYS = 1,

     [Description("Has slept an average of 2 hours per day in the last three days.")]
     HAS_SLEPT_AN_AVERAGE_OF_2_HOURS_PER_DAY_IN_THE_LAST_THREE_DAYS = 2,

     [Description("Has slept an average of 3 hours per day in the last three days.")]
     HAS_SLEPT_AN_AVERAGE_OF_3_HOURS_PER_DAY_IN_THE_LAST_THREE_DAYS = 3,

     [Description("Has slept an average of 4 hours per day in the last three days.")]
     HAS_SLEPT_AN_AVERAGE_OF_4_HOURS_PER_DAY_IN_THE_LAST_THREE_DAYS = 4,

     [Description("Has slept an average of 5 hours per day in the last three days.")]
     HAS_SLEPT_AN_AVERAGE_OF_5_HOURS_PER_DAY_IN_THE_LAST_THREE_DAYS = 5,

     [Description("Has slept an average of 6 hours per day in the last three days.")]
     HAS_SLEPT_AN_AVERAGE_OF_6_HOURS_PER_DAY_IN_THE_LAST_THREE_DAYS = 6,

     [Description("Has slept an average of 7 hours per day in the last three days.")]
     HAS_SLEPT_AN_AVERAGE_OF_7_HOURS_PER_DAY_IN_THE_LAST_THREE_DAYS = 7,

     [Description("Fully rested (Has slept an average of 8 hours per day in the last three days)")]
     FULLY_RESTED_HAS_SLEPT_AN_AVERAGE_OF_8_HOURS_PER_DAY_IN_THE_LAST_THREE_DAYS = 8
     }

    } //End Parial Class

} //End Namespace
