
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for ActionID
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

        public enum ActionID 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Local storage of the requested information")]
     LOCAL_STORAGE_OF_THE_REQUESTED_INFORMATION = 1,

     [Description("Inform SM of event ran out of ammunition")]
     INFORM_SM_OF_EVENT_RAN_OUT_OF_AMMUNITION = 2,

     [Description("Inform SM of event killed in action")]
     INFORM_SM_OF_EVENT_KILLED_IN_ACTION = 3,

     [Description("Inform SM of event damage")]
     INFORM_SM_OF_EVENT_DAMAGE = 4,

     [Description("Inform SM of event mobility disabled")]
     INFORM_SM_OF_EVENT_MOBILITY_DISABLED = 5,

     [Description("Inform SM of event fire disabled")]
     INFORM_SM_OF_EVENT_FIRE_DISABLED = 6,

     [Description("Inform SM of event ran out of fuel")]
     INFORM_SM_OF_EVENT_RAN_OUT_OF_FUEL = 7,

     [Description("Recall checkpoint data")]
     RECALL_CHECKPOINT_DATA = 8,

     [Description("Recall initial parameters")]
     RECALL_INITIAL_PARAMETERS = 9,

     [Description("Initiate tether-lead")]
     INITIATE_TETHER_LEAD = 10,

     [Description("Initiate tether-follow")]
     INITIATE_TETHER_FOLLOW = 11,

     [Description("Unthether")]
     UNTHETHER = 12,

     [Description("Initiate service station resupply")]
     INITIATE_SERVICE_STATION_RESUPPLY = 13,

     [Description("Initiate tailgate resupply")]
     INITIATE_TAILGATE_RESUPPLY = 14,

     [Description("Initiate hitch lead")]
     INITIATE_HITCH_LEAD = 15,

     [Description("Initiate hitch follow")]
     INITIATE_HITCH_FOLLOW = 16,

     [Description("Unhitch")]
     UNHITCH = 17,

     [Description("Mount")]
     MOUNT = 18,

     [Description("Dismount")]
     DISMOUNT = 19,

     [Description("Start DRC (Daily Readiness Check)")]
     START_DRC_DAILY_READINESS_CHECK = 20,

     [Description("Stop DRC")]
     STOP_DRC = 21,

     [Description("Data Query")]
     DATA_QUERY = 22,

     [Description("Status Request")]
     STATUS_REQUEST = 23,

     [Description("Send Object State Data")]
     SEND_OBJECT_STATE_DATA = 24,

     [Description("Reconstitute")]
     RECONSTITUTE = 25,

     [Description("Lock Site Configuration")]
     LOCK_SITE_CONFIGURATION = 26,

     [Description("Unlock Site Configuration")]
     UNLOCK_SITE_CONFIGURATION = 27,

     [Description("Update Site Configuration")]
     UPDATE_SITE_CONFIGURATION = 28,

     [Description("Query Site Configuration")]
     QUERY_SITE_CONFIGURATION = 29,

     [Description("Tethering Information")]
     TETHERING_INFORMATION = 30,

     [Description("Mount Intent")]
     MOUNT_INTENT = 31,

     [Description("Accept Subscription")]
     ACCEPT_SUBSCRIPTION = 33,

     [Description("Unsubscribe")]
     UNSUBSCRIBE = 34,

     [Description("Teleport entity")]
     TELEPORT_ENTITY = 35,

     [Description("Change aggregate state")]
     CHANGE_AGGREGATE_STATE = 36,

     [Description("Request Start PDU")]
     REQUEST_START_PDU = 37,

     [Description("Wakeup get ready for initialization")]
     WAKEUP_GET_READY_FOR_INITIALIZATION = 38,

     [Description("Initialize internal parameters")]
     INITIALIZE_INTERNAL_PARAMETERS = 39,

     [Description("Send plan data")]
     SEND_PLAN_DATA = 40,

     [Description("Synchronize internal clocks")]
     SYNCHRONIZE_INTERNAL_CLOCKS = 41,

     [Description("Run")]
     RUN = 42,

     [Description("Save internal parameters")]
     SAVE_INTERNAL_PARAMETERS = 43,

     [Description("Simulate malfunction")]
     SIMULATE_MALFUNCTION = 44,

     [Description("Join exercise")]
     JOIN_EXERCISE = 45,

     [Description("Resign exercise")]
     RESIGN_EXERCISE = 46,

     [Description("Time advance")]
     TIME_ADVANCE = 47,

     [Description("TACCSF LOS Request-Type 1")]
     TACCSF_LOS_REQUEST_TYPE_1 = 100,

     [Description("TACCSF LOS Request-Type 2")]
     TACCSF_LOS_REQUEST_TYPE_2 = 101
     }

    } //End Parial Class

} //End Namespace
