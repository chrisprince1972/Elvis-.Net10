using BusinessLogic.Constants.Trending.Dashboards;
using ElvisDataModel.EDMX;

namespace BusinessLogic.Models.TrendingShifts
{
    public class KpiAction
    {
        public DashboardActionType Index { get; private set; }
        public GroupConfig Group { get; private set; }
        public KpiAction(int index, GroupConfig groupConf)
        {
            Index = (DashboardActionType)index;
            Group = groupConf;
        }
    }
}
