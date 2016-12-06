
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for Weapons
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

        public enum Weapons 
        {

     [Description("gun elevation drive")]
     GUN_ELEVATION_DRIVE = 2000,

     [Description("gun stabilization system")]
     GUN_STABILIZATION_SYSTEM = 2010,

     [Description("gunner's primary sight (GPS)")]
     GUNNERS_PRIMARY_SIGHT_GPS = 2020,

     [Description("commander's extension to the GPS")]
     COMMANDERS_EXTENSION_TO_THE_GPS = 2030,

     [Description("loading mechanism")]
     LOADING_MECHANISM = 2040,

     [Description("gunner's auxiliary sight")]
     GUNNERS_AUXILIARY_SIGHT = 2050,

     [Description("gunner's control panel")]
     GUNNERS_CONTROL_PANEL = 2060,

     [Description("gunner's control assembly handle(s)")]
     GUNNERS_CONTROL_ASSEMBLY_HANDLES = 2070,

     [Description("commander's control handles/assembly")]
     COMMANDERS_CONTROL_HANDLES_ASSEMBLY = 2090,

     [Description("commander's weapon station")]
     COMMANDERS_WEAPON_STATION = 2100,

     [Description("commander's independent thermal viewer (CITV)")]
     COMMANDERS_INDEPENDENT_THERMAL_VIEWER_CITV = 2110,

     [Description("general weapons")]
     GENERAL_WEAPONS = 2120,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 2121
     }

    } //End Parial Class

} //End Namespace
