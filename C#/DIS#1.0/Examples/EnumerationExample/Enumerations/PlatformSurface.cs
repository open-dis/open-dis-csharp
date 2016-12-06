
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for PlatformSurface
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

        public enum PlatformSurface 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Carrier")]
     CARRIER = 1,

     [Description("Command Ship/Cruiser")]
     COMMAND_SHIP_CRUISER = 2,

     [Description("Guided Missile Cruiser")]
     GUIDED_MISSILE_CRUISER = 3,

     [Description("Guided Missile Destroyer (DDG)")]
     GUIDED_MISSILE_DESTROYER_DDG = 4,

     [Description("Destroyer (DD)")]
     DESTROYER_DD = 5,

     [Description("Guided Missile Frigate (FFG)")]
     GUIDED_MISSILE_FRIGATE_FFG = 6,

     [Description("Light/Patrol Craft")]
     LIGHT_PATROL_CRAFT = 7,

     [Description("Mine Countermeasure Ship/Craft")]
     MINE_COUNTERMEASURE_SHIP_CRAFT = 8,

     [Description("Dock Landing Ship")]
     DOCK_LANDING_SHIP = 9,

     [Description("Tank Landing Ship")]
     TANK_LANDING_SHIP = 10,

     [Description("Landing Craft")]
     LANDING_CRAFT = 11,

     [Description("Light Carrier")]
     LIGHT_CARRIER = 12,

     [Description("Cruiser/Helicopter Carrier")]
     CRUISER_HELICOPTER_CARRIER = 13,

     [Description("Hydrofoil")]
     HYDROFOIL = 14,

     [Description("Air Cushion/Surface Effect")]
     AIR_CUSHION_SURFACE_EFFECT = 15,

     [Description("Auxiliary")]
     AUXILIARY = 16,

     [Description("Auxiliary, Merchant Marine")]
     AUXILIARY_MERCHANT_MARINE = 17,

     [Description("Utility")]
     UTILITY = 18,

     [Description("Frigate (including Corvette)")]
     FRIGATE_INCLUDING_CORVETTE = 50,

     [Description("Battleship")]
     BATTLESHIP = 51,

     [Description("Heavy Cruiser")]
     HEAVY_CRUISER = 52,

     [Description("Destroyer Tender")]
     DESTROYER_TENDER = 53,

     [Description("Amphibious Assault Ship")]
     AMPHIBIOUS_ASSAULT_SHIP = 54,

     [Description("Amphibious Cargo Ship")]
     AMPHIBIOUS_CARGO_SHIP = 55,

     [Description("Amphibious Transport Dock")]
     AMPHIBIOUS_TRANSPORT_DOCK = 56,

     [Description("Ammunition Ship")]
     AMMUNITION_SHIP = 57,

     [Description("Combat Stores Ship")]
     COMBAT_STORES_SHIP = 58,

     [Description("Surveillance Towed Array Sonar System (SURTASS)")]
     SURVEILLANCE_TOWED_ARRAY_SONAR_SYSTEM_SURTASS = 59,

     [Description("Fast Combat Support Ship")]
     FAST_COMBAT_SUPPORT_SHIP = 60,

     [Description("Non-Combatant Ship")]
     NON_COMBATANT_SHIP = 61,

     [Description("Coast Guard Cutters")]
     COAST_GUARD_CUTTERS = 62,

     [Description("Coast Guard Boats")]
     COAST_GUARD_BOATS = 63
     }

    } //End Parial Class

} //End Namespace
