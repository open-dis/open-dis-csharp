
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for DestLineState
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

        public enum DestLineState 
        {

     [Description("None")]
     NONE = 0,

     [Description("Set Line State - Transmitting")]
     SET_LINE_STATE_TRANSMITTING = 1,

     [Description("Set Line State - Not Transmitting")]
     SET_LINE_STATE_NOT_TRANSMITTING = 2,

     [Description("Return to Local Line State Control")]
     RETURN_TO_LOCAL_LINE_STATE_CONTROL = 3,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 4
     }

    } //End Parial Class

} //End Namespace
