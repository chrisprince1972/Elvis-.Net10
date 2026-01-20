using System;
using System.Collections.Generic;
using System.Linq;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region DailyPlanCasterHeats View Functions
        public static class DailyPlanCasterHeats
        {
            /// <summary>
            /// VIEW - DailyPlanCasterHeats
            /// Gets a list of daily planned caster heats for the caster review page.
            /// For 10am plan pass date e.g. 10/10/2010 10:00:00
            /// For 7am plan pass date e.g. 10/10/2010 07:00:00
            /// For 7pm plan pass date e.g. 10/10/2010 19:00:00
            /// </summary>
            /// <param name="fixDate">The Date you wish to get the record for.</param>
            /// <returns>A list of DailyPlanCasterHeat objects.</returns>
            public static List<ElvisDataModel.EDMX.DailyPlanCasterHeat> GetByFixDate(DateTime fixDate)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    DateTime toFixDate = fixDate.AddHours(12);
                    DateTime toDate = fixDate.AddHours(24);

                    return ctx.DailyPlanCasterHeats
                        .Where(d =>
                            d.FixDate == fixDate &&
                            d.FixDate < toFixDate
                            &&
                            d.PLANNED_START_CAST_TIME >= fixDate &&
                            d.PLANNED_START_CAST_TIME < toDate
                            && d.PLANNED_START_CAST_TIME != null
                            )
                        .OrderBy(d => d.PLANNED_START_CAST_TIME)
                        .ToList();
                }
            }
        }
        #endregion

        #region TibOEEReport View Functions
        public static class TibOEEReport
        {
            /// <summary>
            /// VIEW - Gets hte Tib OEE Report data between two dates per area (Unit).
            /// </summary>
            /// <param name="dateFrom">The Date From.</param>
            /// <param name="dateTo">The Date To.</param>
            /// <param name="unitNumber">The Unit number of the area.</param>
            /// <returns>A list of TibOEEReport data objects.</returns>
            public static List<ElvisDataModel.EDMX.TibOEEReport> GetByDateAndUnit(DateTime dateFrom,
                DateTime dateTo, int unitNumber)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibOEEReports
                        .Where(d =>
                            (d.EventStart >= dateFrom && d.EventStart < dateTo ||
                             d.EventEnd >= dateFrom && d.EventStart < dateTo ||
                             d.EventStart < dateFrom && d.EventEnd >= dateTo) &&
                             d.DelayDuration > 0 &&
                             d.UnitNumber == unitNumber)
                        .ToList();
                }
            }

            /// <summary>
            /// VIEW - gets OEE data between two dates per arrays of units
            /// </summary>
            /// <param name="units">The list of units to get the data for</param>
            /// <param name="dateFrom">The start of the period</param>
            /// <param name="dateTo">The end of the period</param>
            /// <returns></returns>
            public static List<ElvisDataModel.EDMX.TibOEEReport> GetByDateAndUnit(List<int> units, DateTime dateFrom,
                DateTime dateTo)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibOEEReports
                        .Where(
                            d => units.Contains(d.UnitNumber))
                        .Where(
                            d => d.EventStart >= dateFrom && d.EventStart < dateTo
                            || d.EventEnd >= dateFrom && d.EventStart < dateTo
                            || d.EventStart < dateFrom && d.EventEnd >= dateTo)
                        .Where(
                            d => d.DelayDuration > 0).ToList();
                }
            }

            /// <summary>
            /// VIEW - Gets hte Tib OEE Report data between two dates per area (Unit Group).
            /// Does the same as GetByDateAndUnit() but for a group of units.
            /// </summary>
            /// <param name="dateFrom">The Date From.</param>
            /// <param name="dateTo">The Date To.</param>
            /// <param name="unitGroupNumber">The Unit Group number of the area.</param>
            /// <returns>A list of TibOEEReport data objects.</returns>
            public static List<ElvisDataModel.EDMX.TibOEEReport> GetByDateAndUnitGroup(DateTime dateFrom,
                DateTime dateTo, int unitGroupNumber)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibOEEReports
                        .Where(d =>
                            (d.EventStart >= dateFrom && d.EventStart < dateTo ||
                             d.EventEnd >= dateFrom && d.EventStart < dateTo ||
                             d.EventStart < dateFrom && d.EventEnd >= dateTo) &&
                             d.DelayDuration > 0 &&
                             d.UnitGroup == unitGroupNumber)
                        .ToList();
                }
            }
        }
        #endregion

        #region TIBReasonsView View Functions
        public static class TIBReasonsView
        {
            /// <summary>
            /// VIEW - Gets a List of Tib Reasons VIew from the Database filtered by unit group 
            /// And containing the text for class and discipline
            /// </summary>
            /// <returns>List of TIBReasonsView.</returns>
            public static List<ElvisDataModel.EDMX.TIBReasonsView> GetByUnitGroup(int? unitGroup)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    if (unitGroup.HasValue)
                    {
                        return ctx.TIBReasonsViews
                            .Where(t => t.UnitGroup == unitGroup)
                            .ToList();
                    }
                }
                return new List<ElvisDataModel.EDMX.TIBReasonsView>();
            }

            /// <summary>
            /// VIEW - Gets TIB Reasons with filter options.
            /// </summary>
            /// <param name="filter">The filter you wish to apply to the data.</param>
            /// <returns>A list of TIBReasonsView objects containing the query results.</returns>
            public static List<ElvisDataModel.EDMX.TIBReasonsView> GetByFilter(string filter)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TIBReasonsViews
                        .Where(filter)
                        .ToList();
                }
            }
        }
        #endregion

        #region TibReportDelaysView View Functions
        public static class TibReportDelaysView
        {
            /// <summary>
            /// Gets a list of TibReportDelaysView using a date range.
            /// </summary>
            /// <param name="dateFrom">The Date to start from.</param>
            /// <param name="dateTo">The end date.</param>
            /// <returns>A list of TibReportDelaysView.</returns>
            public static List<ElvisDataModel.EDMX.TibReportDelaysView> GetByDateRange(
                DateTime dateFrom, DateTime dateTo)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    //return ctx.TibReportDelaysViews.Where(d =>
                    //    (d.EventStart >= dateFrom && d.EventEnd <= dateTo ||
                    //    (d.EventStart >= dateFrom && d.EventEnd == null &&
                    //        d.EventStart < dateTo)))
                    //    .ToList();
                    return ctx.TibReportDelaysViews.Where(d =>
                        (d.EventStart >= dateFrom && d.EventEnd <= dateTo ||
                        (d.EventStart >= dateFrom && d.EventEnd == null &&
                            d.EventStart < dateTo)
                            || (d.EventStart >= dateFrom && d.EventStart < dateTo && d.EventEnd > dateTo)
                            || (d.EventStart <= dateFrom && d.EventStart < dateTo && d.EventEnd > dateFrom
                            && d.EventEnd < dateTo)))
                        .ToList();
                }
            }

            /// <summary>
            /// Gets a list of TibReportDelaysView using a date range and unit id.
            /// </summary>
            /// <param name="dateFrom">The Date to start from.</param>
            /// <param name="dateTo">The end date.</param>
            /// <param name="unitID">The id of the required unit.</param>
            /// <returns>A list of TibReportDelaysView for the unit within the given date range.</returns>
            public static List<ElvisDataModel.EDMX.TibReportDelaysView> GetByDateRangeAndUnit(DateTime dateFrom, DateTime dateTo, int unitID)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibReportDelaysViews.Where(d => d.UnitNumber == unitID &&
                        (d.EventStart >= dateFrom && d.EventEnd <= dateTo ||
                        (d.EventStart >= dateFrom && d.EventEnd == null &&
                            d.EventStart < dateTo)
                            || (d.EventStart >= dateFrom && d.EventStart < dateTo && d.EventEnd > dateTo)
                            || (d.EventStart <= dateFrom && d.EventStart < dateFrom && d.EventEnd >= dateFrom
                            && d.EventEnd < dateTo)))
                        .ToList();
                }
            }

            /// <summary>
            /// Gets a list of TibReportDelaysView using a date range and unit group id.
            /// </summary>
            /// <param name="dateFrom">The Date to start from.</param>
            /// <param name="dateTo">The end date.</param>
            /// <param name="unitID">The id of the required unit group.</param>
            /// <returns>A list of TibReportDelaysView for the unit group within the given date range.</returns>
            public static List<ElvisDataModel.EDMX.TibReportDelaysView> GetByDateRangeAndUnitGroup(DateTime dateFrom, DateTime dateTo, int unitGroupID)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibReportDelaysViews.Where(d => d.UnitGroup == unitGroupID &&
                        (d.EventStart >= dateFrom && d.EventEnd <= dateTo ||
                        (d.EventStart >= dateFrom && d.EventEnd == null &&
                            d.EventStart < dateTo)
                            || (d.EventStart >= dateFrom && d.EventStart < dateTo && d.EventEnd > dateTo)
                            || (d.EventStart <= dateFrom && d.EventStart < dateFrom && d.EventEnd >= dateFrom
                            && d.EventEnd < dateTo)))
                        .ToList();
                }
            }

            /// <summary>
            /// Gets a list of TibReportDelaysView using a string
            /// </summary>
            /// <param name="filter">Dynamic query string</param>
            /// <returns>A list of TibReportDelaysView based on the contents of the filter.</returns>
            public static List<ElvisDataModel.EDMX.TibReportDelaysView> GetDelaysByFilter(string filter)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibReportDelaysViews.Where(filter).ToList();
                }
            }

            public static List<ElvisDataModel.EDMX.TibReportDelaysView> GetByDateAndUnit(List<int> units, DateTime dateFrom,
                DateTime dateTo)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibReportDelaysViews
                        .Where(
                            d => units.Contains(d.UnitNumber))
                        .Where(
                            d => d.EventStart >= dateFrom && d.EventStart < dateTo
                            || d.EventEnd >= dateFrom && d.EventStart < dateTo
                            || d.EventStart < dateFrom && d.EventEnd >= dateTo)
                        .Where(
                            d => d.TibDuration > 0).ToList();
                }
            }
        }

        
        #endregion

        #region TibReportsView View Functions
        public static class TibReportsView
        {
            /// <summary>
            /// VIEW - Gets the Tib Analysis Report Data using the TibReportsView View.
            /// </summary>
            /// <param name="units">The List of Units to include in the results.</param>
            /// <param name="dateFrom">The From Date.</param>
            /// <param name="dateTo">The To Date.</param>
            /// <returns>A List of TibReportsView for the report.</returns>
            public static List<ElvisDataModel.EDMX.TibReportsView> GetByDateAndUnit(
                List<int> units,
                DateTime dateFrom,
                DateTime dateTo)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibReportsViews
                        .Where(
                            d => units.Contains(d.UnitNumber))
                        .Where(
                            d => d.EventStart >= dateFrom && d.EventStart < dateTo
                            || d.EventEnd >= dateFrom && d.EventStart < dateTo
                            || d.EventStart < dateFrom && d.EventEnd >= dateTo)
                        .Where(
                            d => d.DelayDuration > 0).ToList();
                }
            }

            /// <summary>
            /// VIEW - Gets the Tib Reports information from the view TibReportsView
            /// </summary>
            /// <param name="filter">The filter for the data as a string.</param>
            /// <returns>A List of TibReportsView</returns>
            public static List<ElvisDataModel.EDMX.TibReportsView> GetByFilter(string filter)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibReportsViews.Where(filter).ToList();
                }
            }

           
        }
        #endregion

        #region TibTimeInProductionView View Functions
        public static class TibTimeInProductionView
        {
            /// <summary>
            /// VIEW - Gets the raw delays data for time in production report.
            /// </summary>
            /// <param name="dateFrom">The Date From.</param>
            /// <param name="dateTo">The Date To.</param>
            /// <returns>A List of TibReportsView.</returns>
            public static List<ElvisDataModel.EDMX.TibTimeInProductionView> GetByDate(
                DateTime dateFrom,
                DateTime dateTo)
            {
                using (ViewDataSchemaEntities ctx = new ViewDataSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TibTimeInProductionViews
                        .Where(d =>
                            d.EventStart >= dateFrom && d.EventStart < dateTo ||
                            d.EventEnd >= dateFrom && d.EventStart < dateTo ||
                            d.EventStart < dateFrom && d.EventEnd >= dateTo)
                        .OrderBy(o => o.UnitNumber)
                        .ToList();
                }
            }
        }
        #endregion
    }
}
