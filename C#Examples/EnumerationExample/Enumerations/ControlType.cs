
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for ControlType
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

        public enum ControlType 
        {

     [Description("Reserved")]
     RESERVED = 0,

     [Description("Status")]
     STATUS = 1,

     [Description("Request - Acknowledge Required")]
     REQUEST_ACKNOWLEDGE_REQUIRED = 2,

     [Description("Request - No Acknowledge")]
     REQUEST_NO_ACKNOWLEDGE = 3,

     [Description("Ack - Request Granted")]
     ACK_REQUEST_GRANTED = 4,

     [Description("Nack - Request Denied")]
     NACK_REQUEST_DENIED = 5,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 6
     }

    } //End Parial Class

} //End Namespace
