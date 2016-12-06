
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for GeometryRecordTypeField
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

        public enum GeometryRecordTypeField 
        {

     [Description("Point Record 1")]
     POINT_RECORD_1 = 655360,

     [Description("Point Record 2")]
     POINT_RECORD_2 = 167772160,

     [Description("Line Record 1")]
     LINE_RECORD_1 = 786432,

     [Description("Line Record 2")]
     LINE_RECORD_2 = 201326592,

     [Description("Bounding Sphere Record")]
     BOUNDING_SPHERE_RECORD = 65536,

     [Description("Sphere Record 1")]
     SPHERE_RECORD_1 = 851968,

     [Description("Sphere Record 2")]
     SPHERE_RECORD_2 = 218103808,

     [Description("Ellipsoid Record 1")]
     ELLIPSOID_RECORD_1 = 1048576,

     [Description("Ellipsoid Record 2")]
     ELLIPSOID_RECORD_2 = 268435456,

     [Description("Cone Record 1")]
     CONE_RECORD_1 = 3145728,

     [Description("Cone Record 2")]
     CONE_RECORD_2 = 805306368,

     [Description("Uniform Geometry Record")]
     UNIFORM_GEOMETRY_RECORD = 327680,

     [Description("Rectangular Volume Record 1")]
     RECTANGULAR_VOLUME_RECORD_1 = 5242880,

     [Description("Rectangular Volume Record 2")]
     RECTANGULAR_VOLUME_RECORD_2 = 1342177280,

     [Description("Gaussian Plume Record")]
     GAUSSIAN_PLUME_RECORD = 1610612736,

     [Description("Gaussian Puff Record")]
     GAUSSIAN_PUFF_RECORD = 1879048192,

     [Description("Rectangular Volume Record 3")]
     RECTANGULAR_VOLUME_RECORD_3 = 83886080
     }

    } //End Parial Class

} //End Namespace
