
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for DetailedModAmpMod
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

        public enum DetailedModAmpMod 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("AFSK (Audio Frequency Shift Keying)")]
     AFSK_AUDIO_FREQUENCY_SHIFT_KEYING = 1,

     [Description("AM (Amplitude Modulation)")]
     AM_AMPLITUDE_MODULATION = 2,

     [Description("CW (Continuous Wave Modulation)")]
     CW_CONTINUOUS_WAVE_MODULATION = 3,

     [Description("DSB (Double Sideband)")]
     DSB_DOUBLE_SIDEBAND = 4,

     [Description("ISB (Independent Sideband)")]
     ISB_INDEPENDENT_SIDEBAND = 5,

     [Description("LSB (Single Band Suppressed Carrier, Lower Sideband Mode)")]
     LSB_SINGLE_BAND_SUPPRESSED_CARRIER_LOWER_SIDEBAND_MODE = 6,

     [Description("SSB-Full (Single Sideband Full Carrier)")]
     SSB_FULL_SINGLE_SIDEBAND_FULL_CARRIER = 7,

     [Description("SSB-Reduc (Single Band Reduced Carrier)")]
     SSB_REDUC_SINGLE_BAND_REDUCED_CARRIER = 8,

     [Description("USB (Single Band Suppressed Carrier, Upper Sideband Mode)")]
     USB_SINGLE_BAND_SUPPRESSED_CARRIER_UPPER_SIDEBAND_MODE = 9,

     [Description("VSB (Vestigial Sideband)")]
     VSB_VESTIGIAL_SIDEBAND = 10
     }

    } //End Parial Class

} //End Namespace
