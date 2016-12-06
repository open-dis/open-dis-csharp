
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for TransferType
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

        public enum TransferType 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Controlling application requests transfer of an entity")]
     CONTROLLING_APPLICATION_REQUESTS_TRANSFER_OF_AN_ENTITY = 1,

     [Description("Application desiring control requests transfer of an entity")]
     APPLICATION_DESIRING_CONTROL_REQUESTS_TRANSFER_OF_AN_ENTITY = 2,

     [Description("Mutual exchange / swap of an entity")]
     MUTUAL_EXCHANGE_SWAP_OF_AN_ENTITY = 3,

     [Description("Controlling application requests transfer of an environmental process")]
     CONTROLLING_APPLICATION_REQUESTS_TRANSFER_OF_AN_ENVIRONMENTAL_PROCESS = 4,

     [Description("Application desiring controls requests transfer of an environmental process")]
     APPLICATION_DESIRING_CONTROLS_REQUESTS_TRANSFER_OF_AN_ENVIRONMENTAL_PROCESS = 5,

     [Description("Mutual exchange / swap of an environmental")]
     MUTUAL_EXCHANGE_SWAP_OF_AN_ENVIRONMENTAL = 6,

     [Description("Cancel transfer")]
     CANCEL_TRANSFER = 7
     }

    } //End Parial Class

} //End Namespace
