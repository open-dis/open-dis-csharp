
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for UKWeaponsForLifeForms
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

        public enum UKWeaponsForLifeForms 
        {

     [Description("LAW 80")]
     LAW_80 = 1,

     [Description("Blowpipe")]
     BLOWPIPE = 2,

     [Description("Javelin")]
     JAVELIN = 3,

     [Description("51-mm mortar")]
     X_51_MM_MORTAR = 4,

     [Description("SLR 7.62-mm rifle")]
     SLR_762_MM_RIFLE = 5,

     [Description("Sterling 9-mm submachine gun")]
     STERLING_9_MM_SUBMACHINE_GUN = 6,

     [Description("L7A2 general purpose MG")]
     L7A2_GENERAL_PURPOSE_MG = 7,

     [Description("L6 Wombat Recoilless rifle,")]
     L6_WOMBAT_RECOILLESS_RIFLE = 8,

     [Description("Carl Gustav 89-mm recoilless rifle")]
     CARL_GUSTAV_89_MM_RECOILLESS_RIFLE = 9,

     [Description("SA80 Individual/light support weapon")]
     SA80_INDIVIDUAL_LIGHT_SUPPORT_WEAPON = 10,

     [Description("Trigat")]
     TRIGAT = 11,

     [Description("Milan AT missile")]
     MILAN_AT_MISSILE = 12
     }

    } //End Parial Class

} //End Namespace
