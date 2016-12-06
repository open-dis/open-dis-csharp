
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for Warhead
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

        public enum Warhead 
        {

     [Description("Other")]
     OTHER = 0,

     [Description("Cargo (Variable Submunitions)")]
     CARGO_VARIABLE_SUBMUNITIONS = 10,

     [Description("Fuel/Air Explosive")]
     FUEL_AIR_EXPLOSIVE = 20,

     [Description("Glass Beads")]
     GLASS_BEADS = 30,

     [Description("1 um")]
     X_1_UM = 31,

     [Description("5 um")]
     X_5_UM = 32,

     [Description("10 um")]
     X_10_UM = 33,

     [Description("High Explosive (HE)")]
     HIGH_EXPLOSIVE_HE = 1000,

     [Description("HE, Plastic")]
     HE_PLASTIC = 1100,

     [Description("HE, Incendiary")]
     HE_INCENDIARY = 1200,

     [Description("HE, Fragmentation")]
     HE_FRAGMENTATION = 1300,

     [Description("HE, Antitank")]
     HE_ANTITANK = 1400,

     [Description("HE, Bomblets")]
     HE_BOMBLETS = 1500,

     [Description("HE, Shaped Charge")]
     HE_SHAPED_CHARGE = 1600,

     [Description("HE, Continuous Rod")]
     HE_CONTINUOUS_ROD = 1610,

     [Description("HE, Tungsten Ball")]
     HE_TUNGSTEN_BALL = 1615,

     [Description("HE, Blast Fragmentation")]
     HE_BLAST_FRAGMENTATION = 1620,

     [Description("HE, Steerable Darts with HE")]
     HE_STEERABLE_DARTS_WITH_HE = 1625,

     [Description("HE, Darts")]
     HE_DARTS = 1630,

     [Description("HE, Flechettes")]
     HE_FLECHETTES = 1635,

     [Description("HE, Directed Fragmentation")]
     HE_DIRECTED_FRAGMENTATION = 1640,

     [Description("HE, Semi-Armor Piercing (SAP)")]
     HE_SEMI_ARMOR_PIERCING_SAP = 1645,

     [Description("HE, Shaped Charge Fragmentation")]
     HE_SHAPED_CHARGE_FRAGMENTATION = 1650,

     [Description("HE, Semi-Armor Piercing, Fragmentation")]
     HE_SEMI_ARMOR_PIERCING_FRAGMENTATION = 1655,

     [Description("HE, Hollow Charge")]
     HE_HOLLOW_CHARGE = 1660,

     [Description("HE, Double Hollow Charge")]
     HE_DOUBLE_HOLLOW_CHARGE = 1665,

     [Description("HE, General Purpose")]
     HE_GENERAL_PURPOSE = 1670,

     [Description("HE, Blast Penetrator")]
     HE_BLAST_PENETRATOR = 1675,

     [Description("HE, Rod Penetrator")]
     HE_ROD_PENETRATOR = 1680,

     [Description("HE, Antipersonnel")]
     HE_ANTIPERSONNEL = 1685,

     [Description("Smoke")]
     SMOKE = 2000,

     [Description("Illumination")]
     ILLUMINATION = 3000,

     [Description("Practice")]
     PRACTICE = 4000,

     [Description("Kinetic")]
     KINETIC = 5000,

     [Description("Mines")]
     MINES = 6000,

     [Description("Nuclear")]
     NUCLEAR = 7000,

     [Description("Nuclear, IMT")]
     NUCLEAR_IMT = 7010,

     [Description("Chemical, General")]
     CHEMICAL_GENERAL = 8000,

     [Description("Chemical, Blister Agent")]
     CHEMICAL_BLISTER_AGENT = 8100,

     [Description("HD (Mustard)")]
     HD_MUSTARD = 8110,

     [Description("Thickened HD (Mustard)")]
     THICKENED_HD_MUSTARD = 8115,

     [Description("Dusty HD (Mustard)")]
     DUSTY_HD_MUSTARD = 8120,

     [Description("Chemical, Blood Agent")]
     CHEMICAL_BLOOD_AGENT = 8200,

     [Description("AC (HCN)")]
     AC_HCN = 8210,

     [Description("CK (CNCI)")]
     CK_CNCI = 8215,

     [Description("CG (Phosgene)")]
     CG_PHOSGENE = 8220,

     [Description("Chemical, Nerve Agent")]
     CHEMICAL_NERVE_AGENT = 8300,

     [Description("VX")]
     VX = 8310,

     [Description("Thickened VX")]
     THICKENED_VX = 8315,

     [Description("Dusty VX")]
     DUSTY_VX = 8320,

     [Description("GA (Tabun)")]
     GA_TABUN = 8325,

     [Description("Thickened GA (Tabun)")]
     THICKENED_GA_TABUN = 8330,

     [Description("Dusty GA (Tabun)")]
     DUSTY_GA_TABUN = 8335,

     [Description("GB (Sarin)")]
     GB_SARIN = 8340,

     [Description("Thickened GB (Sarin)")]
     THICKENED_GB_SARIN = 8345,

     [Description("Dusty GB (Sarin)")]
     DUSTY_GB_SARIN = 8350,

     [Description("GD (Soman)")]
     GD_SOMAN = 8355,

     [Description("Thickened GD (Soman)")]
     THICKENED_GD_SOMAN = 8360,

     [Description("Dusty GD (Soman)")]
     DUSTY_GD_SOMAN = 8365,

     [Description("GF")]
     GF = 8370,

     [Description("Thickened GF")]
     THICKENED_GF = 8375,

     [Description("Dusty GF")]
     DUSTY_GF = 8380,

     [Description("Biological")]
     BIOLOGICAL = 9000,

     [Description("Biological, Virus")]
     BIOLOGICAL_VIRUS = 9100,

     [Description("Biological, Bacteria")]
     BIOLOGICAL_BACTERIA = 9200,

     [Description("Biological, Rickettsia")]
     BIOLOGICAL_RICKETTSIA = 9300,

     [Description("Biological, Genetically Modified Micro-organisms")]
     BIOLOGICAL_GENETICALLY_MODIFIED_MICRO_ORGANISMS = 9400,

     [Description("Biological, Toxin")]
     BIOLOGICAL_TOXIN = 9500
     }

    } //End Parial Class

} //End Namespace
