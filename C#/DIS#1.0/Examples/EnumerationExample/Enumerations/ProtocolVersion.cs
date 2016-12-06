
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for ProtocolVersion
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

        public enum ProtocolVersion 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("DIS PDU version 1.0 (May 92)")]
     DIS_PDU_VERSION_10_MAY_92 = 1,

     [Description("IEEE 1278-1993")]
     IEEE_1278_1993 = 2,

     [Description("DIS PDU version 2.0 - third draft (May 93)")]
     DIS_PDU_VERSION_20_THIRD_DRAFT_MAY_93 = 3,

     [Description("DIS PDU version 2.0 - fourth draft (revised) March 16, 1994")]
     DIS_PDU_VERSION_20_FOURTH_DRAFT_REVISED_MARCH_16_1994 = 4,

     [Description("IEEE 1278.1-1995")]
     IEEE_12781_1995 = 5,

     [Description("IEEE 1278.1A-1998")]
     IEEE_12781A_1998 = 6
     }

    } //End Parial Class

} //End Namespace
