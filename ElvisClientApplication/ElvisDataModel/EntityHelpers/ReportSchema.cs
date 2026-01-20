using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Security.Principal;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region AimsAnalysisGridData View Functions
        public static class AimsAnalysisGridData
        {
            /// <summary>
            /// VIEW - AimsAnalysisGridData it gets the Aims Analysis data by heat.
            /// This is only half of the analysis data.
            /// Please see AimsExtendedAnalysisGridData for the remaining data.
            /// </summary>
            /// <param name="heatNumber">Heat Number</param>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <returns>List of AimsAnalysisGridData</returns>
            public static List<ElvisDataModel.EDMX.AimsAnalysisGridData> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.AimsAnalysisGridDatas
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet)
                        .OrderBy(a => a.UnitNumber)
                        .ToList();
                }
            }

            /// <summary>
            /// VIEW - AimsAnalysisGridData it gets the Aims Analysis data per Unit.
            /// This is only half of the analysis data.
            /// Please see AimsExtendedAnalysisGridData for the remaining data.
            /// </summary>
            /// <param name="heatNumber">Heat Number.</param>
            /// <param name="heatNumberSet">Heat Number Set.</param>
            /// <param name="unitNumber">Unit Number.</param>
            /// <returns>List of AimsAnalysisGridData.</returns>
            public static List<ElvisDataModel.EDMX.AimsAnalysisGridData> GetByHeatAndUnit(
                int heatNumber,
                int heatNumberSet,
                int unitNumber)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.AimsAnalysisGridDatas
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet &&
                                t.UnitNumber == unitNumber)
                        .OrderBy(a => a.Type)
                        .ToList();
                }
            }
        }
        #endregion

        #region AimsExtendAnalysisGridData View Functions
        public static class AimsExtendAnalysisGridData
        {
            /// <summary>
            /// VIEW - AimsExtendAnalysisGridData return full list of
            /// aims analysis data by Heat.
            /// </summary>
            /// <param name="heatNumber">Heat Number</param>
            /// <param name="heatNumberSet">Heat Number Set</param>
            /// <returns>List of AimsExtendAnalysisGridData</returns>
            public static List<ElvisDataModel.EDMX.AimsExtendAnalysisGridData>
                GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.AimsExtendAnalysisGridDatas
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet)
                        .OrderBy(a => a.UnitNumber)
                        .ToList();
                }
            }

            /// <summary>
            /// VIEW - AimsExtendAnalysisGridData returns list of 
            /// aims analysis data by Heat and per Unit.
            /// </summary>
            /// <param name="heatNumber">Heat Number.</param>
            /// <param name="heatNumberSet">Heat Number Set.</param>
            /// <param name="unitNumber">Unit Number.</param>
            /// <returns>List of AimsExtendAnalysisGridData.</returns>
            public static List<ElvisDataModel.EDMX.AimsExtendAnalysisGridData>
                GetByHeatAndUnit(
                    int heatNumber,
                    int heatNumberSet,
                    int unitNumber)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.AimsExtendAnalysisGridDatas
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet &&
                                t.UnitNumber == unitNumber)
                        .OrderBy(a => a.Type)
                        .ToList();
                }
            }
        }
        #endregion

        #region AnalysisGridData View Functions
        public static class AnalysisGridData
        {
            /// <summary>
            /// VIEW - AnalysisGridData it gets the heat analysis data by Heat.
            /// This is only half of the analysis data. 
            /// Please see ExtendedAnalysisGridData for the remaining data.
            /// </summary>
            /// <param name="heatNumber">Heat Number.</param>
            /// <param name="heatNumberSet">Heat Number Set.</param>
            /// <returns>List of AnalysisGridData.</returns>
            public static List<ElvisDataModel.EDMX.AnalysisGridData> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.AnalysisGridDatas
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet)
                        .OrderBy(a => a.TimeStamp)
                        .ToList();
                }
            }
        }
        #endregion

        #region DRFActions Table Functions
        public static class DRFActions
        {
            /// <summary>
            /// Gets all Actions related to a specific DRF Report.
            /// </summary>
            /// <param name="drfIndex">The index of the report you wish to search for.</param>
            /// <returns>A list of DRFReport objects containing the query results.</returns>
            public static List<ElvisDataModel.EDMX.DRFAction> GetByIndex(int drfIndex)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.DRFActions.Where(d => 
                        d.DRFIndex == drfIndex)
                        .ToList();
                }
            }

            /// <summary>
            /// Adds a new DRF Action to the database.
            /// </summary>
            /// <param name="actionToAdd">The Action object you wish to add.</param>
            public static void AddNew(ElvisDataModel.EDMX.DRFAction actionToAdd)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ctx.AddToDRFActions(actionToAdd);
                    ctx.SaveChanges();
                }
            }

            /// <summary>
            /// Deletes a DRF Action from the database.
            /// </summary>
            /// <param name="actionIndex">The index of the action you wish to delete.</param>
            public static void Delete(int actionIndex)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ElvisDataModel.EDMX.DRFAction drfAction = ctx.DRFActions.FirstOrDefault(t =>
                        t.ActionIndex == actionIndex);

                    if (drfAction != null)
                    {
                        ctx.DRFActions.DeleteObject(drfAction);//Deletes the Action
                        ctx.SaveChanges();
                    }
                }
            }

            /// <summary>
            /// Updates a DRF Action.
            /// </summary>
            /// <param name="actionToAdd">The Action object you wish to update.</param>
            public static void Update(ElvisDataModel.EDMX.DRFAction actionToUpdate)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ElvisDataModel.EDMX.DRFAction drfAction = ctx.DRFActions.FirstOrDefault(t =>
                        t.ActionIndex == actionToUpdate.ActionIndex);

                    if (drfAction != null)
                    {
                        drfAction.Action = actionToUpdate.Action;
                        drfAction.ActionOwner = actionToUpdate.ActionOwner;
                        drfAction.TargetDate = actionToUpdate.TargetDate;
                        drfAction.ActionState = actionToUpdate.ActionState;
                        ctx.SaveChanges();
                    }
                }
            }

            /// <summary>
            /// Change the state of an action.
            /// False for Open.
            /// True for Complete.
            /// </summary>
            /// <param name="actionToAdd">The Action object you wish to modify.</param>
            /// <param name="complete">The new state of the action. False for Open. True for Complete.</param>
            public static void ChangeState(ElvisDataModel.EDMX.DRFAction actionToComplete, bool complete)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ElvisDataModel.EDMX.DRFAction drfAction = ctx.DRFActions.FirstOrDefault(t =>
                        t.ActionIndex == actionToComplete.ActionIndex);

                    if (drfAction != null)
                    {
                        drfAction.ActionState = complete;
                        ctx.SaveChanges();
                    }
                }
            }
        }
        #endregion

        #region DRFDropDownLookUp Table Functions
        public static class DRFDropDownLookUp
        {
            /// <summary>
            /// Gets a list of all of the DRFDropDownLookUp entries in the database.
            /// </summary>
            /// <returns>A list of a drop down look up items.</returns>
            public static List<ElvisDataModel.EDMX.DRFDropDownLookUp> GetAll()
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.DRFDropDownLookUps.ToList();
                }
            }
        }
        #endregion

        #region DRFLocationLookUp Table Functions
        public static class DRFLocationLookUp
        {
            /// <summary>
            /// Gets a list of all of the DRFLocationLookUp entries in the database. 
            /// </summary>
            /// <returns>A list of location look ups.</returns>
            public static List<ElvisDataModel.EDMX.DRFLocationLookUp> GetAll()
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.DRFLocationLookUps.ToList();
                }
            }
        }
        #endregion

        #region DRFOwners Table Functions
        public static class DRFOwners
        {
            /// <summary>
            /// Gets a list of all of the DRFOwners entries in the database. 
            /// </summary>
            /// <returns>A list of DRFOwners.</returns>
            public static List<ElvisDataModel.EDMX.DRFOwner> GetAll()
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.DRFOwners.OrderBy(o => o.Owner).ToList();
                }
            }

            /// <summary>
            /// Gets a list of all of the DRFOwners entries in the database. 
            /// </summary>
            /// <returns>A list of DRFOwners.</returns>
            public static List<ElvisDataModel.EDMX.DRFOwner> GetAllValidIncluding(string extraName)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.DRFOwners
                        .Where(r => !r.ValidUntil.HasValue || r.ValidUntil > DateTime.Now || r.Owner == extraName)
                        .OrderBy(o => o.Owner).ToList();
                }
            }

            /// <summary>
            /// Gets a single owner from the database using the works area and name.
            /// </summary>
            /// <param name="works">The Works Area the Owner is a part of (Steelmaking or Concast).</param>
            /// <param name="owner">The Owners Full Name.</param>
            /// <returns>A DRFOwner.</returns>
            public static ElvisDataModel.EDMX.DRFOwner GetSingle(string works, string owner)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.DRFOwners.FirstOrDefault(o => 
                        o.Works.ToUpper() == works.ToUpper() && 
                        o.Owner.ToUpper() == owner.ToUpper()
                        );
                }
            }
        }
        #endregion

        #region DRFReports Table Functions
        public static class DRFReport
        {
            /// <summary>
            /// Gets a single report from the DRFReport table using the primary key.
            /// </summary>
            /// <param name="drfIndex">The DRFIndex of the report you wish to return.</param>
            /// <returns>A single DRFReport.</returns>
            public static ElvisDataModel.EDMX.DRFReport GetSingle(int drfIndex)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.DRFReports.FirstOrDefault(r => r.DRFIndex == drfIndex);
                }
            }

            /// <summary>
            /// Gets a single report from the DRFReport table using the TibDelayIndex.
            /// </summary>
            /// <param name="tibDelayIndex">The Tib Delay Index associated with the Report.</param>
            /// <returns>A single DRFReport.</returns>
            public static ElvisDataModel.EDMX.DRFReport GetSingleWithDelayIndex(int tibDelayIndex)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.DRFReports.FirstOrDefault(r => r.TIBDelayIndex == tibDelayIndex);
                }
            }

            /// <summary>
            /// Gets all reports between two dates with filter options.
            /// </summary>
            /// <param name="dateFrom">The Date From.</param>
            /// <param name="dateTo">The Date To.</param>
            /// <param name="filter">The filter you wish to apply to the data.</param>
            /// <returns>A list of DRFReport objects containing the query results.</returns>
            public static List<ElvisDataModel.EDMX.DRFReport> GetAllWithFilter(DateTime dateFrom, DateTime dateTo, string filter)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.DRFReports.Where(r =>
                            r.StartDateTime >= dateFrom &&
                            r.StartDateTime <= dateTo)
                        .Where(filter)
                        .ToList();
                }
            }

            /// <summary>
            /// Adds a new DRF report to the database.
            /// </summary>
            /// <param name="reportToAdd">The report object you wish to add.</param>
            public static void AddNew(ElvisDataModel.EDMX.DRFReport reportToAdd)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ctx.AddToDRFReports(reportToAdd);
                    ctx.SaveChanges();
                }
            }

            /// <summary>
            /// Update existing DRF Report
            /// </summary>
            /// <param name="reportToUpdate">The report object you wish to update.</param>
            public static void Update(ElvisDataModel.EDMX.DRFReport reportToUpdate)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ElvisDataModel.EDMX.DRFReport drfReport = ctx.DRFReports.FirstOrDefault(t =>
                        t.DRFIndex == reportToUpdate.DRFIndex);

                    if (drfReport != null)
                    {
                        drfReport.Works = reportToUpdate.Works;
                        drfReport.Location = reportToUpdate.Location;
                        drfReport.PlantItem = reportToUpdate.PlantItem;
                        drfReport.StartDateTime = reportToUpdate.StartDateTime;
                        drfReport.DelayDuration = reportToUpdate.DelayDuration;
                        drfReport.InitiatorName = reportToUpdate.InitiatorName;
                        drfReport.ShortDescription = reportToUpdate.ShortDescription;
                        drfReport.Description = reportToUpdate.Description;
                        drfReport.ImmediateActions = reportToUpdate.ImmediateActions;
                        drfReport.RootCause = reportToUpdate.RootCause;
                        drfReport.CorrectiveMeasure = reportToUpdate.CorrectiveMeasure;
                        drfReport.OwnerName = reportToUpdate.OwnerName;
                        drfReport.Discipline = reportToUpdate.Discipline;
                        drfReport.DelayType = reportToUpdate.DelayType;
                        drfReport.Rota = reportToUpdate.Rota;
                        drfReport.Shift = reportToUpdate.Shift;
                        ctx.SaveChanges();
                    }
                }
            }

            /// <summary>
            /// Set DRF Report as Reviewed.
            /// </summary>
            /// <param name="reportToUpdate">The report object you wish to update.</param>
            public static void Review(ElvisDataModel.EDMX.DRFReport reportToUpdate)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ElvisDataModel.EDMX.DRFReport drfReport = ctx.DRFReports.FirstOrDefault(t =>
                        t.DRFIndex == reportToUpdate.DRFIndex);

                    if (drfReport != null)
                    {
                        drfReport.ReviewDate = DateTime.Now;
                        ctx.SaveChanges();
                    }
                }
            }

            /// <summary>
            /// Set DRF Report HasAttachment flag to true.
            /// </summary>
            /// <param name="reportToUpdate">The report object you wish to update.</param>
            /// <param name="hasAttachment">Defaults to true if not set.</param>
            public static void SetHasAttachment(int drfIndex, bool hasAttachment = true)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ElvisDataModel.EDMX.DRFReport drfReport = ctx.DRFReports.FirstOrDefault(t =>
                        t.DRFIndex == drfIndex);

                    if (drfReport != null)
                    {
                        drfReport.HasAttachments = hasAttachment;
                        ctx.SaveChanges();
                    }
                }
            }

            /// <summary>
            /// Open or Close a DRF Report.
            /// </summary>
            /// <param name="reportToUpdate">The report object you wish to update.</param>
            /// <param name="open">Open is true, close is false.</param>
            public static void OpenClose(ElvisDataModel.EDMX.DRFReport reportToUpdate, bool open)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ElvisDataModel.EDMX.DRFReport drfReport = ctx.DRFReports.FirstOrDefault(t =>
                        t.DRFIndex == reportToUpdate.DRFIndex);

                    if (drfReport != null)
                    {
                        drfReport.ClosureDate = DateTime.Now;
                        drfReport.ClosedByName = WindowsIdentity.GetCurrent().Name;
                        drfReport.ReportStatus = 1;

                        if (open)
                        {
                            drfReport.ClosureDate = null;
                            drfReport.ClosedByName = null;
                            drfReport.ReportStatus = 0;
                        }

                        ctx.SaveChanges();
                    }
                }
            }

            /// <summary>
            /// Removes any links with a certain tib delay so that the delay can be deleted.
            /// </summary>
            /// <param name="tibDelayIndex">The Tib Delay Index of the delay.</param>
            public static void RemoveTibDelayLinks(int tibDelayIndex)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    List<ElvisDataModel.EDMX.DRFReport> reportsWithLinks = ctx.DRFReports
                        .Where(r =>
                            r.TIBDelayIndex == tibDelayIndex)
                        .ToList();

                    foreach (ElvisDataModel.EDMX.DRFReport report in reportsWithLinks)
                    {
                        report.TIBDelayIndex = 0;
                        report.TIBIndex = null;
                    }
                    ctx.SaveChanges();
                }
            }

            /// <summary>
            /// Gets highest DRF Index Number from database.
            /// </summary>
            /// <returns>Highest DRF Index in the Database.</returns>
            public static int GetMaxDRFIndex()
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    if (ctx.DRFReports.Count() > 0)
                    {
                        return ctx.DRFReports.Max(r => r.DRFIndex);
                    }
                    return 0;
                }
            }

            /// <summary>
            /// Gets a list of DRF reports for a given time period.
            /// Uses dynamic link to enable selection using report status or not.
            /// </summary>
            /// <param name="query">Dynamic Linq Query.</param>
            /// <param name="dateFrom">The Date From.</param>
            /// <param name="dateTo">The Date To.</param>
            /// <returns>A list of DRFReports objects.</returns>
            public static List<ElvisDataModel.EDMX.DRFReport> GetDRFList(string query, DateTime dateFrom, DateTime dateTo)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.DRFReports
                        .Where(r => 
                            r.StartDateTime >= dateFrom && 
                            r.StartDateTime <= dateTo)
                        .Where(query)
                        .ToList();
                }
            }
        }
        #endregion

        #region ExtendAnalysisGridData View Functions
        public static class ExtendAnalysisGridData
        {
            /// <summary>
            /// VIEW - ExtendAnalysisGridData it gets the 
            /// extended heat analysis data.
            /// </summary>
            /// <param name="heatNumber">Heat Number.</param>
            /// <param name="heatNumberSet">Heat Number Set.</param>
            /// <returns>List of ExtendAnalysisGridData.</returns>
            public static List<ElvisDataModel.EDMX.ExtendAnalysisGridData> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.ExtendAnalysisGridDatas
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet)
                        .OrderBy(a => a.TimeStamp)
                        .ToList();
                }
            }
        }
        #endregion

        #region HeatDetailsEvent View Functions
        public static class HeatDetailsEvent
        {
            /// <summary>
            /// VIEW - HeatDetailsEvent, it gets the 
            /// Heat Details Events data.
            /// </summary>
            /// <param name="heatNumber">Heat Number.</param>
            /// <param name="heatNumberSet">Heat Number Set.</param>
            /// <returns>List of HeatDetailsEvents.</returns>
            public static List<ElvisDataModel.EDMX.HeatDetailsEvent> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.HeatDetailsEvents
                        .Where(t =>
                                t.HeatNumber == heatNumber &&
                                t.HNS == heatNumberSet)
                        .ToList();
                }
            }
        }
        #endregion

        #region I3 Table Functions
        public static class I3Report
        {
            /// <summary>
            /// Gets a single I3 report from the I3 table using the primary key.
            /// </summary>
            /// <param name="id">The Id of the report to return.</param>
            /// <returns>A single I3 report or null if none match the Id.</returns>
            public static ElvisDataModel.EDMX.I3s GetSingle(int id)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.I3s.FirstOrDefault(r => r.Id == id);
                }
            }

            /// <summary>
            /// Gets all reports created between the to and from dates and completed status.
            /// </summary>
            /// <param name="from">Minimum date.</param>
            /// <param name="to">Maximum date.</param>
            /// <param name="completed">Show only completed report if true, only uncompleted if false.</param>
            /// <returns>A list of I3 report objects.</returns>
            public static List<ElvisDataModel.EDMX.I3s> GetByDateRangeAndCompleted(DateTime from, DateTime to, bool completed)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.I3s
                        .Where(i3 =>
                            i3.Created >= from && 
                            i3.Created <= to &&
                            i3.Complete == completed)
                        .OrderByDescending(i => i.Created)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets all reports created between the to and from dates.
            /// </summary>
            /// <param name="from">Minimum date.</param>
            /// <param name="to">Maximum date.</param>
            /// <returns>A list of I3 report objects.</returns>
            public static List<ElvisDataModel.EDMX.I3s> GetByDateRange(DateTime from, DateTime to)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.I3s
                        .Where(i3 =>
                            i3.Created >= from &&
                            i3.Created <= to)
                        .OrderByDescending(i => i.Created)
                        .ToList();
                }
            }

            /// <summary>
            /// Adds a new I3 report to the database.
            /// </summary>
            /// <param name="report">The I3 record to be added.</param>
            public static void AddNew(ElvisDataModel.EDMX.I3s report)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ctx.AddToI3s(report);
                    ctx.SaveChanges();
                }
            }

            /// <summary>
            /// Update existing I3 Report.
            /// </summary>
            /// <param name="newReport">The new version of the report to update to.</param>
            public static void Update(ElvisDataModel.EDMX.I3s newReport)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ElvisDataModel.EDMX.I3s currentReport = ctx.I3s.FirstOrDefault(t =>
                        t.Id == newReport.Id);

                    if (currentReport != null)
                    {
                        currentReport.Created = newReport.Created;
                        currentReport.Shift = newReport.Shift;
                        currentReport.Title = newReport.Title;
                        currentReport.ShiftManager = newReport.ShiftManager;
                        currentReport.CompleteIn24Hrs = newReport.CompleteIn24Hrs;
                        currentReport.HigherLevelInvestigationRequired = newReport.HigherLevelInvestigationRequired;
                        currentReport.Trio = newReport.Trio;
                        currentReport.FeedBackBy = newReport.FeedBackBy;
                        currentReport.Complete = newReport.Complete;
                        ctx.SaveChanges();
                    }
                }
            }
        }
        #endregion

        #region TempAimsData View Functions
        public static class TempAimsData
        {
            /// <summary>
            /// VIEW - TempAimsData, it gets the 
            /// TempAimsData data.
            /// </summary>
            /// <param name="heatNumber">Heat Number.</param>
            /// <param name="heatNumberSet">Heat Number Set.</param>
            /// <returns>List of TempAimsData.</returns>
            public static List<ElvisDataModel.EDMX.TempAimsData> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TempAimsDatas
                      .Where(d => d.HeatNumber == heatNumber &&
                                  d.HNS == heatNumberSet)
                      .OrderByDescending(t => t.Temperature)
                      .ToList();
                }
            }
        }
        #endregion

        #region TempDipData View Functions
        public static class TempDipData
        {
            /// <summary>
            /// VIEW - TempDipData, it gets the 
            /// TempDipData data.
            /// </summary>
            /// <param name="heatNumber">Heat Number.</param>
            /// <param name="heatNumberSet">Heat Number Set.</param>
            /// <returns>List of TempDipData.</returns>
            public static List<ElvisDataModel.EDMX.TempDipData> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TempDipDatas
                              .Where(d => d.HeatNumber == heatNumber &&
                                          d.HNS == heatNumberSet &&
                                          d.Temperature.HasValue &&
                                          d.Temperature.Value > 0)
                              .OrderBy(a => a.TimeStamp)
                              .ToList();
                }
            }
        }
        #endregion
    }
}
