
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for PlatformSubSurface
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

        public enum PlatformSubSurface 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("SSBN (Nuclear Ballistic Missile)")]
     SSBN_NUCLEAR_BALLISTIC_MISSILE = 1,

     [Description("SSGN (Nuclear Guided Missile)")]
     SSGN_NUCLEAR_GUIDED_MISSILE = 2,

     [Description("SSN (Nuclear Attack - Torpedo)")]
     SSN_NUCLEAR_ATTACK_TORPEDO = 3,

     [Description("SSG (Conventional Guided Missile)")]
     SSG_CONVENTIONAL_GUIDED_MISSILE = 4,

     [Description("SS (Conventional Attack - Torpedo, Patrol)")]
     SS_CONVENTIONAL_ATTACK_TORPEDO_PATROL = 5,

     [Description("SSAN (Nuclear Auxiliary)")]
     SSAN_NUCLEAR_AUXILIARY = 6,

     [Description("SSA (Conventional Auxiliary)")]
     SSA_CONVENTIONAL_AUXILIARY = 7
     }

    } //End Parial Class

} //End Namespace
