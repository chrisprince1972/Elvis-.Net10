using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elvis.Model.ViewModels
{
    public class SteelInMouldViewModel : IHeatsPerDayByCasterPeriod
    {

        public PeriodType Period { get; set; }

        public DateTime SelectedDate { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }

        public List<SteelInMouldSpeedRatioItem> Items { get; set; }

        public SteelInMouldViewModel()
        {
            Items = new List<SteelInMouldSpeedRatioItem>();
        }
        
        public string PeriodEndDisplayDate
        {
            get { return PeriodEnd.ToString("dd-MM hh:mm"); }
        }

        public string PeriodStartDisplayDate
        {
            get { return PeriodStart.ToString("dd-MM hh:mm"); }
        }

        //public float? CC1SteelInMouldTotal
        //{
        //    get { return Items.Sum(i => i.CC1SteelInMould); }
        //}

        //public float? CC2SteelInMouldTotal
        //{
        //    get { return Items.Sum(i => i.CC2SteelInMould); }
        //}

        //public float? CC3SteelInMouldTotal
        //{
        //    get { return Items.Sum(i => i.CC3SteelInMould); }
        //}

        //public float? TotalSteelInMouldTotal
        //{
        //    get { return Items.Sum(i => i.TotalSteelInMould); }
        //}

        //public float? CC1SpeedRatioAverage
        //{
        //    get { return Items.Average(i => i.CC1SpeedRatio); }
        //}

        //public float? CC2SpeedRatioAverage
        //{
        //    get { return Items.Average(i => i.CC2SpeedRatio); }
        //}

        //public float? CC3SpeedRatioAverage
        //{
        //    get { return Items.Average(i => i.CC3SpeedRatio); }
        //}

        //public float? AverageSpeedRatioAverage
        //{
        //    get { return Items.Average(i => i.AverageSpeedRatio); }
        //}

        //public double? AverageSpeedRatioStandardDeviation
        //{
        //    get { return Items.Average(i => i.SpeedRatioStandardDeviation); }
        //}
    }
}
