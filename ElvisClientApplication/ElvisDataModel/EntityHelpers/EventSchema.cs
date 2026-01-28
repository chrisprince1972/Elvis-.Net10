using System;
using System.Collections.Generic;
using System.Linq;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        // IMPORTANT:
        // EventSchemaEntities expects an *Entity Framework entity connection string* (metadata=...csdl|ssdl|msl).
        // Passing ElvisDBSettings.ConnectionString (provider/SqlConnection string) causes:
        // "A minimum of one .ssdl artifact must be supplied."
        private static EventSchemaEntities CreateEventSchemaContext()
        {
            // legacy (do not delete):
            // return new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString);

            // Use config-backed entity connection string (metadata=...) via the parameterless ctor.
            return new EventSchemaEntities();
        }

        #region Additions Table Functions
        public static class Additions
        {
            /// <summary>
            /// Gets a list of the latest ScrapDemand records per heat.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set.</param>
            /// <param name="heatNumber">The heat number.</param>
            /// <returns>A list of ScrapDemand objects.</returns>
            public static List<ElvisDataModel.EDMX.Addition> GetByHeatNumber(
                int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.Additions
                        .Where(s =>
                            s.HNS == heatNumberSet &&
                            s.HeatNumber == heatNumber)
                        .OrderByDescending(s => s.TimeCreated)
                        .ToList();
                }
            }
        }
        #endregion

        #region Analysis Table Functions
        public static class Analysis
        {
            /// <summary>
            /// Gets a list of the latest Analysis records per heat.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set.</param>
            /// <param name="heatNumber">The heat number.</param>
            /// <returns>A list of Analysis objects.</returns>
            public static List<EDMX.Analysis> GetByHeat(
                int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.Analyses
                        .Where(s =>
                            s.HNS == heatNumberSet &&
                            s.HeatNumber == heatNumber)
                        .OrderByDescending(s => s.TimeCreated)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets an analysis record by heat and material code.
            /// NB: This method can return null if record not found.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set.</param>
            /// <param name="heatNumber">The heat number.</param>
            /// <returns>An Analysis object or null if record not found.</returns>
            public static EDMX.Analysis GetByHeatAndMaterialCode(
                int heatNumber, int heatNumberSet, int materialCode)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.Analyses
                        .Where(s =>
                            s.HNS == heatNumberSet &&
                            s.HeatNumber == heatNumber &&
                            s.MaterialCode == materialCode)
                        .OrderByDescending(s => s.TimeCreated)
                        .FirstOrDefault();
                }
            }
        }
        #endregion

        #region CoordLink View Functions
        public static class CoordLink
        {
            /// <summary>
            /// VIEW - Get Latest Coord Link Data from Elvis DB.
            /// </summary>
            /// <returns>List of CoordLink Objects</returns>
            public static List<ElvisDataModel.EDMX.CoordLink> GetAll()
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.CoordLinks.OrderBy(c => c.HEAT_NUMBER).ToList();
                }
            }
        }
        #endregion

        #region CoordLinkFull Functions
        public static class CoordLinkFull
        {
            /// <summary>
            /// Get Coord Link Full Data from Elvis DB by Heat Number.
            /// </summary>
            /// <param name="heatNumber">Heat Number</param>
            /// <returns>List of CoordLinkFull Objects</returns>
            public static List<ElvisDataModel.EDMX.CoordLinkFull> GetByHeat(int heatNo, int heatNoSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.CoordLinkFulls
                            .Where(c =>
                                c.HEAT_NUMBER == heatNo &&
                                c.HNS == heatNoSet)
                            .OrderByDescending(c => c.UPDATE_TIME)
                            .ToList();
                }
            }

            /// <summary>
            /// Gets Coord Link data for the last X days.
            /// </summary>
            /// <returns>List of CoordLinkFull Objects.</returns>
            public static List<ElvisDataModel.EDMX.CoordLinkFull> GetLastXDays(int xDays)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.CoordLinkFulls
                        .Where(p => p.TimeStamp >= dtXDaysAgo)
                        .ToList();
                }
            }
        }
        #endregion

        #region CoordLock Table Functions
        public static class CoordLock
        {
            /// <summary>
            /// Gets a Record from CoordLock data for a heat.
            /// </summary>
            /// <param name="heatNumber">Heat Number</param>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <returns>A CoordLock Object.</returns>
            public static ElvisDataModel.EDMX.CoordLock GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.CoordLocks.FirstOrDefault(c =>
                                c.HEAT_NUMBER == heatNumber &&
                                c.HNS == heatNumberSet);
                }
            }
        }
        #endregion

        #region DesulphSkimPercentage Table Functions
        public static class DesulphSkimPercentage
        {
            /// <summary>
            /// Gets a List of DesulphSkimPercentage from the database
            /// for a specific heat.
            /// </summary>
            /// <param name="heatNumber">Heat Number</param>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <returns>A List of DesulphSkimPercentage Objects.</returns>
            public static List<EDMX.DesulphSkimPercentage> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.DesulphSkimPercentages
                        .Where(c =>
                            c.HeatNumber == heatNumber &&
                            c.HNS == heatNumberSet)
                        .ToList();
                }
            }
        }
        #endregion

        #region DipResult Table Functions
        public static class DipResult
        {
            public enum DipType : int
            {
                Temperature = 1,
                Sulphox,
                Tundish,
                Secondary,
                TSO,
                Celox,
                HotMetal,
                Unknown,
                Tap,
                Hydris,
                TSC
            }

            /// <summary>
            /// Gets dip results by heat numbers.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set.</param>
            /// <param name="heatNumber">The heat number.</param>
            /// <returns>A list of dip result objects.</returns>
            public static List<EDMX.DipResult> GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.DipResults
                        .Where(dr =>
                            dr.HNS == heatNumberSet &&
                            dr.HeatNumber == heatNumber)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets dip results by heat number and dip type.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set.</param>
            /// <param name="heatNumber">The heat number.</param>
            /// <param name="dipTypes">List of the enum of the dip types to return.</param>
            /// <returns>A list of dip result objects.</returns>
            public static List<EDMX.DipResult> GetByHeatDipTypeList(int heatNumber,
                int heatNumberSet, List<DipType> dipTypes)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    List<int> dipTypesAsInt = new List<int>();

                    dipTypes.ForEach(r => dipTypesAsInt.Add((int)r));

                    return ctx.DipResults
                        .Where(r =>
                            r.HNS == heatNumberSet &&
                            r.HeatNumber == heatNumber &&
                            dipTypesAsInt.Contains(r.DipType))
                        .OrderBy(r => r.TimeStampGMT)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets temperature for heats dip type.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set.</param>
            /// <param name="heatNumber">The heat number.</param>
            /// <param name="dipType">Enumerator of the dip type to return.</param>
            /// <returns>The temperature of a dip for a heat.</returns>
            public static float? GetHeatsTemperatureByDipType(int heatNumber, int heatNumberSet, DipType dipType)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    float? returnValue = null;

                    EDMX.DipResult record = ctx.DipResults
                        .Where(r =>
                            r.HNS == heatNumberSet &&
                            r.HeatNumber == heatNumber &&
                            r.DipType == (int)dipType)
                        .FirstOrDefault();

                    if (record != null)
                    {
                        returnValue = record.Temperature;
                    }

                    return returnValue;
                }
            }
        }
        #endregion

        #region HeatAimAnalysis Table Functions
        public static class HeatAimAnalysis
        {
            /// <summary>
            /// Gets a Heat Aim Analysis record by heat number.
            /// </summary>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <param name="heatNumber">Heat Number</param>
            /// <returns>A HeatAimAnalysi object.</returns>
            public static EDMX.HeatAimAnalysi GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.HeatAimAnalysis
                        .FirstOrDefault(g =>
                            g.HeatNumber == heatNumber &&
                            g.HNS == heatNumberSet &&
                            g.Type == 0 &&       //0 is AIM
                            g.UnitNumber == 99); //99 is CASTER
                }
            }
        }
        #endregion

        #region HeatAimGeneral Table Functions
        public static class HeatAimGeneral
        {
            /// <summary>
            /// Gets a Heat Aim General record by heat number.
            /// </summary>
            /// <param name="heatNumber">Heat Number</param>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <returns>A HeatAimGrades object.</returns>
            public static EDMX.HeatAimGeneral GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.HeatAimGenerals
                        .FirstOrDefault(g =>
                            g.HeatNumber == heatNumber &&
                            g.HNS == heatNumberSet
                        );
                }
            }
        }
        #endregion

        #region HeatAimGrades Table Functions
        public static class HeatAimGrades
        {
            /// <summary>
            /// Gets a list of Grades associated with a certain Heat
            /// </summary>
            /// <param name="heatNumber">Heat Number</param>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <returns>A list of HeatAimGrades</returns>
            public static List<HeatAimGrade> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.HeatAimGrades
                        .Where(g =>
                            g.HeatNumber == heatNumber &&
                            g.HNS == heatNumberSet)
                        .ToList();
                }
            }
        }
        #endregion

        #region HeatLog Table Functions
        public static class HeatLog
        {
            /// <summary>
            /// Gets a list of heat log entries related to that Heat.
            /// </summary>
            /// <param name="heatNumber">Heat Number</param>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <returns>List of HeatLog Objects</returns>
            public static List<EDMX.HeatLog> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.HeatLogs
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet)
                        .OrderBy(h => h.TimeStamp)
                        .ToList();
                }
            }

            public static List<EDMX.HeatLog> GetByHeatAndUnit(int heatNumber,
                int heatNumberSet,
                int unitNumber)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.HeatLogs
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet &&
                                t.Unit == unitNumber)
                        .OrderBy(h => h.TimeStamp)
                        .ToList();
                }
            }

            public static List<EDMX.HeatLog> GetByHeatForDesulphPour(int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.HeatLogs
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet &&
                                (t.Unit >= 1 && t.Unit <= 4))
                        .OrderBy(h => h.TimeStamp)
                        .ToList();
                }
            }

            public static DateTime? GetTapTimeByHeat(int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    ElvisDataModel.EDMX.HeatLog hl = ctx.HeatLogs
                        .FirstOrDefault(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet &&
                                t.EventType == "Start of Tap");
                    if (hl != null)
                    {
                        return hl.TimeStamp;
                    }
                    return null;
                }
            }

            public static List<ElvisDataModel.EDMX.HeatLog> GetByHeatForVessels(
                int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.HeatLogs
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet &&
                                (t.Unit == 5 || t.Unit == 6)) // 5 and 6 are Vessel 1 and 2
                        .OrderBy(h => h.TimeStamp)
                        .ToList();
                }
            }
        }
        #endregion

        #region HM Stocks Table Functions
        public static class HMStocks
        {
            public static List<HM_Stocks> GetHMStocksForPeriod(DateTime startDate, DateTime endDate)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.HM_Stocks
                        .Where(h => h.DATE >= startDate && h.DATE <= endDate)
                        .OrderBy(h => h.DATE).ToList();
                }
            }
        }
        #endregion

        #region LastProgramNumber View Functions
        public static class LastProgramNumber
        {
            public static List<EDMX.LastProgramNumber> GetByDateRange(DateTime dateFrom, DateTime dateTo)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    dateFrom = dateFrom.AddHours(-12);
                    dateTo = dateTo.AddHours(13);
                    return ctx.LastProgramNumbers
                        .Where(l => l.TimeCreated >= dateFrom && l.TimeCreated <= dateTo)
                        .OrderBy(d => d.TimeCreated)
                        .ToList();
                }
            }
        }
        #endregion

        #region ManInputDay Table Functions
        public static class ManInputDay
        {
            public static EDMX.ManInputDay GetByDate(DateTime date)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.ManInputDays.FirstOrDefault(m => m.DayDate == date);
                }
            }

            public static void InsertNew(EDMX.ManInputDay manInput)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    ctx.AddToManInputDays(manInput);
                    ctx.SaveChanges();
                }
            }

            public static string UpdateExisting(EDMX.ManInputDay manInputNewValues)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    EDMX.ManInputDay manInput = ctx.ManInputDays.FirstOrDefault(t =>
                        t.DayDate == manInputNewValues.DayDate);

                    if (manInput != null)
                    {
                        manInput.DayDate = manInputNewValues.DayDate;
                        manInput.BFOutput = manInputNewValues.BFOutput;
                        manInput.OPPracticeIndex = manInputNewValues.OPPracticeIndex;

                        ctx.SaveChanges();
                        return "";
                    }
                    return "Record not found!";
                }
            }

            public static List<EDMX.ManInputDay> GetLast7Days()
            {
                DateTime date = DateTime.Now.AddDays(-7);
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.ManInputDays
                        .Where(m => m.DayDate >= date)
                        .OrderByDescending(m => m.DayDate)
                        .ToList();
                }
            }

            public static EDMX.ManInputDay GetByIndex(int dayDateIndex)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.ManInputDays.FirstOrDefault(d => d.DayDateIndex == dayDateIndex);
                }
            }
        }
        #endregion

        #region ProgramHistory Table Functions
        public static class ProgramHistory
        {
            public static List<ElvisDataModel.EDMX.ProgramHistory> GetLastXDays(int xDays)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.ProgramHistories
                        .Where(p => p.TimeCreated >= dtXDaysAgo)
                        .ToList();
                }
            }
        }
        #endregion

        #region ScrapBoxLoad Events Table Functions
        public static class ScrapBoxLoad
        {
            public static EDMX.ScrapBoxLoad GetByHeatNumber(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.ScrapBoxLoads
                        .FirstOrDefault(s =>
                            s.HNS == heatNumberSet &&
                            s.HeatNumber == heatNumber
                        );
                }
            }
        }
        #endregion

        #region ScrapBoxStatusEvent Events Table Functions
        public static class ScrapBoxStatusEvent
        {
            public static List<EDMX.ScrapBoxStatusEvent> GetByHeatNumber(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.ScrapBoxStatusEvents
                        .Where(s =>
                            s.HNS == heatNumberSet &&
                            s.HeatNumber == heatNumber)
                        .OrderBy(s => s.ScrapEventTimeStamp)
                        .ToList();
                }
            }
        }
        #endregion

        #region ScrapDemand Table Functions
        public static class ScrapDemand
        {
            public static List<EDMX.ScrapDemand> GetByHeatNumber(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    List<EDMX.ScrapDemand> demands = ctx.ScrapDemands
                        .Where(s =>
                            s.HNS == heatNumberSet &&
                            s.HeatNumber == heatNumber)
                        .ToList();

                    if (demands != null && demands.Count > 0)
                    {
                        DateTime dtLatest = demands.Max(s => s.TimeStamp);

                        return demands
                            .Where(s => s.TimeStamp == dtLatest)
                            .ToList();
                    }
                    return new List<EDMX.ScrapDemand>();
                }
            }
        }
        #endregion

        #region TapWeights Table Functions
        public static class TapWeights
        {
            public static List<EDMX.TapWeight> GetLastXDays(int xDays)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.TapWeights
                        .Where(p => p.EventTime >= dtXDaysAgo)
                        .ToList();
                }
            }

            public static List<EDMX.TapWeight> GetByDateRange(DateTime dateFrom, DateTime dateTo)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    dateFrom = dateFrom.AddHours(-12);
                    dateTo = dateTo.AddHours(13);
                    return ctx.TapWeights
                        .Where(l => l.EventTime >= dateFrom && l.EventTime <= dateTo)
                        .OrderBy(d => d.EventTime)
                        .ToList();
                }
            }
        }
        #endregion

        #region Torpedo Table Functions
        public static class Torpedo
        {
            public static List<EDMX.Torpedo> GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.Torpedoes
                        .Where(t =>
                            t.HNS == heatNumberSet
                            && t.HeatNumber == heatNumber)
                        .OrderBy(t => t.PourStationTimeGMT)
                        .ToList();
                }
            }

            public static float? GetTotalPouredWeightOfHeat(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.Torpedoes
                        .Where(t =>
                            t.HNS == heatNumberSet
                            && t.HeatNumber == heatNumber)
                        .Sum(r => r.TotalPouredWeight);
                }
            }
        }
        #endregion

        #region TIBDelays
        public static class TIBDelays
        {
            public static TIBDelay GetSingle(int tibDelayIndex)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.TIBDelays.FirstOrDefault(t =>
                        t.TibDelayIndex == tibDelayIndex);
                }
            }

            public static TIBDelay GetSingle(int tibIndex, int delayNo)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.TIBDelays.FirstOrDefault(t =>
                        t.TibIndex == tibIndex &&
                        t.DelayNumber == delayNo);
                }
            }

            public static List<TIBDelay> GetLastXDays(int xDays)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.TIBDelays
                        .Where(p => p.DelayStart >= dtXDaysAgo)
                        .OrderBy(o => o.DelayNumber)
                        .ToList();
                }
            }

            public static List<TIBDelay> GetByDateRange(DateTime dateFrom, DateTime dateTo)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    dateFrom = dateFrom.AddHours(-12);
                    dateTo = dateTo.AddHours(13);
                    return ctx.TIBDelays.Where(d =>
                            (d.DelayStart >= dateFrom && d.DelayEnd < dateTo ||
                            (d.DelayStart >= dateFrom && d.DelayEnd == null &&
                                d.DelayStart < dateTo)))
                        .ToList();
                }
            }

            public static List<TIBDelay> GetByTibEventIndex(int tibIndex)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.TIBDelays
                        .Where(t => t.TibIndex == tibIndex)
                        .OrderBy(d => d.DelayNumber)
                        .ToList();
                }
            }

            public static void AddNew(TIBDelay tibDelayToAdd)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    ctx.AddToTIBDelays(tibDelayToAdd);
                    ctx.SaveChanges();
                }
            }

            public static bool EditExisting(TIBDelay tibDelayNewValues)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    TIBDelay tibDelay = ctx.TIBDelays.FirstOrDefault(t =>
                        t.TibIndex == tibDelayNewValues.TibIndex &&
                        t.DelayNumber == tibDelayNewValues.DelayNumber);

                    if (tibDelay != null)
                    {
                        tibDelay.DelayStart = tibDelayNewValues.DelayStart;
                        tibDelay.DelayEnd = tibDelayNewValues.DelayEnd;
                        tibDelay.DelayDuration = tibDelayNewValues.DelayDuration;
                        tibDelay.PlantArea = tibDelayNewValues.PlantArea;
                        tibDelay.DelayReason1 = tibDelayNewValues.DelayReason1;
                        tibDelay.DelayReason2 = tibDelayNewValues.DelayReason2;
                        tibDelay.DelayReason3 = tibDelayNewValues.DelayReason3;
                        tibDelay.DelayReason4 = tibDelayNewValues.DelayReason4;
                        tibDelay.UnitGroup = tibDelayNewValues.UnitGroup;
                        tibDelay.DelayClass = tibDelayNewValues.DelayClass;
                        tibDelay.Category = tibDelayNewValues.Category;
                        tibDelay.Discipline = tibDelayNewValues.Discipline;
                        tibDelay.Comment = tibDelayNewValues.Comment;
                        tibDelay.UserName = tibDelayNewValues.UserName;
                        tibDelay.MachineName = tibDelayNewValues.MachineName;
                        tibDelay.OEECategory = tibDelayNewValues.OEECategory;
                        tibDelay.LossType = tibDelayNewValues.LossType;
                        tibDelay.Owner = tibDelayNewValues.Owner;
                        tibDelay.ReportingTextLevel1 = tibDelayNewValues.ReportingTextLevel1;
                        tibDelay.ReportingTextLevel2 = tibDelayNewValues.ReportingTextLevel2;
                        tibDelay.ObjectDescription = tibDelayNewValues.ObjectDescription;
                        tibDelay.ObjectCode = tibDelayNewValues.ObjectCode;
                        tibDelay.DamageDescription = tibDelayNewValues.DamageDescription;
                        tibDelay.DamageCode = tibDelayNewValues.DamageCode;
                        tibDelay.DeviationType = tibDelayNewValues.DeviationType;
                        tibDelay.CauseText = tibDelayNewValues.CauseText;
                        tibDelay.Section = tibDelayNewValues.Section;
                        tibDelay.ExternalInternal = tibDelayNewValues.ExternalInternal;
                        tibDelay.SupplierDownStream = tibDelayNewValues.SupplierDownStream;
                        tibDelay.NoExtraWork = tibDelayNewValues.NoExtraWork;
                        tibDelay.FlocDescriptionL3 = tibDelayNewValues.FlocDescriptionL3;
                        tibDelay.FlocNumberL3 = tibDelayNewValues.FlocNumberL3;
                        tibDelay.FlocDescriptionL4 = tibDelayNewValues.FlocDescriptionL4;
                        tibDelay.FlocNumberL4 = tibDelayNewValues.FlocNumberL4;
                        tibDelay.FlocDescriptionL5 = tibDelayNewValues.FlocDescriptionL5;
                        tibDelay.FlocNumberL5 = tibDelayNewValues.FlocNumberL5;
                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }

            public static void ChangeOrder(int tibIndex, int oldDelayNo, bool moveUp)
            {
                int newDelayNo = oldDelayNo;

                if (moveUp)
                    newDelayNo--;
                else
                    newDelayNo++;

                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    int tempDelayNo = ctx.TIBDelays.OrderByDescending(t =>
                        t.DelayNumber)
                            .FirstOrDefault(t =>
                                t.TibIndex == tibIndex).DelayNumber + 1;

                    TIBDelay tibDelay = ctx.TIBDelays.FirstOrDefault(t =>
                        t.TibIndex == tibIndex &&
                        t.DelayNumber == oldDelayNo);

                    if (tibDelay != null)
                    {
                        tibDelay.DelayNumber = tempDelayNo;
                        ctx.SaveChanges();

                        TIBDelay moveTibDelay = ctx.TIBDelays.FirstOrDefault(t =>
                            t.TibIndex == tibIndex &&
                            t.DelayNumber == newDelayNo);

                        if (moveTibDelay != null)
                        {
                            if (moveUp)
                            {
                                DateTime? start = moveTibDelay.DelayStart;
                                DateTime? end = start.Value.AddMinutes(
                                    Convert.ToInt16(tibDelay.DelayDuration));

                                moveTibDelay.DelayStart = end;
                                moveTibDelay.DelayEnd = moveTibDelay.DelayStart.Value.AddMinutes(
                                    Convert.ToInt16(moveTibDelay.DelayDuration));

                                tibDelay.DelayStart = start;
                                tibDelay.DelayEnd = end;
                            }
                            else
                            {
                                DateTime? start = tibDelay.DelayStart;
                                DateTime? end = start.Value.AddMinutes(
                                    Convert.ToInt16(moveTibDelay.DelayDuration));

                                tibDelay.DelayStart = end;
                                tibDelay.DelayEnd = tibDelay.DelayStart.Value.AddMinutes(
                                    Convert.ToInt16(tibDelay.DelayDuration));

                                moveTibDelay.DelayStart = start;
                                moveTibDelay.DelayEnd = end;
                            }
                            moveTibDelay.DelayNumber = oldDelayNo;
                            ctx.SaveChanges();
                            tibDelay.DelayNumber = newDelayNo;
                            ctx.SaveChanges();
                        }
                    }
                }
            }

            public static void DeleteRecord(TIBDelay tibDelay, DateTime tibEventStart)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    TIBDelay delayToDelete = ctx.TIBDelays.FirstOrDefault(t =>
                        t.TibDelayIndex == tibDelay.TibDelayIndex);

                    if (delayToDelete != null)
                    {
                        ctx.TIBDelays.DeleteObject(delayToDelete);
                        ctx.SaveChanges();

                        List<TIBDelay> delaysToMod = ctx.TIBDelays
                            .Where(t => t.TibIndex == tibDelay.TibIndex)
                            .OrderBy(t => t.DelayNumber)
                            .ToList();

                        int delayNumber = 1;
                        DateTime delayStart = tibEventStart;
                        foreach (TIBDelay delay in delaysToMod)
                        {
                            delay.DelayNumber = delayNumber;
                            delay.DelayStart = delayStart;
                            delay.DelayEnd = delayStart.AddMinutes(
                                Convert.ToInt16(delay.DelayDuration));

                            delayStart = delay.DelayEnd.Value;
                            delayNumber++;
                        }
                        ctx.SaveChanges();
                    }
                }
            }
        }
        #endregion

        #region TIBDelaysView View Functions
        public static class TIBDelaysView
        {
            public static List<ElvisDataModel.EDMX.TIBDelaysView> GetByTibEvent(int tibIndex)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.TIBDelaysViews
                        .Where(t => t.TibIndex == tibIndex)
                        .OrderBy(t => t.DelayNumber)
                        .ToList();
                }
            }

            public static ElvisDataModel.EDMX.TIBDelaysView GetByTibDelayIndex(int index)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx
                        .TIBDelaysViews
                        .FirstOrDefault(t => t.TibDelayIndex == index);
                }
            }
        }
        #endregion

        #region TIBEvents Table Functions
        public static class TIBEvents
        {
            public static List<TIBEvent> GetLastXDays(int xDays)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.TIBEvents
                        .Where(p => p.EventStart >= dtXDaysAgo)
                        .OrderByDescending(o => o.EventStart)
                        .ToList();
                }
            }

            public static TIBEvent GetSingle(int tibIndex)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.TIBEvents.FirstOrDefault(t =>
                                    t.TibIndex == tibIndex);
                }
            }

            public static int? GetLengthInMinutes(int tibIndex)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    TIBEvent tibEvent
                        = ctx
                        .TIBEvents
                        .FirstOrDefault
                        (t =>
                            t.TibIndex == tibIndex
                        );

                    int? lengthInMinutes = null;
                    if (tibEvent != null)
                    {
                        if (tibEvent.EventEnd.HasValue)
                        {
                            lengthInMinutes = tibEvent.TibDuration;
                        }
                        else
                        {
                            if (tibEvent.EventStart.HasValue)
                            {
                                TimeSpan ts = DateTime.Now - tibEvent.EventStart.Value;
                                lengthInMinutes = new int?((int)Math.Round(ts.TotalMinutes));
                            }
                        }
                    }

                    return lengthInMinutes;
                }
            }

            public static string GetUnitText(int tibIndex)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    TIBEvent tibEvent
                        = ctx
                        .TIBEvents
                        .FirstOrDefault
                        (t =>
                            t.TibIndex == tibIndex
                        );

                    string unitText = String.Empty;
                    if (tibEvent != null)
                    {
                        unitText = Units.GetText(tibEvent.UnitNumber);
                    }

                    return unitText;
                }
            }

            public static List<TIBEvent> GetByDateRange(DateTime dateFrom, DateTime dateTo)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    dateFrom = dateFrom.AddHours(-12);
                    dateTo = dateTo.AddHours(13);
                    return ctx.TIBEvents.Where(d =>
                            (d.EventStart >= dateFrom && d.EventEnd < dateTo ||
                            (d.EventStart >= dateFrom && d.EventEnd == null &&
                                d.EventStart < dateTo)))
                        .ToList();
                }
            }

            public static List<TIBEvent> GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.TIBEvents.Where(r =>
                            r.HNS == heatNumberSet &&
                            r.HeatNumber == heatNumber)
                        .ToList();
                }
            }

            public static TIBEvent GetNextEventForUnit(int tibIndex, int unitNumber)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.TIBEvents.FirstOrDefault(e => e.UnitNumber == unitNumber
                        && e.TibIndex > tibIndex);
                }
            }

            public static TIBEvent GetNextEventForUnitGroup(int tibIndex, int unitGroupNumber)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.TIBEvents.FirstOrDefault(e => e.UnitNumber == unitGroupNumber
                        && e.TibIndex > tibIndex);
                }
            }

            public static List<TIBEvent> GetByDateRangeForUnit(DateTime dateFrom, DateTime dateTo, int unitNumber)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    dateFrom = dateFrom.AddHours(-12);
                    dateTo = dateTo.AddHours(13);
                    return ctx.TIBEvents.Where(d => d.UnitNumber == unitNumber
                            && (d.EventStart >= dateFrom && d.EventEnd < dateTo ||
                            (d.EventStart >= dateFrom && d.EventEnd == null &&
                                d.EventStart < dateTo)))
                        .ToList();
                }
            }

            public static List<TIBEvent> GetByDateRangeForUnitGroup(DateTime dateFrom, DateTime dateTo, int unitGroupNumber)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    dateFrom = dateFrom.AddHours(-12);
                    dateTo = dateTo.AddHours(13);
                    return ctx.TIBEvents.Where(d => d.UnitGroup == unitGroupNumber
                            && (d.EventStart >= dateFrom && d.EventEnd < dateTo ||
                            (d.EventStart >= dateFrom && d.EventEnd == null &&
                                d.EventStart < dateTo)))
                        .ToList();
                }
            }
        }
        #endregion

        #region Tracking Table Functions
        public static class Tracking
        {
            public static ElvisDataModel.EDMX.Tracking GetSingleCasterEvent(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.Trackings.FirstOrDefault(t =>
                            t.HeatNumber == heatNumber &&
                            t.HNS == heatNumberSet &&
                                (
                                    t.UnitNumber == 13 ||
                                    t.UnitNumber == 12 ||
                                    t.UnitNumber == 11
                                )
                        );
                }
            }

            public static List<ElvisDataModel.EDMX.Tracking> GetLastXDays(int xDays)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.Trackings
                        .Where(p => p.TimeStampStart >= dtXDaysAgo)
                        .OrderByDescending(o => o.TimeStampStart)
                        .ToList();
                }
            }

            public static int GetLatestHNS()
            {
                //using (EventSchemaEntities ctx = CreateEventSchemaContext())
                //{
                //    return ctx.Trackings.FirstOrDefault(
                //        t => t.HNS == ElvisDbFunctions.GetHNS()).HNS;
                //}
                return 4;
            }

            public static int GetHNSFromHeatNumber(int heatNumber)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    ElvisDataModel.EDMX.Tracking eventData = ctx.Trackings
                        .OrderByDescending(t => t.TrackIndex)
                        .FirstOrDefault(t => t.HeatNumber == heatNumber);
                    if (eventData != null)
                    {
                        return eventData.HNS;
                    }
                }
                return 0;
            }
        }
        #endregion

        #region Treatment Tracking Table Functions
        public static class TreatmentTracking
        {
            public static List<ElvisDataModel.EDMX.TreatmentTracking> GetByDateRange(
                DateTime dateFrom,
                DateTime dateTo)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.TreatmentTrackings
                        .Where(t =>
                            t.TimeStampStart >= dateFrom &&
                            t.TimeStampStart <= dateTo)
                        .ToList();
                }
            }

            public static List<ElvisDataModel.EDMX.TreatmentTracking> GetByHeatNumber(
                int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = CreateEventSchemaContext())
                {
                    return ctx.TreatmentTrackings
                        .Where(t =>
                            t.HeatNumber == heatNumber &&
                            t.HNS == heatNumberSet)
                        .ToList();
                }
            }
        }
        #endregion
    }
}
