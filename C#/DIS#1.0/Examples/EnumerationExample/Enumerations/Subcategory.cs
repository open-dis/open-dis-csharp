
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for Subcategory
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

        public enum Subcategory 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Cavalry Troop")]
     CAVALRY_TROOP = 1,

     [Description("Armor")]
     ARMOR = 2,

     [Description("Infantry")]
     INFANTRY = 3,

     [Description("Mechanized Infantry")]
     MECHANIZED_INFANTRY = 4,

     [Description("Cavalry")]
     CAVALRY = 5,

     [Description("Armored Cavalry")]
     ARMORED_CAVALRY = 6,

     [Description("Artillery")]
     ARTILLERY = 7,

     [Description("Self-propelled Artillery")]
     SELF_PROPELLED_ARTILLERY = 8,

     [Description("Close Air Support")]
     CLOSE_AIR_SUPPORT = 9,

     [Description("Engineer")]
     ENGINEER = 10,

     [Description("Air Defense Artillery")]
     AIR_DEFENSE_ARTILLERY = 11,

     [Description("Anti-tank")]
     ANTI_TANK = 12,

     [Description("Army Aviation Fixed-wing")]
     ARMY_AVIATION_FIXED_WING = 13,

     [Description("Army Aviation Rotary-wing")]
     ARMY_AVIATION_ROTARY_WING = 14,

     [Description("Army Attack Helicopter")]
     ARMY_ATTACK_HELICOPTER = 15,

     [Description("Air Cavalry")]
     AIR_CAVALRY = 16,

     [Description("Armor Heavy Task Force")]
     ARMOR_HEAVY_TASK_FORCE = 17,

     [Description("Motorized Rifle")]
     MOTORIZED_RIFLE = 18,

     [Description("Mechanized Heavy Task Force")]
     MECHANIZED_HEAVY_TASK_FORCE = 19,

     [Description("Command Post")]
     COMMAND_POST = 20,

     [Description("CEWI")]
     CEWI = 21,

     [Description("Tank only")]
     TANK_ONLY = 22
     }

    } //End Parial Class

} //End Namespace
