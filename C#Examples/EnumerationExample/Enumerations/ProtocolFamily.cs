
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for ProtocolFamily
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

        public enum ProtocolFamily 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Entity Information/Interaction")]
     ENTITY_INFORMATION_INTERACTION = 1,

     [Description("Warfare")]
     WARFARE = 2,

     [Description("Logistics")]
     LOGISTICS = 3,

     [Description("Radio Communication")]
     RADIO_COMMUNICATION = 4,

     [Description("Simulation Management")]
     SIMULATION_MANAGEMENT = 5,

     [Description("Distributed Emission Regeneration")]
     DISTRIBUTED_EMISSION_REGENERATION = 6,

     [Description("Entity Management")]
     ENTITY_MANAGEMENT = 7,

     [Description("Minefield")]
     MINEFIELD = 8,

     [Description("Synthetic Environment")]
     SYNTHETIC_ENVIRONMENT = 9,

     [Description("Simulation Management with Reliability")]
     SIMULATION_MANAGEMENT_WITH_RELIABILITY = 10,

     [Description("Live Entity")]
     LIVE_ENTITY = 11,

     [Description("Non-Real Time")]
     NON_REAL_TIME = 12,

     [Description("Experimental - Computer Generated Forces")]
     EXPERIMENTAL_COMPUTER_GENERATED_FORCES = 129
     }

    } //End Parial Class

} //End Namespace
