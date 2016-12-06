
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for LifeSupportSystems
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

        public enum LifeSupportSystems 
        {

     [Description("air supply")]
     AIR_SUPPLY = 8000,

     [Description("filters")]
     FILTERS = 8010,

     [Description("water supply")]
     WATER_SUPPLY = 8020,

     [Description("refrigeration system")]
     REFRIGERATION_SYSTEM = 8030,

     [Description("chemical, biological, and radiological protection")]
     CHEMICAL_BIOLOGICAL_AND_RADIOLOGICAL_PROTECTION = 8040,

     [Description("water wash down systems")]
     WATER_WASH_DOWN_SYSTEMS = 8050,

     [Description("decontamination systems")]
     DECONTAMINATION_SYSTEMS = 8060,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 8070
     }

    } //End Parial Class

} //End Namespace
