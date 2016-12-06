
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for BeamFunction
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

        public enum BeamFunction 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Search")]
     SEARCH = 1,

     [Description("Height finder")]
     HEIGHT_FINDER = 2,

     [Description("Acquisition")]
     ACQUISITION = 3,

     [Description("Tracking")]
     TRACKING = 4,

     [Description("Acquisition and tracking")]
     ACQUISITION_AND_TRACKING = 5,

     [Description("Command guidance")]
     COMMAND_GUIDANCE = 6,

     [Description("Illumination")]
     ILLUMINATION = 7,

     [Description("Range only radar")]
     RANGE_ONLY_RADAR = 8,

     [Description("Missile beacon")]
     MISSILE_BEACON = 9,

     [Description("Missile fuze")]
     MISSILE_FUZE = 10,

     [Description("Active radar missile seeker")]
     ACTIVE_RADAR_MISSILE_SEEKER = 11,

     [Description("Jammer")]
     JAMMER = 12,

     [Description("IFF")]
     IFF = 13,

     [Description("Navigational / Weather")]
     NAVIGATIONAL_WEATHER = 14,

     [Description("Meteorological")]
     METEOROLOGICAL = 15,

     [Description("Data transmission")]
     DATA_TRANSMISSION = 16,

     [Description("Navigational directional beacon")]
     NAVIGATIONAL_DIRECTIONAL_BEACON = 17
     }

    } //End Parial Class

} //End Namespace
