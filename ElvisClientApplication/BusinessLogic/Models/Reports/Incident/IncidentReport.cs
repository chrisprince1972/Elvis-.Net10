using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElvisDataModel.EDMX;
using ElvisDataModel;
using BusinessLogic.Models.Reports.Incident;

namespace BusinessLogic.Models.Reports.Incident
{
    public class IncidentReport
    {
        public int? IncidentId { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeClosed { get; set; }
        public Area ReportArea { get; set; }
        public Function ReportFunction { get; set; }
        public string Description { get; set; }
        public Status ReportStatus { get; set; }
        public IncidentOwner ReportOwner { get; set; }
        public List<IncidentAction> Actions { get; set; }
        public Boolean NewIncident = false;

        public IncidentReport()
        {
            ElvisDataModel.EDMX.IncidentReport report = new ElvisDataModel.EDMX.IncidentReport();
            NewIncident = true;
            SetUpObject(report);
        }

        public IncidentReport(int incidentId)
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                ElvisDataModel.EDMX.IncidentReport report
                    = ctx
                    .IncidentReports
                    .FirstOrDefault(r => r.IncidentId == IncidentId.Value);

                if (report != null)
                {
                    SetUpObject(report);
                }
            }
        }

        public IncidentReport(ElvisDataModel.EDMX.IncidentReport report)
        {
            SetUpObject(report);
        }

        public void Save(bool close)
        {
            if (NewIncident)
            {
                Insert(close);
            }
            else
            {
                Update(close);
            }

            foreach (IncidentAction ia in Actions)
            {
                ia.Save();
            }
            NewIncident = false;
        }


        public static List<IncidentReport> GetByDateRangeAndFilter(DateTime from, DateTime to
            , int? areaId = null, int? functionId = null, int? ownerId = null, Status.IncidentStatus? status = null)
        {


            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                return ctx.IncidentReports
                    .ToList()
                    .Where
                    (r =>
                        r.TimeStampCreated >= from
                        && r.TimeStampCreated < to.AddDays(1)
                        && (status.HasValue == false || r.IncidentStatus == (int)status.Value)
                        && (areaId.HasValue == false || r.AreaId == areaId.Value)
                        && (ownerId.HasValue == false || r.ReportOwnerID == ownerId.Value)
                        && (functionId.HasValue == false || r.FunctionId == functionId.Value)
                    )
                    .Select(r => new IncidentReport(r))
                    .ToList();
            }
        }

        public static DateTime GetEarliestTimeStampCreated(DateTime? from, DateTime? to
            , int? areaId = null, int? functionId = null, int? ownerId = null, Status.IncidentStatus? status = null)
        {


            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                DateTime returnDateTime;

                //check for existing records
                if (ctx.IncidentReports
                        .ToList()
                        .Where
                        (r =>
                               (from.HasValue == false || r.TimeStampCreated >= from.Value)
                            && (to.HasValue == false || r.TimeStampCreated < to.Value.AddDays(1))
                            && (status.HasValue == false || r.IncidentStatus == (int)status.Value)
                            && (areaId.HasValue == false || r.AreaId == areaId.Value)
                            && (ownerId.HasValue == false || r.ReportOwnerID == ownerId.Value)
                            && (functionId.HasValue == false || r.FunctionId == functionId.Value))
                        .Count() > 0)
                    {
                    IncidentReport ir = ctx.IncidentReports
                        .ToList()
                        .Where
                        (r =>
                               (from.HasValue == false || r.TimeStampCreated >= from.Value)
                            && (to.HasValue == false || r.TimeStampCreated < to.Value.AddDays(1))
                            && (status.HasValue == false || r.IncidentStatus == (int)status.Value)
                            && (areaId.HasValue == false || r.AreaId == areaId.Value)
                            && (ownerId.HasValue == false || r.ReportOwnerID == ownerId.Value)
                            && (functionId.HasValue == false || r.FunctionId == functionId.Value)
                        )
                        .Select(r => new IncidentReport(r))
                        .OrderBy(r => r.TimeCreated).First();

                    returnDateTime = ir.TimeCreated;
                }
                else
                {
                    returnDateTime=DateTime.MinValue;
                }

                return returnDateTime;
            }
        }

        public IncidentReportLookUpGridView ToLookUpGridView()
        {
            return new IncidentReportLookUpGridView(this);
        }

        private void SetUpObject(ElvisDataModel.EDMX.IncidentReport report)
        {
            IncidentId = report.IncidentId;
            TimeCreated = report.TimeStampCreated;
            TimeClosed = report.TimeStampClosed;
            ReportArea = (report.AreaLookUp == null) ? new Area() : new Area(report.AreaLookUp);
            ReportFunction = (report.FunctionLookUp == null) ? new Function() : new Function(report.FunctionLookUp);
            Description = report.IncidentDescription;
            ReportStatus = (report.StatusLookUp == null) ? new Status(Status.IncidentStatus.Open) : new Status(report.StatusLookUp);
            ReportOwner = (report.IncidentOwner == null) ? new IncidentOwner() : new IncidentOwner(report.IncidentOwner);
            Actions = report.IncidentActions.Select(r => new IncidentAction(r)).ToList();
        }

        private void Insert(bool close)
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                ElvisDataModel.EDMX.IncidentReport report = new ElvisDataModel.EDMX.IncidentReport();
                report.TimeStampCreated = DateTime.Now;
                if(close)
                {
                    report.TimeStampClosed = DateTime.Now;
                }
                report.AreaId = ReportArea.AreaId.Value;
                report.FunctionId = ReportFunction.FunctionId.Value;
                report.IncidentDescription = Description;
                report.IncidentStatus = ReportStatus.StatusId.Value;
                report.ReportOwnerID = (ReportOwner.OwnerId.Value == 0) ? default(int?) : ReportOwner.OwnerId.Value; //default(int?) is null
                ctx.AddToIncidentReports(report);
                ctx.SaveChanges();

                IncidentId = report.IncidentId;
                foreach (IncidentAction ia in Actions)
                {
                    ia.IncidentId = report.IncidentId;
                }
            }
        }

        private void Update(bool close)
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                ElvisDataModel.EDMX.IncidentReport report
                    = ctx
                    .IncidentReports
                    .FirstOrDefault(r => r.IncidentId == IncidentId.Value);

                if (report != null)
                {
                    report.IncidentId = IncidentId.Value;
                    if (close)
                    {
                        report.TimeStampClosed = DateTime.Now;
                    }
                    else
                    {
                        report.TimeStampClosed = null;
                    }
                    report.AreaId = ReportArea.AreaId.Value;
                    report.FunctionId = ReportFunction.FunctionId.Value;
                    report.IncidentDescription = Description;
                    report.IncidentStatus = ReportStatus.StatusId.Value;
                    report.ReportOwnerID = (ReportOwner.OwnerId.Value == 0) ? default(int?) : ReportOwner.OwnerId.Value; //default(int?) is null
                    ctx.SaveChanges();
                }
            }
        }

        public Boolean CheckAllActionsClosed()
        {
            Boolean bAllActionsClosed = true;

            foreach (IncidentAction ia in Actions)
            {
                bAllActionsClosed = ia.State.StatusId == (int)Status.IncidentStatus.Open ? false : bAllActionsClosed;
            }
            
            return bAllActionsClosed;
        }
    }
}
