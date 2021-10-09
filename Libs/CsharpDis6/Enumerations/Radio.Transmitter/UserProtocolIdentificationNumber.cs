// Copyright 2008-2011. This work is licensed under the BSD license, available at
// http://www.movesinstitute.org/licenses
//
// Orignal authors: DMcG, Jason Nelson
// Modified for use with C#:
// - Peter Smith (Naval Air Warfare Center - Training Systems Division)
// - Zvonko Bostjancic (Blubit d.o.o. - zvonko.bostjancic@blubit.si)

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace OpenDis.Enumerations.Radio.Transmitter
{
    /// <summary>
    /// Enumeration values for UserProtocolIdentificationNumber (radio.tx.protocolid, User Protocol Identification Number, 
    /// section 9.1.10)
    /// The enumeration values are generated from the SISO DIS XML EBV document (R35), which was
    /// obtained from http://discussions.sisostds.org/default.asp?action=10&amp;fd=31
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
    [Serializable]
    public enum UserProtocolIdentificationNumber : uint
    {
        /// <summary>
        /// CCSIL.  poc: Marnie Salisbury.  email: MARNIE@MITRE.ORG.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("CCSIL.  poc: Marnie Salisbury.  email: MARNIE@MITRE.ORG.")]
        CCSIL = 1,

        /// <summary>
        /// A2ATD SINCGARS ERF.  type: Binary data.  poc: Chuck Woodman.  email: WOODMAN@ORLANDO.LORAL.COM.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("A2ATD SINCGARS ERF.  type: Binary data.  poc: Chuck Woodman.  email: WOODMAN@ORLANDO.LORAL.COM.")]
        A2ATDSINCGARSERF = 5,

        /// <summary>
        /// A2ATD CAC2.  type: Binary Report/Overlay data.  poc: Wayne Beard.  email: WBEARD@ORLANDO.LORAL.COM.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("A2ATD CAC2.  type: Binary Report/Overlay data.  poc: Wayne Beard.  email: WBEARD@ORLANDO.LORAL.COM.")]
        A2ATDCAC2 = 6,

        /// <summary>
        /// Battle Command.  type: Abbreviated Command and Control.  poc: Gary Gagnon.  email: ggagnon@cas-inc.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Battle Command.  type: Abbreviated Command and Control.  poc: Gary Gagnon.  email: ggagnon@cas-inc.com.")]
        BattleCommand = 20,

        /// <summary>
        /// AFIWC IADS Track Report.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("AFIWC IADS Track Report.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.")]
        AFIWCIADSTrackReport = 30,

        /// <summary>
        /// AFIWC IADS Comm C2 Message.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("AFIWC IADS Comm C2 Message.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.")]
        AFIWCIADSCommC2Message = 31,

        /// <summary>
        /// AFIWC IADS Ground Control Interceptor (GCI) Command.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("AFIWC IADS Ground Control Interceptor (GCI) Command.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.")]
        AFIWCIADSGroundControlInterceptorGCICommand = 32,

        /// <summary>
        /// AFIWC Voice Text Message.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("AFIWC Voice Text Message.  type: Binary Data.  poc: Randy Schuetz.  email: randy.schuetz@lackland.af.mil.")]
        AFIWCVoiceTextMessage = 35,

        /// <summary>
        /// ModSAF Text Radio.  type: Free Format ASCII Text.  poc: Richard Schaffer.  email: RSCHAFFER@CAMB-LADS.LORAL.COM.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("ModSAF Text Radio.  type: Free Format ASCII Text.  poc: Richard Schaffer.  email: RSCHAFFER@CAMB-LADS.LORAL.COM.")]
        ModSAFTextRadio = 177,

        /// <summary>
        /// CCTT SINCGARS ERF-LOCKOUT.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("CCTT SINCGARS ERF-LOCKOUT.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.")]
        CCTTSINCGARSERFLOCKOUT = 200,

        /// <summary>
        /// CCTT SINCGARS ERF-HOPSET.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("CCTT SINCGARS ERF-HOPSET.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.")]
        CCTTSINCGARSERFHOPSET = 201,

        /// <summary>
        /// CCTT SINCGARS OTAR.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("CCTT SINCGARS OTAR.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.")]
        CCTTSINCGARSOTAR = 202,

        /// <summary>
        /// CCTT SINCGARS DATA.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("CCTT SINCGARS DATA.  type: Binary Data.  poc: Jim Keenan.  email: jimk@greatwall.cctt.com.")]
        CCTTSINCGARSDATA = 203,

        /// <summary>
        /// ModSAF FWA Forward Air Controller.  type: Binary data.  poc: Dan Coffin.  email: dcoffin@camb-lads.loral.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("ModSAF FWA Forward Air Controller.  type: Binary data.  poc: Dan Coffin.  email: dcoffin@camb-lads.loral.com.")]
        ModSAFFWAForwardAirController = 546,

        /// <summary>
        /// ModSAF Threat ADA C3.  type: Binary data.  poc: Dan Coffin.  email: dcoffin@camb-lads.loral.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("ModSAF Threat ADA C3.  type: Binary data.  poc: Dan Coffin.  email: dcoffin@camb-lads.loral.com.")]
        ModSAFThreatADAC3 = 832,

        /// <summary>
        /// F-16 MTC AFAPD Protocol.  type: Packed Binary AFAPD Message Format for F-16 Block 50/52.  poc: Albert Ludwig.  org: The Boeing Company.  email: albert.j.ludwig@boeing.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("F-16 MTC AFAPD Protocol.  type: Packed Binary AFAPD Message Format for F-16 Block 50/52.  poc: Albert Ludwig.  org: The Boeing Company.  email: albert.j.ludwig@boeing.com.")]
        F16MTCAFAPDProtocol = 1000,

        /// <summary>
        /// F-16 MTC IDL Protocol.  type: Packed Binary IDL Message Format for F-16 Block 50/52.  poc: Albert Ludwig.  org: The Boeing Company.  email: albert.j.ludwig@boeing.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("F-16 MTC IDL Protocol.  type: Packed Binary IDL Message Format for F-16 Block 50/52.  poc: Albert Ludwig.  org: The Boeing Company.  email: albert.j.ludwig@boeing.com.")]
        F16MTCIDLProtocol = 1100,

        /// <summary>
        /// ModSAF Artillery Fire Control.  type: Structured text followed by binary data.  poc: Richard Schaffer.  email: RSCHAFFER@CAMB-LADS.LORAL.COM.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("ModSAF Artillery Fire Control.  type: Structured text followed by binary data.  poc: Richard Schaffer.  email: RSCHAFFER@CAMB-LADS.LORAL.COM.")]
        ModSAFArtilleryFireControl = 4570,

        /// <summary>
        /// AGTS.  type: Binary Report/ Overlay data.  poc: Steve Gendreau.  email: GENDREAU@ESCMAIL.ORL.MMC.COM.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("AGTS.  type: Binary Report/ Overlay data.  poc: Steve Gendreau.  email: GENDREAU@ESCMAIL.ORL.MMC.COM.")]
        AGTS = 5361,

        /// <summary>
        /// GC3.  type: Binary data.  poc: Karl Shepherd.  email: karl.shepherd@gsc.gte.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("GC3.  type: Binary data.  poc: Karl Shepherd.  email: karl.shepherd@gsc.gte.com.")]
        GC3 = 6000,

        /// <summary>
        /// WNCP data.  type: Binary data.  poc: Karl Shepherd.  email: karl.shepherd@gsc.gte.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("WNCP data.  type: Binary data.  poc: Karl Shepherd.  email: karl.shepherd@gsc.gte.com.")]
        WNCPData = 6010,

        /// <summary>
        /// Spoken text message.  type: Data about speaker followed by free ASCII text.  poc: Brett Kaylor.  org: GTE Government Systems.  email: brett.kaylor@gsc.gte.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Spoken text message.  type: Data about speaker followed by free ASCII text.  poc: Brett Kaylor.  org: GTE Government Systems.  email: brett.kaylor@gsc.gte.com.")]
        SpokenTextMessage = 6020,

        /// <summary>
        /// Longbow IDM message.  type: Simulated IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Longbow IDM message.  type: Simulated IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.")]
        LongbowIDMMessage = 6661,

        /// <summary>
        /// Comanche IDM message.  type: Simulated IDM message for Comanche Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Comanche IDM message.  type: Simulated IDM message for Comanche Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.")]
        ComancheIDMMessage = 6662,

        /// <summary>
        /// Longbow Airborne TACFIRE Message.  type: Simulated TACFIRE IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Longbow Airborne TACFIRE Message.  type: Simulated TACFIRE IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.")]
        LongbowAirborneTACFIREMessage = 6663,

        /// <summary>
        /// Longbow Ground TACFIRE Message.  type: Simulated TACFIRE IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Longbow Ground TACFIRE Message.  type: Simulated TACFIRE IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.")]
        LongbowGroundTACFIREMessage = 6664,

        /// <summary>
        /// Longbow AFAPD Message.  type: Simulated AFAPD IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Longbow AFAPD Message.  type: Simulated AFAPD IDM message for Longbow Apache Aircraft.  poc: Peter Obear.  org: Carmel Applied Technologies, Inc.  email: obear@catinet.com.")]
        LongbowAFAPDMessage = 6665,

        /// <summary>
        /// Longbow ERF message.  type: Simulated ERF message for Longbow Apache Aircraft.  poc: Jeffery Day.  org: Boeing - St. Louis.  email: Jeffrey.Day@MW.Boeing.com.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", Justification = "Due to SISO standardized naming.")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Due to SISO standardized naming.")]
        [Description("Longbow ERF message.  type: Simulated ERF message for Longbow Apache Aircraft.  poc: Jeffery Day.  org: Boeing - St. Louis.  email: Jeffrey.Day@MW.Boeing.com.")]
        LongbowERFMessage = 6666
    }
}
