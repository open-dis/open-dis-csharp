
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for DeadReckoningAlgorithm
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

        public enum DeadReckoningAlgorithm 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Static (Entity does not move.)")]
     STATIC_ENTITY_DOES_NOT_MOVE = 1,

     [Description("DRM(F, P, W)")]
     DRMF_P_W = 2,

     [Description("DRM(R, P, W)")]
     DRMR_P_W = 3,

     [Description("DRM(R, V, W)")]
     DRMR_V_W = 4,

     [Description("DRM(F, V, W)")]
     DRMF_V_W = 5,

     [Description("DRM(F, P, B)")]
     DRMF_P_B = 6,

     [Description("DRM(R, P, B)")]
     DRMR_P_B = 7,

     [Description("DRM(R, V, B)")]
     DRMR_V_B = 8,

     [Description("DRM(F, V, B)")]
     DRMF_V_B = 9
     }

    } //End Parial Class

} //End Namespace
