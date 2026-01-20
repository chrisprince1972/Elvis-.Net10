using BusinessLogic.Constants;
using BusinessLogic.Constants.Trending.Dashboards;
using BusinessLogic.Models.TrendingShifts;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Models.ViewModels.TrendingShifts
{
    public class TrendShift
    {
        private List<KpiDataShiftWrapper> KpiData { get; set; }
        public List<KpiConfigShiftDataWrapper> KpiConfigs { get; private set; }
        public List<KPIDataMonth> KpiDataMonth { get; private set; }
        public TrendShift(ElvisSettings settings, DashboardType dashType, 
            int year, int month)
        {
            using (TrendSchemaEntities ctx = new TrendSchemaEntities(
                EntityHelper.ElvisDBSettings.ConnectionString))
            {
                DateTime dateFrom = new DateTime(year, month, 1);
                DateTime dateTo = new DateTime(year, month, 
                    dateFrom.AddMonths(1).AddSeconds(-1).Day);
                SetupData(settings, ctx, dateFrom, dateTo);
                SetupDataMonth(ctx, dateFrom);
                SetupConfiguations(settings, dashType, ctx);
            }
        }

        public List<Tuple<DateTime, Shift>> GetShiftsWithData(Rota rota)
        {
            return
                (
                    from kds in KpiData
                    where kds.Rota == rota
                    group kds by new { kds.Date, kds.Shift } into grp
                    select new Tuple<DateTime, Shift>
                            (grp.Key.Date, grp.Key.Shift)
                )
                .ToList();
        }


        public bool OneConfig(int level)
        {
            return
                (
                    from kc in KpiConfigs
                    where kc.Level == level
                    select kc
                )
                .ToList()
                .Count == 1;
        }

        private void SetupData(ElvisSettings settings,
            TrendSchemaEntities ctx, DateTime dateFrom, DateTime dateTo)
        {
            KpiData =
                    (
                    from kds in ctx.KPIDataShifts
                    where
                        kds.KPIDate >= dateFrom.Date &&
                        kds.KPIDate <= dateTo.Date
                    orderby kds.KPIDate, kds.KPIIndex
                    select kds
                    )
                    .ToList()
                    .Select
                    (r =>
                        new KpiDataShiftWrapper(settings, r)
                    )
                    .ToList();
        }
        private void SetupDataMonth(TrendSchemaEntities ctx, DateTime dateFrom)
        {
            KpiDataMonth =
                    (
                    from kdm in ctx.KPIDataMonths
                    where
                        kdm.KPIYear == dateFrom.Year &&
                        kdm.KPIMonth == dateFrom.Month
                    orderby kdm.KPIYear, kdm.KPIMonth, kdm.KPIIndex
                    select kdm
                    )
                    .ToList();
        }

        private void SetupConfiguations(ElvisSettings settings, 
            DashboardType dashType, TrendSchemaEntities ctx)
        {
            List<GroupConfig> GroupConfigs = ctx.GroupConfigs
                .Include("GroupHighlight")
                .OrderBy(p => p.GroupSort)
                .ToList();

            KpiConfigs =
                (
                    from kcs in ctx.KPIConfigShifts
                    where kcs.Dashboard == (int)dashType
                    orderby kcs.KPILevel, kcs.KPISubLevel
                    select kcs
                )
                .ToList()
                .Select
                (r =>
                    new KpiConfigShiftDataWrapper(settings, r, 
                    KpiData.Where(x => x.Index == r.KPIINdex).ToList(),
                            GroupConfigs,
                    KpiDataMonth.Where(x=> x.KPIIndex == r.KPIINdex).ToList())
                )
                .ToList();
        }
    }
}
