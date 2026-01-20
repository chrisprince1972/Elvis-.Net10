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

public class TWVReader : TWV
{
    bool FlatSlag = false;

    public TWVReader(string fnam)
    {
        this.FileName = fnam;
        stream = Open(this.FileName);
    }

    public FileStream Open(string path)
    {
        return Open(path, FileMode.Open, FileAccess.Read);
    }

    public void ReadHeader()
    {
        Rewind();

        Read(out this.Header.Version);
        if (this.Header.Version > TWV.RequiredVersion) throw new TWVVersionException(this.Header.Version);
        if (this.Header.Version == TWV.VersionBase) HeaderLengthBase();
        else if (this.Header.Version >= TWV.VersionWithCBM) HeaderLengthWithCBM();

        if (this.Header.Version < TWV.VersionNewCamera)
        {
            // Old camera
            TWV.YPIX = 120;
            TWV.XPIX = 176;
            FlatSlag = false;
        }
        else
        {
            // New camera
            TWV.YPIX = 144;
            TWV.XPIX = 192;
            FlatSlag = true;
        }

        this.Frame.Length -= this.Frame.Pixels.Length;
        this.Frame.Pixels = new byte[TWV.XPIX * TWV.YPIX];
        this.Frame.Length += this.Frame.Pixels.Length;

        Read(out this.Header.VesselNumber);
        Read(out this.Header.HeatNumber);
        Read(out this.Header.StartTap);
        Read(out this.Header.EndTap);
        Read(out this.Header.FrameCount);
        Read(out this.Header.L1);
        Read(out this.Header.L2);
        Read(out this.Header.Red);
        Read(out this.Header.Orange);
        Read(out this.Header.Left);
        Read(out this.Header.Top);
        Read(out this.Header.Right);
        Read(out this.Header.Bottom);
        Read(out this.Header.SlagCarry);
        Read(out this.Header.FlightPath, MaxFlightPath);
        Read(out this.Header.UpOn);
        Read(out this.Header.HeatNumberSet);
        Read(out this.Header.DartRelease);
        Read(out this.Header.CumulativeAlarm);
        Read(out this.Header.PredictedROT);
        Read(out this.Header.Spare5);
        Read(out this.Header.Done);
        this.TotalSeconds = (this.Header.EndTap-this.Header.StartTap).TotalSeconds;

        if (FlatSlag)
        {
            this.Header.L1 = ConvertGLV(7125);
            this.Header.L2 = 254;// ConvertGLV(9262);
            this.Header.Left = 0;
            this.Header.Top = 0;
            this.Header.Right = TWV.XPIX-1;
            this.Header.Bottom = TWV.YPIX-1;
        }

        Read(out this.Header.Ebm.ProgramNumber);
        Read(out this.Header.Ebm.OxygenCbModel);
        Read(out this.Header.Ebm.OxygenAtInBlow);
        Read(out this.Header.Ebm.OxygenEbModel);
        Read(out this.Header.Ebm.OxygenAtPostBlow);
        Read(out this.Header.Ebm.OxygenVolumeToCharge);
        Read(out this.Header.Ebm.OreCbModel);
        Read(out this.Header.Ebm.OreAtInBlow);
        Read(out this.Header.Ebm.OreEbModel);
        Read(out this.Header.Ebm.OreAtPostBlow);
        Read(out this.Header.Ebm.AimTemperature);
        Read(out this.Header.Ebm.InBlowTemperature);
        Read(out this.Header.Ebm.InBlowTemperatureQc);
        Read(out this.Header.Ebm.AimCarbon);
        Read(out this.Header.Ebm.InBlowCarbon);
        Read(out this.Header.Ebm.InBlowCarbonQc);
        Read(out this.Header.Ebm.Pb1Temperature);
        Read(out this.Header.Ebm.Pb1TemperatureQc);
        Read(out this.Header.Ebm.Pb1OxyActivity);
        Read(out this.Header.Ebm.Pb1OxyActivityQc);
        Read(out this.Header.Ebm.Pb1CalculatedCarbon);
        Read(out this.Header.Ebm.Pb1ImmersionDepth);
        Read(out this.Header.Ebm.Pb1ImmersionDepthQc);
        Read(out this.Header.Ebm.Pb1BathHeight);
        Read(out this.Header.Ebm.Pb2Temperature);
        Read(out this.Header.Ebm.Pb2TemperatureQc);
        Read(out this.Header.Ebm.Pb2OxyActivity);
        Read(out this.Header.Ebm.Pb2OxyActivityQc);
        Read(out this.Header.Ebm.Pb2CalculatedCarbon);
        Read(out this.Header.Ebm.Pb2ImmersionDepth);
        Read(out this.Header.Ebm.Pb2ImmersionDepthQc);
        Read(out this.Header.Ebm.Pb2BathHeight);
        Read(out this.Header.Ebm.OreAlarm);
        Read(out this.Header.Ebm.LimeAlarm);
        Read(out this.Header.Ebm.ScrapAlarm);
        Read(out this.Header.Ebm.PhosphorousAlarm);
        Read(out this.Header.Ebm.TsoRequired);
        Read(out this.Header.Ebm.EstOxyActivity);
        Read(out this.Header.Ebm.EstPbCarbon);
        Read(out this.Header.Ebm.SlspOxyActivity);
        Read(out this.Header.Ebm.SlspOxyActivityQc);
        Read(out this.Header.Ebm.SlspDolofluxWt);
        Read(out this.Header.Ebm.ReblowOxygen);
        Read(out this.Header.Ebm.CoolbackOre);
        Read(out this.Header.Ebm.DeltaTemperature);
        Read(out this.Header.Ebm.ReblowRequired);
        Read(out this.Header.Ebm.LadleAimTemperature);
        Read(out this.Header.Ebm.LadleAimCarbon);
        Read(out this.Header.Ebm.LadleActualTemperature);
        Read(out this.Header.Ebm.LadleActualCarbon);
        Read(out this.Header.Ebm.HmCarbon);
        Read(out this.Header.Ebm.HmSilicon);
        Read(out this.Header.Ebm.HmSulphur);
        Read(out this.Header.Ebm.HmPhosphorous);
        Read(out this.Header.Ebm.HmManganese);
        Read(out this.Header.Ebm.HmNitrogen);
        Read(out this.Header.Ebm.IbCarbon);
        Read(out this.Header.Ebm.IbSilicon);
        Read(out this.Header.Ebm.IbSulphur);
        Read(out this.Header.Ebm.IbPhosphorous);
        Read(out this.Header.Ebm.IbManganese);
        Read(out this.Header.Ebm.IbNitrogen);
        Read(out this.Header.Ebm.Pb1Carbon);
        Read(out this.Header.Ebm.Pb1Silicon);
        Read(out this.Header.Ebm.Pb1Sulphur);
        Read(out this.Header.Ebm.Pb1Phosphorous);
        Read(out this.Header.Ebm.Pb1Manganese);
        Read(out this.Header.Ebm.Pb1Nitrogen);
        Read(out this.Header.Ebm.QtCarbon);
        Read(out this.Header.Ebm.QtSilicon);
        Read(out this.Header.Ebm.QtSulphur);
        Read(out this.Header.Ebm.QtPhosphorous);
        Read(out this.Header.Ebm.QtManganese);
        Read(out this.Header.Ebm.QtNitrogen);
        Read(out this.Header.Ebm.TundishCarbon);
        Read(out this.Header.Ebm.TundishSilicon);
        Read(out this.Header.Ebm.TundishSulphur);
        Read(out this.Header.Ebm.TundishPhosphorous);
        Read(out this.Header.Ebm.TundishManganese);
        Read(out this.Header.Ebm.TundishNitrogen);
        Read(out this.Header.Ebm.RunoutTimeMins);
        Read(out this.Header.Ebm.RunoutTimeSecs);
        Read(out this.Header.Ebm.ErrorText, MaxErrorText);
        Read(out this.Header.Ebm.DolofluxAlarm);
        Read(out this.Header.Ebm.HighAluminaHeatNumber);

        Read(out this.Header.Coord.Grade1);
        Read(out this.Header.Coord.Grade2);
        Read(out this.Header.Coord.SteelLadleNumber);
        Read(out this.Header.Coord.SsUnit, MaxSsUnit);
        Read(out this.Header.Coord.CasterNumber);
        Read(out this.Header.Coord.PlannedPourTime);
        Read(out this.Header.Coord.PlannedEndDesulphTime);
        Read(out this.Header.Coord.PlannedChargeTime);
        Read(out this.Header.Coord.PlannedTapTime);
        Read(out this.Header.Coord.ActualTapTime);
        Read(out this.Header.Coord.PlannedEndSsTime);
        Read(out this.Header.Coord.PlannedDwellTime);
        Read(out this.Header.Coord.PlannedStartCastTime);
        Read(out this.Header.Coord.PlannedEndCastTime);
        Read(out this.Header.Coord.CombinedWidth);
        Read(out this.Header.Coord.CastDuration);
        Read(out this.Header.Coord.CastingRate);
        Read(out this.Header.Coord.CastingSpeed);
        Read(out this.Header.Coord.Comments, MaxComments);
        Read(out this.Header.Coord.UpdateTime);
        Read(out this.Header.Coord.ReleaseTemperature);
        Read(out this.Header.Coord.AimLadleTemperature);

        for (int i=0; i<MAXANAL; i++)
        {
            Read(out this.Header.Anals[i].Lbl, MaxLbl);
            Read(out this.Header.Anals[i].C);
            Read(out this.Header.Anals[i].Si);
            Read(out this.Header.Anals[i].S);
            Read(out this.Header.Anals[i].P);
            Read(out this.Header.Anals[i].Mn);
            Read(out this.Header.Anals[i].Ni);
            Read(out this.Header.Anals[i].Cu);
            Read(out this.Header.Anals[i].Sn);
            Read(out this.Header.Anals[i].Cr);
            Read(out this.Header.Anals[i].Ars);
            Read(out this.Header.Anals[i].Mo);
            Read(out this.Header.Anals[i].N2);
            Read(out this.Header.Anals[i].AlT);
            Read(out this.Header.Anals[i].AlS);
            Read(out this.Header.Anals[i].Ti);
            Read(out this.Header.Anals[i].B);
            Read(out this.Header.Anals[i].Ca);
            Read(out this.Header.Anals[i].Ce);
            Read(out this.Header.Anals[i].Co);
            Read(out this.Header.Anals[i].Nb);
            Read(out this.Header.Anals[i].V);
            Read(out this.Header.Anals[i].CalcAlN2);
            Read(out this.Header.Anals[i].CalcBN2);
        }

        for (int i=0; i<MAXADDS; i++)
        {
            Read(out this.Header.Adds[i].Material, MaxMaterial);
            Read(out this.Header.Adds[i].Standard);
            Read(out this.Header.Adds[i].Model);
        }

        if (this.Header.Version >= TWV.VersionWithCBM)
        {
            Read(out this.Header.Cbm.CbmRunTimeStamp);
            Read(out this.Header.Cbm.CbmResultStatus);
            Read(out this.Header.Cbm.HeatStatus);
            Read(out this.Header.Cbm.RequiredRecycledSteelWeight);
            Read(out this.Header.Cbm.CbmPredictedTapWeight);
            Read(out this.Header.Cbm.CbmPredictedSlagWeight);
            Read(out this.Header.Cbm.CbmPredictedEndBlowTemp);
            Read(out this.Header.Cbm.CbmCommitTimeStamp);
            Read(out this.Header.Cbm.CbmCommitOperator, TWV.CbmCommitOperatorLength);
            Read(out this.Header.Cbm.HmLadleNumber);
            Read(out this.Header.Cbm.CalculatedHmLadleCarbon);
            Read(out this.Header.Cbm.CalculatedHmLadleSilicon);
            Read(out this.Header.Cbm.CalculatedHmLadleManganese);
            Read(out this.Header.Cbm.CalculatedHmLadlePhosphorus);
            Read(out this.Header.Cbm.CalculatedHmLadleSulphur);
            Read(out this.Header.Cbm.CalculatedHmLadleNitrogen);
            Read(out this.Header.Cbm.CalculatedHmLadleTemperature);
            Read(out this.Header.Cbm.PredictedTapCarbon);
            Read(out this.Header.Cbm.PredictedTapManganese);
            Read(out this.Header.Cbm.PredictedTapPhosphorus);
            Read(out this.Header.Cbm.PredictedTapSulphur);
            Read(out this.Header.Cbm.PredictedTapNitrogen);
            Read(out this.Header.Cbm.PredictedSlagFe);
            Read(out this.Header.Cbm.PredictedSlagCaO);
            Read(out this.Header.Cbm.PredictedSlagSiO2);
            Read(out this.Header.Cbm.PredictedSlagAl2O3);
            Read(out this.Header.Cbm.PredictedSlagMgO);
            Read(out this.Header.Cbm.PredictedSlagP2O5);
            Read(out this.Header.Cbm.PredictedSlagS);
            Read(out this.Header.Cbm.PredictedSlagMnO);
            Read(out this.Header.Cbm.PredictedSlagFeO);
            Read(out this.Header.Cbm.PredictedSlagTiO2);
            Read(out this.Header.Cbm.CbmMessageLine1, TWV.CbmMessageLineLength);
            Read(out this.Header.Cbm.CbmMessageLine2, TWV.CbmMessageLineLength);
            Read(out this.Header.Cbm.CbmMessageLine3, TWV.CbmMessageLineLength);
            Read(out this.Header.Cbm.DesulphRequirementFlag);
            Read(out this.Header.Cbm.SkimmingPracticeCode);
            Read(out this.Header.Cbm.CalculatedHmTempAtCharge);
            Read(out this.Header.Cbm.Converter);
            Read(out this.Header.Cbm.RunMode);
            Read(out this.Header.Cbm.IbDipTriggerOxygen);
        }
    }

