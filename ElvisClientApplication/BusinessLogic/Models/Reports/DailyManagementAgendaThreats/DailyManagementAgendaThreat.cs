using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElvisDataModel.EDMX;
using ElvisDataModel;
using BusinessLogic.Constants;
using BusinessLogic.Models.ViewModels.Reports;

namespace BusinessLogic.Models.Reports.DailyManagementAgendaThreats
{
    public class DailyManagementAgendaThreat
    {
        public int? DmaThreatId { get; private set; }
        public ThreatLocationId ThreatLocationId { get; private set; }
        public ThreatTimescales ThreatTimeScaleId { get; private set; }
        public string Threat { get; set; }

        public DailyManagementAgendaThreat(ElvisDataModel.EDMX.MangementAgendaThreat dma)
        {
            DmaThreatId = dma.DmaThreatId;
            ThreatLocationId = (ThreatLocationId)dma.ThreatLocationId;
            ThreatTimeScaleId = (ThreatTimescales)dma.ThreatTimeScaleId;
            Threat = dma.Threat;
        }


        public void Save()
        {
            if (DmaThreatId.HasValue)
            {
                Update();
            }
            else
            {
                Insert();
            }
        }

        //will throw an excepition if it fails to find a record with the classes id.
        public void Reload()
        {

            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                ElvisDataModel.EDMX.MangementAgendaThreat dma = 
                    (
                        from mat in ctx.MangementAgendaThreats
                        where mat.DmaThreatId == DmaThreatId
                        select mat
                    ).FirstOrDefault();
                
                DmaThreatId = dma.DmaThreatId;
                ThreatLocationId = (ThreatLocationId)dma.ThreatLocationId;
                ThreatTimeScaleId = (ThreatTimescales)dma.ThreatTimeScaleId;
                Threat = dma.Threat;
            }
        }


        public static List<DailyManagementAgendaThreatIndex> GetAllAgendas()
        {
            List<DailyManagementAgendaThreatIndex> returnValue =
                new List<DailyManagementAgendaThreatIndex>();

            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                List<ThreatLocation> locations = ThreatLocation.GetAllLocations().Where(r=>r.LocationId != ThreatLocationId.Unknown).ToList();
                List<ElvisDataModel.EDMX.MangementAgendaThreat> threats = ctx.MangementAgendaThreats.ToList();

                foreach (ThreatLocation loc in locations)
                {
                    ElvisDataModel.EDMX.MangementAgendaThreat shortTermThreat = GetOrCreate(threats, loc.LocationId, ThreatTimescales.Hour24Threat);
                    ElvisDataModel.EDMX.MangementAgendaThreat longTermThreat = GetOrCreate(threats, loc.LocationId, ThreatTimescales.LongTermPm);

                    DailyManagementAgendaThreat shortTerm = new DailyManagementAgendaThreat(shortTermThreat);
                    DailyManagementAgendaThreat longTerm = new DailyManagementAgendaThreat(longTermThreat);
                    DailyManagementAgendaThreatIndex threatToAdd =
                        new DailyManagementAgendaThreatIndex(loc, shortTerm, longTerm);

                    returnValue.Add(threatToAdd);
                }

                return returnValue;
            }
        }

        private static ElvisDataModel.EDMX.MangementAgendaThreat GetOrCreate(
            List<ElvisDataModel.EDMX.MangementAgendaThreat> threats, ThreatLocationId location, ThreatTimescales timescale)
        {
            
            ElvisDataModel.EDMX.MangementAgendaThreat threat = threats
                .FirstOrDefault(r =>
                    r.ThreatLocationId == (int)location
                    && r.ThreatTimeScaleId == (int)timescale
                );

            if (threat == null)
            {
                using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    threat = new MangementAgendaThreat()
                    {
                        ThreatLocationId = (int)location,
                        ThreatTimeScaleId = (int)timescale,
                        Threat = string.Empty
                    };

                    ctx.AddToMangementAgendaThreats(threat);
                    ctx.SaveChanges();
                }

            }
            return threat;
        }

        private void Update()
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                MangementAgendaThreat dma = ctx.MangementAgendaThreats.FirstOrDefault(r => r.DmaThreatId == DmaThreatId);

                if (dma != null)
                {
                    dma.ThreatLocationId = (int)ThreatLocationId;
                    dma.ThreatTimeScaleId = (int)ThreatTimeScaleId;
                    dma.Threat = Threat;
                }

                ctx.SaveChanges();
            }
        }

        private void Insert()
        {
            using (ReportSchemaEntities ctx = new ReportSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                MangementAgendaThreat dma = new MangementAgendaThreat()
                {
                    ThreatLocationId = (int)ThreatLocationId,
                    ThreatTimeScaleId = (int)ThreatTimeScaleId,
                    Threat = Threat
                };
                ctx.AddToMangementAgendaThreats(dma);
                ctx.SaveChanges();
                DmaThreatId = dma.DmaThreatId;
            }
        }


    }
}
