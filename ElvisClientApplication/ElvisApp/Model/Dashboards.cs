using System;
using System.Collections.Generic;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Model
{
    public static class Dashboards
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the KPI Config Data from the database.
        /// </summary>
        public static List<KPIConfig> GetKPIConfigs(int dashNo)
        {
            try
            {
                return EntityHelper.KPIConfig.GetByDashboardNo(dashNo);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- GetKPIConfigs() -- Error getting KPI Config data from database -- ",
                    ex);
            }
            return new List<KPIConfig>();
        }

        /// <summary>
        /// Gets the KPI Action Rules Data from the database.
        /// </summary>
        public static List<KPIActionRule> GetKPIActionRules()
        {
            try
            {
                return EntityHelper.KPIActionRules.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- GetKPIActionRules() -- Error getting KPI Action Rules data from database -- ",
                    ex);
            }
            return new List<KPIActionRule>();
        }

        /// <summary>
        /// Gets the KPI Data from the database.
        /// </summary>
        public static List<KPIData> GetKPIData(DateTime dateFrom, int noOfDays)
        {
            try
            {
                return EntityHelper.KPIData.GetByDaySpan(noOfDays, dateFrom);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- GetKPIData() -- Error getting KPI Data from database -- ",
                    ex);
            }
            return new List<KPIData>();
        }

        /// <summary>
        /// Gets the Weekly KPI Data from the database.
        /// </summary>
        public static List<KPIDataWeek> GetWeeklyKPIData(int weekNo, int yearNo)
        {
            try
            {
                return EntityHelper.KPIDataWeek.GetByWeekNo(weekNo, yearNo);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- GetWeeklyKPIData() -- Error getting Weekly KPI Data from database -- ",
                    ex);
            }
            return new List<KPIDataWeek>();
        }

        /// <summary>
        /// Gets the Group Config Data from the database.
        /// </summary>
        public static List<GroupConfig> GetGroupConfigs()
        {
            try
            {
                return EntityHelper.GroupConfig.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- GetGroupConfigs() -- Error getting Group Config Data from database -- ",
                    ex);
            }
            return new List<GroupConfig>();
        }

        /// <summary>
        /// This method is required to supply the mouse enter event with tooltip info.
        /// Tooltips were behaving funny after being clicked on and not
        /// displaying anymore so this was the solution.
        /// </summary>
        /// <param name="config">The KPIConfig to Convert.</param>
        /// <param name="dayNo">The Day No value.</param>
        /// <returns>A KPIConfigDayNo object.</returns>
        public static KPIConfigWithDayNo GetConfigWithDayNo(KPIConfig config, int dayNo)
        {
            if (config != null)
            {
                return new KPIConfigWithDayNo()
                {
                    KPIINdex = config.KPIINdex,
                    KPILevel = config.KPILevel,
                    KPIDescription = config.KPIDescription,
                    Minimum = config.Minimum,
                    Maximum = config.Maximum,
                    KPISubLevel = config.KPISubLevel,
                    KPIActionIndex = config.KPIActionIndex,
                    KPIActionGroup = config.KPIActionGroup,
                    ShowValue = config.ShowValue,
                    ToolTip = config.ToolTip,
                    DayNo = dayNo
                };
            }
            return null;
        }
    }

    public class KPIConfigWithDayNo : KPIConfig
    {
        public int DayNo { get; set; }
    }
}