    private void ReadFrameHeader()
    {
        Read(out this.Frame.Timestamp);
        Read(out this.Frame.Angle);
        Read(out this.Frame.Speed);
        Read(out this.Frame.SteelPixels);
        Read(out this.Frame.SlagPixels);
        Read(out this.Frame.Alarm);
    }

    public void ReadFrameNoPixels()
    {
        ReadFrameHeader();
        stream.Seek(this.Frame.Pixels.Length, SeekOrigin.Current);
    }

    public void ReadFrame()
    {
        ReadFrameHeader();
        Read(ref this.Frame.Pixels);
        if (this.FlatSlag)
        {
            for (int ii = 0; ii < this.Frame.Pixels.Length; ii++)
            {
                if (this.Frame.Pixels[ii] == 1) this.Frame.Pixels[ii] = 255;
                else if (this.Frame.Pixels[ii] == 0) this.Frame.Pixels[ii] = 254;
                else this.Frame.Pixels[ii] -= 1;
            }
        }
    }

    public void ReadFrame(int frame)
    {
        GotoFrame(frame);
        ReadFrame();
    }

    private void Read(out byte val)
    {
        byte[] arr = new byte[sizeof(byte)];
        stream.Read(arr, 0, arr.Length);
        val = arr[0];
    }

    private void Read(out short val)
    {
        byte[] arr = new byte[sizeof(short)];
        stream.Read(arr, 0, arr.Length);
        val = BitConverter.ToInt16(arr, 0);
    }

    private void Read(out int val)
    {
        byte[] arr = new byte[sizeof(int)];
        stream.Read(arr, 0, arr.Length);
        val = BitConverter.ToInt32(arr, 0);
    }

    private void Read(out float val)
    {
        byte[] arr = new byte[sizeof(float)];
        stream.Read(arr, 0, arr.Length);
        val = BitConverter.ToSingle(arr,0);
    }

    private void Read(out bool val)
    {
        byte[] arr = new byte[sizeof(bool)];
        stream.Read(arr, 0, arr.Length);
        val = BitConverter.ToBoolean(arr,0);
    }

    private void Read(out DateTime val)
    {
        byte[] arr = new byte[sizeof(long)];
        stream.Read(arr, 0, arr.Length);
        val = new DateTime(BitConverter.ToInt64(arr,0));
    }

    private void Read(out string val, int len)
    {
        byte[] arr = new byte[len];
        stream.Read(arr, 0, arr.Length);
        val = Encoding.ASCII.GetString(arr);
    }

    private void Read(ref byte[] arr)
    {
        stream.Read(arr, 0, arr.Length);
    }
}
