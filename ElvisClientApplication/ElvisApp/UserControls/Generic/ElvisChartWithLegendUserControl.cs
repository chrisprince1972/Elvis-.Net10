using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ElvisDataModel;
using Elvis.Properties;

namespace Elvis.UserControls.Generic
{
    public partial class ElvisChartWithLegendUserControl : UserControl
    {
        private List<ElvisDataModel.EDMX.ChartSery> OptionsForLegend;
        private DateTime StartTime { get; set; }
        private DateTime EndTime { get; set; }
        private string ChartName { get; set; }
        private bool inhibitCheckBoxLoading;
        private EntityHelper.ChartsConfiguration.ChartsType chartType;
        //Persist the legend status.
        private List<Tuple<int, bool>> CheckBoxesChecked { get; set; }
        private int LegendColumnWidth { get; set; }

        /// <summary>
        /// Constructor.  Setup the object with initialised variables.
        /// </summary>
        public ElvisChartWithLegendUserControl()
        {
            InitializeComponent();
            this.inhibitCheckBoxLoading = false;
            this.ChartName = String.Empty;
            this.OptionsForLegend = null;
            this.CheckBoxesChecked = new List<Tuple<int,bool>>();
            CustomiseColours();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlChart.BackColor =
                pnlRest.BackColor =
                pnlSelection.BackColor =
                grpChart.BackColor =
                grpLegend.BackColor =
                grpValues.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlChart.ForeColor =
                pnlRest.ForeColor =
                pnlSelection.ForeColor =
                grpChart.ForeColor =
                grpLegend.ForeColor =
                grpValues.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Main entry point for passing data into the class.  This sets up the object with the data it needs to operate.
        /// </summary>
        /// <param name="chartType">This contains the type of chart that needs to be created.</param>
        /// <param name="getSeriesSet">List of the series to put into the chart.</param>
        /// <param name="start">Start of the date range for the chart.</param>
        /// <param name="end">End of the date range for the chart.</param>
        public void SetupUserControlByDateRange(
            EntityHelper.ChartsConfiguration.ChartsType chartType,
            List<EntityHelper.ChartSeriesSet.ChartSeriesSetTypes> getSeriesSet,
            DateTime start,
            DateTime end,
            int legendColumnWidth)
        {
            this.StartTime = start;
            this.EndTime = end;
            this.OptionsForLegend = LegendForChart.GetChartData(getSeriesSet);
            this.ChartName = GetNameForChart(getSeriesSet);
            //Get all configured.
            this.chart.SetupUserControlByDateRange(chartType, OptionsForLegend, start, end);
            this.chartType = chartType;
            this.LegendColumnWidth = legendColumnWidth;
        }

        /// <summary>
        /// Sets up some UI properties associated with different chart types.
        /// </summary>
        /// <param name="chartType">The Chart Type.</param>
        private void CustomiseUI(EntityHelper.ChartsConfiguration.ChartsType chartType)
        {
            if (chartType == EntityHelper.ChartsConfiguration.ChartsType.CasterTrend)
            {
                this.Padding = new Padding(6, 6, 6, 6);
                lstSelection.Columns[0].Width = 90;
                lstSelection.Columns[1].Width = 54;
                splitContainerMain.SplitterDistance = 610;
            }
            else if (chartType == EntityHelper.ChartsConfiguration.ChartsType.EndBlowingModel)
            {
                this.Padding = new Padding(0, 6, 6, 6);
                lstSelection.Columns[0].Width = 115;
                lstSelection.Columns[1].Width = 66;
            }
        }

        /// <summary>
        /// Returns the name for the chart as a whole by getting each of the series sets requested.
        /// </summary>
        /// <param name="seriesSets">List of the sets of series to show on the chart.</param>
        /// <returns>The name of the chart to be put on chart's group control.</returns>
        private string GetNameForChart(List<EntityHelper.ChartSeriesSet.ChartSeriesSetTypes> seriesSets)
        {
            string nameForChart = String.Empty;

            foreach (EntityHelper.ChartSeriesSet.ChartSeriesSetTypes chartSeriesSet in seriesSets)
            {
                if (nameForChart != String.Empty)
                {
                    nameForChart += ", ";
                }

                nameForChart +=
                    EntityHelper
                    .ChartSeriesSet
                    .GetByChartID(chartSeriesSet);
            }

            return nameForChart;
        }

        /// <summary>
        /// This is to be called when all of the data is ready to
        /// be displayed and just calls the functions to render the chart.
        /// </summary>
        public void Draw()
        {
            if (this.OptionsForLegend != null)
            {
                LoadLegend();
                FillSelection(this.StartTime);
                this.chart.AddVerticalLineAnnotation(0);
                
                Redraw();
                grpChart.Text = this.ChartName;
            }
        }

        /// <summary>
        /// Loads the legend into the side bar.
        /// </summary>
        private void LoadLegend()
        {
            this.legendForChart.SetupUserControl(this.OptionsForLegend, this.LegendColumnWidth);
            this.legendForChart.OnChange += LegendChanged;
        }

        private List<ElvisDataModel.EDMX.ChartSery> GetTagValuesToDisplay()
        {
            List<ElvisDataModel.EDMX.ChartSery> listChartSeries = new List<ElvisDataModel.EDMX.ChartSery>();
            foreach (object obj in this.legendForChart.GetCheckedTagValues())
            {
                listChartSeries.Add((ElvisDataModel.EDMX.ChartSery)obj);
            }

            return listChartSeries;
        }


        /// <summary>
        /// Refresh the series that are being displayed if the check boxes change.
        /// </summary>
        public void Redraw()
        {
            chart.WriteAllSeries(GetTagValuesToDisplay());
        }


        /// <summary>
        /// If a the legend has changed in any way reload.
        /// </summary>
        private void LegendChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!this.inhibitCheckBoxLoading)
            {
                Redraw();
                this.chart.AddVerticalLineAnnotation(this.StartTime.ToOADate());
                FillSelection(this.StartTime);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Fills the selection box with data.
        /// </summary>
        public void FillSelection(DateTime selectedDT)
        {
            if (selectedDT != null && selectedDT > DateTime.MinValue)
            {
                this.grpValues.Text = "Time Selected - " + selectedDT.ToString("HH:mm:ss");
            }

            this.lstSelection.Items.Clear();//Clean up list box before adding more items.

            List<ElvisDataModel.EDMX.ChartSery> seriesToShow = GetTagValuesToDisplay();

            if (seriesToShow != null && seriesToShow.Count > 0)
            {
                //Get the datetime at which to show data
                seriesToShow.Reverse();

                foreach (ElvisDataModel.EDMX.ChartSery series in seriesToShow)
                {
                    string tag
                        = EntityHelper
                        .ChartDataLocations
                        .GetByChartDataLocationsID(series.ChartDataLocationsID)
                        .ReferenceId;

                    string val = this.chart.GetTagValue(selectedDT, tag);

                    this.lstSelection.Items.Add(new ListViewItem(new[] { series.Name, val }));
                }
            }
        }

        /// <summary>
        /// Reduce or increase the overall size of the chart by default.
        /// </summary>
        /// <param name="control">Which control to resize.</param>
        /// <param name="diff">Difference to change by.</param>
        private void IncreaseControlWidth(Control control, int diff)
        {
            control.Size = new System.Drawing.Size(control.Size.Width + diff, control.Size.Height);
        }

        /// <summary>
        /// Reduce or increase the overall size of the chart by default.
        /// </summary>
        /// <param name="diff">Difference to change by.</param>
        public void ControlIncreaseChartSize(int diff)
        {
            this.splitContainerMain.SplitterDistance += diff;
        }

        private void ElvisChartWithLegendUserControl_Load(object sender, EventArgs e)
        {
            CustomiseUI(this.chartType);
        }

    }
}
