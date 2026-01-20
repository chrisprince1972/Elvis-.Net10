using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Elvis.Common;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Model
{
    public static class CasterTrend
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the data points for a specific tag in a time frame.
        /// Use this method for each tag selected on the casting trends page.
        /// </summary>
        /// <param name="tag">The tag you wish to get data for.</param>
        /// <param name="startDate">The starting point from which the data should start.</param>
        /// <param name="endDate">The end point at which the data should stop.</param>
        /// <returns>A list of CasterTrendDataPoint objects.</returns>
        public static List<CasterTrendDataPoint> GetDataPoints(string tag,
            DateTime startDate, DateTime endDate)
        {
            try
            {
                DataTable dt = EntityHelper.ElvisGetTrend.GetByTagAndDate(tag, startDate, endDate);
                dt.Columns.Add("Tag", typeof(string));

                //Adds the tag data to the DataTable before converting it.
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Tag"] = tag;
                }

                return dt.ToList<CasterTrendDataPoint>();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- CasterTrend.cs -- GetDataPoints -- tag: " + tag + " -- ", ex);
            }
            return new List<CasterTrendDataPoint>();// Errored
        }

        /// <summary>
        /// Formula for Normalising Data - 
        /// 
        ///     y = ((x - A) * (D - C)) / (B - A)
        ///     
        ///     where x is the value to normalise,
        ///     A is Min value of data set,
        ///     B is Max value of data set,
        ///     C is Min value of normalised outcome,
        ///     D is Max value of normalised outcome,
        ///     y is your normalised value on a scale of C to D.
        /// </summary>
        /// <param name="dataPoints">The list of data points to normalise.</param>
        public static void NormaliseCasterData(List<CasterTrendDataPoint> dataPoints,
            List<CasterTag> casterTags)
        {
            //First Find the TagName.
            string tagName = dataPoints.FirstOrDefault().Tag;
            if (!string.IsNullOrEmpty(tagName))
            {
                //Then Find the Tag to get the Max and Mins.
                CasterTag tag = casterTags.FirstOrDefault(c => c.TagName == tagName);

                if (tag != null)
                {
                    double A = tag.Min;
                    double B = tag.Max;
                    double C = 0;
                    double D = 100;

                    foreach (CasterTrendDataPoint point in dataPoints)
                    {
                        double y = 0;
                        double x = point.Value;
                        double numeratorResult = 0;
                        double denominatorResult = 0;

                        numeratorResult = (x - A) * (D - C);
                        denominatorResult = B - A;

                        if (denominatorResult > 0)
                            y = numeratorResult / denominatorResult;

                        if (y > 100)//Can't be over 100
                            point.NormalisedValue = 100;
                        else if (y < 0)//Can't be less than 0
                            point.NormalisedValue = 0;
                        else
                            point.NormalisedValue = Math.Round(y, 2);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the caster number (1, 2 or 3) from a tracking event unit number.
        /// </summary>
        /// <param name="trackingRecord">The Tracking record to interrogate.</param>
        /// <returns>A Caster Number as an Int.</returns>
        public static int GetCasterNumber(Tracking trackingRecord)
        {
            if (trackingRecord != null)
            {
                switch (trackingRecord.UnitNumber)
                {
                    case 11:
                        return 1;
                    case 12:
                        return 2;
                    case 13:
                        return 3;
                    default:
                        return 0;
                }
            }
            return 0;
        }
    }

    #region Supporting Classes
    /// <summary>
    /// Holds the info for a data point in the caster trend graph.
    /// </summary>
    public class CasterTrendDataPoint
    {
        public DateTime DateTime { get; set; }
        public double Value { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }
        public double NormalisedValue { get; set; }
        public int Interval { get; set; }
        public string Tag { get; set; }
    }
    #endregion
}