
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for RequestStatus
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

        public enum RequestStatus 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Pending")]
     PENDING = 1,

     [Description("Executing")]
     EXECUTING = 2,

     [Description("Partially Complete")]
     PARTIALLY_COMPLETE = 3,

     [Description("Complete")]
     COMPLETE = 4,

     [Description("Request rejected")]
     REQUEST_REJECTED = 5,

     [Description("Retransmit request now")]
     RETRANSMIT_REQUEST_NOW = 6,

     [Description("Retransmit request later")]
     RETRANSMIT_REQUEST_LATER = 7,

     [Description("Invalid time parameters")]
     INVALID_TIME_PARAMETERS = 8,

     [Description("Simulation time exceeded")]
     SIMULATION_TIME_EXCEEDED = 9,

     [Description("Request done")]
     REQUEST_DONE = 10,

     [Description("TACCSF LOS Reply-Type 1")]
     TACCSF_LOS_REPLY_TYPE_1 = 100,

     [Description("TACCSF LOS Reply-Type 2")]
     TACCSF_LOS_REPLY_TYPE_2 = 101,

     [Description("Join Exercise Request Rejected")]
     JOIN_EXERCISE_REQUEST_REJECTED = 201
     }

    } //End Parial Class

} //End Namespace
