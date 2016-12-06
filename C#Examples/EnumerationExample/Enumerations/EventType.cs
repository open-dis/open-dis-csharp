
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for EventType
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

        public enum EventType 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 1,

     [Description("Ran out of ammunition")]
     RAN_OUT_OF_AMMUNITION = 2,

     [Description("Killed in action")]
     KILLED_IN_ACTION = 3,

     [Description("Damage")]
     DAMAGE = 4,

     [Description("Mobility disabled")]
     MOBILITY_DISABLED = 5,

     [Description("Fire disabled")]
     FIRE_DISABLED = 6,

     [Description("Ran out of fuel")]
     RAN_OUT_OF_FUEL = 7,

     [Description("Entity initialization")]
     ENTITY_INITIALIZATION = 8,

     [Description("Request for indirect fire or CAS mission")]
     REQUEST_FOR_INDIRECT_FIRE_OR_CAS_MISSION = 9,

     [Description("Indirect fire or CAS fire")]
     INDIRECT_FIRE_OR_CAS_FIRE = 10,

     [Description("Minefield entry")]
     MINEFIELD_ENTRY = 11,

     [Description("Minefield detonation")]
     MINEFIELD_DETONATION = 12,

     [Description("Vehicle master power on")]
     VEHICLE_MASTER_POWER_ON = 13,

     [Description("Vehicle master power off")]
     VEHICLE_MASTER_POWER_OFF = 14,

     [Description("Aggregate state change requested")]
     AGGREGATE_STATE_CHANGE_REQUESTED = 15,

     [Description("Prevent Collision / Detonation")]
     PREVENT_COLLISION_DETONATION = 16
     }

    } //End Parial Class

} //End Namespace
