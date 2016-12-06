
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for CISWeaponsForLifeForms
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

        public enum CISWeaponsForLifeForms 
        {

     [Description("Automatic (APS) 9-mm, Stechkin")]
     AUTOMATIC_APS_9_MM_STECHKIN = 201,

     [Description("PSM 5.45-mm")]
     PSM_545_MM = 202,

     [Description("Self-loading (PM) 9-mm, Makarov")]
     SELF_LOADING_PM_9_MM_MAKAROV = 203,

     [Description("TT-33 7.62-mm, Tokarev")]
     TT_33_762_MM_TOKAREV = 204,

     [Description("Assault rifle AK and AKM, 7.62-mm")]
     ASSAULT_RIFLE_AK_AND_AKM_762_MM = 205,

     [Description("Assault rifle AK-74 and AKS-74, 5.45-mm")]
     ASSAULT_RIFLE_AK_74_AND_AKS_74_545_MM = 206,

     [Description("Self-loading rifle (SKS), 7.62-mm, Simonov")]
     SELF_LOADING_RIFLE_SKS_762_MM_SIMONOV = 207,

     [Description("Sniper rifle SVD 7.62-mm, Dragunov")]
     SNIPER_RIFLE_SVD_762_MM_DRAGUNOV = 208,

     [Description("AKSU-74 5.45-mm")]
     AKSU_74_545_MM = 209,

     [Description("PPS-43 7.62-mm")]
     PPS_43_762_MM = 210,

     [Description("PPSh-41 7.62-mm")]
     PPSH_41_762_MM = 211,

     [Description("General purpose PK 7.62-mm")]
     GENERAL_PURPOSE_PK_762_MM = 212,

     [Description("Heavy DShK-38 and Model 38/46 12.7-mm, Degtyarev")]
     HEAVY_DSHK_38_AND_MODEL_38_46_127_MM_DEGTYAREV = 213,

     [Description("Heavy NSV 12.7-mm")]
     HEAVY_NSV_127_MM = 214,

     [Description("Light RPD 7.62-mm")]
     LIGHT_RPD_762_MM = 215,

     [Description("Light RPK 7.62-mm")]
     LIGHT_RPK_762_MM = 216,

     [Description("Light RPK-74 5.45-mm")]
     LIGHT_RPK_74_545_MM = 217,

     [Description("Hand grenade M75")]
     HAND_GRENADE_M75 = 218,

     [Description("Hand grenade RGD-5")]
     HAND_GRENADE_RGD_5 = 219,

     [Description("AP hand grenade F1")]
     AP_HAND_GRENADE_F1 = 220,

     [Description("AT hand grenade RKG-3")]
     AT_HAND_GRENADE_RKG_3 = 221,

     [Description("AT hand grenade RKG-3M")]
     AT_HAND_GRENADE_RKG_3M = 222,

     [Description("AT hand grenade RKG-3T")]
     AT_HAND_GRENADE_RKG_3T = 223,

     [Description("Fragmentation hand grenade RGN")]
     FRAGMENTATION_HAND_GRENADE_RGN = 224,

     [Description("Fragmentation hand grenade RGO")]
     FRAGMENTATION_HAND_GRENADE_RGO = 225,

     [Description("Smoke hand grenade RDG-1")]
     SMOKE_HAND_GRENADE_RDG_1 = 226,

     [Description("Plamya launcher, 30-mm AGS-17")]
     PLAMYA_LAUNCHER_30_MM_AGS_17 = 227,

     [Description("Rifle-mounted launcher, BG-15 40-mm")]
     RIFLE_MOUNTED_LAUNCHER_BG_15_40_MM = 228,

     [Description("LPO-50")]
     LPO_50 = 229,

     [Description("ROKS-3")]
     ROKS_3 = 230,

     [Description("Cart-mounted TPO-50")]
     CART_MOUNTED_TPO_50 = 231,

     [Description("Gimlet SA-16")]
     GIMLET_SA_16 = 232,

     [Description("Grail SA-7")]
     GRAIL_SA_7 = 233,

     [Description("Gremlin SA-14")]
     GREMLIN_SA_14 = 234,

     [Description("Sagger AT-3 (MCLOS)")]
     SAGGER_AT_3_MCLOS = 235,

     [Description("Saxhorn AT-7")]
     SAXHORN_AT_7 = 236,

     [Description("Spigot A/B AT-14")]
     SPIGOT_A_B_AT_14 = 237,

     [Description("SA-18")]
     SA_18 = 238,

     [Description("SA-19")]
     SA_19 = 239,

     [Description("Grad-1P manportable tripod rocket launcher, 122-mm (for Spesnatz and other specialists; aka 9P132)")]
     GRAD_1P_MANPORTABLE_TRIPOD_ROCKET_LAUNCHER_122_MM_FOR_SPESNATZ_AND_OTHER_SPECIALISTS_AKA_9P132 = 240,

     [Description("Light anti-armor weapon RPG-18")]
     LIGHT_ANTI_ARMOR_WEAPON_RPG_18 = 241,

     [Description("Light antitank weapon RPG-22")]
     LIGHT_ANTITANK_WEAPON_RPG_22 = 242,

     [Description("MG & RPG")]
     MG_RPG = 243,

     [Description("Portable rocket launcher RPG-16")]
     PORTABLE_ROCKET_LAUNCHER_RPG_16 = 244,

     [Description("Recoilless gun 73-mm SPG-9")]
     RECOILLESS_GUN_73_MM_SPG_9 = 245,

     [Description("VAT rocket launcher RPG-7")]
     VAT_ROCKET_LAUNCHER_RPG_7 = 246,

     [Description("Mon-50 antipersonnel mine")]
     MON_50_ANTIPERSONNEL_MINE = 248
     }

    } //End Parial Class

} //End Namespace
