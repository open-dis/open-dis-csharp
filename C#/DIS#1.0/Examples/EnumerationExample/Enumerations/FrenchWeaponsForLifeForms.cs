
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for FrenchWeaponsForLifeForms
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

        public enum FrenchWeaponsForLifeForms 
        {

     [Description("ACL-STRIM")]
     ACL_STRIM = 1,

     [Description("Mistral missile")]
     MISTRAL_MISSILE = 2,

     [Description("Milan AT missile")]
     MILAN_AT_MISSILE = 3,

     [Description("LRAC F1 89-mm AT rocket launcher")]
     LRAC_F1_89_MM_AT_ROCKET_LAUNCHER = 4,

     [Description("FA-MAS rifle")]
     FA_MAS_RIFLE = 5,

     [Description("AA-52 machine gun")]
     AA_52_MACHINE_GUN = 6,

     [Description("58-mm rifle grenade")]
     X_58_MM_RIFLE_GRENADE = 7,

     [Description("FR-F1 sniper rifle")]
     FR_F1_SNIPER_RIFLE = 8
     }

    } //End Parial Class

} //End Namespace
