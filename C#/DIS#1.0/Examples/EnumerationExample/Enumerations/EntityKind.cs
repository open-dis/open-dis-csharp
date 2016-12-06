
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for EntityKind
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

        public enum EntityKind 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Platform")]
     PLATFORM = 1,

     [Description("Munition")]
     MUNITION = 2,

     [Description("Life form")]
     LIFE_FORM = 3,

     [Description("Environmental")]
     ENVIRONMENTAL = 4,

     [Description("Cultural feature")]
     CULTURAL_FEATURE = 5,

     [Description("Supply")]
     SUPPLY = 6,

     [Description("Radio")]
     RADIO = 7,

     [Description("Expendable")]
     EXPENDABLE = 8,

     [Description("Sensor/Emitter")]
     SENSOR_EMITTER = 9
     }

    } //End Parial Class

} //End Namespace
