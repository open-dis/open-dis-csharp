
using System;
using System.ComponentModel;
using System.Reflection;
using EnumUtilities;

/** Enumeration values for CountryType
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
 */

namespace DISnet 
{

    public partial class DISEnumerations
    {

        public enum CountryType 
        {

     [Description("Other")]
     [InternetDomainCode("Unknown")]
     OTHER = 0,
     [Description("Afghanistan")]
     [InternetDomainCode("AF")]
     AFGHANISTAN = 1,
     [Description("Albania")]
     [InternetDomainCode("AL")]
     ALBANIA = 2,
     [Description("Algeria")]
     [InternetDomainCode("DZ")]
     ALGERIA = 3,
     [Description("American Samoa (United States)")]
     [InternetDomainCode("Unknown")]
     AMERICAN_SAMOA_UNITED_STATES = 4,
     [Description("Andorra")]
     [InternetDomainCode("AD")]
     ANDORRA = 5,
     [Description("Angola")]
     [InternetDomainCode("AO")]
     ANGOLA = 6,
     [Description("Anguilla")]
     [InternetDomainCode("AI")]
     ANGUILLA = 7,
     [Description("Antarctica (International)")]
     [InternetDomainCode("Unknown")]
     ANTARCTICA_INTERNATIONAL = 8,
     [Description("Antigua and Barbuda")]
     [InternetDomainCode("AG")]
     ANTIGUA_AND_BARBUDA = 9,
     [Description("Argentina")]
     [InternetDomainCode("AR")]
     ARGENTINA = 10,
     [Description("Armenia")]
     [InternetDomainCode("AM")]
     ARMENIA = 244,
     [Description("Aruba")]
     [InternetDomainCode("AW")]
     ARUBA = 11,
     [Description("Ashmore and Cartier Islands (Australia)")]
     [InternetDomainCode("Unknown")]
     ASHMORE_AND_CARTIER_ISLANDS_AUSTRALIA = 12,
     [Description("Australia")]
     [InternetDomainCode("AU")]
     AUSTRALIA = 13,
     [Description("Austria")]
     [InternetDomainCode("AT")]
     AUSTRIA = 14,
     [Description("Azerbaijan")]
     [InternetDomainCode("AZ")]
     AZERBAIJAN = 245,
     [Description("Bahamas")]
     [InternetDomainCode("BS")]
     BAHAMAS = 15,
     [Description("Bahrain")]
     [InternetDomainCode("BH")]
     BAHRAIN = 16,
     [Description("Baker Island (United States)")]
     [InternetDomainCode("Unknown")]
     BAKER_ISLAND_UNITED_STATES = 17,
     [Description("Bangladesh")]
     [InternetDomainCode("BD")]
     BANGLADESH = 18,
     [Description("Barbados")]
     [InternetDomainCode("BB")]
     BARBADOS = 19,
     [Description("Bassas da India (France)")]
     [InternetDomainCode("Unknown")]
     BASSAS_DA_INDIA_FRANCE = 20,
     [Description("Belarus")]
     [InternetDomainCode("BY")]
     BELARUS = 246,
     [Description("Belgium")]
     [InternetDomainCode("BE")]
     BELGIUM = 21,
     [Description("Belize")]
     [InternetDomainCode("BZ")]
     BELIZE = 22,
     [Description("Benin (aka Dahomey)")]
     [InternetDomainCode("Unknown")]
     BENIN_AKA_DAHOMEY = 23,
     [Description("Bermuda (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     BERMUDA_UNITED_KINGDOM = 24,
     [Description("Bhutan")]
     [InternetDomainCode("BT")]
     BHUTAN = 25,
     [Description("Bolivia")]
     [InternetDomainCode("BO")]
     BOLIVIA = 26,
     [Description("Bosnia and Hercegovina")]
     [InternetDomainCode("Unknown")]
     BOSNIA_AND_HERCEGOVINA = 247,
     [Description("Botswana")]
     [InternetDomainCode("BW")]
     BOTSWANA = 27,
     [Description("Bouvet Island (Norway)")]
     [InternetDomainCode("Unknown")]
     BOUVET_ISLAND_NORWAY = 28,
     [Description("Brazil")]
     [InternetDomainCode("BR")]
     BRAZIL = 29,
     [Description("British Indian Ocean Territory (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     BRITISH_INDIAN_OCEAN_TERRITORY_UNITED_KINGDOM = 30,
     [Description("British Virgin Islands (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     BRITISH_VIRGIN_ISLANDS_UNITED_KINGDOM = 31,
     [Description("Brunei")]
     [InternetDomainCode("Unknown")]
     BRUNEI = 32,
     [Description("Bulgaria")]
     [InternetDomainCode("BG")]
     BULGARIA = 33,
     [Description("Burkina (aka Burkina Faso or Upper Volta)")]
     [InternetDomainCode("Unknown")]
     BURKINA_AKA_BURKINA_FASO_OR_UPPER_VOLTA = 34,
     [Description("Burma (Myanmar)")]
     [InternetDomainCode("Unknown")]
     BURMA_MYANMAR = 35,
     [Description("Burundi")]
     [InternetDomainCode("BI")]
     BURUNDI = 36,
     [Description("Cambodia (aka Kampuchea)")]
     [InternetDomainCode("Unknown")]
     CAMBODIA_AKA_KAMPUCHEA = 37,
     [Description("Cameroon")]
     [InternetDomainCode("CM")]
     CAMEROON = 38,
     [Description("Canada")]
     [InternetDomainCode("CA")]
     CANADA = 39,
     [Description("Cape Verde, Republic of")]
     [InternetDomainCode("Unknown")]
     CAPE_VERDE_REPUBLIC_OF = 40,
     [Description("Cayman Islands (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     CAYMAN_ISLANDS_UNITED_KINGDOM = 41,
     [Description("Central African Republic")]
     [InternetDomainCode("CF")]
     CENTRAL_AFRICAN_REPUBLIC = 42,
     [Description("Chad")]
     [InternetDomainCode("TD")]
     CHAD = 43,
     [Description("Chile")]
     [InternetDomainCode("CL")]
     CHILE = 44,
     [Description("China, People's Republic of")]
     [InternetDomainCode("Unknown")]
     CHINA_PEOPLES_REPUBLIC_OF = 45,
     [Description("Christmas Island (Australia)")]
     [InternetDomainCode("Unknown")]
     CHRISTMAS_ISLAND_AUSTRALIA = 46,
     [Description("Clipperton Island (France)")]
     [InternetDomainCode("Unknown")]
     CLIPPERTON_ISLAND_FRANCE = 248,
     [Description("Cocos (Keeling) Islands (Australia)")]
     [InternetDomainCode("Unknown")]
     COCOS_KEELING_ISLANDS_AUSTRALIA = 47,
     [Description("Colombia")]
     [InternetDomainCode("CO")]
     COLOMBIA = 48,
     [Description("Commonwealth of Independent States")]
     [InternetDomainCode("Unknown")]
     COMMONWEALTH_OF_INDEPENDENT_STATES = 222,
     [Description("Comoros")]
     [InternetDomainCode("KM")]
     COMOROS = 49,
     [Description("Congo, Republic of")]
     [InternetDomainCode("Unknown")]
     CONGO_REPUBLIC_OF = 50,
     [Description("Cook Islands (New Zealand)")]
     [InternetDomainCode("Unknown")]
     COOK_ISLANDS_NEW_ZEALAND = 51,
     [Description("Coral Sea Islands (Australia)")]
     [InternetDomainCode("Unknown")]
     CORAL_SEA_ISLANDS_AUSTRALIA = 52,
     [Description("Costa Rica")]
     [InternetDomainCode("CR")]
     COSTA_RICA = 53,
     [Description("(Cote D'Ivoire (aka Ivory Coast)")]
     [InternetDomainCode("Unknown")]
     COTE_DIVOIRE_AKA_IVORY_COAST = 107,
     [Description("Croatia")]
     [InternetDomainCode("Unknown")]
     CROATIA = 249,
     [Description("Cuba")]
     [InternetDomainCode("CU")]
     CUBA = 54,
     [Description("Cyprus")]
     [InternetDomainCode("CY")]
     CYPRUS = 55,
     [Description("Czechoslovakia (separating into Czech Republic and Slovak Republic)")]
     [InternetDomainCode("Unknown")]
     CZECHOSLOVAKIA_SEPARATING_INTO_CZECH_REPUBLIC_AND_SLOVAK_REPUBLIC = 56,
     [Description("Dahomey (aka Benin)")]
     [InternetDomainCode("Unknown")]
     DAHOMEY_AKA_BENIN = 23,
     [Description("Denmark")]
     [InternetDomainCode("DK")]
     DENMARK = 57,
     [Description("Djibouti")]
     [InternetDomainCode("DJ")]
     DJIBOUTI = 58,
     [Description("Dominica")]
     [InternetDomainCode("DM")]
     DOMINICA = 59,
     [Description("Dominican Republic")]
     [InternetDomainCode("DO")]
     DOMINICAN_REPUBLIC = 60,
     [Description("Ecuador")]
     [InternetDomainCode("EC")]
     ECUADOR = 61,
     [Description("Egypt")]
     [InternetDomainCode("EG")]
     EGYPT = 62,
     [Description("El Salvador")]
     [InternetDomainCode("SV")]
     EL_SALVADOR = 63,
     [Description("Equatorial Guinea")]
     [InternetDomainCode("GQ")]
     EQUATORIAL_GUINEA = 64,
     [Description("Estonia")]
     [InternetDomainCode("EE")]
     ESTONIA = 250,
     [Description("Ethiopia")]
     [InternetDomainCode("ET")]
     ETHIOPIA = 65,
     [Description("Europa Island (France)")]
     [InternetDomainCode("Unknown")]
     EUROPA_ISLAND_FRANCE = 66,
     [Description("Falkland Islands (aka Islas Malvinas) (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     FALKLAND_ISLANDS_AKA_ISLAS_MALVINAS_UNITED_KINGDOM = 67,
     [Description("Faroe Islands (Denmark)")]
     [InternetDomainCode("Unknown")]
     FAROE_ISLANDS_DENMARK = 68,
     [Description("Fiji")]
     [InternetDomainCode("FJ")]
     FIJI = 69,
     [Description("Finland")]
     [InternetDomainCode("FI")]
     FINLAND = 70,
     [Description("France")]
     [InternetDomainCode("FR")]
     FRANCE = 71,
     [Description("French Guiana (France)")]
     [InternetDomainCode("Unknown")]
     FRENCH_GUIANA_FRANCE = 72,
     [Description("French Polynesia (France)")]
     [InternetDomainCode("Unknown")]
     FRENCH_POLYNESIA_FRANCE = 73,
     [Description("French Southern and Antarctic Islands (France)")]
     [InternetDomainCode("Unknown")]
     FRENCH_SOUTHERN_AND_ANTARCTIC_ISLANDS_FRANCE = 74,
     [Description("Gabon")]
     [InternetDomainCode("GA")]
     GABON = 75,
     [Description("Gambia, The")]
     [InternetDomainCode("Unknown")]
     GAMBIA_THE = 76,
     [Description("Gaza Strip (Israel)")]
     [InternetDomainCode("Unknown")]
     GAZA_STRIP_ISRAEL = 77,
     [Description("Georgia")]
     [InternetDomainCode("GE")]
     GEORGIA = 251,
     [Description("Germany")]
     [InternetDomainCode("DE")]
     GERMANY = 78,
     [Description("Ghana")]
     [InternetDomainCode("GH")]
     GHANA = 79,
     [Description("Gibraltar (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     GIBRALTAR_UNITED_KINGDOM = 80,
     [Description("Glorioso Islands (France)")]
     [InternetDomainCode("Unknown")]
     GLORIOSO_ISLANDS_FRANCE = 81,
     [Description("Greece")]
     [InternetDomainCode("GR")]
     GREECE = 82,
     [Description("Greenland (Denmark)")]
     [InternetDomainCode("Unknown")]
     GREENLAND_DENMARK = 83,
     [Description("Grenada")]
     [InternetDomainCode("GD")]
     GRENADA = 84,
     [Description("Guadaloupe (France)")]
     [InternetDomainCode("Unknown")]
     GUADALOUPE_FRANCE = 85,
     [Description("Guam (United States)")]
     [InternetDomainCode("Unknown")]
     GUAM_UNITED_STATES = 86,
     [Description("Guatemala")]
     [InternetDomainCode("GT")]
     GUATEMALA = 87,
     [Description("Guernsey (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     GUERNSEY_UNITED_KINGDOM = 88,
     [Description("Guinea")]
     [InternetDomainCode("GN")]
     GUINEA = 89,
     [Description("Guinea- Bissau")]
     [InternetDomainCode("Unknown")]
     GUINEA_BISSAU = 90,
     [Description("Guyana")]
     [InternetDomainCode("GY")]
     GUYANA = 91,
     [Description("Haiti")]
     [InternetDomainCode("HT")]
     HAITI = 92,
     [Description("Heard Island and McDonald Islands (Australia)")]
     [InternetDomainCode("Unknown")]
     HEARD_ISLAND_AND_MCDONALD_ISLANDS_AUSTRALIA = 93,
     [Description("Honduras")]
     [InternetDomainCode("HN")]
     HONDURAS = 94,
     [Description("Hong Kong (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     HONG_KONG_UNITED_KINGDOM = 95,
     [Description("Howland Island (United States)")]
     [InternetDomainCode("Unknown")]
     HOWLAND_ISLAND_UNITED_STATES = 96,
     [Description("Hungary")]
     [InternetDomainCode("HU")]
     HUNGARY = 97,
     [Description("Iceland")]
     [InternetDomainCode("IS")]
     ICELAND = 98,
     [Description("India")]
     [InternetDomainCode("IN")]
     INDIA = 99,
     [Description("Indonesia")]
     [InternetDomainCode("ID")]
     INDONESIA = 100,
     [Description("Iran")]
     [InternetDomainCode("IR")]
     IRAN = 101,
     [Description("Iraq")]
     [InternetDomainCode("IQ")]
     IRAQ = 102,
     [Description("Ireland")]
     [InternetDomainCode("IE")]
     IRELAND = 104,
     [Description("Israel")]
     [InternetDomainCode("IL")]
     ISRAEL = 105,
     [Description("Italy")]
     [InternetDomainCode("IT")]
     ITALY = 106,
     [Description("Ivory Coast (aka Cote D'Ivoire)")]
     [InternetDomainCode("Unknown")]
     IVORY_COAST_AKA_COTE_DIVOIRE = 107,
     [Description("Jamaica")]
     [InternetDomainCode("JM")]
     JAMAICA = 108,
     [Description("Jan Mayen (Norway)")]
     [InternetDomainCode("Unknown")]
     JAN_MAYEN_NORWAY = 109,
     [Description("Japan")]
     [InternetDomainCode("JP")]
     JAPAN = 110,
     [Description("Jarvis Island (United States)")]
     [InternetDomainCode("Unknown")]
     JARVIS_ISLAND_UNITED_STATES = 111,
     [Description("Jersey (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     JERSEY_UNITED_KINGDOM = 112,
     [Description("Johnston Atoll (United States)")]
     [InternetDomainCode("Unknown")]
     JOHNSTON_ATOLL_UNITED_STATES = 113,
     [Description("Jordan")]
     [InternetDomainCode("JO")]
     JORDAN = 114,
     [Description("Juan de Nova Island")]
     [InternetDomainCode("Unknown")]
     JUAN_DE_NOVA_ISLAND = 115,
     [Description("Kazakhstan")]
     [InternetDomainCode("KZ")]
     KAZAKHSTAN = 252,
     [Description("Kenya")]
     [InternetDomainCode("KE")]
     KENYA = 116,
     [Description("Kingman Reef (United States)")]
     [InternetDomainCode("Unknown")]
     KINGMAN_REEF_UNITED_STATES = 117,
     [Description("Kiribati")]
     [InternetDomainCode("KI")]
     KIRIBATI = 118,
     [Description("Korea, Democratic People's Republic of (North)")]
     [InternetDomainCode("Unknown")]
     KOREA_DEMOCRATIC_PEOPLES_REPUBLIC_OF_NORTH = 119,
     [Description("Korea, Republic of (South)")]
     [InternetDomainCode("Unknown")]
     KOREA_REPUBLIC_OF_SOUTH = 120,
     [Description("Kuwait")]
     [InternetDomainCode("KW")]
     KUWAIT = 121,
     [Description("Kyrgyzstan")]
     [InternetDomainCode("KG")]
     KYRGYZSTAN = 253,
     [Description("Laos")]
     [InternetDomainCode("LA")]
     LAOS = 122,
     [Description("Latvia")]
     [InternetDomainCode("LV")]
     LATVIA = 254,
     [Description("Lebanon")]
     [InternetDomainCode("LB")]
     LEBANON = 123,
     [Description("Lesotho")]
     [InternetDomainCode("LS")]
     LESOTHO = 124,
     [Description("Liberia")]
     [InternetDomainCode("LR")]
     LIBERIA = 125,
     [Description("Libya")]
     [InternetDomainCode("LY")]
     LIBYA = 126,
     [Description("Liechtenstein")]
     [InternetDomainCode("LI")]
     LIECHTENSTEIN = 127,
     [Description("Lithuania")]
     [InternetDomainCode("LT")]
     LITHUANIA = 255,
     [Description("Luxembourg")]
     [InternetDomainCode("LU")]
     LUXEMBOURG = 128,
     [Description("Macau (Portugal)")]
     [InternetDomainCode("Unknown")]
     MACAU_PORTUGAL = 130,
     [Description("Macedonia")]
     [InternetDomainCode("MK")]
     MACEDONIA = 256,
     [Description("Madagascar")]
     [InternetDomainCode("MG")]
     MADAGASCAR = 129,
     [Description("Malawi")]
     [InternetDomainCode("MW")]
     MALAWI = 131,
     [Description("Malaysia")]
     [InternetDomainCode("MY")]
     MALAYSIA = 132,
     [Description("Maldives")]
     [InternetDomainCode("MV")]
     MALDIVES = 133,
     [Description("Mali")]
     [InternetDomainCode("ML")]
     MALI = 134,
     [Description("Malta")]
     [InternetDomainCode("MT")]
     MALTA = 135,
     [Description("Man, Isle of (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     MAN_ISLE_OF_UNITED_KINGDOM = 136,
     [Description("Marshall Islands")]
     [InternetDomainCode("MH")]
     MARSHALL_ISLANDS = 137,
     [Description("Martinique (France)")]
     [InternetDomainCode("Unknown")]
     MARTINIQUE_FRANCE = 138,
     [Description("Mauritania")]
     [InternetDomainCode("MR")]
     MAURITANIA = 139,
     [Description("Mauritius")]
     [InternetDomainCode("MU")]
     MAURITIUS = 140,
     [Description("Mayotte (France)")]
     [InternetDomainCode("Unknown")]
     MAYOTTE_FRANCE = 141,
     [Description("Mexico")]
     [InternetDomainCode("MX")]
     MEXICO = 142,
     [Description("Micronesia, Federative States of")]
     [InternetDomainCode("Unknown")]
     MICRONESIA_FEDERATIVE_STATES_OF = 143,
     [Description("Midway Islands (United States)")]
     [InternetDomainCode("Unknown")]
     MIDWAY_ISLANDS_UNITED_STATES = 257,
     [Description("Moldova")]
     [InternetDomainCode("MD")]
     MOLDOVA = 258,
     [Description("Monaco")]
     [InternetDomainCode("MC")]
     MONACO = 144,
     [Description("Mongolia")]
     [InternetDomainCode("MN")]
     MONGOLIA = 145,
     [Description("Montenegro")]
     [InternetDomainCode("Unknown")]
     MONTENEGRO = 259,
     [Description("Montserrat (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     MONTSERRAT_UNITED_KINGDOM = 146,
     [Description("Morocco")]
     [InternetDomainCode("MA")]
     MOROCCO = 147,
     [Description("Mozambique")]
     [InternetDomainCode("MZ")]
     MOZAMBIQUE = 148,
     [Description("Myanmar (aka Burma)")]
     [InternetDomainCode("Unknown")]
     MYANMAR_AKA_BURMA = 35,
     [Description("Namibia (South West Africa)")]
     [InternetDomainCode("Unknown")]
     NAMIBIA_SOUTH_WEST_AFRICA = 149,
     [Description("Nauru")]
     [InternetDomainCode("NR")]
     NAURU = 150,
     [Description("Navassa Island (United States)")]
     [InternetDomainCode("Unknown")]
     NAVASSA_ISLAND_UNITED_STATES = 151,
     [Description("Nepal")]
     [InternetDomainCode("NP")]
     NEPAL = 152,
     [Description("Netherlands")]
     [InternetDomainCode("NL")]
     NETHERLANDS = 153,
     [Description("Netherlands Antilles (Curacao, Bonaire, Saba, Sint Maarten Sint Eustatius)")]
     [InternetDomainCode("Unknown")]
     NETHERLANDS_ANTILLES_CURACAO_BONAIRE_SABA_SINT_MAARTEN_SINT_EUSTATIUS = 154,
     [Description("New Caledonia (France)")]
     [InternetDomainCode("Unknown")]
     NEW_CALEDONIA_FRANCE = 155,
     [Description("New Zealand")]
     [InternetDomainCode("Unknown")]
     NEW_ZEALAND = 156,
     [Description("Nicaragua")]
     [InternetDomainCode("NI")]
     NICARAGUA = 157,
     [Description("Niger")]
     [InternetDomainCode("NE")]
     NIGER = 158,
     [Description("Nigeria")]
     [InternetDomainCode("NG")]
     NIGERIA = 159,
     [Description("Niue (New Zealand)")]
     [InternetDomainCode("Unknown")]
     NIUE_NEW_ZEALAND = 160,
     [Description("Norfolk Island (Australia)")]
     [InternetDomainCode("Unknown")]
     NORFOLK_ISLAND_AUSTRALIA = 161,
     [Description("Northern Mariana Islands (United States)")]
     [InternetDomainCode("Unknown")]
     NORTHERN_MARIANA_ISLANDS_UNITED_STATES = 162,
     [Description("Norway")]
     [InternetDomainCode("NO")]
     NORWAY = 163,
     [Description("Oman")]
     [InternetDomainCode("OM")]
     OMAN = 164,
     [Description("Pacific Islands, Trust Territory of the (Palau)")]
     [InternetDomainCode("Unknown")]
     PACIFIC_ISLANDS_TRUST_TERRITORY_OF_THE_PALAU = 216,
     [Description("Pakistan")]
     [InternetDomainCode("PK")]
     PAKISTAN = 165,
     [Description("Palmyra Atoll (United States)")]
     [InternetDomainCode("Unknown")]
     PALMYRA_ATOLL_UNITED_STATES = 166,
     [Description("Panama")]
     [InternetDomainCode("PA")]
     PANAMA = 168,
     [Description("Papua New Guinea")]
     [InternetDomainCode("PG")]
     PAPUA_NEW_GUINEA = 169,
     [Description("Paracel Islands (International - Occupied by China, also claimed by Taiwan and Vietnam)")]
     [InternetDomainCode("Unknown")]
     PARACEL_ISLANDS_INTERNATIONAL_OCCUPIED_BY_CHINA_ALSO_CLAIMED_BY_TAIWAN_AND_VIETNAM = 170,
     [Description("Paraguay")]
     [InternetDomainCode("PY")]
     PARAGUAY = 171,
     [Description("Peru")]
     [InternetDomainCode("PE")]
     PERU = 172,
     [Description("Philippines")]
     [InternetDomainCode("PH")]
     PHILIPPINES = 173,
     [Description("Pitcairn Islands (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     PITCAIRN_ISLANDS_UNITED_KINGDOM = 174,
     [Description("Poland")]
     [InternetDomainCode("PL")]
     POLAND = 175,
     [Description("Portugal")]
     [InternetDomainCode("PT")]
     PORTUGAL = 176,
     [Description("Puerto Rico (United States)")]
     [InternetDomainCode("Unknown")]
     PUERTO_RICO_UNITED_STATES = 177,
     [Description("Qatar")]
     [InternetDomainCode("QA")]
     QATAR = 178,
     [Description("Reunion (France)")]
     [InternetDomainCode("Unknown")]
     REUNION_FRANCE = 179,
     [Description("Romania")]
     [InternetDomainCode("RO")]
     ROMANIA = 180,
     [Description("Russia")]
     [InternetDomainCode("Unknown")]
     RUSSIA = 260,
     [Description("Rwanda")]
     [InternetDomainCode("RW")]
     RWANDA = 181,
     [Description("St. Helena (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     ST_HELENA_UNITED_KINGDOM = 183,
     [Description("St. Lucia")]
     [InternetDomainCode("Unknown")]
     ST_LUCIA = 184,
     [Description("St. Vincent and the Grenadines")]
     [InternetDomainCode("Unknown")]
     ST_VINCENT_AND_THE_GRENADINES = 186,
     [Description("St. Kitts and Nevis")]
     [InternetDomainCode("Unknown")]
     ST_KITTS_AND_NEVIS = 182,
     [Description("St. Pierre and Miquelon (France)")]
     [InternetDomainCode("Unknown")]
     ST_PIERRE_AND_MIQUELON_FRANCE = 185,
     [Description("San Marino")]
     [InternetDomainCode("SM")]
     SAN_MARINO = 187,
     [Description("Sao Tome and Principe")]
     [InternetDomainCode("ST")]
     SAO_TOME_AND_PRINCIPE = 188,
     [Description("Saudi Arabia")]
     [InternetDomainCode("SA")]
     SAUDI_ARABIA = 189,
     [Description("Senegal")]
     [InternetDomainCode("SN")]
     SENEGAL = 190,
     [Description("Serbia and Montenegro (Montenegro to separate)")]
     [InternetDomainCode("Unknown")]
     SERBIA_AND_MONTENEGRO_MONTENEGRO_TO_SEPARATE = 261,
     [Description("Seychelles")]
     [InternetDomainCode("SC")]
     SEYCHELLES = 191,
     [Description("Sierra Leone")]
     [InternetDomainCode("SL")]
     SIERRA_LEONE = 192,
     [Description("Singapore")]
     [InternetDomainCode("SG")]
     SINGAPORE = 193,
     [Description("Slovenia")]
     [InternetDomainCode("SI")]
     SLOVENIA = 262,
     [Description("Solomon Islands")]
     [InternetDomainCode("SB")]
     SOLOMON_ISLANDS = 194,
     [Description("Somalia")]
     [InternetDomainCode("SO")]
     SOMALIA = 195,
     [Description("South Africa")]
     [InternetDomainCode("ZA")]
     SOUTH_AFRICA = 197,
     [Description("South Georgia and the South Sandwich Islands (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     SOUTH_GEORGIA_AND_THE_SOUTH_SANDWICH_ISLANDS_UNITED_KINGDOM = 196,
     [Description("Spain")]
     [InternetDomainCode("ES")]
     SPAIN = 198,
     [Description("Spratly Islands (International - parts occupied and claimed by China,Malaysia, Philippines, Taiwan, Vietnam)")]
     [InternetDomainCode("Unknown")]
     SPRATLY_ISLANDS_INTERNATIONAL_PARTS_OCCUPIED_AND_CLAIMED_BY_CHINAMALAYSIA_PHILIPPINES_TAIWAN_VIETNAM = 199,
     [Description("Sri Lanka")]
     [InternetDomainCode("LK")]
     SRI_LANKA = 200,
     [Description("Sudan")]
     [InternetDomainCode("SD")]
     SUDAN = 201,
     [Description("Suriname")]
     [InternetDomainCode("SR")]
     SURINAME = 202,
     [Description("Svalbard (Norway)")]
     [InternetDomainCode("Unknown")]
     SVALBARD_NORWAY = 203,
     [Description("Swaziland")]
     [InternetDomainCode("SZ")]
     SWAZILAND = 204,
     [Description("Sweden")]
     [InternetDomainCode("SE")]
     SWEDEN = 205,
     [Description("Switzerland")]
     [InternetDomainCode("CH")]
     SWITZERLAND = 206,
     [Description("Syria")]
     [InternetDomainCode("SY")]
     SYRIA = 207,
     [Description("Taiwan")]
     [InternetDomainCode("TW")]
     TAIWAN = 208,
     [Description("Tajikistan")]
     [InternetDomainCode("TJ")]
     TAJIKISTAN = 263,
     [Description("Tanzania")]
     [InternetDomainCode("TZ")]
     TANZANIA = 209,
     [Description("Thailand")]
     [InternetDomainCode("TH")]
     THAILAND = 210,
     [Description("Togo")]
     [InternetDomainCode("TG")]
     TOGO = 211,
     [Description("Tokelau (New Zealand)")]
     [InternetDomainCode("Unknown")]
     TOKELAU_NEW_ZEALAND = 212,
     [Description("Tonga")]
     [InternetDomainCode("TO")]
     TONGA = 213,
     [Description("Trinidad and Tobago")]
     [InternetDomainCode("TT")]
     TRINIDAD_AND_TOBAGO = 214,
     [Description("Tromelin Island (France)")]
     [InternetDomainCode("Unknown")]
     TROMELIN_ISLAND_FRANCE = 215,
     [Description("Tunisia")]
     [InternetDomainCode("TN")]
     TUNISIA = 217,
     [Description("Turkey")]
     [InternetDomainCode("TR")]
     TURKEY = 218,
     [Description("Turkmenistan")]
     [InternetDomainCode("TM")]
     TURKMENISTAN = 264,
     [Description("Turks and Caicos Islands (United Kingdom)")]
     [InternetDomainCode("Unknown")]
     TURKS_AND_CAICOS_ISLANDS_UNITED_KINGDOM = 219,
     [Description("Tuvalu")]
     [InternetDomainCode("TV")]
     TUVALU = 220,
     [Description("Uganda")]
     [InternetDomainCode("UG")]
     UGANDA = 221,
     [Description("Ukraine")]
     [InternetDomainCode("UA")]
     UKRAINE = 265,
     [Description("United Arab Emirates")]
     [InternetDomainCode("AE")]
     UNITED_ARAB_EMIRATES = 223,
     [Description("United Kingdom")]
     [InternetDomainCode("UK")]
     UNITED_KINGDOM = 224,
     [Description("United States")]
     [InternetDomainCode("US")]
     UNITED_STATES = 225,
     [Description("Upper Volta (aka Burkina or Burkina Faso)")]
     [InternetDomainCode("Unknown")]
     UPPER_VOLTA_AKA_BURKINA_OR_BURKINA_FASO = 34,
     [Description("Uruguay")]
     [InternetDomainCode("UY")]
     URUGUAY = 226,
     [Description("Uzbekistan")]
     [InternetDomainCode("UZ")]
     UZBEKISTAN = 266,
     [Description("Vanuatu")]
     [InternetDomainCode("VU")]
     VANUATU = 227,
     [Description("Vatican City (Holy See)")]
     [InternetDomainCode("Unknown")]
     VATICAN_CITY_HOLY_SEE = 228,
     [Description("Venezuela")]
     [InternetDomainCode("VE")]
     VENEZUELA = 229,
     [Description("Vietnam")]
     [InternetDomainCode("Unknown")]
     VIETNAM = 230,
     [Description("Virgin Islands (United States)")]
     [InternetDomainCode("Unknown")]
     VIRGIN_ISLANDS_UNITED_STATES = 231,
     [Description("Wake Island (United States)")]
     [InternetDomainCode("Unknown")]
     WAKE_ISLAND_UNITED_STATES = 232,
     [Description("Wallis and Futuna (France)")]
     [InternetDomainCode("Unknown")]
     WALLIS_AND_FUTUNA_FRANCE = 233,
     [Description("West Bank (Israel)")]
     [InternetDomainCode("Unknown")]
     WEST_BANK_ISRAEL = 235,
     [Description("Western Sahara")]
     [InternetDomainCode("EH")]
     WESTERN_SAHARA = 234,
     [Description("Western Samoa")]
     [InternetDomainCode("Unknown")]
     WESTERN_SAMOA = 236,
     [Description("Yemen")]
     [InternetDomainCode("YE")]
     YEMEN = 237,
     [Description("Serbia and Montenegro")]
     [InternetDomainCode("CS")]
     SERBIA_AND_MONTENEGRO = 240,
     [Description("Zaire")]
     [InternetDomainCode("Unknown")]
     ZAIRE = 241,
     [Description("Zambia")]
     [InternetDomainCode("ZM")]
     ZAMBIA = 242,
     [Description("Zimbabwe")]
     [InternetDomainCode("ZW")]
     ZIMBABWE = 243        }//End Enum


    } //End Parial Class

} //End Namespace
