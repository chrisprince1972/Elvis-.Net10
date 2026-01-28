// -----------------------------------------------------------------------
// <copyright file="HeatsPerDayByCasterViewModel.cs" company="TSSP UK">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Elvis.Model.ViewModels
{
    using Elvis.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// One-way view model to hold heat/caster totals over a given time period.
    /// </summary>
    public class HeatsPerDayByCasterViewModel : IHeatsPerDayByCasterPeriod
    {
        public PeriodType Period { get; set; }

        public DateTime SelectedDate { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }

        /// <summary>
        /// Collection of shift summaries, covering either a day or a week depending on the Period Type.
        /// </summary>
        public IEnumerable<ShiftHeatCountSummary> ShiftHeatCountSummaries { get; set; }

        /// <summary>
        /// True if the <c>ShiftHeatCountSummaries</c> has cumulative values over the time period rather
        /// than discrete summaries for each shift.
        /// </summary>
        public bool HasCumulativeSummaries { get; set; }

        /// <summary>
        /// True if the <c>ShiftHeatCountSummaries</c> are showing the daily 10:00am plan.
        /// </summary>
        public bool HasDailyPlanSummaries { get; set; }

        public string PeriodStartDisplayDate
        {
            get
            {
                return PeriodStart.ToString("dd-MM 07:00");
            }
        }

        public string PeriodEndDisplayDate
        {
            get
            {
                return PeriodEnd.ToString("dd-MM 07:00");
            }
        }

        public HeatsPerDayByCasterViewModel()
            : this(MyDateTime.Now)
        {
        }

        public HeatsPerDayByCasterViewModel(DateTime selectedDate)
        {
            HasCumulativeSummaries = false;
            SelectedDate = selectedDate;
            ShiftHeatCountSummaries = new List<ShiftHeatCountSummary>();
        }

        public int CC1PlannedCountTotal
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.CC1PlannedCount);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.CC1PlannedCount);
            }
        }

        public int CC2PlannedCountTotal
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.CC2PlannedCount);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.CC2PlannedCount);
            }
        }

        public int CC3PlannedCountTotal
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.CC3PlannedCount);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.CC3PlannedCount);
            }
        }

        public int PlannedCountTotalSum
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.PlannedCountTotal);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.PlannedCountTotal);
            }
        }

        public int CC1DeviationsCountTotal
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.CC1DeviationsCount);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.CC1DeviationsCount);
            }
        }

        public int CC2DeviationsCountTotal
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.CC2DeviationsCount);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.CC2DeviationsCount);
            }
        }

        public int CC3DeviationsCountTotal
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.CC3DeviationsCount);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.CC3DeviationsCount);
            }
        }

        public int DeviationsCountTotalSum
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.DeviationsCountTotal);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.DeviationsCountTotal);
            }
        }

        public int CC1ActualCountTotal
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.CC1ActualCount);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.CC1ActualCount);
            }
        }

        public int CC2ActualCountTotal
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.CC2ActualCount);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.CC2ActualCount);
            }
        }

        public int CC3ActualCountTotal
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.CC3ActualCount);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.CC3ActualCount);
            }
        }

        public int ActualCountTotalSum
        {
            get
            {
                if (HasCumulativeSummaries)
                    return ShiftHeatCountSummaries.Max(s => s.ActualCountTotal);
                else
                    return ShiftHeatCountSummaries.Sum(s => s.ActualCountTotal);
            }
        }
    }
}
