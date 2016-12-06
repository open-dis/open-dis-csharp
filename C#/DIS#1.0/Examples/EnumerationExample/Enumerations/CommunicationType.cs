
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for CommunicationType
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

        public enum CommunicationType 
        {

     [Description("Reserved")]
     RESERVED = 0,

     [Description("Connection FDX")]
     CONNECTION_FDX = 1,

     [Description("Connection HDX - Destination is Receive Only")]
     CONNECTION_HDX_DESTINATION_IS_RECEIVE_ONLY = 2,

     [Description("Connection HDX - Destination is Transmit Only")]
     CONNECTION_HDX_DESTINATION_IS_TRANSMIT_ONLY = 3,

     [Description("Connection HDX")]
     CONNECTION_HDX = 4,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 5
     }

    } //End Parial Class

} //End Namespace
