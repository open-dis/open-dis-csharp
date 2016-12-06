
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for Fuse
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

        public enum Fuse 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Intelligent Influence")]
     INTELLIGENT_INFLUENCE = 10,

     [Description("Sensor")]
     SENSOR = 20,

     [Description("Self-destruct")]
     SELF_DESTRUCT = 30,

     [Description("Ultra Quick")]
     ULTRA_QUICK = 40,

     [Description("Body")]
     BODY = 50,

     [Description("Deep Intrusion")]
     DEEP_INTRUSION = 60,

     [Description("Multifunction")]
     MULTIFUNCTION = 100,

     [Description("Point Detonation (PD)")]
     POINT_DETONATION_PD = 200,

     [Description("Base Detonation (BD)")]
     BASE_DETONATION_BD = 300,

     [Description("Contact")]
     CONTACT = 1000,

     [Description("Contact, Instant (Impact)")]
     CONTACT_INSTANT_IMPACT = 1100,

     [Description("Contact, Delayed")]
     CONTACT_DELAYED = 1200,

     [Description("10 ms delay")]
     X_10_MS_DELAY = 1201,

     [Description("20 ms delay")]
     X_20_MS_DELAY = 1202,

     [Description("50 ms delay")]
     X_50_MS_DELAY = 1205,

     [Description("60 ms delay")]
     X_60_MS_DELAY = 1206,

     [Description("100 ms delay")]
     X_100_MS_DELAY = 1210,

     [Description("125 ms delay")]
     X_125_MS_DELAY = 1212,

     [Description("250 ms delay")]
     X_250_MS_DELAY = 1225,

     [Description("Contact, Electronic (Oblique Contact)")]
     CONTACT_ELECTRONIC_OBLIQUE_CONTACT = 1300,

     [Description("Contact, Graze")]
     CONTACT_GRAZE = 1400,

     [Description("Contact, Crush")]
     CONTACT_CRUSH = 1500,

     [Description("Contact, Hydrostatic")]
     CONTACT_HYDROSTATIC = 1600,

     [Description("Contact, Mechanical")]
     CONTACT_MECHANICAL = 1700,

     [Description("Contact, Chemical")]
     CONTACT_CHEMICAL = 1800,

     [Description("Contact, Piezoelectric")]
     CONTACT_PIEZOELECTRIC = 1900,

     [Description("Contact, Point Initiating")]
     CONTACT_POINT_INITIATING = 1910,

     [Description("Contact, Point Initiating, Base Detonating")]
     CONTACT_POINT_INITIATING_BASE_DETONATING = 1920,

     [Description("Contact, Base Detonating")]
     CONTACT_BASE_DETONATING = 1930,

     [Description("Contact, Ballistic Cap and Base")]
     CONTACT_BALLISTIC_CAP_AND_BASE = 1940,

     [Description("Contact, Base")]
     CONTACT_BASE = 1950,

     [Description("Contact, Nose")]
     CONTACT_NOSE = 1960,

     [Description("Contact, Fitted in Standoff Probe")]
     CONTACT_FITTED_IN_STANDOFF_PROBE = 1970,

     [Description("Contact, Non-aligned")]
     CONTACT_NON_ALIGNED = 1980,

     [Description("Timed")]
     TIMED = 2000,

     [Description("Timed, Programmable")]
     TIMED_PROGRAMMABLE = 2100,

     [Description("Timed, Burnout")]
     TIMED_BURNOUT = 2200,

     [Description("Timed, Pyrotechnic")]
     TIMED_PYROTECHNIC = 2300,

     [Description("Timed, Electronic")]
     TIMED_ELECTRONIC = 2400,

     [Description("Timed, Base Delay")]
     TIMED_BASE_DELAY = 2500,

     [Description("Timed, Reinforced Nose Impact Delay")]
     TIMED_REINFORCED_NOSE_IMPACT_DELAY = 2600,

     [Description("Timed, Short Delay Impact")]
     TIMED_SHORT_DELAY_IMPACT = 2700,

     [Description("10 ms delay")]
     X_10_MS_DELAY_1 = 2701,

     [Description("20 ms delay")]
     X_20_MS_DELAY_2 = 2702,

     [Description("50 ms delay")]
     X_50_MS_DELAY_3 = 2705,

     [Description("60 ms delay")]
     X_60_MS_DELAY_4 = 2706,

     [Description("100 ms delay")]
     X_100_MS_DELAY_5 = 2710,

     [Description("125 ms delay")]
     X_125_MS_DELAY_6 = 2712,

     [Description("250 ms delay")]
     X_250_MS_DELAY_7 = 2725,

     [Description("Timed, Nose Mounted Variable Delay")]
     TIMED_NOSE_MOUNTED_VARIABLE_DELAY = 2800,

     [Description("Timed, Long Delay Side")]
     TIMED_LONG_DELAY_SIDE = 2900,

     [Description("Timed, Selectable Delay")]
     TIMED_SELECTABLE_DELAY = 2910,

     [Description("Timed, Impact")]
     TIMED_IMPACT = 2920,

     [Description("Timed, Sequence")]
     TIMED_SEQUENCE = 2930,

     [Description("Proximity")]
     PROXIMITY = 3000,

     [Description("Proximity, Active Laser")]
     PROXIMITY_ACTIVE_LASER = 3100,

     [Description("Proximity, Magnetic (Magpolarity)")]
     PROXIMITY_MAGNETIC_MAGPOLARITY = 3200,

     [Description("Proximity, Active Radar (Doppler Radar)")]
     PROXIMITY_ACTIVE_RADAR_DOPPLER_RADAR = 3300,

     [Description("Proximity, Radio Frequency (RF)")]
     PROXIMITY_RADIO_FREQUENCY_RF = 3400,

     [Description("Proximity, Programmable")]
     PROXIMITY_PROGRAMMABLE = 3500,

     [Description("Proximity, Programmable, Prefragmented")]
     PROXIMITY_PROGRAMMABLE_PREFRAGMENTED = 3600,

     [Description("Proximity, Infrared")]
     PROXIMITY_INFRARED = 3700,

     [Description("Command")]
     COMMAND = 4000,

     [Description("Command, Electronic, Remotely Set")]
     COMMAND_ELECTRONIC_REMOTELY_SET = 4100,

     [Description("Altitude")]
     ALTITUDE = 5000,

     [Description("Altitude, Radio Altimeter")]
     ALTITUDE_RADIO_ALTIMETER = 5100,

     [Description("Altitude, Air Burst")]
     ALTITUDE_AIR_BURST = 5200,

     [Description("Depth")]
     DEPTH = 6000,

     [Description("Acoustic")]
     ACOUSTIC = 7000,

     [Description("Pressure")]
     PRESSURE = 8000,

     [Description("Pressure, Delay")]
     PRESSURE_DELAY = 8010,

     [Description("Inert")]
     INERT = 8100,

     [Description("Dummy")]
     DUMMY = 8110,

     [Description("Practice")]
     PRACTICE = 8120,

     [Description("Plug Representing")]
     PLUG_REPRESENTING = 8130,

     [Description("Training")]
     TRAINING = 8150,

     [Description("Pyrotechnic")]
     PYROTECHNIC = 9000,

     [Description("Pyrotechnic, Delay")]
     PYROTECHNIC_DELAY = 9010,

     [Description("Electro-optical")]
     ELECTRO_OPTICAL = 9100,

     [Description("Electromechanical")]
     ELECTROMECHANICAL = 9110,

     [Description("Electromechanical, Nose")]
     ELECTROMECHANICAL_NOSE = 9120,

     [Description("Strikerless")]
     STRIKERLESS = 9200,

     [Description("Strikerless, Nose Impact")]
     STRIKERLESS_NOSE_IMPACT = 9210,

     [Description("Strikerless, Compression-Ignition")]
     STRIKERLESS_COMPRESSION_IGNITION = 9220,

     [Description("Compression-Ignition")]
     COMPRESSION_IGNITION = 9300,

     [Description("Compression-Ignition, Strikerless, Nose Impact")]
     COMPRESSION_IGNITION_STRIKERLESS_NOSE_IMPACT = 9310,

     [Description("Percussion")]
     PERCUSSION = 9400,

     [Description("Percussion, Instantaneous")]
     PERCUSSION_INSTANTANEOUS = 9410,

     [Description("Electronic")]
     ELECTRONIC = 9500,

     [Description("Electronic, Internally Mounted")]
     ELECTRONIC_INTERNALLY_MOUNTED = 9510,

     [Description("Electronic, Range Setting")]
     ELECTRONIC_RANGE_SETTING = 9520,

     [Description("Electronic, Programmed")]
     ELECTRONIC_PROGRAMMED = 9530,

     [Description("Mechanical")]
     MECHANICAL = 9600,

     [Description("Mechanical, Nose")]
     MECHANICAL_NOSE = 9610,

     [Description("Mechanical, Tail")]
     MECHANICAL_TAIL = 9620
     }

    } //End Parial Class

} //End Namespace
