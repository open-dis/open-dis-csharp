
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for GroupedEntityCategory
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

        public enum GroupedEntityCategory 
        {

     [Description("Undefined")]
     UNDEFINED = 0,

     [Description("Basic Ground Combat Vehicle")]
     BASIC_GROUND_COMBAT_VEHICLE = 1,

     [Description("Enhanced Ground Combat Vehicle")]
     ENHANCED_GROUND_COMBAT_VEHICLE = 2,

     [Description("Basic Ground Combat Soldier")]
     BASIC_GROUND_COMBAT_SOLDIER = 3,

     [Description("Enhanced Ground Combat Soldier")]
     ENHANCED_GROUND_COMBAT_SOLDIER = 4,

     [Description("Basic Rotor Wing Aircraft")]
     BASIC_ROTOR_WING_AIRCRAFT = 5,

     [Description("Enhanced Rotor Wing Aircraft")]
     ENHANCED_ROTOR_WING_AIRCRAFT = 6,

     [Description("Basic Fixed Wing Aircraft")]
     BASIC_FIXED_WING_AIRCRAFT = 7,

     [Description("Enhanced Fixed Wing Aircraft")]
     ENHANCED_FIXED_WING_AIRCRAFT = 8,

     [Description("Ground Logistics Vehicle")]
     GROUND_LOGISTICS_VEHICLE = 9
     }

    } //End Parial Class

} //End Namespace
