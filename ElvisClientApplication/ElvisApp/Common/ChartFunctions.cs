using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Common
{
    class ChartFunctions
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Add a chart annotation which displays a vertical line to indicate
        /// the time given.
        /// </summary>
        /// <param name="chart">The chart to draw the line on.</param>
        /// <param name="dt">The Time Stamp to do it at.</param>
        public static void DrawVerticalAnnotation(Chart chart, DateTime dt)
        {
            foreach (Annotation a in chart.Annotations)
            {
                a.Dispose();
            }

            chart.Annotations.Clear();

            var dateLine = new VerticalLineAnnotation();
            dateLine.AxisX = chart.ChartAreas[0].AxisX;
            dateLine.AxisY = chart.ChartAreas[0].AxisY;
            dateLine.LineColor = Color.SteelBlue;
            dateLine.LineWidth = 2;
            dateLine.LineDashStyle = ChartDashStyle.Solid;
            dateLine.AnchorX = dt.ToOADate();
            dateLine.AnchorY = 0;
            dateLine.ClipToChartArea = chart.ChartAreas[0].Name;
            dateLine.IsInfinitive = true;

            chart.Annotations.Add(dateLine);
        }

        /// <summary>
        /// Clears the chart of data
        /// </summary>
        public static void ClearChartData(Chart chart)
        {
            foreach (Series series in chart.Series)
            {
                series.Points.Clear();
            }

            foreach (Annotation a in chart.Annotations)
            {
                a.Dispose();
            }
            chart.Annotations.Clear();
        }

        /// <summary>
        /// Adds the HM Stock actual data to a chart.
        /// </summary>
        /// <param name="chart">The Chart you wish to add it to.</param>
        /// <param name="hmStocks">The List of HM_Stocks objects to use to populate the chart.</param>
        /// <param name="maxYValue">The highest value so far that the Y axis has hit (for scaling).</param>
        /// <returns>The highest value so far that the Y axis has hit (for scaling).</returns>
        public static double AddActualHMStockAndBlastOutputToChart(Chart chart, List<HM_Stocks> hmStocks, double maxYValue)
        {
            foreach (HM_Stocks stock in hmStocks)
            {
                if (stock != null)
                {
                    double dblHMLevel = 0;
                    double blastOutput = 0;
                    double o2Spill = 0;
                    if (stock.HM_LEVEL.HasValue &&
                        double.TryParse(stock.HM_LEVEL.Value.ToString(), out dblHMLevel))
                    {
                        int hmLevel = Convert.ToInt32(dblHMLevel);
                        chart.Series["HM Stock"].Points.AddXY(stock.DATE, hmLevel);
                        maxYValue = CheckYMaxValue(maxYValue, dblHMLevel);
                    }
                    if (stock.BF_OUTPUT.HasValue &&
                        double.TryParse(stock.BF_OUTPUT.Value.ToString(), out blastOutput))
                    {
                        chart.Series["BF Output"].Points.AddXY(stock.DATE, Math.Round(blastOutput, 1));
                        maxYValue = CheckYMaxValue(maxYValue, blastOutput);
                    }
                    if (stock.O2Spill.HasValue &&
                        double.TryParse(stock.O2Spill.Value.ToString(), out o2Spill))
                    {
                        chart.Series["Oxy Spill"].Points.AddXY(stock.DATE, Math.Round(o2Spill, 1));
                        maxYValue = CheckYMaxValue(maxYValue, o2Spill);
                    }
                }
            }
            return maxYValue;
        }

        /// <summary>
        /// Adds the actual casting rate to a chart.
        /// </summary>
        /// <param name="chart">The chart you wish to populate.</param>
        /// <param name="list">A list of HM Stock data.</param>
        public static void AddActualCastingRateToChart(Chart chart, List<HM_Stocks> hmStocks)
        {
            foreach (HM_Stocks stock in hmStocks)
            {
                if (stock != null)
                {
                    double total = 0;

                    if (stock.cc1_output.HasValue)
                        total += stock.cc1_output.Value;
                    if (stock.cc2_output.HasValue)
                        total += stock.cc2_output.Value;
                    if (stock.cc3_output.HasValue)
                        total += stock.cc3_output.Value;

                    chart.Series["Actual t/min"].Points.AddXY(stock.DATE, Math.Round(total, 2));
                }
            }
        }

        /// <summary>
        /// Adds the predicted HM Stock data to a chart.
        /// </summary>
        /// <param name="chart">The Chart you wish to add it to.</param>
        /// <param name="plannedHeats">A List of the CoordLink data objects.</param>
        /// <param name="hoursToPredict">The amount of hours the data should predict.</param>
        /// <param name="currentHMStock">The current hm stock.</param>
        /// <param name="currentBlastOutput">The current blast output.</param>
        /// <param name="maxYValue">The highest value so far that the Y axis has hit (for scaling).</param>
        /// <returns>The highest value so far that the Y axis has hit (for scaling).</returns>
        public static double AddPredictedHMStockToChart(Chart chart, List<CoordLink> plannedHeats,
            int hoursToPredict, double currentHMStock,
            double currentBlastOutput, double maxYValue)
        {
            double runningTotal = currentHMStock;
            for (DateTime nextMinute = DateTime.Now.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
                nextMinute < DateTime.Now.AddHours(hoursToPredict);
                nextMinute = nextMinute.AddMinutes(1))
            {
                maxYValue = CheckYMaxValue(maxYValue, currentBlastOutput);
                maxYValue = CheckYMaxValue(maxYValue, currentHMStock);

                double minuteBlastTonnage = currentBlastOutput / 60;
                runningTotal += minuteBlastTonnage;

                if (plannedHeats != null && plannedHeats.Count > 0 &&
                    plannedHeats.Where(d => d.PLANNED_CHARGE_TIME == nextMinute).Any())
                {
                    runningTotal -= DefaultSettings.AvgIronPerBlow;
                }

                chart.Series["HM Stock"].Points.AddXY(nextMinute, runningTotal);
            }
            return maxYValue;
        }

        /// <summary>
        /// Adds the predicted blast furnace output to the chart.
        /// </summary>
        /// <param name="chart">The chart you wish to add the data to.</param>
        /// <param name="currentBlastOutput">The current blast furnace output.</param>
        /// <param name="hoursToPredict">The amount of hours to predict.</param>
        public static void AddPredictedBlastOutputToChart(Chart chart, double currentBlastOutput, int hoursToPredict)
        {
            for (DateTime nextHour = DateTime.Now;
                nextHour < DateTime.Now.AddHours(hoursToPredict);
                nextHour = nextHour.AddHours(1))
            {
                chart.Series["BF Output"].Points.AddXY(nextHour, currentBlastOutput);
            }
        }

        /// <summary>
        /// Adds the target casting rate line to the chart.
        /// </summary>
        /// <param name="chart">The chart you wish to add the data to.</param>
        /// <param name="startDate">The starting point.</param>
        /// <param name="endDate">The end point.</param>
        /// <param name="targetTonPerMins">The value for target tonnes per minute.</param>
        public static void AddTargetCastingRateToChart(Chart chart, DateTime startDate, DateTime endDate, int targetTonPerMins)
        {
            chart.Series["Target t/min"].Points.AddXY(
                startDate,
                targetTonPerMins);
            chart.Series["Target t/min"].Points.AddXY(
                endDate,
                targetTonPerMins);
        }

        /// <summary>
        /// Adds the predicted casting rate line to the chart.
        /// </summary>
        /// <param name="chart1">The chart you wish to add the data to.</param>
        /// <param name="plannedHeats">List of Coord Link Data.</param>
        public static void AddPredictedCastingRateToChart(Chart chart1, List<CoordLink> plannedHeats, DateTime StartDate, int hoursToPredict)
        {
            FormatPlannedHeatsForChart(plannedHeats);

            double tonnesPerMinute = 0;
            bool plotTargetTonnesPerMin = false;

            //Draw the casting rate line, starting at the time now
            for (DateTime nextMinute = DateTime.Now.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
                nextMinute < DateTime.Now.AddHours(hoursToPredict);
                nextMinute = nextMinute.AddMinutes(1))
            {
                foreach (var heat in plannedHeats)
                {
                    if (nextMinute >= heat.PLANNED_START_CAST_TIME && nextMinute < heat.PLANNED_END_CAST_TIME)
                    {
                        if (heat.CASTING_RATE.HasValue)
                        {
                            tonnesPerMinute += heat.CASTING_RATE.Value;
                        }
                    }
                }

                // If set true here, plotTargetTonnesPerMin will remain true for the remaining iterations.
                // This is to ensure that we don't plot zero for historic days, but do plot a zero for
                // the current day.
                if (tonnesPerMinute > 0)
                {
                    plotTargetTonnesPerMin = true;
                }

                //Predicted
                if (plotTargetTonnesPerMin)
                {
                    chart1.Series["Predicted t/min"].Points.AddXY(nextMinute, tonnesPerMinute);
                }
                tonnesPerMinute = 0;
            }
        }

        /// <summary>
        /// Checks values to see if larger than current max value for Y Axis
        /// </summary>
        /// <param name="maxYValue">The current max value to set</param>
        /// <param name="compareValue">The Value to compare</param>
        /// <returns>The new Max Value</returns>
        private static double CheckYMaxValue(double maxYValue, double compareValue)
        {
            if (compareValue > maxYValue)
                return compareValue;
            return maxYValue;
        }

        /// <summary>
        /// Filter the planned heats by caster, then adjust the times to remove gaps between the heats
        /// which would otherwise appear as spikes on the chart.
        /// </summary>
        /// <param name="plannedHeats">The list of Coord Link data to filter.</param>
        private static void FormatPlannedHeatsForChart(List<CoordLink> plannedHeats)
        {
            if (plannedHeats != null)
            {
                ModifyHeatsPerCaster(plannedHeats
                    .Where(h => h.CASTER_NUMBER == 1)
                    .OrderBy(h => h.PLANNED_START_CAST_TIME)
                    .ToList());

                ModifyHeatsPerCaster(plannedHeats
                    .Where(h => h.CASTER_NUMBER == 2)
                    .OrderBy(h => h.PLANNED_START_CAST_TIME)
                    .ToList());

                ModifyHeatsPerCaster(plannedHeats
                    .Where(h => h.CASTER_NUMBER == 3)
                    .OrderBy(h => h.PLANNED_START_CAST_TIME)
                    .ToList());
            }
        }

        /// <summary>
        /// Modifies the Start casting time to even out the data and 
        /// remove any spikes.
        /// </summary>
        /// <param name="plannedHeatsPerCaster">A list of Coord Link data 
        /// filtered by Caster (Order By ASC PLANNED_START_CAST_TIME).</param>
        private static void ModifyHeatsPerCaster(List<CoordLink> plannedHeatsPerCaster)
        {
            for (int i = 0; i < plannedHeatsPerCaster.Count; i++)
            {
                if (plannedHeatsPerCaster.ElementAt(i) != plannedHeatsPerCaster.Last() && //If not the last record
                    plannedHeatsPerCaster.ElementAt(i).PLANNED_END_CAST_TIME.HasValue &&
                    plannedHeatsPerCaster.ElementAt(i + 1).PLANNED_START_CAST_TIME.HasValue)
                {
                    int minsBetweenHeats = Convert.ToInt32(
                        (plannedHeatsPerCaster.ElementAt(i + 1).PLANNED_START_CAST_TIME.Value -
                            plannedHeatsPerCaster.ElementAt(i).PLANNED_END_CAST_TIME.Value).TotalMinutes);

                    if (minsBetweenHeats < 3)
                    {
                        plannedHeatsPerCaster.ElementAt(i + 1).PLANNED_START_CAST_TIME =
                            plannedHeatsPerCaster.ElementAt(i).PLANNED_END_CAST_TIME;
                    }
                }
            }
        }

        /// <summary>
        /// Calculates how many hours into the future the chart should predict.
        /// </summary>
        /// <param name="plannedHeats">A list of the planned heats (CoordLink object).</param>
        /// <returns>Integer value in Hours.</returns>
        public static int GetHoursToPredict(List<CoordLink> plannedHeats)
        {
            if (plannedHeats != null && plannedHeats.Count > 0)
            {
                CoordLink cl = plannedHeats.OrderByDescending(o =>
                    o.PLANNED_END_CAST_TIME).FirstOrDefault();

                if (cl.PLANNED_END_CAST_TIME.HasValue)
                {
                    DateTime endTime = cl.PLANNED_END_CAST_TIME.Value;
                    TimeSpan ts = endTime - DateTime.Now;
                    if (ts.TotalHours > 11)
                        return Convert.ToInt32(ts.TotalHours) + 1;
                }
            }
            return 12;
        }

        /// <summary>
        /// Adds the predicted 7 AM HM Stocks data to the chart.
        /// </summary>
        /// <param name="chart">The chart you wish to add it to.</param>
        /// <param name="hmb10amDataList">The list of CastersScheduleItem data.</param>
        /// <param name="currentHMStock">The Current HM Stock.</param>
        /// <param name="currentBlastOutput">The Current Blast Output.</param>
        public static void AddPredicted7AMHMStock(Chart chart,
            List<CastersScheduleItem> hmb7amDataList, double currentHMStock,
            double currentBlastOutput, DateTime dateFrom)
        {
            double hmbRunningTotal = currentHMStock;
            double minuteBlastTonnage = currentBlastOutput / 60;

            for (DateTime nextMinute = dateFrom;
                nextMinute < DateTime.Now.AddHours(12);
                nextMinute = nextMinute.AddMinutes(1))
            {
                hmbRunningTotal += minuteBlastTonnage;

                CastersScheduleItem item = hmb7amDataList
                    .FirstOrDefault(h => h.PlannedChargeTime == nextMinute);

                if (item != null)
                {//Deduct from total if scheduled charge time found
                    hmbRunningTotal -= DefaultSettings.AvgIronPerBlow;
                }

                chart.Series["HM Stock 7am"].Points.AddXY(nextMinute, hmbRunningTotal);
            }
        }

        public static void ScaleSeriesYValuesToRatio(Series s, double seriesMin, double seriesMax, double minOutput, double maxOutput)
        {
            for (int i = 0; i < s.Points.Count; i++)
            {
                double valueInAsDbl = s.Points[i].YValues[0];
                double valueOutAsDbl = ScaleValue(valueInAsDbl, seriesMin, seriesMax, minOutput, maxOutput);
                double valueOutAsRoundedDbl = Math.Round(valueOutAsDbl, 0, MidpointRounding.AwayFromZero);
                int valueOut = 0;
                if (int.TryParse(valueOutAsRoundedDbl.ToString(), out valueOut))
                {
                    s.Points[i].ToolTip = string.Format("{0}: {1}", s.Name, Math.Round(valueInAsDbl, 2));
                    s.Points[i].YValues[0] = valueOut;
                }
            }

        }


        /// <summary>
        /// This function provides the scaling mechinisim that was used in the original CasterTrend model.
        /// The result gets put in the ScaledValue property.  Perhaps we should be using this function to scale all
        /// of the values or perhaps just the ones with the scale configuration to null.
        /// </summary>
        /// <param name="val">The value to scale.</param>
        /// <param name="dataSetMinimum">The minimum value as specified by the database.</param>
        /// <param name="dataSetMinimum">The maximum value as specified by the database.</param>
        /// <param name="scaledMinimum">The minimum value of the axis.</param>
        /// <param name="scaledMaximum">The maximum value of the axis.</param>
        /// <returns>Scaled value as a double.</returns>
        public static double ScaleValue(
            double value, 
            double dataSetMinimum, 
            double dataSetMaximum, 
            double scaledMinimum, 
            double scaledMaximum)
        {

            double y = 0;
            double numeratorResult = 0;
            double denominatorResult = 0;

            numeratorResult = (value - dataSetMinimum) * (scaledMaximum - scaledMinimum);
            denominatorResult = dataSetMaximum - dataSetMinimum;

            if (denominatorResult > 0)
            {
                y = numeratorResult / denominatorResult;
            }

            if (y > scaledMaximum)//Can't be over max
            {
                value = scaledMaximum;
            }
            else if (y < scaledMinimum)//Can't be less than max
            {
                value = scaledMinimum;
            }
            else
            {
                value = Math.Round(y, 2);
            }

            return value;
        }

    }
}
