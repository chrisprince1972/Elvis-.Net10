using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Elvis.Model.ViewModels
{
    public class SteelInMouldSpeedRatioItem
    {
        public DateTime SumDate { get; set; }
        public string DisplayDay
        {
            get
            {
                string[] names = CultureInfo.InstalledUICulture.DateTimeFormat.AbbreviatedDayNames;
                return names[(int)SumDate.DayOfWeek];
            }
        }
        public float? CC1SteelInMould { get; set; }
        public float? CC2SteelInMould { get; set; }
        public float? CC3SteelInMould { get; set; }
        //public float? TotalSteelInMould
        //{
        //    get { return (CC1SteelInMould + CC2SteelInMould + CC3SteelInMould); }
        //}
        public float? CC1SpeedRatio { get; set; }
        public float? CC2SpeedRatio { get; set; }
        public float? CC3SpeedRatio { get; set; }
        //public float? AverageSpeedRatio
        //{
        //    get { return (CC1SpeedRatio + CC2SpeedRatio + CC3SpeedRatio) / 3; }
        //}

        // See: http://www.remondo.net/calculate-the-variance-and-standard-deviation-in-csharp/ for calculations.
        //public double? SpeedRatioStandardDeviation
        //{
        //    get
        //    {
        //        var numbers = new List<float?>(new[] { CC1SpeedRatio, CC2SpeedRatio, CC3SpeedRatio });
        //        var mean = numbers.Average();

        //        if (!mean.HasValue)
        //        {
        //            return null;
        //        }

        //        var result = numbers.Sum(number => Math.Pow((double)number - (double)mean, 2.0));

        //        return Math.Sqrt((double)result / numbers.Count());
        //    }
        //}
    }
}
