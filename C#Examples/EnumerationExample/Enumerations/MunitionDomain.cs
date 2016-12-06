
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for MunitionDomain
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

        public enum MunitionDomain 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Anti-Air")]
     ANTI_AIR = 1,

     [Description("Anti-Armor")]
     ANTI_ARMOR = 2,

     [Description("Anti-Guided Weapon")]
     ANTI_GUIDED_WEAPON = 3,

     [Description("Antiradar")]
     ANTIRADAR = 4,

     [Description("Antisatellite")]
     ANTISATELLITE = 5,

     [Description("Antiship")]
     ANTISHIP = 6,

     [Description("Antisubmarine")]
     ANTISUBMARINE = 7,

     [Description("Antipersonnel")]
     ANTIPERSONNEL = 8,

     [Description("Battlefield Support")]
     BATTLEFIELD_SUPPORT = 9,

     [Description("Strategic")]
     STRATEGIC = 10,

     [Description("Tactical")]
     TACTICAL = 11,

     [Description("Directed Energy (DE) Weapon")]
     DIRECTED_ENERGY_DE_WEAPON = 12
     }

    } //End Parial Class

} //End Namespace
