
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for SystemType
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

        public enum SystemType 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Mark X/XII/ATCRBS/Mode S Transponder")]
     MARK_X_XII_ATCRBS_MODE_S_TRANSPONDER = 1,

     [Description("Mark X/XII/ATCRBS/Mode S Interrogator")]
     MARK_X_XII_ATCRBS_MODE_S_INTERROGATOR = 2,

     [Description("Soviet Transponder")]
     SOVIET_TRANSPONDER = 3,

     [Description("Soviet Interrogator")]
     SOVIET_INTERROGATOR = 4,

     [Description("RRB Transponder")]
     RRB_TRANSPONDER = 5
     }

    } //End Parial Class

} //End Namespace
