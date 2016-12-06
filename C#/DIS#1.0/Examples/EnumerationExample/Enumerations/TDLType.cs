
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for TDLType
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

        public enum TDLType 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("PADIL")]
     PADIL = 1,

     [Description("NATO Link-1")]
     NATO_LINK_1 = 2,

     [Description("ATDL-1")]
     ATDL_1 = 3,

     [Description("Link 11B (TADIL B)")]
     LINK_11B_TADIL_B = 4,

     [Description("Situational Awareness Data Link (SADL)")]
     SITUATIONAL_AWARENESS_DATA_LINK_SADL = 5,

     [Description("Link 16 Legacy Format (JTIDS/TADIL-J)")]
     LINK_16_LEGACY_FORMAT_JTIDS_TADIL_J = 6,

     [Description("Link 16 Legacy Format (JTIDS/FDL/TADIL-J)")]
     LINK_16_LEGACY_FORMAT_JTIDS_FDL_TADIL_J = 7,

     [Description("Link 11A (TADIL A)")]
     LINK_11A_TADIL_A = 8,

     [Description("IJMS")]
     IJMS = 9,

     [Description("Link 4A (TADIL C)")]
     LINK_4A_TADIL_C = 10,

     [Description("Link 4C")]
     LINK_4C = 11,

     [Description("TIBS")]
     TIBS = 12,

     [Description("ATL")]
     ATL = 13,

     [Description("Constant Source")]
     CONSTANT_SOURCE = 14,

     [Description("Abbreviated Command and Control")]
     ABBREVIATED_COMMAND_AND_CONTROL = 15,

     [Description("MILSTAR")]
     MILSTAR = 16,

     [Description("ATHS")]
     ATHS = 17,

     [Description("OTHGOLD")]
     OTHGOLD = 18,

     [Description("TACELINT")]
     TACELINT = 19,

     [Description("Weapons Data Link (AWW-13)")]
     WEAPONS_DATA_LINK_AWW_13 = 20,

     [Description("Abbreviated Command and Control")]
     ABBREVIATED_COMMAND_AND_CONTROL_1 = 21,

     [Description("Enhanced Position Location Reporting System (EPLRS)")]
     ENHANCED_POSITION_LOCATION_REPORTING_SYSTEM_EPLRS = 22,

     [Description("Position Location Reporting System (PLRS)")]
     POSITION_LOCATION_REPORTING_SYSTEM_PLRS = 23,

     [Description("SINCGARS")]
     SINCGARS = 24,

     [Description("Have Quick I")]
     HAVE_QUICK_I = 25,

     [Description("Have Quick II")]
     HAVE_QUICK_II = 26,

     [Description("Have Quick IIA (Saturn)")]
     HAVE_QUICK_IIA_SATURN = 27,

     [Description("Intra-Flight Data Link 1")]
     INTRA_FLIGHT_DATA_LINK_1 = 28,

     [Description("Intra-Flight Data Link 2")]
     INTRA_FLIGHT_DATA_LINK_2 = 29,

     [Description("Improved Data Modem (IDM)")]
     IMPROVED_DATA_MODEM_IDM = 30,

     [Description("Air Force Application Program Development (AFAPD)")]
     AIR_FORCE_APPLICATION_PROGRAM_DEVELOPMENT_AFAPD = 31,

     [Description("Cooperative Engagement Capability (CEC)")]
     COOPERATIVE_ENGAGEMENT_CAPABILITY_CEC = 32,

     [Description("Forward Area Air Defense (FAAD) Data Link (FDL)")]
     FORWARD_AREA_AIR_DEFENSE_FAAD_DATA_LINK_FDL = 33,

     [Description("Ground Based Data Link (GBDL)")]
     GROUND_BASED_DATA_LINK_GBDL = 34,

     [Description("Intra Vehicular Info System (IVIS)")]
     INTRA_VEHICULAR_INFO_SYSTEM_IVIS = 35,

     [Description("Marine Tactical System (MTS)")]
     MARINE_TACTICAL_SYSTEM_MTS = 36,

     [Description("Tactical Fire Direction System (TACFIRE)")]
     TACTICAL_FIRE_DIRECTION_SYSTEM_TACFIRE = 37,

     [Description("Integrated Broadcast Service (IBS)")]
     INTEGRATED_BROADCAST_SERVICE_IBS = 38,

     [Description("Airborne Information Transfer (ABIT)")]
     AIRBORNE_INFORMATION_TRANSFER_ABIT = 39,

     [Description("Advanced Tactical Airborne Reconnaissance System (ATARS) Data Link")]
     ADVANCED_TACTICAL_AIRBORNE_RECONNAISSANCE_SYSTEM_ATARS_DATA_LINK = 40,

     [Description("Battle Group Passive Horizon Extension System (BGPHES) Data Link")]
     BATTLE_GROUP_PASSIVE_HORIZON_EXTENSION_SYSTEM_BGPHES_DATA_LINK = 41,

     [Description("Common High Bandwidth Data Link (CHBDL)")]
     COMMON_HIGH_BANDWIDTH_DATA_LINK_CHBDL = 42,

     [Description("Guardrail Interoperable Data Link (IDL)")]
     GUARDRAIL_INTEROPERABLE_DATA_LINK_IDL = 43,

     [Description("Guardrail Common Sensor System One (CSS1) Data Link")]
     GUARDRAIL_COMMON_SENSOR_SYSTEM_ONE_CSS1_DATA_LINK = 44,

     [Description("Guardrail Common Sensor System Two (CSS2) Data Link")]
     GUARDRAIL_COMMON_SENSOR_SYSTEM_TWO_CSS2_DATA_LINK = 45,

     [Description("Guardrail CSS2 Multi-Role Data Link (MRDL)")]
     GUARDRAIL_CSS2_MULTI_ROLE_DATA_LINK_MRDL = 46,

     [Description("Guardrail CSS2 Direct Air to Satellite Relay (DASR) Data Link")]
     GUARDRAIL_CSS2_DIRECT_AIR_TO_SATELLITE_RELAY_DASR_DATA_LINK = 47,

     [Description("Line of Sight (LOS) Data Link Implementation (LOS tether)")]
     LINE_OF_SIGHT_LOS_DATA_LINK_IMPLEMENTATION_LOS_TETHER = 48,

     [Description("Lightweight CDL (LWCDL)")]
     LIGHTWEIGHT_CDL_LWCDL = 49,

     [Description("L-52M (SR-71)")]
     L_52M_SR_71 = 50,

     [Description("Rivet Reach/Rivet Owl Data Link")]
     RIVET_REACH_RIVET_OWL_DATA_LINK = 51,

     [Description("Senior Span")]
     SENIOR_SPAN = 52,

     [Description("Senior Spur")]
     SENIOR_SPUR = 53,

     [Description("Senior Stretch.")]
     SENIOR_STRETCH = 54,

     [Description("Senior Year Interoperable Data Link (IDL)")]
     SENIOR_YEAR_INTEROPERABLE_DATA_LINK_IDL = 55,

     [Description("Space CDL")]
     SPACE_CDL = 56,

     [Description("TR-1 mode MIST Airborne Data Link")]
     TR_1_MODE_MIST_AIRBORNE_DATA_LINK = 57,

     [Description("Ku-band SATCOM Data Link Implementation (UAV)")]
     KU_BAND_SATCOM_DATA_LINK_IMPLEMENTATION_UAV = 58,

     [Description("Mission Equipment Control Data link (MECDL)")]
     MISSION_EQUIPMENT_CONTROL_DATA_LINK_MECDL = 59,

     [Description("Radar Data Transmitting Set Data Link")]
     RADAR_DATA_TRANSMITTING_SET_DATA_LINK = 60,

     [Description("Surveillance and Control Data Link (SCDL)")]
     SURVEILLANCE_AND_CONTROL_DATA_LINK_SCDL = 61,

     [Description("Tactical UAV Video")]
     TACTICAL_UAV_VIDEO = 62,

     [Description("UHF SATCOM Data Link Implementation (UAV)")]
     UHF_SATCOM_DATA_LINK_IMPLEMENTATION_UAV = 63,

     [Description("Tactical Common Data Link (TCDL)")]
     TACTICAL_COMMON_DATA_LINK_TCDL = 64,

     [Description("Low Level Air Picture Interface (LLAPI)")]
     LOW_LEVEL_AIR_PICTURE_INTERFACE_LLAPI = 65,

     [Description("Weapons Data Link (AGM-130)")]
     WEAPONS_DATA_LINK_AGM_130 = 66,

     [Description("GC3")]
     GC3 = 99,

     [Description("Link 16 Standardized Format (JTIDS/MIDS/TADIL J)")]
     LINK_16_STANDARDIZED_FORMAT_JTIDS_MIDS_TADIL_J = 100,

     [Description("Link 16 Enhanced Data Rate (EDR JTIDS/MIDS/TADIL-J)")]
     LINK_16_ENHANCED_DATA_RATE_EDR_JTIDS_MIDS_TADIL_J = 101,

     [Description("JTIDS/MIDS Net Data Load (TIMS/TOMS)")]
     JTIDS_MIDS_NET_DATA_LOAD_TIMS_TOMS = 102,

     [Description("Link 22")]
     LINK_22 = 103,

     [Description("AFIWC IADS Communications Links")]
     AFIWC_IADS_COMMUNICATIONS_LINKS = 104
     }

    } //End Parial Class

} //End Namespace
