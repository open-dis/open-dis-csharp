
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for SensorEmitterCategory
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

        public enum SensorEmitterCategory 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Multi-spectral")]
     MULTI_SPECTRAL = 1,

     [Description("RF Active")]
     RF_ACTIVE = 2,

     [Description("RF Passive (intercept and DF)")]
     RF_PASSIVE_INTERCEPT_AND_DF = 3,

     [Description("Optical (direct viewing with or without optics)")]
     OPTICAL_DIRECT_VIEWING_WITH_OR_WITHOUT_OPTICS = 4,

     [Description("Electro-Optical")]
     ELECTRO_OPTICAL = 5,

     [Description("Seismic")]
     SEISMIC = 6,

     [Description("Chemical, point detector")]
     CHEMICAL_POINT_DETECTOR = 7,

     [Description("Chemical, standoff")]
     CHEMICAL_STANDOFF = 8,

     [Description("Thermal (temperature sensing)")]
     THERMAL_TEMPERATURE_SENSING = 9,

     [Description("Acoustic, Active")]
     ACOUSTIC_ACTIVE = 10,

     [Description("Acoustic, Passive")]
     ACOUSTIC_PASSIVE = 11,

     [Description("Contact/Pressure (physical, hydrostatic, barometric)")]
     CONTACT_PRESSURE_PHYSICAL_HYDROSTATIC_BAROMETRIC = 12,

     [Description("Electro-Magnetic Radiation (gamma radiation)")]
     ELECTRO_MAGNETIC_RADIATION_GAMMA_RADIATION = 13,

     [Description("Particle Radiation (Neutrons, alpha, beta particles)")]
     PARTICLE_RADIATION_NEUTRONS_ALPHA_BETA_PARTICLES = 14,

     [Description("Magnetic")]
     MAGNETIC = 15,

     [Description("Gravitational")]
     GRAVITATIONAL = 16
     }

    } //End Parial Class

} //End Namespace
