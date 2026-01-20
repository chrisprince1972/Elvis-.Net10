using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region CasterSum Table Functions

        public static class CasterSum
        {
            /// <summary>
            /// Gets the CasterSum record for a single date.
            /// </summary>
            /// <param name="date">The date required</param>
            /// <returns>A single CasterSum instance.</returns>
            public static EDMX.CasterSum GetCasterSumForDay(DateTime date)
            {
                DateTime casterSumDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);

                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.CasterSums
                        .Where(c => c.SumDate == casterSumDate)
                        .SingleOrDefault();
                }
            }

            /// <summary>
            /// Gets the CasterSum records for the week starting midnight on the Sunday
            /// of the week containing the supplied date.
            /// </summary>
            /// <param name="date">A date within the required week.</param>
            /// <returns>A list of CasterSum instances.</returns>
            public static List<EDMX.CasterSum> GetCasterSumsForWeek(DateTime date)
            {
                // Get the date of midnight on Sunday of the required week.
                int diff = date.DayOfWeek - DayOfWeek.Sunday;
                if (diff < 0)
                {
                    diff += 7;
                }

                DateTime startDate = date.AddDays(-1 * diff).Date;
                DateTime endDate = startDate.AddDays(7);

                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.CasterSums
                        .Where(c => c.SumDate >= startDate && c.SumDate < endDate)
                        .OrderBy(c => c.SumDate)
                        .ToList();
                }
            }
        }

        #endregion CasterSum Table Functions

        #region GroupConfig Table Functions

        public static class GroupConfig
        {
            /// <summary>
            /// Gets all of the GroupConfig records from the database.
            /// </summary>
            /// <returns>List of GroupConfig Objects.</returns>
            public static List<EDMX.GroupConfig> GetAll()
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GroupConfigs
                        .Include("GroupHighlight")
                        .OrderBy(p => p.GroupSort)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets all of the GroupConfig records from the database that are enabled.
            /// </summary>
            /// <returns>List of GroupConfig Objects.</returns>
            public static List<EDMX.GroupConfig> GetAllEnabled()
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GroupConfigs
                        .Where(g => g.DisplayCode == 1)
                        .OrderBy(p => p.GroupSort)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets a GroupConfig record by GroupIndex ID.
            /// </summary>
            /// <returns>A GroupConfig Object.</returns>
            public static EDMX.GroupConfig GetByID(int groupIndex)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GroupConfigs
                        .Include("GroupHighlight")
                        .FirstOrDefault(g => g.GroupIndex == groupIndex);
                }
            }

            /// <summary>
            /// Adds a new GroupConfig record to the database.
            /// </summary>
            /// <param name="groupConfig">The GroupConfig to add.</param>
            public static void AddNew(EDMX.GroupConfig groupConfig)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ctx.AddToGroupConfigs(groupConfig);
                    ctx.SaveChanges();
                }
            }

            /// <summary>
            /// Gets the highest group sort in the table.
            /// </summary>
            public static int GetHighestGroupSort()
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    int? groupSort = ctx.GroupConfigs.Max(g => g.GroupSort);
                    if (groupSort.HasValue)
                        return groupSort.Value;
                    return 0;
                }
            }

            /// <summary>
            /// Updates an existing GroupConfig record in the database.
            /// </summary>
            /// <param name="groupConfigNewValues">A GroupConfig holding the updated values
            /// ready to store in the database.</param>
            /// <returns>Boolean stating success or failure.</returns>
            public static bool EditExisting(EDMX.GroupConfig groupConfigNewValues)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    EDMX.GroupConfig groupConfig = ctx.GroupConfigs.FirstOrDefault(t =>
                        t.GroupIndex == groupConfigNewValues.GroupIndex);

                    if (groupConfig != null)
                    {
                        groupConfig.GroupDesc = groupConfigNewValues.GroupDesc;
                        groupConfig.DisplayCode = groupConfigNewValues.DisplayCode;
                        groupConfig.Par1 = groupConfigNewValues.Par1;
                        groupConfig.Par2 = groupConfigNewValues.Par2;
                        groupConfig.Par3 = groupConfigNewValues.Par3;
                        groupConfig.Par4 = groupConfigNewValues.Par4;
                        groupConfig.Par5 = groupConfigNewValues.Par5;
                        groupConfig.Par6 = groupConfigNewValues.Par6;
                        groupConfig.DefaultHighlight = groupConfigNewValues.DefaultHighlight;

                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }

            /// <summary>
            /// Updates an existing GroupConfig with a new Group Sort number.
            /// </summary>
            /// <param name="newGroupSort">The new group sort to set.</param>
            /// <param name="groupIndex">The index of the object to modify.</param>
            /// <returns>Boolean stating success or failure.</returns>
            public static bool EditGroupSort(int? newGroupSort, int groupIndex)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    EDMX.GroupConfig groupConfig = ctx.GroupConfigs.FirstOrDefault(t =>
                        t.GroupIndex == groupIndex);

                    if (groupConfig != null && newGroupSort.HasValue)
                    {
                        groupConfig.GroupSort = newGroupSort;
                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }

            /// <summary>
            /// Deletes a GroupConfig record from the database.
            /// </summary>
            /// <param name="groupIndexToDelete">The index of the Group Config record to delete.</param>
            /// <returns>True if success, false if failed.</returns>
            public static bool DeleteRecord(int groupIndexToDelete)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    EDMX.GroupConfig groupToDelete = ctx.GroupConfigs.FirstOrDefault(g => g.GroupIndex == groupIndexToDelete);

                    if (groupToDelete != null)
                    {
                        ctx.DeleteObject(groupToDelete);
                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
        }

        #endregion GroupConfig Table Functions

        #region GroupHighlight Table Functions

        public static class GroupHighlight
        {
            /// <summary>
            /// Gets all of the GroupHighlight records from the database.
            /// </summary>
            /// <returns>List of GroupHighlight Objects.</returns>
            public static List<EDMX.GroupHighlight> GetAll()
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GroupHighlights
                        .OrderBy(g => g.HighlightID)
                        .ToList();
                }
            }
        }

        #endregion GroupHighlight Table Functions

        #region KPIActionRules Table Functions

        public static class KPIActionRules
        {
            /// <summary>
            /// Gets all the KPI Action Rules records from the database.
            /// </summary>
            /// <returns>A list of KPIActionRule objects.</returns>
            public static List<EDMX.KPIActionRule> GetAll()
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.KPIActionRules.ToList();
                }
            }
        }

        #endregion KPIActionRules Table Functions

        #region KPIConfig Table Functions

        public static class KPIConfig
        {
            /// <summary>
            /// Gets the KPI Config records from the database by dashboard number.
            /// </summary>
            /// <param name="dashboardNo">The Dashboard number to filter on -
            ///     1 - Central Morning Meeting Dashboard -
            ///     2 - Primary Dashboard -
            ///     99 - Test Dashboard - </param>
            /// <returns>A list of KPIConfig objects ordered by levels.</returns>
            public static List<EDMX.KPIConfig> GetByDashboardNo(int dashboardNo)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.KPIConfigs
                        .Where(k => k.Dashboard == dashboardNo)
                        .OrderBy(k => k.KPILevel)
                        .ThenBy(k => k.KPISubLevel)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets all the KPI Config records from the database.
            /// </summary>
            /// <returns>A list of KPIConfig objects ordered by levels.</returns>
            public static List<EDMX.KPIConfig> GetAll()
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.KPIConfigs
                        .OrderBy(k => k.KPILevel)
                        .ThenBy(k => k.KPISubLevel)
                        .ToList();
                }
            }

            /// <summary>
            /// Updates a specific KPIConfig.
            /// </summary>
            /// <param name="kpiConfigNewValues">The KPI Config to Update.</param>
            /// <returns>True for success, false for failure.</returns>
            public static bool Update(EDMX.KPIConfig kpiConfigNewValues)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ElvisDataModel.EDMX.KPIConfig kpiConfig = ctx.KPIConfigs.FirstOrDefault(t =>
                        t.KPIINdex == kpiConfigNewValues.KPIINdex);

                    if (kpiConfig != null)
                    {
                        kpiConfig.Minimum = kpiConfigNewValues.Minimum;
                        kpiConfig.Maximum = kpiConfigNewValues.Maximum;
                        kpiConfig.ShowValue = kpiConfigNewValues.ShowValue;
                        kpiConfig.KPIActionIndex = kpiConfigNewValues.KPIActionIndex;
                        kpiConfig.KPIActionGroup = kpiConfigNewValues.KPIActionGroup;
                        kpiConfig.ToolTip = kpiConfigNewValues.ToolTip;
                        kpiConfig.StringFormat = kpiConfigNewValues.StringFormat;
                        kpiConfig.KPIInfo = kpiConfigNewValues.KPIInfo;

                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
        }

        #endregion KPIConfig Table Functions

        #region KPIData Table Functions

        public static class KPIData
        {
            /// <summary>
            /// Gets all the KPI Data records from the database between
            /// two dates.
            /// </summary>
            /// <param name="noOfDays">The amount of days worth of data.</param>
            /// <param name="dateFrom">The Date from.</param>
            /// <returns>A list of KPIData objects ordered by date then index.</returns>
            public static List<EDMX.KPIData> GetByDaySpan(int noOfDays, DateTime dateFrom)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    DateTime dateTo = dateFrom.AddDays(noOfDays);
                    return ctx.KPIDatas
                        .Where(k =>
                            k.KPIDate >= dateFrom.Date &&
                            k.KPIDate <= dateTo.Date)
                        .OrderBy(k => k.KPIDate)
                        .ThenBy(k => k.KPIIndex)
                        .ToList();
                }
            }
        }

        #endregion KPIData Table Functions

        #region KPIDataWeek Table Functions

        public static class KPIDataWeek
        {
            /// <summary>
            /// Gets all the Weekly KPI Data records for the Week requested.
            /// </summary>
            /// <param name="weekNo">The Week Number.</param>
            /// <param name="yearNo">The Year Number.</param>
            /// <returns>A list of KPIDataWeek objects ordered by date then index.</returns>
            public static List<EDMX.KPIDataWeek> GetByWeekNo(int weekNo, int yearNo)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.KPIDataWeeks
                        .Where(k =>
                            k.KPIWeek == weekNo &&
                            k.KPIYear == yearNo)
                        .OrderBy(k => k.KPIDate)
                        .ThenBy(k => k.KPIIndex)
                        .ToList();
                }
            }
        }

        #endregion KPIDataWeek Table Functions

        #region ParConfig Table Functions

        public static class ParConfig
        {
            /// <summary>
            /// Adds a new ParConfig record to the database.
            /// </summary>
            /// <param name="parConfig">The ParConfig to add.</param>
            public static void AddNew(ElvisDataModel.EDMX.ParConfig parConfig)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ctx.AddToParConfigs(parConfig);
                    ctx.SaveChanges();
                }
            }

            /// <summary>
            /// Updates an existing ParConfig record in the database.
            /// </summary>
            /// <param name="parConfigNewValues">A ParConfig holding the updated values
            /// ready to store in the database.</param>
            /// <returns>Boolean stating success or failure.</returns>
            public static bool EditExisting(ElvisDataModel.EDMX.ParConfig parConfigNewValues)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ElvisDataModel.EDMX.ParConfig parConfig = ctx.ParConfigs.FirstOrDefault(t =>
                        t.ParIndex == parConfigNewValues.ParIndex);

                    if (parConfig != null)
                    {
                        parConfig.ParDesc = parConfigNewValues.ParDesc;
                        //parConfig.ParFieldName = parConfigNewValues.ParFieldName;//Not Editable
                        parConfig.Parameter = parConfigNewValues.Parameter;
                        parConfig.MinLimit = parConfigNewValues.MinLimit;
                        parConfig.MaxLimit = parConfigNewValues.MaxLimit;
                        parConfig.AimTarget = parConfigNewValues.AimTarget;
                        parConfig.DisplayMin = parConfigNewValues.DisplayMin;
                        parConfig.DisplayMax = parConfigNewValues.DisplayMax;
                        parConfig.ActionCode = parConfigNewValues.ActionCode;
                        parConfig.ActionGroupNumber = parConfigNewValues.ActionGroupNumber;
                        parConfig.CellWidth = parConfigNewValues.CellWidth;

                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }

            /// <summary>
            /// Gets all of the ParConfig records from the database.
            /// </summary>
            /// <returns>List of ParConfig Objects.</returns>
            public static List<ElvisDataModel.EDMX.ParConfig> GetAll()
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.ParConfigs
                        .Include("GroupConfig")
                        .OrderBy(p => p.ParFieldName)
                        .ToList();
                }
            }

            /// <summary>
            /// Get a ParConfig record by ID from the database.
            /// </summary>
            /// <returns>A ParConfig Object.</returns>
            public static ElvisDataModel.EDMX.ParConfig GetByID(int parIndex)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.ParConfigs
                        .FirstOrDefault(p => p.ParIndex == parIndex);
                }
            }
        }

        #endregion ParConfig Table Functions

        #region TrendData Tables Functions

        /// <summary>
        /// This class Covers the many tables that make up the Trending Data
        ///     - TrendDataAdditions
        ///     - TrendDataAnalysis
        ///     - TrendDataProcess
        ///     - TrendDataTemps
        ///     - TrendDataTimes
        /// You need to pass in the type T when using the methods within.
        /// </summary>
        public static class TrendData
        {
            /// <summary>
            /// Get Trending Data by index range
            /// ordered by Index DESC.
            /// </summary>
            /// <param name="fromIndex">The Index to start from.</param>
            /// <param name="toIndex">The Index to end on.</param>
            /// <typeparam name="T">The type to search for -
            ///     TrendDataAdditions
            ///     TrendDataAnalysis
            ///     TrendDataProcess
            ///     TrendDataTemps
            ///     TrendDataTimes</typeparam>
            /// <returns>List of T Objects.</returns>
            public static List<T> GetByIndexRange<T>(int fromIndex, int toIndex) where T : class
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.CreateObjectSet<T>()
                        .Where(string.Format("it.TrendSampleIndex >= {0} AND it.TrendSampleIndex <= {1}", fromIndex, toIndex))
                        .OrderBy("it.TrendSampleIndex DESC")
                        .ToList();
                }
            }

            /// <summary>
            /// Get TrendData by list of indices
            /// ordered by Index DESC.
            /// </summary>
            /// <param name="listIndices">The list of Indices to search.</param>
            /// <typeparam name="T">The type to search for -
            ///     TrendDataAdditions
            ///     TrendDataAnalysis
            ///     TrendDataProcess
            ///     TrendDataTemps
            ///     TrendDataTimes</typeparam>
            /// <returns>List of T Objects.</returns>
            public static List<T> GetByIndexList<T>(
                List<EDMX.TrendDataIndex> listIndices) where T : class
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    if (listIndices != null && listIndices.Count > 0)
                    {
                        int fromIndex = listIndices.OrderBy(t => t.TrendSampleIndex).First().TrendSampleIndex;
                        int toIndex = listIndices.OrderBy(t => t.TrendSampleIndex).Last().TrendSampleIndex;

                        //Need to get full list before filtering on specific Indices
                        List<T> trendDatas = GetByIndexRange<T>(fromIndex, toIndex);

                        //.GetType().GetProperty("TrendSampleIndex").GetValue(datas, null) --
                        // We need this because of the generic way of getting the data.  We
                        // don't know what the type is going to be but we do know the property (TrendSampleIndex).
                        return trendDatas
                            .Where(datas => listIndices
                                .Any(indices => indices.TrendSampleIndex
                                    .Equals(datas
                                        .GetType().GetProperty("TrendSampleIndex").GetValue(datas, null))))
                            .OrderByDescending(p => p.GetType().GetProperty("TrendSampleIndex"))
                            .ToList();
                    }
                    return new List<T>();
                }
            }
        }

        #endregion TrendData Tables Functions

        #region TrendDataIndex Table Functions

        public static class TrendDataIndex
        {
            /// <summary>
            /// Get TrendDataIndex Data by date range
            /// ordered by TimeStamp desc.
            /// </summary>
            /// <param name="from">The DateTime to start from.</param>
            /// <param name="to">The DateTime to end on.</param>
            /// <returns>List of TrendDataIndex Objects.</returns>
            public static List<ElvisDataModel.EDMX.TrendDataIndex> GetByDateRange(DateTime from, DateTime to)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TrendDataIndexes
                        .Where(p => p.TimeStamp >= from && p.TimeStamp <= to)
                        .OrderByDescending(p => p.TimeStamp)
                        .ToList();
                }
            }

            /// <summary>
            /// Get TrendDataIndex Data by date range
            /// and by a filter passed in as a string to be used
            /// dynamically using dynamic lambda.
            /// Ordered by TimeStamp desc.
            /// </summary>
            /// <returns>List of TrendDataIndex Objects.</returns>
            public static List<ElvisDataModel.EDMX.TrendDataIndex> GetByDateRangeAndFilter(
                DateTime from, DateTime to, string filter)
            {
                using (TrendSchemaEntities ctx = new TrendSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TrendDataIndexes
                        .Where(p => p.TimeStamp >= from && p.TimeStamp <= to)
                        .Where(filter)
                        .OrderByDescending(p => p.TimeStamp)
                        .ToList();
                }
            }
        }

        #endregion TrendDataIndex Table Functions
    }
}