using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Constants;
using ElvisDataModel.EDMX;
using ElvisDataModel;

namespace BusinessLogic.Models.Reports.DailyManagementAgendaThreats
{
    public class ThreatTimeScale
    {
        public ThreatTimescales TimeScaleId { get; private set; }
        public string TimeScaleDescription { get; private set; }

        public ThreatTimeScale(ElvisDataModel.EDMX.ThreatTimeScale timeScale)
        {
            TimeScaleId = (ThreatTimescales)timeScale.ThreatTimeScaleId;
            TimeScaleDescription = timeScale.TimeScaleName;
        }

        public static List<ThreatLocation> GetAllTimeScale()
        {
            using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                return ctx.ThreatLocations.ToList().Select(r => new ThreatLocation(r)).ToList();
            }
        }

        //Will throw exception if unable to find location.
        public static string GetTimeScaleDescription(ThreatTimescales timeScaleId)
        {
            using (ConfigSchemaEntities ctx = new ConfigSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                int timeScaleIdAsInt = (int)timeScaleId;
                var timeScale = ctx.ThreatTimeScales.FirstOrDefault(r => r.ThreatTimeScaleId == timeScaleIdAsInt);
                return timeScale.TimeScaleName;
            }
        }

    }
}
