
using System;
using System.ComponentModel;
using System.Reflection;

/** Enumeration values for DatumSpecificationRecord
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

        public enum DatumSpecificationRecord 
        {

     [Description("Identification")]
     IDENTIFICATION = 10000,

     [Description("Entity Type")]
     ENTITY_TYPE = 11000,

     [Description("Concatenated")]
     CONCATENATED = 11100,

     [Description("Kind")]
     KIND = 11110,

     [Description("Domain")]
     DOMAIN = 11120,

     [Description("Country")]
     COUNTRY = 11130,

     [Description("Category")]
     CATEGORY = 11140,

     [Description("Subcategory")]
     SUBCATEGORY = 11150,

     [Description("Specific")]
     SPECIFIC = 11160,

     [Description("Extra")]
     EXTRA = 11170,

     [Description("Force ID")]
     FORCE_ID = 11200,

     [Description("Description")]
     DESCRIPTION = 11300,

     [Description("Alternative Entity Type")]
     ALTERNATIVE_ENTITY_TYPE = 12000,

     [Description("Kind")]
     KIND_1 = 12110,

     [Description("Domain")]
     DOMAIN_2 = 12120,

     [Description("Country")]
     COUNTRY_3 = 12130,

     [Description("Category")]
     CATEGORY_4 = 12140,

     [Description("Subcategory")]
     SUBCATEGORY_5 = 12150,

     [Description("Specific")]
     SPECIFIC_6 = 12160,

     [Description("Extra")]
     EXTRA_7 = 12170,

     [Description("Description")]
     DESCRIPTION_8 = 12300,

     [Description("Entity Marking")]
     ENTITY_MARKING = 13000,

     [Description("Entity Marking Characters")]
     ENTITY_MARKING_CHARACTERS = 13100,

     [Description("Crew ID")]
     CREW_ID = 13200,

     [Description("Task Organization")]
     TASK_ORGANIZATION = 14000,

     [Description("Regiment Name")]
     REGIMENT_NAME = 14200,

     [Description("Battalion Name")]
     BATTALION_NAME = 14300,

     [Description("Company Name")]
     COMPANY_NAME = 14400,

     [Description("Platoon Name")]
     PLATOON_NAME = 14500,

     [Description("Squad Name")]
     SQUAD_NAME = 14520,

     [Description("Team Name")]
     TEAM_NAME = 14540,

     [Description("Bumper Number")]
     BUMPER_NUMBER = 14600,

     [Description("Vehicle Number")]
     VEHICLE_NUMBER = 14700,

     [Description("Unit Number")]
     UNIT_NUMBER = 14800,

     [Description("DIS Identity")]
     DIS_IDENTITY = 15000,

     [Description("DIS Site ID")]
     DIS_SITE_ID = 15100,

     [Description("DIS Host ID")]
     DIS_HOST_ID = 15200,

     [Description("DIS Entity ID")]
     DIS_ENTITY_ID = 15300,

     [Description("Mount Intent")]
     MOUNT_INTENT = 15400,

     [Description("Tether-Unthether Command ID")]
     TETHER_UNTHETHER_COMMAND_ID = 15500,

     [Description("Teleport Entity Data Record")]
     TELEPORT_ENTITY_DATA_RECORD = 15510,

     [Description("DIS Aggregate ID (Set if communication to aggregate)")]
     DIS_AGGREGATE_ID_SET_IF_COMMUNICATION_TO_AGGREGATE = 15600,

     [Description("Loads")]
     LOADS = 20000,

     [Description("Crew Members")]
     CREW_MEMBERS = 21000,

     [Description("Crew Member ID")]
     CREW_MEMBER_ID = 21100,

     [Description("Health")]
     HEALTH = 21200,

     [Description("Job Assignment")]
     JOB_ASSIGNMENT = 21300,

     [Description("Fuel")]
     FUEL = 23000,

     [Description("Quantity")]
     QUANTITY = 23100,

     [Description("Quantity")]
     QUANTITY_9 = 23105,

     [Description("Ammunition")]
     AMMUNITION = 24000,

     [Description("120-mm HEAT, quantity")]
     X_120_MM_HEAT_QUANTITY = 24001,

     [Description("120-mm SABOT, quantity")]
     X_120_MM_SABOT_QUANTITY = 24002,

     [Description("12.7-mm M8, quantity")]
     X_127_MM_M8_QUANTITY = 24003,

     [Description("12.7-mm M20, quantity")]
     X_127_MM_M20_QUANTITY = 24004,

     [Description("7.62-mm M62, quantity")]
     X_762_MM_M62_QUANTITY = 24005,

     [Description("M250 UKL8A1, quantity")]
     M250_UKL8A1_QUANTITY = 24006,

     [Description("M250 UKL8A3, quantity")]
     M250_UKL8A3_QUANTITY = 24007,

     [Description("7.62-mm M80, quantity")]
     X_762_MM_M80_QUANTITY = 24008,

     [Description("12.7-mm, quantity")]
     X_127_MM_QUANTITY = 24009,

     [Description("7.62-mm, quantity")]
     X_762_MM_QUANTITY = 24010,

     [Description("Mines, quantity")]
     MINES_QUANTITY = 24060,

     [Description("Type")]
     TYPE = 24100,

     [Description("Kind")]
     KIND_10 = 24110,

     [Description("Domain")]
     DOMAIN_11 = 24120,

     [Description("Country")]
     COUNTRY_12 = 24130,

     [Description("Category")]
     CATEGORY_13 = 24140,

     [Description("Subcategory")]
     SUBCATEGORY_14 = 24150,

     [Description("Extra")]
     EXTRA_15 = 24160,

     [Description("Description")]
     DESCRIPTION_16 = 24300,

     [Description("Cargo")]
     CARGO = 25000,

     [Description("Vehicle Mass")]
     VEHICLE_MASS = 26000,

     [Description("Supply Quantity")]
     SUPPLY_QUANTITY = 27000,

     [Description("Armament")]
     ARMAMENT = 28000,

     [Description("Status")]
     STATUS = 30000,

     [Description("Activate entity")]
     ACTIVATE_ENTITY = 30010,

     [Description("Subscription State")]
     SUBSCRIPTION_STATE = 30100,

     [Description("Round trip time delay")]
     ROUND_TRIP_TIME_DELAY = 30300,

     [Description("TADIL J message count (label 0)")]
     TADIL_J_MESSAGE_COUNT_LABEL_0 = 30400,

     [Description("TADIL J message count (label 1)")]
     TADIL_J_MESSAGE_COUNT_LABEL_1 = 30401,

     [Description("TADIL J message count (label 2)")]
     TADIL_J_MESSAGE_COUNT_LABEL_2 = 30402,

     [Description("TADIL J message count (label 3)")]
     TADIL_J_MESSAGE_COUNT_LABEL_3 = 30403,

     [Description("TADIL J message count (label 4)")]
     TADIL_J_MESSAGE_COUNT_LABEL_4 = 30404,

     [Description("TADIL J message count (label 5)")]
     TADIL_J_MESSAGE_COUNT_LABEL_5 = 30405,

     [Description("TADIL J message count (label 6)")]
     TADIL_J_MESSAGE_COUNT_LABEL_6 = 30406,

     [Description("TADIL J message count (label 7)")]
     TADIL_J_MESSAGE_COUNT_LABEL_7 = 30407,

     [Description("TADIL J message count (label 8)")]
     TADIL_J_MESSAGE_COUNT_LABEL_8 = 30408,

     [Description("TADIL J message count (label 9)")]
     TADIL_J_MESSAGE_COUNT_LABEL_9 = 30409,

     [Description("TADIL J message count (label 10)")]
     TADIL_J_MESSAGE_COUNT_LABEL_10 = 30410,

     [Description("TADIL J message count (label 11)")]
     TADIL_J_MESSAGE_COUNT_LABEL_11 = 30411,

     [Description("TADIL J message count (label 12)")]
     TADIL_J_MESSAGE_COUNT_LABEL_12 = 30412,

     [Description("TADIL J message count (label 13)")]
     TADIL_J_MESSAGE_COUNT_LABEL_13 = 30413,

     [Description("TADIL J message count (label 14)")]
     TADIL_J_MESSAGE_COUNT_LABEL_14 = 30414,

     [Description("TADIL J message count (label 15)")]
     TADIL_J_MESSAGE_COUNT_LABEL_15 = 30415,

     [Description("TADIL J message count (label 16)")]
     TADIL_J_MESSAGE_COUNT_LABEL_16 = 30416,

     [Description("TADIL J message count (label 17)")]
     TADIL_J_MESSAGE_COUNT_LABEL_17 = 30417,

     [Description("TADIL J message count (label 18)")]
     TADIL_J_MESSAGE_COUNT_LABEL_18 = 30418,

     [Description("TADIL J message count (label 19)")]
     TADIL_J_MESSAGE_COUNT_LABEL_19 = 30419,

     [Description("TADIL J message count (label 20)")]
     TADIL_J_MESSAGE_COUNT_LABEL_20 = 30420,

     [Description("TADIL J message count (label 21)")]
     TADIL_J_MESSAGE_COUNT_LABEL_21 = 30421,

     [Description("TADIL J message count (label 22)")]
     TADIL_J_MESSAGE_COUNT_LABEL_22 = 30422,

     [Description("TADIL J message count (label 23)")]
     TADIL_J_MESSAGE_COUNT_LABEL_23 = 30423,

     [Description("TADIL J message count (label 24)")]
     TADIL_J_MESSAGE_COUNT_LABEL_24 = 30424,

     [Description("TADIL J message count (label 25)")]
     TADIL_J_MESSAGE_COUNT_LABEL_25 = 30425,

     [Description("TADIL J message count (label 26)")]
     TADIL_J_MESSAGE_COUNT_LABEL_26 = 30426,

     [Description("TADIL J message count (label 27)")]
     TADIL_J_MESSAGE_COUNT_LABEL_27 = 30427,

     [Description("TADIL J message count (label 28)")]
     TADIL_J_MESSAGE_COUNT_LABEL_28 = 30428,

     [Description("TADIL J message count (label 29)")]
     TADIL_J_MESSAGE_COUNT_LABEL_29 = 30429,

     [Description("TADIL J message count (label 30)")]
     TADIL_J_MESSAGE_COUNT_LABEL_30 = 30430,

     [Description("TADIL J message count (label 31)")]
     TADIL_J_MESSAGE_COUNT_LABEL_31 = 30431,

     [Description("Position")]
     POSITION = 31000,

     [Description("Route (Waypoint) type")]
     ROUTE_WAYPOINT_TYPE = 31010,

     [Description("MilGrid10")]
     MILGRID10 = 31100,

     [Description("Geocentric Coordinates")]
     GEOCENTRIC_COORDINATES = 31200,

     [Description("X")]
     X = 31210,

     [Description("Y")]
     Y = 31220,

     [Description("Z")]
     Z = 31230,

     [Description("Latitude")]
     LATITUDE = 31300,

     [Description("Longitude")]
     LONGITUDE = 31400,

     [Description("Line of Sight")]
     LINE_OF_SIGHT = 31500,

     [Description("X")]
     X_17 = 31510,

     [Description("Y")]
     Y_18 = 31520,

     [Description("Z")]
     Z_19 = 31530,

     [Description("Altitude")]
     ALTITUDE = 31600,

     [Description("Destination Latitude")]
     DESTINATION_LATITUDE = 31700,

     [Description("Destination Longitude")]
     DESTINATION_LONGITUDE = 31800,

     [Description("Destination Altitude")]
     DESTINATION_ALTITUDE = 31900,

     [Description("Orientation")]
     ORIENTATION = 32000,

     [Description("Hull Heading Angle")]
     HULL_HEADING_ANGLE = 32100,

     [Description("Hull Pitch Angle")]
     HULL_PITCH_ANGLE = 32200,

     [Description("Roll Angle")]
     ROLL_ANGLE = 32300,

     [Description("X")]
     X_20 = 32500,

     [Description("Y")]
     Y_21 = 32600,

     [Description("Z")]
     Z_22 = 32700,

     [Description("Appearance")]
     APPEARANCE = 33000,

     [Description("Ambient Lighting")]
     AMBIENT_LIGHTING = 33100,

     [Description("Lights")]
     LIGHTS = 33101,

     [Description("Paint Scheme")]
     PAINT_SCHEME = 33200,

     [Description("Smoke")]
     SMOKE = 33300,

     [Description("Trailing Effects")]
     TRAILING_EFFECTS = 33400,

     [Description("Flaming")]
     FLAMING = 33500,

     [Description("Marking")]
     MARKING = 33600,

     [Description("Mine Plows Attached")]
     MINE_PLOWS_ATTACHED = 33710,

     [Description("Mine Rollers Attached")]
     MINE_ROLLERS_ATTACHED = 33720,

     [Description("Tank Turret Azimuth")]
     TANK_TURRET_AZIMUTH = 33730,

     [Description("Failures and Malfunctions")]
     FAILURES_AND_MALFUNCTIONS = 34000,

     [Description("Age")]
     AGE = 34100,

     [Description("Kilometers")]
     KILOMETERS = 34110,

     [Description("Damage")]
     DAMAGE = 35000,

     [Description("Cause")]
     CAUSE = 35050,

     [Description("Mobility Kill")]
     MOBILITY_KILL = 35100,

     [Description("Fire-Power Kill")]
     FIRE_POWER_KILL = 35200,

     [Description("Personnel Casualties")]
     PERSONNEL_CASUALTIES = 35300,

     [Description("Velocity")]
     VELOCITY = 36000,

     [Description("X-velocity")]
     X_VELOCITY = 36100,

     [Description("Y-velocity")]
     Y_VELOCITY = 36200,

     [Description("Z-velocity")]
     Z_VELOCITY = 36300,

     [Description("Speed")]
     SPEED = 36400,

     [Description("Acceleration")]
     ACCELERATION = 37000,

     [Description("X-acceleration")]
     X_ACCELERATION = 37100,

     [Description("Y-acceleration")]
     Y_ACCELERATION = 37200,

     [Description("Z-acceleration")]
     Z_ACCELERATION = 37300,

     [Description("Engine Status")]
     ENGINE_STATUS = 38100,

     [Description("Primary Target Line (PTL)")]
     PRIMARY_TARGET_LINE_PTL = 39000,

     [Description("Exercise")]
     EXERCISE = 40000,

     [Description("Exercise State")]
     EXERCISE_STATE = 40010,

     [Description("Restart/Refresh")]
     RESTART_REFRESH = 40015,

     [Description("AFATDS File Name")]
     AFATDS_FILE_NAME = 40020,

     [Description("Terrain Database")]
     TERRAIN_DATABASE = 41000,

     [Description("41001")]
     X_41001 = 41001,

     [Description("Missions")]
     MISSIONS = 42000,

     [Description("Mission ID")]
     MISSION_ID = 42100,

     [Description("Mission Type")]
     MISSION_TYPE = 42200,

     [Description("Mission Request Time Stamp")]
     MISSION_REQUEST_TIME_STAMP = 42300,

     [Description("Exercise Description")]
     EXERCISE_DESCRIPTION = 43000,

     [Description("Name")]
     NAME = 43100,

     [Description("Entities")]
     ENTITIES = 43200,

     [Description("Version")]
     VERSION = 43300,

     [Description("Guise Mode")]
     GUISE_MODE = 43410,

     [Description("Simulation Application Active Status")]
     SIMULATION_APPLICATION_ACTIVE_STATUS = 43420,

     [Description("Simulation Application Role Record")]
     SIMULATION_APPLICATION_ROLE_RECORD = 43430,

     [Description("Simulation Application State")]
     SIMULATION_APPLICATION_STATE = 43440,

     [Description("Visual Output Mode")]
     VISUAL_OUTPUT_MODE = 44000,

     [Description("Simulation Manager Role")]
     SIMULATION_MANAGER_ROLE = 44100,

     [Description("Simulation Manager Site ID")]
     SIMULATION_MANAGER_SITE_ID = 44110,

     [Description("Simulation Manager Applic. ID")]
     SIMULATION_MANAGER_APPLIC_ID = 44120,

     [Description("Simulation Manager Entity ID")]
     SIMULATION_MANAGER_ENTITY_ID = 44130,

     [Description("Simulation Manager Active Status")]
     SIMULATION_MANAGER_ACTIVE_STATUS = 44140,

     [Description("After Active Review Role")]
     AFTER_ACTIVE_REVIEW_ROLE = 44200,

     [Description("After Active Review Site ID")]
     AFTER_ACTIVE_REVIEW_SITE_ID = 44210,

     [Description("After Active Applic. ID")]
     AFTER_ACTIVE_APPLIC_ID = 44220,

     [Description("After Active Review Entity ID")]
     AFTER_ACTIVE_REVIEW_ENTITY_ID = 44230,

     [Description("After Active Review Active Status")]
     AFTER_ACTIVE_REVIEW_ACTIVE_STATUS = 44240,

     [Description("Exercise Logger Role")]
     EXERCISE_LOGGER_ROLE = 44300,

     [Description("Exercise Logger Site ID")]
     EXERCISE_LOGGER_SITE_ID = 44310,

     [Description("Exercise Logger Applic. ID")]
     EXERCISE_LOGGER_APPLIC_ID = 44320,

     [Description("Exercise Entity ID")]
     EXERCISE_ENTITY_ID = 44330,

     [Description("Exercise Logger Active Status")]
     EXERCISE_LOGGER_ACTIVE_STATUS = 44340,

     [Description("Synthetic Environment Manager Role")]
     SYNTHETIC_ENVIRONMENT_MANAGER_ROLE = 44400,

     [Description("Synthetic Environment Manager Site ID")]
     SYNTHETIC_ENVIRONMENT_MANAGER_SITE_ID = 44410,

     [Description("Synthetic Environment Manager Applic. ID")]
     SYNTHETIC_ENVIRONMENT_MANAGER_APPLIC_ID = 44420,

     [Description("Synthetic Environment Manager Entity ID")]
     SYNTHETIC_ENVIRONMENT_MANAGER_ENTITY_ID = 44430,

     [Description("Synthetic Environment Manager Active Status")]
     SYNTHETIC_ENVIRONMENT_MANAGER_ACTIVE_STATUS = 44440,

     [Description("SIMNET-DIS Translator Role")]
     SIMNET_DIS_TRANSLATOR_ROLE = 44500,

     [Description("SIMNET-DIS Translator Site ID")]
     SIMNET_DIS_TRANSLATOR_SITE_ID = 44510,

     [Description("SIMNET-DIS Translator Applic. ID")]
     SIMNET_DIS_TRANSLATOR_APPLIC_ID = 44520,

     [Description("SIMNET-DIS Translator Entity ID")]
     SIMNET_DIS_TRANSLATOR_ENTITY_ID = 44530,

     [Description("SIMNET-DIS Translator Active Status")]
     SIMNET_DIS_TRANSLATOR_ACTIVE_STATUS = 44540,

     [Description("Application Rate")]
     APPLICATION_RATE = 45000,

     [Description("Application Time")]
     APPLICATION_TIME = 45005,

     [Description("Application Timestep")]
     APPLICATION_TIMESTEP = 45010,

     [Description("Feedback Time")]
     FEEDBACK_TIME = 45020,

     [Description("Simulation Rate")]
     SIMULATION_RATE = 45030,

     [Description("Simulation Time")]
     SIMULATION_TIME = 45040,

     [Description("Simulation Timestep")]
     SIMULATION_TIMESTEP = 45050,

     [Description("Time Interval")]
     TIME_INTERVAL = 45060,

     [Description("Time Latency")]
     TIME_LATENCY = 45070,

     [Description("Time Scheme")]
     TIME_SCHEME = 45080,

     [Description("Exercise Elapsed Time")]
     EXERCISE_ELAPSED_TIME = 46000,

     [Description("Elapsed Time")]
     ELAPSED_TIME = 46010,

     [Description("Environment")]
     ENVIRONMENT = 50000,

     [Description("Weather")]
     WEATHER = 51000,

     [Description("Weather Condition")]
     WEATHER_CONDITION = 51010,

     [Description("Thermal Condition")]
     THERMAL_CONDITION = 51100,

     [Description("Thermal Visibility")]
     THERMAL_VISIBILITY = 51110,

     [Description("Thermal Visibility")]
     THERMAL_VISIBILITY_23 = 51111,

     [Description("Time")]
     TIME = 52000,

     [Description("Time")]
     TIME_24 = 52001,

     [Description("Time of Day, Discrete")]
     TIME_OF_DAY_DISCRETE = 52100,

     [Description("Time of Day, Continuous")]
     TIME_OF_DAY_CONTINUOUS = 52200,

     [Description("Time Mode")]
     TIME_MODE = 52300,

     [Description("Time Scene")]
     TIME_SCENE = 52305,

     [Description("Current Hour")]
     CURRENT_HOUR = 52310,

     [Description("Current Minute")]
     CURRENT_MINUTE = 52320,

     [Description("Current Second")]
     CURRENT_SECOND = 52330,

     [Description("Azimuth")]
     AZIMUTH = 52340,

     [Description("Maximum Elevation")]
     MAXIMUM_ELEVATION = 52350,

     [Description("Time Zone")]
     TIME_ZONE = 52360,

     [Description("Time Rate")]
     TIME_RATE = 52370,

     [Description("The number of simulation seconds since the start of the exercise (simulation time)")]
     THE_NUMBER_OF_SIMULATION_SECONDS_SINCE_THE_START_OF_THE_EXERCISE_SIMULATION_TIME = 52380,

     [Description("Time Sunrise Enabled")]
     TIME_SUNRISE_ENABLED = 52400,

     [Description("Sunrise Hour")]
     SUNRISE_HOUR = 52410,

     [Description("Sunrise Minute")]
     SUNRISE_MINUTE = 52420,

     [Description("Sunrise Second")]
     SUNRISE_SECOND = 52430,

     [Description("Sunrise Azimuth")]
     SUNRISE_AZIMUTH = 52440,

     [Description("Time Sunset Enabled")]
     TIME_SUNSET_ENABLED = 52500,

     [Description("Sunset Hour")]
     SUNSET_HOUR = 52510,

     [Description("Sunset Hour")]
     SUNSET_HOUR_25 = 52511,

     [Description("Sunset Minute")]
     SUNSET_MINUTE = 52520,

     [Description("Sunset Second")]
     SUNSET_SECOND = 52530,

     [Description("52531")]
     X_52531 = 52531,

     [Description("Date")]
     DATE = 52600,

     [Description("Date (European)")]
     DATE_EUROPEAN = 52601,

     [Description("Date (US)")]
     DATE_US = 52602,

     [Description("Month")]
     MONTH = 52610,

     [Description("Day")]
     DAY = 52620,

     [Description("Year")]
     YEAR = 52630,

     [Description("Clouds")]
     CLOUDS = 53000,

     [Description("Cloud Layer Enable")]
     CLOUD_LAYER_ENABLE = 53050,

     [Description("Cloud Layer Selection")]
     CLOUD_LAYER_SELECTION = 53060,

     [Description("Visibility")]
     VISIBILITY = 53100,

     [Description("Base Altitude")]
     BASE_ALTITUDE = 53200,

     [Description("Base Altitude")]
     BASE_ALTITUDE_26 = 53250,

     [Description("Ceiling")]
     CEILING = 53300,

     [Description("Ceiling")]
     CEILING_27 = 53350,

     [Description("Characteristics")]
     CHARACTERISTICS = 53400,

     [Description("Concentration Length")]
     CONCENTRATION_LENGTH = 53410,

     [Description("Transmittance")]
     TRANSMITTANCE = 53420,

     [Description("Radiance")]
     RADIANCE = 53430,

     [Description("Precipitation")]
     PRECIPITATION = 54000,

     [Description("Rain")]
     RAIN = 54100,

     [Description("Fog")]
     FOG = 55000,

     [Description("Visibility")]
     VISIBILITY_28 = 55100,

     [Description("Visibility")]
     VISIBILITY_29 = 55101,

     [Description("Visibility")]
     VISIBILITY_30 = 55105,

     [Description("Density")]
     DENSITY = 55200,

     [Description("Base")]
     BASE = 55300,

     [Description("View Layer from above.")]
     VIEW_LAYER_FROM_ABOVE = 55401,

     [Description("Transition Range")]
     TRANSITION_RANGE = 55410,

     [Description("Bottom")]
     BOTTOM = 55420,

     [Description("Bottom")]
     BOTTOM_31 = 55425,

     [Description("Ceiling")]
     CEILING_32 = 55430,

     [Description("Ceiling")]
     CEILING_33 = 55435,

     [Description("Heavenly Bodies")]
     HEAVENLY_BODIES = 56000,

     [Description("Sun")]
     SUN = 56100,

     [Description("Sun Visible")]
     SUN_VISIBLE = 56105,

     [Description("Position")]
     POSITION_34 = 56110,

     [Description("Sun Position Elevation, Degrees")]
     SUN_POSITION_ELEVATION_DEGREES = 56111,

     [Description("Position Azimuth")]
     POSITION_AZIMUTH = 56120,

     [Description("Sun Position Azimuth, Degrees")]
     SUN_POSITION_AZIMUTH_DEGREES = 56121,

     [Description("Position Elevation")]
     POSITION_ELEVATION = 56130,

     [Description("Position Intensity")]
     POSITION_INTENSITY = 56140,

     [Description("Moon")]
     MOON = 56200,

     [Description("Moon Visible")]
     MOON_VISIBLE = 56205,

     [Description("Position")]
     POSITION_35 = 56210,

     [Description("Position Azimuth")]
     POSITION_AZIMUTH_36 = 56220,

     [Description("Moon Position Azimuth, Degrees")]
     MOON_POSITION_AZIMUTH_DEGREES = 56221,

     [Description("Position Elevation")]
     POSITION_ELEVATION_37 = 56230,

     [Description("Moon Position Elevation, Degrees")]
     MOON_POSITION_ELEVATION_DEGREES = 56231,

     [Description("Position Intensity")]
     POSITION_INTENSITY_38 = 56240,

     [Description("Horizon")]
     HORIZON = 56310,

     [Description("Horizon Azimuth")]
     HORIZON_AZIMUTH = 56320,

     [Description("Horizon Elevation")]
     HORIZON_ELEVATION = 56330,

     [Description("Horizon Heading")]
     HORIZON_HEADING = 56340,

     [Description("Horizon Intensity")]
     HORIZON_INTENSITY = 56350,

     [Description("Humidity")]
     HUMIDITY = 57200,

     [Description("Visibility")]
     VISIBILITY_39 = 57300,

     [Description("Winds")]
     WINDS = 57400,

     [Description("Speed")]
     SPEED_40 = 57410,

     [Description("Wind Speed, Knots")]
     WIND_SPEED_KNOTS = 57411,

     [Description("Wind Direction")]
     WIND_DIRECTION = 57420,

     [Description("Wind Direction, Degrees")]
     WIND_DIRECTION_DEGREES = 57421,

     [Description("Rainsoak")]
     RAINSOAK = 57500,

     [Description("Tide Speed")]
     TIDE_SPEED = 57610,

     [Description("Tide Speed, Knots")]
     TIDE_SPEED_KNOTS = 57611,

     [Description("Tide Direction")]
     TIDE_DIRECTION = 57620,

     [Description("Tide Direction, Degrees")]
     TIDE_DIRECTION_DEGREES = 57621,

     [Description("Haze")]
     HAZE = 58000,

     [Description("Visibility")]
     VISIBILITY_41 = 58100,

     [Description("Visibility")]
     VISIBILITY_42 = 58105,

     [Description("Density")]
     DENSITY_43 = 58200,

     [Description("Ceiling")]
     CEILING_44 = 58430,

     [Description("Ceiling")]
     CEILING_45 = 58435,

     [Description("Contaminants and Obscurants")]
     CONTAMINANTS_AND_OBSCURANTS = 59000,

     [Description("Contaminant/Obscurant Type")]
     CONTAMINANT_OBSCURANT_TYPE = 59100,

     [Description("Persistence")]
     PERSISTENCE = 59110,

     [Description("Chemical Dosage")]
     CHEMICAL_DOSAGE = 59115,

     [Description("Chemical Air Concentration")]
     CHEMICAL_AIR_CONCENTRATION = 59120,

     [Description("Chemical Ground Deposition")]
     CHEMICAL_GROUND_DEPOSITION = 59125,

     [Description("Chemical Maximum Ground Deposition")]
     CHEMICAL_MAXIMUM_GROUND_DEPOSITION = 59130,

     [Description("Chemical Dosage Threshold")]
     CHEMICAL_DOSAGE_THRESHOLD = 59135,

     [Description("Biological Dosage")]
     BIOLOGICAL_DOSAGE = 59140,

     [Description("Biological Air Concentration")]
     BIOLOGICAL_AIR_CONCENTRATION = 59145,

     [Description("Biological Dosage Threshold")]
     BIOLOGICAL_DOSAGE_THRESHOLD = 59150,

     [Description("Biological Binned Particle Count")]
     BIOLOGICAL_BINNED_PARTICLE_COUNT = 59155,

     [Description("Radiological Dosage")]
     RADIOLOGICAL_DOSAGE = 59160,

     [Description("Communications")]
     COMMUNICATIONS = 60000,

     [Description("Channel Type")]
     CHANNEL_TYPE = 61100,

     [Description("Channel Type")]
     CHANNEL_TYPE_46 = 61101,

     [Description("Channel Identification")]
     CHANNEL_IDENTIFICATION = 61200,

     [Description("Alpha Identification")]
     ALPHA_IDENTIFICATION = 61300,

     [Description("61301")]
     X_61301 = 61301,

     [Description("Radio Identification")]
     RADIO_IDENTIFICATION = 61400,

     [Description("61401")]
     X_61401 = 61401,

     [Description("Land Line Identification")]
     LAND_LINE_IDENTIFICATION = 61500,

     [Description("Intercom Identification")]
     INTERCOM_IDENTIFICATION = 61600,

     [Description("Group Network Channel Number")]
     GROUP_NETWORK_CHANNEL_NUMBER = 61700,

     [Description("Radio Communications Status")]
     RADIO_COMMUNICATIONS_STATUS = 62100,

     [Description("Stationary Radio Transmitters Default Time")]
     STATIONARY_RADIO_TRANSMITTERS_DEFAULT_TIME = 62200,

     [Description("Moving Radio Transmitters Default Time")]
     MOVING_RADIO_TRANSMITTERS_DEFAULT_TIME = 62300,

     [Description("Stationary Radio Signals Default Time")]
     STATIONARY_RADIO_SIGNALS_DEFAULT_TIME = 62400,

     [Description("Moving Radio Signal Default Time")]
     MOVING_RADIO_SIGNAL_DEFAULT_TIME = 62500,

     [Description("Radio Initialization Transec Security Key")]
     RADIO_INITIALIZATION_TRANSEC_SECURITY_KEY = 63101,

     [Description("Radio Initialization Internal Noise Level")]
     RADIO_INITIALIZATION_INTERNAL_NOISE_LEVEL = 63102,

     [Description("Radio Initialization Squelch Threshold")]
     RADIO_INITIALIZATION_SQUELCH_THRESHOLD = 63103,

     [Description("Radio Initialization Antenna Location")]
     RADIO_INITIALIZATION_ANTENNA_LOCATION = 63104,

     [Description("Radio Initialization Antenna Pattern Type")]
     RADIO_INITIALIZATION_ANTENNA_PATTERN_TYPE = 63105,

     [Description("Radio Initialization Antenna Pattern Length")]
     RADIO_INITIALIZATION_ANTENNA_PATTERN_LENGTH = 63106,

     [Description("Radio Initialization Beam Definition")]
     RADIO_INITIALIZATION_BEAM_DEFINITION = 63107,

     [Description("Radio Initialization Transmit Heartbeat Time")]
     RADIO_INITIALIZATION_TRANSMIT_HEARTBEAT_TIME = 63108,

     [Description("Radio Initialization Transmit Distance Threshold Variable Record")]
     RADIO_INITIALIZATION_TRANSMIT_DISTANCE_THRESHOLD_VARIABLE_RECORD = 63109,

     [Description("Radio Channel Initialization Lockout ID")]
     RADIO_CHANNEL_INITIALIZATION_LOCKOUT_ID = 63110,

     [Description("Radio Channel Initialization Hopset ID")]
     RADIO_CHANNEL_INITIALIZATION_HOPSET_ID = 63111,

     [Description("Radio Channel Initialization Preset Frequency")]
     RADIO_CHANNEL_INITIALIZATION_PRESET_FREQUENCY = 63112,

     [Description("Radio Channel Initialization Frequency Sync Time")]
     RADIO_CHANNEL_INITIALIZATION_FREQUENCY_SYNC_TIME = 63113,

     [Description("Radio Channel Initialization Comsec Key")]
     RADIO_CHANNEL_INITIALIZATION_COMSEC_KEY = 63114,

     [Description("Radio Channel Initialization Alpha")]
     RADIO_CHANNEL_INITIALIZATION_ALPHA = 63115,

     [Description("Algorithm Parameters")]
     ALGORITHM_PARAMETERS = 70000,

     [Description("Dead Reckoning Algorithm (DRA)")]
     DEAD_RECKONING_ALGORITHM_DRA = 71000,

     [Description("DRA Location Threshold")]
     DRA_LOCATION_THRESHOLD = 71100,

     [Description("DRA Orientation Threshold")]
     DRA_ORIENTATION_THRESHOLD = 71200,

     [Description("DRA Time Threshold")]
     DRA_TIME_THRESHOLD = 71300,

     [Description("Simulation Management Parameters")]
     SIMULATION_MANAGEMENT_PARAMETERS = 72000,

     [Description("Checkpoint Interval")]
     CHECKPOINT_INTERVAL = 72100,

     [Description("Transmitter Time Threshold")]
     TRANSMITTER_TIME_THRESHOLD = 72600,

     [Description("Receiver Time Threshold")]
     RECEIVER_TIME_THRESHOLD = 72700,

     [Description("Interoperability Mode")]
     INTEROPERABILITY_MODE = 73000,

     [Description("SIMNET Data Collection")]
     SIMNET_DATA_COLLECTION = 74000,

     [Description("Event ID")]
     EVENT_ID = 75000,

     [Description("Source Site ID")]
     SOURCE_SITE_ID = 75100,

     [Description("Source Host ID")]
     SOURCE_HOST_ID = 75200,

     [Description("Articulated Parts")]
     ARTICULATED_PARTS = 90000,

     [Description("90001")]
     X_90001 = 90001,

     [Description("Part ID")]
     PART_ID = 90050,

     [Description("Index")]
     INDEX = 90070,

     [Description("Position")]
     POSITION_47 = 90100,

     [Description("Position Rate")]
     POSITION_RATE = 90200,

     [Description("Extension")]
     EXTENSION = 90300,

     [Description("Extension Rate")]
     EXTENSION_RATE = 90400,

     [Description("X")]
     X_48 = 90500,

     [Description("X-rate")]
     X_RATE = 90600,

     [Description("Y")]
     Y_49 = 90700,

     [Description("Y-rate")]
     Y_RATE = 90800,

     [Description("Z")]
     Z_50 = 90900,

     [Description("Z-rate")]
     Z_RATE = 91000,

     [Description("Azimuth")]
     AZIMUTH_51 = 91100,

     [Description("Azimuth Rate")]
     AZIMUTH_RATE = 91200,

     [Description("Elevation")]
     ELEVATION = 91300,

     [Description("Elevation Rate")]
     ELEVATION_RATE = 91400,

     [Description("Rotation")]
     ROTATION = 91500,

     [Description("Rotation Rate")]
     ROTATION_RATE = 91600,

     [Description("DRA Angular X-Velocity")]
     DRA_ANGULAR_X_VELOCITY = 100001,

     [Description("DRA Angular Y-Velocity")]
     DRA_ANGULAR_Y_VELOCITY = 100002,

     [Description("DRA Angular Z-Velocity")]
     DRA_ANGULAR_Z_VELOCITY = 100003,

     [Description("Appearance, Trailing Effects")]
     APPEARANCE_TRAILING_EFFECTS = 100004,

     [Description("Appearance, Hatch")]
     APPEARANCE_HATCH = 100005,

     [Description("Appearance, Character Set")]
     APPEARANCE_CHARACTER_SET = 100008,

     [Description("Capability, Ammunition Supplier")]
     CAPABILITY_AMMUNITION_SUPPLIER = 100010,

     [Description("Capability, Miscellaneous Supplier")]
     CAPABILITY_MISCELLANEOUS_SUPPLIER = 100011,

     [Description("Capability, Repair Provider")]
     CAPABILITY_REPAIR_PROVIDER = 100012,

     [Description("Articulation Parameter")]
     ARTICULATION_PARAMETER = 100014,

     [Description("Articulation Parameter Type")]
     ARTICULATION_PARAMETER_TYPE = 100047,

     [Description("Articulation Parameter Value")]
     ARTICULATION_PARAMETER_VALUE = 100048,

     [Description("Time of Day-Scene")]
     TIME_OF_DAY_SCENE = 100058,

     [Description("Latitude-North (Location of weather cell)")]
     LATITUDE_NORTH_LOCATION_OF_WEATHER_CELL = 100061,

     [Description("Longitude-East (Location of weather cell)")]
     LONGITUDE_EAST_LOCATION_OF_WEATHER_CELL = 100063,

     [Description("Tactical Driver Status")]
     TACTICAL_DRIVER_STATUS = 100068,

     [Description("Sonar System Status")]
     SONAR_SYSTEM_STATUS = 100100,

     [Description("Upper latitude")]
     UPPER_LATITUDE = 100161,

     [Description("Latitude-South (Location of weather cell)")]
     LATITUDE_SOUTH_LOCATION_OF_WEATHER_CELL = 100162,

     [Description("Western longitude")]
     WESTERN_LONGITUDE = 100163,

     [Description("Longitude-West (location of weather cell)")]
     LONGITUDE_WEST_LOCATION_OF_WEATHER_CELL = 100164,

     [Description("Accomplished accept")]
     ACCOMPLISHED_ACCEPT = 100165,

     [Description("CD ROM Number (Disk ID for terrain)")]
     CD_ROM_NUMBER_DISK_ID_FOR_TERRAIN = 100165,

     [Description("DTED disk ID")]
     DTED_DISK_ID = 100166,

     [Description("Altitude")]
     ALTITUDE_52 = 100167,

     [Description("Tactical System Status")]
     TACTICAL_SYSTEM_STATUS = 100169,

     [Description("JTIDS Status")]
     JTIDS_STATUS = 100170,

     [Description("TADIL-J Status")]
     TADIL_J_STATUS = 100171,

     [Description("DSDD Status")]
     DSDD_STATUS = 100172,

     [Description("Weapon System Status")]
     WEAPON_SYSTEM_STATUS = 100200,

     [Description("Subsystem status")]
     SUBSYSTEM_STATUS = 100205,

     [Description("Number of interceptors fired")]
     NUMBER_OF_INTERCEPTORS_FIRED = 100206,

     [Description("Number of interceptor detonations")]
     NUMBER_OF_INTERCEPTOR_DETONATIONS = 100207,

     [Description("Number of message buffers dropped")]
     NUMBER_OF_MESSAGE_BUFFERS_DROPPED = 100208,

     [Description("Satellite sensor background (year, day)")]
     SATELLITE_SENSOR_BACKGROUND_YEAR_DAY = 100213,

     [Description("Satellite sensor background (hour, minute)")]
     SATELLITE_SENSOR_BACKGROUND_HOUR_MINUTE = 100214,

     [Description("Script Number")]
     SCRIPT_NUMBER = 100218,

     [Description("Entity/Track/Update Data")]
     ENTITY_TRACK_UPDATE_DATA = 100300,

     [Description("Local/Force Training")]
     LOCAL_FORCE_TRAINING = 100400,

     [Description("Entity/Track Identity Data")]
     ENTITY_TRACK_IDENTITY_DATA = 100500,

     [Description("Entity for Track Event")]
     ENTITY_FOR_TRACK_EVENT = 100510,

     [Description("IFF (Friend-Foe) status")]
     IFF_FRIEND_FOE_STATUS = 100520,

     [Description("Engagement Data")]
     ENGAGEMENT_DATA = 100600,

     [Description("Target Latitude")]
     TARGET_LATITUDE = 100610,

     [Description("Target Longitude")]
     TARGET_LONGITUDE = 100620,

     [Description("Area of Interest (Ground Impact Circle) Center Latitude")]
     AREA_OF_INTEREST_GROUND_IMPACT_CIRCLE_CENTER_LATITUDE = 100631,

     [Description("Area of Interest (Ground Impact Circle) Center Longitude")]
     AREA_OF_INTEREST_GROUND_IMPACT_CIRCLE_CENTER_LONGITUDE = 100632,

     [Description("Area of Interest (Ground Impact Circle) Radius")]
     AREA_OF_INTEREST_GROUND_IMPACT_CIRCLE_RADIUS = 100633,

     [Description("Area of Interest Type")]
     AREA_OF_INTEREST_TYPE = 100634,

     [Description("Target Aggregate ID")]
     TARGET_AGGREGATE_ID = 100640,

     [Description("GIC Identification Number")]
     GIC_IDENTIFICATION_NUMBER = 100650,

     [Description("Estimated Time of Flight to TBM Impact")]
     ESTIMATED_TIME_OF_FLIGHT_TO_TBM_IMPACT = 100660,

     [Description("Estimated Intercept Time")]
     ESTIMATED_INTERCEPT_TIME = 100661,

     [Description("Estimated Time of Flight to Next Waypoint")]
     ESTIMATED_TIME_OF_FLIGHT_TO_NEXT_WAYPOINT = 100662,

     [Description("Entity/Track Equipment Data")]
     ENTITY_TRACK_EQUIPMENT_DATA = 100700,

     [Description("Emission/EW Data")]
     EMISSION_EW_DATA = 100800,

     [Description("Appearance Data")]
     APPEARANCE_DATA = 100900,

     [Description("Command/Order Data")]
     COMMAND_ORDER_DATA = 101000,

     [Description("Environmental Data")]
     ENVIRONMENTAL_DATA = 101100,

     [Description("Significant Event Data")]
     SIGNIFICANT_EVENT_DATA = 101200,

     [Description("Operator Action Data")]
     OPERATOR_ACTION_DATA = 101300,

     [Description("ADA Engagement Mode")]
     ADA_ENGAGEMENT_MODE = 101310,

     [Description("ADA Shooting Status")]
     ADA_SHOOTING_STATUS = 101320,

     [Description("ADA Mode")]
     ADA_MODE = 101321,

     [Description("ADA Radar Status")]
     ADA_RADAR_STATUS = 101330,

     [Description("Shoot Command")]
     SHOOT_COMMAND = 101340,

     [Description("ADA Weapon Status")]
     ADA_WEAPON_STATUS = 101350,

     [Description("ADA Firing Disciple")]
     ADA_FIRING_DISCIPLE = 101360,

     [Description("Order Status")]
     ORDER_STATUS = 101370,

     [Description("Time Synchronization")]
     TIME_SYNCHRONIZATION = 101400,

     [Description("Tomahawk Data")]
     TOMAHAWK_DATA = 101500,

     [Description("Number of Detonations")]
     NUMBER_OF_DETONATIONS = 102100,

     [Description("Number of Intercepts")]
     NUMBER_OF_INTERCEPTS = 102200,

     [Description("OBT Control MT-201")]
     OBT_CONTROL_MT_201 = 200201,

     [Description("Sensor Data MT-202")]
     SENSOR_DATA_MT_202 = 200202,

     [Description("Environmental Data MT-203")]
     ENVIRONMENTAL_DATA_MT_203 = 200203,

     [Description("Ownship Data MT-204")]
     OWNSHIP_DATA_MT_204 = 200204,

     [Description("Acoustic Contact Data MT-205")]
     ACOUSTIC_CONTACT_DATA_MT_205 = 200205,

     [Description("Sonobuoy Data MT-207")]
     SONOBUOY_DATA_MT_207 = 200207,

     [Description("Sonobuoy Contact Data MT-210")]
     SONOBUOY_CONTACT_DATA_MT_210 = 200210,

     [Description("Helo Control MT-211")]
     HELO_CONTROL_MT_211 = 200211,

     [Description("ESM Control Data")]
     ESM_CONTROL_DATA = 200213,

     [Description("ESM Contact Data MT-214")]
     ESM_CONTACT_DATA_MT_214 = 200214,

     [Description("ESM Emitter Data MT-215")]
     ESM_EMITTER_DATA_MT_215 = 200215,

     [Description("Weapon Definition Data MT-217")]
     WEAPON_DEFINITION_DATA_MT_217 = 200216,

     [Description("Weapon Preset Data MT-217")]
     WEAPON_PRESET_DATA_MT_217 = 200217,

     [Description("OBT Control MT-301")]
     OBT_CONTROL_MT_301 = 200301,

     [Description("Sensor Data MT-302")]
     SENSOR_DATA_MT_302 = 200302,

     [Description("Environmental Data MT-303m")]
     ENVIRONMENTAL_DATA_MT_303M = 200303,

     [Description("Ownship Data MT-304")]
     OWNSHIP_DATA_MT_304 = 200304,

     [Description("Acoustic Contact Data MT-305")]
     ACOUSTIC_CONTACT_DATA_MT_305 = 200305,

     [Description("Sonobuoy Data MT-307")]
     SONOBUOY_DATA_MT_307 = 200307,

     [Description("Sonobuoy Contact Data MT-310")]
     SONOBUOY_CONTACT_DATA_MT_310 = 200310,

     [Description("Helo Scenario / Equipment Status")]
     HELO_SCENARIO_EQUIPMENT_STATUS = 200311,

     [Description("ESM Control Data MT-313")]
     ESM_CONTROL_DATA_MT_313 = 200313,

     [Description("ESM Contact Data MT-314")]
     ESM_CONTACT_DATA_MT_314 = 200314,

     [Description("ESM Emitter Data MT-315")]
     ESM_EMITTER_DATA_MT_315 = 200315,

     [Description("Weapon Definition Data MT-316")]
     WEAPON_DEFINITION_DATA_MT_316 = 200316,

     [Description("Weapon Preset Data MT-317")]
     WEAPON_PRESET_DATA_MT_317 = 200317,

     [Description("Pairing/Association (eMT-56)")]
     PAIRING_ASSOCIATION_EMT_56 = 200400,

     [Description("Pointer (eMT-57)")]
     POINTER_EMT_57 = 200401,

     [Description("Reporting Responsibility (eMT-58)")]
     REPORTING_RESPONSIBILITY_EMT_58 = 200402,

     [Description("Track Number (eMT-59)")]
     TRACK_NUMBER_EMT_59 = 200403,

     [Description("ID for Link-11 Reporting (eMT-60)")]
     ID_FOR_LINK_11_REPORTING_EMT_60 = 200404,

     [Description("Remote Track (eMT-62)")]
     REMOTE_TRACK_EMT_62 = 200405,

     [Description("Link-11 Error Rate (eMT-63)")]
     LINK_11_ERROR_RATE_EMT_63 = 200406,

     [Description("Track Quality (eMT-64)")]
     TRACK_QUALITY_EMT_64 = 200407,

     [Description("Gridlock (eMT-65)")]
     GRIDLOCK_EMT_65 = 200408,

     [Description("Kill (eMT-66)")]
     KILL_EMT_66 = 200409,

     [Description("Track ID Change / Resolution (eMT-68)")]
     TRACK_ID_CHANGE_RESOLUTION_EMT_68 = 200410,

     [Description("Weapons Status (eMT-69)")]
     WEAPONS_STATUS_EMT_69 = 200411,

     [Description("Link-11 Operator (eMT-70)")]
     LINK_11_OPERATOR_EMT_70 = 200412,

     [Description("Force Training Transmit (eMT-71)")]
     FORCE_TRAINING_TRANSMIT_EMT_71 = 200413,

     [Description("Force Training Receive (eMT-72)")]
     FORCE_TRAINING_RECEIVE_EMT_72 = 200414,

     [Description("Interceptor Amplification (eMT-75)")]
     INTERCEPTOR_AMPLIFICATION_EMT_75 = 200415,

     [Description("Consumables (eMT-78)")]
     CONSUMABLES_EMT_78 = 200416,

     [Description("Link-11 Local Track Quality (eMT-95)")]
     LINK_11_LOCAL_TRACK_QUALITY_EMT_95 = 200417,

     [Description("DLRP (eMT-19)")]
     DLRP_EMT_19 = 200418,

     [Description("Force Order (eMT-52)")]
     FORCE_ORDER_EMT_52 = 200419,

     [Description("Wilco / Cantco (eMT-53)")]
     WILCO_CANTCO_EMT_53 = 200420,

     [Description("EMC Bearing (eMT-54)")]
     EMC_BEARING_EMT_54 = 200421,

     [Description("Change Track Eligibility (eMT-55)")]
     CHANGE_TRACK_ELIGIBILITY_EMT_55 = 200422,

     [Description("Land Mass Reference Point")]
     LAND_MASS_REFERENCE_POINT = 200423,

     [Description("System Reference Point")]
     SYSTEM_REFERENCE_POINT = 200424,

     [Description("PU Amplification")]
     PU_AMPLIFICATION = 200425,

     [Description("Set/Drift")]
     SET_DRIFT = 200426,

     [Description("Begin Initialization (MT-1)")]
     BEGIN_INITIALIZATION_MT_1 = 200427,

     [Description("Status and Control (MT-3)")]
     STATUS_AND_CONTROL_MT_3 = 200428,

     [Description("Scintillation Change (MT-39)")]
     SCINTILLATION_CHANGE_MT_39 = 200429,

     [Description("Link 11 ID Control (MT-61)")]
     LINK_11_ID_CONTROL_MT_61 = 200430,

     [Description("PU Guard List")]
     PU_GUARD_LIST = 200431,

     [Description("Winds Aloft (MT-14)")]
     WINDS_ALOFT_MT_14 = 200432,

     [Description("Surface Winds (MT-15)")]
     SURFACE_WINDS_MT_15 = 200433,

     [Description("Sea State (MT-17)")]
     SEA_STATE_MT_17 = 200434,

     [Description("Magnetic Variation (MT-37)")]
     MAGNETIC_VARIATION_MT_37 = 200435,

     [Description("Track Eligibility (MT-29)")]
     TRACK_ELIGIBILITY_MT_29 = 200436,

     [Description("Training Track Notification")]
     TRAINING_TRACK_NOTIFICATION = 200437,

     [Description("Tacan Data (MT-32)")]
     TACAN_DATA_MT_32 = 200501,

     [Description("Interceptor Amplification (MT-75)")]
     INTERCEPTOR_AMPLIFICATION_MT_75 = 200502,

     [Description("Tacan Assignment (MT-76)")]
     TACAN_ASSIGNMENT_MT_76 = 200503,

     [Description("Autopilot Status (MT-77)")]
     AUTOPILOT_STATUS_MT_77 = 200504,

     [Description("Consumables (MT-78)")]
     CONSUMABLES_MT_78 = 200505,

     [Description("Downlink (MT-79)")]
     DOWNLINK_MT_79 = 200506,

     [Description("TIN Report (MT-80)")]
     TIN_REPORT_MT_80 = 200507,

     [Description("Special Point Control (MT-81)")]
     SPECIAL_POINT_CONTROL_MT_81 = 200508,

     [Description("Control Discretes (MT-82)")]
     CONTROL_DISCRETES_MT_82 = 200509,

     [Description("Request Target Discretes(MT-83)")]
     REQUEST_TARGET_DISCRETESMT_83 = 200510,

     [Description("Target Discretes (MT-84)")]
     TARGET_DISCRETES_MT_84 = 200511,

     [Description("Reply Discretes (MT-85)")]
     REPLY_DISCRETES_MT_85 = 200512,

     [Description("Command Maneuvers (MT-86)")]
     COMMAND_MANEUVERS_MT_86 = 200513,

     [Description("Target Data (MT-87)")]
     TARGET_DATA_MT_87 = 200514,

     [Description("Target Pointer (MT-88)")]
     TARGET_POINTER_MT_88 = 200515,

     [Description("Intercept Data (MT-89)")]
     INTERCEPT_DATA_MT_89 = 200516,

     [Description("Decrement Missile Inventory (MT-90)")]
     DECREMENT_MISSILE_INVENTORY_MT_90 = 200517,

     [Description("Link-4A Alert (MT-91)")]
     LINK_4A_ALERT_MT_91 = 200518,

     [Description("Strike Control (MT-92)")]
     STRIKE_CONTROL_MT_92 = 200519,

     [Description("Speed Change (MT-25)")]
     SPEED_CHANGE_MT_25 = 200521,

     [Description("Course Change (MT-26)")]
     COURSE_CHANGE_MT_26 = 200522,

     [Description("Altitude Change (MT-27)")]
     ALTITUDE_CHANGE_MT_27 = 200523,

     [Description("ACLS AN/SPN-46 Status")]
     ACLS_AN_SPN_46_STATUS = 200524,

     [Description("ACLS Aircraft Report")]
     ACLS_AIRCRAFT_REPORT = 200525,

     [Description("SPS-67 Radar Operator Functions")]
     SPS_67_RADAR_OPERATOR_FUNCTIONS = 200600,

     [Description("SPS-55 Radar Operator Functions")]
     SPS_55_RADAR_OPERATOR_FUNCTIONS = 200601,

     [Description("SPQ-9A Radar Operator Functions")]
     SPQ_9A_RADAR_OPERATOR_FUNCTIONS = 200602,

     [Description("SPS-49 Radar Operator Functions")]
     SPS_49_RADAR_OPERATOR_FUNCTIONS = 200603,

     [Description("MK-23 Radar Operator Functions")]
     MK_23_RADAR_OPERATOR_FUNCTIONS = 200604,

     [Description("SPS-48 Radar Operator Functions")]
     SPS_48_RADAR_OPERATOR_FUNCTIONS = 200605,

     [Description("SPS-40 Radar Operator Functions")]
     SPS_40_RADAR_OPERATOR_FUNCTIONS = 200606,

     [Description("MK-95 Radar Operator Functions")]
     MK_95_RADAR_OPERATOR_FUNCTIONS = 200607,

     [Description("Kill/No Kill")]
     KILL_NO_KILL = 200608,

     [Description("CMT pc")]
     CMT_PC = 200609,

     [Description("CMC4AirGlobalData")]
     CMC4AIRGLOBALDATA = 200610,

     [Description("CMC4GlobalData")]
     CMC4GLOBALDATA = 200611,

     [Description("LINKSIM_COMMENT_PDU")]
     LINKSIM_COMMENT_PDU = 200612,

     [Description("NSST Ownship Control")]
     NSST_OWNSHIP_CONTROL = 200613,

     [Description("Other")]
     OTHER = 240000,

     [Description("Mass Of The Vehicle")]
     MASS_OF_THE_VEHICLE = 240001,

     [Description("Force ID")]
     FORCE_ID_53 = 240002,

     [Description("Entity Type Kind")]
     ENTITY_TYPE_KIND = 240003,

     [Description("Entity Type Domain")]
     ENTITY_TYPE_DOMAIN = 240004,

     [Description("Entity Type Country")]
     ENTITY_TYPE_COUNTRY = 240005,

     [Description("Entity Type Category")]
     ENTITY_TYPE_CATEGORY = 240006,

     [Description("Entity Type Sub Category")]
     ENTITY_TYPE_SUB_CATEGORY = 240007,

     [Description("Entity Type Specific")]
     ENTITY_TYPE_SPECIFIC = 240008,

     [Description("Entity Type Extra")]
     ENTITY_TYPE_EXTRA = 240009,

     [Description("Alternative Entity Type Kind")]
     ALTERNATIVE_ENTITY_TYPE_KIND = 240010,

     [Description("Alternative Entity Type Domain")]
     ALTERNATIVE_ENTITY_TYPE_DOMAIN = 240011,

     [Description("Alternative Entity Type Country")]
     ALTERNATIVE_ENTITY_TYPE_COUNTRY = 240012,

     [Description("Alternative Entity Type Category")]
     ALTERNATIVE_ENTITY_TYPE_CATEGORY = 240013,

     [Description("Alternative Entity Type Sub Category")]
     ALTERNATIVE_ENTITY_TYPE_SUB_CATEGORY = 240014,

     [Description("Alternative Entity Type Specific")]
     ALTERNATIVE_ENTITY_TYPE_SPECIFIC = 240015,

     [Description("Alternative Entity Type Extra")]
     ALTERNATIVE_ENTITY_TYPE_EXTRA = 240016,

     [Description("Entity Location X")]
     ENTITY_LOCATION_X = 240017,

     [Description("Entity Location Y")]
     ENTITY_LOCATION_Y = 240018,

     [Description("Entity Location Z")]
     ENTITY_LOCATION_Z = 240019,

     [Description("Entity Linear Velocity X")]
     ENTITY_LINEAR_VELOCITY_X = 240020,

     [Description("Entity Linear Velocity Y")]
     ENTITY_LINEAR_VELOCITY_Y = 240021,

     [Description("Entity Linear Velocity Z")]
     ENTITY_LINEAR_VELOCITY_Z = 240022,

     [Description("Entity Orientation Psi")]
     ENTITY_ORIENTATION_PSI = 240023,

     [Description("Entity Orientation Theta")]
     ENTITY_ORIENTATION_THETA = 240024,

     [Description("Entity Orientation Phi")]
     ENTITY_ORIENTATION_PHI = 240025,

     [Description("Dead Reckoning Algorithm")]
     DEAD_RECKONING_ALGORITHM = 240026,

     [Description("Dead Reckoning Linear Acceleration X")]
     DEAD_RECKONING_LINEAR_ACCELERATION_X = 240027,

     [Description("Dead Reckoning Linear Acceleration Y")]
     DEAD_RECKONING_LINEAR_ACCELERATION_Y = 240028,

     [Description("Dead Reckoning Linear Acceleration Z")]
     DEAD_RECKONING_LINEAR_ACCELERATION_Z = 240029,

     [Description("Dead Reckoning Angular Velocity X")]
     DEAD_RECKONING_ANGULAR_VELOCITY_X = 240030,

     [Description("Dead Reckoning Angular Velocity Y")]
     DEAD_RECKONING_ANGULAR_VELOCITY_Y = 240031,

     [Description("Dead Reckoning Angular Velocity Z")]
     DEAD_RECKONING_ANGULAR_VELOCITY_Z = 240032,

     [Description("Entity Appearance")]
     ENTITY_APPEARANCE = 240033,

     [Description("Entity Marking Character Set")]
     ENTITY_MARKING_CHARACTER_SET = 240034,

     [Description("Entity Marking 11 Bytes")]
     ENTITY_MARKING_11_BYTES = 240035,

     [Description("Capability")]
     CAPABILITY = 240036,

     [Description("Number Articulation Parameters")]
     NUMBER_ARTICULATION_PARAMETERS = 240037,

     [Description("Articulation Parameter ID")]
     ARTICULATION_PARAMETER_ID = 240038,

     [Description("Articulation Parameter Type")]
     ARTICULATION_PARAMETER_TYPE_54 = 240039,

     [Description("Articulation Parameter Value")]
     ARTICULATION_PARAMETER_VALUE_55 = 240040,

     [Description("Type Of Stores")]
     TYPE_OF_STORES = 240041,

     [Description("Quantity Of Stores")]
     QUANTITY_OF_STORES = 240042,

     [Description("Fuel Quantity")]
     FUEL_QUANTITY = 240043,

     [Description("Radar System Status")]
     RADAR_SYSTEM_STATUS = 240044,

     [Description("Radio Communication System Status")]
     RADIO_COMMUNICATION_SYSTEM_STATUS = 240045,

     [Description("Default Time For Radio Transmission For Stationary Transmitters")]
     DEFAULT_TIME_FOR_RADIO_TRANSMISSION_FOR_STATIONARY_TRANSMITTERS = 240046,

     [Description("Default Time For Radio Transmission For Moving Transmitters")]
     DEFAULT_TIME_FOR_RADIO_TRANSMISSION_FOR_MOVING_TRANSMITTERS = 240047,

     [Description("Body Part Damaged Ratio")]
     BODY_PART_DAMAGED_RATIO = 240048,

     [Description("Name Of The Terrain Database File")]
     NAME_OF_THE_TERRAIN_DATABASE_FILE = 240049,

     [Description("Name Of Local File")]
     NAME_OF_LOCAL_FILE = 240050,

     [Description("Aimpoint Bearing")]
     AIMPOINT_BEARING = 240051,

     [Description("Aimpoint Elevation")]
     AIMPOINT_ELEVATION = 240052,

     [Description("Aimpoint Range")]
     AIMPOINT_RANGE = 240053,

     [Description("Air Speed")]
     AIR_SPEED = 240054,

     [Description("Altitude")]
     ALTITUDE_56 = 240055,

     [Description("Application Status")]
     APPLICATION_STATUS = 240056,

     [Description("Auto Iff")]
     AUTO_IFF = 240057,

     [Description("Beacon Delay")]
     BEACON_DELAY = 240058,

     [Description("Bingo Fuel Setting")]
     BINGO_FUEL_SETTING = 240059,

     [Description("Cloud Bottom")]
     CLOUD_BOTTOM = 240060,

     [Description("Cloud Top")]
     CLOUD_TOP = 240061,

     [Description("Direction")]
     DIRECTION = 240062,

     [Description("End Action")]
     END_ACTION = 240063,

     [Description("Frequency")]
     FREQUENCY = 240064,

     [Description("Freeze")]
     FREEZE = 240065,

     [Description("Heading")]
     HEADING = 240066,

     [Description("Identification")]
     IDENTIFICATION_57 = 240067,

     [Description("Initial Point Data")]
     INITIAL_POINT_DATA = 240068,

     [Description("Latitude")]
     LATITUDE_58 = 240069,

     [Description("Lights")]
     LIGHTS_59 = 240070,

     [Description("Linear")]
     LINEAR = 240071,

     [Description("Longitude")]
     LONGITUDE_60 = 240072,

     [Description("Low Altitude")]
     LOW_ALTITUDE = 240073,

     [Description("Mfd Formats")]
     MFD_FORMATS = 240074,

     [Description("Nctr")]
     NCTR = 240075,

     [Description("Number Projectiles")]
     NUMBER_PROJECTILES = 240076,

     [Description("Operation Code")]
     OPERATION_CODE = 240077,

     [Description("Pitch")]
     PITCH = 240078,

     [Description("Profiles")]
     PROFILES = 240079,

     [Description("Quantity")]
     QUANTITY_61 = 240080,

     [Description("Radar Modes")]
     RADAR_MODES = 240081,

     [Description("Radar Search Volume")]
     RADAR_SEARCH_VOLUME = 240082,

     [Description("Roll")]
     ROLL = 240083,

     [Description("Rotation")]
     ROTATION_62 = 240084,

     [Description("Scale Factor X")]
     SCALE_FACTOR_X = 240085,

     [Description("Scale Factor Y")]
     SCALE_FACTOR_Y = 240086,

     [Description("Shields")]
     SHIELDS = 240087,

     [Description("Steerpoint")]
     STEERPOINT = 240088,

     [Description("Spare1")]
     SPARE1 = 240089,

     [Description("Spare2")]
     SPARE2 = 240090,

     [Description("Team")]
     TEAM = 240091,

     [Description("Text")]
     TEXT = 240092,

     [Description("Time Of Day")]
     TIME_OF_DAY = 240093,

     [Description("Trail Flag")]
     TRAIL_FLAG = 240094,

     [Description("Trail Size")]
     TRAIL_SIZE = 240095,

     [Description("Type Of Projectile")]
     TYPE_OF_PROJECTILE = 240096,

     [Description("Type Of Target")]
     TYPE_OF_TARGET = 240097,

     [Description("Type Of Threat")]
     TYPE_OF_THREAT = 240098,

     [Description("Uhf Frequency")]
     UHF_FREQUENCY = 240099,

     [Description("Utm Altitude")]
     UTM_ALTITUDE = 240100,

     [Description("Utm Latitude")]
     UTM_LATITUDE = 240101,

     [Description("Utm Longitude")]
     UTM_LONGITUDE = 240102,

     [Description("Vhf Frequency")]
     VHF_FREQUENCY = 240103,

     [Description("Visibility Range")]
     VISIBILITY_RANGE = 240104,

     [Description("Void Aaa Hit")]
     VOID_AAA_HIT = 240105,

     [Description("Void Collision")]
     VOID_COLLISION = 240106,

     [Description("Void Earth Hit")]
     VOID_EARTH_HIT = 240107,

     [Description("Void Friendly")]
     VOID_FRIENDLY = 240108,

     [Description("Void Gun Hit")]
     VOID_GUN_HIT = 240109,

     [Description("Void Rocket Hit")]
     VOID_ROCKET_HIT = 240110,

     [Description("Void Sam Hit")]
     VOID_SAM_HIT = 240111,

     [Description("Weapon Data")]
     WEAPON_DATA = 240112,

     [Description("Weapon Type")]
     WEAPON_TYPE = 240113,

     [Description("Weather")]
     WEATHER_63 = 240114,

     [Description("Wind Direction")]
     WIND_DIRECTION_64 = 240115,

     [Description("Wind Speed")]
     WIND_SPEED = 240116,

     [Description("Wing Station")]
     WING_STATION = 240117,

     [Description("Yaw")]
     YAW = 240118,

     [Description("Memory Offset")]
     MEMORY_OFFSET = 240119,

     [Description("Memory Data")]
     MEMORY_DATA = 240120,

     [Description("VASI")]
     VASI = 240121,

     [Description("Beacon")]
     BEACON = 240122,

     [Description("Strobe")]
     STROBE = 240123,

     [Description("Culture")]
     CULTURE = 240124,

     [Description("Approach")]
     APPROACH = 240125,

     [Description("Runway End")]
     RUNWAY_END = 240126,

     [Description("Obstruction")]
     OBSTRUCTION = 240127,

     [Description("Runway Edge")]
     RUNWAY_EDGE = 240128,

     [Description("Ramp Taxiway")]
     RAMP_TAXIWAY = 240129,

     [Description("Laser Bomb Code")]
     LASER_BOMB_CODE = 240130,

     [Description("Rack Type")]
     RACK_TYPE = 240131,

     [Description("HUD")]
     HUD = 240132,

     [Description("RoleFileName")]
     ROLEFILENAME = 240133,

     [Description("PilotName")]
     PILOTNAME = 240134,

     [Description("PilotDesignation")]
     PILOTDESIGNATION = 240135,

     [Description("Model Type")]
     MODEL_TYPE = 240136,

     [Description("DIS Type")]
     DIS_TYPE = 240137,

     [Description("Class")]
     CLASS = 240138,

     [Description("Channel")]
     CHANNEL = 240139,

     [Description("Entity Type")]
     ENTITY_TYPE_65 = 240140,

     [Description("Alternative Entity Type")]
     ALTERNATIVE_ENTITY_TYPE_66 = 240141,

     [Description("Entity Location")]
     ENTITY_LOCATION = 240142,

     [Description("Entity Linear Velocity")]
     ENTITY_LINEAR_VELOCITY = 240143,

     [Description("Entity Orientation")]
     ENTITY_ORIENTATION = 240144,

     [Description("Dead Reckoning")]
     DEAD_RECKONING = 240145,

     [Description("Failure Symptom")]
     FAILURE_SYMPTOM = 240146,

     [Description("Max Fuel")]
     MAX_FUEL = 240147,

     [Description("Refueling Boom Connect")]
     REFUELING_BOOM_CONNECT = 240148,

     [Description("Altitude AGL")]
     ALTITUDE_AGL = 240149,

     [Description("Calibrated Airspeed")]
     CALIBRATED_AIRSPEED = 240150,

     [Description("TACAN Channel")]
     TACAN_CHANNEL = 240151,

     [Description("TACAN Band")]
     TACAN_BAND = 240152,

     [Description("TACAN Mode")]
     TACAN_MODE = 240153
     }

    } //End Parial Class

} //End Namespace
