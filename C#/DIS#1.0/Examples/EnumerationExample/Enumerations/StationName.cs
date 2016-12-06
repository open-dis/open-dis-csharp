
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for StationName
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

        public enum StationName 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Aircraft wingstation")]
     AIRCRAFT_WINGSTATION = 1,

     [Description("Ship's forward gunmount (starboard)")]
     SHIPS_FORWARD_GUNMOUNT_STARBOARD = 2,

     [Description("Ship's forward gunmount (port)")]
     SHIPS_FORWARD_GUNMOUNT_PORT = 3,

     [Description("Ship's forward gunmount (centerline)")]
     SHIPS_FORWARD_GUNMOUNT_CENTERLINE = 4,

     [Description("Ship's aft gunmount (starboard)")]
     SHIPS_AFT_GUNMOUNT_STARBOARD = 5,

     [Description("Ship's aft gunmount (port)")]
     SHIPS_AFT_GUNMOUNT_PORT = 6,

     [Description("Ship's aft gunmount (centerline)")]
     SHIPS_AFT_GUNMOUNT_CENTERLINE = 7,

     [Description("Forward torpedo tube")]
     FORWARD_TORPEDO_TUBE = 8,

     [Description("Aft torpedo tube")]
     AFT_TORPEDO_TUBE = 9,

     [Description("Bomb bay")]
     BOMB_BAY = 10,

     [Description("Cargo bay")]
     CARGO_BAY = 11,

     [Description("Truck bed")]
     TRUCK_BED = 12,

     [Description("Trailer bed")]
     TRAILER_BED = 13,

     [Description("Well deck")]
     WELL_DECK = 14,

     [Description("On station - (RNG/BRG)")]
     ON_STATION_RNG_BRG = 15,

     [Description("On station - (x,y,z)")]
     ON_STATION_XYZ = 16
     }

    } //End Parial Class

} //End Namespace
