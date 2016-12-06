
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for DetonationResult
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

        public enum DetonationResult 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Entity Impact")]
     ENTITY_IMPACT = 1,

     [Description("Entity Proximate Detonation")]
     ENTITY_PROXIMATE_DETONATION = 2,

     [Description("Ground Impact")]
     GROUND_IMPACT = 3,

     [Description("Ground Proximate Detonation")]
     GROUND_PROXIMATE_DETONATION = 4,

     [Description("Detonation")]
     DETONATION = 5,

     [Description("None or No Detonation (Dud)")]
     NONE_OR_NO_DETONATION_DUD = 6,

     [Description("HE hit, small")]
     HE_HIT_SMALL = 7,

     [Description("HE hit, medium")]
     HE_HIT_MEDIUM = 8,

     [Description("HE hit, large")]
     HE_HIT_LARGE = 9,

     [Description("Armor-piercing hit")]
     ARMOR_PIERCING_HIT = 10,

     [Description("Dirt blast, small")]
     DIRT_BLAST_SMALL = 11,

     [Description("Dirt blast, medium")]
     DIRT_BLAST_MEDIUM = 12,

     [Description("Dirt blast, large")]
     DIRT_BLAST_LARGE = 13,

     [Description("Water blast, small")]
     WATER_BLAST_SMALL = 14,

     [Description("Water blast, medium")]
     WATER_BLAST_MEDIUM = 15,

     [Description("Water blast, large")]
     WATER_BLAST_LARGE = 16,

     [Description("Air hit")]
     AIR_HIT = 17,

     [Description("Building hit, small")]
     BUILDING_HIT_SMALL = 18,

     [Description("Building hit, medium")]
     BUILDING_HIT_MEDIUM = 19,

     [Description("Building hit, large")]
     BUILDING_HIT_LARGE = 20,

     [Description("Mine-clearing line charge")]
     MINE_CLEARING_LINE_CHARGE = 21,

     [Description("Environment object impact")]
     ENVIRONMENT_OBJECT_IMPACT = 22,

     [Description("Environment object proximate detonation")]
     ENVIRONMENT_OBJECT_PROXIMATE_DETONATION = 23,

     [Description("Water Impact")]
     WATER_IMPACT = 24,

     [Description("Air Burst")]
     AIR_BURST = 25,

     [Description("Kill with fragment type 1")]
     KILL_WITH_FRAGMENT_TYPE_1 = 26,

     [Description("Kill with fragment type 2")]
     KILL_WITH_FRAGMENT_TYPE_2 = 27,

     [Description("Kill with fragment type 3")]
     KILL_WITH_FRAGMENT_TYPE_3 = 28,

     [Description("Kill with fragment type 1 after fly-out failure")]
     KILL_WITH_FRAGMENT_TYPE_1_AFTER_FLY_OUT_FAILURE = 29,

     [Description("Kill with fragment type 2 after fly-out failure")]
     KILL_WITH_FRAGMENT_TYPE_2_AFTER_FLY_OUT_FAILURE = 30,

     [Description("Miss due to fly-out failure")]
     MISS_DUE_TO_FLY_OUT_FAILURE = 31,

     [Description("Miss due to end-game failure")]
     MISS_DUE_TO_END_GAME_FAILURE = 32,

     [Description("Miss due to fly-out and end-game failure")]
     MISS_DUE_TO_FLY_OUT_AND_END_GAME_FAILURE = 33
     }

    } //End Parial Class

} //End Namespace
