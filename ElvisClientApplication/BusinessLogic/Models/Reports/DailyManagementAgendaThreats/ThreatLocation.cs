using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Constants;
using ElvisDataModel.EDMX;
using ElvisDataModel;

namespace BusinessLogic.Models.Reports.DailyManagementAgendaThreats
{
    public class ThreatLocation
    {
        public ThreatLocationId LocationId { get; private set; }
        public string LocationDescription { get; private set; }

        public ThreatLocation(ElvisDataModel.EDMX.ThreatLocation threat)
        {
            LocationId = (ThreatLocationId)threat.ThreatLocationId;
            LocationDescription = threat.LocationName;
        }

        public static List<ThreatLocation> GetAllLocations()
        {
            using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                return ctx.ThreatLocations.ToList().Select(r => new ThreatLocation(r)).ToList();
            }
        }

        //Will throw exception if unable to find location.
        public static string GetLocationDescription(ThreatLocationId locId)
        {
            using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                int locationId = (int)locId;
                var location = ctx.ThreatLocations.FirstOrDefault(r => r.ThreatLocationId == locationId);
                return location.LocationName;
            }
        }

    }
}
