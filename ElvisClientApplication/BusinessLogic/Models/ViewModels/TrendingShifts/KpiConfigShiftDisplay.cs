using BusinessLogic.Constants.Trending.Dashboards;
using BusinessLogic.Models.TrendingShifts;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Models.ViewModels.TrendingShifts
{
    public class KpiConfigShiftDisplay
    {
        public IEnumerable<KpiConfigShiftWrapper> Configurations { get; private set; }
        public IEnumerable<GroupConfig> GroupConfigs { get; private set; }
        public IEnumerable<KPIActionRule> KpiActions { get; private set; }

        public KpiConfigShiftDisplay (ElvisSettings settings)
        {

            using (TrendSchemaEntities ctx = new TrendSchemaEntities(
                EntityHelper.ElvisDBSettings.ConnectionString))
            {
                GroupConfigs = ctx.GroupConfigs
                .Include("GroupHighlight")
                .Where(g => g.DisplayCode == 1)
                .OrderBy(p => p.GroupSort)
                .ToList();

                Configurations = KpiConfigShiftWrapper.All(settings, GroupConfigs);

                KpiActions = ctx.KPIActionRules.ToList();

            }

        }

        public IEnumerable<KpiConfigShiftWrapper> GetTopLevelConfigurations(
            DashboardType dashboard)
        {
            return (from conf in Configurations
                    where conf.Dashboard == dashboard &&
                    conf.SubLevel == 0 
                    select conf).ToList();
        }
        public IEnumerable<KpiConfigShiftWrapper> GetSubLevelConfigurations(
            DashboardType dashboard, int level)
        {
            return (from conf in Configurations
                    where conf.Dashboard == dashboard &&
                    conf.Level == level &&
                    conf.SubLevel > 0
                    select conf).ToList();
        }

    }
}
