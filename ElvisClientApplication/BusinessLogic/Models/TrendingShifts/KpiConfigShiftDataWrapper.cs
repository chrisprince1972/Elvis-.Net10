using BusinessLogic.Models.ViewModels;
using ElvisDataModel.EDMX;
using System.Collections.Generic;

namespace BusinessLogic.Models.TrendingShifts
{
    public class KpiConfigShiftDataWrapper : KpiConfigShiftWrapper
    {
        public List<KpiDataShiftWrapper> Data { get; protected set; }
        public List<KpiDataMonthWrapper> DataMonth { get; protected set; }

        public KpiConfigShiftDataWrapper(ElvisSettings settings,
            KPIConfigShift kpiConfig, List<KpiDataShiftWrapper> data,
            List<GroupConfig> groupConfigs, List<KPIDataMonth> dataMonth)
            : base(settings, kpiConfig, groupConfigs)
        {
            Data = data;
            DataMonth = new List<KpiDataMonthWrapper>();
            dataMonth.ForEach(r => DataMonth.Add(
                new KpiDataMonthWrapper(settings, r)));
        }
    }
}
