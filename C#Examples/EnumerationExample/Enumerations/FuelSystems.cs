
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for FuelSystems
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

        public enum FuelSystems 
        {

     [Description("fuel transfer pump")]
     FUEL_TRANSFER_PUMP = 4000,

     [Description("fuel lines")]
     FUEL_LINES = 4010,

     [Description("gauges")]
     GAUGES = 4020,

     [Description("general fuel system")]
     GENERAL_FUEL_SYSTEM = 4030,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 4031
     }

    } //End Parial Class

} //End Namespace
