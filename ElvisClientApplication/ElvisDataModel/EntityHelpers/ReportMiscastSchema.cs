using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Dynamic;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {

        #region LookupStandardPracticeFollowed Functions
        public static class LookupStandardPracticeFollowed
        {
            public enum StandarPrictiseFollowedTypes
            {
                Followed = 1,
                NotFollowed,
                DoesNotExist
            }
            public static List<EDMX.LookupStandardPracticeFollowed> GetAll()
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.LookupStandardPracticeFolloweds
                        .OrderBy(a => a.Id)
                        .ToList();
                }
            }
        }
        #endregion


        #region MiscastActions Functions
        public static class MiscastActions
        {
            public static List<EDMX.MiscastAction> GetByMiscastID(int miscastID)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastActions
                        .Where(m => m.MiscastID == miscastID)
                        .OrderBy(a => a.TargetDate)
                        .ToList();
                }
            }

            public static void Update(MiscastAction miscastActionNewValues)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    EDMX.MiscastAction miscastAction = ctx.MiscastActions
                        .FirstOrDefault(t => t.MiscastActionID == miscastActionNewValues.MiscastActionID);

                    if (miscastAction != null)
                    {
                        miscastAction.ActionText = miscastActionNewValues.ActionText;
                        miscastAction.ActionOwnerID = miscastActionNewValues.ActionOwnerID;
                        miscastAction.TargetDate = miscastActionNewValues.TargetDate;
                        miscastAction.ActionState = miscastActionNewValues.ActionState;

                        ctx.SaveChanges();
                    }
                }
            }

            public static void AddNew(MiscastAction miscastAction)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    if (miscastAction != null)
                    {
                        ctx.AddToMiscastActions(miscastAction);
                        ctx.SaveChanges();
                    }
                }
            }

            public static void Delete(MiscastAction miscastAction)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    EDMX.MiscastAction recordToDelete = ctx.MiscastActions
                        .FirstOrDefault(m => m.MiscastActionID == miscastAction.MiscastActionID);

                    if (recordToDelete != null)
                    {
                        ctx.MiscastActions.DeleteObject(recordToDelete);
                        ctx.SaveChanges();
                    }
                }
            }
        }
        #endregion

        #region MiscastActionsReportView VIEW
        public static class MiscastActionsReportView
        {
            /// <summary>
            /// Gets Miscast Actions Report View Data.
            /// </summary>
            /// <param name="filter">The filter.</param>
            /// <param name="showAll">Show all actions rather than just outstanding ones.</param>
            /// <returns>List of MiscastActionsReportView Objects.</returns>
            public static List<EDMX.MiscastActionsReportView> GetByFilter(string filter, bool showAll)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    if (showAll)
                    {
                        return ctx.MiscastActionsReportViews
                            .Where(filter)
                            .OrderByDescending(a => a.TargetDate)
                            .Take(200)//This could potentially return all records in database so limit them
                            .ToList();
                    }
                    else
                    {   //Filter on Action Status
                        return ctx.MiscastActionsReportViews
                            .Where(m => !m.ActionState)
                            .Where(filter)
                            .OrderByDescending(a => a.TargetDate)
                            .ToList();
                    }
                }
            }
        }
        #endregion

        #region MiscastAreaResponsible Functions
        public static class MiscastAreaResponsible
        {
            public static List<EDMX.MiscastAreaResponsible> GetAll()
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastAreaResponsibles
                        .OrderBy(a => a.Sort)
                        .ToList();
                }
            }
        }
        #endregion

        #region MiscastFailureMode Functions
        public static class MiscastFailureMode
        {
            public static List<EDMX.MiscastFailureMode> GetAll()
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastFailureModes
                        .OrderBy(a => a.Sort)
                        .ToList();
                }
            }
        }
        #endregion

        #region MiscastFunction Functions
        public static class MiscastFunction
        {
            public static List<EDMX.MiscastFunction> GetAll()
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastFunctions
                        .OrderBy(a => a.Sort)
                        .ToList();
                }
            }
        }
        #endregion

        #region MiscastInvestigation Functions
        public static class MiscastInvestigation
        {
            public static void AddNew(EDMX.MiscastInvestigation investigation)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    if (investigation != null)
                    {
                        ctx.AddToMiscastInvestigations(investigation);
                        ctx.SaveChanges();

                        EDMX.MiscastWhy why = new EDMX.MiscastWhy()
                        {
                            InvestigationID = investigation.InvestigationID,
                            WhyText = ""
                        };
                        ctx.AddToMiscastWhies(why);
                        ctx.SaveChanges();
                    }
                }
            }

            public static void DeleteByID(int investigationID)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    EDMX.MiscastInvestigation recordToDelete = ctx.MiscastInvestigations
                        .FirstOrDefault(m => m.InvestigationID == investigationID);

                    if (recordToDelete != null)
                    {
                        foreach (EDMX.MiscastWhy why in recordToDelete.MiscastWhies.ToList())
                        {
                            ctx.MiscastWhies.DeleteObject(why);
                        }
                        ctx.SaveChanges();

                        ctx.MiscastInvestigations.DeleteObject(recordToDelete);
                        ctx.SaveChanges();
                    }
                }
            }
        }
        #endregion

        #region MiscastMain Functions
        public static class MiscastMain
        {
            /// <summary>
            /// Gets Miscast Data for the last X days.
            /// </summary>
            /// <returns>List of MiscastMain Objects.</returns>
            public static List<EDMX.MiscastMain> GetLastXDays(int xDays)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.MiscastMains
                        .Include("MiscastType")//All you need is the type.
                        .Where(p => p.TapTime >= dtXDaysAgo)
                        .OrderByDescending(o => o.TapTime)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets Miscast Data between two dates and subject to a filter.
            /// </summary>
            /// <param name="dateFrom">The date you want to filter from.</param>
            /// <param name="dateTo">The date you want to filter to.</param>
            /// <param name="filter">The filter you wish to apply to the data.</param>
            /// <returns>List of MiscastMain Objects.</returns>
            public static List<EDMX.MiscastMain> GetByDateAndFilter(DateTime dateFrom, DateTime dateTo, string filter)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastMains
                        .Include("MiscastActions")
                        .Include("MiscastActions.MiscastOwner")
                        .Include("MiscastAreaResponsible")
                        .Include("MiscastFailureMode")
                        .Include("MiscastFunction")
                        .Include("MiscastInvestigations")
                        .Include("MiscastInvestigations.MiscastAreaResponsible")
                        .Include("MiscastInvestigations.MiscastWhies")
                        .Include("MiscastOwner")
                        .Include("MiscastRootCause")
                        .Include("MiscastRota")
                        .Include("MiscastType")
                        .Include("MiscastUnit")
                        .Include("MiscastStatu")
                        .Where(p =>
                            p.TapTime >= dateFrom &&
                            p.TapTime < dateTo)
                        .Where(filter)
                        .OrderByDescending(o => o.TapTime)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets a single miscast record by ID.
            /// </summary>
            /// <param name="miscastID">The ID of the miscast in question.</param>
            /// <returns>A MiscastMain Object.</returns>
            public static EDMX.MiscastMain GetByID(int miscastID)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastMains
                        .Include("MiscastActions")
                        .Include("MiscastActions.MiscastOwner")
                        .Include("MiscastAreaResponsible")
                        .Include("MiscastFailureMode")
                        .Include("MiscastFunction")
                        .Include("MiscastInvestigations")
                        .Include("MiscastInvestigations.MiscastAreaResponsible")
                        .Include("MiscastInvestigations.MiscastWhies")
                        .Include("MiscastOwner")
                        .Include("MiscastRootCause")
                        .Include("MiscastRota")
                        .Include("MiscastType")
                        .Include("MiscastUnit")
                        .Include("MiscastStatu")
                        .FirstOrDefault(p => p.MiscastID == miscastID);
                }
            }

            /// <summary>
            /// Gets a single miscast record by Heat Number.
            /// </summary>
            /// <param name="heatNo">The Heat Number.</param>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <returns>A MiscastMain Object.</returns>
            public static EDMX.MiscastMain GetByHeatNumber(int heatNo, int heatNumberSet)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastMains
                        .Include("MiscastActions")
                        .Include("MiscastActions.MiscastOwner")
                        .Include("MiscastAreaResponsible")
                        .Include("MiscastFailureMode")
                        .Include("MiscastFunction")
                        .Include("MiscastInvestigations")
                        .Include("MiscastInvestigations.MiscastAreaResponsible")
                        .Include("MiscastInvestigations.MiscastWhies")
                        .Include("MiscastOwner")
                        .Include("MiscastRootCause")
                        .Include("MiscastRota")
                        .Include("MiscastType")
                        .Include("MiscastUnit")
                        .Include("MiscastStatu")
                        .FirstOrDefault(p =>
                            p.HeatNumber == heatNo &&
                            p.HeatNumberSet == heatNumberSet);
                }
            }

            /// <summary>
            /// Adds a new Miscast Main record to the database.
            /// </summary>
            /// <param name="newMiscast">The new Miscast to add.</param>
            public static void AddNew(EDMX.MiscastMain newMiscast)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ctx.MiscastMains.AddObject(newMiscast);
                    ctx.SaveChanges();

                    EDMX.MiscastInvestigation newInvestigation = new EDMX.MiscastInvestigation()
                    {
                        MiscastID = newMiscast.MiscastID,
                        InvestigationNumber = 0,
                        AreaResponsibleID = 2//2 is Area: Not Set
                    };

                    ctx.MiscastInvestigations.AddObject(newInvestigation);
                    ctx.SaveChanges();

                    EDMX.MiscastWhy newWhy = new EDMX.MiscastWhy()
                    {
                        InvestigationID = newInvestigation.InvestigationID,
                        SortNumber = 0,
                        WhyText = ""
                    };

                    ctx.MiscastWhies.AddObject(newWhy);
                    ctx.SaveChanges();
                }
            }

            /// <summary>
            /// Edit existing Miscast.
            /// </summary>
            /// <param name="miscastNewValues">The new values to be update the database record.</param>
            /// <returns>Boolean stating success or failure.</returns>
            public static bool EditExisting(EDMX.MiscastMain miscastNewValues)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    EDMX.MiscastMain miscast = ctx.MiscastMains
                        .Include("MiscastInvestigations")
                        .Include("MiscastInvestigations.MiscastWhies")
                        .FirstOrDefault(t => t.MiscastID == miscastNewValues.MiscastID);

                    if (miscast != null)
                    {
                        //miscast.HeatNumber = miscastNewValues.HeatNumber;//Doesn't change.
                        miscast.OrderedGrade = miscastNewValues.OrderedGrade;
                        miscast.MadeGrade = miscastNewValues.MadeGrade;
                        miscast.HotConnect = miscastNewValues.HotConnect;
                        miscast.MiscastRotaID = miscastNewValues.MiscastRotaID;
                        miscast.MiscastTypeID = miscastNewValues.MiscastTypeID;
                        miscast.MiscastFailureModeID = miscastNewValues.MiscastFailureModeID;
                        miscast.MiscastAreaResponsibleID = miscastNewValues.MiscastAreaResponsibleID;
                        miscast.MiscastUnitID = miscastNewValues.MiscastUnitID;
                        miscast.MiscastFunctionID = miscastNewValues.MiscastFunctionID;
                        miscast.ProblemStatement = miscastNewValues.ProblemStatement;
                        miscast.ProblemStatementName = miscastNewValues.ProblemStatementName;
                        miscast.InstallationGoodCondition = miscastNewValues.InstallationGoodCondition;
                        miscast.StandardPracticeFollowedID = miscastNewValues.StandardPracticeFollowedID;
                        miscast.ContainmentAction = miscastNewValues.ContainmentAction;
                        miscast.ShiftComments = miscastNewValues.ShiftComments;
                        miscast.ShiftName = miscastNewValues.ShiftName;
                        miscast.ShiftComplete = miscastNewValues.ShiftComplete;
                        miscast.TechComments = miscastNewValues.TechComments;
                        miscast.TechNameID = miscastNewValues.TechNameID;
                        miscast.RootCauseID = miscastNewValues.RootCauseID;
                        miscast.TechComplete = miscastNewValues.TechComplete;
                        //miscast.DateRaised = miscastNewValues.DateRaised;//Doesn't change.
                        miscast.LastEdit = miscastNewValues.LastEdit;
                        //miscast.TapTime = miscastNewValues.TapTime;//Doesn't change.
                        miscast.MiscastStatusID = miscastNewValues.MiscastStatusID;

                        foreach (EDMX.MiscastInvestigation investigationNewValues in
                            miscastNewValues.MiscastInvestigations)
                        {
                            EDMX.MiscastInvestigation investigation = miscast.MiscastInvestigations
                                .FirstOrDefault(m => m.InvestigationID == investigationNewValues.InvestigationID);

                            if (investigation != null)
                            {
                                investigation.AreaResponsibleID = investigationNewValues.AreaResponsibleID;
                                investigation.Investigator = investigationNewValues.Investigator;
                                investigation.ProblemStatement = investigationNewValues.ProblemStatement;
                                investigation.RootCause = investigationNewValues.RootCause;

                                foreach (EDMX.MiscastWhy whyNewValues in investigationNewValues.MiscastWhies)
                                {
                                    EDMX.MiscastWhy why = investigation.MiscastWhies
                                        .FirstOrDefault(w => w.WhyID == whyNewValues.WhyID);

                                    if (why != null)
                                    {
                                        why.WhyText = whyNewValues.WhyText;
                                    }
                                }
                            }
                        }

                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }

            public static void Delete(int miscastID)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    EDMX.MiscastMain recordToDelete = ctx.MiscastMains
                        .Include("MiscastInvestigations")
                        .Include("MiscastInvestigations.MiscastWhies")
                        .Include("MiscastActions")
                        .FirstOrDefault(m => m.MiscastID == miscastID);

                    if (recordToDelete != null)
                    {
                        //Delete all the Investigations + Whys
                        foreach (EDMX.MiscastInvestigation investigation in
                            recordToDelete.MiscastInvestigations.ToList())
                        {
                            foreach (EDMX.MiscastWhy why in investigation.MiscastWhies.ToList())
                            {
                                ctx.MiscastWhies.DeleteObject(why);
                            }
                            ctx.SaveChanges();
                            ctx.MiscastInvestigations.DeleteObject(investigation);
                        }
                        ctx.SaveChanges();

                        //Delete all the Actions
                        foreach (EDMX.MiscastAction action in recordToDelete.MiscastActions.ToList())
                        {
                            ctx.MiscastActions.DeleteObject(action);
                        }

                        //Finally Delete the Miscast
                        ctx.MiscastMains.DeleteObject(recordToDelete);
                        ctx.SaveChanges();
                    }
                }
            }

            public static bool UpdateStatus(int miscastID, int statusID)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    EDMX.MiscastMain miscast = ctx.MiscastMains
                        .FirstOrDefault(t => t.MiscastID == miscastID);

                    if (miscast != null)
                    {
                        miscast.MiscastStatusID = statusID;
                        ctx.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
        }
        #endregion

        #region MiscastOwners Functions
        public static class MiscastOwners
        {
            public static List<EDMX.MiscastOwner> GetAll()
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastOwners
                        .OrderBy(a => a.OwnerName)
                        .ToList();
                }
            }
        }
        #endregion

        #region MiscastReportView VIEW
        public static class MiscastReportView
        {
            /// <summary>
            /// Gets Miscast Report View Data between two dates and filter.
            /// </summary>
            /// <param name="dateFrom">The date you want to filter from.</param>
            /// <param name="dateTo">The date you want to filter to.</param>
            /// <param name="filter">The filter to filter the data.</param>
            /// <returns>List of MiscastReportView Objects.</returns>
            public static List<EDMX.MiscastReportView> GetByDateAndFilter(
                DateTime dateFrom, DateTime dateTo, string filter)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastReportViews
                        .Where(p =>
                            p.TapTime >= dateFrom &&
                            p.TapTime < dateTo)
                        .Where(filter)
                        .OrderByDescending(o => o.TapTime)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets a single miscast record by Heat Number.
            /// </summary>
            /// <param name="heatNo">The Heat Number.</param>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <returns>A MiscastMain Object.</returns>
            public static EDMX.MiscastReportView GetByHeatNumber(int heatNo, int heatNumberSet)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastReportViews
                        .FirstOrDefault(p =>
                            p.HeatNumber == heatNo &&
                            p.HeatNumberSet == heatNumberSet);
                }
            }
        }
        #endregion

        #region MiscastRootCause Functions
        public static class MiscastRootCause
        {
            public enum MiscastRootCauseTypes
            {
                StandardPracticeNotFollowed = 1,
                StandardPracticeInadequate,
                OperatorError,
                ProcessCapability,
                SLAFailure,
                EquipmentFailure,
                NotSet
            }
            public static List<EDMX.MiscastRootCause> GetAll()
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastRootCauses
                        .OrderBy(a => a.Sort)
                        .ToList();
                }
            }
        }
        #endregion

        #region MiscastRota Functions
        public static class MiscastRota
        {
            public static List<EDMX.MiscastRota> GetAll()
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastRotas
                        .OrderBy(a => a.Sort)
                        .ToList();
                }
            }
        }
        #endregion

        #region MiscastStatus Functions
        public static class MiscastStatus
        {
            public static List<EDMX.MiscastStatu> GetAll()
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastStatus
                        .OrderBy(a => a.Sort)
                        .ToList();
                }
            }
        }
        #endregion

        #region MiscastType Functions
        public static class MiscastType
        {
            public static List<EDMX.MiscastType> GetAll()
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastTypes
                        .OrderBy(a => a.Sort)
                        .ToList();
                }
            }
        }
        #endregion

        #region MiscastUnit Functions
        public static class MiscastUnit
        {
            public static List<EDMX.MiscastUnit> GetAll()
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.MiscastUnits
                        .OrderBy(a => a.Sort)
                        .ToList();
                }
            }
        }
        #endregion

        #region MiscastWhy Functions
        public static class MiscastWhy
        {
            public static void AddNew(EDMX.MiscastWhy why)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    if (why != null)
                    {
                        why.SortNumber = 0;

                        List<EDMX.MiscastWhy> whys = ctx.MiscastWhies
                            .Where(m => m.InvestigationID == why.InvestigationID)
                            .ToList();

                        if (whys != null && whys.Count > 0)
                        {
                            why.SortNumber = whys.Count;
                        }

                        ctx.AddToMiscastWhies(why);
                        ctx.SaveChanges();
                    }
                }
            }

            public static void DeleteByID(int whyID)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    EDMX.MiscastWhy recordToDelete = ctx.MiscastWhies
                        .FirstOrDefault(w => w.WhyID == whyID);

                    if (recordToDelete != null)
                    {
                        ctx.MiscastWhies.DeleteObject(recordToDelete);
                        ctx.SaveChanges();
                    }
                }
            }

            public static List<EDMX.MiscastWhy> GetByInvestigationIDs(
                EntityCollection<EDMX.MiscastInvestigation> investigations)
            {
                using (ReportMiscastSchemaEntities ctx = new ReportMiscastSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    List<EDMX.MiscastWhy> whys = new List<EDMX.MiscastWhy>();

                    foreach (EDMX.MiscastInvestigation investigation in investigations)
                    {
                        if (investigation != null)
                        {
                            whys.AddRange(ctx.MiscastWhies
                                .Include("MiscastInvestigation")
                                .Where(w => w.InvestigationID == investigation.InvestigationID)
                                .ToList());
                        }
                    }

                    return whys;
                }
            }
        }
        #endregion
    }
}
