
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for Nature
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

        public enum Nature 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Host-fireable munition")]
     HOST_FIREABLE_MUNITION = 1,

     [Description("Munition carried as cargo")]
     MUNITION_CARRIED_AS_CARGO = 2,

     [Description("Fuel carried as cargo")]
     FUEL_CARRIED_AS_CARGO = 3,

     [Description("Gunmount attached to host")]
     GUNMOUNT_ATTACHED_TO_HOST = 4,

     [Description("Computer generated forces carried as cargo")]
     COMPUTER_GENERATED_FORCES_CARRIED_AS_CARGO = 5,

     [Description("Vehicle carried as cargo")]
     VEHICLE_CARRIED_AS_CARGO = 6,

     [Description("Emitter mounted on host")]
     EMITTER_MOUNTED_ON_HOST = 7,

     [Description("Mobile command and control entity carried aboard host")]
     MOBILE_COMMAND_AND_CONTROL_ENTITY_CARRIED_ABOARD_HOST = 8,

     [Description("Entity stationed at position with respect to host")]
     ENTITY_STATIONED_AT_POSITION_WITH_RESPECT_TO_HOST = 9,

     [Description("Team member in formation with")]
     TEAM_MEMBER_IN_FORMATION_WITH = 10
     }

    } //End Parial Class

} //End Namespace
