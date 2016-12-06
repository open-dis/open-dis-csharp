
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for Optical
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

        public enum Optical 
        {

     [Description("Unaided Eye, Actively Searching")]
     UNAIDED_EYE_ACTIVELY_SEARCHING = 0,

     [Description("Unaided Eye, Not Actively Searching")]
     UNAIDED_EYE_NOT_ACTIVELY_SEARCHING = 1,

     [Description("Binoculars")]
     BINOCULARS = 2,

     [Description("Image Intensifier")]
     IMAGE_INTENSIFIER = 3,

     [Description("HMMWV occupant, Actively Searching")]
     HMMWV_OCCUPANT_ACTIVELY_SEARCHING = 4,

     [Description("HMMWV occupant, Not Actively Searching")]
     HMMWV_OCCUPANT_NOT_ACTIVELY_SEARCHING = 5,

     [Description("Truck occupant, Actively Searching")]
     TRUCK_OCCUPANT_ACTIVELY_SEARCHING = 6,

     [Description("Truck occupant, Not Actively Searching")]
     TRUCK_OCCUPANT_NOT_ACTIVELY_SEARCHING = 7,

     [Description("Tracked vehicle occupant, closed hatch, Actively Searching")]
     TRACKED_VEHICLE_OCCUPANT_CLOSED_HATCH_ACTIVELY_SEARCHING = 8,

     [Description("Tracked vehicle occupant, closed hatch, Not Actively Searching")]
     TRACKED_VEHICLE_OCCUPANT_CLOSED_HATCH_NOT_ACTIVELY_SEARCHING = 9,

     [Description("Tracked vehicle occupant, open hatch, Actively Searching")]
     TRACKED_VEHICLE_OCCUPANT_OPEN_HATCH_ACTIVELY_SEARCHING = 10,

     [Description("Tracked vehicle occupant, open hatch, Not Actively Searching")]
     TRACKED_VEHICLE_OCCUPANT_OPEN_HATCH_NOT_ACTIVELY_SEARCHING = 11
     }

    } //End Parial Class

} //End Namespace
