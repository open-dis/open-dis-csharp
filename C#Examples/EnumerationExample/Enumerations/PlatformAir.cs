
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for PlatformAir
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

        public enum PlatformAir 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Fighter/Air Defense")]
     FIGHTER_AIR_DEFENSE = 1,

     [Description("Attack/Strike")]
     ATTACK_STRIKE = 2,

     [Description("Bomber")]
     BOMBER = 3,

     [Description("Cargo/Tanker")]
     CARGO_TANKER = 4,

     [Description("ASW/Patrol/Observation")]
     ASW_PATROL_OBSERVATION = 5,

     [Description("Electronic Warfare (EW)")]
     ELECTRONIC_WARFARE_EW = 6,

     [Description("Reconnaissance")]
     RECONNAISSANCE = 7,

     [Description("Surveillance/C2 (Airborne Early Warning)")]
     SURVEILLANCE_C2_AIRBORNE_EARLY_WARNING = 8,

     [Description("Attack Helicopter")]
     ATTACK_HELICOPTER = 20,

     [Description("Utility Helicopter")]
     UTILITY_HELICOPTER = 21,

     [Description("Antisubmarine Warfare/Patrol Helicopter")]
     ANTISUBMARINE_WARFARE_PATROL_HELICOPTER = 22,

     [Description("Cargo Helicopter")]
     CARGO_HELICOPTER = 23,

     [Description("Observation Helicopter")]
     OBSERVATION_HELICOPTER = 24,

     [Description("Special Operations Helicopter")]
     SPECIAL_OPERATIONS_HELICOPTER = 25,

     [Description("Trainer")]
     TRAINER = 40,

     [Description("Unmanned")]
     UNMANNED = 50,

     [Description("Non-Combatant Commercial Aircraft")]
     NON_COMBATANT_COMMERCIAL_AIRCRAFT = 57
     }

    } //End Parial Class

} //End Namespace
