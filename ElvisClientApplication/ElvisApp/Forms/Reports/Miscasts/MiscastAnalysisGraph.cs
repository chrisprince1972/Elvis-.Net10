using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Elvis.Common;
using Elvis.Forms.Reports.Miscasts.UserControls;
using Elvis.Properties;
using Elvis.UserControls.DatePickers;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using Elvis.Model;

namespace Elvis.Forms.Reports.Miscasts
{
    public partial class MiscastAnalysisGraph : Form
    {
        #region Variables and Properties
        private bool dataReady = false;
        private bool isAdmin = false;
        private bool legendReady = false;
        private List<ElvisDataModel.EDMX.MiscastMain> miscasts;
        private BackgroundWorker worker = new BackgroundWorker();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Stops the flickers of the form when generating it.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;// Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        #endregion Variables and Properties

        public MiscastAnalysisGraph(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            SetupBackgroundWorker();

            if (ucMiscastFilter != null)
            {
                ucMiscastFilter.CheckedComboBoxClosedEvent += new
                    MiscastFilter.CheckedComboBoxClosed(ucMiscastFilter_CheckedComboBoxClosedEvent);

                ucMiscastFilter.MiscastFilterLoadedEvent += new
                    MiscastFilter.MiscastFilterLoaded(ucMiscastFilter_MiscastFilterLoadedEvent);
            }
        }

        private void SetupBackgroundWorker()
        {
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
        }

        private void MiscastAnalysis_Load(object sender, EventArgs e)
        {
            SetupForm();
            CustomiseColours();
        }

        /// <summary>
        /// Sets up the form.
        /// </summary>
        private void SetupForm()
        {
            PopulateLegendItems();
            SetDefaultValuesForDropDowns();
            ResetDatePicker();
            RunWorker();
        }

        private void ResetDatePicker()
        {
            DateTime dateNow = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                7, 0, 0
            );

            ucDateSelector.SelectedDateFormat = ElvisDateSelector.DateFormat.DateSpan;
            ucDateSelector.DateFrom = dateNow.AddMonths(-1);
            ucDateSelector.DateTo = dateNow;
        }

        /// <summary>
        /// Change the cmboSeries to a different state
        /// than that of the cmboXAxis.
        /// </summary>
        private void SetDefaultValuesForDropDowns()
        {
            cmboXAxis.SelectedIndex = 0;
            cmboSeries.SelectedIndex = 1;
        }

