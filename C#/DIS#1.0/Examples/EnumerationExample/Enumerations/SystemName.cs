
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for SystemName
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

        public enum SystemName 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Mark X")]
     MARK_X = 1,

     [Description("Mark XII")]
     MARK_XII = 2,

     [Description("ATCRBS")]
     ATCRBS = 3,

     [Description("Soviet")]
     SOVIET = 4,

     [Description("Mode S")]
     MODE_S = 5,

     [Description("Mark X/XII/ATCRBS")]
     MARK_X_XII_ATCRBS = 6,

     [Description("Mark X/XII/ATCRBS/Mode S")]
     MARK_X_XII_ATCRBS_MODE_S = 7,

     [Description("ARI 5954")]
     ARI_5954 = 8,

     [Description("ARI 5983")]
     ARI_5983 = 9
     }

    } //End Parial Class

} //End Namespace
