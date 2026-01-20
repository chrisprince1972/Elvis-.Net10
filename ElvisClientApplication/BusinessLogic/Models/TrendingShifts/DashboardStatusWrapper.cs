using BusinessLogic.Constants.Trending.Dashboards;
using BusinessLogic.Models.ViewModels;
using System.Drawing;

namespace BusinessLogic.Models.TrendingShifts
{
    public class DashboardStatusWrapper
    {
        public DashboardStatus Status { get; private set; }
        public Color BackgroundColour { get; private set; }
        public Color TextColour { get; private set; }
        private const int STATUS_GOOD = 1;


        public DashboardStatusWrapper(ElvisSettings settings, int? status)
        {
            Status = DashboardStatus.Missing;
            BackgroundColour = settings.ColourDashMissingBackground;
            TextColour = settings.ColourDashMissingText;

            if (status.HasValue)
            {
                if (status.Value == STATUS_GOOD)
                {
                    Status = DashboardStatus.WithinLimits;
                    BackgroundColour = settings.ColourDashGoodBackground;
                    TextColour = settings.ColourDashGoodText;
                }
                else
                {
                    Status = DashboardStatus.NotWithinLimits;
                    BackgroundColour = settings.ColourDashBadBackground;
                    TextColour = settings.ColourDashBadText;
                }
            }
        }

    }
}
