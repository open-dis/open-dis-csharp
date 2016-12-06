
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for CoordinateSystem
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

        public enum CoordinateSystem 
        {

     [Description("Right handed Cartesian (local topographic projection: east, north, up)")]
     RIGHT_HANDED_CARTESIAN_LOCAL_TOPOGRAPHIC_PROJECTION_EAST_NORTH_UP = 0,

     [Description("Left handed Cartesian (local topographic projection: east, north, down)")]
     LEFT_HANDED_CARTESIAN_LOCAL_TOPOGRAPHIC_PROJECTION_EAST_NORTH_DOWN = 1,

     [Description("Latitude, Longitude, Height")]
     LATITUDE_LONGITUDE_HEIGHT = 2,

     [Description("Latitude, Longitude, Depth")]
     LATITUDE_LONGITUDE_DEPTH = 3
     }

    } //End Parial Class

} //End Namespace
