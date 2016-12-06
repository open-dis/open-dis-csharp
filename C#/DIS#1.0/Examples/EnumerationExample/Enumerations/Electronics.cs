
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for Electronics
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

        public enum Electronics 
        {

     [Description("electronic warfare systems")]
     ELECTRONIC_WARFARE_SYSTEMS = 4500,

     [Description("detection systems")]
     DETECTION_SYSTEMS = 4600,

     [Description("radio frequency")]
     RADIO_FREQUENCY = 4610,

     [Description("microwave")]
     MICROWAVE = 4620,

     [Description("infrared")]
     INFRARED = 4630,

     [Description("laser")]
     LASER = 4640,

     [Description("range finders")]
     RANGE_FINDERS = 4700,

     [Description("range-only radar")]
     RANGE_ONLY_RADAR = 4710,

     [Description("laser range finder")]
     LASER_RANGE_FINDER = 4720,

     [Description("electronic systems")]
     ELECTRONIC_SYSTEMS = 4800,

     [Description("radio frequency")]
     RADIO_FREQUENCY_1 = 4810,

     [Description("microwave")]
     MICROWAVE_2 = 4820,

     [Description("infrared")]
     INFRARED_3 = 4830,

     [Description("laser")]
     LASER_4 = 4840,

     [Description("radios")]
     RADIOS = 5000,

     [Description("communication systems")]
     COMMUNICATION_SYSTEMS = 5010,

     [Description("intercoms")]
     INTERCOMS = 5100,

     [Description("encoders")]
     ENCODERS = 5200,

     [Description("encryption devices")]
     ENCRYPTION_DEVICES = 5250,

     [Description("decoders")]
     DECODERS = 5300,

     [Description("decryption devices")]
     DECRYPTION_DEVICES = 5350,

     [Description("computers")]
     COMPUTERS = 5500,

     [Description("navigation and control systems")]
     NAVIGATION_AND_CONTROL_SYSTEMS = 6000,

     [Description("fire control systems")]
     FIRE_CONTROL_SYSTEMS = 6500,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 6501
     }

    } //End Parial Class

} //End Namespace
