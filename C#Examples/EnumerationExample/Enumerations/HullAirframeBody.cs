
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for HullAirframeBody
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

        public enum HullAirframeBody 
        {

     [Description("hull")]
     HULL = 1000,

     [Description("airframe")]
     AIRFRAME = 1010,

     [Description("truck body")]
     TRUCK_BODY = 1020,

     [Description("tank body")]
     TANK_BODY = 1030,

     [Description("trailer body")]
     TRAILER_BODY = 1040,

     [Description("turret")]
     TURRET = 1050,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 1060
     }

    } //End Parial Class

} //End Namespace
