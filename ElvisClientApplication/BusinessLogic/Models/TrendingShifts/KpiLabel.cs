using BusinessLogic.Constants;
using BusinessLogic.Models.ViewModels;
using System;
using System.Drawing;

namespace BusinessLogic.Models.TrendingShifts
{
    public class KpiLabel
    {
        public string Text { get; set; }
        public Color ForeColor { get; private set; }
        public Color BackColor { get; private set; }
        public object Tag { get; private set; }
        public string ToolTip { get; private set; }

        public KpiLabel(KpiConfigShiftDataWrapper config, string text)
        {
            Text = text;
            ForeColor = config.GetKpiTextColour();
            BackColor = config.GetKpiBackgroundColour();
            ToolTip = text;
            Tag = config;
        }

        //empty
        public KpiLabel(ElvisSettings settings, KpiConfigShiftWrapper config,
            DateTime dt, Rota rota, Shift shift)
        {
            ForeColor = settings.ColourDashBadText;
            BackColor = settings.ColourDashBadBackground;

            ToolTip = config.GetToolTip(dt, rota, shift, true);
            Text = "#";
        }
        public KpiLabel(ElvisSettings settings, KpiConfigShiftDataWrapper config, 
            KpiDataShiftWrapper data)
        {
            KpiConfigShiftSingleDataWrapper kpiShift
                    = new KpiConfigShiftSingleDataWrapper(config, data);
            Tag = kpiShift;

            Text = "";

            if (kpiShift != null && config.ShowValue)
            {
                Text = data.GetFormatedValue(kpiShift);
            }
            BackColor = data.Status.BackgroundColour;
            ForeColor = data.Status.TextColour;

            if (kpiShift != null)
            {
                ToolTip = kpiShift.GetToolTip();
            }
        }
        public KpiLabel(ElvisSettings settings, KpiConfigShiftDataWrapper config,
            KpiDataMonthWrapper data)
        {
            Tag = config;

            Text = "";
            ForeColor = config.GetKpiTextColour();
            BackColor = config.GetKpiBackgroundColour();

            if (data != null)
            {
                if (config.ShowValue)
                {
                    Text = data.GetFormatedValue(config);
                }

                BackColor = data.Status.BackgroundColour;
                ForeColor = data.Status.TextColour;

                ToolTip = string.Format("Month {0}", data.Month);
            }
        }
    }
}
