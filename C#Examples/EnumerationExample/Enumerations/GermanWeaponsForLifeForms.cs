
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for GermanWeaponsForLifeForms
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

        public enum GermanWeaponsForLifeForms 
        {

     [Description("G3 rifle")]
     G3_RIFLE = 1,

     [Description("G11 rifle")]
     G11_RIFLE = 2,

     [Description("P1 pistol")]
     P1_PISTOL = 3,

     [Description("MG3 machine gun")]
     MG3_MACHINE_GUN = 4,

     [Description("Milan missile")]
     MILAN_MISSILE = 5,

     [Description("MP1 Uzi submachine gun")]
     MP1_UZI_SUBMACHINE_GUN = 6,

     [Description("Panzerfaust 3 Light Anti-Tank Weapon")]
     PANZERFAUST_3_LIGHT_ANTI_TANK_WEAPON = 7,

     [Description("DM19 hand grenade")]
     DM19_HAND_GRENADE = 8,

     [Description("DM29 hand grenade")]
     DM29_HAND_GRENADE = 9
     }

    } //End Parial Class

} //End Namespace
