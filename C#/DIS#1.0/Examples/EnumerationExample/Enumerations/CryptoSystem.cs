
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for CryptoSystem
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

        public enum CryptoSystem 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("KY-28")]
     KY_28 = 1,

     [Description("VINSON (KY-57, KY-58, SINCGARS ICOM)")]
     VINSON_KY_57_KY_58_SINCGARS_ICOM = 2,

     [Description("Narrow Spectrum Secure Voice (NSVE)")]
     NARROW_SPECTRUM_SECURE_VOICE_NSVE = 3,

     [Description("Wide Spectrum Secure Voice (WSVE)")]
     WIDE_SPECTRUM_SECURE_VOICE_WSVE = 4,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 5
     }

    } //End Parial Class

} //End Namespace
