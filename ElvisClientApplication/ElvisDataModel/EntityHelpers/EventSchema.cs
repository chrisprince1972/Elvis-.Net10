using System;
using System.Collections.Generic;
using System.Linq;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.HeatLogs
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet)
                        .OrderBy(h => h.TimeStamp)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets a list of heat log entries related to that Heat and Unit
            /// </summary>
            /// <param name="heatNumber">Heat Number</param>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <param name="unitNumber">Unit Number</param>
            /// <returns>List of HeatLog Objects</returns>
            public static List<EDMX.HeatLog> GetByHeatAndUnit(int heatNumber,
                int heatNumberSet,
                int unitNumber)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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

            /// <summary>
            /// Gets a list of heat log entries related to that Heat for either of the desulphurisation units.
            /// Function will return 2 sets of logs if heat visited both of the desulphurisation unit.  However, it will return null if not but this should be a rare case.
            /// </summary>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <param name="heatNumber">Heat Number</param>
            /// <returns>Null or a list of HeatLog Objects</returns>
            public static List<EDMX.HeatLog> GetByHeatForDesulphPour(int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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

            /// <summary>
            /// Get Start Tap Time by Heat
            /// </summary>
            /// <param name="heatNumber">Heat Number</param>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <returns>DateTime containing the start tap time for that heat.</returns>
            public static DateTime? GetTapTimeByHeat(int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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

            /// <summary>
            /// Gets a list of heat logs by heat for the vessels.
            /// </summary>
            /// <param name="heatNumber">Heat Number</param>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <returns>List of HeatLog Objects</returns>
            public static List<ElvisDataModel.EDMX.HeatLog> GetByHeatForVessels(
                int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
            /// <summary>
            /// Returns HM Stocks for the given period.
            /// </summary>
            /// <param name="startDate">The start of the period</param>
            /// <param name="endDate">The end of the period</param>
            /// <returns>A collection of HM_STOCK instances</returns>
            public static List<HM_Stocks> GetHMStocksForPeriod(DateTime startDate, DateTime endDate)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
            /// <summary>
            /// VIEW - LastProgramNumber
            /// Gets a list of last program numbers associated with heats
            /// between two dates given.
            /// </summary>
            /// <param name="dateFrom">The Date From</param>
            /// <param name="dateTo">The Date To</param>
            /// <returns>A list of LastProgramNumber objects.</returns>
            public static List<EDMX.LastProgramNumber> GetByDateRange(DateTime dateFrom, DateTime dateTo)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    //Need to modify the dates slightly to ensure we populate the whole scheduler.
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
            /// <summary>
            /// Gets ManInputDay records by a date.
            /// </summary>
            /// <param name="date">The DateTime to get.</param>
            /// <returns>List of ManInputDay Objects.</returns>
            public static EDMX.ManInputDay GetByDate(DateTime date)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.ManInputDays.FirstOrDefault(m => m.DayDate == date);
                }
            }

            /// <summary>
            /// Inserts new ManInputDay record into the database. 
            /// </summary>
            /// <param name="manInput">The ManInputDay to insert.</param>
            /// <returns>String containing any errors.</returns>
            public static void InsertNew(EDMX.ManInputDay manInput)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ctx.AddToManInputDays(manInput);
                    ctx.SaveChanges();
                }
            }

            /// <summary>
            /// Updates existing ManInputDay record in the database. 
            /// </summary>
            /// <param name="manInput">The ManInputDay to insert.</param>
            /// <returns>String containing any errors.</returns>
            public static string UpdateExisting(EDMX.ManInputDay manInputNewValues)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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

            /// <summary>
            /// Gets the last 7 days worth of records.
            /// </summary>
            /// <returns>A list of ManInputDay objects.</returns>
            public static List<EDMX.ManInputDay> GetLast7Days()
            {
                DateTime date = DateTime.Now.AddDays(-7);
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.ManInputDays
                        .Where(m => m.DayDate >= date)
                        .OrderByDescending(m => m.DayDate)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets the ManInputDay record by index.
            /// </summary>
            /// <param name="dayDateIndex">The index to search for.</param>
            /// <returns>A ManInputDay object.</returns>
            public static EDMX.ManInputDay GetByIndex(int dayDateIndex)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.ManInputDays.FirstOrDefault(d => d.DayDateIndex == dayDateIndex);
                }
            }
        }
        #endregion

        #region ProgramHistory Table Functions
        public static class ProgramHistory
        {
            /// <summary>
            /// Gets Program History data for the last X days.
            /// </summary>
            /// <returns>List of ProgramHistory Objects.</returns>
            public static List<ElvisDataModel.EDMX.ProgramHistory> GetLastXDays(int xDays)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
            /// <summary>
            /// Returns ScrapBoxLoad for the given heat number set and heat number.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set.</param>
            /// <param name="heatNumber">The heat numbe</param>
            /// <returns>A list of ScrapBoxLoad objects.</returns>
            public static EDMX.ScrapBoxLoad GetByHeatNumber(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
            /// <summary>
            /// Returns ScrapBoxStatusEvent for the given heat number set and heat number.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set.</param>
            /// <param name="heatNumber">The heat numbe</param>
            /// <returns>A list of ScrapBoxStatusEvent objects.</returns>
            public static List<EDMX.ScrapBoxStatusEvent> GetByHeatNumber(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
            /// <summary>
            /// Gets a list of the latest ScrapDemand records per heat.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set.</param>
            /// <param name="heatNumber">The heat number.</param>
            /// <returns>A list of ScrapDemand objects.</returns>
            public static List<EDMX.ScrapDemand> GetByHeatNumber(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    //Get whole list of demands
                    List<EDMX.ScrapDemand> demands = ctx.ScrapDemands
                        .Where(s =>
                            s.HNS == heatNumberSet &&
                            s.HeatNumber == heatNumber)
                        .ToList();
                    if (demands != null && demands.Count > 0)
                    {
                        //Needs to get the latest DateTime value for timestamp
                        //so that we can filter the correct records.
                        DateTime dtLatest = demands
                            .Max(s => s.TimeStamp);

                        //Return only the latest records.
                        return demands
                            .Where(s =>
                                s.TimeStamp == dtLatest)
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
            /// <summary>
            /// Gets Tap Weights data for the last X days.
            /// </summary>
            /// <returns>List of TapWeight Objects.</returns>
            public static List<EDMX.TapWeight> GetLastXDays(int xDays)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.TapWeights
                        .Where(p => p.EventTime >= dtXDaysAgo)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets a list of Tap Weights between two dates given.
            /// </summary>
            /// <param name="dateFrom">The Date From</param>
            /// <param name="dateTo">The Date To</param>
            /// <returns>A list of TapWeight objects.</returns>
            public static List<EDMX.TapWeight> GetByDateRange(DateTime dateFrom, DateTime dateTo)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    //Need to modify the dates slightly to ensure we populate the whole scheduler.
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
            /// <summary>
            /// Gets torpedos by heat numbers.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set.</param>
            /// <param name="heatNumber">The heat number.</param>
            /// <returns>A list of Torpedo objects.</returns>
            public static List<EDMX.Torpedo> GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Torpedoes
                        .Where(t =>
                            t.HNS == heatNumberSet
                            && t.HeatNumber == heatNumber)
                        .OrderBy(t => t.PourStationTimeGMT)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets the total poured weight for the entire heat.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set.</param>
            /// <param name="heatNumber">The heat number.</param>
            /// <returns>Nullable float containing the sum total of the poured weight for the heat.</returns>
            public static float? GetTotalPouredWeightOfHeat(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
            /// <summary>
            /// Gets a specific Tib Delay from the Database by TibDelayIndex
            /// </summary>
            /// <param name="tibDelayIndex">The Tib Delay Index associated with the delay.</param>
            /// <returns>A TIBDelay Database Object.</returns>
            public static TIBDelay GetSingle(int tibDelayIndex)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TIBDelays.FirstOrDefault(t =>
                        t.TibDelayIndex == tibDelayIndex);
                }
            }

            /// <summary>
            /// Gets a specific Tib Delay from the Database by TibIndex and DelayNo.
            /// </summary>
            /// <param name="tibIndex">The Tib Index associated with the delay.</param>
            /// <param name="delayNo">The delay number associated with the delay.</param>
            /// <returns>A TIBDelay Database Object.</returns>
            public static TIBDelay GetSingle(int tibIndex, int delayNo)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TIBDelays.FirstOrDefault(t =>
                        t.TibIndex == tibIndex &&
                        t.DelayNumber == delayNo);
                }
            }

            /// <summary>
            /// Gets a List of Tib Delays from the Database for the last X days.
            /// </summary>
            /// <returns>List of TIBDelays of the last X days.</returns>
            public static List<TIBDelay> GetLastXDays(int xDays)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.TIBDelays
                        .Where(p => p.DelayStart >= dtXDaysAgo)
                        .OrderBy(o => o.DelayNumber)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets the Tib Delays between two dates.
            /// </summary>
            /// <param name="dateFrom">The Date to start from.</param>
            /// <param name="dateTo">The end date.</param>
            /// <returns>A list of Tib Events.</returns>
            public static List<TIBDelay> GetByDateRange(DateTime dateFrom, DateTime dateTo)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    //Need to modify the dates slightly to ensure we populate the whole scheduler.
                    dateFrom = dateFrom.AddHours(-12);
                    dateTo = dateTo.AddHours(13);
                    return ctx.TIBDelays.Where(d =>
                            (d.DelayStart >= dateFrom && d.DelayEnd < dateTo ||
                            (d.DelayStart >= dateFrom && d.DelayEnd == null &&
                                d.DelayStart < dateTo)))
                        .ToList();
                }
            }

            /// <summary>
            /// Gets a List of Tib Delays from the Database for a specific tib event.
            /// </summary>
            /// <returns>List of TIBDelays.</returns>
            public static List<TIBDelay> GetByTibEventIndex(int tibIndex)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TIBDelays
                        .Where(t => t.TibIndex == tibIndex)
                        .OrderBy(d => d.DelayNumber)
                        .ToList();
                }
            }

            /// <summary>
            /// Add new Tib Delay to the Database.
            /// </summary>
            public static void AddNew(TIBDelay tibDelayToAdd)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ctx.AddToTIBDelays(tibDelayToAdd);
                    ctx.SaveChanges();
                }
            }

            /// <summary>
            /// Edit existing Tib Delay in the database.
            /// </summary>
            /// <param name="tibDelayNewValues">The new values to be updating in database.</param>
            /// <returns>Boolean stating success or failure.</returns>
            public static bool EditExisting(TIBDelay tibDelayNewValues)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
                        //2015-08-10 Les added in missing fields so that the entire record is updated
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

            /// <summary>
            /// Edits the order of delays.
            /// Move the delay up or down 1 index in the list.
            /// </summary>
            /// <param name="tibIndex">The Tib Index (Event Index) of the Delay.</param>
            /// <param name="oldDelayNo">The delay number to change.</param>
            /// <param name="moveUp">If true, moves the record up (decreasing the delay number by 1),
            ///     if false moves it down (increasing the delay number by 1).</param>
            /// <returns>True for success, false for failure.</returns>
            public static void ChangeOrder(int tibIndex, int oldDelayNo, bool moveUp)
            {
                int newDelayNo = oldDelayNo;

                if (moveUp)//Up in the order
                    newDelayNo--;
                else//Down in the order
                    newDelayNo++;

                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    //Generates a temp value to store the delay in until a save can be done
                    //Max delayNumber for that event + 1
                    int tempDelayNo = ctx.TIBDelays.OrderByDescending(t =>
                        t.DelayNumber)
                            .FirstOrDefault(t =>
                                t.TibIndex == tibIndex).DelayNumber + 1;

                    TIBDelay tibDelay = ctx.TIBDelays.FirstOrDefault(t =>
                        t.TibIndex == tibIndex &&
                        t.DelayNumber == oldDelayNo);

                    if (tibDelay != null)
                    {
                        //Change delay Number to a temporary value
                        tibDelay.DelayNumber = tempDelayNo;
                        ctx.SaveChanges();//Need to save changes so they take affect immediately.

                        TIBDelay moveTibDelay = ctx.TIBDelays.FirstOrDefault(t =>
                            t.TibIndex == tibIndex &&
                            t.DelayNumber == newDelayNo);

                        if (moveTibDelay != null)
                        {
                            if (moveUp)
                            {//Move up is different to move down when it comes to start/end times
                                //Store Start/End Times ready for swap
                                //New end times need to be calculated
                                DateTime? start = moveTibDelay.DelayStart;
                                DateTime? end = start.Value.AddMinutes(
                                    Convert.ToInt16(tibDelay.DelayDuration));

                                moveTibDelay.DelayStart = end;
                                moveTibDelay.DelayEnd = moveTibDelay.DelayStart.Value.AddMinutes(
                                    Convert.ToInt16(moveTibDelay.DelayDuration));

                                tibDelay.DelayStart = start;
                                tibDelay.DelayEnd = end;
                            }
                            else //Opposite of above
                            {
                                //Store Start/End Times ready for swap
                                //New end times need to be calculated
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

            /// <summary>
            /// Deletes the specified tib delay from the database.
            /// Corrects all the remaining start times associated with that event.
            /// </summary>
            /// <param name="tibDelay">The tib delay to delete.</param>
            /// <param name="tibEventStart">Start of the associated tib event.</param>
            /// <returns>True if success, false if failed.</returns>
            public static void DeleteRecord(TIBDelay tibDelay, DateTime tibEventStart)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    TIBDelay delayToDelete = ctx.TIBDelays.FirstOrDefault(t =>
                        t.TibDelayIndex == tibDelay.TibDelayIndex);

                    if (delayToDelete != null)
                    {
                        ctx.TIBDelays.DeleteObject(delayToDelete);//Deletes the delay
                        ctx.SaveChanges();

                        List<TIBDelay> delaysToMod = ctx.TIBDelays
                            .Where(t => t.TibIndex == tibDelay.TibIndex)
                            .OrderBy(t => t.DelayNumber)
                            .ToList();

                        //Loops through remaining delays correcting the DelayNumbers + Start/Ends
                        int delayNumber = 1;
                        DateTime delayStart = tibEventStart;
                        foreach (TIBDelay delay in delaysToMod)
                        {
                            delay.DelayNumber = delayNumber;
                            delay.DelayStart = delayStart;
                            delay.DelayEnd = delayStart.AddMinutes(
                                Convert.ToInt16(delay.DelayDuration));

                            delayStart = delay.DelayEnd.Value;//Set next start time for delay
                            delayNumber++;//increase delay number for each record
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
            /// <summary>
            /// VIEW - Gets the Tib delays view from the database by Tib Event
            /// (using tib event PK - tibIndex).
            /// </summary>
            /// <returns>List of TIBDelaysView.</returns>
            public static List<ElvisDataModel.EDMX.TIBDelaysView> GetByTibEvent(int tibIndex)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TIBDelaysViews
                        .Where(t => t.TibIndex == tibIndex)
                        .OrderBy(t => t.DelayNumber)
                        .ToList();
                }
            }


            /// <summary>
            /// VIEW - Gets the TIB delay view from the database by TIB delay index.
            /// </summary>
            /// <param name="index">TIB Delay Index to retrive.</param>
            /// <returns>Single TIBDelaysView.</returns>
            public static ElvisDataModel.EDMX.TIBDelaysView GetByTibDelayIndex(int index)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
            /// <summary>
            /// Gets a List of Tib Events from the Database for the last X days.
            /// </summary>
            /// <returns>List of TIBEvents.</returns>
            public static List<TIBEvent> GetLastXDays(int xDays)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.TIBEvents
                        .Where(p => p.EventStart >= dtXDaysAgo)
                        .OrderByDescending(o => o.EventStart)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets a specific Tib Event from the Database using the Tib Index
            /// </summary>
            /// <param name="tibIndex">The Tib Index.</param>
            /// <returns>Single TIBEvent database object.</returns>
            public static TIBEvent GetSingle(int tibIndex)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TIBEvents.FirstOrDefault(t =>
                                    t.TibIndex == tibIndex);
                }
            }

            /// <summary>
            /// Works out how long an event is.  If it hasn't ended return duration from start until now.
            /// </summary>
            /// <param name="tibIndex">The Tib Index.</param>
            /// <returns>Duration of the event.</returns>
            public static int? GetLengthInMinutes(int tibIndex)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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

            /// <summary>
            /// Gets the text for the unit number associated with the TIB index.
            /// </summary>
            /// <param name="tibIndex">The Tib Index.</param>
            /// <returns>TIBEvent's unit text.</returns>
            public static string GetUnitText(int tibIndex)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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

            /// <summary>
            /// Gets the Tib events between two dates.
            /// </summary>
            /// <param name="dateFrom">The Date to start from.</param>
            /// <param name="dateTo">The end date.</param>
            /// <returns>A list of Tib Events.</returns>
            public static List<TIBEvent> GetByDateRange(DateTime dateFrom, DateTime dateTo)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    //Need to modify the dates slightly to ensure we populate the whole scheduler.
                    dateFrom = dateFrom.AddHours(-12);
                    dateTo = dateTo.AddHours(13);
                    return ctx.TIBEvents.Where(d =>
                            (d.EventStart >= dateFrom && d.EventEnd < dateTo ||
                            (d.EventStart >= dateFrom && d.EventEnd == null &&
                                d.EventStart < dateTo)))
                        .ToList();
                }
            }

            /// <summary>
            /// Gets the Tib events for a heat.
            /// </summary>
            /// <param name="heatNumberSet">The heat number set to get the data from.</param>
            /// <param name="heatNumber">The heat number to get the data from.</param>
            /// <returns>A list of Tib Events for the heat number specified.</returns>
            public static List<TIBEvent> GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TIBEvents.Where(r =>
                            r.HNS == heatNumberSet && 
                            r.HeatNumber == heatNumber)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets the next event for a given unit
            /// </summary>
            /// <param name="tibIndex">The Tib index for the 'current' event (i.e. we want the next event for the unit after this one)</param>
            /// <param name="unitNumber">The unit number for which the next event must be found</param>
            /// <returns></returns>
            public static TIBEvent GetNextEventForUnit(int tibIndex, int unitNumber)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TIBEvents.FirstOrDefault(e => e.UnitNumber == unitNumber
                        && e.TibIndex > tibIndex);
                }
            }

            /// <summary>
            /// Gets the next event for a given unit group
            /// </summary>
            /// <param name="tibIndex">The Tib index for the 'current' event (i.e. we want the next event for the unit group after this one)</param>
            /// <param name="unitGroupNumber">The unit group number for which the next event must be found</param>
            /// <returns></returns>
            public static TIBEvent GetNextEventForUnitGroup(int tibIndex, int unitGroupNumber)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TIBEvents.FirstOrDefault(e => e.UnitNumber == unitGroupNumber
                        && e.TibIndex > tibIndex);
                }
            }

            public static List<TIBEvent> GetByDateRangeForUnit(DateTime dateFrom, DateTime dateTo, int unitNumber)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    //Need to modify the dates slightly to ensure we populate the whole scheduler.
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
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    //Need to modify the dates slightly to ensure we populate the whole scheduler.
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
            /// <summary>
            /// Gets a single record associated with that heat for a casting event 
            /// e.g. tracking record with unit number 11, 12 or 13 per heat.
            /// </summary>
            /// <returns>A single tracking record.</returns>
            public static ElvisDataModel.EDMX.Tracking GetSingleCasterEvent(int heatNumber, int heatNumberSet)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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

            /// <summary>
            /// Gets Tracking Data for the last X days.
            /// </summary>
            /// <returns>List of Tracking Objects.</returns>
            public static List<ElvisDataModel.EDMX.Tracking> GetLastXDays(int xDays)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.Trackings
                        .Where(p => p.TimeStampStart >= dtXDaysAgo)
                        .OrderByDescending(o => o.TimeStampStart)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets the latest Heat Number Set from the database.
            /// </summary>
            /// <returns>An Int representing the latest HNS.</returns>
            public static int GetLatestHNS()
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Trackings.FirstOrDefault(
                        t => t.HNS == ElvisDbFunctions.GetHNS()).HNS;
                }
            }

            /// <summary>
            /// Gets the latest Heat Number Set from the database using a Heat Number.
            /// </summary>
            /// <param name="heatNumber">The heatnumber you wish to 
            ///     get the latest HNS for.</param>
            /// <returns>An Int representing the latest HNS.</returns>
            public static int GetHNSFromHeatNumber(int heatNumber)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
            /// <summary>
            /// Gets the Treatment Tracking events between two dates.
            /// </summary>
            /// <param name="dateFrom">The Date to start from.</param>
            /// <param name="dateTo">The end date.</param>
            /// <returns>A list of TreatmentTracking Events.</returns>
            public static List<ElvisDataModel.EDMX.TreatmentTracking> GetByDateRange(
                DateTime dateFrom,
                DateTime dateTo)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TreatmentTrackings
                        .Where(t =>
                            t.TimeStampStart >= dateFrom &&
                            t.TimeStampStart <= dateTo)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets the Treatment Tracking events by Heat Number
            /// </summary>
            /// <param name="heatNumber">The Heat Number.</param>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <returns>A list of TreatmentTracking Events.</returns>
            public static List<ElvisDataModel.EDMX.TreatmentTracking> GetByHeatNumber(
                int heatNumber,
                int heatNumberSet)
            {
                using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
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
