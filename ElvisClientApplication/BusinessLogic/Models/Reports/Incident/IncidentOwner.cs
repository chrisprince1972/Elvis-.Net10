using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElvisDataModel.EDMX;
using ElvisDataModel;

namespace BusinessLogic.Models.Reports.Incident
{
    public class IncidentOwner
    {
        public int? OwnerId { get; set; }
        public string OwnerDescription { get; set; }
        public string OwnerEmail { get; set; }

        public IncidentOwner()
        {
            ElvisDataModel.EDMX.IncidentOwner incidentOwner = new ElvisDataModel.EDMX.IncidentOwner();
            List<IncidentOwner> incidentOwners = GetAllIncidentOwnersPlusOther("-");
            incidentOwner.OwnerId = incidentOwners[0].OwnerId.Value;
            incidentOwner.OwnerDesc = incidentOwners[0].OwnerDescription;
            incidentOwner.OwnerEmail = incidentOwners[0].OwnerEmail;
            SetUpObject(incidentOwner);
        }

        public IncidentOwner(string other)
        {
            ElvisDataModel.EDMX.IncidentOwner incidentOwner = new ElvisDataModel.EDMX.IncidentOwner();
            List<IncidentOwner> incidentOwners = GetAllIncidentOwnersPlusOther(other);
            incidentOwner.OwnerId = incidentOwners[0].OwnerId.Value;
            incidentOwner.OwnerDesc = incidentOwners[0].OwnerDescription;
            incidentOwner.OwnerEmail = incidentOwners[0].OwnerEmail;
            SetUpObject(incidentOwner);
        }

        public IncidentOwner(ElvisDataModel.EDMX.IncidentOwner owner)
        {
            SetUpObject(owner);
        }

        public IncidentOwner(int newOwnerID, string newDescription, string newEmail)
        {
            ElvisDataModel.EDMX.IncidentOwner incidentOwner = new ElvisDataModel.EDMX.IncidentOwner();
            incidentOwner.OwnerId = newOwnerID;
            incidentOwner.OwnerDesc = newDescription;
            incidentOwner.OwnerEmail = newEmail;
            SetUpObject(incidentOwner);
        }

        private void SetUpObject(ElvisDataModel.EDMX.IncidentOwner owner)
        {
            OwnerId = owner.OwnerId;
            OwnerDescription = owner.OwnerDesc;
            OwnerEmail = owner.OwnerEmail;
        }

        public static List<IncidentOwner> GetAllIncidentOwners()
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                return ctx.IncidentOwners.ToList().Select(r => new IncidentOwner(r)).OrderBy(r => r.OwnerDescription).ToList();
            }
        }
        /// <summary>
        /// Gets full list and adds a row at position 0 for an "other" option, useful for drop down lists.
        /// </summary>
        public static List<IncidentOwner> GetAllIncidentOwnersPlusOther(string other)
        {
            List<IncidentOwner> allItems;
            allItems = GetAllIncidentOwners();

            IncidentOwner allItem = new IncidentOwner(0, other, null);

            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                allItems = ctx.IncidentOwners.ToList().Select(r => new IncidentOwner(r)).OrderBy(r => r.OwnerDescription).ToList();
                allItems.Insert(0, allItem);
                return allItems;
            }
        }

    }
}
