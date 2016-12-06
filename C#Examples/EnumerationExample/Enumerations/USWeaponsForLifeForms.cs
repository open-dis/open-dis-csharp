
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for USWeaponsForLifeForms
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

        public enum USWeaponsForLifeForms 
        {

     [Description("Assault machine pistol, KF-AMP")]
     ASSAULT_MACHINE_PISTOL_KF_AMP = 1,

     [Description("Automatic model 1911A1 .45")]
     AUTOMATIC_MODEL_1911A1_45 = 2,

     [Description("Combat Master Mark VI .45, Detronics")]
     COMBAT_MASTER_MARK_VI_45_DETRONICS = 3,

     [Description("De-cocker KP90DC .45")]
     DE_COCKER_KP90DC_45 = 4,

     [Description("De-cocker KP91DC .40")]
     DE_COCKER_KP91DC_40 = 5,

     [Description("General officer's Model 15 .45")]
     GENERAL_OFFICERS_MODEL_15_45 = 6,

     [Description("Nova 9-mm, LaFrance")]
     NOVA_9_MM_LAFRANCE = 7,

     [Description("Personal Defense Weapon MP5K-PDW 9-mm")]
     PERSONAL_DEFENSE_WEAPON_MP5K_PDW_9_MM = 8,

     [Description("Silenced Colt .45, LaFrance")]
     SILENCED_COLT_45_LAFRANCE = 9,

     [Description("5900-series 9-mm, Smith & Wesson (S&W)")]
     X_5900_SERIES_9_MM_SMITH_WESSON_SW = 10,

     [Description("M9")]
     M9 = 11,

     [Description("Model 1911A1, Springfield Armory")]
     MODEL_1911A1_SPRINGFIELD_ARMORY = 12,

     [Description("Model 2000 9-mm")]
     MODEL_2000_9_MM = 13,

     [Description("P-9 9-mm, Springfield Armory")]
     P_9_9_MM_SPRINGFIELD_ARMORY = 14,

     [Description("P-12 9-mm")]
     P_12_9_MM = 15,

     [Description("P-85 Mark II 9-mm, Ruger")]
     P_85_MARK_II_9_MM_RUGER = 16,

     [Description("Advanced Combat Rifle 5.56-mm, AAI")]
     ADVANCED_COMBAT_RIFLE_556_MM_AAI = 17,

     [Description("Commando assault rifle, Model 733 5.56-mm, Colt")]
     COMMANDO_ASSAULT_RIFLE_MODEL_733_556_MM_COLT = 18,

     [Description("Infantry rifle, Mini-14/20 GB 5.56-mm, Ruger")]
     INFANTRY_RIFLE_MINI_14_20_GB_556_MM_RUGER = 19,

     [Description("Mini-14 5.56-mm, Ruger")]
     MINI_14_556_MM_RUGER = 20,

     [Description("Mini Thirty 7.62-mm, Ruger")]
     MINI_THIRTY_762_MM_RUGER = 21,

     [Description("Semi-automatic model 82A2 .50, Barrett")]
     SEMI_AUTOMATIC_MODEL_82A2_50_BARRETT = 22,

     [Description("Sniper Weapon System M24 7.62-mm")]
     SNIPER_WEAPON_SYSTEM_M24_762_MM = 23,

     [Description("Sniping rifle M21, Springfield Armory")]
     SNIPING_RIFLE_M21_SPRINGFIELD_ARMORY = 24,

     [Description("Sniping rifle M40A1 7.62-mm")]
     SNIPING_RIFLE_M40A1_762_MM = 25,

     [Description("Sniping rifle M600 7.62-mm")]
     SNIPING_RIFLE_M600_762_MM = 26,

     [Description("AR-15 (M16) 5.56-mm")]
     AR_15_M16_556_MM = 27,

     [Description("M1 .30")]
     M1_30 = 28,

     [Description("M14 7.62-mm, NATO")]
     M14_762_MM_NATO = 29,

     [Description("M14 (M1A, M1A1-A1), Springfield Armory")]
     M14_M1A_M1A1_A1_SPRINGFIELD_ARMORY = 30,

     [Description("M14K assault rifle, LaFrance")]
     M14K_ASSAULT_RIFLE_LAFRANCE = 31,

     [Description("M16A2 assault rifle 5.56-mm, Colt")]
     M16A2_ASSAULT_RIFLE_556_MM_COLT = 32,

     [Description("M21 7.62-mm, U.S.")]
     M21_762_MM_US = 33,

     [Description("M77 Mark II 5.56-mm, Ruger")]
     M77_MARK_II_556_MM_RUGER = 34,

     [Description("M77V 7.62-mm, Ruger")]
     M77V_762_MM_RUGER = 35,

     [Description("S-16 7.62 x 36-mm, Grendel")]
     S_16_762_X_36_MM_GRENDEL = 36,

     [Description("SAR-8 7.62-mm")]
     SAR_8_762_MM = 37,

     [Description("SAR-4800 7.62-mm")]
     SAR_4800_762_MM = 38,

     [Description("Assault carbine M16K, LaFrance")]
     ASSAULT_CARBINE_M16K_LAFRANCE = 39,

     [Description("M1 .30")]
     M1_30_1 = 40,

     [Description("M4 (Model 720) 5.56-mm, Colt")]
     M4_MODEL_720_556_MM_COLT = 41,

     [Description("M-900 9-mm, Calico")]
     M_900_9_MM_CALICO = 42,

     [Description("AC-556F 5.56-mm, Ruger")]
     AC_556F_556_MM_RUGER = 43,

     [Description("M3 .45")]
     M3_45 = 44,

     [Description("M11, Cobray")]
     M11_COBRAY = 45,

     [Description("M951 9-mm, Calico")]
     M951_9_MM_CALICO = 46,

     [Description("MP5/10 10-mm")]
     MP5_10_10_MM = 47,

     [Description("9-mm, Colt")]
     X_9_MM_COLT = 48,

     [Description("Ingram")]
     INGRAM = 49,

     [Description("Externally powered (EPG) 7.62-mm, Ares")]
     EXTERNALLY_POWERED_EPG_762_MM_ARES = 50,

     [Description("GECAL 50")]
     GECAL_50 = 51,

     [Description("General purpose M60 7.62-mm")]
     GENERAL_PURPOSE_M60_762_MM = 52,

     [Description("Heavy M2HB-QCB .50, RAMO")]
     HEAVY_M2HB_QCB_50_RAMO = 53,

     [Description("Light assault M60E3 (Enhanced) 7.62-mm")]
     LIGHT_ASSAULT_M60E3_ENHANCED_762_MM = 54,

     [Description("Light M16A2 5.56-mm, Colt")]
     LIGHT_M16A2_556_MM_COLT = 55,

     [Description("Light 5.56-mm, Ares")]
     LIGHT_556_MM_ARES = 56,

     [Description("Lightweight M2 .50, RAMO")]
     LIGHTWEIGHT_M2_50_RAMO = 57,

     [Description("Lightweight assault M60E3 7.62-mm")]
     LIGHTWEIGHT_ASSAULT_M60E3_762_MM = 58,

     [Description("Minigun M134 7.62-mm, General Electric")]
     MINIGUN_M134_762_MM_GENERAL_ELECTRIC = 59,

     [Description("MG system MK19 Mod 3, 40-mm")]
     MG_SYSTEM_MK19_MOD_3_40_MM = 60,

     [Description("MG system (or kit) M2HB QCB .50, Saco Defense")]
     MG_SYSTEM_OR_KIT_M2HB_QCB_50_SACO_DEFENSE = 61,

     [Description("M1919A4 .30-cal, Browning")]
     M1919A4_30_CAL_BROWNING = 62,

     [Description(".50-cal, Browning")]
     X_50_CAL_BROWNING = 63,

     [Description("Colored-smoke hand grenade M18")]
     COLORED_SMOKE_HAND_GRENADE_M18 = 64,

     [Description("Colored-smoke grenades, Federal Laboratories")]
     COLORED_SMOKE_GRENADES_FEDERAL_LABORATORIES = 65,

     [Description("Infrared smoke grenade M76")]
     INFRARED_SMOKE_GRENADE_M76 = 66,

     [Description("Smoke hand grenade AN-M8 HC")]
     SMOKE_HAND_GRENADE_AN_M8_HC = 67,

     [Description("Delay fragmentation hand grenade M61")]
     DELAY_FRAGMENTATION_HAND_GRENADE_M61 = 68,

     [Description("Delay fragmentation hand grenade M67")]
     DELAY_FRAGMENTATION_HAND_GRENADE_M67 = 69,

     [Description("Impact fragmentation hand grenade M57")]
     IMPACT_FRAGMENTATION_HAND_GRENADE_M57 = 70,

     [Description("Impact fragmentation hand grenade M68")]
     IMPACT_FRAGMENTATION_HAND_GRENADE_M68 = 71,

     [Description("Incendiary hand grenade AN-M14 TH3")]
     INCENDIARY_HAND_GRENADE_AN_M14_TH3 = 72,

     [Description("Launcher I-M203 40-mm")]
     LAUNCHER_I_M203_40_MM = 73,

     [Description("Launcher M79 40-mm")]
     LAUNCHER_M79_40_MM = 74,

     [Description("Multiple grenade launcher MM-1 40-mm")]
     MULTIPLE_GRENADE_LAUNCHER_MM_1_40_MM = 75,

     [Description("Multi-shot portable flame weapon M202A2 66-mm")]
     MULTI_SHOT_PORTABLE_FLAME_WEAPON_M202A2_66_MM = 76,

     [Description("Portable ABC-M9-7")]
     PORTABLE_ABC_M9_7 = 77,

     [Description("Portable M2A1-7")]
     PORTABLE_M2A1_7 = 78,

     [Description("Portable M9E1-7")]
     PORTABLE_M9E1_7 = 79,

     [Description("Dragon medium anti-armor missile, M47, FGM-77A")]
     DRAGON_MEDIUM_ANTI_ARMOR_MISSILE_M47_FGM_77A = 80,

     [Description("Javelin AAWS-M")]
     JAVELIN_AAWS_M = 81,

     [Description("Light Antitank Weapon M72 (LAW II)")]
     LIGHT_ANTITANK_WEAPON_M72_LAW_II = 82,

     [Description("Redeye, FIM-43, General Dynamics")]
     REDEYE_FIM_43_GENERAL_DYNAMICS = 83,

     [Description("Saber dual-purpose missile system")]
     SABER_DUAL_PURPOSE_MISSILE_SYSTEM = 84,

     [Description("Stinger, FIM-92, General Dynamics")]
     STINGER_FIM_92_GENERAL_DYNAMICS = 85,

     [Description("TOW heavy antitank weapon")]
     TOW_HEAVY_ANTITANK_WEAPON = 86,

     [Description("Bear Trap AP device, Pancor")]
     BEAR_TRAP_AP_DEVICE_PANCOR = 87,

     [Description("Chain Gun automatic weapon EX-34 7.62-mm")]
     CHAIN_GUN_AUTOMATIC_WEAPON_EX_34_762_MM = 88,

     [Description("Close Assault Weapon System (CAWS), AAI")]
     CLOSE_ASSAULT_WEAPON_SYSTEM_CAWS_AAI = 89,

     [Description("CAWS, Olin/Heckler and Koch")]
     CAWS_OLIN_HECKLER_AND_KOCH = 90,

     [Description("Crossfire SAM Model 88")]
     CROSSFIRE_SAM_MODEL_88 = 91,

     [Description("Dragon and M16")]
     DRAGON_AND_M16 = 92,

     [Description("Firing port weapon M231, 5.56-mm, Colt")]
     FIRING_PORT_WEAPON_M231_556_MM_COLT = 93,

     [Description("Foxhole Digger Explosive Kit (EXFODA)")]
     FOXHOLE_DIGGER_EXPLOSIVE_KIT_EXFODA = 94,

     [Description("Infantry Support Weapon ASP-30 {RM} 30-mm")]
     INFANTRY_SUPPORT_WEAPON_ASP_30_RM_30_MM = 95,

     [Description("Jackhammer Mk 3-A2, Pancor")]
     JACKHAMMER_MK_3_A2_PANCOR = 96,

     [Description("Light anti-armor weapon M136 (AT4)")]
     LIGHT_ANTI_ARMOR_WEAPON_M136_AT4 = 97,

     [Description("M26A2")]
     M26A2 = 98,

     [Description("Master Key S")]
     MASTER_KEY_S = 99,

     [Description("Minigun 5.56-mm")]
     MINIGUN_556_MM = 100,

     [Description("Multipurpose Individual Munition (MPIM), Marquardt")]
     MULTIPURPOSE_INDIVIDUAL_MUNITION_MPIM_MARQUARDT = 101,

     [Description("Multipurpose weapon AT8")]
     MULTIPURPOSE_WEAPON_AT8 = 102,

     [Description("Recoilless rifle M40, M40A2, and M40A4; 106-mm")]
     RECOILLESS_RIFLE_M40_M40A2_AND_M40A4_106_MM = 103,

     [Description("Recoilless rifle M67, 90-mm")]
     RECOILLESS_RIFLE_M67_90_MM = 104,

     [Description("Revolver, SP 101")]
     REVOLVER_SP_101 = 105,

     [Description("Revolver, Super Redhawk .44 magnum, Ruger")]
     REVOLVER_SUPER_REDHAWK_44_MAGNUM_RUGER = 106,

     [Description("RAW rocket, 140-mm, Brunswick")]
     RAW_ROCKET_140_MM_BRUNSWICK = 107,

     [Description("Rifle-launcher Anti-Armor Munition (RAAM), Olin")]
     RIFLE_LAUNCHER_ANTI_ARMOR_MUNITION_RAAM_OLIN = 108,

     [Description("Rocket launcher M-20 3.5-in")]
     ROCKET_LAUNCHER_M_20_35_IN = 109,

     [Description("Rocket launcher, Enhanced M72 E series HEAT, 66-mm")]
     ROCKET_LAUNCHER_ENHANCED_M72_E_SERIES_HEAT_66_MM = 110,

     [Description("Selective fire weapon AC-556 5.56-mm, Ruger")]
     SELECTIVE_FIRE_WEAPON_AC_556_556_MM_RUGER = 111,

     [Description("Selective fire weapon AC-556F 5.56-mm, Ruger")]
     SELECTIVE_FIRE_WEAPON_AC_556F_556_MM_RUGER = 112,

     [Description("Shotgun M870 Mk 1 (U.S. Marine Corps), Remington")]
     SHOTGUN_M870_MK_1_US_MARINE_CORPS_REMINGTON = 113,

     [Description("SMAW Mk 193, 83-mm, McDonnell-Douglas")]
     SMAW_MK_193_83_MM_MCDONNELL_DOUGLAS = 114,

     [Description("SMAW-D: Disposable SMAW")]
     SMAW_D_DISPOSABLE_SMAW = 115,

     [Description("Squad Automatic Weapon (SAW) M249 5.56-mm")]
     SQUAD_AUTOMATIC_WEAPON_SAW_M249_556_MM = 116,

     [Description("Tactical Support Weapon 50/12, .50-cal, Peregrine")]
     TACTICAL_SUPPORT_WEAPON_50_12_50_CAL_PEREGRINE = 117,

     [Description("Telescoped Ammunition Revolver Gun (TARG) .50-cal, Ares")]
     TELESCOPED_AMMUNITION_REVOLVER_GUN_TARG_50_CAL_ARES = 118,

     [Description("Ultimate over-under combination, Ciener")]
     ULTIMATE_OVER_UNDER_COMBINATION_CIENER = 119,

     [Description("M18A1 Claymore mine")]
     M18A1_CLAYMORE_MINE = 120,

     [Description("Mortar 81-mm")]
     MORTAR_81_MM = 121,

     [Description("Machinegun M240 7.62mm")]
     MACHINEGUN_M240_762MM = 134
     }

    } //End Parial Class

} //End Namespace
