using System;
using System.Collections.Generic;
using System.Linq;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Model
{
    public static class Trending
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the List of TrendData ready for graph population.
        /// Using a list of TrendDataIndexit gets all the
        /// data from the relevant tables and creates a list of
        /// TrendData objects to return.
        /// </summary>
        /// <param name="trendDataFilterList">List of TrendDataIndex objects to filter by.</param>
        /// <returns>Returns a List of TrendDataIndex objects.</returns>
        public static List<TrendData> GetTrendData(List<TrendDataIndex> trendDataFilterList)
        {
            List<TrendData> trendData = new List<TrendData>();
            try
            {
                AddAdditions(trendData,
                    EntityHelper.TrendData.GetByIndexList<TrendDataAddition>(trendDataFilterList));

                AddAnalysis(trendData,
                    EntityHelper.TrendData.GetByIndexList<TrendDataAnalysis>(trendDataFilterList));

                AddProcess(trendData,
                    EntityHelper.TrendData.GetByIndexList<TrendDataProcess>(trendDataFilterList));

                AddTemps(trendData,
                    EntityHelper.TrendData.GetByIndexList<TrendDataTemp>(trendDataFilterList));

                AddTimes(trendData,
                    EntityHelper.TrendData.GetByIndexList<TrendDataTime>(trendDataFilterList));
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                        "DATA ERROR -- GetTrendData() -- Error getting trend data -- ",
                    ex);
            }
            return trendData;
        }

        /// <summary>
        /// Adds or Edits existing Trend Data to update
        /// the list with the TrendDataAdditions Data.
        /// </summary>
        /// <param name="trendData">The Trend Data to update.</param>
        /// <param name="additions">The List of Additions to update with.</param>
        private static void AddAdditions(List<TrendData> trendData, List<TrendDataAddition> additions)
        {
            foreach (TrendDataAddition addition in additions)
            {
                TrendData existingTrendData = trendData.FirstOrDefault(t =>
                    t.TrendSampleIndex == addition.TrendSampleIndex);

                if (existingTrendData == null)
                {//Add a New Trend
                    trendData.Add(new TrendData()
                    {
                        TrendSampleIndex = addition.TrendSampleIndex,
                        HeatNumber = addition.HeatNumber,
                        HNS = addition.HNS,
                        WobWeight = addition.WobWeight,
                        DolofluxWeight = addition.DolofluxWeight,
                        OreWeight = addition.OreWeight,
                        LimeWeight = addition.LimeWeight,
                        DolometWeight = addition.DolometWeight,
                        DeSTotalMgWeight = addition.DeSTotalMgWeight,
                        HotMetalWeight = addition.HotMetalWeight,
                        ScrapWeight = addition.ScrapWeight,
                        SecScrapWeight = addition.SecScrapWeight,
                        SteelSkullWeight = addition.SteelSkullWeight
                        //Add additional tag data here
                    });
                }
                else
                {//Edit Existing Trend
                    existingTrendData.WobWeight = addition.WobWeight;
                    existingTrendData.DolofluxWeight = addition.DolofluxWeight;
                    existingTrendData.OreWeight = addition.OreWeight;
                    existingTrendData.LimeWeight = addition.LimeWeight;
                    existingTrendData.DolometWeight = addition.DolometWeight;
                    existingTrendData.DeSTotalMgWeight = addition.DeSTotalMgWeight;
                    existingTrendData.HotMetalWeight = addition.HotMetalWeight;
                    existingTrendData.ScrapWeight = addition.ScrapWeight;
                    existingTrendData.SecScrapWeight = addition.SecScrapWeight;
                    existingTrendData.SteelSkullWeight = addition.SteelSkullWeight;
                    //Add additional tag data here
                }
            }
        }

        /// <summary>
        /// Adds or Edits existing Trend Data to update
        /// the list with the TrendDataAnalysis Data.
        /// </summary>
        /// <param name="trendData">The Trend Data to update.</param>
        /// <param name="analyses">The List of Analysis to update with.</param>
        private static void AddAnalysis(List<TrendData> trendData, List<TrendDataAnalysis> analyses)
        {
            foreach (TrendDataAnalysis analysis in analyses)
            {
                TrendData existingTrendData = trendData.FirstOrDefault(t =>
                    t.TrendSampleIndex == analysis.TrendSampleIndex);

                if (existingTrendData == null)
                {//Add a New Trend
                    trendData.Add(new TrendData()
                    {
                        TrendSampleIndex = analysis.TrendSampleIndex,
                        HeatNumber = analysis.HeatNumber,
                        HNS = analysis.HNS,
                        HMSi = analysis.HMSi,
                        Basicity = analysis.Basicity,
                        CaO = analysis.CaO,
                        SiO2 = analysis.SiO2,
                        TotalFe = analysis.TotalFe,
                        EBPhos = analysis.EBPhos,
                        HMS = analysis.HMS,
                        N2Pickup = analysis.N2Pickup,
                        HMP = analysis.HMP,
                        HMMn = analysis.HMMn,
                        LadleS = analysis.LadleS,
                        LadleP = analysis.LadleP,
                        LadleN = analysis.LadleN,
                        TunC = analysis.TunC,
                        TunS = analysis.TunS,
                        TunP = analysis.TunP,
                        TunN = analysis.TunN,
                        TunAlSol = analysis.TunAlSol,
                        SSHydris = analysis.SSHydris,
                        SecN2Pickup = analysis.SecN2Pickup,
                        Al203 = analysis.Al2O3,
                        MgO = analysis.MgO
                        //Add additional tag data here
                    });
                }
                else
                {//Edit Existing Trend
                    existingTrendData.HMSi = analysis.HMSi;
                    existingTrendData.Basicity = analysis.Basicity;
                    existingTrendData.CaO = analysis.CaO;
                    existingTrendData.SiO2 = analysis.SiO2;
                    existingTrendData.TotalFe = analysis.TotalFe;
                    existingTrendData.EBPhos = analysis.EBPhos;
                    existingTrendData.HMS = analysis.HMS;
                    existingTrendData.N2Pickup = analysis.N2Pickup;
                    existingTrendData.HMP = analysis.HMP;
                    existingTrendData.HMMn = analysis.HMMn;
                    existingTrendData.LadleS = analysis.LadleS;
                    existingTrendData.LadleP = analysis.LadleP;
                    existingTrendData.LadleN = analysis.LadleN;
                    existingTrendData.TunC = analysis.TunC;
                    existingTrendData.TunS = analysis.TunS;
                    existingTrendData.TunP = analysis.TunP;
                    existingTrendData.TunN = analysis.TunN;
                    existingTrendData.TunAlSol = analysis.TunAlSol;
                    existingTrendData.SSHydris = analysis.SSHydris;
                    existingTrendData.SecN2Pickup = analysis.SecN2Pickup;
                    existingTrendData.Al203 = analysis.Al2O3;
                    existingTrendData.MgO = analysis.MgO;
                    //Add additional tag data here
                }
            }
        }

        /// <summary>
        /// Adds or Edits existing Trend Data to update
        /// the list with the TrendDataProcess Data.
        /// </summary>
        /// <param name="trendData">The Trend Data to update.</param>
        /// <param name="processes">The List of Process to update with.</param>
        private static void AddProcess(List<TrendData> trendData, List<TrendDataProcess> processes)
        {
            foreach (TrendDataProcess process in processes)
            {
                TrendData existingTrendData = trendData.FirstOrDefault(t =>
                    t.TrendSampleIndex == process.TrendSampleIndex);

                if (existingTrendData == null)
                {//Add a New Trend
                    trendData.Add(new TrendData()
                    {
                        TrendSampleIndex = process.TrendSampleIndex,
                        HeatNumber = process.HeatNumber,
                        HNS = process.HNS,
                        HMDesSkimLoss = process.HMDesSkimLoss,
                        TapWeightError = process.TapWeightError,
                        LadleReturnWeight = process.LadleReturnWeight,
                        HMLiquidRatio = process.HMLiquidRatio,
                        EBTempVar = process.EBTempVar,
                        EBCoolReq = process.EBCoolReq,
                        EBCoolAdd = process.EBCoolAdd,
                        EBOXYDiff = process.EBOXYDiff,
                        LadleTempVar = process.LadleTempVar,
                        ReHeat = process.ReHeat,
                        SlagDepth = process.SlagDepth,
                        Freeboard = process.Freeboard,
                        CCStartWeight = process.CCStartWeight,
                        CCEndWeight = process.CCEndWeight,
                        TapWeightActual = process.TapWeightActual,
                        TapWeightPred = process.TapWeightPred,
                        TapAdditions = process.TapAdditions,
                        VesselSlop = process.VesselSlop,
                        CastRate = process.CastRate,
                        CastingSpeed = process.CastingSpeed,
                        TundishWeight = process.TundishWeight,
                        LadleLiningTemp = process.LadleLiningTemp,
                        UpOnMetal = process.UpOnMetal,
                        LadleBubbling = process.LadleBubbling,
                        TundishSkullWeight = process.TundishSkullWeight,
                        Dart = process.Dart,
                        PrimaryYield = process.PrimaryYield,
                        LadleScheduleIndex = process.LadleScheduleIndex,
                        TPVPressure = process.TPVPressure,
                        HeavySlopDuration = process.HeavySlopDuration,
                        HeavySlopCount = process.HeavySlopCount,
                        COProduct = process.COProduct

                        //Add additional tag data here
                    });
                }
                else
                {//Edit Existing Trend
                    existingTrendData.HMDesSkimLoss = process.HMDesSkimLoss;
                    existingTrendData.TapWeightError = process.TapWeightError;
                    existingTrendData.LadleReturnWeight = process.LadleReturnWeight;
                    existingTrendData.HMLiquidRatio = process.HMLiquidRatio;
                    existingTrendData.EBTempVar = process.EBTempVar;
                    existingTrendData.EBCoolReq = process.EBCoolReq;
                    existingTrendData.EBCoolAdd = process.EBCoolAdd;
                    existingTrendData.EBOXYDiff = process.EBOXYDiff;
                    existingTrendData.LadleTempVar = process.LadleTempVar;
                    existingTrendData.ReHeat = process.ReHeat;
                    existingTrendData.SlagDepth = process.SlagDepth;
                    existingTrendData.Freeboard = process.Freeboard;
                    existingTrendData.CCStartWeight = process.CCStartWeight;
                    existingTrendData.CCEndWeight = process.CCEndWeight;
                    existingTrendData.TapWeightActual = process.TapWeightActual;
                    existingTrendData.TapWeightPred = process.TapWeightPred;
                    existingTrendData.TapAdditions = process.TapAdditions;
                    existingTrendData.VesselSlop = process.VesselSlop;
                    existingTrendData.CastRate = process.CastRate;
                    existingTrendData.CastingSpeed = process.CastingSpeed;
                    existingTrendData.TundishWeight = process.TundishWeight;
                    existingTrendData.LadleLiningTemp = process.LadleLiningTemp;
                    existingTrendData.UpOnMetal = process.UpOnMetal;
                    existingTrendData.LadleBubbling = process.LadleBubbling;
                    existingTrendData.TundishSkullWeight = process.TundishSkullWeight;
                    existingTrendData.Dart = process.Dart;
                    existingTrendData.PrimaryYield = process.PrimaryYield;
                    existingTrendData.LadleScheduleIndex = process.LadleScheduleIndex;
                    existingTrendData.TPVPressure = process.TPVPressure;
                    existingTrendData.HeavySlopDuration = process.HeavySlopDuration;
                    existingTrendData.HeavySlopCount = process.HeavySlopCount;
                    existingTrendData.COProduct = process.COProduct;
                    //Add additional tag data here
                }
            }
        }

        /// <summary>
        /// Adds or Edits existing Trend Data to update
        /// the list with the TrendDataTemps Data.
        /// </summary>
        /// <param name="trendData">The Trend Data to update.</param>
        /// <param name="temps">The List of Temps to update with.</param>
        private static void AddTemps(List<TrendData> trendData, List<TrendDataTemp> temps)
        {
            foreach (TrendDataTemp temp in temps)
            {
                TrendData existingTrendData = trendData.FirstOrDefault(t =>
                    t.TrendSampleIndex == temp.TrendSampleIndex);

                if (existingTrendData == null)
                {//Add a New Trend
                    trendData.Add(new TrendData()
                    {
                        TrendSampleIndex = temp.TrendSampleIndex,
                        HeatNumber = temp.HeatNumber,
                        HNS = temp.HNS,
                        HMTemp = temp.HMTemp,
                        ActEBTemp = temp.ActEBTemp,
                        AimEBTemp = temp.AimEBTemp,
                        AimLadleTemp = temp.AimLadleTemp,
                        ActLadleTemp = temp.ActLadleTemp,
                        AimReleaseTemp = temp.AimReleaseTemp,
                        ActReleaseTemp = temp.ActReleaseTemp,
                        ReleaseTempDev = temp.ReleaseTempDev
                        //Add additional tag data here
                    });
                }
                else
                {//Edit Existing Trend
                    existingTrendData.HMTemp = temp.HMTemp;
                    existingTrendData.ActEBTemp = temp.ActEBTemp;
                    existingTrendData.AimEBTemp = temp.AimEBTemp;
                    existingTrendData.AimLadleTemp = temp.AimLadleTemp;
                    existingTrendData.ActLadleTemp = temp.ActLadleTemp;
                    existingTrendData.AimReleaseTemp = temp.AimReleaseTemp;
                    existingTrendData.ActReleaseTemp = temp.ActReleaseTemp;
                    existingTrendData.ReleaseTempDev = temp.ReleaseTempDev;
                    //Add additional tag data here
                }
            }
        }

        /// <summary>
        /// Adds or Edits existing Trend Data to update
        /// the list with the TrendDataTimes Data.
        /// </summary>
        /// <param name="trendData">The Trend Data to update.</param>
        /// <param name="times">The List of Times to update with.</param>
        private static void AddTimes(List<TrendData> trendData, List<TrendDataTime> times)
        {
            foreach (TrendDataTime time in times)
            {
                TrendData existingTrendData = trendData.FirstOrDefault(t =>
                    t.TrendSampleIndex == time.TrendSampleIndex);

                if (existingTrendData == null)
                {//Add a New Trend
                    trendData.Add(new TrendData()
                    {
                        TrendSampleIndex = time.TrendSampleIndex,
                        HeatNumber = time.HeatNumber,
                        HNS = time.HNS,
                        VesselCycleTime = time.VesselCycleTime,
                        VesselCycleTimeSameVessel = time.VesselCycleTimeSameVessel,
                        ChargeToBlowTime = time.ChargeToBlowTime,
                        BlowingTime = time.BlowingTime,
                        BlowToTapTime = time.BlowToTapTime,
                        TappingTime = time.TappingTime,
                        TapToChargeTime = time.TapToChargeTime,
                        PlannedDwellTime = time.PlannedDwellTime,
                        ActDwellTime = time.ActDwellTime,
                        WaitingTime = time.WaitingTime,
                        TreatmentTime = time.TreatmentTime,
                        FloatationTime = time.FloatationTime,
                        LadleTurnTime = time.LadleTurnTime,
                        DeSStartToInject = time.DeSStartToInject,
                        DeSInjectionTime = time.DeSInjectionTime,
                        DeSInjectToRabble = time.DeSInjectToRabble,
                        DeSRabbleTime = time.DeSRabbleTime,
                        DeSRabbleToEnd = time.DeSRabbleToEnd,
                        DeSTotalTime = time.DeSTotalTime
                        //Add additional tag data here
                    });
                }
                else
                {//Edit Existing Trend
                    existingTrendData.VesselCycleTime = time.VesselCycleTime;
                    existingTrendData.VesselCycleTimeSameVessel = time.VesselCycleTimeSameVessel;
                    existingTrendData.ChargeToBlowTime = time.ChargeToBlowTime;
                    existingTrendData.BlowingTime = time.BlowingTime;
                    existingTrendData.BlowToTapTime = time.BlowToTapTime;
                    existingTrendData.TappingTime = time.TappingTime;
                    existingTrendData.TapToChargeTime = time.TapToChargeTime;
                    existingTrendData.PlannedDwellTime = time.PlannedDwellTime;
                    existingTrendData.ActDwellTime = time.ActDwellTime;
                    existingTrendData.WaitingTime = time.WaitingTime;
                    existingTrendData.TreatmentTime = time.TreatmentTime;
                    existingTrendData.FloatationTime = time.FloatationTime;
                    existingTrendData.LadleTurnTime = time.LadleTurnTime;
                    existingTrendData.DeSStartToInject = time.DeSStartToInject;
                    existingTrendData.DeSInjectionTime = time.DeSInjectionTime;
                    existingTrendData.DeSInjectToRabble = time.DeSInjectToRabble;
                    existingTrendData.DeSRabbleTime = time.DeSRabbleTime;
                    existingTrendData.DeSRabbleToEnd = time.DeSRabbleToEnd;
                    existingTrendData.DeSTotalTime = time.DeSTotalTime;
                    //Add additional tag data here
                }
            }
        }

        /// <summary>
        /// Provides a list of Series as strings for highlighting
        /// on the distribution graph.
        /// </summary>
        /// <param name="highlightBy">The Group Highlight.</param>
        /// <returns>A list of strings representing the series.</returns>
        public static List<string> GetTrendHighlightList(GroupHighlight highlightBy)
        {
            if (highlightBy.Description.Equals("Sec Steel"))
            {
                return new List<string>()
                {
                    "CAS 1",
                    "CAS 2",
                    "RH Degasser",
                    "RD Degasser"
                };
            }
            else if (highlightBy.Description.Equals("Casters"))
            {
                return new List<string>()
                {
                    "Caster 1",
                    "Caster 2",
                    "Caster 3"
                };
            }
            else if (highlightBy.Description.Equals("Desulph"))
            {
                return new List<string>()
                {
                    "Desulph North",
                    "Desulph South"
                };
            }
            else if (highlightBy.Description.Equals("Hot Metal"))
            {
                return new List<string>()
                {
                    "Hot Metal North",
                    "Hot Metal South"
                };
            }
            else if (highlightBy.Description.Equals("Rota"))
            {
                return new List<string>()
                {
                    "A Rota",
                    "B Rota",
                    "C Rota",
                    "D Rota"
                };
            }
            else if (highlightBy.Description.Equals("Vessels"))
            {
                return new List<string>()
                {
                    "Vessel 1",
                    "Vessel 2"
                };
            }
            return new List<string>();
        }

        /// <summary>
        /// Method that determines which field value to use
        /// depending on which parameter the graph has been
        /// set up for.
        /// </summary>
        /// <param name="trend">The Trand Data value.</param>
        /// <returns>A float to display on the graph.</returns>
        public static float? GetValueForCorrectParameter(TrendData trend, string parFieldName)
        {
            switch (parFieldName)
            {
                case "VesselCycleTime":             //ParIndex = 1
                    return trend.VesselCycleTime;
                case "VesselCycleTimeSameVessel":   //ParIndex = 2
                    return trend.VesselCycleTimeSameVessel;
                case "ChargeToBlowTime":            //ParIndex = 3
                    return trend.ChargeToBlowTime;
                case "BlowingTime":                 //ParIndex = 4
                    return trend.BlowingTime;
                case "BlowToTapTime":               //ParIndex = 5
                    return trend.BlowToTapTime;
                case "TappingTime":                 //ParIndex = 6
                    return trend.TappingTime;
                case "TapToChargeTime":             //ParIndex = 7
                    return trend.TapToChargeTime;
                case "PlannedDwellTime":            //ParIndex = 8
                    return trend.PlannedDwellTime;
                case "ActDwellTime":                //ParIndex = 9
                    return trend.ActDwellTime;
                case "WaitingTime":                 //ParIndex = 10
                    return trend.WaitingTime;
                case "TreatmentTime":               //ParIndex = 11
                    return trend.TreatmentTime;
                case "FloatationTime":              //ParIndex = 12
                    return trend.FloatationTime;
                case "LadleTurnTime":               //ParIndex = 13
                    return trend.LadleTurnTime;
                case "HMSI":                        //ParIndex = 15
                    return trend.HMSi;
                case "HMTemp":                      //ParIndex = 16
                    return trend.HMTemp;
                case "WobWeight":                   //ParIndex = 17
                    return trend.WobWeight;
                case "DolofluxWeight":              //ParIndex = 18
                    return trend.DolofluxWeight;
                case "OreWeight":                   //ParIndex = 19
                    return trend.OreWeight;
                case "EBTempVar":                   //ParIndex = 20
                    return trend.EBTempVar;
                case "ActEBTemp":                   //ParIndex = 21
                    return trend.ActEBTemp;
                case "AimEBTemp":                   //ParIndex = 22
                    return trend.AimEBTemp;
                case "EBCoolReq":                   //ParIndex = 23
                    return trend.EBCoolReq;
                case "EBCoolAdd":                   //ParIndex = 24
                    return trend.EBCoolAdd;
                case "EBOXYDiff":                   //ParIndex = 25
                    return trend.EBOXYDiff;
                case "ReHeat":                      //ParIndex = 26
                    return trend.ReHeat;
                case "CaO":                         //ParIndex = 27
                    return trend.CaO;
                case "SiO2":                        //ParIndex = 28
                    return trend.SiO2;
                case "Basicity":                    //ParIndex = 29
                    return trend.Basicity;
                case "HMDesSkimLoss":               //ParIndex = 30
                    return trend.HMDesSkimLoss;
                case "LimeWeight":                  //ParIndex = 31
                    return trend.LimeWeight;
                case "DolometWeight":               //ParIndex = 32
                    return trend.DolometWeight;
                case "TapWeightError":              //ParIndex = 33
                    return trend.TapWeightError;
                case "LadleReturnWeight":           //ParIndex = 34
                    return trend.LadleReturnWeight;
                case "HMLiquidRatio":               //ParIndex = 35
                    return trend.HMLiquidRatio;
                case "LadleTempVar":                //ParIndex = 36
                    return trend.LadleTempVar;
                case "SlagDepth":                   //ParIndex = 37
                    return trend.SlagDepth;
                case "Freeboard":                   //ParIndex = 38
                    return trend.Freeboard;
                case "CCStartWeight":               //ParIndex = 39
                    return trend.CCStartWeight;
                case "CCEndWeight":                 //ParIndex = 40
                    return trend.CCEndWeight;
                case "TapWeightActual":             //ParIndex = 41
                    return trend.TapWeightActual;
                case "TapWeightPred":               //ParIndex = 42
                    return trend.TapWeightPred;
                case "TapAdditions":                //ParIndex = 43
                    return trend.TapAdditions;
                case "AimLadleTemp":                //ParIndex = 44
                    return trend.AimLadleTemp;
                case "ActLadleTemp":                //ParIndex = 45
                    return trend.ActLadleTemp;
                case "DeSStartToInject":            //ParIndex = 46
                    return trend.DeSStartToInject;
                case "DeSInjectionTime":            //ParIndex = 47
                    return trend.DeSInjectionTime;
                case "DeSInjectToRabble":           //ParIndex = 48
                    return trend.DeSInjectToRabble;
                case "DeSRabbleTime":               //ParIndex = 49
                    return trend.DeSRabbleTime;
                case "DeSRabbleToEnd":              //ParIndex = 50
                    return trend.DeSRabbleToEnd;
                case "DeSTotalMgWeight":            //ParIndex = 51
                    return trend.DeSTotalMgWeight;
                case "TotalFe":                     //ParIndex = 52
                    return trend.TotalFe;
                case "EBPhos":                      //ParIndex = 53
                    return trend.EBPhos;
                case "HMS":                         //ParIndex = 54
                    return trend.HMS;
                case "VesselSlop":                  //ParIndex = 55
                    return trend.VesselSlop;
                case "DeSTotalTime":                //ParIndex = 56
                    return trend.DeSTotalTime;
                case "AimReleaseTemp":              //ParIndex = 57
                    return trend.AimReleaseTemp;
                case "ActReleaseTemp":              //ParIndex = 58
                    return trend.ActReleaseTemp;
                case "ReleaseTempDev":              //ParIndex = 59
                    return trend.ReleaseTempDev;
                case "HotMetalWeight":              //ParIndex = 60
                    return trend.HotMetalWeight;
                case "ScrapWeight":                 //ParIndex = 61
                    return trend.ScrapWeight;
                case "CastRate":                    //ParIndex = 62
                    return trend.CastRate;
                case "N2Pickup":                    //ParIndex = 63
                    return trend.N2Pickup;
                case "CastingSpeed":                //ParIndex = 64
                    return trend.CastingSpeed;
                case "TundishWeight":               //ParIndex = 65
                    return trend.TundishWeight;
                case "SecScrapWeight":              //ParIndex = 66
                    return trend.SecScrapWeight;
                case "LadleLiningTemp":             //ParIndex = 67
                    return trend.LadleLiningTemp;
                case "UpOnMetal":                   //ParIndex = 68
                    return trend.UpOnMetal;
                case "LadleBubbling":               //ParIndex = 69
                    return trend.LadleBubbling;
                case "HMP":                         //ParIndex = 70
                    return trend.HMP;
                case "HMMn":                        //ParIndex = 71
                    return trend.HMMn;
                case "LadleS":                      //ParIndex = 72
                    return trend.LadleS;
                case "LadleP":                      //ParIndex = 73
                    return trend.LadleP;
                case "LadleN":                      //ParIndex = 74
                    return trend.LadleN;
                case "TunC":                        //ParIndex = 75
                    return trend.TunC;
                case "TunS":                        //ParIndex = 76
                    return trend.TunS;
                case "TunP":                        //ParIndex = 77
                    return trend.TunP;
                case "TunN":                        //ParIndex = 78
                    return trend.TunN;
                case "TunAlSol":                    //ParIndex = 79
                    return trend.TunAlSol;
                case "SSHydris":
                    return trend.SSHydris;
                case "SteelSkullWeight":            //ParIndex = 80
                    return trend.SteelSkullWeight;
                case "TundishSkullWeight":          //ParIndex = 81
                    return trend.TundishSkullWeight;
                case "Dart":
                    return trend.Dart;
                case "PrimaryYield":
                    return trend.PrimaryYield;
                case "LadleScheduleIndex":
                    return trend.LadleScheduleIndex;
                case "TPVPressure":
                    return trend.TPVPressure;
                case "HeavySlopDuration":
                    return trend.HeavySlopDuration;
                case "HeavySlopCount":
                    return trend.HeavySlopCount;
                case "COProduct":
                    return trend.COProduct;
                case "SecN2Pickup":
                    return trend.SecN2Pickup;
                case "Al203":
                    return trend.Al203;
                case "MgO":
                    return trend.MgO;
                //Add New Columns Here if needed.
                default:
                    return 0;
            }
        }
    }

    #region Supporting Classes

    /// <summary>
    /// Holds all of the Trending Data for easier
    /// creation of the graphs.
    /// ** Add new Properties here if any columns are added to database. **
    /// ** See also Method GetValueForCorrectParameter in Trending.cs. ****
    /// </summary>
    public class TrendData
    {
        public int TrendSampleIndex { get; set; }

        public int? HeatNumber { get; set; }

        public int? HNS { get; set; }

        /// <summary>
        /// Table Name: TrendDataAdditions
        /// </summary>
        public float? WobWeight { get; set; }           //ParIndex = 17

        public float? DolofluxWeight { get; set; }      //ParIndex = 18

        public float? OreWeight { get; set; }           //ParIndex = 19

        public float? LimeWeight { get; set; }          //ParIndex = 31

        public float? DolometWeight { get; set; }       //ParIndex = 32

        public float? DeSTotalMgWeight { get; set; }    //ParIndex = 51

        public float? HotMetalWeight { get; set; }      //ParIndex = 60

        public float? ScrapWeight { get; set; }         //ParIndex = 61

        public float? SecScrapWeight { get; set; }      //ParIndex = 66

        public float? SteelSkullWeight { get; set; }    //ParIndex = 80

        /// <summary>
        /// Table Name: TrendDataAnalysis
        /// </summary>
        public float? HMSi { get; set; }        //ParIndex = 15

        public float? Basicity { get; set; }    //ParIndex = 29

        public float? CaO { get; set; }         //ParIndex = 27

        public float? SiO2 { get; set; }        //ParIndex = 28

        public float? TotalFe { get; set; }     //ParIndex = 52

        public float? EBPhos { get; set; }      //ParIndex = 53

        public float? HMS { get; set; }         //ParIndex = 54

        public float? N2Pickup { get; set; }    //ParIndex = 63

        public float? HMP { get; set; }         //ParIndex = 70

        public float? HMMn { get; set; }        //ParIndex = 71

        public float? LadleS { get; set; }      //ParIndex = 72

        public float? LadleP { get; set; }      //ParIndex = 73

        public float? LadleN { get; set; }      //ParIndex = 74

        public float? TunC { get; set; }        //ParIndex = 75

        public float? TunS { get; set; }        //ParIndex = 76

        public float? TunP { get; set; }        //ParIndex = 77

        public float? TunN { get; set; }        //ParIndex = 78

        public float? TunAlSol { get; set; }    //ParIndex = 79

        public float? SSHydris { get; set; }
        
        public float? SecN2Pickup { get; set; }

        public float? Al203 { get; set; }

        public float? MgO { get; set; }
         


        /// <summary>
        /// Table Name: TrendDataProcess
        /// </summary>
        public float? HMDesSkimLoss { get; set; }       //ParIndex = 30

        public float? TapWeightError { get; set; }      //ParIndex = 33

        public float? LadleReturnWeight { get; set; }   //ParIndex = 34

        public float? HMLiquidRatio { get; set; }       //ParIndex = 35

        public float? EBTempVar { get; set; }           //ParIndex = 20

        public float? EBCoolReq { get; set; }           //ParIndex = 23

        public float? EBCoolAdd { get; set; }           //ParIndex = 24

        public float? EBOXYDiff { get; set; }           //ParIndex = 25

        public float? LadleTempVar { get; set; }        //ParIndex = 36

        public float? ReHeat { get; set; }              //ParIndex = 26

        public float? SlagDepth { get; set; }           //ParIndex = 37

        public float? Freeboard { get; set; }           //ParIndex = 38

        public float? CCStartWeight { get; set; }       //ParIndex = 39

        public float? CCEndWeight { get; set; }         //ParIndex = 40

        public float? TapWeightActual { get; set; }     //ParIndex = 41

        public float? TapWeightPred { get; set; }       //ParIndex = 42

        public float? TapAdditions { get; set; }        //ParIndex = 43

        public float? VesselSlop { get; set; }          //ParIndex = 55

        public float? CastRate { get; set; }            //ParIndex = 62

        public float? CastingSpeed { get; set; }        //ParIndex = 64

        public float? TundishWeight { get; set; }       //ParIndex = 65

        public float? LadleLiningTemp { get; set; }     //ParIndex = 67

        public float? UpOnMetal { get; set; }           //ParIndex = 68

        public float? LadleBubbling { get; set; }       //ParIndex = 69

        public float? TundishSkullWeight { get; set; }  //ParIndex = 81

        public float? Dart { get; set; }

        public float? PrimaryYield { get; set; }

        public float? LadleScheduleIndex { get; set; }

        public float? TPVPressure { get; set; }

        public float? HeavySlopDuration { get; set; }

        public float? HeavySlopCount { get; set; }

        public float? COProduct { get; set; }

        /// <summary>
        /// Table Name: TrendDataTemps
        /// </summary>
        public float? HMTemp { get; set; }          //ParIndex = 16

        public float? ActEBTemp { get; set; }       //ParIndex = 21

        public float? AimEBTemp { get; set; }       //ParIndex = 22

        public float? AimLadleTemp { get; set; }    //ParIndex = 44

        public float? ActLadleTemp { get; set; }    //ParIndex = 45

        public float? AimReleaseTemp { get; set; }  //ParIndex = 57

        public float? ActReleaseTemp { get; set; }  //ParIndex = 58

        public float? ReleaseTempDev { get; set; }  //ParIndex = 59

        /// <summary>
        /// Table Name: TrendDataTimes
        /// </summary>
        public float? VesselCycleTime { get; set; }             //ParIndex = 1

        public float? VesselCycleTimeSameVessel { get; set; }   //ParIndex = 2

        public float? ChargeToBlowTime { get; set; }            //ParIndex = 3

        public float? BlowingTime { get; set; }                 //ParIndex = 4

        public float? BlowToTapTime { get; set; }               //ParIndex = 5

        public float? TappingTime { get; set; }                 //ParIndex = 6

        public float? TapToChargeTime { get; set; }             //ParIndex = 7

        public float? PlannedDwellTime { get; set; }            //ParIndex = 8

        public float? ActDwellTime { get; set; }                //ParIndex = 9

        public float? WaitingTime { get; set; }                 //ParIndex = 10

        public float? TreatmentTime { get; set; }               //ParIndex = 11

        public float? FloatationTime { get; set; }              //ParIndex = 12

        public float? LadleTurnTime { get; set; }               //ParIndex = 13

        public float? DeSStartToInject { get; set; }            //ParIndex = 46

        public float? DeSInjectionTime { get; set; }            //ParIndex = 47

        public float? DeSInjectToRabble { get; set; }           //ParIndex = 48

        public float? DeSRabbleTime { get; set; }               //ParIndex = 49

        public float? DeSRabbleToEnd { get; set; }              //ParIndex = 50

        public float? DeSTotalTime { get; set; }                //ParIndex = 56
    }

    #endregion Supporting Classes
}
