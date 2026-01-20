using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Elvis.Model;
using ElvisDataModel;
//using ElvisDataModel.PIHelpers;
//using ElvisDataModel.PSPIServiceReference;
using NLog;
using System.ComponentModel;

namespace Elvis.UserControls.Generic
{
    public partial class ElvisChartUserControl : Chart
    {        

        private Logger logger = LogManager.GetCurrentClassLogger();

        public EntityHelper.ChartsConfiguration.ChartsType ChartType { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsHighContrast { get; set; }
        public List<SeriesDataFromPI> ListSeriesDataFromPI { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Loaded { get; set; }
        private List<TramLines> ListTramLines { get; set; }
        
        /// <summary>
        /// Constructor.  Initalise the unassigned properties above.
        /// </summary>
        public ElvisChartUserControl()
        {
            InitializeComponent();

            this.ListSeriesDataFromPI = new List<SeriesDataFromPI>();
            this.ListTramLines = new List<TramLines>();
            this.IsHighContrast = false;
            this.Loaded = false;
        }

        /// <summary>
        /// This function sets all of the data to be shown.
        /// So you can get a list of series from the GetChartData function or provide your own list.
        /// </summary>
        /// <param name="chartTypeForConfiguration">Chart configuration to get..</param>
        /// <param name="chartPISeriesInformationToGet">List of series to get the values for.</param>
        /// <param name="start">Start time of the range.</param>
        /// <param name="end">End time of the range to show values for.</param>
        public void SetupUserControlByDateRange(
                EntityHelper.ChartsConfiguration.ChartsType chartTypeForConfiguration, 
                List<ElvisDataModel.EDMX.ChartSery> chartPISeriesInformationToGet, 
                DateTime start, 
                DateTime end)
        {
            this.ListSeriesDataFromPI.Clear();
            this.ChartType = chartTypeForConfiguration;

            //Populate data
            try
            {
                foreach (ElvisDataModel.EDMX.ChartSery element in chartPISeriesInformationToGet)
                {
                    ListSeriesDataFromPI.Add(new SeriesDataFromPI(element, start, end));
                }
                this.Loaded = true;
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- SetupUserControlByDateRange() -- Error getting data for graphs.", ex);
            }
        }


        /// <summary>
        /// Initialy when the chart is loaded you might want to just show all of the series.
        /// </summary>
        public void WriteAllSeries()
        {
            WriteAllSeries(null);
        }

        /// <summary>
        /// This is where the chart object gets configured by the database.  It uses the ConfigChartModel as a helper to get the data from the database.
        /// </summary>
        private void Configure()
        {
            ElvisDataModel.EDMX.ChartsConfiguration configChart = new ElvisDataModel.EDMX.ChartsConfiguration();
            try
            {
                configChart = EntityHelper.ChartsConfiguration.GetByChartType(this.ChartType);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Configure() -- Error getting Chart data.", ex);
            }

            this.ChartAreas.Clear();
            List<ChartArea> chartAreaList = ConfigChartModel.GetChartAreas(this.ChartType, this.IsHighContrast);
            foreach (ChartArea ca in chartAreaList)
            {
                if (configChart != null)
                {
                    ca.BackColor = System.Drawing.ColorTranslator.FromHtml(
                        this.IsHighContrast ? configChart.BackColourHighContrast : configChart.BackColour);
                }
                this.ChartAreas.Add(ca);
            }

            if (configChart != null)
            {
                this.ForeColor = System.Drawing.ColorTranslator.FromHtml(
                    this.IsHighContrast ? configChart.ForeColourHighContrast : configChart.ForeColour);
                this.BackColor = System.Drawing.ColorTranslator.FromHtml(
                    this.IsHighContrast ? configChart.BackColourHighContrast : configChart.BackColour);
            }
        }

        /// <summary>
        /// Takes the data already obtained by the SetupUserControlByDateRange function and display it on the chart
        /// but filter it to only show the series passed in.
        /// </summary>
        /// <param name="seriesToShow">Shows all series on this list.</param>
        public void WriteAllSeries(List<ElvisDataModel.EDMX.ChartSery> seriesToShow)
        {
            this.Series.Clear();
            if (this.Loaded)
            {
                Configure();
                WriteTramLines();

                foreach (SeriesDataFromPI s in ListSeriesDataFromPI)
                {
                    if (s.Data != null)
                    {
                        if (seriesToShow == null || 
                            seriesToShow.Where(r => r.ID == s.SeriesID).Any())
                        {
                            if (IsHighContrast)
                            {
                                CreateSeriesIfRequired(s.SeriesName, s.ColourHighContrast);
                            }
                            else
                            {
                                CreateSeriesIfRequired(s.SeriesName, s.Colour);
                            }

                            WriteSeries(s.SeriesName, s.Data);
                        }
                    }
                }
            }
        }

        /// <summary> 
        /// Creates tram lines on the chart these are generally used a min max indicators.
        /// </summary>
        /// <param name="nameOfSeries">Name of the new series to add.</param>
        /// <param name="colour">colour of the tram lines.</param>
        /// <param name="start">Starting x position.</param>
        /// <param name="end">Ending x position.</param>
        /// <param name="y1">Height from the bottom.</param>
        /// <param name="y2">Value?</param>
        public void AddTramLines(string nameOfSeries, Color colour, int start, int end, int y1, int y2)
        {
            TramLines tramLines = new TramLines()
            {
                Name = nameOfSeries,
                Colour = colour,
                Start = start,
                End = end,
                Y1 = y1,
                Y2 = y2
            };

            ListTramLines.Add(tramLines);
        }

        /// <summary>
        /// Writes tram lines that have been specified using the function above.  This is seperated so that it remembers the 
        /// tram lines to rewrite them on the chart even when it gets reloaded.
        /// </summary>
        private void WriteTramLines()
        {
            foreach (TramLines tramLines in ListTramLines)
            {
                CreateSeriesIfRequired(tramLines.Name, tramLines.Colour);

                Series currSeries = this.Series[tramLines.Name];
                
                currSeries.Color = Color.Transparent;
                currSeries.BorderColor = tramLines.Colour;
                
                currSeries.BorderDashStyle = ChartDashStyle.Dash;
                currSeries.ChartType = SeriesChartType.Range;

                for (int i = tramLines.Start; i < tramLines.End; i++)
                {
                    currSeries.Points.AddXY(i, tramLines.Y1, tramLines.Y2);
                }
            }
        }


        /// <summary>
        /// Creates a series with the name provided if one does not exist.  With the default properties for this chart.
        /// </summary>
        /// <param name="name">Name of the series to add.</param>
        /// <param name="colour">Colour of the series.</param>
        private void CreateSeriesIfRequired(string name, Color colour)
        {
            if (this.Series.Where(r => r.Name == name).Count() < 1)
            {
                this.Series.Add(name);

                var currSeries = this.Series[name];
                currSeries.ChartArea = this.ChartAreas[0].Name;
                currSeries.Color = colour;
                currSeries.BorderWidth = 2;
                currSeries.LegendText = name;
                currSeries.LegendToolTip = name;
                currSeries.ChartType = SeriesChartType.FastLine;
                currSeries.IsVisibleInLegend = false;
            }

        }

        /// <summary>
        /// This writes the series data points onto the chart it uses different X value depending on which chart.  However,
        /// this could proberbly be done better by using existing configuration ie axis configuration type or at least should 
        /// be a new configuration in the database.
        /// </summary>
        /// <param name="name">Name of the series to write the data points to.</param>
        /// <param name="data">List of chart values to be put onto the data points.</param>
        private void WriteSeries(string name, List<ChartValue> data)
        {
            foreach (ChartValue chartVal in data)
            {
                if (this.ChartType == EntityHelper.ChartsConfiguration.ChartsType.EndBlowingModel)
                {
                    this.Series[name].Points.AddXY(
                        chartVal.Value,
                        chartVal.ScaledValue);
                }
                else if (this.ChartType == EntityHelper.ChartsConfiguration.ChartsType.CasterTrend)
                {
                    this.Series[name].Points.AddXY(
                        chartVal.Time,
                        chartVal.ScaledValue);
                }
            }
        }


        /// <summary>
        /// Helper class for the chart values.
        /// </summary>
        public class ChartValue
        {
            public DateTime Time { get; set; }
            // X value for plotting on the chart.  This is the time in seconds from the start time.
            public double Value { get; set; }
            //Plain unaltered value from source.
            public double ActualValue { get; set; }
            /// <summary>
            /// A modified value ready for plotting on the graph.
            /// </summary>
            public double ScaledValue { get; set; }

            /// <summary>
            /// This function provides a scaling mechinisim to the chart value.  
            /// First it checks where the data has come from and chooses how to scale it based on that.
            /// The result gets put in the ScaledValue property.
            /// </summary>
            /// <param name="val">The value to scale.</param>
            /// <param name="chartDataLocation">This contains the configuration on how to treat the data.</param>
            public void SetScaleValue(double val, ElvisDataModel.EDMX.ChartDataLocation chartDataLocation)
            {
                switch (((EntityHelper.ChartSery.RetrievalDataMethod)chartDataLocation.RetrievalDataMethodID))
                {
                    case EntityHelper.ChartSery.RetrievalDataMethod.GetInterpolatedPIData5Sec:
                        {
                            this.ScaledValue = ScalueUsingDBConfiguration(val, chartDataLocation);
                            break;
                        }
                    case EntityHelper.ChartSery.RetrievalDataMethod.GetCasterDataPoints:
                        {
                            if (chartDataLocation.Min.HasValue && chartDataLocation.Max.HasValue)
                            {
                                this.ScaledValue = ScaleValue(val,
                                    chartDataLocation.Min.Value,
                                    chartDataLocation.Max.Value,
                                    0,
                                    100);
                            }
                            break;
                        }
                }
            }

            /// <summary>
            /// This uses the scale value from the database and restricts the value min and max database configuration.
            /// </summary>
            /// <param name="val">value to scale.</param>
            /// <param name="chartDataLocation">Configuration from database on how to scale the value.</param>
            /// <returns>Scaled value as a double.</returns>
            private double ScalueUsingDBConfiguration(double val, ElvisDataModel.EDMX.ChartDataLocation chartDataLocation)
            {
                if (chartDataLocation.Scale.HasValue)
                {
                    val = val * chartDataLocation.Scale.Value;
                }

                if (chartDataLocation.Min.HasValue && val < chartDataLocation.Min.Value)
                {
                    val = chartDataLocation.Min.Value;
                }

                if (chartDataLocation.Max.HasValue && val > chartDataLocation.Max.Value)
                {
                    val = chartDataLocation.Max.Value;
                }

                return val;
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
            private static double ScaleValue(
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

                if (y > 100)//Can't be over 100
                {
                    value = 100;
                }
                else if (y < 0)//Can't be less than 0
                {
                    value = 0;
                }
                else
                {
                    value = Math.Round(y, 2);
                }

                return value;
            }
        }

        /// <summary>
        /// Add a vertical line to the chart to indicate where the values are coming from.
        /// </summary>
        /// <param name="location"></param>
        public void AddVerticalLineAnnotation(double location)
        {
            this.Annotations.Clear();

            if (this.Loaded)
            {
                VerticalLineAnnotation dateLine = new VerticalLineAnnotation();
                dateLine.AxisX = this.ChartAreas[0].AxisX;
                dateLine.AxisY = this.ChartAreas[0].AxisY;
                dateLine.LineColor = Color.SteelBlue;
                dateLine.LineWidth = 2;
                dateLine.LineDashStyle = ChartDashStyle.Solid;
                dateLine.AnchorX = location;
                dateLine.AnchorY = 0;
                dateLine.ClipToChartArea = this.ChartAreas[0].Name;
                dateLine.IsInfinitive = true;

                this.Annotations.Add(dateLine);
            }

        }

        /// <summary>
        /// Gets the value at a specific point in time for a specific 
        /// tag, from the data.  Using the database configuration to specify how to get the data.
        /// </summary>
        /// <param name="dt">The DateTime of the value.</param>
        /// <param name="tag">The tag name.</param>
        /// <returns>A string representing the value to 2 d.p.</returns>
        public string GetTagValue(DateTime dt, string tag)
        {
            ElvisDataModel.EDMX.ChartDataLocation chartDataLocation = 
                new ElvisDataModel.EDMX.ChartDataLocation();
            try
            {
                chartDataLocation
                    = ElvisDataModel
                    .EntityHelper
                    .ChartDataLocations
                    .GetByReferenceID(tag);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetTagValue() -- Error getting chart data location. -- ", ex);
            }

            if (chartDataLocation != null)
            {
                List<PIValueAsFloat> listPiValue = null;

                double tagValue = 0;
                string returnValue = String.Empty;

                switch (((EntityHelper.ChartSery.RetrievalDataMethod)chartDataLocation.RetrievalDataMethodID))
                {
                    case EntityHelper.ChartSery.RetrievalDataMethod.GetInterpolatedPIData5Sec:
                        {
                            listPiValue = SeriesDataFromPI.GetPIDataForDatesInterval5Sec(chartDataLocation.ReferenceId, dt, dt);

                            if (listPiValue != null)
                            {
                                PIValueAsFloat piValue = listPiValue.FirstOrDefault();
                                if (piValue != null)
                                {
                                    tagValue = piValue.Value;

                                }
                            }

                            break;
                        }
                    case EntityHelper.ChartSery.RetrievalDataMethod.GetCasterDataPoints:
                        {
                            SeriesDataFromPI seriesDataFromPI
                                = this
                                .ListSeriesDataFromPI
                                .FirstOrDefault(r =>
                                    r.LocationID == chartDataLocation.Id);

                            if (seriesDataFromPI != null)
                            {
                                ChartValue chartValue = seriesDataFromPI.Data.OrderBy
                                (r =>
                                    Math.Abs((r.Time - dt).Ticks)
                                ).FirstOrDefault();

                                if (chartValue != null)
                                {
                                    tagValue = chartValue.ActualValue;
                                }
                            }

                            break;
                        }
                }
                return tagValue.ToString("N2");
            }
            return "";
        }

        /// <summary>
        /// Helper class for PI data.
        /// </summary>
        public class SeriesDataFromPI
        {
            private Logger logger = LogManager.GetCurrentClassLogger();
            public string Heading { get; private set; }
            public Color Colour { get; private set; }
            public Color ColourHighContrast { get; private set; }
            public string SeriesName { get; private set; }
            public int SeriesID { get; private set; }
            public int LocationID { get; private set; }
            public List<ChartValue> Data { get; private set; }

            /// <summary>
            /// Constructor. Initialises the value of the class object mainly from the database table ChartSeries.
            /// </summary>
            /// <param name="chartSeries">Configuration of how to treat the data.</param>
            /// <param name="start">Start of the range of where to get the data from.</param>
            /// <param name="end">End of the range of where to get the data from.</param>
            public SeriesDataFromPI(ElvisDataModel.EDMX.ChartSery chartSeries, DateTime start, DateTime end)
            {
                Data = new List<ChartValue>();
                Heading = chartSeries.Name;
                Colour = System.Drawing.ColorTranslator.FromHtml(chartSeries.Colour);
                ColourHighContrast = System.Drawing.ColorTranslator.FromHtml(chartSeries.ColourHighContrast);
                SeriesName = chartSeries.Name;
                SeriesID = chartSeries.ID;
                LocationID = chartSeries.ChartDataLocationsID;
                ElvisDataModel.EDMX.ChartDataLocation chartDataLocation = 
                    new ElvisDataModel.EDMX.ChartDataLocation();

                try
                {
                    chartDataLocation = ElvisDataModel
                        .EntityHelper
                        .ChartDataLocations
                        .GetByChartDataLocationsID(chartSeries.ChartDataLocationsID);
                }
                catch (Exception ex)
                {
                    logger.ErrorException("DATA ERROR -- SeriesDataFromPI() -- Error getting chart data location. -- ", ex);
                }

                if(chartDataLocation != null)
                {
                    GetDataForTag(chartDataLocation, start, end);
                }
            }

            /// <summary>
            /// Get and convert the data from the data source and put it in a chart value object ready for display.
            /// </summary>
            /// <param name="chartSeries">Configuration of how to treat the data.</param>
            /// <param name="start">Start of the range of where to get the data from.</param>
            /// <param name="end">End of the range of where to get the data from.</param>
            private void GetDataForTag(ElvisDataModel.EDMX.ChartDataLocation chartDataLocation, DateTime start, DateTime end)
            {
                List<PIValueAsFloat> piValues = GetDataForDateRange(
                    chartDataLocation, start, end);

                if (piValues != null && piValues.Count > 0)
                {
                    foreach (PIValueAsFloat piValue in piValues)
                    {
                        double piDoubleValue = 0;
                        if (double.TryParse(piValue.Value.ToString(), out piDoubleValue))
                        {
                            //Work out TimeSpan
                            TimeSpan ts = piValue.Timestamp - start;

                            ChartValue chartValue = new ChartValue()
                            {
                                Time = piValue.Timestamp,
                                //Use this for plotting graph.
                                Value = ts.TotalMinutes,
                                ActualValue = piDoubleValue
                            };

                            chartValue.SetScaleValue(piDoubleValue, chartDataLocation);
                            Data.Add(chartValue);
                        }
                    }
                }
            }

            /// <summary>
            /// Manages where to get the data from based on the database configuration.
            /// </summary>
            /// <param name="chartDataLocation">Where and how to get the data from the database.</param>
            /// <param name="start">Start of the range of where to get the data from.</param>
            /// <param name="end">End of the range of where to get the data from.</param>
            /// <returns>List of data points that ready to be converted to chart values.</returns>
            private List<PIValueAsFloat> GetDataForDateRange(ElvisDataModel.EDMX.ChartDataLocation chartDataLocation, DateTime start, DateTime end)
            {
                List<PIValueAsFloat> listPiValue = null;

                switch (((EntityHelper.ChartSery.RetrievalDataMethod)chartDataLocation.RetrievalDataMethodID))
                {
                    case EntityHelper.ChartSery.RetrievalDataMethod.GetInterpolatedPIData5Sec:
                    {
                        listPiValue = GetPIDataForDatesInterval5Sec(chartDataLocation.ReferenceId, start, end);
                        break;
                    }
                    case EntityHelper.ChartSery.RetrievalDataMethod.GetCasterDataPoints:
                    {
                        listPiValue = GetCasterDataPoints(chartDataLocation.ReferenceId, start, end);
                        break;
                    }
                }
                return listPiValue;
            }

            /// <summary>
            /// Gets interpolated PI data from the PSPI Service Reference. 
            /// </summary>
            /// <param name="piTag">The PI tag to search for.</param>
            /// <param name="start">Start of the time period in search.</param>
            /// <param name="end">Start of the time period in search.</param>
            /// <returns>A List of PIValueObjects.</returns>
            public static List<PIValueAsFloat> GetPIDataForDatesInterval5Sec(string tag, DateTime start, DateTime end)
            {
                //List<PIValueObject> listPiValueObjects = PIHelper.GetInterpolatedPIData(tag, start, end, 5);
                //List<PIValueAsFloat> listPiFloatObjects = new List<PIValueAsFloat>();

                //if (PIHelper.TagExists(tag))
                //{
                //    foreach(PIValueObject piValueObject in listPiValueObjects)
                //    {
                //        listPiFloatObjects.Add(new PIValueAsFloat(piValueObject));
                //    }
                //}

                return new List<PIValueAsFloat>();// listPiFloatObjects;
            }

            /// <summary>
            /// Gets caster data points from the the caster trend model and convertes them into a list of PIValueAsFloats.
            /// </summary>
            /// <param name="tag">The PI tag to get the data points for.</param>
            /// <param name="start">Start of the time period in search.</param>
            /// <param name="end">Start of the time period in search.</param>
            /// <returns>A List of PIValueObjects.</returns>
            public static List<PIValueAsFloat> GetCasterDataPoints(string tag, DateTime start, DateTime end)
            {
                List<CasterTrendDataPoint> casterDataPoints = Model.CasterTrend.GetDataPoints(
                    tag, start, end);
                List<PIValueAsFloat> listPiFloatObjects = new List<PIValueAsFloat>();

                if (casterDataPoints.Count > 0)
                {
                    foreach (CasterTrendDataPoint casterTrendDataPoint in casterDataPoints)
                    {
                        listPiFloatObjects.Add(new PIValueAsFloat(casterTrendDataPoint));
                    }
                }
                return listPiFloatObjects;
            }
        }


        /// <summary>
        /// Helper class for PI objects.
        /// </summary>
        public class PIValueAsFloat
        {
            public string TagName { get; private set; }
            public DateTime Timestamp { get; private set; }
            public double Value { get; private set; }
            public double ScaledValue { get; private set; }

            /// <summary>
            /// Constructs a PIValueAsFloat object from a PIValueObject.
            /// </summary>
            /// <param name="piValueObject">To populate the values from.</param>
            //public PIValueAsFloat(PIValueObject piValueObject)
            //{
            //    TagName = piValueObject.TagName;
            //    Timestamp = piValueObject.Timestamp;
            //    Value = piValueObject.Float;
            //}

            /// <summary>
            /// Constructs a PIValueAsFloat object from a casterTrendValueObject.
            /// </summary>
            /// <param name="casterTrendValueObject">To populate the values from.</param>
            public PIValueAsFloat(CasterTrendDataPoint casterTrendValueObject)
            {
                TagName = casterTrendValueObject.Tag;
                Timestamp = casterTrendValueObject.DateTime;
                Value = casterTrendValueObject.Value;
                ScaledValue = casterTrendValueObject.Value;
            }

        }

        /// <summary>
        /// Helper class to aid storage of the tram lines.
        /// </summary>
        public class TramLines
        {
            public string Name { get; set; }
            public Color Colour { get; set; }
            public int Start { get; set; }
            public int End { get; set; }
            public int Y1 { get; set; }
            public int Y2 { get; set; }
        }
    }
}
