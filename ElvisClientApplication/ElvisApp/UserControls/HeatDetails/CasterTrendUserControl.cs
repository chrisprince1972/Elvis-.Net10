using Elvis.Properties;
using Elvis.UserControls.Generic;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Elvis.UserControls.HeatDetails
{
    public partial class CasterTrendUserControl : ElvisUserControl
    {
        private int heatNumber;
        private int heatNumberSet;

        private DateTime? startTime = null, endTime = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public int CasterNo { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public bool HasNoEndTime { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public bool NoCastingData { get; set; }

        private DateTime selectedDateTime;

        private string titleText;
        private string fromToText;


        public CasterTrendUserControl()
        {
            InitializeComponent();
            this.HasNoEndTime = true;
            this.chart.chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartMouseClick);
        }

        /// <summary>
        /// Sets up the user control with the heats data.
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        public void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;
            base.SetupUserControl(Resources.loadingBlack);
        }

        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        protected override string GetData()
        {
            string error = String.Empty;

            List<HeatLog> heatLogs = new List<HeatLog>();

            try
            {
                this.CasterNo = 0;
                Tracking trackingRecord = EntityHelper.Tracking.GetSingleCasterEvent(this.heatNumber, this.heatNumberSet);
                this.NoCastingData = trackingRecord == null;
                
                if (trackingRecord != null)
                {
                    this.CasterNo = Model.CasterTrend.GetCasterNumber(trackingRecord);
                    this.startTime = trackingRecord.TimeStampStart.AddMinutes(-5);//Add a 5 mins span either side of start and end times.
                    this.endTime = GetEndTime(trackingRecord.TimeStampEnd).AddMinutes(5);

                    List<EntityHelper.ChartSeriesSet.ChartSeriesSetTypes> listOfSeriesSetTypes 
                        = new List<EntityHelper.ChartSeriesSet.ChartSeriesSetTypes>();

                    if(this.CasterNo == 1)
                    {
                        listOfSeriesSetTypes.Add(EntityHelper.ChartSeriesSet.ChartSeriesSetTypes.Caster1Trend);
                    }
                    else if(this.CasterNo == 2)
                    {
                        listOfSeriesSetTypes.Add(EntityHelper.ChartSeriesSet.ChartSeriesSetTypes.Caster2Trend);
                    }
                    else if(this.CasterNo == 3)
                    {
                        listOfSeriesSetTypes.Add(EntityHelper.ChartSeriesSet.ChartSeriesSetTypes.Caster3Trend);
                    }

                    if (this.startTime.HasValue && this.endTime.HasValue)
                    {


                        this.titleText = string.Format(
                            "CC{0} - Heat {1}",
                            this.CasterNo, this.heatNumber
                            );

                        this.fromToText = string.Format("Start {0} - {1}",
                            this.startTime.Value.AddMinutes(5).ToString("HH:mm"),
                            GetTitleEndTime(trackingRecord.TimeStampEnd)
                            );

                        // Legend only needs to be 1 column wide.
                        this.chart.SetupUserControlByDateRange(
                            EntityHelper.ChartsConfiguration.ChartsType.CasterTrend, 
                            listOfSeriesSetTypes, 
                            this.startTime.Value, 
                            this.endTime.Value, 1);

                        this.selectedDateTime = this.startTime.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                error = String.Format(
                    "Error getting data for Caster graph. Error: {0}", ex.Message);
            }

            return error;
        }

        
        /// <summary>
        /// Generates an end time for the graph.  Returns a time that's 
        /// 2 hours ahead of the start time if the event has no end time and
        /// has been running longer than 2 hours.  Or returns the actual end time. 
        /// Or returns the DateTime.Now as default value if none of the above apply.
        /// </summary>
        /// <param name="endTime">The End time of the tracking event.</param>
        /// <returns>A DateTime to be used as an end time.</returns>
        private DateTime GetEndTime(DateTime? endDateTime)
        {
            this.HasNoEndTime = true;
            DateTime returnValue = DateTime.Now;

            if(this.startTime.HasValue)
            {
                if (endDateTime.HasValue)
                {
                    this.HasNoEndTime = false;
                    returnValue = endDateTime.Value;
                }
                else if (this.startTime.Value.AddHours(2) < DateTime.Now)
                {
                    returnValue = startTime.Value.AddHours(2);
                }
            }

            return returnValue;
        }

        /// <summary>
        /// When the thread has finished executing it will call this. So populate the data on the gridview.
        /// </summary>
        protected override void PopulateForm()
        {
            if (this.chart.chart.Loaded)
            {
                chart.chart.WriteAllSeries();

                chart.Draw();

                this.chart.chart.Titles["title"].Text = titleText;
                this.chart.chart.Titles["fromTo"].Text = fromToText;
                this.chart.chart.AddVerticalLineAnnotation(this.selectedDateTime.ToOADate());
            }
        }

        /// <summary>
        /// Passes back the control's main panel so it can overwrite the loading image.
        /// </summary>
        protected override void ShowMainPanel()
        {
            if (this.NoCastingData || !this.chart.chart.Loaded)
            {
                this.ShowImage(Resources.CastingData);
            }
            else if (this.error != String.Empty)
            {
                this.ShowImage(Resources.error);
            }
            else
            {
                this.ShowMainPanel(pnlMain);
            }
        }

        /// <summary>
        /// Handles the mouse clicking events onthe chart.
        /// </summary>
        private void ChartMouseClick(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //Gets the datetime of the point clicked
                var results = this.chart.chart.HitTest(e.Location.X, e.Location.Y, false,
                                 ChartElementType.PlottingArea);
                foreach (var result in results)
                {
                    if (result.ChartElementType == ChartElementType.PlottingArea
                        && startTime.HasValue)
                    {
                        double xVal = result.ChartArea.AxisX.PixelPositionToValue(e.Location.X);
                        this.selectedDateTime = DateTime.FromOADate(xVal);
                        this.chart.chart.AddVerticalLineAnnotation(this.selectedDateTime.ToOADate());
                        this.chart.FillSelection(this.selectedDateTime);
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Determines if the heat has a casting end time or not.
        /// </summary>
        /// <returns>The casting end time of the heat or "NO END TIME!" if no end time present.</returns>
        private string GetTitleEndTime(DateTime? endDateTime)
        {
            string returnValue = String.Empty;

            if (!this.HasNoEndTime)
            {
                returnValue = "End " + endDateTime.Value.ToString("HH:mm");
            }
            else
            {
                returnValue = "No End Time!";
            }
            return returnValue;
        }

        /// <summary>
        /// Moves the annotated line on the graph by the amount of minutes 
        /// in the parameter.  Positive to increase, negative to decrease.
        /// </summary>
        /// <param name="mins">The amount of minutes to change the selection by.</param>
        public void MoveAnnotatedLine(int mins)
        {
            if (this.selectedDateTime != null && this.selectedDateTime > DateTime.MinValue)
            {
                this.selectedDateTime = this.selectedDateTime.AddMinutes(mins);
                this.chart.chart.AddVerticalLineAnnotation(this.selectedDateTime.ToOADate());
                this.chart.FillSelection(this.selectedDateTime);
            }
        }
    }
}
