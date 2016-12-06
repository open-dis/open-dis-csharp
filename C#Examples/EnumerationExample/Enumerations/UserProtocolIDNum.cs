
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for UserProtocolIDNum
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

        public enum UserProtocolIDNum 
        {

     [Description("CCSIL")]
     CCSIL = 1,

     [Description("A2ATD SINCGARS ERF")]
     A2ATD_SINCGARS_ERF = 5,

     [Description("A2ATD CAC2")]
     A2ATD_CAC2 = 6,

     [Description("Battle Command")]
     BATTLE_COMMAND = 20,

     [Description("AFIWC IADS Track Report")]
     AFIWC_IADS_TRACK_REPORT = 30,

     [Description("AFIWC IADS Comm C2 Message")]
     AFIWC_IADS_COMM_C2_MESSAGE = 31,

     [Description("AFIWC IADS Ground Control Interceptor (GCI) Command")]
     AFIWC_IADS_GROUND_CONTROL_INTERCEPTOR_GCI_COMMAND = 32,

     [Description("AFIWC Voice Text Message")]
     AFIWC_VOICE_TEXT_MESSAGE = 35,

     [Description("ModSAF Text Radio")]
     MODSAF_TEXT_RADIO = 177,

     [Description("CCTT SINCGARS ERF-LOCKOUT")]
     CCTT_SINCGARS_ERF_LOCKOUT = 200,

     [Description("CCTT SINCGARS ERF-HOPSET")]
     CCTT_SINCGARS_ERF_HOPSET = 201,

     [Description("CCTT SINCGARS OTAR")]
     CCTT_SINCGARS_OTAR = 202,

     [Description("CCTT SINCGARS DATA")]
     CCTT_SINCGARS_DATA = 203,

     [Description("ModSAF FWA Forward Air Controller")]
     MODSAF_FWA_FORWARD_AIR_CONTROLLER = 546,

     [Description("ModSAF Threat ADA C3")]
     MODSAF_THREAT_ADA_C3 = 832,

     [Description("F-16 MTC AFAPD Protocol")]
     F_16_MTC_AFAPD_PROTOCOL = 1000,

     [Description("F-16 MTC IDL Protocol")]
     F_16_MTC_IDL_PROTOCOL = 1100,

     [Description("ModSAF Artillery Fire Control")]
     MODSAF_ARTILLERY_FIRE_CONTROL = 4570,

     [Description("AGTS")]
     AGTS = 5361,

     [Description("GC3")]
     GC3 = 6000,

     [Description("WNCP data")]
     WNCP_DATA = 6010,

     [Description("Spoken text message")]
     SPOKEN_TEXT_MESSAGE = 6020,

     [Description("Longbow IDM message")]
     LONGBOW_IDM_MESSAGE = 6661,

     [Description("Comanche IDM message")]
     COMANCHE_IDM_MESSAGE = 6662,

     [Description("Longbow Airborne TACFIRE Message")]
     LONGBOW_AIRBORNE_TACFIRE_MESSAGE = 6663,

     [Description("Longbow Ground TACFIRE Message")]
     LONGBOW_GROUND_TACFIRE_MESSAGE = 6664,

     [Description("Longbow AFAPD Message")]
     LONGBOW_AFAPD_MESSAGE = 6665,

     [Description("Longbow ERF message")]
     LONGBOW_ERF_MESSAGE = 6666
     }

    } //End Parial Class

} //End Namespace
