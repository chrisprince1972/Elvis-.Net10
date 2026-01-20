/*
 * WARNING.
 * 
 * This file is duplicated in the Watch and Player projects. Make sure
 * you copy one to the other. I know, I could use a linked file, but
 * Microsoft Visual Source Paper Bag doesn't know how to handle them.
 * 
 * History :-
 * 
 * Date         Ref      Who  Description
 * -----------  -------  ---  ------------------------------------------------
 * 12-MAY-2016  PPS3925  DW   Add DartRelease, CumulativeAlarm, PredictedROT.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class TWVVersionException : Exception
{
    public float Version;

    public TWVVersionException(float v)
    {
        Version = v;
    }
}

public class TWV
{
    public const int MAXANAL = 10;
    public const int MAXADDS = 10;

    public const int MaxErrorText = 40;
    public const int MaxSsUnit = 10;
    public const int MaxComments = 80;
    public const int MaxLbl = 16;
    public const int MaxMaterial = 7;
    public const int MaxFlightPath = 500;
    public const int CbmMessageLineLength = 64;
    public const int CbmCommitOperatorLength = 29;

    public const float VersionBase      = 0.04f;
    public const float VersionWithCBM   = 0.05f;
    public const float VersionNewCamera = 0.06f;
    public const float RequiredVersion  = VersionNewCamera;

    public struct EBM
    {
        public int ProgramNumber;
        public int OxygenCbModel;
        public int OxygenAtInBlow;
        public int OxygenEbModel;
        public int OxygenAtPostBlow;
        public int OxygenVolumeToCharge;
        public float OreCbModel;
        public float OreAtInBlow;
        public float OreEbModel;
        public float OreAtPostBlow;
        public int AimTemperature;
        public int InBlowTemperature;
        public short InBlowTemperatureQc;
        public float AimCarbon;
        public float InBlowCarbon;
        public short InBlowCarbonQc;
        public int Pb1Temperature;
        public short Pb1TemperatureQc;
        public int Pb1OxyActivity;
        public short Pb1OxyActivityQc;
        public float Pb1CalculatedCarbon;
        public float Pb1ImmersionDepth;
        public short Pb1ImmersionDepthQc;
        public float Pb1BathHeight;
        public int Pb2Temperature;
        public short Pb2TemperatureQc;
        public int Pb2OxyActivity;
        public short Pb2OxyActivityQc;
        public float Pb2CalculatedCarbon;
        public float Pb2ImmersionDepth;
        public short Pb2ImmersionDepthQc;
        public float Pb2BathHeight;
        public int OreAlarm;
        public int LimeAlarm;
        public int ScrapAlarm;
        public int PhosphorousAlarm;
        public int TsoRequired;
        public int EstOxyActivity;
        public float EstPbCarbon;
        public int SlspOxyActivity;
        public short SlspOxyActivityQc;
        public float SlspDolofluxWt;
        public int ReblowOxygen;
        public float CoolbackOre;
        public int DeltaTemperature;
        public int ReblowRequired;
        public int LadleAimTemperature;
        public float LadleAimCarbon;
        public int LadleActualTemperature;
        public float LadleActualCarbon;
        public float HmCarbon;
        public float HmSilicon;
        public float HmSulphur;
        public float HmPhosphorous;
        public float HmManganese;
        public float HmNitrogen;
        public float IbCarbon;
        public float IbSilicon;
        public float IbSulphur;
        public float IbPhosphorous;
        public float IbManganese;
        public float IbNitrogen;
        public float Pb1Carbon;
        public float Pb1Silicon;
        public float Pb1Sulphur;
        public float Pb1Phosphorous;
        public float Pb1Manganese;
        public float Pb1Nitrogen;
        public float QtCarbon;
        public float QtSilicon;
        public float QtSulphur;
        public float QtPhosphorous;
        public float QtManganese;
        public float QtNitrogen;
        public float TundishCarbon;
        public float TundishSilicon;
        public float TundishSulphur;
        public float TundishPhosphorous;
        public float TundishManganese;
        public float TundishNitrogen;
        public int RunoutTimeMins;
        public int RunoutTimeSecs;
        public string ErrorText;
        public int DolofluxAlarm;
        public int HighAluminaHeatNumber;
    }

    public struct CBM
    {
        public DateTime CbmRunTimeStamp;
        public int CbmResultStatus;
        public int HeatStatus;
        public float RequiredRecycledSteelWeight;
        public float CbmPredictedTapWeight;
        public float CbmPredictedSlagWeight;
        public short CbmPredictedEndBlowTemp;
        public DateTime CbmCommitTimeStamp;
        public string CbmCommitOperator;
        public short HmLadleNumber;
        public float CalculatedHmLadleCarbon;
        public float CalculatedHmLadleSilicon;
        public float CalculatedHmLadleManganese;
        public float CalculatedHmLadlePhosphorus;
        public float CalculatedHmLadleSulphur;
        public float CalculatedHmLadleNitrogen;
        public float CalculatedHmLadleTemperature;
        public float PredictedTapCarbon;
        public float PredictedTapManganese;
        public float PredictedTapPhosphorus;
        public float PredictedTapSulphur;
        public float PredictedTapNitrogen;
        public float PredictedSlagFe;
        public float PredictedSlagCaO;
        public float PredictedSlagSiO2;
        public float PredictedSlagAl2O3;
        public float PredictedSlagMgO;
        public float PredictedSlagP2O5;
        public float PredictedSlagS;
        public float PredictedSlagMnO;
        public float PredictedSlagFeO;
        public float PredictedSlagTiO2;
        public string CbmMessageLine1;
        public string CbmMessageLine2;
        public string CbmMessageLine3;
        public short DesulphRequirementFlag;
        public short SkimmingPracticeCode;
        public float CalculatedHmTempAtCharge;
        public short Converter;
        public short RunMode;
        public float IbDipTriggerOxygen;
    }

    public struct CoordLink
    {
        public short Grade1;
        public short Grade2;
        public short SteelLadleNumber;
        public string SsUnit;
        public short CasterNumber;
        public DateTime PlannedPourTime;
        public DateTime PlannedEndDesulphTime;
        public DateTime PlannedChargeTime;
        public DateTime PlannedTapTime;
        public DateTime ActualTapTime;
        public DateTime PlannedEndSsTime;
        public short PlannedDwellTime;
        public DateTime PlannedStartCastTime;
        public DateTime PlannedEndCastTime;
        public short CombinedWidth;
        public short CastDuration;
        public float CastingRate;
        public float CastingSpeed;
        public string Comments;
        public DateTime UpdateTime;
        public float ReleaseTemperature;
        public float AimLadleTemperature;
    }

    public struct Analysis
    {
        public string Lbl;
        public float C;
        public float Si;
        public float S;
        public float P;
        public float Mn;
        public float Ni;
        public float Cu;
        public float Sn;
        public float Cr;
        public float Ars;
        public float Mo;
        public float N2;
        public float AlT;
        public float AlS;
        public float Ti;
        public float B;
        public float Ca;
        public float Ce;
        public float Co;
        public float Nb;
        public float V;
        public float CalcAlN2;
        public float CalcBN2;
    }

    public struct Additions
    {
        public string Material;
        public float Standard;
        public float Model;
    }

    public struct FileHeader
    {
        public float    Version;         // Version number
        public int      VesselNumber;    // Vessel 1 or 2
        public int      HeatNumber;      // Heat number
        public DateTime StartTap;        // Start timestamp
        public DateTime EndTap;          // End timestamp
        public int      FrameCount;      // Number of frames
        public byte     L1;              // Background to steel boundary
        public byte     L2;              // Steel to slag boundary
        public byte     Red;             // Alarm threshold
        public byte     Orange;          // Warning threshold
        public int      Left;            // Left margin of SDS area
        public int      Top;             // Top margin
        public int      Right;           // Right margin
        public int      Bottom;          // Bottom margin
        public float    SlagCarry;       // Percent slag carried over
        public string   FlightPath;      // Flight path definition
        public int      UpOn;            // 0=Metal, 2=Slag, -1=Undefined
        public int      HeatNumberSet;   // Previously Spare1
        public float    DartRelease;     // Nonzero minutes since start tap
        public float    CumulativeAlarm; // Nonzero minutes since start tap
        public float    PredictedROT;    // Nonzero minutes
        public int      Spare5;          // Spare
        public bool     Done;            // False when recording, true when all done

        public EBM Ebm;
        public CBM Cbm;
        public CoordLink Coord;
        public Analysis[] Anals;
        public Additions[] Adds;

        public int Length;
    }

    public struct PixelFrame
    {
        public DateTime Timestamp;     // Subsecond timestamp of sample    -- keep these three fields together
        public float    Angle;         // Tilter angle                     -- because ReadFrameTimestamp()
        public float    Speed;         // Tilter speed                     -- and WritePIData() work together
        public int      SteelPixels;   // Number of pixels above L1 threshold but below L2
        public int      SlagPixels;    // Number of pixels above L2 threshold
        public bool     Alarm;         // True if SDS is alarming
        public byte[]   Pixels;        // Pixel array

        public int Length;
    }

    public FileHeader Header;
    public PixelFrame Frame;

    // NOTE These need to match the consts in LandSystem
    public static int YPIX = 144; // number of lines
    public static int XPIX = 192; // number of pixels per line

    public string FileName;

    public double TotalSeconds;  // Duration of tap

    public FileStream stream;

    public TWV(string fnam)
    {
        this.FileName = fnam;
    }

    public TWV()
    {
        this.Header.Version               = RequiredVersion;
        this.Header.VesselNumber          = -1;
        this.Header.HeatNumber            = -1;
        this.Header.StartTap              = DateTime.MinValue;
        this.Header.EndTap                = DateTime.MinValue;
        this.Header.FrameCount            = 0;
        this.Header.SlagCarry             = 0;
        this.Header.FlightPath            = "";
        this.Header.UpOn                  = -1;
        this.Header.Done                  = false;
        this.Header.Ebm                   = new EBM();
        this.Header.Cbm                   = new CBM();
        this.Header.Coord                 = new CoordLink();
        this.Header.Anals                 = new Analysis[MAXANAL];
        this.Header.Adds                  = new Additions[MAXADDS];
        this.Header.Ebm.ErrorText         = "";
        this.Header.Cbm.CbmCommitOperator = "";
        this.Header.Cbm.CbmMessageLine1   = "";
        this.Header.Cbm.CbmMessageLine2   = "";
        this.Header.Cbm.CbmMessageLine3   = "";
        this.Header.Coord.SsUnit          = "";
        this.Header.Coord.Comments        = "";
        for (int i=0; i<MAXANAL; i++) this.Header.Anals[i].Lbl = "";
        for (int i=0; i<MAXADDS; i++) this.Header.Adds[i].Material = "";

        this.Frame.Timestamp   = this.Header.StartTap;
        this.Frame.Angle       = -1;
        this.Frame.Speed       = -1;
        this.Frame.SteelPixels = -1;
        this.Frame.SlagPixels  = -1;
        this.Frame.Alarm       = false;
        this.Frame.Pixels      = new byte[TWV.XPIX*TWV.YPIX];

        this.Frame.Length = sizeof(long) +            // Timestamp
                            sizeof(float) +           // Angle
                            sizeof(float) +           // Speed
                            sizeof(int) +             // SteelPixels
                            sizeof(int) +             // SlagPixels
                            sizeof(bool) +            // Alarm
                            this.Frame.Pixels.Length; // Pixels

        HeaderLengthWithCBM();
    }

    public void HeaderLengthBase()
    {
        this.Header.Length = sizeof(float) + // Version
                             sizeof(int) +   // VesselNumber
                             sizeof(int) +   // HeatNumber
                             sizeof(long) +  // StartTap
                             sizeof(long) +  // EndTap
                             sizeof(int) +   // FrameCount
                             sizeof(byte) +  // L1
                             sizeof(byte) +  // L2
                             sizeof(byte) +  // Red
                             sizeof(byte) +  // Orange
                             sizeof(int) +   // Left
                             sizeof(int) +   // Top
                             sizeof(int) +   // Right
                             sizeof(int) +   // Bottom
                             sizeof(float) + // SlagCarry
                             MaxFlightPath + // FlightPath
                             sizeof(int) +   // UpOn
                             sizeof(int) +   // HeatNumberSet
                             sizeof(float) + // DartRelease
                             sizeof(float) + // CumulativeAlarm
                             sizeof(float) + // PredictedROT
                             sizeof(int) +   // Spare5
                             sizeof(bool);   // Done

        // EBM
        this.Header.Length += sizeof(int) +   // ProgramNumber
                              sizeof(int) +   // OxygenCbModel
                              sizeof(int) +   // OxygenAtInBlow
                              sizeof(int) +   // OxygenEbModel
                              sizeof(int) +   // OxygenAtPostBlow
                              sizeof(int) +   // OxygenVolumeToCharge
                              sizeof(float) + // OreCbModel
                              sizeof(float) + // OreAtInBlow
                              sizeof(float) + // OreEbModel
                              sizeof(float) + // OreAtPostBlow
                              sizeof(int) +   // AimTemperature
                              sizeof(int) +   // InBlowTemperature
                              sizeof(short) + // InBlowTemperatureQc
                              sizeof(float) + // AimCarbon
                              sizeof(float) + // InBlowCarbon
                              sizeof(short) + // InBlowCarbonQc
                              sizeof(int) +   // Pb1Temperature
                              sizeof(short) + // Pb1TemperatureQc
                              sizeof(int) +   // Pb1OxyActivity
                              sizeof(short) + // Pb1OxyActivityQc
                              sizeof(float) + // Pb1CalculatedCarbon
                              sizeof(float) + // Pb1ImmersionDepth
                              sizeof(short) + // Pb1ImmersionDepthQc
                              sizeof(float) + // Pb1BathHeight
                              sizeof(int) +   // Pb2Temperature
                              sizeof(short) + // Pb2TemperatureQc
                              sizeof(int) +   // Pb2OxyActivity
                              sizeof(short) + // Pb2OxyActivityQc
                              sizeof(float) + // Pb2CalculatedCarbon
                              sizeof(float) + // Pb2ImmersionDepth
                              sizeof(short) + // Pb2ImmersionDepthQc
                              sizeof(float) + // Pb2BathHeight
                              sizeof(int) +   // OreAlarm
                              sizeof(int) +   // LimeAlarm
                              sizeof(int) +   // ScrapAlarm
                              sizeof(int) +   // PhosphorousAlarm
                              sizeof(int) +   // TsoRequired
                              sizeof(int) +   // EstOxyActivity
                              sizeof(float) + // EstPbCarbon
                              sizeof(int) +   // SlspOxyActivity
                              sizeof(short) + // SlspOxyActivityQc
                              sizeof(float) + // SlspDolofluxWt
                              sizeof(int) +   // ReblowOxygen
                              sizeof(float) + // CoolbackOre
                              sizeof(int) +   // DeltaTemperature
                              sizeof(int) +   // ReblowRequired
                              sizeof(int) +   // LadleAimTemperature
                              sizeof(float) + // LadleAimCarbon
                              sizeof(int) +   // LadleActualTemperature
                              sizeof(float) + // LadleActualCarbon
                              sizeof(float) + // HmCarbon
                              sizeof(float) + // HmSilicon
                              sizeof(float) + // HmSulphur
                              sizeof(float) + // HmPhosphorous
                              sizeof(float) + // HmManganese
                              sizeof(float) + // HmNitrogen
                              sizeof(float) + // IbCarbon
                              sizeof(float) + // IbSilicon
                              sizeof(float) + // IbSulphur
                              sizeof(float) + // IbPhosphorous
                              sizeof(float) + // IbManganese
                              sizeof(float) + // IbNitrogen
                              sizeof(float) + // Pb1Carbon
                              sizeof(float) + // Pb1Silicon
                              sizeof(float) + // Pb1Sulphur
                              sizeof(float) + // Pb1Phosphorous
                              sizeof(float) + // Pb1Manganese
                              sizeof(float) + // Pb1Nitrogen
                              sizeof(float) + // QtCarbon
                              sizeof(float) + // QtSilicon
                              sizeof(float) + // QtSulphur
                              sizeof(float) + // QtPhosphorous
                              sizeof(float) + // QtManganese
                              sizeof(float) + // QtNitrogen
                              sizeof(float) + // TundishCarbon
                              sizeof(float) + // TundishSilicon
                              sizeof(float) + // TundishSulphur
                              sizeof(float) + // TundishPhosphorous
                              sizeof(float) + // TundishManganese
                              sizeof(float) + // TundishNitrogen
                              sizeof(int) +   // RunoutTimeMins
                              sizeof(int) +   // RunoutTimeSecs
                              MaxErrorText +  // ErrorText
                              sizeof(int) +   // DolofluxAlarm
                              sizeof(int);    // HighAluminaHeatNumber

        // CoordLink
        this.Header.Length += sizeof(short) + // Grade1
                              sizeof(short) + // Grade2
                              sizeof(short) + // SteelLadleNumber
                              MaxSsUnit +     // SsUnit
                              sizeof(short) + // CasterNumber
                              sizeof(long) +  // PlannedPourTime
                              sizeof(long) +  // PlannedEndDesulphTime
                              sizeof(long) +  // PlannedChargeTime
                              sizeof(long) +  // PlannedTapTime
                              sizeof(long) +  // ActualTapTime
                              sizeof(long) +  // PlannedEndSsTime
                              sizeof(short) + // PlannedDwellTime
                              sizeof(long) +  // PlannedStartCastTime
                              sizeof(long) +  // PlannedEndCastTime
                              sizeof(short) + // CombinedWidth
                              sizeof(short) + // CastDuration
                              sizeof(float) + // CastingRate
                              sizeof(float) + // CastingSpeed
                              MaxComments +   // Comments
                              sizeof(long) +  // UpdateTime
                              sizeof(float) + // ReleaseTemperature
                              sizeof(float);  // AimLadleTemperature

        // Analyses
        for (int i=0; i<MAXANAL; i++)
        {
            this.Header.Length += MaxLbl +        // Lbl
                                  sizeof(float) + // C
                                  sizeof(float) + // Si
                                  sizeof(float) + // S
                                  sizeof(float) + // P
                                  sizeof(float) + // Mn
                                  sizeof(float) + // Ni
                                  sizeof(float) + // Cu
                                  sizeof(float) + // Sn
                                  sizeof(float) + // Cr
                                  sizeof(float) + // Ars
                                  sizeof(float) + // Mo
                                  sizeof(float) + // N2
                                  sizeof(float) + // AlT
                                  sizeof(float) + // AlS
                                  sizeof(float) + // Ti
                                  sizeof(float) + // B
                                  sizeof(float) + // Ca
                                  sizeof(float) + // Ce
                                  sizeof(float) + // Co
                                  sizeof(float) + // Nb
                                  sizeof(float) + // V
                                  sizeof(float) + // CalcAlN2
                                  sizeof(float);  // CalcBN2
        }

        // Additions
        for (int i=0; i<MAXADDS; i++)
        {
            this.Header.Length += MaxMaterial +   // Material
                                  sizeof(float) + // Standard
                                  sizeof(float);  // Model
        }
    }

    public void HeaderLengthWithCBM()
    {
        HeaderLengthBase();
        Header.Length += sizeof(long)            + // CbmRunTimeStamp
                         sizeof(int)             + // CbmResultStatus
                         sizeof(int)             + // HeatStatus
                         sizeof(float)           + // RequiredRecycledSteelWeight
                         sizeof(float)           + // CbmPredictedWapWeight
                         sizeof(float)           + // CbmPredictedSlagWeight
                         sizeof(short)           + // CbmPredictedEndBlowTemp
                         sizeof(long)            + // CbmCommitTimeStamp
                         CbmCommitOperatorLength + // CbmCommitOperator
                         sizeof(short)           + // HmLadleNumber
                         sizeof(float)           + // CalculatedHmLadleCarbon
                         sizeof(float)           + // CalculatedHmLadleSilicon
                         sizeof(float)           + // CalculatedHmLadleManganese
                         sizeof(float)           + // CalculatedHmLadlePhosphorus
                         sizeof(float)           + // CalculatedHmLadleSulphur
                         sizeof(float)           + // CalculatedHmLadleNitrogen
                         sizeof(float)           + // CalculatedHmLadleTemperature
                         sizeof(float)           + // PredictedTapCarbon
                         sizeof(float)           + // PredictedTapManganese
                         sizeof(float)           + // PredictedTapPhosphorus
                         sizeof(float)           + // PredictedTapSulphur
                         sizeof(float)           + // PredictedTapNitrogen
                         sizeof(float)           + // PredictedSlagFe
                         sizeof(float)           + // PredictedSlagCaO
                         sizeof(float)           + // PredictedSlagSiO2
                         sizeof(float)           + // PredictedSlagAl2O3
                         sizeof(float)           + // PredictedSlagMgO
                         sizeof(float)           + // PredictedSlagP2O5
                         sizeof(float)           + // PredictedSlagS
                         sizeof(float)           + // PredictedSlagMnO
                         sizeof(float)           + // PredictedSlagFeO
                         sizeof(float)           + // PredictedSlagTiO2
                         CbmMessageLineLength    + // CbmMessageLine1
                         CbmMessageLineLength    + // CbmMessageLine2
                         CbmMessageLineLength    + // CbmMessageLine3
                         sizeof(short)           + // DesulphRequirementFlag
                         sizeof(short)           + // SkimmingPracticeCode
                         sizeof(float)           + // CalculatedHmTempAtCharge
                         sizeof(short)           + // Converter
                         sizeof(short)           + // RunMode
                         sizeof(float);            // IbDipTriggerOxygen
     }

    public void GotoFrame(int frame)
    {
        if (stream == null) throw new Exception ("TWV.GotoFrame: File not open");
        stream.Seek(this.Header.Length + frame*this.Frame.Length, SeekOrigin.Begin);
    }

    public void Rewind()
    {
        if (stream == null) throw new Exception("TWV.Rewind: File not open");
        stream.Flush();
        stream.Seek(0, SeekOrigin.Begin);
    }

    public FileStream Open(string path, FileMode mode, FileAccess access)
    {
        return new FileStream(path, mode, access);
    }

    public void Close()
    {
        if (stream == null) throw new Exception("TWV.Close: File not open");
        stream.Flush();
        stream.Close();
        stream = null;
    }

    protected byte ConvertGLV(double x)
    {
        const double a = 21.37;
        const double b = 6291.57;
        double y = (x - b) / a;
        if (y < 0) y = 0;
        if (y > 255) y = 255;
        return (byte)y;
    }
}