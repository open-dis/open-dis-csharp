
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for RadioCategory
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

        public enum RadioCategory 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Voice Transmission/Reception")]
     VOICE_TRANSMISSION_RECEPTION = 1,

     [Description("Data Link Transmission/Reception")]
     DATA_LINK_TRANSMISSION_RECEPTION = 2,

     [Description("Voice and Data Link Transmission/Reception")]
     VOICE_AND_DATA_LINK_TRANSMISSION_RECEPTION = 3,

     [Description("Instrumented Landing System (ILS) Glideslope Transmitter")]
     INSTRUMENTED_LANDING_SYSTEM_ILS_GLIDESLOPE_TRANSMITTER = 4,

     [Description("Instrumented Landing System (ILS) Localizer Transmitter")]
     INSTRUMENTED_LANDING_SYSTEM_ILS_LOCALIZER_TRANSMITTER = 5,

     [Description("Instrumented Landing System (ILS) Outer Marker Beacon")]
     INSTRUMENTED_LANDING_SYSTEM_ILS_OUTER_MARKER_BEACON = 6,

     [Description("Instrumented Landing System (ILS) Middle Marker Beacon")]
     INSTRUMENTED_LANDING_SYSTEM_ILS_MIDDLE_MARKER_BEACON = 7,

     [Description("Instrumented Landing System (ILS) Inner Marker Beacon")]
     INSTRUMENTED_LANDING_SYSTEM_ILS_INNER_MARKER_BEACON = 8,

     [Description("Instrumented Landing System (ILS) Receiver (Platform Radio)")]
     INSTRUMENTED_LANDING_SYSTEM_ILS_RECEIVER_PLATFORM_RADIO = 9,

     [Description("Tactical Air Navigation (TACAN) Transmitter (Ground Fixed Equipment)")]
     TACTICAL_AIR_NAVIGATION_TACAN_TRANSMITTER_GROUND_FIXED_EQUIPMENT = 10,

     [Description("Tactical Air Navigation (TACAN) Receiver (Moving Platform Equipment)")]
     TACTICAL_AIR_NAVIGATION_TACAN_RECEIVER_MOVING_PLATFORM_EQUIPMENT = 11,

     [Description("Tactical Air Navigation (TACAN) Transmitter/Receiver (Moving Platform Equipment)")]
     TACTICAL_AIR_NAVIGATION_TACAN_TRANSMITTER_RECEIVER_MOVING_PLATFORM_EQUIPMENT = 12,

     [Description("Variable Omni-Ranging (VOR) Transmitter (Ground Fixed Equipment)")]
     VARIABLE_OMNI_RANGING_VOR_TRANSMITTER_GROUND_FIXED_EQUIPMENT = 13,

     [Description("Variable Omni-Ranging (VOR) with Distance Measuring Equipment (DME) Transmitter (Ground Fixed Equipment)")]
     VARIABLE_OMNI_RANGING_VOR_WITH_DISTANCE_MEASURING_EQUIPMENT_DME_TRANSMITTER_GROUND_FIXED_EQUIPMENT = 14,

     [Description("Combined VOR/ILS Receiver (Moving Platform Equipment)")]
     COMBINED_VOR_ILS_RECEIVER_MOVING_PLATFORM_EQUIPMENT = 15,

     [Description("Combined VOR & TACAN (VORTAC) Transmitter")]
     COMBINED_VOR_TACAN_VORTAC_TRANSMITTER = 16,

     [Description("Non-Directional Beacon (NDB) Transmitter")]
     NON_DIRECTIONAL_BEACON_NDB_TRANSMITTER = 17,

     [Description("Non-Directional Beacon (NDB) Receiver")]
     NON_DIRECTIONAL_BEACON_NDB_RECEIVER = 18,

     [Description("Non-Directional Beacon (NDB) with Distance Measuring Equipment (DME) Transmitter")]
     NON_DIRECTIONAL_BEACON_NDB_WITH_DISTANCE_MEASURING_EQUIPMENT_DME_TRANSMITTER = 19,

     [Description("Distance Measuring Equipment (DME)")]
     DISTANCE_MEASURING_EQUIPMENT_DME = 20
     }

    } //End Parial Class

} //End Namespace
