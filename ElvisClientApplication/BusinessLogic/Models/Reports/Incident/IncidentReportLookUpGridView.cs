using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Models.Reports.Incident;

namespace BusinessLogic.Models.Reports.Incident
{
    public class IncidentReportLookUpGridView
    {
        public int IncidentId { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeClosed { get; set; }
        public string Area { get; set; }
        public string Function { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Actions { get; set; }
        public int ClosedActions { get; set; }
        public string ReportOwner { get; set; }
        public IncidentReport Report { get; set; }

        public IncidentReportLookUpGridView(IncidentReport report)
        {
            Report = report;
            IncidentId = report.IncidentId.Value;
            TimeCreated = report.TimeCreated;
            TimeClosed = report.TimeClosed;
            Area = report.ReportArea.Description;
            Function = report.ReportFunction.Description;
            Description = report.Description;
            Status = report.ReportStatus.Description;
            ReportOwner = report.ReportOwner.OwnerDescription;
            Actions = report.Actions.Count();
            ClosedActions = report.Actions.Where(x => x.State.StatusId==2).Count();
        }

    }
}
