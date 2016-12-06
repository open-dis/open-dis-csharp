
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for ArticulatedPartsOffsetNumber
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

        public enum ArticulatedPartsOffsetNumber 
        {

     [Description("Position")]
     POSITION = 1,

     [Description("Position Rate")]
     POSITION_RATE = 2,

     [Description("Extension")]
     EXTENSION = 3,

     [Description("Extension Rate")]
     EXTENSION_RATE = 4,

     [Description("X")]
     X = 5,

     [Description("X Rate")]
     X_RATE = 6,

     [Description("Y")]
     Y = 7,

     [Description("Y Rate")]
     Y_RATE = 8,

     [Description("Z")]
     Z = 9,

     [Description("Z Rate")]
     Z_RATE = 10,

     [Description("Azimuth")]
     AZIMUTH = 11,

     [Description("Azimuth Rate")]
     AZIMUTH_RATE = 12,

     [Description("Elevation")]
     ELEVATION = 13,

     [Description("Elevation Rate")]
     ELEVATION_RATE = 14,

     [Description("Rotation")]
     ROTATION = 15,

     [Description("Rotation Rate")]
     ROTATION_RATE = 16
     }

    } //End Parial Class

} //End Namespace
