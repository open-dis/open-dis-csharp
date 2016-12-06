
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for ObjectKind
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

        public enum ObjectKind 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Obstacle")]
     OBSTACLE = 1,

     [Description("Prepared position")]
     PREPARED_POSITION = 2,

     [Description("Cultural feature")]
     CULTURAL_FEATURE = 3,

     [Description("Passageway")]
     PASSAGEWAY = 4,

     [Description("Tactical smoke")]
     TACTICAL_SMOKE = 5,

     [Description("Obstacle marker")]
     OBSTACLE_MARKER = 6,

     [Description("Obstacle breach")]
     OBSTACLE_BREACH = 7
     }

    } //End Parial Class

} //End Namespace
