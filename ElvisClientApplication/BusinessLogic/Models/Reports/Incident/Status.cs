using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElvisDataModel.EDMX;
using ElvisDataModel;

namespace BusinessLogic.Models.Reports.Incident
{

    public class Status
    {
        public int? StatusId { get; set; }
        public string Description { get; set; }
        //public IncidentStatus Status { get { return (IncidentStatus)StatusId.Value; } }

        public enum IncidentStatus
        {
            Open = 1,
            Close = 2
        }

        public Status(IncidentStatus status)
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                ElvisDataModel.EDMX.StatusLookUp statusLU
                    = ctx
                    .StatusLookUps
                    .FirstOrDefault(r => r.StatusId == (int)status);

                if (statusLU != null)
                {
                    SetUpObject(statusLU);
                }
            }
        }

        public Status(ElvisDataModel.EDMX.StatusLookUp status)
        {
            SetUpObject(status);
        }

        private void SetUpObject(ElvisDataModel.EDMX.StatusLookUp status)
        {
            StatusId = status.StatusId;
            Description = status.StatusDesc;
        }
    }
}
