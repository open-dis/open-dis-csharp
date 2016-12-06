
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for RepairResponsePDU
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

        public enum RepairResponsePDU 
        {

     [Description("other")]
     OTHER = 0,

     [Description("repair ended")]
     REPAIR_ENDED = 1,

     [Description("invalid repair")]
     INVALID_REPAIR = 2,

     [Description("repair interrupted")]
     REPAIR_INTERRUPTED = 3,

     [Description("service canceled by the supplier")]
     SERVICE_CANCELED_BY_THE_SUPPLIER = 4
     }

    } //End Parial Class

} //End Namespace
