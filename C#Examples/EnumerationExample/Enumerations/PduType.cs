
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for PduType
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

        public enum PduType 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Entity State")]
     ENTITY_STATE = 1,

     [Description("Fire")]
     FIRE = 2,

     [Description("Detonation")]
     DETONATION = 3,

     [Description("Collision")]
     COLLISION = 4,

     [Description("Service Request")]
     SERVICE_REQUEST = 5,

     [Description("Resupply Offer")]
     RESUPPLY_OFFER = 6,

     [Description("Resupply Received")]
     RESUPPLY_RECEIVED = 7,

     [Description("Resupply Cancel")]
     RESUPPLY_CANCEL = 8,

     [Description("Repair Complete")]
     REPAIR_COMPLETE = 9,

     [Description("Repair Response")]
     REPAIR_RESPONSE = 10,

     [Description("Create Entity")]
     CREATE_ENTITY = 11,

     [Description("Remove Entity")]
     REMOVE_ENTITY = 12,

     [Description("Start/Resume")]
     START_RESUME = 13,

     [Description("Stop/Freeze")]
     STOP_FREEZE = 14,

     [Description("Acknowledge")]
     ACKNOWLEDGE = 15,

     [Description("Action Request")]
     ACTION_REQUEST = 16,

     [Description("Action Response")]
     ACTION_RESPONSE = 17,

     [Description("Data Query")]
     DATA_QUERY = 18,

     [Description("Set Data")]
     SET_DATA = 19,

     [Description("Data")]
     DATA = 20,

     [Description("Event Report")]
     EVENT_REPORT = 21,

     [Description("Comment")]
     COMMENT = 22,

     [Description("Electromagnetic Emission")]
     ELECTROMAGNETIC_EMISSION = 23,

     [Description("Designator")]
     DESIGNATOR = 24,

     [Description("Transmitter")]
     TRANSMITTER = 25,

     [Description("Signal")]
     SIGNAL = 26,

     [Description("Receiver")]
     RECEIVER = 27,

     [Description("IFF/ATC/NAVAIDS")]
     IFF_ATC_NAVAIDS = 28,

     [Description("Underwater Acoustic")]
     UNDERWATER_ACOUSTIC = 29,

     [Description("Supplemental Emission / Entity State")]
     SUPPLEMENTAL_EMISSION_ENTITY_STATE = 30,

     [Description("Intercom Signal")]
     INTERCOM_SIGNAL = 31,

     [Description("Intercom Control")]
     INTERCOM_CONTROL = 32,

     [Description("Aggregate State")]
     AGGREGATE_STATE = 33,

     [Description("IsGroupOf")]
     ISGROUPOF = 34,

     [Description("Transfer Control")]
     TRANSFER_CONTROL = 35,

     [Description("IsPartOf")]
     ISPARTOF = 36,

     [Description("Minefield State")]
     MINEFIELD_STATE = 37,

     [Description("Minefield Query")]
     MINEFIELD_QUERY = 38,

     [Description("Minefield Data")]
     MINEFIELD_DATA = 39,

     [Description("Minefield Response NAK")]
     MINEFIELD_RESPONSE_NAK = 40,

     [Description("Environmental Process")]
     ENVIRONMENTAL_PROCESS = 41,

     [Description("Gridded Data")]
     GRIDDED_DATA = 42,

     [Description("Point Object State")]
     POINT_OBJECT_STATE = 43,

     [Description("Linear Object State")]
     LINEAR_OBJECT_STATE = 44,

     [Description("Areal Object State")]
     AREAL_OBJECT_STATE = 45,

     [Description("TSPI")]
     TSPI = 46,

     [Description("Appearance")]
     APPEARANCE = 47,

     [Description("Articulated Parts")]
     ARTICULATED_PARTS = 48,

     [Description("LE Fire")]
     LE_FIRE = 49,

     [Description("LE Detonation")]
     LE_DETONATION = 50,

     [Description("Create Entity-R")]
     CREATE_ENTITY_R = 51,

     [Description("Remove Entity-R")]
     REMOVE_ENTITY_R = 52,

     [Description("Start/Resume-R")]
     START_RESUME_R = 53,

     [Description("Stop/Freeze-R")]
     STOP_FREEZE_R = 54,

     [Description("Acknowledge-R")]
     ACKNOWLEDGE_R = 55,

     [Description("Action Request-R")]
     ACTION_REQUEST_R = 56,

     [Description("Action Response-R")]
     ACTION_RESPONSE_R = 57,

     [Description("Data Query-R")]
     DATA_QUERY_R = 58,

     [Description("Set Data-R")]
     SET_DATA_R = 59,

     [Description("Data-R")]
     DATA_R = 60,

     [Description("Event Report-R")]
     EVENT_REPORT_R = 61,

     [Description("Comment-R")]
     COMMENT_R = 62,

     [Description("Record-R")]
     RECORD_R = 63,

     [Description("Set Record-R")]
     SET_RECORD_R = 64,

     [Description("Record Query-R")]
     RECORD_QUERY_R = 65,

     [Description("Collision-Elastic")]
     COLLISION_ELASTIC = 66,

     [Description("Entity State Update")]
     ENTITY_STATE_UPDATE = 67
     }

    } //End Parial Class

} //End Namespace
