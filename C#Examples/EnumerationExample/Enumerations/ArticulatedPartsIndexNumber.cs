
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for ArticulatedPartsIndexNumber
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

        public enum ArticulatedPartsIndexNumber 
        {

     [Description("rudder")]
     RUDDER = 1024,

     [Description("left flap")]
     LEFT_FLAP = 1056,

     [Description("right flap")]
     RIGHT_FLAP = 1088,

     [Description("left aileron")]
     LEFT_AILERON = 1120,

     [Description("right aileron")]
     RIGHT_AILERON = 1152,

     [Description("helicopter - main rotor")]
     HELICOPTER_MAIN_ROTOR = 1184,

     [Description("helicopter - tail rotor")]
     HELICOPTER_TAIL_ROTOR = 1216,

     [Description("other Aircraft Control Surfaces defined as needed")]
     OTHER_AIRCRAFT_CONTROL_SURFACES_DEFINED_AS_NEEDED = 1248,

     [Description("periscope")]
     PERISCOPE = 2048,

     [Description("generic antenna")]
     GENERIC_ANTENNA = 2080,

     [Description("snorkel")]
     SNORKEL = 2112,

     [Description("other extendible parts defined as needed")]
     OTHER_EXTENDIBLE_PARTS_DEFINED_AS_NEEDED = 2144,

     [Description("landing gear")]
     LANDING_GEAR = 3072,

     [Description("tail hook")]
     TAIL_HOOK = 3104,

     [Description("speed brake")]
     SPEED_BRAKE = 3136,

     [Description("left weapon bay door")]
     LEFT_WEAPON_BAY_DOOR = 3168,

     [Description("right weapon bay doors")]
     RIGHT_WEAPON_BAY_DOORS = 3200,

     [Description("tank or APC hatch")]
     TANK_OR_APC_HATCH = 3232,

     [Description("wingsweep")]
     WINGSWEEP = 3264,

     [Description("Bridge launcher")]
     BRIDGE_LAUNCHER = 3296,

     [Description("Bridge section 1")]
     BRIDGE_SECTION_1 = 3328,

     [Description("Bridge section 2")]
     BRIDGE_SECTION_2 = 3360,

     [Description("Bridge section 3")]
     BRIDGE_SECTION_3 = 3392,

     [Description("Primary blade 1")]
     PRIMARY_BLADE_1 = 3424,

     [Description("Primary blade 2")]
     PRIMARY_BLADE_2 = 3456,

     [Description("Primary boom")]
     PRIMARY_BOOM = 3488,

     [Description("Primary launcher arm")]
     PRIMARY_LAUNCHER_ARM = 3520,

     [Description("other fixed position parts defined as needed")]
     OTHER_FIXED_POSITION_PARTS_DEFINED_AS_NEEDED = 3552,

     [Description("Primary turret number 1")]
     PRIMARY_TURRET_NUMBER_1 = 4096,

     [Description("Primary turret number 2")]
     PRIMARY_TURRET_NUMBER_2 = 4128,

     [Description("Primary turret number 3")]
     PRIMARY_TURRET_NUMBER_3 = 4160,

     [Description("Primary turret number 4")]
     PRIMARY_TURRET_NUMBER_4 = 4192,

     [Description("Primary turret number 5")]
     PRIMARY_TURRET_NUMBER_5 = 4224,

     [Description("Primary turret number 6")]
     PRIMARY_TURRET_NUMBER_6 = 4256,

     [Description("Primary turret number 7")]
     PRIMARY_TURRET_NUMBER_7 = 4288,

     [Description("Primary turret number 8")]
     PRIMARY_TURRET_NUMBER_8 = 4320,

     [Description("Primary turret number 9")]
     PRIMARY_TURRET_NUMBER_9 = 4352,

     [Description("Primary turret number 10")]
     PRIMARY_TURRET_NUMBER_10 = 4384,

     [Description("Primary gun number 1")]
     PRIMARY_GUN_NUMBER_1 = 4416,

     [Description("Primary gun number 2")]
     PRIMARY_GUN_NUMBER_2 = 4448,

     [Description("Primary gun number 3")]
     PRIMARY_GUN_NUMBER_3 = 4480,

     [Description("Primary gun number 4")]
     PRIMARY_GUN_NUMBER_4 = 4512,

     [Description("Primary gun number 5")]
     PRIMARY_GUN_NUMBER_5 = 4544,

     [Description("Primary gun number 6")]
     PRIMARY_GUN_NUMBER_6 = 4576,

     [Description("Primary gun number 7")]
     PRIMARY_GUN_NUMBER_7 = 4608,

     [Description("Primary gun number 8")]
     PRIMARY_GUN_NUMBER_8 = 4640,

     [Description("Primary gun number 9")]
     PRIMARY_GUN_NUMBER_9 = 4672,

     [Description("Primary gun number 10")]
     PRIMARY_GUN_NUMBER_10 = 4704,

     [Description("Primary launcher 1")]
     PRIMARY_LAUNCHER_1 = 4736,

     [Description("Primary launcher 2")]
     PRIMARY_LAUNCHER_2 = 4768,

     [Description("Primary launcher 3")]
     PRIMARY_LAUNCHER_3 = 4800,

     [Description("Primary launcher 4")]
     PRIMARY_LAUNCHER_4 = 4832,

     [Description("Primary launcher 5")]
     PRIMARY_LAUNCHER_5 = 4864,

     [Description("Primary launcher 6")]
     PRIMARY_LAUNCHER_6 = 4896,

     [Description("Primary launcher 7")]
     PRIMARY_LAUNCHER_7 = 4928,

     [Description("Primary launcher 8")]
     PRIMARY_LAUNCHER_8 = 4960,

     [Description("Primary launcher 9")]
     PRIMARY_LAUNCHER_9 = 4992,

     [Description("Primary launcher 10")]
     PRIMARY_LAUNCHER_10 = 5024,

     [Description("Primary defense systems 1")]
     PRIMARY_DEFENSE_SYSTEMS_1 = 5056,

     [Description("Primary defense systems 2")]
     PRIMARY_DEFENSE_SYSTEMS_2 = 5088,

     [Description("Primary defense systems 3")]
     PRIMARY_DEFENSE_SYSTEMS_3 = 5120,

     [Description("Primary defense systems 4")]
     PRIMARY_DEFENSE_SYSTEMS_4 = 5152,

     [Description("Primary defense systems 5")]
     PRIMARY_DEFENSE_SYSTEMS_5 = 5184,

     [Description("Primary defense systems 6")]
     PRIMARY_DEFENSE_SYSTEMS_6 = 5216,

     [Description("Primary defense systems 7")]
     PRIMARY_DEFENSE_SYSTEMS_7 = 5248,

     [Description("Primary defense systems 8")]
     PRIMARY_DEFENSE_SYSTEMS_8 = 5280,

     [Description("Primary defense systems 9")]
     PRIMARY_DEFENSE_SYSTEMS_9 = 5312,

     [Description("Primary defense systems 10")]
     PRIMARY_DEFENSE_SYSTEMS_10 = 5344,

     [Description("Primary radar 1")]
     PRIMARY_RADAR_1 = 5376,

     [Description("Primary radar 2")]
     PRIMARY_RADAR_2 = 5408,

     [Description("Primary radar 3")]
     PRIMARY_RADAR_3 = 5440,

     [Description("Primary radar 4")]
     PRIMARY_RADAR_4 = 5472,

     [Description("Primary radar 5")]
     PRIMARY_RADAR_5 = 5504,

     [Description("Primary radar 6")]
     PRIMARY_RADAR_6 = 5536,

     [Description("Primary radar 7")]
     PRIMARY_RADAR_7 = 5568,

     [Description("Primary radar 8")]
     PRIMARY_RADAR_8 = 5600,

     [Description("Primary radar 9")]
     PRIMARY_RADAR_9 = 5632,

     [Description("Primary radar 10")]
     PRIMARY_RADAR_10 = 5664,

     [Description("Secondary turret number 1")]
     SECONDARY_TURRET_NUMBER_1 = 5696,

     [Description("Secondary turret number 2")]
     SECONDARY_TURRET_NUMBER_2 = 5728,

     [Description("Secondary turret number 3")]
     SECONDARY_TURRET_NUMBER_3 = 5760,

     [Description("Secondary turret number 4")]
     SECONDARY_TURRET_NUMBER_4 = 5792,

     [Description("Secondary turret number 5")]
     SECONDARY_TURRET_NUMBER_5 = 5824,

     [Description("Secondary turret number 6")]
     SECONDARY_TURRET_NUMBER_6 = 5856,

     [Description("Secondary turret number 7")]
     SECONDARY_TURRET_NUMBER_7 = 5888,

     [Description("Secondary turret number 8")]
     SECONDARY_TURRET_NUMBER_8 = 5920,

     [Description("Secondary turret number 9")]
     SECONDARY_TURRET_NUMBER_9 = 5952,

     [Description("Secondary turret number 10")]
     SECONDARY_TURRET_NUMBER_10 = 5984,

     [Description("Secondary gun number 1")]
     SECONDARY_GUN_NUMBER_1 = 6016,

     [Description("Secondary gun number 2")]
     SECONDARY_GUN_NUMBER_2 = 6048,

     [Description("Secondary gun number 3")]
     SECONDARY_GUN_NUMBER_3 = 6080,

     [Description("Secondary gun number 4")]
     SECONDARY_GUN_NUMBER_4 = 6112,

     [Description("Secondary gun number 5")]
     SECONDARY_GUN_NUMBER_5 = 6144,

     [Description("Secondary gun number 6")]
     SECONDARY_GUN_NUMBER_6 = 6176,

     [Description("Secondary gun number 7")]
     SECONDARY_GUN_NUMBER_7 = 6208,

     [Description("Secondary gun number 8")]
     SECONDARY_GUN_NUMBER_8 = 6240,

     [Description("Secondary gun number 9")]
     SECONDARY_GUN_NUMBER_9 = 6272,

     [Description("Secondary gun number 10")]
     SECONDARY_GUN_NUMBER_10 = 6304,

     [Description("Secondary launcher 1")]
     SECONDARY_LAUNCHER_1 = 6336,

     [Description("Secondary launcher 2")]
     SECONDARY_LAUNCHER_2 = 6368,

     [Description("Secondary launcher 3")]
     SECONDARY_LAUNCHER_3 = 6400,

     [Description("Secondary launcher 4")]
     SECONDARY_LAUNCHER_4 = 6432,

     [Description("Secondary launcher 5")]
     SECONDARY_LAUNCHER_5 = 6464,

     [Description("Secondary launcher 6")]
     SECONDARY_LAUNCHER_6 = 6496,

     [Description("Secondary launcher 7")]
     SECONDARY_LAUNCHER_7 = 6528,

     [Description("Secondary launcher 8")]
     SECONDARY_LAUNCHER_8 = 6560,

     [Description("Secondary launcher 9")]
     SECONDARY_LAUNCHER_9 = 6592,

     [Description("Secondary launcher 10")]
     SECONDARY_LAUNCHER_10 = 6624,

     [Description("Secondary defense systems 1")]
     SECONDARY_DEFENSE_SYSTEMS_1 = 6656,

     [Description("Secondary defense systems 2")]
     SECONDARY_DEFENSE_SYSTEMS_2 = 6688,

     [Description("Secondary defense systems 3")]
     SECONDARY_DEFENSE_SYSTEMS_3 = 6720,

     [Description("Secondary defense systems 4")]
     SECONDARY_DEFENSE_SYSTEMS_4 = 6752,

     [Description("Secondary defense systems 5")]
     SECONDARY_DEFENSE_SYSTEMS_5 = 6784,

     [Description("Secondary defense systems 6")]
     SECONDARY_DEFENSE_SYSTEMS_6 = 6816,

     [Description("Secondary defense systems 7")]
     SECONDARY_DEFENSE_SYSTEMS_7 = 6848,

     [Description("Secondary defense systems 8")]
     SECONDARY_DEFENSE_SYSTEMS_8 = 6880,

     [Description("Secondary defense systems 9")]
     SECONDARY_DEFENSE_SYSTEMS_9 = 6912,

     [Description("Secondary defense systems 10")]
     SECONDARY_DEFENSE_SYSTEMS_10 = 6944,

     [Description("Secondary radar 1")]
     SECONDARY_RADAR_1 = 6976,

     [Description("Secondary radar 2")]
     SECONDARY_RADAR_2 = 7008,

     [Description("Secondary radar 3")]
     SECONDARY_RADAR_3 = 7040,

     [Description("Secondary radar 4")]
     SECONDARY_RADAR_4 = 7072,

     [Description("Secondary radar 5")]
     SECONDARY_RADAR_5 = 7104,

     [Description("Secondary radar 6")]
     SECONDARY_RADAR_6 = 7136,

     [Description("Secondary radar 7")]
     SECONDARY_RADAR_7 = 7168,

     [Description("Secondary radar 8")]
     SECONDARY_RADAR_8 = 7200,

     [Description("Secondary radar 9")]
     SECONDARY_RADAR_9 = 7232,

     [Description("Secondary radar 10")]
     SECONDARY_RADAR_10 = 7264,

     [Description("Deck Elevator #1")]
     DECK_ELEVATOR_1 = 7296,

     [Description("Deck Elevator #2")]
     DECK_ELEVATOR_2 = 7328,

     [Description("Catapult #1")]
     CATAPULT_1 = 7360,

     [Description("Catapult #2")]
     CATAPULT_2 = 7392,

     [Description("Jet Blast Deflector #1")]
     JET_BLAST_DEFLECTOR_1 = 7424,

     [Description("Jet Blast Deflector #2")]
     JET_BLAST_DEFLECTOR_2 = 7456,

     [Description("Arrestor Wires #1")]
     ARRESTOR_WIRES_1 = 7488,

     [Description("Arrestor Wires #2")]
     ARRESTOR_WIRES_2 = 7520,

     [Description("Arrestor Wires #3")]
     ARRESTOR_WIRES_3 = 7552,

     [Description("Wing (or rotor) fold")]
     WING_OR_ROTOR_FOLD = 7584,

     [Description("Fuselage fold")]
     FUSELAGE_FOLD = 7616
     }

    } //End Parial Class

} //End Namespace