        /// <summary>
        /// Gets the miscast data and applies a filter to it.
        /// </summary>
        private List<ElvisDataModel.EDMX.MiscastMain> GetGraphData()
        {
            if (ucDateSelector != null && ucMiscastFilter != null)
            {
                try
                {
                    return EntityHelper.MiscastMain.GetByDateAndFilter(
                        ucDateSelector.DateFrom,
                        ucDateSelector.DateTo,
                        ucMiscastFilter.Filter);
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "DATA ERROR -- Error getting miscast records -- GetGraphData() -- ", ex);
                }
            }
            return new List<ElvisDataModel.EDMX.MiscastMain>();
        }

        /// <summary>
        /// Updates the forms labels of data.
        /// </summary>
        /// <param name="additionalText">Any additional text to add.</param>
        private void UpdateLabels(string additionalText)
        {
            if (this.miscasts != null)
            {
                lblRecordsReturned.Text = string.Format(
                    "{0} Miscast Records Returned", this.miscasts.Count);
            }

            if (string.IsNullOrWhiteSpace(additionalText))
            {
                grpChart.Text = string.Format(
                    "Miscast Analysis - {0} to {1}",
                    ucDateSelector.DateFrom.ToString("dd/MM/yy HH:mm"),
                    ucDateSelector.DateTo.ToString("dd/MM/yy HH:mm")
                    );
            }
            else
            {
                grpChart.Text = string.Format(
                    "Miscast Analysis - {0} to {1} - {2}",
                    ucDateSelector.DateFrom.ToString("dd/MM/yy HH:mm"),
                    ucDateSelector.DateTo.ToString("dd/MM/yy HH:mm"),
                    additionalText
                    );
            }
        }

        /// <summary>
        /// Binds the Miscast Analysis Chart with data 
        /// and displays it.
        /// </summary>
        private void BindChart()
        {
            UpdateLabels("");
            if (this.miscasts != null && this.dataReady)
            {
                try
                {
                    ChartFunctions.ClearChartData(chartMiscast);
                    chartMiscast.Series.Clear();
                    chartMiscast.ChartAreas[0].BackColor = Color.White;
                    chartMiscast.ChartAreas[0].AxisX.Interval = 1;
                    chartMiscast.ChartAreas[0].AxisX.Title = cmboXAxis.Text;
                    chartMiscast.DataBindCrossTable(
                        GetMiscastAnalysisChartData(),
                        "Series", "XAxisGroup", "YAxisCount",
                        "Date=Date{dd/MM/yyyy HH:mm:ss},SeriesTitle=SeriesTitle,XAxisTitle=XAxisTitle"
                        );

                    SetupChartSeries();
                    SetEmptyPoints();
                    if (chartMiscast.Series.Count == 0)
                    {
                        DisplayNoDataAnnotation();
                    }
                }
                catch (Exception ex)
                {
                    logger.ErrorException("GRAPH ERROR -- Error generating miscast analysis graph -- ", ex);
                    MessageBox.Show(
                        "Error generating the Miscast Analysis Graph!",
                        "Graph Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DisplayNoDataAnnotation()
        {
            chartMiscast.ChartAreas[0].BackColor = Color.Transparent;
            TextAnnotation annotation = new TextAnnotation();
            annotation.Text = "No data to display";
            annotation.X = 2;
            annotation.Y = 2;
            annotation.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
            chartMiscast.Annotations.Add(annotation);
        }

        /// <summary>
        /// Finds all of the points on the graph and checks for
        /// 0 count and sets it to an EmptyDataPoint.
        /// This technique keeps all the data points lined up and hides 
        /// the empty counts.
        /// </summary>
        private void SetEmptyPoints()
        {
            foreach (Series series in chartMiscast.Series)
            {
                foreach (DataPoint dataPoint in series.Points)
                {
                    if (dataPoint.YValues[0] == 0)
                    {
                        dataPoint.IsEmpty = true;
                    }
                }
            }
        }

        /// <summary>
        /// Sets up the Series for the Chart.
        /// </summary>
        private void SetupChartSeries()
        {
            foreach (Series series in chartMiscast.Series)
            {
                MiscastLegendItem legendItem = GetMiscastLegendItem(series.Name);
                if (legendItem != null &&
                    legendItem.LegendColour != null)
                {
                    if (legendItem.LegendColour != null)
                        series.Color = legendItem.LegendColour;
                    if (legendItem.LegendForeColour != null)
                        series.LabelForeColor = legendItem.LegendForeColour;
                }
                series.SmartLabelStyle.Enabled = false;
                series.ChartType = SeriesChartType.StackedColumn;
                series.ToolTip = "Group: #VALX -- #SERIESNAME: #VAL";
                series.IsValueShownAsLabel = true;
                series.Font = new Font("Tahoma", 7, FontStyle.Regular);
                series.Enabled = legendItem.LegendItemEnabled;
                series.IsXValueIndexed = true;
            }
        }

        /// <summary>
        /// Find the Miscast Legend Item by series name 
        /// from the legend item panel holder on the form.
        /// </summary>
        /// <param name="seriesName">The Series Name of the Legend Item.</param>
        /// <returns>The MiscastLegendItem or a new empty item.</returns>
        public MiscastLegendItem GetMiscastLegendItem(string seriesName)
        {
            foreach (Control ctrl in pnlLegendItemHolder.Controls)
            {
                if (ctrl is MiscastLegendItem)
                {
                    MiscastLegendItem legendItem = (MiscastLegendItem)ctrl;
                    if (legendItem.LegendText.Equals(seriesName))
                    {
                        return legendItem;
                    }
                }
            }
            return new MiscastLegendItem();
        }

        /// <summary>
        /// Populates the Legend Groupbox with
        /// Miscast Legend Items.
        /// </summary>
        private void PopulateLegendItems()
        {
            this.legendReady = false;
            pnlLegendItemHolder.Controls.Clear();
            chbCheckAll.Checked = true;

            switch (cmboSeries.Text)
            {
                case "Failure Mode":
                    PopulateLegendFailureMode();
                    break;
                case "Type":
                    PopulateLegendType();
                    break;
                case "Root Cause":
                    PopulateLegendRootCause();
                    break;
                case "Unit":
                    PopulateLegendUnit();
                    break;
                case "Area":
                    PopulateLegendArea();
                    break;
                case "Function":
                    PopulateLegendFunction();
                    break;
                case "Rota":
                    PopulateLegendRota();
                    break;
                case "Status":
                    PopulateLegendStatus();
                    break;
            }
            this.legendReady = true;
        }

        private void PopulateLegendFailureMode()
        {
            if (this.ucMiscastFilter != null && this.ucMiscastFilter.MiscastLookups != null &&
                this.ucMiscastFilter.MiscastLookups.FailureModes != null)
            {
                foreach (MiscastFailureMode failureMode in this.ucMiscastFilter.MiscastLookups.FailureModes)
                {
                    if (!failureMode.FailureMode.Equals("All"))
                    {
                        AddLegendItem(
                            failureMode.FailureModeID,
                            failureMode.FailureMode,
                            failureMode.ChartColourHex,
                            failureMode.ChartForeColourHex,
                            failureMode.Sort
                            );
                    }
                }
            }
        }

        private void PopulateLegendType()
        {
            if (this.ucMiscastFilter != null && this.ucMiscastFilter.MiscastLookups != null &&
                this.ucMiscastFilter.MiscastLookups.Types != null)
            {
                foreach (MiscastType type in this.ucMiscastFilter.MiscastLookups.Types)
                {
                    if (!type.Type.Equals("All"))
                    {
                        AddLegendItem(
                            type.MiscastTypeID,
                            type.Type,
                            type.ChartColourHex,
                            type.ChartForeColourHex,
                            type.Sort
                            );
                    }
                }
            }
        }

        private void PopulateLegendRootCause()
        {
            if (this.ucMiscastFilter != null && this.ucMiscastFilter.MiscastLookups != null &&
                this.ucMiscastFilter.MiscastLookups.RootCauses != null)
            {
                foreach (MiscastRootCause rootCause in this.ucMiscastFilter.MiscastLookups.RootCauses)
                {
                    if (!rootCause.RootCause.Equals("All"))
                    {
                        AddLegendItem(
                            rootCause.RootCauseID,
                            rootCause.RootCause,
                            rootCause.ChartColourHex,
                            rootCause.ChartForeColourHex,
                            rootCause.Sort
                            );
                    }
                }
            }
        }

        private void PopulateLegendUnit()
        {
            if (this.ucMiscastFilter != null && this.ucMiscastFilter.MiscastLookups != null &&
                this.ucMiscastFilter.MiscastLookups.Units != null)
            {
                foreach (MiscastUnit unit in this.ucMiscastFilter.MiscastLookups.Units)
                {
                    if (!unit.MiscastUnit1.Equals("All"))
                    {
                        AddLegendItem(
                            unit.MiscastUnitID,
                            unit.MiscastUnit1,
                            unit.ChartColourHex,
                            unit.ChartForeColourHex,
                            unit.Sort
                            );
                    }
                }
            }
        }

        private void PopulateLegendArea()
        {
            if (this.ucMiscastFilter != null && this.ucMiscastFilter.MiscastLookups != null &&
                this.ucMiscastFilter.MiscastLookups.Areas != null)
            {
                foreach (MiscastAreaResponsible area in this.ucMiscastFilter.MiscastLookups.Areas)
                {
                    if (!area.AreaResponsible.Equals("All"))
                    {
                        AddLegendItem(
                            area.AreaResponsibleID,
                            area.AreaResponsible,
                            area.ChartColourHex,
                            area.ChartForeColourHex,
                            area.Sort
                            );
                    }
                }
            }
        }

        private void PopulateLegendFunction()
        {
            if (this.ucMiscastFilter != null && this.ucMiscastFilter.MiscastLookups != null &&
                this.ucMiscastFilter.MiscastLookups.Functions != null)
            {
                foreach (MiscastFunction function in this.ucMiscastFilter.MiscastLookups.Functions)
                {
                    if (!function.TrioFunction.Equals("All"))
                    {
                        AddLegendItem(
                            function.FunctionID,
                            function.TrioFunction,
                            function.ChartColourHex,
                            function.ChartForeColourHex,
                            function.Sort
                            );
                    }
                }
            }
        }

        private void PopulateLegendRota()
        {
            if (this.ucMiscastFilter != null && this.ucMiscastFilter.MiscastLookups != null &&
                this.ucMiscastFilter.MiscastLookups.Rotas != null)
            {
                foreach (MiscastRota rota in this.ucMiscastFilter.MiscastLookups.Rotas)
                {
                    if (!rota.Rota.Equals("All"))
                    {
                        AddLegendItem(
                            rota.RotaID,
                            rota.Rota,
                            rota.ChartColourHex,
                            rota.ChartForeColourHex,
                            rota.Sort
                            );
                    }
                }
            }
        }

        private void PopulateLegendStatus()
        {
            if (this.ucMiscastFilter != null && this.ucMiscastFilter.MiscastLookups != null &&
                this.ucMiscastFilter.MiscastLookups.Statuses != null)
            {
                foreach (MiscastStatu status in this.ucMiscastFilter.MiscastLookups.Statuses)
                {
                    if (!status.Status.Equals("All"))
                    {
                        AddLegendItem(
                            status.MiscastStatusID,
                            status.Status,
                            status.ChartColourHex,
                            status.ChartForeColourHex,
                            status.Sort
                            );
                    }
                }
            }
        }

        private void AddLegendItem(int id, string text, string colour, string foreColour, int? sort)
        {
            MiscastLegendItem legendItem = new MiscastLegendItem()
            {
                MiscastLookupID = id,
                LegendText = text,
                LegendColour = ColorTranslator.FromHtml(colour),
                LegendForeColour = ColorTranslator.FromHtml(foreColour),
                LegendSort = sort,
                LegendItemEnabled = true
            };

            //CheckChanged Event handler assignment
            legendItem.LegendItemCheckChanged += new MiscastLegendItem.LegendItemCheckChangedEvent(
                legendItem_LegendItemCheckChanged
                );

            pnlLegendItemHolder.Controls.Add(legendItem);
            legendItem.Dock = DockStyle.Top;
            legendItem.BringToFront();
        }

        /// <summary>
        /// Builds and returns the Miscast Analysis Chart Data.
        /// </summary>
        /// <returns>A list of MiscastAnalysisDataPoints</returns>
        private List<MiscastAnalysisDataPoint> GetMiscastAnalysisChartData()
        {
            List<MiscastAnalysisDataPoint> dataPoints = new List<MiscastAnalysisDataPoint>();
            List<MiscastGraphItem> seriesList = GetMiscastGraphList(cmboSeries.Text);
            List<MiscastGraphItem> xAxisList = GetMiscastGraphList(cmboXAxis.Text);
            int recordCount = 0;

            foreach (MiscastGraphItem xAxis in xAxisList)
            {//Group Each Axis Data
                List<ElvisDataModel.EDMX.MiscastMain> initialXAxisFilter =
                    GetFilteredMiscasts(this.miscasts, xAxis, cmboXAxis.Text);

                //First if is for X Axis Types that are not 'Date' oriented (hides any x axis items that don't contain data)
                //Second if is for the 'Date' X Axis so we add them all in (shows all x axis items)
                if (initialXAxisFilter.Count > 0 ||
                    (xAxis.Date != null && xAxis.Date > DateTime.MinValue))
                {
                    foreach (MiscastGraphItem series in seriesList)
                    {//Then Find each series data within that X Axis
                        MiscastAnalysisDataPoint dataPoint = new MiscastAnalysisDataPoint()
                        {
                            XAxisGroup = xAxis.Description,
                            YAxisCount = GetMiscastCount(initialXAxisFilter, series, cmboSeries.Text),
                            Series = series.Description,
                            Date = xAxis.Date,
                            SeriesTitle = cmboSeries.Text,
                            XAxisTitle = cmboXAxis.Text
                        };

                        dataPoints.Add(dataPoint);//Must add each point, even if count is 0
                        recordCount += dataPoint.YAxisCount;
                    }
                }
            }

            UpdateLabels(string.Format(
                "{0} Miscasts", recordCount)
                );

            return dataPoints;
        }

        /// <summary>
        /// Counts the amount of miscast data present with given filters.
        /// </summary>
        /// <param name="filteredOnXAxisData">Data already filtered on X Axis.</param>
        /// <param name="series">The Series to filter on.</param>
        /// <returns>The count of records present.</returns>
        private int GetMiscastCount(List<ElvisDataModel.EDMX.MiscastMain> filteredOnXAxisData,
            MiscastGraphItem series, string group)
        {
            return GetFilteredMiscasts(filteredOnXAxisData, series, group).Count;
        }

        /// <summary>
        /// Gets filters the list passed in by the filter parameter.
        /// </summary>
        /// <param name="miscastData">The Data to Filter.</param>
        /// <param name="filter">The Type of Filter to Apply.</param>
        /// <param name="group">The Group to switch on e.g. Failure Mode, Unit etc.</param>
        /// <returns>A list of Filtered Records.</returns>
        private List<ElvisDataModel.EDMX.MiscastMain> GetFilteredMiscasts(
            List<ElvisDataModel.EDMX.MiscastMain> miscastData,
            MiscastGraphItem filter, string group)
        {
            switch (group)
            {
                case "Failure Mode":
                    return miscastData.Where(m =>
                        m.MiscastFailureModeID != null &&
                        m.MiscastFailureModeID.Equals(filter.ID)).ToList();
                case "Unit":
                    return miscastData.Where(m =>
                        m.MiscastUnitID != null &&
                        m.MiscastUnitID.Equals(filter.ID)).ToList();
                case "Rota":
                    return miscastData.Where(m =>
                        m.MiscastRotaID.Equals(filter.ID)).ToList();
                case "Area":
                    return miscastData.Where(m =>
                        m.MiscastAreaResponsibleID != null &&
                        m.MiscastAreaResponsibleID.Equals(filter.ID)).ToList();
                case "Function":
                    return miscastData.Where(m =>
                        m.MiscastFunctionID != null &&
                        m.MiscastFunctionID.Equals(filter.ID)).ToList();
                case "Type":
                    return miscastData.Where(m =>
                        m.MiscastTypeID != null &&
                        m.MiscastTypeID.Equals(filter.ID)).ToList();
                case "Root Cause":
                    return miscastData.Where(m =>
                        m.RootCauseID != null &&
                        m.RootCauseID.Equals(filter.ID)).ToList();
                case "Status":
                    return miscastData.Where(m =>
                        m.MiscastStatusID != null &&
                        m.MiscastStatusID.Equals(filter.ID)).ToList();
                case "Weekly":
                    if (filter.Date.HasValue)
                    {
                        DateTime dateToWeekly = filter.Date.Value.AddDays(7);
                        return miscastData.Where(m =>
                            m.TapTime >= filter.Date &&
                            m.TapTime < dateToWeekly).ToList();
                    }
                    break;
                case "Daily":
                    if (filter.Date.HasValue)
                    {
                        DateTime dateToDaily = filter.Date.Value.AddDays(1);
                        return miscastData.Where(m =>
                            m.TapTime >= filter.Date &&
                            m.TapTime < dateToDaily).ToList();
                    }
                    break;
                default:
                    return new List<ElvisDataModel.EDMX.MiscastMain>();
            }
            return new List<ElvisDataModel.EDMX.MiscastMain>();
        }

        /// <summary>
        /// Gets a list of MiscastGraphItems depending on the
        /// filter option passed in.
        /// </summary>
        /// <param name="seriesText">The Text to filter the lookup by.</param>
        /// <returns>A list of MiscastGraphItems.</returns>
        private List<MiscastGraphItem> GetMiscastGraphList(string type)
        {
            if (ucMiscastFilter != null && ucMiscastFilter.MiscastLookups != null)
            {
                switch (type)
                {
                    case "Failure Mode":
                        return Model.Miscasts.GetMiscastFailureModeData(
                            ucMiscastFilter.MiscastLookups.FailureModes);
                    case "Type":
                        return Model.Miscasts.GetMiscastTypeData(
                            ucMiscastFilter.MiscastLookups.Types);
                    case "Root Cause":
                        return Model.Miscasts.GetMiscastRootCauseData(
                            ucMiscastFilter.MiscastLookups.RootCauses);
                    case "Unit":
                        return Model.Miscasts.GetMiscastUnitData(
                            ucMiscastFilter.MiscastLookups.Units);
                    case "Area":
                        return Model.Miscasts.GetMiscastAreaData(
                            ucMiscastFilter.MiscastLookups.Areas);
                    case "Function":
                        return Model.Miscasts.GetMiscastFunctionData(
                            ucMiscastFilter.MiscastLookups.Functions);
                    case "Rota":
                        return Model.Miscasts.GetMiscastRotaData(
                            ucMiscastFilter.MiscastLookups.Rotas);
                    case "Status":
                        return Model.Miscasts.GetMiscastStatusData(
                            ucMiscastFilter.MiscastLookups.Statuses);
                    case "Weekly":
                        return Model.Miscasts.GetMiscastWeeklyData(
                            ucDateSelector.DateFrom,
                            ucDateSelector.DateTo);
                    case "Daily":
                        return Model.Miscasts.GetMiscastDailyData(
                            ucDateSelector.DateFrom,
                            ucDateSelector.DateTo);
                    default:
                        return new List<MiscastGraphItem>();
                }
            }
            return new List<MiscastGraphItem>();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlChart.BackColor = pnlGenerate.BackColor = pnlXAxis.BackColor =
                pnlButtons.BackColor = pnlCheckAll.BackColor =
                pnlGenerateMain.BackColor = pnlLegend.BackColor =
                pnlLegendItemHolder.BackColor = pnlMiscastAnalysis.BackColor = pnlOptions.BackColor =
                pnlSeries.BackColor = pnlXAxis.BackColor =
                grpChart.BackColor = grpGenerate.BackColor = grpXAxis.BackColor =
                grpLegend.BackColor = grpSeries.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlChart.ForeColor = pnlGenerate.ForeColor = pnlXAxis.ForeColor =
                pnlButtons.ForeColor = pnlCheckAll.ForeColor =
                pnlGenerateMain.ForeColor = pnlLegend.ForeColor =
                pnlLegendItemHolder.ForeColor = pnlMiscastAnalysis.ForeColor = pnlOptions.ForeColor =
                pnlSeries.ForeColor = pnlXAxis.ForeColor =
                grpChart.ForeColor = grpGenerate.ForeColor = grpXAxis.ForeColor =
                grpLegend.ForeColor = grpSeries.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Checks or Unchecks all the Legend Items
        /// depending on the parameter state.
        /// </summary>
        /// <param name="checkedState">True for Checked, false for Unchecked.</param>
        private void CheckAllLegendItems(bool checkedState)
        {
            this.legendReady = false;
            foreach (Control ctrl in pnlLegendItemHolder.Controls)
            {
                if (ctrl is MiscastLegendItem)
                {
                    MiscastLegendItem legendItem = (MiscastLegendItem)ctrl;
                    legendItem.LegendItemEnabled = checkedState;
                }
            }
            if (this.dataReady)
            {
                BindChart();
            }
            this.legendReady = true;
        }

        /// <summary>
        /// Shows or Hides the loading gif depending 
        /// on the parameter passed in.
        /// </summary>
        /// <param name="gifState">True to show loading, false to show chart.</param>
        private void DisplayLoadingGif(bool gifState)
        {
            if (gifState)
            {
                PictureBox picBox = new PictureBox();
                picBox.Image = Resources.loading;
                picBox.SizeMode = PictureBoxSizeMode.CenterImage;

                grpChart.Controls.Clear();
                grpChart.Controls.Add(picBox);
                picBox.Dock = DockStyle.Fill;
                picBox.BringToFront();
                picBox.Refresh();
            }
            else
            {
                grpChart.Controls.Clear();
                grpChart.Controls.Add(chartMiscast);
                chartMiscast.Dock = DockStyle.Fill;
                chartMiscast.BringToFront();
                chartMiscast.Refresh();
            }
        }

        private void EnableControls(bool state)
        {
            btnReset.Enabled = state;
            ucDateSelector.Enabled = state;
            ucMiscastFilter.Enabled = state;
            cmboSeries.Enabled = state;
            cmboXAxis.Enabled = state;
            grpLegend.Enabled = state;
        }

        /// <summary>
        /// Runs the Background Worker when data needs updating.
        /// </summary>
        private void RunWorker()
        {
            if (ucDateSelector.Ready && !worker.IsBusy)
            {
                this.Cursor = Cursors.AppStarting;
                EnableControls(false);
                DisplayLoadingGif(true);
                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Closes window on click.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void MiscastAnalysis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Button reset event. Sets up the form back to original settings.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ucMiscastFilter.Reset();
            SetupForm();
            SetupForm();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Populates the Legend on Series Change.
        /// </summary>
        private void cmboSeries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PopulateLegendItems();
            if (this.dataReady)
            {
                BindChart();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Populates the Series Drop Down, Legend Items and Chart
        /// </summary>
        private void cmboXAxis_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.dataReady)
            {
                BindChart();
            }
            this.Cursor = Cursors.Default;
        }

        private void chbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CheckAllLegendItems(chbCheckAll.Checked);
            this.Cursor = Cursors.Default;
        }

        private void ucDateSelector_DateChangedEvent(object sender)
        {
            RunWorker();
        }

        private void ucMiscastFilter_CheckedComboBoxClosedEvent()
        {
            RunWorker();
        }

        /// <summary>
        /// Used to populate the legend items once the miscast filter is ready.
        /// </summary>
        private void ucMiscastFilter_MiscastFilterLoadedEvent()
        {
            cmboSeries_SelectionChangeCommitted(null, new EventArgs());
        }

        private void legendItem_LegendItemCheckChanged(object sender)
        {
            this.Cursor = Cursors.WaitCursor;
            //SetupChartSeries();
            //chartMiscast.ChartAreas[0].RecalculateAxesScale();
            if (this.legendReady && this.dataReady)
            {
                BindChart();
            }
            this.Cursor = Cursors.Default;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.dataReady = false;
            this.miscasts = GetGraphData();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.dataReady = true;
            BindChart();
            EnableControls(true);
            DisplayLoadingGif(false);
            this.Cursor = Cursors.Default;
        }

        #region Printing

        /// <summary>
        /// Prints out the Charts Generated.
        /// </summary>
        private void printCharts_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (chartMiscast != null)
            {
                //Font setup for the pages.
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font filterFont = new Font("Arial", 11);
                Font dateFont = new Font("Arial", 10);

                //Print Header Onto Page.
                e.Graphics.DrawString("Elvis Miscast Analysis Chart Printout",
                    headerFont, Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);

                e.Graphics.DrawString(string.Format(
                    "From {0} to {1}",
                    ucDateSelector.DateFrom.ToString("dd/MM/yyyy HH:mm"),
                    ucDateSelector.DateTo.ToString("dd/MM/yyyy HH:mm")),
                    filterFont,
                    Brushes.Black,
                    e.MarginBounds.X,
                    e.MarginBounds.Y + 23);

                int yAxisOffset = e.MarginBounds.Y + 40;

                //Build the Rectangle that the chart will sit in.
                Rectangle myRec = new Rectangle(
                    e.MarginBounds.X, yAxisOffset,
                    printChart.DefaultPageSettings.PaperSize.Width - (e.MarginBounds.X * 2),
                    chartMiscast.Height);

                chartMiscast.Printing.PrintPaint(e.Graphics, myRec);

                PrintLegend(e, dateFont, yAxisOffset + myRec.Height);

                //Print Footer Onto Page.
                e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    dateFont, Brushes.Black,
                    e.PageSettings.PrintableArea.Width - e.MarginBounds.X - 60,
                    e.PageSettings.PrintableArea.Height - e.MarginBounds.Y + 30);
            }
        }

        /// <summary>
        /// Prints the legend onto the bottom of the page to be printed.
        /// </summary>
        /// <param name="e">The PrintPageEventArgs</param>
        /// <param name="font">The Font for the legend items.</param>
        private void PrintLegend(PrintPageEventArgs e, Font font, int chartYLocation)
        {
            float yRectangleLocation = chartYLocation + 50;
            float xRectangleLocation = e.MarginBounds.X + 2;
            float pageWidth = e.PageSettings.PrintableArea.Width - (e.MarginBounds.X * 2) + 32;
            float widthLeftOnPage = pageWidth;
            float xOffset = 0;
            float yOffset = 0;
            float wordGap = 10;

            e.Graphics.DrawString(
                "Legend - " + cmboSeries.Text,
                new Font("Arial", 12, FontStyle.Bold), Brushes.Black,
                xRectangleLocation - 2, yRectangleLocation - 28);

            List<MiscastLegendItem> legendItems = GetLegendItems();
            foreach (MiscastLegendItem legend in legendItems)
            {
                string legendText = " - " + legend.LegendText;
                float fontWidth = HelperFunctions.GetFontSizeInPixels(legendText, font).Width;

                if (fontWidth > widthLeftOnPage)
                {
                    widthLeftOnPage = pageWidth;
                    yOffset += 30;//New Line
                    xOffset = 0;
                }

                Brush brush = new SolidBrush(legend.LegendColour);

                Rectangle legendColourBox = new Rectangle(
                    Convert.ToInt32(xRectangleLocation + xOffset),
                    Convert.ToInt32(yRectangleLocation + yOffset),
                    18, 18
                    );

                e.Graphics.FillRectangle(
                    brush, legendColourBox
                    );

                xOffset += legendColourBox.Width;

                e.Graphics.DrawString(
                    legendText,
                    font, Brushes.Black,
                    xRectangleLocation + xOffset,
                    yRectangleLocation + yOffset);

                xOffset += fontWidth + wordGap;
                widthLeftOnPage -= (legendColourBox.Width + fontWidth + wordGap);
            }
        }

        private List<MiscastLegendItem> GetLegendItems()
        {
            List<MiscastLegendItem> legendList = new List<MiscastLegendItem>();
            foreach (Control ctrl in pnlLegendItemHolder.Controls)
            {
                if (ctrl is MiscastLegendItem)
                {
                    MiscastLegendItem legendItem = (MiscastLegendItem)ctrl;
                    if (legendItem.LegendItemEnabled)
                    {
                        legendList.Add(legendItem);
                    }
                }
            }
            return legendList.OrderBy(l => l.LegendSort).ToList();
        }

        /// <summary>
        /// Print Event Handler
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printChart.Print();
            }
        }

        /// <summary>
        /// Print Preview Event Handler
        /// </summary>
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chartMiscast != null && chartMiscast.Series.Count > 0)
            {
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Nothing to Print!",
                    "Print Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
        #endregion Printing

        private void chartMiscast_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult pointHit = chartMiscast.HitTest(e.X, e.Y);

                if (pointHit.ChartElementType == ChartElementType.DataPoint &&
                    pointHit.Series != null &&
                    pointHit.Series.Points[pointHit.PointIndex] != null &&
                    !string.IsNullOrWhiteSpace(pointHit.Series.Name) &&
                    !string.IsNullOrWhiteSpace(pointHit.Series.Points[pointHit.PointIndex].AxisLabel))
                {
                    DataPoint dp = pointHit.Series.Points[pointHit.PointIndex];

                    MiscastFilterHolder filterValues = new MiscastFilterHolder()
                    {
                        ComboFilterList = new List<Tuple<string, string>>()
                        {
                            new Tuple<string, string>(
                                dp["SeriesTitle"], pointHit.Series.Name),
                            new Tuple<string, string>(
                                dp["XAxisTitle"], pointHit.Series.Points[pointHit.PointIndex].AxisLabel),
                        },
                        DateFrom = GetFromFilterDate(dp["Date"])
                    };
                    filterValues.DateTo = GetToFilterDate(filterValues.DateFrom.Value);

                    OpenMiscastMain(filterValues);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "ERROR -- Could not get Miscast Data from click on Miscast Analysis Chart -- chartMiscast_MouseClick() -- ",
                    ex);
            }
        }

        private DateTime GetToFilterDate(DateTime dateFrom)
        {
            if (cmboXAxis.Text.Equals("Daily"))
            {
                return dateFrom.AddDays(1);
            }
            else if (cmboXAxis.Text.Equals("Weekly"))
            {
                return dateFrom.AddDays(7);
            }
            return ucDateSelector.DateTo;//Default to Form Date Filter
        }

        private DateTime GetFromFilterDate(string xAxisDate)
        {
            if (!string.IsNullOrWhiteSpace(xAxisDate))
            {
                DateTime dateToReturn = new DateTime();
                if (DateTime.TryParse(xAxisDate, out dateToReturn))
                {
                    return dateToReturn;
                }
            }
            return ucDateSelector.DateFrom;//Default to Form Date Filter
        }

        private void OpenMiscastMain(MiscastFilterHolder filterValues)
        {
            this.Cursor = Cursors.WaitCursor;
            MiscastMainNew miscastMain = new MiscastMainNew(
                filterValues, this.isAdmin);
            miscastMain.Show();
            this.Cursor = Cursors.Default;
        }

        private void chartMiscast_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;

            HitTestResult seriesHit = chartMiscast.HitTest(e.X, e.Y);
            if (seriesHit.ChartElementType == ChartElementType.DataPoint)
            {
                this.Cursor = Cursors.Hand;
            }
        }
    }
}
