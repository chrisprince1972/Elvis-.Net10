namespace BusinessLogic.Models.TrendingShifts
{
    public class KpiConfigShiftSingleDataWrapper: KpiConfigShiftWrapper
    {
        public KpiDataShiftWrapper Data { get; private set; }
        public KpiConfigShiftSingleDataWrapper(KpiConfigShiftWrapper kpiConfig,
            KpiDataShiftWrapper data) : base(kpiConfig)
        {
            Data = data;
        }
        public string GetToolTip(bool lineBreaks = true)
        {
            return GetToolTip(Data.Date, Data.Rota, Data.Shift, lineBreaks);
        }
        


    }
}
