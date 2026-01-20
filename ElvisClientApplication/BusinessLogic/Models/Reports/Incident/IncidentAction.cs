using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElvisDataModel.EDMX;
using ElvisDataModel;

namespace BusinessLogic.Models.Reports.Incident
{
    public class IncidentAction
    {
        public int? IncidentActionId { get; set; }
        public int? IncidentId { get; set; }
        public string ActionDesc { get; set; }
        public IncidentOwner ActionOwner { get; set; }
        public DateTime TargetDate { get; set; }
        public Status State { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeClosed { get; set; }
        public string ClosedBy { get; set; }
        public Boolean NewAction = false;

        public IncidentAction()
        {
            ElvisDataModel.EDMX.IncidentAction act = new ElvisDataModel.EDMX.IncidentAction();
            NewAction = true;
            SetUpObject(act);
        }

        public IncidentAction(ElvisDataModel.EDMX.IncidentAction act)
        {
            SetUpObject(act);
        }

        public void Save()
        {
            if (NewAction)
            {
                Insert();
            }
            else
            {
                Update();
            }
            NewAction = false;
        }

        private void SetUpObject(ElvisDataModel.EDMX.IncidentAction action)
        {
            IncidentActionId = action.ActionId;
            IncidentId = action.IncidentId;
            ActionDesc = action.ActionDesc;
            ActionOwner = (action.IncidentOwner == null) ? new IncidentOwner() : new IncidentOwner(action.IncidentOwner);
            TargetDate = action.ActionTargetDate;
            State = (action.StatusLookUp == null) ? new Status(Status.IncidentStatus.Open) : new Status(action.StatusLookUp);
            TimeCreated = action.TimeStampCreated;
            TimeClosed = action.TimeStampClosed;
            ClosedBy = action.ClosedBy;
        }

        private void Insert()
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                ElvisDataModel.EDMX.IncidentAction action = new ElvisDataModel.EDMX.IncidentAction();
                action.IncidentId = IncidentId.Value;
                action.ActionDesc = ActionDesc;
                action.ActionOwner = ActionOwner.OwnerId.Value;
                action.ActionTargetDate = TargetDate;
                action.ActionStatus = State.StatusId.Value;
                action.TimeStampCreated = TimeCreated;
                action.TimeStampClosed = TimeClosed;
                action.ClosedBy = ClosedBy;
                ctx.AddToIncidentActions(action);
                ctx.SaveChanges();
                IncidentActionId = action.ActionId;
            }
        }

        private void Update()
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                ElvisDataModel.EDMX.IncidentAction action
                    = ctx
                    .IncidentActions
                    .FirstOrDefault(r => r.ActionId == IncidentActionId.Value);

                if (action != null)
                {
                    action.ActionDesc = ActionDesc;
                    action.ActionOwner = ActionOwner.OwnerId.Value;
                    action.ActionTargetDate = TargetDate;
                    action.ActionStatus = State.StatusId.Value;
                    action.TimeStampCreated = TimeCreated;
                    action.TimeStampClosed = TimeClosed;
                    action.ClosedBy = ClosedBy;
                    ctx.SaveChanges();
                }
            }
        }

        public static List<IncidentAction> ByIncidentId(int incidentId)
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                return ctx.IncidentActions
                    .Where(r => r.IncidentId == incidentId)
                    .ToList()
                    .Select(r => new IncidentAction(r))
                    .ToList();
            }
        }

    }
}
