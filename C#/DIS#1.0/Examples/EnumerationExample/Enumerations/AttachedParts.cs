
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for AttachedParts
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

        public enum AttachedParts 
        {

     [Description("Nothing, Empty")]
     NOTHING_EMPTY = 0,

     [Description("Sequential IDs for model-specific stations")]
     SEQUENTIAL_IDS_FOR_MODEL_SPECIFIC_STATIONS = 1,

     [Description("Fuselage Stations")]
     FUSELAGE_STATIONS = 512,

     [Description("Left-wing Stations")]
     LEFT_WING_STATIONS = 640,

     [Description("Right-wing Stations")]
     RIGHT_WING_STATIONS = 768,

     [Description("M16A42 rifle")]
     M16A42_RIFLE = 896,

     [Description("M249 SAW")]
     M249_SAW = 897,

     [Description("M60 Machine gun")]
     M60_MACHINE_GUN = 898,

     [Description("M203 Grenade Launcher")]
     M203_GRENADE_LAUNCHER = 899,

     [Description("M136 AT4")]
     M136_AT4 = 900,

     [Description("M47 Dragon")]
     M47_DRAGON = 901,

     [Description("AAWS-M Javelin")]
     AAWS_M_JAVELIN = 902,

     [Description("M18A1 Claymore Mine")]
     M18A1_CLAYMORE_MINE = 903,

     [Description("MK19 Grenade Launcher")]
     MK19_GRENADE_LAUNCHER = 904,

     [Description("M2 Machine Gun")]
     M2_MACHINE_GUN = 905,

     [Description("Other attached parts")]
     OTHER_ATTACHED_PARTS = 906
     }

    } //End Parial Class

} //End Namespace
