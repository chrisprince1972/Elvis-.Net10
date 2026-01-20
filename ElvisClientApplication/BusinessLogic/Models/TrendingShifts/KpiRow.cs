using BusinessLogic.Constants;
using BusinessLogic.Models.TrendingShifts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BusinessLogic.Models.ViewModels.TrendingShifts
{
    public class KpiRow
    {
        public KpiLabel RowLevel { get; private set; }
        public KpiLabel RowDescription { get; private set; }
        public List<KpiLabel> KpiData { get; private set; }
        public ElvisSettings Settings { get; private set; }
        public Color BackColor { get; private set; }
        public bool Action { get; private set; }
        //can be null
        public KpiLabel KpiDataMonth { get; private set; }

        public KpiRow(ElvisSettings settings, KpiConfigShiftDataWrapper config,
                Rota rota, DateTime start, 
                List<Tuple<DateTime, Shift>> shiftsToShow)
        {
            Settings = settings;
            RowLevel = new KpiLabel(config, config.GetLevelText());
            RowDescription = new KpiLabel(config, config.Description);
            BackColor = config.GetKpiBackgroundColour();
            Action = config.Action != null;
            KpiData = new List<KpiLabel>();
            
            KpiDataMonthWrapper KpiMonth = config.DataMonth.FirstOrDefault(r => 
                    r.Rota == rota);
            KpiDataMonth = new KpiLabel(settings, config, KpiMonth);
            
            foreach (var shiftToShow in shiftsToShow)
            {
                AddDataForShift(config, rota, shiftToShow.Item1, 
                    shiftToShow.Item2);
            }
        }
        
        private void AddDataForShift(KpiConfigShiftDataWrapper config,
            Rota rota, DateTime date, Shift shift)
        {
            KpiDataShiftWrapper kpi = GetDataForShift(config, rota, date, shift);
            KpiLabel toAdd = null;
            if (kpi == null)
            {
                toAdd = new KpiLabel(Settings, config, date, rota, shift);
            }
            else
            {
                toAdd = new KpiLabel(Settings, config, kpi);
            }
            KpiData.Add(toAdd);
        }

        private KpiDataShiftWrapper GetDataForShift(KpiConfigShiftDataWrapper config,
            Rota rota, DateTime date, Shift shift)
        {
            return
                (
                    from kdw in config.Data
                    where kdw.Date.Date == date &&
                        kdw.Shift == shift &&
                        kdw.Rota == rota
                    select kdw
                )
                .FirstOrDefault();
        }
    }
}
