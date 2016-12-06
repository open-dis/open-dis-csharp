
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for PlatformLand
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

        public enum PlatformLand 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Tank")]
     TANK = 1,

     [Description("Armored Fighting Vehicle - (IFV, APC, SP mortars, armored cars, chemical reconnaissance, anti-tank guided missile launchers, etc.)")]
     ARMORED_FIGHTING_VEHICLE_IFV_APC_SP_MORTARS_ARMORED_CARS_CHEMICAL_RECONNAISSANCE_ANTI_TANK_GUIDED_MISSILE_LAUNCHERS_ETC = 2,

     [Description("Armored Utility Vehicle - (Engineering vehicle, tracked load carriers, towing vehicles, recovery vehicles, AVLB, etc.)")]
     ARMORED_UTILITY_VEHICLE_ENGINEERING_VEHICLE_TRACKED_LOAD_CARRIERS_TOWING_VEHICLES_RECOVERY_VEHICLES_AVLB_ETC = 3,

     [Description("Self-propelled Artillery - (guns and howitzers)")]
     SELF_PROPELLED_ARTILLERY_GUNS_AND_HOWITZERS = 4,

     [Description("Towed Artillery - (anti-tank guns, guns and howitzers)")]
     TOWED_ARTILLERY_ANTI_TANK_GUNS_GUNS_AND_HOWITZERS = 5,

     [Description("Small Wheeled Utility Vehicle - (0-1.25 tons)")]
     SMALL_WHEELED_UTILITY_VEHICLE_0_125_TONS = 6,

     [Description("Large Wheeled Utility Vehicle - (greater than 1.25 tons)")]
     LARGE_WHEELED_UTILITY_VEHICLE_GREATER_THAN_125_TONS = 7,

     [Description("Small Tracked Utility Vehicle - (0-4999 kg weight load)")]
     SMALL_TRACKED_UTILITY_VEHICLE_0_4999_KG_WEIGHT_LOAD = 8,

     [Description("Large Tracked Utility Vehicle - (greater than 4999 kg weight load)")]
     LARGE_TRACKED_UTILITY_VEHICLE_GREATER_THAN_4999_KG_WEIGHT_LOAD = 9,

     [Description("Mortar")]
     MORTAR = 10,

     [Description("Mine plow")]
     MINE_PLOW = 11,

     [Description("Mine rake")]
     MINE_RAKE = 12,

     [Description("Mine roller")]
     MINE_ROLLER = 13,

     [Description("Cargo trailer")]
     CARGO_TRAILER = 14,

     [Description("Fuel trailer")]
     FUEL_TRAILER = 15,

     [Description("Generator trailer")]
     GENERATOR_TRAILER = 16,

     [Description("Water trailer")]
     WATER_TRAILER = 17,

     [Description("Engineer equipment")]
     ENGINEER_EQUIPMENT = 18,

     [Description("Heavy equipment transport trailer")]
     HEAVY_EQUIPMENT_TRANSPORT_TRAILER = 19,

     [Description("Maintenance equipment trailer")]
     MAINTENANCE_EQUIPMENT_TRAILER = 20,

     [Description("Limber")]
     LIMBER = 21,

     [Description("Chemical decontamination trailer")]
     CHEMICAL_DECONTAMINATION_TRAILER = 22,

     [Description("Warning System")]
     WARNING_SYSTEM = 23,

     [Description("Train - Engine")]
     TRAIN_ENGINE = 24,

     [Description("Train - Car")]
     TRAIN_CAR = 25,

     [Description("Train - Caboose")]
     TRAIN_CABOOSE = 26,

     [Description("Civilian Vehicle")]
     CIVILIAN_VEHICLE = 27,

     [Description("Air Defense / Missile Defense Unit Equipment")]
     AIR_DEFENSE_MISSILE_DEFENSE_UNIT_EQUIPMENT = 28,

     [Description("Command, Control, Communications, and Intelligence (C3I) System")]
     COMMAND_CONTROL_COMMUNICATIONS_AND_INTELLIGENCE_C3I_SYSTEM = 29,

     [Description("Operations Facility")]
     OPERATIONS_FACILITY = 30,

     [Description("Intelligence Facility")]
     INTELLIGENCE_FACILITY = 31,

     [Description("Surveillance Facility")]
     SURVEILLANCE_FACILITY = 32,

     [Description("Communications Facility")]
     COMMUNICATIONS_FACILITY = 33,

     [Description("Command Facility")]
     COMMAND_FACILITY = 34,

     [Description("C4I Facility")]
     C4I_FACILITY = 35,

     [Description("Control Facility")]
     CONTROL_FACILITY = 36,

     [Description("Fire Control Facility")]
     FIRE_CONTROL_FACILITY = 37,

     [Description("Missile Defense Facility")]
     MISSILE_DEFENSE_FACILITY = 38,

     [Description("Field Command Post")]
     FIELD_COMMAND_POST = 39,

     [Description("Observation Post")]
     OBSERVATION_POST = 40
     }

    } //End Parial Class

} //End Namespace
