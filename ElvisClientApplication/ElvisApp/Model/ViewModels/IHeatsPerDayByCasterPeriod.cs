using System;

namespace Elvis.Model.ViewModels
{
    interface IHeatsPerDayByCasterPeriod
    {
        PeriodType Period { get; set; }
        DateTime PeriodEnd { get; set; }
        string PeriodEndDisplayDate { get; }
        DateTime PeriodStart { get; set; }
        string PeriodStartDisplayDate { get; }
        DateTime SelectedDate { get; set; }
    }
}
