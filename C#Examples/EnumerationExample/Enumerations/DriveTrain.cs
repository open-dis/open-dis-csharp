
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for DriveTrain
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

        public enum DriveTrain 
        {

     [Description("motor / engine")]
     MOTOR_ENGINE = 10,

     [Description("starter")]
     STARTER = 20,

     [Description("alternator")]
     ALTERNATOR = 30,

     [Description("generator")]
     GENERATOR = 40,

     [Description("battery")]
     BATTERY = 50,

     [Description("engine-coolant leak")]
     ENGINE_COOLANT_LEAK = 60,

     [Description("fuel filter")]
     FUEL_FILTER = 70,

     [Description("transmission-oil leak")]
     TRANSMISSION_OIL_LEAK = 80,

     [Description("engine-oil leak")]
     ENGINE_OIL_LEAK = 90,

     [Description("pumps")]
     PUMPS = 100,

     [Description("filters")]
     FILTERS = 110,

     [Description("transmission")]
     TRANSMISSION = 120,

     [Description("brakes")]
     BRAKES = 130,

     [Description("suspension system")]
     SUSPENSION_SYSTEM = 140,

     [Description("oil filter")]
     OIL_FILTER = 150,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 160
     }

    } //End Parial Class

} //End Namespace
