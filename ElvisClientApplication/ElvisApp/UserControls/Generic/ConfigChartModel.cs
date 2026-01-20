using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using ElvisDataModel;


//Helper class to get the data to configure a ElvisChartUserControl object.
namespace Elvis.UserControls.Generic
{
    static class ConfigChartModel
    {
        /// <summary>
        /// Gets a list of ChartAreas from the database configuration.
        /// </summary>
        /// <param name="chartTypeForConfiguration">The type of chart to get the areas configuration from.</param>
        /// <param name="highContrast">Use the high contrast colours.</param>
        /// <returns>List of ChartAreas from the database configuration based on the chart type.</returns>
        public static List<ChartArea> GetChartAreas(EntityHelper.ChartsConfiguration.ChartsType chartTypeForConfiguration, bool highContrast)
        {
            List<ElvisDataModel.EDMX.ChartArea> configChartArea = EntityHelper.ChartsAreas.GetByChartType(chartTypeForConfiguration);
            List<ChartArea> chartAreas = new List<ChartArea>();

            foreach (ElvisDataModel.EDMX.ChartArea area in configChartArea)
            {
                chartAreas.Add(GetArea(area, highContrast));
            }

            return chartAreas;
        }

        /// <summary>
        /// Gets a database configured chart area.
        /// </summary>
        /// <param name="area">Object representing the database configuration of the chart area.</param>
        /// <param name="highContrast">Use the high contrast colours.</param>
        /// <returns>A ChartArea configured from the database specification.</returns>
        private static ChartArea GetArea(ElvisDataModel.EDMX.ChartArea area, bool highContrast)
        {
            ChartArea chartArea = new ChartArea(area.Name);
            if (chartArea != null)
            {
                if (area.PositionAuto.HasValue)
                {
                    chartArea.Position.Auto = area.PositionAuto.Value;
                }
                if (area.PositionHeight.HasValue)
                {
                    chartArea.Position.Height = (float)area.PositionHeight.Value;
                }
                if (area.PositionWidth.HasValue)
                {
                    chartArea.Position.Width = (float)area.PositionWidth.Value;
                }
                if (area.PositionY.HasValue)
                {
                    chartArea.Position.Y = (float)area.PositionY.Value;
                }

                SetAxes(area.ChartID, highContrast, chartArea);
            }

            return chartArea;
        }

        /// <summary>
        /// Configures all the axes of for the chart area.
        /// </summary>
        /// <param name="chartID">To specify which chart to get the configuration for.</param>
        /// <param name="highContrast">Indicates whether to use the the high contrast colours from the database.</param>
        /// <param name="chartArea">The chart area to configure.</param>
        private static void SetAxes(short chartID, bool highContrast, ChartArea chartArea)
        {
            foreach (ElvisDataModel.EDMX.ChartAxi axis in
                    ElvisDataModel
                    .EntityHelper
                    .ChartsAxis
                    .GetByChartAreaID(chartID))
            {
                if (axis != null)
                {
                    if (axis.AxisType
                        == (int)ElvisDataModel.EntityHelper.ChartsAxis.chartAxisType.X)
                    {
                        SetAxis(chartArea.AxisX, axis, highContrast);
                    }

                    if (axis.AxisType
                        == (int)ElvisDataModel.EntityHelper.ChartsAxis.chartAxisType.Y)
                    {
                        SetAxis(chartArea.AxisY, axis, highContrast);
                    }
                }

            }
        }

        /// <summary>
        /// Configure specifc axis of the chart area.
        /// </summary>
        /// <param name="axisForm">The axis to be configured.</param>
        /// <param name="axisDB">The axis specification of the configuration from the database.</param>
        /// <param name="highContrast">Use the high contrast colours.</param>
        private static void SetAxis(Axis axisForm, ElvisDataModel.EDMX.ChartAxi axisDB, bool highContrast)
        {
            if (axisDB.Title != String.Empty)
            {
                axisForm.Title = axisDB.Title;
            }

            if (axisDB.IntervalType.HasValue)
            {
                axisForm.IntervalType = (DateTimeIntervalType)axisDB.IntervalType.Value;
            }
            if (axisDB.Interval.HasValue)
            {
                axisForm.Interval = axisDB.Interval.Value;
            }

            if (axisDB.Min.HasValue)
            {
                axisForm.Minimum = axisDB.Min.Value;
            }

            if (axisDB.Max.HasValue)
            {
                axisForm.Maximum = axisDB.Max.Value;
            }

            if (axisDB.MajorGridLineDashStyle.HasValue)
            {
                axisForm.MajorGrid.LineDashStyle = (ChartDashStyle)axisDB.MajorGridLineDashStyle.Value;
            }

            if (axisDB.Title != String.Empty)
            {
                axisForm.Title = axisDB.Title;
            }

            if (axisDB.LabelStyleFormat != String.Empty)
            {
                axisForm.LabelStyle.Format = axisDB.LabelStyleFormat;
            }

            if (axisDB.LabelStyleIntervalType.HasValue)
            {
                axisForm.LabelStyle.IntervalType = (DateTimeIntervalType)axisDB.LabelStyleIntervalType.Value;
            }
            if (axisDB.LabelStyleInterval.HasValue)
            {
                axisForm.LabelStyle.Interval = axisDB.LabelStyleInterval.Value;
            }

            axisForm.MajorGrid.LineColor = System.Drawing.ColorTranslator.FromHtml(highContrast ? axisDB.MajorGridLineColorHighContrast : axisDB.MajorGridLineColor);
            axisForm.TitleForeColor = System.Drawing.ColorTranslator.FromHtml(highContrast ? axisDB.TitleForeColorHighContrast : axisDB.TitleForeColor);
            axisForm.LineColor = System.Drawing.ColorTranslator.FromHtml(highContrast ? axisDB.LineColorHighContrast : axisDB.LineColor);
            axisForm.LabelStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(highContrast ? axisDB.LabelStyleForeColorHighContrast : axisDB.LabelStyleForeColor);
            axisForm.MajorTickMark.LineColor = System.Drawing.ColorTranslator.FromHtml(highContrast ? axisDB.MajorTickMarkLineColorHighContrast : axisDB.MajorTickMarkLineColor);
        }
    }
}
