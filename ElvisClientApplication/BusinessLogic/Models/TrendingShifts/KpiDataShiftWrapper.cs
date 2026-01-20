using BusinessLogic.Constants;
using BusinessLogic.Models.ViewModels;
using ElvisDataModel.EDMX;
using System;

namespace BusinessLogic.Models.TrendingShifts
{
    public class KpiDataShiftWrapper
    {
        public DateTime Date { get; private set; }
        public Shift Shift { get; private set; }
        public int Index { get; private set; }
        public Rota Rota { get; private set; }
        public float? Value { get; private set; }
        public DashboardStatusWrapper Status { get; private set; }

        public KpiDataShiftWrapper(ElvisSettings settings, KPIDataShift kpiData)
        {
            Date = kpiData.KPIDate;
            Shift = (Shift)kpiData.KPIShift;
            Index = kpiData.KPIIndex;

            // cleaner way of doing this?
            Rota tempForRota;
            if (Enum.TryParse(kpiData.KPIRota, out tempForRota))
            {
                Rota = tempForRota;
            }

            Value = kpiData.KPIValue;
            Status = new DashboardStatusWrapper(settings, kpiData.KPIStatus);
        }

        //returns # as default.
        public string GetFormatedValue(KpiConfigShiftWrapper config)
        {
            string returnValue = "#";

            if (Value.HasValue)
            {
                string format = "0";

                if (!string.IsNullOrWhiteSpace(config.StringFormat))
                {
                    format = config.StringFormat;
                }

                returnValue = Value.Value.ToString(format);
            }

            return returnValue;
        }
    }
}
