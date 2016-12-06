
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for ElectromagneticEmitters
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

        public enum ElectromagneticEmitters 
        {

     [Description("1RL138")]
     X_1RL138 = 10,

     [Description("1226 DECCA MIL")]
     X_1226_DECCA_MIL = 45,

     [Description("9GR400")]
     X_9GR400 = 80,

     [Description("9GR600")]
     X_9GR600 = 90,

     [Description("9LV 200 TA")]
     X_9LV_200_TA = 135,

     [Description("9LV 200 TV")]
     X_9LV_200_TV = 180,

     [Description("Missing Description")]
     MISSING_DESCRIPTION = 225,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_1 = 270,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_2 = 315,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_3 = 360,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_4 = 405,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_5 = 450,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_6 = 495,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_7 = 540,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_8 = 585,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_9 = 630,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_10 = 675,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_11 = 720,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_12 = 765,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_13 = 810,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_14 = 855,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_15 = 900,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_16 = 945,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_17 = 990,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_18 = 1035,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_19 = 1080,

     [Description("AA-12 Seeker")]
     AA_12_SEEKER = 1095,

     [Description("Agave")]
     AGAVE = 1100,

     [Description("AGRION 15")]
     AGRION_15 = 1125,

     [Description("AI MK 23")]
     AI_MK_23 = 1170,

     [Description("AIDA II")]
     AIDA_II = 1215,

     [Description("Albatros MK2")]
     ALBATROS_MK2 = 1260,

     [Description("1L13-3 (55G6)")]
     X_1L13_3_55G6 = 1280,

     [Description("1L13-3 (55G6)")]
     X_1L13_3_55G6_20 = 1282,

     [Description("ANA SPS 502")]
     ANA_SPS_502 = 1305,

     [Description("ANRITSU Electric AR-30A")]
     ANRITSU_ELECTRIC_AR_30A = 1350,

     [Description("Antilope V")]
     ANTILOPE_V = 1395,

     [Description("AN/ALE-50")]
     AN_ALE_50 = 1400,

     [Description("AN/ALQ 99")]
     AN_ALQ_99 = 1440,

     [Description("AN/ALQ-100")]
     AN_ALQ_100 = 1485,

     [Description("AN/ALQ-101")]
     AN_ALQ_101 = 1530,

     [Description("AN/ALQ-119")]
     AN_ALQ_119 = 1575,

     [Description("AN/ALQ-122")]
     AN_ALQ_122 = 1585,

     [Description("AN/ALQ-126A")]
     AN_ALQ_126A = 1620,

     [Description("AN/ALQ-131")]
     AN_ALQ_131 = 1626,

     [Description("AN/ALQ-135C/D")]
     AN_ALQ_135C_D = 1628,

     [Description("AN/ALQ-144A(V)3")]
     AN_ALQ_144AV3 = 1630,

     [Description("AN/ALQ-153")]
     AN_ALQ_153 = 1632,

     [Description("AN/ALQ-155")]
     AN_ALQ_155 = 1634,

     [Description("AN/ALQ-161/A")]
     AN_ALQ_161_A = 1636,

     [Description("AN/ALQ-162")]
     AN_ALQ_162 = 1638,

     [Description("AN/ALQ-165")]
     AN_ALQ_165 = 1640,

     [Description("AN/ALQ-167")]
     AN_ALQ_167 = 1642,

     [Description("AN/ALQ-172(V)2")]
     AN_ALQ_172V2 = 1644,

     [Description("AN/ALQ-176")]
     AN_ALQ_176 = 1646,

     [Description("AN/ALQ-184")]
     AN_ALQ_184 = 1648,

     [Description("AN/ALQ-188")]
     AN_ALQ_188 = 1650,

     [Description("AN/ALR-56")]
     AN_ALR_56 = 1652,

     [Description("AN/ALR-69")]
     AN_ALR_69 = 1654,

     [Description("AN/ALT-16A")]
     AN_ALT_16A = 1656,

     [Description("AN/ALT-28")]
     AN_ALT_28 = 1658,

     [Description("AN/ALT-32A")]
     AN_ALT_32A = 1660,

     [Description("AN/APD 10")]
     AN_APD_10 = 1665,

     [Description("AN/APG 53")]
     AN_APG_53 = 1710,

     [Description("AN/APG 59")]
     AN_APG_59 = 1755,

     [Description("AN/APG-63")]
     AN_APG_63 = 1800,

     [Description("AN/APG-63(V)1")]
     AN_APG_63V1 = 1805,

     [Description("AN/APG-63(V)2")]
     AN_APG_63V2 = 1807,

     [Description("AN/APG-63(V)3")]
     AN_APG_63V3 = 1809,

     [Description("AN/APG 65")]
     AN_APG_65 = 1845,

     [Description("AN/APG-66")]
     AN_APG_66 = 1870,

     [Description("AN/APG 68")]
     AN_APG_68 = 1890,

     [Description("AN/APG 70")]
     AN_APG_70 = 1935,

     [Description("AN/APG-73")]
     AN_APG_73 = 1945,

     [Description("AN/APG-77")]
     AN_APG_77 = 1960,

     [Description("AN/APG-78")]
     AN_APG_78 = 1970,

     [Description("AN/APG-502")]
     AN_APG_502 = 1980,

     [Description("AN/APN-1")]
     AN_APN_1 = 2025,

     [Description("AN/APN-22")]
     AN_APN_22 = 2070,

     [Description("AN/APN 59")]
     AN_APN_59 = 2115,

     [Description("AN/APN-69")]
     AN_APN_69 = 2160,

     [Description("AN/APN-81")]
     AN_APN_81 = 2205,

     [Description("AN/APN-117")]
     AN_APN_117 = 2250,

     [Description("AN/APN-118")]
     AN_APN_118 = 2295,

     [Description("AN/APN-130")]
     AN_APN_130 = 2340,

     [Description("AN/APN-131")]
     AN_APN_131 = 2385,

     [Description("AN/APN-133")]
     AN_APN_133 = 2430,

     [Description("AN/APN-134")]
     AN_APN_134 = 2475,

     [Description("AN/APN-147")]
     AN_APN_147 = 2520,

     [Description("AN/APN-150")]
     AN_APN_150 = 2565,

     [Description("AN/APN-153")]
     AN_APN_153 = 2610,

     [Description("AN/APN 154")]
     AN_APN_154 = 2655,

     [Description("AN/APN-155")]
     AN_APN_155 = 2700,

     [Description("AN/APN-159")]
     AN_APN_159 = 2745,

     [Description("AN/APN-182")]
     AN_APN_182 = 2790,

     [Description("AN/APN-187")]
     AN_APN_187 = 2835,

     [Description("AN/APN-190")]
     AN_APN_190 = 2880,

     [Description("AN/APN 194")]
     AN_APN_194 = 2925,

     [Description("AN/APN-195")]
     AN_APN_195 = 2970,

     [Description("AN/APN-198")]
     AN_APN_198 = 3015,

     [Description("AN/APN-200")]
     AN_APN_200 = 3060,

     [Description("AN/APN 202")]
     AN_APN_202 = 3105,

     [Description("AN/APN-217")]
     AN_APN_217 = 3150,

     [Description("AN/APN-218")]
     AN_APN_218 = 3152,

     [Description("AN/APN-238")]
     AN_APN_238 = 3160,

     [Description("AN/APN-239")]
     AN_APN_239 = 3162,

     [Description("AN/APN-241")]
     AN_APN_241 = 3164,

     [Description("AN/APN-242")]
     AN_APN_242 = 3166,

     [Description("AN/APN-506")]
     AN_APN_506 = 3195,

     [Description("AN/APQ-72")]
     AN_APQ_72 = 3240,

     [Description("AN/APQ-99")]
     AN_APQ_99 = 3285,

     [Description("AN/APQ 100")]
     AN_APQ_100 = 3330,

     [Description("AN/APQ-102")]
     AN_APQ_102 = 3375,

     [Description("AN/APQ-109")]
     AN_APQ_109 = 3420,

     [Description("AN/APQ 113")]
     AN_APQ_113 = 3465,

     [Description("AN/APQ 120")]
     AN_APQ_120 = 3510,

     [Description("AN/APQ 126")]
     AN_APQ_126 = 3555,

     [Description("AN/APQ-128")]
     AN_APQ_128 = 3600,

     [Description("AN/APQ-129")]
     AN_APQ_129 = 3645,

     [Description("AN/APQ 148")]
     AN_APQ_148 = 3690,

     [Description("AN/APQ-153")]
     AN_APQ_153 = 3735,

     [Description("AN/APQ 159")]
     AN_APQ_159 = 3780,

     [Description("AN/APQ-164")]
     AN_APQ_164 = 3785,

     [Description("AN/APQ-166")]
     AN_APQ_166 = 3788,

     [Description("AN/APQ-181")]
     AN_APQ_181 = 3795,

     [Description("AN/APS-31")]
     AN_APS_31 = 3820,

     [Description("AN/APS-42")]
     AN_APS_42 = 3825,

     [Description("AN/APS 80")]
     AN_APS_80 = 3870,

     [Description("AN/APS-88")]
     AN_APS_88 = 3915,

     [Description("AN/APS 115")]
     AN_APS_115 = 3960,

     [Description("AN/APS 116")]
     AN_APS_116 = 4005,

     [Description("AN/APS-120")]
     AN_APS_120 = 4050,

     [Description("AN/APS 121")]
     AN_APS_121 = 4095,

     [Description("AN/APS 124")]
     AN_APS_124 = 4140,

     [Description("AN/APS 125")]
     AN_APS_125 = 4185,

     [Description("AN/APS-128")]
     AN_APS_128 = 4230,

     [Description("AN/APS 130")]
     AN_APS_130 = 4275,

     [Description("AN/APS 133")]
     AN_APS_133 = 4320,

     [Description("AN/APS-134")]
     AN_APS_134 = 4365,

     [Description("AN/APS 137")]
     AN_APS_137 = 4410,

     [Description("AN/APS-138")]
     AN_APS_138 = 4455,

     [Description("AN/APS-143 (V) 1")]
     AN_APS_143_V_1 = 4465,

     [Description("AN/APW 22")]
     AN_APW_22 = 4500,

     [Description("AN/APW 23")]
     AN_APW_23 = 4545,

     [Description("AN/APX-6")]
     AN_APX_6 = 4590,

     [Description("AN/APX 7")]
     AN_APX_7 = 4635,

     [Description("AN/APX 39")]
     AN_APX_39 = 4680,

     [Description("AN/APX-72")]
     AN_APX_72 = 4725,

     [Description("AN/APX 76")]
     AN_APX_76 = 4770,

     [Description("AN/APX 78")]
     AN_APX_78 = 4815,

     [Description("AN/APX 101")]
     AN_APX_101 = 4860,

     [Description("AN/APX-113 AIFF")]
     AN_APX_113_AIFF = 4870,

     [Description("AN/APY-1")]
     AN_APY_1 = 4900,

     [Description("AN/APY 2")]
     AN_APY_2 = 4905,

     [Description("AN/APY 3")]
     AN_APY_3 = 4950,

     [Description("AN/APY-8")]
     AN_APY_8 = 4953,

     [Description("AN/ARN 21")]
     AN_ARN_21 = 4995,

     [Description("AN/ARN 52")]
     AN_ARN_52 = 5040,

     [Description("AN/ARN 84")]
     AN_ARN_84 = 5085,

     [Description("AN/ARN 118")]
     AN_ARN_118 = 5130,

     [Description("AN/ARW 73")]
     AN_ARW_73 = 5175,

     [Description("AN/ASB 1")]
     AN_ASB_1 = 5220,

     [Description("AN/ASG 21")]
     AN_ASG_21 = 5265,

     [Description("AN/ASQ-108")]
     AN_ASQ_108 = 5280,

     [Description("AN/AWG 9")]
     AN_AWG_9 = 5310,

     [Description("AN/BPS-9")]
     AN_BPS_9 = 5355,

     [Description("AN/BPS 15")]
     AN_BPS_15 = 5400,

     [Description("AN/BPS-16")]
     AN_BPS_16 = 5405,

     [Description("AN/CRM-30")]
     AN_CRM_30 = 5420,

     [Description("AN/DPW-23")]
     AN_DPW_23 = 5430,

     [Description("AN/DSQ 26 Phoenix MH")]
     AN_DSQ_26_PHOENIX_MH = 5445,

     [Description("AN/DSQ 28 Harpoon MH")]
     AN_DSQ_28_HARPOON_MH = 5490,

     [Description("AN/FPN-40")]
     AN_FPN_40 = 5495,

     [Description("AN/FPN-62")]
     AN_FPN_62 = 5500,

     [Description("AN/FPS-16")]
     AN_FPS_16 = 5505,

     [Description("AN/FPS-18")]
     AN_FPS_18 = 5507,

     [Description("AN/FPS-89")]
     AN_FPS_89 = 5508,

     [Description("AN/FPS-117")]
     AN_FPS_117 = 5510,

     [Description("AN/FPS-20R")]
     AN_FPS_20R = 5515,

     [Description("AN/FPS-77")]
     AN_FPS_77 = 5520,

     [Description("AN/FPS-103")]
     AN_FPS_103 = 5525,

     [Description("AN/GPN-12")]
     AN_GPN_12 = 5527,

     [Description("AN/GPX-6")]
     AN_GPX_6 = 5530,

     [Description("AN/GPX 8")]
     AN_GPX_8 = 5535,

     [Description("AN/GRN-12")]
     AN_GRN_12 = 5537,

     [Description("AN/MPQ-10")]
     AN_MPQ_10 = 5540,

     [Description("AN/MPQ-33/39/46/57/61 (HPIR) ILL")]
     AN_MPQ_33_39_46_57_61_HPIR_ILL = 5545,

     [Description("AN/MPQ-34/48/55/62 (CWAR) TA")]
     AN_MPQ_34_48_55_62_CWAR_TA = 5550,

     [Description("AN/MPQ-49")]
     AN_MPQ_49 = 5551,

     [Description("AN/MPQ-35/50 (PAR) TA")]
     AN_MPQ_35_50_PAR_TA = 5555,

     [Description("AN/MPQ-37/51 (ROR) TT")]
     AN_MPQ_37_51_ROR_TT = 5560,

     [Description("AN/MPQ-53")]
     AN_MPQ_53 = 5570,

     [Description("AN/MPQ-63")]
     AN_MPQ_63 = 5571,

     [Description("AN/MPQ-64")]
     AN_MPQ_64 = 5575,

     [Description("AN/SPG-34")]
     AN_SPG_34 = 5580,

     [Description("AN/SPG 50")]
     AN_SPG_50 = 5625,

     [Description("AN/SPG 51")]
     AN_SPG_51 = 5670,

     [Description("AN/SPG-51 CWI TI")]
     AN_SPG_51_CWI_TI = 5715,

     [Description("AN/SPG-51 FC")]
     AN_SPG_51_FC = 5760,

     [Description("AN/SPG 52")]
     AN_SPG_52 = 5805,

     [Description("AN/SPG-53")]
     AN_SPG_53 = 5850,

     [Description("AN/SPG 55B")]
     AN_SPG_55B = 5895,

     [Description("AN/SPG 60")]
     AN_SPG_60 = 5940,

     [Description("AN/SPG 62")]
     AN_SPG_62 = 5985,

     [Description("AN/SPN 35")]
     AN_SPN_35 = 6030,

     [Description("AN/SPN 43")]
     AN_SPN_43 = 6075,

     [Description("AN/SPQ-2")]
     AN_SPQ_2 = 6120,

     [Description("AN/SPQ 9")]
     AN_SPQ_9 = 6165,

     [Description("AN/SPS-4")]
     AN_SPS_4 = 6210,

     [Description("AN/SPS-5")]
     AN_SPS_5 = 6255,

     [Description("AN/SPS-5C")]
     AN_SPS_5C = 6300,

     [Description("AN/SPS-6")]
     AN_SPS_6 = 6345,

     [Description("AN/SPS 10")]
     AN_SPS_10 = 6390,

     [Description("AN/SPS 21")]
     AN_SPS_21 = 6435,

     [Description("AN/SPS-28")]
     AN_SPS_28 = 6480,

     [Description("AN/SPS-37")]
     AN_SPS_37 = 6525,

     [Description("AN/SPS-39A")]
     AN_SPS_39A = 6570,

     [Description("AN/SPS 40")]
     AN_SPS_40 = 6615,

     [Description("AN/SPS-41")]
     AN_SPS_41 = 6660,

     [Description("AN/SPS-48")]
     AN_SPS_48 = 6705,

     [Description("AN/SPS-48C")]
     AN_SPS_48C = 6750,

     [Description("AN/SPS-48E")]
     AN_SPS_48E = 6752,

     [Description("AN/SPS-49")]
     AN_SPS_49 = 6795,

     [Description("AN/SPS-49(V)1")]
     AN_SPS_49V1 = 6796,

     [Description("AN/SPS-49(V)2")]
     AN_SPS_49V2 = 6797,

     [Description("AN/SPS-49(V)3")]
     AN_SPS_49V3 = 6798,

     [Description("AN/SPS-49(V)4")]
     AN_SPS_49V4 = 6799,

     [Description("AN/SPS-49(V)5")]
     AN_SPS_49V5 = 6800,

     [Description("AN/SPS-49(V)6")]
     AN_SPS_49V6 = 6801,

     [Description("AN/SPS-49(V)7")]
     AN_SPS_49V7 = 6802,

     [Description("AN/SPS-49(V)8")]
     AN_SPS_49V8 = 6803,

     [Description("AN/SPS-49A(V)1")]
     AN_SPS_49AV1 = 6804,

     [Description("AN/SPS 52")]
     AN_SPS_52 = 6840,

     [Description("AN/SPS 53")]
     AN_SPS_53 = 6885,

     [Description("AN/SPS 55")]
     AN_SPS_55 = 6930,

     [Description("AN/SPS-55 SS")]
     AN_SPS_55_SS = 6975,

     [Description("AN/SPS-58")]
     AN_SPS_58 = 7020,

     [Description("AN/SPS 59")]
     AN_SPS_59 = 7065,

     [Description("AN/SPS 64")]
     AN_SPS_64 = 7110,

     [Description("AN/SPS 65")]
     AN_SPS_65 = 7155,

     [Description("AN/SPS 67")]
     AN_SPS_67 = 7200,

     [Description("AN/SPY-1")]
     AN_SPY_1 = 7245,

     [Description("AN/SPY-1A")]
     AN_SPY_1A = 7250,

     [Description("AN/SPY-1B")]
     AN_SPY_1B = 7252,

     [Description("AN/SPY-1B(V)")]
     AN_SPY_1BV = 7253,

     [Description("AN/SPY-1D")]
     AN_SPY_1D = 7260,

     [Description("AN/SPY-1D(V)")]
     AN_SPY_1DV = 7261,

     [Description("AN/SPY-1F")]
     AN_SPY_1F = 7265,

     [Description("AN/TPN-17")]
     AN_TPN_17 = 7270,

     [Description("AN/TPN-24")]
     AN_TPN_24 = 7275,

     [Description("AN/TPQ-18")]
     AN_TPQ_18 = 7280,

     [Description("AN/TPQ-36")]
     AN_TPQ_36 = 7295,

     [Description("AN/TPQ-37")]
     AN_TPQ_37 = 7300,

     [Description("AN/TPQ-38 (V8)")]
     AN_TPQ_38_V8 = 7301,

     [Description("AN/TPQ-47")]
     AN_TPQ_47 = 7303,

     [Description("AN/TPS-43")]
     AN_TPS_43 = 7305,

     [Description("AN/TPS-43E")]
     AN_TPS_43E = 7310,

     [Description("AN/TPS-59")]
     AN_TPS_59 = 7315,

     [Description("AN/TPS-63")]
     AN_TPS_63 = 7320,

     [Description("AN/TPS-70 (V) 1")]
     AN_TPS_70_V_1 = 7322,

     [Description("AN/TPS-75")]
     AN_TPS_75 = 7325,

     [Description("AN/TPX-46(V)7")]
     AN_TPX_46V7 = 7330,

     [Description("AN/ULQ-6A")]
     AN_ULQ_6A = 7335,

     [Description("AN/UPN 25")]
     AN_UPN_25 = 7380,

     [Description("AN/UPS 1")]
     AN_UPS_1 = 7425,

     [Description("AN/UPS-2")]
     AN_UPS_2 = 7426,

     [Description("AN/UPX 1")]
     AN_UPX_1 = 7470,

     [Description("AN/UPX 5")]
     AN_UPX_5 = 7515,

     [Description("AN/UPX 11")]
     AN_UPX_11 = 7560,

     [Description("AN/UPX 12")]
     AN_UPX_12 = 7605,

     [Description("AN/UPX 17")]
     AN_UPX_17 = 7650,

     [Description("AN/UPX 23")]
     AN_UPX_23 = 7695,

     [Description("AN/VPS 2")]
     AN_VPS_2 = 7740,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_21 = 7785,

     [Description("APG 71")]
     APG_71 = 7830,

     [Description("APN 148")]
     APN_148 = 7875,

     [Description("APN 227")]
     APN_227 = 7920,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_22 = 7965,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_23 = 8010,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_24 = 8055,

     [Description("APS 504 V3")]
     APS_504_V3 = 8100,

     [Description("AR 3D")]
     AR_3D = 8105,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_25 = 8112,

     [Description("AR 320")]
     AR_320 = 8115,

     [Description("AR 327")]
     AR_327 = 8120,

     [Description("AR M31")]
     AR_M31 = 8145,

     [Description("ARI 5954")]
     ARI_5954 = 8190,

     [Description("ARI 5955")]
     ARI_5955 = 8235,

     [Description("ARI 5979")]
     ARI_5979 = 8280,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_26 = 8325,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_27 = 8370,

     [Description("ARK-1")]
     ARK_1 = 8375,

     [Description("ARSR-3")]
     ARSR_3 = 8380,

     [Description("ARSR-18")]
     ARSR_18 = 8390,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_28 = 8415,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_29 = 8460,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_30 = 8505,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_31 = 8550,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_32 = 8595,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_33 = 8640,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_34 = 8685,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_35 = 8730,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_36 = 8735,

     [Description("Aspide AAM/SAM ILL")]
     ASPIDE_AAM_SAM_ILL = 8760,

     [Description("ASR-4")]
     ASR_4 = 8772,

     [Description("ASR O")]
     ASR_O = 8775,

     [Description("ASR-5")]
     ASR_5 = 8780,

     [Description("ASR-7")]
     ASR_7 = 8782,

     [Description("ASR-8")]
     ASR_8 = 8785,

     [Description("ASR-9")]
     ASR_9 = 8790,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_37 = 8812,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_38 = 8820,

     [Description("ATCR-33")]
     ATCR_33 = 8840,

     [Description("ATCR 33 K/M")]
     ATCR_33_K_M = 8845,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_39 = 8865,

     [Description("ATLAS-9740 VTS")]
     ATLAS_9740_VTS = 8870,

     [Description("AVG 65")]
     AVG_65 = 8910,

     [Description("AVH 7")]
     AVH_7 = 8955,

     [Description("AVQ 20")]
     AVQ_20 = 9000,

     [Description("AVQ30X")]
     AVQ30X = 9045,

     [Description("AVQ-50 (RCA)")]
     AVQ_50_RCA = 9075,

     [Description("AVQ 70")]
     AVQ_70 = 9090,

     [Description("AWS 5")]
     AWS_5 = 9135,

     [Description("AWS 6")]
     AWS_6 = 9180,

     [Description("B597Z")]
     B597Z = 9200,

     [Description("B636Z")]
     B636Z = 9205,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_40 = 9225,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_41 = 9270,

     [Description("BALTYK")]
     BALTYK = 9310,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_42 = 9315,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_43 = 9360,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_44 = 9405,

     [Description("P-35/37 (A); P-50 (B)")]
     P_35_37_A_P_50_B = 9450,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_45 = 9495,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_46 = 9540,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_47 = 9585,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_48 = 9630,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_49 = 9640,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_50 = 9642,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_51 = 9645,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_52 = 9660,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_53 = 9675,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_54 = 9720,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_55 = 9765,

     [Description("SNAR-10")]
     SNAR_10 = 9780,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_56 = 9810,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_57 = 9855,

     [Description("9S15MT")]
     X_9S15MT = 9885,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_58 = 9900,

     [Description("Blowpipe MG")]
     BLOWPIPE_MG = 9905,

     [Description("Blue Fox")]
     BLUE_FOX = 9930,

     [Description("Blue Vixen")]
     BLUE_VIXEN = 9935,

     [Description("Blue Silk")]
     BLUE_SILK = 9945,

     [Description("Blue Parrot")]
     BLUE_PARROT = 9990,

     [Description("Blue Orchid")]
     BLUE_ORCHID = 10035,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_59 = 10080,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_60 = 10125,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_61 = 10170,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_62 = 10215,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_63 = 10260,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_64 = 10305,

     [Description("BPS 11A")]
     BPS_11A = 10350,

     [Description("BPS 14")]
     BPS_14 = 10395,

     [Description("BPS 15A")]
     BPS_15A = 10440,

     [Description("BR-15 Tokyo KEIKI")]
     BR_15_TOKYO_KEIKI = 10485,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_65 = 10510,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_66 = 10530,

     [Description("BT 271")]
     BT_271 = 10575,

     [Description("BX 732")]
     BX_732 = 10620,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_67 = 10665,

     [Description("C 5A Multi Mode Radar")]
     C_5A_MULTI_MODE_RADAR = 10710,

     [Description("Caiman")]
     CAIMAN = 10755,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_68 = 10800,

     [Description("Calypso C61")]
     CALYPSO_C61 = 10845,

     [Description("Calypso Ii")]
     CALYPSO_II = 10890,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_69 = 10895,

     [Description("Castor Ii")]
     CASTOR_II = 10935,

     [Description("Castor 2J TT (Crotale NG)")]
     CASTOR_2J_TT_CROTALE_NG = 10940,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_70 = 10980,

     [Description("CDR-431")]
     CDR_431 = 10985,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_71 = 11000,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_72 = 11010,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_73 = 11025,

     [Description("Clam Pipe")]
     CLAM_PIPE = 11070,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_74 = 11115,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_75 = 11160,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_76 = 11205,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_77 = 11250,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_78 = 11260,

     [Description("CR-105 RMCA")]
     CR_105_RMCA = 11270,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_79 = 11295,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_80 = 11340,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_81 = 11385,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_82 = 11430,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_83 = 11475,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_84 = 11520,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_85 = 11565,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_86 = 11610,

     [Description("Crotale Acquisition TA")]
     CROTALE_ACQUISITION_TA = 11655,

     [Description("Crotale NG TA")]
     CROTALE_NG_TA = 11660,

     [Description("Crotale TT")]
     CROTALE_TT = 11665,

     [Description("Crotale MGMissile System")]
     CROTALE_MGMISSILE_SYSTEM = 11700,

     [Description("CSS C 3C CAS 1M1 M2 MH")]
     CSS_C_3C_CAS_1M1_M2_MH = 11745,

     [Description("CSS C 2B HY 1A MH")]
     CSS_C_2B_HY_1A_MH = 11790,

     [Description("CWS 2")]
     CWS_2 = 11835,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_87 = 11880,

     [Description("Cyrano II")]
     CYRANO_II = 11925,

     [Description("Cyrano IV")]
     CYRANO_IV = 11970,

     [Description("Cyrano IV-M")]
     CYRANO_IV_M = 11975,

     [Description("DA-01/00")]
     DA_01_00 = 12010,

     [Description("DA 05 00")]
     DA_05_00 = 12015,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_88 = 12060,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_89 = 12105,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_90 = 12110,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_91 = 12111,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_92 = 12150,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_93 = 12195,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_94 = 12240,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_95 = 12285,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_96 = 12292,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_97 = 12330,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_98 = 12375,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_99 = 12420,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_100 = 12430,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_101 = 12465,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_102 = 12510,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_103 = 12555,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_104 = 12600,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_105 = 12610,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_106 = 12645,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_107 = 12690,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_108 = 12735,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_109 = 12780,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_110 = 12782,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_111 = 12785,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_112 = 12787,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_113 = 12800,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_114 = 12805,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_115 = 12825,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_116 = 12870,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_117 = 12915,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_118 = 12960,

     [Description("DISS 1")]
     DISS_1 = 13005,

     [Description("Rapier TTDN 181")]
     RAPIER_TTDN_181 = 13050,

     [Description("Rapier 2000 TT")]
     RAPIER_2000_TT = 13055,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_119 = 13095,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_120 = 13140,

     [Description("Don 2")]
     DON_2 = 13185,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_121 = 13230,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_122 = 13275,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_123 = 13320,

     [Description("DRAA 2A")]
     DRAA_2A = 13365,

     [Description("DRAA 2B")]
     DRAA_2B = 13410,

     [Description("DRAC 39")]
     DRAC_39 = 13455,

     [Description("DRBC 30B")]
     DRBC_30B = 13500,

     [Description("DRBC 31A")]
     DRBC_31A = 13545,

     [Description("DRBC 32A")]
     DRBC_32A = 13590,

     [Description("DRBC 32D")]
     DRBC_32D = 13635,

     [Description("DRBC 33A")]
     DRBC_33A = 13680,

     [Description("DRBI 10")]
     DRBI_10 = 13725,

     [Description("DRBI 23")]
     DRBI_23 = 13770,

     [Description("DRBJ 11B")]
     DRBJ_11B = 13815,

     [Description("DRBN 30")]
     DRBN_30 = 13860,

     [Description("DRBN 32")]
     DRBN_32 = 13905,

     [Description("DRBR 51")]
     DRBR_51 = 13950,

     [Description("DRBV 20B")]
     DRBV_20B = 13995,

     [Description("DRBV 22")]
     DRBV_22 = 14040,

     [Description("DRBV 26C")]
     DRBV_26C = 14085,

     [Description("DRBV 30")]
     DRBV_30 = 14130,

     [Description("DRBV 50")]
     DRBV_50 = 14175,

     [Description("DRBV 51")]
     DRBV_51 = 14220,

     [Description("DRBV 51A")]
     DRBV_51A = 14265,

     [Description("DRBV 51B")]
     DRBV_51B = 14310,

     [Description("DRBV 51C")]
     DRBV_51C = 14355,

     [Description("Drop Kick")]
     DROP_KICK = 14400,

     [Description("DRUA 31")]
     DRUA_31 = 14445,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_124 = 14490,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_125 = 14535,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_126 = 14545,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_127 = 14580,

     [Description("ECR-90")]
     ECR_90 = 14600,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_128 = 14625,

     [Description("EKCO 190")]
     EKCO_190 = 14670,

     [Description("EL M 2001B")]
     EL_M_2001B = 14715,

     [Description("EL M 2207")]
     EL_M_2207 = 14760,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_129 = 14770,

     [Description("ELTA EL/M 2221 GM STGR")]
     ELTA_EL_M_2221_GM_STGR = 14805,

     [Description("ELTA SIS")]
     ELTA_SIS = 14810,

     [Description("EMD 2900")]
     EMD_2900 = 14850,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_130 = 14895,

     [Description("Exocet 1")]
     EXOCET_1 = 14940,

     [Description("Exocet 1 MH")]
     EXOCET_1_MH = 14985,

     [Description("Exocet 2")]
     EXOCET_2 = 15030,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_131 = 15075,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_132 = 15120,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_133 = 15140,

     [Description("FALCON")]
     FALCON = 15160,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_134 = 15165,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_135 = 15200,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_136 = 15210,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_137 = 15220,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_138 = 15230,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_139 = 15240,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_140 = 15255,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_141 = 15300,

     [Description("FCR-1401")]
     FCR_1401 = 15310,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_142 = 15345,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_143 = 15390,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_144 = 15435,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_145 = 15470,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_146 = 15475,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_147 = 15480,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_148 = 15525,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_149 = 15570,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_150 = 15615,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_151 = 15660,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_152 = 15705,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_153 = 15750,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_154 = 15795,

     [Description("P-15")]
     P_15 = 15840,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_155 = 15885,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_156 = 15930,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_157 = 15975,

     [Description("Fledermaus")]
     FLEDERMAUS = 16020,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_158 = 16030,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_159 = 16065,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_160 = 16110,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_161 = 16155,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_162 = 16200,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_163 = 16245,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_164 = 16290,

     [Description("Fox Hunter")]
     FOX_HUNTER = 16335,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_165 = 16380,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_166 = 16390,

     [Description("FR-151A")]
     FR_151A = 16400,

     [Description("FR-1505 DA")]
     FR_1505_DA = 16410,

     [Description("FR-2000")]
     FR_2000 = 16420,

     [Description("FR-2855W")]
     FR_2855W = 16421,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_167 = 16425,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_168 = 16470,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_169 = 16515,

     [Description("Furuno")]
     FURUNO = 16560,

     [Description("Furuno 1721")]
     FURUNO_1721 = 16561,

     [Description("Furuno 701")]
     FURUNO_701 = 16605,

     [Description("Furuno 711 2")]
     FURUNO_711_2 = 16650,

     [Description("Furuno 2400")]
     FURUNO_2400 = 16695,

     [Description("GA 01 00")]
     GA_01_00 = 16740,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_170 = 16785,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_171 = 16830,

     [Description("GEM BX 132")]
     GEM_BX_132 = 16875,

     [Description("MPDR-12")]
     MPDR_12 = 16880,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_172 = 16884,

     [Description("GERAN-F")]
     GERAN_F = 16888,

     [Description("GIRAFFE")]
     GIRAFFE = 16900,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_173 = 16915,

     [Description("Gin Sling")]
     GIN_SLING = 16920,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_174 = 16925,

     [Description("GPN-22")]
     GPN_22 = 16945,

     [Description("GRN-9")]
     GRN_9 = 16950,

     [Description("Green Stain")]
     GREEN_STAIN = 16965,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_175 = 17010,

     [Description("9S32")]
     X_9S32 = 17025,

     [Description("Guardsman")]
     GUARDSMAN = 17055,

     [Description("RPK-2")]
     RPK_2 = 17070,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_176 = 17100,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_177 = 17145,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_178 = 17190,

     [Description("HARD")]
     HARD = 17220,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_179 = 17235,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_180 = 17280,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_181 = 17325,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_182 = 17370,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_183 = 17415,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_184 = 17460,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_185 = 17505,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_186 = 17550,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_187 = 17595,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_188 = 17640,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_189 = 17685,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_190 = 17730,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_191 = 17775,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_192 = 17820,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_193 = 17865,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_194 = 17910,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_195 = 17955,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_196 = 18000,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_197 = 18045,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_198 = 18090,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_199 = 18135,

     [Description("9S19MT")]
     X_9S19MT = 18150,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_200 = 18180,

     [Description("HN-503")]
     HN_503 = 18200,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_201 = 18225,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_202 = 18270,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_203 = 18280,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_204 = 18315,

     [Description("IRL144M")]
     IRL144M = 18320,

     [Description("IRL144M")]
     IRL144M_205 = 18325,

     [Description("IRL144M")]
     IRL144M_206 = 18330,

     [Description("IFF MK XII AIMS UPX 29")]
     IFF_MK_XII_AIMS_UPX_29 = 18360,

     [Description("IFF MK XV")]
     IFF_MK_XV = 18405,

     [Description("Javelin MG")]
     JAVELIN_MG = 18410,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_207 = 18450,

     [Description("JRC-NMD-401")]
     JRC_NMD_401 = 18460,

     [Description("Jupiter")]
     JUPITER = 18495,

     [Description("Jupiter II")]
     JUPITER_II = 18540,

     [Description("JY-8")]
     JY_8 = 18550,

     [Description("JY-9")]
     JY_9 = 18555,

     [Description("JY-14")]
     JY_14 = 18560,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_208 = 18585,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_209 = 18630,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_210 = 18675,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_211 = 18720,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_212 = 18765,

     [Description("KH-902M")]
     KH_902M = 18785,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_213 = 18810,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_214 = 18855,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_215 = 18900,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_216 = 18945,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_217 = 18990,

     [Description("P-10")]
     P_10 = 19035,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_218 = 19037,

     [Description("KR-75")]
     KR_75 = 19050,

     [Description("KSA SRN")]
     KSA_SRN = 19080,

     [Description("KSA TSR")]
     KSA_TSR = 19125,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_219 = 19170,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_220 = 19215,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_221 = 19260,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_222 = 19305,

     [Description("LC-150")]
     LC_150 = 19310,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_223 = 19350,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_224 = 19395,

     [Description("LMT NRAI-6A")]
     LMT_NRAI_6A = 19400,

     [Description("LN 55")]
     LN_55 = 19440,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_225 = 19485,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_226 = 19530,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_227 = 19575,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_228 = 19620,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_229 = 19665,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_230 = 19710,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_231 = 19755,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_232 = 19800,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_233 = 19845,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_234 = 19890,

     [Description("LORAN")]
     LORAN = 19935,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_235 = 19950,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_236 = 19955,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_237 = 19960,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_238 = 19980,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_239 = 20025,

     [Description("TRS-2050")]
     TRS_2050 = 20040,

     [Description("LW 08")]
     LW_08 = 20070,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_240 = 20090,

     [Description("M22-40")]
     M22_40 = 20115,

     [Description("M44")]
     M44 = 20160,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_241 = 20205,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_242 = 20250,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_243 = 20295,

     [Description("MA 1 IFF Portion")]
     MA_1_IFF_PORTION = 20340,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_244 = 20360,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_245 = 20385,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_246 = 20430,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_247 = 20475,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_248 = 20495,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_249 = 20520,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_250 = 20530,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_251 = 20565,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_252 = 20585,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_253 = 20610,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_254 = 20655,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_255 = 20700,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_256 = 20745,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_257 = 20790,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_258 = 20835,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_259 = 20880,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_260 = 20925,

     [Description("Mirage ILL")]
     MIRAGE_ILL = 20950,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_261 = 20970,

     [Description("MK-23")]
     MK_23 = 21015,

     [Description("MK 23 TAS")]
     MK_23_TAS = 21060,

     [Description("MK 25")]
     MK_25 = 21105,

     [Description("MK-35 M2")]
     MK_35_M2 = 21150,

     [Description("MK 92")]
     MK_92 = 21195,

     [Description("MK-92 CAS")]
     MK_92_CAS = 21240,

     [Description("MK-92 STIR")]
     MK_92_STIR = 21285,

     [Description("MK 95")]
     MK_95 = 21330,

     [Description("MLA-1")]
     MLA_1 = 21340,

     [Description("MM APS 705")]
     MM_APS_705 = 21375,

     [Description("MM SPG 74")]
     MM_SPG_74 = 21420,

     [Description("MM SPG 75")]
     MM_SPG_75 = 21465,

     [Description("MM SPN 703")]
     MM_SPN_703 = 21490,

     [Description("MM SPS 702")]
     MM_SPS_702 = 21510,

     [Description("MM SPS 768")]
     MM_SPS_768 = 21555,

     [Description("MM SPS 774")]
     MM_SPS_774 = 21600,

     [Description("Moon 4")]
     MOON_4 = 21645,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_262 = 21650,

     [Description("MPDR 18 X")]
     MPDR_18_X = 21690,

     [Description("MT-305X")]
     MT_305X = 21710,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_263 = 21735,

     [Description("Mushroom")]
     MUSHROOM = 21780,

     [Description("Mushroom 1")]
     MUSHROOM_1 = 21825,

     [Description("Mushroom 2")]
     MUSHROOM_2 = 21870,

     [Description("N920Z")]
     N920Z = 21880,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_264 = 21890,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_265 = 21895,

     [Description("Nayada")]
     NAYADA = 21915,

     [Description("Neptun")]
     NEPTUN = 21960,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_266 = 21980,

     [Description("NRBA 50")]
     NRBA_50 = 22005,

     [Description("NRBA 51")]
     NRBA_51 = 22050,

     [Description("NRBF 20A")]
     NRBF_20A = 22095,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_267 = 22140,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_268 = 22185,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_269 = 22230,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_270 = 22275,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_271 = 22320,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_272 = 22345,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_273 = 22365,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_274 = 22410,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_275 = 22455,

     [Description("OKEAN")]
     OKEAN = 22500,

     [Description("OKINXE 12C")]
     OKINXE_12C = 22545,

     [Description("OMEGA")]
     OMEGA = 22590,

     [Description("Omera ORB32")]
     OMERA_ORB32 = 22635,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_276 = 22680,

     [Description("OP-28")]
     OP_28 = 22690,

     [Description("OPS-16B")]
     OPS_16B = 22725,

     [Description("OPS-18")]
     OPS_18 = 22730,

     [Description("OPS-28")]
     OPS_28 = 22740,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_277 = 22770,

     [Description("ORB-31S")]
     ORB_31S = 22810,

     [Description("ORB 32")]
     ORB_32 = 22815,

     [Description("Orion Rtn 10X")]
     ORION_RTN_10X = 22860,

     [Description("Otomat MK II Teseo")]
     OTOMAT_MK_II_TESEO = 22905,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_278 = 22950,

     [Description("P360Z")]
     P360Z = 22955,

     [Description("PA-1660")]
     PA_1660 = 22960,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_279 = 22995,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_280 = 23040,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_281 = 23085,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_282 = 23095,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_283 = 23130,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_284 = 23175,

     [Description("PBR 4 Rubin")]
     PBR_4_RUBIN = 23220,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_285 = 23265,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_286 = 23310,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_287 = 23355,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_288 = 23400,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_289 = 23445,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_290 = 23490,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_291 = 23535,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_292 = 23580,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_293 = 23625,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_294 = 23670,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_295 = 23690,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_296 = 23710,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_297 = 23715,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_298 = 23760,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_299 = 23805,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_300 = 23850,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_301 = 23895,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_302 = 23940,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_303 = 23985,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_304 = 23990,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_305 = 24030,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_306 = 24075,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_307 = 24095,

     [Description("POHJANPALO")]
     POHJANPALO = 24100,

     [Description("POLLUX")]
     POLLUX = 24120,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_308 = 24165,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_309 = 24210,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_310 = 24255,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_311 = 24300,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_312 = 24345,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_313 = 24390,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_314 = 24435,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_315 = 24480,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_316 = 24525,

     [Description("PRIMUS 40 WXD")]
     PRIMUS_40_WXD = 24570,

     [Description("PRIMUS 300SL")]
     PRIMUS_300SL = 24615,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_317 = 24620,

     [Description("PS-05A")]
     PS_05A = 24650,

     [Description("PS 46 A")]
     PS_46_A = 24660,

     [Description("PS 70 R")]
     PS_70_R = 24705,

     [Description("PS-890")]
     PS_890 = 24710,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_318 = 24750,

     [Description("R-76")]
     R_76 = 24770,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_319 = 24780,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_320 = 24795,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_321 = 24840,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_322 = 24885,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_323 = 24930,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_324 = 24975,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_325 = 25020,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_326 = 25065,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_327 = 25110,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_328 = 25155,

     [Description("RAN 7S")]
     RAN_7S = 25200,

     [Description("RAN 10S")]
     RAN_10S = 25205,

     [Description("RAN 11 LX")]
     RAN_11_LX = 25245,

     [Description("Rapier TA")]
     RAPIER_TA = 25260,

     [Description("Rapier 2000 TA")]
     RAPIER_2000_TA = 25265,

     [Description("Rapier MG")]
     RAPIER_MG = 25270,

     [Description("RAT-31S")]
     RAT_31S = 25280,

     [Description("RATAC (LCT)")]
     RATAC_LCT = 25285,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_329 = 25290,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_330 = 25300,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_331 = 25335,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_332 = 25380,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_333 = 25425,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_334 = 25470,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_335 = 25515,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_336 = 25560,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_337 = 25605,

     [Description("RAY-1220XR")]
     RAY_1220XR = 25630,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_338 = 25635,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_339 = 25650,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_340 = 25695,

     [Description("RBE2")]
     RBE2 = 25735,

     [Description("RDM")]
     RDM = 25740,

     [Description("RDY")]
     RDY = 25760,

     [Description("RDN 72")]
     RDN_72 = 25785,

     [Description("RDR 1A")]
     RDR_1A = 25830,

     [Description("RDR 1E")]
     RDR_1E = 25835,

     [Description("RDR 4A")]
     RDR_4A = 25840,

     [Description("RDR 1200")]
     RDR_1200 = 25875,

     [Description("RDR 1400")]
     RDR_1400 = 25885,

     [Description("RDR 1400 C")]
     RDR_1400_C = 25890,

     [Description("RDR 1500")]
     RDR_1500 = 25895,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_341 = 25920,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_342 = 25965,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_343 = 26010,

     [Description("ROLAND BN")]
     ROLAND_BN = 26055,

     [Description("ROLAND MG")]
     ROLAND_MG = 26100,

     [Description("ROLAND TA")]
     ROLAND_TA = 26145,

     [Description("ROLAND TT")]
     ROLAND_TT = 26190,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_344 = 26235,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_345 = 26280,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_346 = 26325,

     [Description("RT-02/50")]
     RT_02_50 = 26330,

     [Description("RTN-1A")]
     RTN_1A = 26350,

     [Description("RV2")]
     RV2 = 26370,

     [Description("RV3")]
     RV3 = 26415,

     [Description("RV5")]
     RV5 = 26460,

     [Description("RV10")]
     RV10 = 26505,

     [Description("RV17")]
     RV17 = 26550,

     [Description("RV18")]
     RV18 = 26595,

     [Description("RV-377")]
     RV_377 = 26610,

     [Description("RV UM")]
     RV_UM = 26640,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_347 = 26660,

     [Description("S-1810CD")]
     S_1810CD = 26670,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_348 = 26685,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_349 = 26730,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_350 = 26775,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_351 = 26795,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_352 = 26820,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_353 = 26865,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_354 = 26910,

     [Description("SATURNE II")]
     SATURNE_II = 26955,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_355 = 27000,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_356 = 27045,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_357 = 27090,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_358 = 27135,

     [Description("SCANTER (CSR)")]
     SCANTER_CSR = 27140,

     [Description("SCORADS")]
     SCORADS = 27141,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_359 = 27150,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_360 = 27180,

     [Description("SCR-584")]
     SCR_584 = 27190,

     [Description("Sea Archer 2")]
     SEA_ARCHER_2 = 27225,

     [Description("Sea Hunter 4 MG")]
     SEA_HUNTER_4_MG = 27270,

     [Description("Sea Hunter 4 TA")]
     SEA_HUNTER_4_TA = 27315,

     [Description("Sea Hunter 4 TT")]
     SEA_HUNTER_4_TT = 27360,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_361 = 27405,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_362 = 27450,

     [Description("Sea Spray")]
     SEA_SPRAY = 27495,

     [Description("Sea Tiger")]
     SEA_TIGER = 27540,

     [Description("Searchwater")]
     SEARCHWATER = 27570,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_363 = 27585,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_364 = 27630,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_365 = 27675,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_366 = 27720,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_367 = 27765,

     [Description("SGR 102 00")]
     SGR_102_00 = 27810,

     [Description("SGR 103/02")]
     SGR_103_02 = 27855,

     [Description("SGR-104")]
     SGR_104 = 27870,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_368 = 27900,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_369 = 27945,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_370 = 27990,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_371 = 28035,

     [Description("SGR 114")]
     SGR_114 = 28080,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_372 = 28125,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_373 = 28170,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_374 = 28215,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_375 = 28260,

     [Description("PRV-11")]
     PRV_11 = 28280,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_376 = 28305,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_377 = 28350,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_378 = 28395,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_379 = 28440,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_380 = 28485,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_381 = 28530,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_382 = 28575,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_383 = 28620,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_384 = 28665,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_385 = 28710,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_386 = 28755,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_387 = 28800,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_388 = 28845,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_389 = 28890,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_390 = 28935,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_391 = 28980,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_392 = 29025,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_393 = 29070,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_394 = 29115,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_395 = 29160,

     [Description("SKYGUARD TA")]
     SKYGUARD_TA = 29185,

     [Description("SKYGUARD TT")]
     SKYGUARD_TT = 29190,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_396 = 29205,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_397 = 29215,

     [Description("SKYSHIELD TA")]
     SKYSHIELD_TA = 29220,

     [Description("SL")]
     SL = 29250,

     [Description("SL/ALQ-234")]
     SL_ALQ_234 = 29270,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_398 = 29295,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_399 = 29340,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_400 = 29385,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_401 = 29400,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_402 = 29430,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_403 = 29440,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_404 = 29475,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_405 = 29520,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_406 = 29565,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_407 = 29610,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_408 = 29655,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_409 = 29700,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_410 = 29745,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_411 = 29790,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_412 = 29835,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_413 = 29880,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_414 = 29925,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_415 = 29970,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_416 = 30015,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_417 = 30060,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_418 = 30080,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_419 = 30105,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_420 = 30150,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_421 = 30195,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_422 = 30240,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_423 = 30285,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_424 = 30330,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_425 = 30375,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_426 = 30420,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_427 = 30465,

     [Description("9S18M1")]
     X_9S18M1 = 30470,

     [Description("SO-1")]
     SO_1 = 30510,

     [Description("SO-12")]
     SO_12 = 30520,

     [Description("SO A Communist")]
     SO_A_COMMUNIST = 30555,

     [Description("SO-69")]
     SO_69 = 30580,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_428 = 30600,

     [Description("SOM 64")]
     SOM_64 = 30645,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_429 = 30670,

     [Description("Sparrow (AIM/RIM-7) ILL")]
     SPARROW_AIM_RIM_7_ILL = 30690,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_430 = 30700,

     [Description("SPG 53F")]
     SPG_53F = 30735,

     [Description("SPG 70 (RTN 10X)")]
     SPG_70_RTN_10X = 30780,

     [Description("SPG 74 (RTN 20X)")]
     SPG_74_RTN_20X = 30825,

     [Description("SPG 75 (RTN 30X)")]
     SPG_75_RTN_30X = 30870,

     [Description("SPG 76 (RTN 30X)")]
     SPG_76_RTN_30X = 30915,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_431 = 30960,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_432 = 31005,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_433 = 31050,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_434 = 31095,

     [Description("SPN 35A")]
     SPN_35A = 31140,

     [Description("SPN 41")]
     SPN_41 = 31185,

     [Description("SPN 42")]
     SPN_42 = 31230,

     [Description("SPN 43A")]
     SPN_43A = 31275,

     [Description("SPN 43B")]
     SPN_43B = 31320,

     [Description("SPN 44")]
     SPN_44 = 31365,

     [Description("SPN 46")]
     SPN_46 = 31410,

     [Description("SPN 703")]
     SPN_703 = 31455,

     [Description("SPN 728 (V) 1")]
     SPN_728_V_1 = 31500,

     [Description("SPN 748")]
     SPN_748 = 31545,

     [Description("SPN 750")]
     SPN_750 = 31590,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_435 = 31635,

     [Description("P-12")]
     P_12 = 31680,

     [Description("P-18")]
     P_18 = 31681,

     [Description("P-18")]
     P_18_436 = 31682,

     [Description("P-18")]
     P_18_437 = 31684,

     [Description("SPQ 712 (RAN 12 L/X)")]
     SPQ_712_RAN_12_L_X = 31725,

     [Description("SPS 6C")]
     SPS_6C = 31770,

     [Description("SPS 10F")]
     SPS_10F = 31815,

     [Description("SPS 12")]
     SPS_12 = 31860,

     [Description("SPS 58")]
     SPS_58 = 31905,

     [Description("SPS 64")]
     SPS_64 = 31950,

     [Description("SPS 768 (RAN EL)")]
     SPS_768_RAN_EL = 31995,

     [Description("SPS 774 (RAN 10S)")]
     SPS_774_RAN_10S = 32040,

     [Description("SPY 790")]
     SPY_790 = 32085,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_438 = 32130,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_439 = 32175,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_440 = 32220,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_441 = 32265,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_442 = 32310,

     [Description("P-15M")]
     P_15M = 32330,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_443 = 32355,

     [Description("SRN 6")]
     SRN_6 = 32400,

     [Description("SRN 15")]
     SRN_15 = 32445,

     [Description("SRN 745")]
     SRN_745 = 32490,

     [Description("SRO 1")]
     SRO_1 = 32535,

     [Description("SRO 2")]
     SRO_2 = 32580,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_444 = 32625,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_445 = 32670,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_446 = 32715,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_447 = 32760,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_448 = 32805,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_449 = 32850,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_450 = 32895,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_451 = 32940,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_452 = 32985,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_453 = 33030,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_454 = 33075,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_455 = 33120,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_456 = 33165,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_457 = 33210,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_458 = 33255,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_459 = 33300,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_460 = 33345,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_461 = 33390,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_462 = 33435,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_463 = 33480,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_464 = 33525,

     [Description("STR 41")]
     STR_41 = 33570,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_465 = 33590,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_466 = 33595,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_467 = 33600,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_468 = 33615,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_469 = 33660,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_470 = 33705,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_471 = 33750,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_472 = 33795,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_473 = 33840,

     [Description("Superfledermaus")]
     SUPERFLEDERMAUS = 33860,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_474 = 33885,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_475 = 33930,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_476 = 33975,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_477 = 34020,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_478 = 34040,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_479 = 34065,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_480 = 34110,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_481 = 34155,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_482 = 34200,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_483 = 34245,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_484 = 34290,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_485 = 34335,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_486 = 34380,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_487 = 34425,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_488 = 34470,

     [Description("P-14")]
     P_14 = 34515,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_489 = 34560,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_490 = 34605,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_491 = 34625,

     [Description("THAAD GBR")]
     THAAD_GBR = 34640,

     [Description("THD 225")]
     THD_225 = 34650,

     [Description("THD 1940")]
     THD_1940 = 34670,

     [Description("THD 5500")]
     THD_5500 = 34695,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_492 = 34740,

     [Description("PRV-9")]
     PRV_9 = 34785,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_493 = 34795,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_494 = 34830,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_495 = 34875,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_496 = 34920,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_497 = 34965,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_498 = 35010,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_499 = 35055,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_500 = 35100,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_501 = 35145,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_502 = 35190,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_503 = 35235,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_504 = 35280,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_505 = 35325,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_506 = 35370,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_507 = 35415,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_508 = 35460,

     [Description("TRS-2105")]
     TRS_2105 = 35480,

     [Description("TRS-2100")]
     TRS_2100 = 35490,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_509 = 35505,

     [Description("36D6")]
     X_36D6 = 35550,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_510 = 35570,

     [Description("TIRSPONDER")]
     TIRSPONDER = 35580,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_511 = 35595,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_512 = 35640,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_513 = 35685,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_514 = 35730,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_515 = 35775,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_516 = 35800,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_517 = 35820,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_518 = 35865,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_519 = 35910,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_520 = 35955,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_521 = 36000,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_522 = 36045,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_523 = 36090,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_524 = 36135,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_525 = 36180,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_526 = 36220,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_527 = 36225,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_528 = 36230,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_529 = 36270,

     [Description("TORSO M")]
     TORSO_M = 36315,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_530 = 36360,

     [Description("TRISPONDE")]
     TRISPONDE = 36380,

     [Description("TRS 3033")]
     TRS_3033 = 36405,

     [Description("TRS 3405")]
     TRS_3405 = 36420,

     [Description("TRS 3410")]
     TRS_3410 = 36425,

     [Description("TRS 3415")]
     TRS_3415 = 36430,

     [Description("TRS-N")]
     TRS_N = 36450,

     [Description("TSE 5000")]
     TSE_5000 = 36495,

     [Description("TSR 333")]
     TSR_333 = 36540,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_531 = 36585,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_532 = 36630,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_533 = 36675,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_534 = 36720,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_535 = 36765,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_536 = 36810,

     [Description("TYPE 262")]
     TYPE_262 = 36855,

     [Description("TYPE 275")]
     TYPE_275 = 36900,

     [Description("TYPE 293")]
     TYPE_293 = 36945,

     [Description("TYPE 343 SUN VISOR B")]
     TYPE_343_SUN_VISOR_B = 36990,

     [Description("TYPE 347B")]
     TYPE_347B = 37035,

     [Description("Type-404A(CH)")]
     TYPE_404ACH = 37050,

     [Description("Type 756")]
     TYPE_756 = 37080,

     [Description("TYPE 903")]
     TYPE_903 = 37125,

     [Description("TYPE 909 TI")]
     TYPE_909_TI = 37170,

     [Description("TYPE 909 TT")]
     TYPE_909_TT = 37215,

     [Description("TYPE 910")]
     TYPE_910 = 37260,

     [Description("TYPE-931(CH)")]
     TYPE_931CH = 37265,

     [Description("TYPE 965")]
     TYPE_965 = 37305,

     [Description("TYPE 967")]
     TYPE_967 = 37350,

     [Description("TYPE 968")]
     TYPE_968 = 37395,

     [Description("TYPE 974")]
     TYPE_974 = 37440,

     [Description("TYPE 975")]
     TYPE_975 = 37485,

     [Description("TYPE 978")]
     TYPE_978 = 37530,

     [Description("TYPE 992")]
     TYPE_992 = 37575,

     [Description("TYPE 993")]
     TYPE_993 = 37620,

     [Description("TYPE 994")]
     TYPE_994 = 37665,

     [Description("TYPE 1006(1)")]
     TYPE_10061 = 37710,

     [Description("TYPE 1006(2)")]
     TYPE_10062 = 37755,

     [Description("TYPE 1022")]
     TYPE_1022 = 37800,

     [Description("UK MK 10")]
     UK_MK_10 = 37845,

     [Description("UPS-220C")]
     UPS_220C = 37850,

     [Description("UPX 1 10")]
     UPX_1_10 = 37890,

     [Description("UPX 27")]
     UPX_27 = 37935,

     [Description("URN 20")]
     URN_20 = 37980,

     [Description("URN 25")]
     URN_25 = 38025,

     [Description("VOLEX III/IV")]
     VOLEX_III_IV = 38045,

     [Description("W8818")]
     W8818 = 38070,

     [Description("W8838")]
     W8838 = 38115,

     [Description("W8852")]
     W8852 = 38120,

     [Description("WAS-74S")]
     WAS_74S = 38160,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_537 = 38205,

     [Description("WATCHDOG")]
     WATCHDOG = 38210,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_538 = 38250,

     [Description("Watchman")]
     WATCHMAN = 38260,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_539 = 38295,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_540 = 38320,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_541 = 38340,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_542 = 38385,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_543 = 38430,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_544 = 38475,

     [Description("Wet Eye")]
     WET_EYE = 38520,

     [Description("Wet Eye Mod")]
     WET_EYE_MOD = 38565,

     [Description("WGU-41/B")]
     WGU_41_B = 38570,

     [Description("WGU-44/B")]
     WGU_44_B = 38572,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_545 = 38610,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_546 = 38655,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_547 = 38700,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_548 = 38715,

     [Description("Wild Card")]
     WILD_CARD = 38745,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_549 = 38790,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_550 = 38835,

     [Description("WM2X Series")]
     WM2X_SERIES = 38880,

     [Description("WM2X Series CAS")]
     WM2X_SERIES_CAS = 38925,

     [Description("WSR-74C")]
     WSR_74C = 38950,

     [Description("WSR-74S")]
     WSR_74S = 38955,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_551 = 38970,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_552 = 39015,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_553 = 39060,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_554 = 39105,

     [Description("Missing Description")]
     MISSING_DESCRIPTION_555 = 39150
     }

    } //End Parial Class

} //End Namespace
