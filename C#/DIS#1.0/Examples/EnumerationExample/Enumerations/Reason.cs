
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for Reason
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

        public enum Reason 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Recess")]
     RECESS = 1,

     [Description("Termination")]
     TERMINATION = 2,

     [Description("System Failure")]
     SYSTEM_FAILURE = 3,

     [Description("Security Violation")]
     SECURITY_VIOLATION = 4,

     [Description("Entity Reconstitution")]
     ENTITY_RECONSTITUTION = 5,

     [Description("Stop for reset")]
     STOP_FOR_RESET = 6,

     [Description("Stop for restart")]
     STOP_FOR_RESTART = 7,

     [Description("Abort Training Return to Tactical Operations")]
     ABORT_TRAINING_RETURN_TO_TACTICAL_OPERATIONS = 8
     }

    } //End Parial Class

} //End Namespace
