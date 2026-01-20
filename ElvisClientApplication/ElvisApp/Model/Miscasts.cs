using System;
using System.Collections.Generic;
using System.Linq;
using Elvis.Common;
using Elvis.Forms.Reports.Miscasts;
using ElvisDataModel.EDMX;
using NLog;
using ElvisDataModel;
using Elvis.Properties;
using BusinessLogic.Constants.Trending.Dashboards;

namespace Elvis.Model
{
    public static class Miscasts
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the miscast data from the Database.
        /// </summary>
        /// <returns>A list of MiscastMain Objects.</returns>
        public static List<MiscastMain> GetMiscastData()
        {
            try
            {
                return EntityHelper.MiscastMain.GetLastXDays(Settings.Default.OverviewDaysToShow);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetMiscastData() -- " +
                    "Getting Miscast data from Database -- ", ex);
                return new List<MiscastMain>();
            }
        }

        /// <summary>
        /// Gets the miscast related to the event by heat number.
        /// Null if none exists.
        /// </summary>
        /// <param name="miscasts">A list of miscasts.</param>
        /// <param name="productionEvent">The event to check.</param>
        /// <returns>A string or null.</returns>
        public static string GetMiscastTypeByProductionEvent(
            List<MiscastMain> miscasts,
            ProductionEvent productionEvent)
        {
            MiscastMain miscast = miscasts.FirstOrDefault(m =>
                m.HeatNumberSet == productionEvent.HeatNumberSet &&
                m.HeatNumber == productionEvent.HeatNumber);

            if (miscast != null)
            {
                if (miscast.MiscastType != null)
                    return miscast.MiscastType.Type;
                else
                    return "Unknown";
            }

            return null;
        }

        public static List<MiscastGraphItem> GetMiscastFailureModeData(List<MiscastFailureMode> failureModesLookup)
        {
            List<MiscastGraphItem> miscastGraphList = new List<MiscastGraphItem>();
            foreach (MiscastFailureMode failureMode in failureModesLookup.Where(f => f.FailureModeID > 0))
            {
                MiscastGraphItem item = new MiscastGraphItem()
                {
                    ID = failureMode.FailureModeID,
                    Description = failureMode.FailureMode
                };
                miscastGraphList.Add(item);
            }
            return miscastGraphList;
        }

        public static List<MiscastGraphItem> GetMiscastTypeData(List<MiscastType> typesLookup)
        {
            List<MiscastGraphItem> miscastGraphList = new List<MiscastGraphItem>();
            foreach (MiscastType type in typesLookup.Where(t => t.MiscastTypeID > 0))
            {
                MiscastGraphItem item = new MiscastGraphItem()
                {
                    ID = type.MiscastTypeID,
                    Description = type.Type
                };
                miscastGraphList.Add(item);
            }
            return miscastGraphList;
        }

        public static List<MiscastGraphItem> GetMiscastRootCauseData(List<MiscastRootCause> rootCausesLookup)
        {
            List<MiscastGraphItem> miscastGraphList = new List<MiscastGraphItem>();
            foreach (MiscastRootCause rootCause in rootCausesLookup.Where(r => r.RootCauseID > 0))
            {
                MiscastGraphItem item = new MiscastGraphItem()
                {
                    ID = rootCause.RootCauseID,
                    Description = rootCause.RootCause
                };
                miscastGraphList.Add(item);
            }
            return miscastGraphList;
        }

        public static List<MiscastGraphItem> GetMiscastUnitData(List<MiscastUnit> unitsLookup)
        {
            List<MiscastGraphItem> miscastGraphList = new List<MiscastGraphItem>();
            foreach (MiscastUnit unit in unitsLookup.Where(u => u.MiscastUnitID > 0))
            {
                MiscastGraphItem item = new MiscastGraphItem()
                {
                    ID = unit.MiscastUnitID,
                    Description = unit.MiscastUnit1
                };
                miscastGraphList.Add(item);
            }
            return miscastGraphList;
        }

        public static List<MiscastGraphItem> GetMiscastAreaData(List<MiscastAreaResponsible> areasLookup)
        {
            List<MiscastGraphItem> miscastGraphList = new List<MiscastGraphItem>();
            foreach (MiscastAreaResponsible area in areasLookup.Where(a => a.AreaResponsibleID > 0))
            {
                MiscastGraphItem item = new MiscastGraphItem()
                {
                    ID = area.AreaResponsibleID,
                    Description = area.AreaResponsible
                };
                miscastGraphList.Add(item);
            }
            return miscastGraphList;
        }

        public static List<MiscastGraphItem> GetMiscastFunctionData(List<MiscastFunction> functionsLookup)
        {
            List<MiscastGraphItem> miscastGraphList = new List<MiscastGraphItem>();
            foreach (MiscastFunction function in functionsLookup.Where(f => f.FunctionID > 0))
            {
                MiscastGraphItem item = new MiscastGraphItem()
                {
                    ID = function.FunctionID,
                    Description = function.TrioFunction
                };
                miscastGraphList.Add(item);
            }
            return miscastGraphList;
        }

        public static List<MiscastGraphItem> GetMiscastRotaData(List<MiscastRota> rotasLookup)
        {
            List<MiscastGraphItem> miscastGraphList = new List<MiscastGraphItem>();
            foreach (MiscastRota rota in rotasLookup.Where(r => r.RotaID > 0))
            {
                MiscastGraphItem item = new MiscastGraphItem()
                {
                    ID = rota.RotaID,
                    Description = rota.Rota
                };
                miscastGraphList.Add(item);
            }
            return miscastGraphList;
        }

        public static List<MiscastGraphItem> GetMiscastStatusData(List<MiscastStatu> statusLookup)
        {
            List<MiscastGraphItem> miscastGraphList = new List<MiscastGraphItem>();
            foreach (MiscastStatu status in statusLookup.Where(s => s.MiscastStatusID > 0))
            {
                MiscastGraphItem item = new MiscastGraphItem()
                {
                    ID = status.MiscastStatusID,
                    Description = status.Status
                };
                miscastGraphList.Add(item);
            }
            return miscastGraphList;
        }

        public static List<MiscastGraphItem> GetMiscastWeeklyData(DateTime dateFrom, DateTime dateTo)
        {
            List<MiscastGraphItem> miscastGraphList = new List<MiscastGraphItem>();
            foreach (DateTime day in DateTimeExtensions.EachDay(dateFrom, dateTo, 1))
            {
                if (day == day.StartOfWeek(DayOfWeek.Sunday))
                {
                    DateTime date = new DateTime(
                        day.Year, day.Month, day.Day,
                        7, 0, 0
                    );

                    if (date < dateTo)
                    {
                        MiscastGraphItem item = new MiscastGraphItem()
                        {
                            Description = "Week " + day.Date.AddDays(1).WeekOfYear(),
                            Date = date
                        };

                        miscastGraphList.Add(item);
                    }
                }
            }
            return miscastGraphList;
        }

        public static List<MiscastGraphItem> GetMiscastDailyData(DateTime dateFrom, DateTime dateTo)
        {
            List<MiscastGraphItem> miscastGraphList = new List<MiscastGraphItem>();
            foreach (DateTime day in DateTimeExtensions.EachDay(dateFrom, dateTo, 1))
            {
                DateTime date = new DateTime(
                    day.Year, day.Month, day.Day,
                    7, 0, 0
                );

                if (date < dateTo)
                {
                    MiscastGraphItem item = new MiscastGraphItem()
                    {
                        Description = day.Date.ToString("dd/MM"),
                        Date = date
                    };

                    miscastGraphList.Add(item);
                }
            }
            return miscastGraphList;
        }
    }

    public class MiscastFilterHolder
    {
        public List<Tuple<string, string>> ComboFilterList { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public void AddFunctionArea(MiscastFunctionArea area)
        {
            if(ComboFilterList == null)
            {
                ComboFilterList = new List<Tuple<string, string>>();
            }

            if (area != MiscastFunctionArea.Unknown)
            {
                string areaAsString = Enum.GetName(typeof(MiscastFunctionArea), area);
                var areaAsTuple = 
                    new Tuple<string, string>("Function", areaAsString);
                ComboFilterList.Add(areaAsTuple);
            }
        }

    }

    /// <summary>
    /// Used to simplify the population of the Miscast Analysis Chart.
    /// </summary>
    public class MiscastAnalysisDataPoint
    {
        public string Series { get; set; }
        public string XAxisGroup { get; set; }
        public int YAxisCount { get; set; }
        public DateTime? Date { get; set; }
        public string SeriesTitle { get; set; }
        public string XAxisTitle { get; set; }
    }

    public class MiscastGraphItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
