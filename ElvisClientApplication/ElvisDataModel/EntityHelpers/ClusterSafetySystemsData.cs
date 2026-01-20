using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region SAS_NM_Actions Table Functions
        public static class SAS_NM_Actions
        {
            /// <summary>
            /// Gets a list of actions by near miss ID.
            /// </summary>
            /// <param name="nearMissID">The ID of the nearmiss in question.</param>
            /// <returns>A list of EDMX.SAS_NM_Actions.</returns>
            public static List<EDMX.SAS_NM_Actions> GetByNearMissID(int nearMissID)
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {
                    return ctx.SAS_NM_Actions
                        .Where
                        (p => p.NM_INDEX == nearMissID)
                        .ToList();
                }
            }
        }

        #endregion

        #region SAS_NM_DataForElvis View Functions
        public static class SAS_NM_DataForElvis
        {
            /// <summary>
            /// Gets data by near miss ID.
            /// </summary>
            /// <param name="nearMissID">The ID of the nearmiss in question.</param>
            /// <returns>A list of EDMX.SAS_NM_Actions.</returns>
            public static EDMX.SAS_NM_DataForElvis GetByNearMissID(int nearMissID)
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {
                    return ctx
                        .SAS_NM_DataForElvis
                        .FirstOrDefault(p => p.ID == nearMissID);
                }
            }
        }
        #endregion

        #region SAS_NM_DataWithDateAndTimeJoinedForElvis View Functions
        public static class SAS_NM_DataWithDateAndTimeJoinedForElvis
        {
            
            public enum NearMissRecordStatus
            {
                open = 1,
                closed = 16
            }

            public enum NearMissRecordPriority
            {
                notSet = 0,
                low,
                medium,
                high
            }


            public static List<EDMX.SAS_NM_DataWithDateAndTimeJoinedForElvis> GetPreviousDays(int number)
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-number);
                    return ctx
                        .SAS_NM_DataWithDateAndTimeJoinedForElvis
                        .Where(r => r.Date >= dtXDaysAgo)
                        .OrderByDescending(r => r.Date)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets near miss Data for the last X days.
            /// </summary>
            /// <returns>List of SAS_NM_DataWithDateAndTimeJoinedForElvis Objects.</returns>
            public static List<EDMX.SAS_NM_DataWithDateAndTimeJoinedForElvis> GetLastXDays(int xDays)
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.SAS_NM_DataWithDateAndTimeJoinedForElvis
                        .Where
                        (p =>
                            p.Date.HasValue
                            && p.Date.Value >= dtXDaysAgo
                        )
                        .OrderByDescending(o => o.Date)
                        .ToList();
                }
            }

            /// <summary>
            /// Get data between two dates and subject to a filter.
            /// </summary>
            /// <param name="dateFrom">The date you want to filter from.</param>
            /// <param name="dateTo">The date you want to filter to.</param>
            /// <param name="filter">The filter you wish to apply to the data.</param>
            /// <returns>List of SAS_NM_DataWithDateAndTimeJoinedForElvis Objects.</returns>
            public static List<EDMX.SAS_NM_DataWithDateAndTimeJoinedForElvis> GetByDateAndFilter(DateTime dateFrom, DateTime dateTo, string filter)
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {

                    if (filter == string.Empty)
                    {
                        return ctx
                            .SAS_NM_DataWithDateAndTimeJoinedForElvis
                            .Where
                            (p =>
                                p.Date.HasValue
                                && p.Date.Value >= dateFrom
                                && p.Date.Value < dateTo
                            )
                            .ToList();
                    }
                    else
                    {
                        return ctx
                            .SAS_NM_DataWithDateAndTimeJoinedForElvis
                            .Where
                            (p =>
                                p.Date.HasValue
                                && p.Date.Value >= dateFrom
                                && p.Date.Value < dateTo
                            )
                            .Where(filter)
                            .ToList();
                    }
                }
            }

            /// <summary>
            /// Gets a single nearmiss record by ID.
            /// </summary>
            /// <param name="id">The ID of the nearmiss in question.</param>
            /// <returns>A SAS_NM_DataWithDateAndTimeJoinedForElvis Object.</returns>
            public static EDMX.SAS_NM_DataWithDateAndTimeJoinedForElvis GetByID(int id)
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {
                    return ctx.SAS_NM_DataWithDateAndTimeJoinedForElvis
                        .FirstOrDefault
                        (p =>
                        p.ID == id);
                }
            }

            /// <summary>
            /// Gets all the distinct locations that exists in that table.
            /// </summary>
            /// <returns>A list of strings with the locations.</returns>
            public static List<string> GetAllLocations()
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {
                    List<string> locations
                        = ctx
                        .SAS_NM_DataWithDateAndTimeJoinedForElvis
                        .DistinctBy(r => r.Location)
                        .Where(r => r.Location != "All")
                        .OrderBy(r => r.Location)
                        .Select(r => r.Location)
                        .ToList();

                    locations.Insert(0, "All");

                    return locations;
                }
            }

            /// <summary>
            /// Gets all the distinct rotas that exists in that table.
            /// </summary>
            /// <returns>A list of strings with the rotas.</returns>
            public static List<string> GetAllRotas()
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {
                    List<string> rotas =
                        ctx
                        .SAS_NM_DataWithDateAndTimeJoinedForElvis
                        .DistinctBy(r => r.ROTA)
                        .OrderBy(r => r.ROTA)
                        .Select(r => r.ROTA)
                        .ToList();

                    rotas.Insert(0, "All");

                    return rotas;
                }
            }

            /// <summary>
            /// Gets all the distinct types that exists in that table.
            /// </summary>
            /// <returns>A list of strings with the types.</returns>
            public static List<string> GetAllTypes()
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {
                    List<string> types =
                        ctx
                        .SAS_NM_DataWithDateAndTimeJoinedForElvis
                        .DistinctBy(r => r.Nearmiss_type)
                        .OrderBy(r => r.Nearmiss_type)
                        .Select(r => r.Nearmiss_type)
                        .ToList();

                    types.Insert(0, "All");

                    return types;
                }
            }

            /// <summary>
            /// Gets all the distinct types that exists in that table.
            /// </summary>
            /// <returns>A list of strings with the types.</returns>
            public static List<string> GetAllInitiatorsName()
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {
                    List<string> initiatorsNames
                        = ctx
                        .SAS_NM_DataWithDateAndTimeJoinedForElvis
                        .DistinctBy(r => r.InitiatorsName)
                        .OrderBy(r => r.InitiatorsName)
                        .Select(r => r.InitiatorsName)
                        .ToList();

                    initiatorsNames.Insert(0, "All");

                    return initiatorsNames;
                }
            }

            /// <summary>
            /// Gets all the distinct units that exists in that table.
            /// </summary>
            /// <returns>A list of strings with the units.</returns>
            public static List<string> GetAllStatus()
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {
                    List<string> statuses = new List<string>();

                    foreach (NearMissRecordStatus status in Enum.GetValues(typeof(NearMissRecordStatus)))
                    {
                        statuses.Add(GetStatusAsString(status));
                    }

                    statuses.Insert(0, "All");

                    return statuses;
                }
            }

            /// <summary>
            /// Gets all the distinct reasons that exists in that table.
            /// </summary>
            /// <returns>A list of strings with the reasons.</returns>
            public static List<string> GetAllPriority()
            {
                using (ClusterWW_SafetySystemsModel ctx = new ClusterWW_SafetySystemsModel())
                {

                    List<string> priorities = new List<string>();

                    foreach (NearMissRecordPriority priority in Enum.GetValues(typeof(NearMissRecordPriority)))
                    {
                        priorities.Add(GetPriorityAsString(priority));
                    }

                    priorities.Insert(0, "All");

                    return priorities;
                }
            }

            /// <summary>
            /// Get string representation of the priority value.
            /// </summary>
            /// <param name="id">To identified the priority.</param>
            /// <returns>String representaion of the priority.</returns>
            public static string GetPriorityAsString(NearMissRecordPriority id)
            {
                string status = "Not set";
                switch (id)
                {
                    case NearMissRecordPriority.low:
                        {
                            status = "Low";
                            break;
                        }
                    case NearMissRecordPriority.medium:
                        {
                            status = "Medium";
                            break;
                        }
                    case NearMissRecordPriority.high:
                        {
                            status = "High";
                            break;
                        }
                }

                return status;
            }

            /// <summary>
            /// Get string representation of the priority value.
            /// </summary>
            /// <param name="id">To identified the priority.</param>
            /// <returns>String representaion of the priority.</returns>
            public static NearMissRecordPriority GetPriorityFromString(string priorityAsString)
            {
                NearMissRecordPriority priority = NearMissRecordPriority.notSet;
                switch (priorityAsString)
                {
                    case "Low":
                        {
                            priority = NearMissRecordPriority.low;
                            break;
                        }
                    case "Medium":
                        {
                            priority = NearMissRecordPriority.medium;
                            break;
                        }
                    case "High":
                        {
                            priority = NearMissRecordPriority.high;
                            break;
                        }
                }

                return priority;
            }

            /// <summary>
            /// Get string representation of the status value.
            /// </summary>
            /// <param name="id">To identified the status.</param>
            /// <returns>String representaion of the status.</returns>
            public static string GetStatusAsString(NearMissRecordStatus id)
            {
                string status = "Closed";
                switch (id)
                {
                    case NearMissRecordStatus.open:
                        {
                            status = "Open";
                            break;
                        }
                }

                return status;
            }

            /// <summary>
            /// Get string representation of the status value.
            /// </summary>
            /// <param name="id">To identified the status.</param>
            /// <returns>String representaion of the status.</returns>
            public static NearMissRecordStatus GetStatusFromString(string statusAsString)
            {
                NearMissRecordStatus status = NearMissRecordStatus.closed;
                switch (statusAsString)
                {
                    case "Open":
                        {
                            status = NearMissRecordStatus.open;
                            break;
                        }
                }

                return status;
            }
        }
        #endregion
    }
}
