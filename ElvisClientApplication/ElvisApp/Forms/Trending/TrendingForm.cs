using Elvis.Common;
using Elvis.Common.ThirdPartyControls;
using Elvis.Forms.Trending.UserControls;
using Elvis.Model;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elvis.Forms.Trending
{
    public partial class TrendingForm : Form
    {
        #region Variables and Properties
        private const int legendHeight = 40;
        private const int chartHeight = 198;

        private int groupIndexToLoad;
        private bool runWorkerAgain = false;
        private bool isMiscastAdmin;
        private bool alreadyErrored = false;
        private bool formLoaded = false;
        private StringBuilder sbPrintFilterText;
        private DateTime dateFrom;
        private DateTime dateTo;
        private List<TrendingChart> chartsToPrint;
        private List<GroupConfig> groupConfigData;
        private List<TrendDataIndex> trendDataIndex;
        private List<TrendingChart> formCharts;
        private List<GroupHighlight> highlightByList;
        private GroupHighlight highlightBy;
        private BackgroundWorker workHeatData = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor and Form Setup
        /// <summary>
        /// Creates a new instance of the TrendingForm form.
        /// </summary>
        public TrendingForm(bool isMiscastAdmin)
        {
            InitializeComponent();
            this.isMiscastAdmin = isMiscastAdmin;
            SetupBackgroundWorker();
            this.dateFrom = new DateTime();
            this.dateTo = new DateTime();
            this.groupIndexToLoad = 0;
            this.highlightBy = new GroupHighlight();
            legendToolStripMenuItem.Checked = Settings.Default.TrendShowLegend;
            SetupForm();
            SetupDateSelector();
            InitialDateSetup(DateTime.Now);
            SetupWeekNo();
            btnGenerate.Enabled = false;
            CustomiseColours();
        }

        /// <summary>
        /// Sets up the background worker that gets the data.
        /// </summary>
        private void SetupBackgroundWorker()
        {
            //Shove the DB access on a different thread to protect the UI.
            workHeatData.DoWork += new DoWorkEventHandler(workHeatData_DoWork);
            workHeatData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workHeatData_RunWorkerCompleted);
            workHeatData.WorkerSupportsCancellation = true;
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor = pnlFilter.BackColor =
                pnlFormat.BackColor = pnlDateSelector.BackColor =
                pnlHeats.BackColor = pnlGroup.BackColor =
                pnlAdditionalFilter.BackColor = pnlUnits.BackColor =
                pnlRota.BackColor = pnlSubUnits.BackColor =
                pnlGradesXHeats.BackColor = 
                pnlHighlight.BackColor = pnlLegend.BackColor =
                grpFilter.BackColor = grpFormat.BackColor =
                grpDateSelector.BackColor = grpHeatRange.BackColor =
                grpGroup.BackColor = grpGrade.BackColor =
                grpUnits.BackColor = grpXHeat.BackColor =
                grpCharts.BackColor = grpRota.BackColor =
                grpHighlight.BackColor = grpLegend.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor = pnlFilter.ForeColor =
                pnlFormat.ForeColor = pnlDateSelector.ForeColor =
                pnlHeats.ForeColor = pnlGroup.ForeColor =
                pnlAdditionalFilter.ForeColor = pnlUnits.ForeColor =
                pnlRota.ForeColor = pnlSubUnits.ForeColor =
                pnlGradesXHeats.ForeColor = 
                pnlHighlight.ForeColor = pnlLegend.ForeColor =
                grpFilter.ForeColor = grpFormat.ForeColor =
                grpDateSelector.ForeColor = grpHeatRange.ForeColor =
                grpGroup.ForeColor = grpGrade.ForeColor =
                grpUnits.ForeColor = grpXHeat.ForeColor =
                grpCharts.ForeColor = grpRota.ForeColor =
                grpHighlight.ForeColor = grpLegend.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Sets up the form ready for user input.
        /// </summary>
        private void SetupForm()
        {
            dpFrom.MaxDate = DateTime.Now;
            dpTo.MaxDate = DateTime.Now.AddDays(7);
            this.dateTo = dpTo.Value = DateTime.Now.AddDays(1);
            this.dateFrom = dpFrom.Value = DateTime.Now.AddDays(-2);
            rbFixed.Checked = true;

            lblDateStatus.Text = "No data generated";
        }

        /// <summary>
        /// Prepares the form to load into a specific time and group,
        /// dictated by the group index and date parameters.
        /// </summary>
        /// <param name="dateFrom">The Date From Value to filter on.</param>
        /// <param name="dateTo">The Date To Value to filter on.</param>
        /// <param name="groupIndex">The GroupConfig index to filter on.</param>
        public void LoadSpecificDateAndGroup(DateTime dateFrom, DateTime dateTo, int groupIndex)
        {
            rbDate.Checked = true;

            if (dateFrom <= dpFrom.MaxDate)
                dpFrom.Value = dateFrom;
            else
                dpFrom.Value = dpFrom.MaxDate;

            if (dateTo <= dpTo.MaxDate && dateTo <= DateTime.Now)
                dpTo.Value = dateTo;
            else
                dpTo.Value = dpFrom.MaxDate.AddDays(1);

            this.groupIndexToLoad = groupIndex;

            if (!workHeatData.IsBusy)
            {
                this.Cursor = Cursors.AppStarting;
                workHeatData.RunWorkerAsync();
            }
            else
            {
                this.runWorkerAgain = true;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the heat data required to populate the 
        /// heat number and grade drop downs.
        /// </summary>
        private void GetTrendDataIndices()
        {
            this.trendDataIndex = new List<TrendDataIndex>();
            if (this.dateFrom > DateTime.MinValue &&
                this.dateTo > DateTime.MinValue)
            {
                this.dateFrom = GetFromDate();
                this.dateTo = GetToDate();

                try
                {
                    this.trendDataIndex = EntityHelper.TrendDataIndex.GetByDateRange(this.dateFrom, this.dateTo);
                }
                catch (Exception ex)
                {
                    logger.ErrorException(string.Format(
                        "DATA ERROR -- Error getting Last Program Number by date range -- GetHeatData() -- " +
                        " Date From: {0} - Date To: {1} -- ", this.dateFrom, this.dateTo),
                        ex);
                }
            }
        }

        /// <summary>
        /// Gets the trend data indices ready for graph
        /// population.  Uses a string to filter the data.
        /// </summary>
        /// <param name="filter">String that represents a filter.</param>
        /// <returns>Returns a List of TrendDataIndex objects.</returns>
        private List<TrendDataIndex> GetTrendDataIndices(string filter)
        {
            try
            {
                return EntityHelper.TrendDataIndex.GetByDateRangeAndFilter(this.dateFrom, this.dateTo, filter);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    string.Format(
                        "DATA ERROR -- GetTrendDataIndices({0}) -- Error getting trend data indices -- ",
                        filter),
                    ex);
            }
            return new List<TrendDataIndex>();
        }

        /// <summary>
        /// Gets the Group Selection Data for the Group Drop Down.
        /// </summary>
        private void GetGroupSelectData()
        {
            this.groupConfigData = new List<GroupConfig>();

            try
            {
                this.groupConfigData = EntityHelper.GroupConfig.GetAllEnabled();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting Group Config data -- GetGroupSelectData() -- ",
                    ex);
            }
        }

        /// <summary>
        /// Gets the Group highlight Data for the Highlight by Drop Down.
        /// </summary>
        private void GetHighlightByData()
        {
            this.highlightByList = new List<GroupHighlight>();

            try
            {
                this.highlightByList = EntityHelper.GroupHighlight.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting Group Highlight data -- GetHighlightByData() -- ",
                    ex);
            }
        }

        /// <summary>
        /// Filters and Populates the Drop Down Lists,
        /// cmboHeatFrom, cmboHeatTo and cmboGrade
        /// </summary>
        private void PopulateDropDowns()
        {
            CommonMethods.ReadyComboBox(cmboHeatFrom);
            CommonMethods.ReadyComboBox(cmboHeatTo);
            CommonMethods.ReadyComboBox(cmboRota);
            CommonMethods.ReadyCheckedComboBox(ccbGrades, 8, ", ");
            CommonMethods.ReadyCheckedComboBox(ccbXHeats, 8, ", ");

            if (this.trendDataIndex != null &&
                this.trendDataIndex.Count > 0)
            {
                //Remove any dodgy heat numbers
                this.trendDataIndex = this.trendDataIndex.Where(h =>
                    h.HeatNumber >= Settings.Default.MinHeatNumber &&
                    h.HeatNumber <= Settings.Default.MaxHeatNumber).ToList();

                #region Heat Wrap Test Code
                ////Heat Wrap Testing!
                //int heatNumber = 10000;
                //DateTime dt = DateTime.Now;

                //for (int i = 0; i <= 10; i++)
                //{
                //    this.trendDataIndex.Add(new TrendDataIndex()
                //    {
                //        HeatNumber = heatNumber,
                //        HNS = 3,
                //        TimeStamp = dt,
                //    });
                //    heatNumber++;
                //    dt = dt.AddHours(1);
                //}
                #endregion

                cmboHeatFrom.DataSource = this.trendDataIndex
                    .OrderBy(h => h.HeatNumber)
                    .OrderBy(h => h.HNS)
                    .ToList();
                cmboHeatFrom.DisplayMember = "HeatNumber";
                cmboHeatFrom.ValueMember = "HeatNumber";

                cmboHeatTo.DataSource = this.trendDataIndex
                    .OrderByDescending(h => h.HeatNumber)
                    .OrderByDescending(h => h.HNS)
                    .ToList();
                cmboHeatTo.DisplayMember = "HeatNumber";
                cmboHeatTo.ValueMember = "HeatNumber";

                PopulateGradesList();
                PopulateXHeatsList();
                PopulateRota();
            }

            if (this.groupConfigData != null &&
                this.groupConfigData.Count > 0)
            {
                if (cmboGroup.Items.Count == 0)
                {
                    CommonMethods.ReadyComboBox(cmboGroup);
                    cmboGroup.DataSource = this.groupConfigData;
                    cmboGroup.DisplayMember = "GroupDesc";
                    cmboGroup.ValueMember = "GroupIndex";
                }
            }

            if (this.highlightByList != null &&
                this.highlightByList.Count > 0)
            {
                if (cmboHighlight.Items.Count == 0)
                {
                    CommonMethods.ReadyComboBox(cmboHighlight);
                    cmboHighlight.DataSource = this.highlightByList;
                    cmboHighlight.DisplayMember = "Description";
                    cmboHighlight.ValueMember = "HighlightID";
                    cmboHighlight.SelectedItem = GetGroupHighlight();
                }
            }
        }

        /// <summary>
        /// Populates the Rota Combobox.
        /// </summary>
        private void PopulateRota()
        {
            cmboRota.Items.Add("All");
            //Loop data finding all the rotas and adding them to combo box.
            foreach (TrendDataIndex trendDataIndex in this.trendDataIndex
                        .DistinctBy(h => h.Rota)
                        .OrderBy(h => h.Rota))
            {
                if (!string.IsNullOrWhiteSpace(trendDataIndex.Rota) &&
                    !cmboRota.Items.Contains(trendDataIndex.Rota))
                {
                    cmboRota.Items.Add(trendDataIndex.Rota);
                }
            }
            cmboRota.SelectedIndex = 0;
        }

        /// <summary>
        /// Populates the Grades Checkbox Combobox.
        /// </summary>
        private void PopulateGradesList()
        {
            ccbGrades.MaxDropDownItems = 8;
            ccbGrades.DisplayMember = "Name";
            ccbGrades.ValueSeparator = ", ";

            //Loop data finding all the grades and adding them to combo box.
            foreach (TrendDataIndex trendDataIndex in this.trendDataIndex
                        .DistinctBy(h => h.Grade)
                        .OrderBy(h => h.Grade))
            {
                //Only add if grade exists and not already in list.
                if (trendDataIndex.Grade.HasValue &&
                    trendDataIndex.Grade.Value > 0 &&
                    !ccbGrades.Items.Contains(trendDataIndex.Grade.Value.ToString()))
                {
                    CCBoxItem item = new CCBoxItem(
                        trendDataIndex.Grade.ToString(),
                        trendDataIndex.Grade.Value);

                    ccbGrades.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Populates the XHeats Checkbox Combobox.
        /// </summary>
        public void PopulateXHeatsList()
        {
            ccbXHeats.MaxDropDownItems = 8;
            ccbXHeats.DisplayMember = "Name";
            ccbXHeats.ValueSeparator = ", ";

            //Loop data finding all the XHeats and adding them to combo box.
            foreach (TrendDataIndex trendDataIndex in this.trendDataIndex
                        .DistinctBy(h => h.XHeat)
                        .OrderBy(h => h.XHeat))
            {
                //Only add if XHeat exists and not already in list.
                if (trendDataIndex.XHeat.HasValue &&
                    trendDataIndex.XHeat.Value > 0 &&
                    !ccbXHeats.Items.Contains(trendDataIndex.XHeat.Value.ToString()))
                {
                    CCBoxItem item = new CCBoxItem(
                        trendDataIndex.XHeat.ToString(),
                        trendDataIndex.XHeat.Value);

                    ccbXHeats.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Gets the Date From using the date selectors.
        /// </summary>
        /// <returns>Date from for filter as DateTime</returns>
        private DateTime GetFromDate()
        {
            if (rbDaily.Checked)
            {
                return ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    Convert.ToInt16(numDay.Value),
                    07, 00, 00, 00);
            }
            else if (rbWeekly.Checked)
            {
                return ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    1,
                    07, 00, 00, 00);
            }
            else if (rbFixed.Checked)
            {
                DateTime startOfCurrentShift = TimeFunctions.StartOfShift_PT(DateTime.Now);

                if (rbLastShift.Checked)
                {//Last Shift
                    return startOfCurrentShift.AddHours(-12);
                }
                else if (rbLastDay.Checked)
                {//Last Day
                    return startOfCurrentShift.AddDays(-1);
                }
                else
                {//Current Shift
                    return startOfCurrentShift;
                }
            }
            //Default to Date Picker
            return Convert.ToDateTime(dpFrom.Value.ToString("yyyy-MM-dd 07:00"));
        }

        /// <summary>
        /// Gets the Date To using the date selectors.
        /// </summary>
        /// <returns>Date To for filter as DateTime</returns>
        private DateTime GetToDate()
        {
            if (rbDaily.Checked)
            {
                return this.dateFrom.AddDays(1);
            }
            else if (rbWeekly.Checked)
            {
                return this.dateFrom.AddDays(7);
            }
            else if (rbFixed.Checked)
            {
                if (rbLastShift.Checked)
                {//Last Shift
                    return this.dateFrom.AddHours(12);
                }
                else if (rbLastDay.Checked)
                {//Last Day
                    return this.dateFrom.AddHours(24);
                }
                else
                {//Current Shift
                    return DateTime.Now;
                }
            }
            //Default to Date Picker
            return Convert.ToDateTime(dpTo.Value.ToString("yyyy-MM-dd 07:00"));
        }

        /// <summary>
        /// Controls the forms Sub Splitters positioning
        /// when the user Collapses or Shows the Sub filter.
        /// </summary>
        /// <param name="state">True for Shown, false for hidden.</param>
        private void ShowSubFilter(bool state)
        {
            if (state)//Show
            {
                btnShowHide2.Image = Resources.HideButtonSmallVert;
                splitContainerSub.Panel2MinSize = 130;
                splitContainerSub.SplitterDistance =
                    splitContainerSub.Width -
                    130;
                btnShowHide2.Tag = "Hide";
            }
            else//Hide
            {
                btnShowHide2.Image = Resources.ShowButtonSmallVert;
                splitContainerSub.Panel2MinSize = 10;
                splitContainerSub.SplitterDistance =
                    splitContainerSub.Panel1.ClientSize.Width +
                    splitContainerSub.Panel2.ClientSize.Width;
                btnShowHide2.Tag = "Show";
            }
        }

        /// <summary>
        /// Controls the forms Main Splitters positioning
        /// when the user Collapses or Shows the Main filter.
        /// </summary>
        /// <param name="state">True for Shown, false for hidden.</param>
        private void ShowMainFilter(bool state)
        {
            if (state)//Show
            {
                btnShowHide.Image = Resources.ShowButtonSmall;
                splitContainerMain.Panel1MinSize = 153;
                splitContainerMain.SplitterDistance = 153;
                btnShowHide.Tag = "Hide";
            }
            else//Hide
            {
                btnShowHide.Image = Resources.HideButtonSmall;
                splitContainerMain.Panel1MinSize = 10;
                splitContainerMain.SplitterDistance = 0;
                btnShowHide.Tag = "Show";
            }
        }

        /// <summary>
        /// Enables or disables the date filters depending on the 
        /// radio button selected.
        /// </summary>
        private void SetupDateSelector()
        {
            lblFrom.Enabled = dpFrom.Enabled =
            lblTo.Enabled = dpTo.Enabled =
                rbDate.Checked;

            lblWeek.Enabled = numWeek.Enabled =
            lblYear.Enabled = numYear.Enabled =
                rbWeekly.Checked;

            lblDay.Enabled = numDay.Enabled =
                rbDaily.Checked;

            if (rbDaily.Checked)
            {
                lblDay.Enabled = numDay.Enabled =
                lblWeek.Enabled = numWeek.Enabled =
                lblYear.Enabled = numYear.Enabled =
                    rbDaily.Checked;
            }

            rbLastShift.Enabled = rbLastDay.Enabled =
            rbCurrentShift.Enabled =
                rbFixed.Checked;
        }

        /// <summary>
        /// Sets the number picker for the year.
        /// </summary>
        private void InitialDateSetup(DateTime dt)
        {
            dt = dt.AddDays(-1);

            //Conversion of DayOfWeek range 0-6, we want 1-7 so add 1
            numDay.Value = (int)dt.DayOfWeek + 1;
            numWeek.Value = dt.WeekOfYear();
            numYear.Maximum = numYear.Value = dt.Year;
            numYear.Minimum = dt.Year - 5;
        }

        /// <summary>
        /// Checks for a week 53 in the currently selected year and 
        /// sets the number picker accordingly.
        /// </summary>
        private void SetupWeekNo()
        {
            if (DateTimeExtensions.IsWeek53Valid(Convert.ToInt16(numYear.Value)))
                numWeek.Maximum = 53;
            else
                numWeek.Maximum = 52;
        }

        /// <summary>
        /// Updates the date text on the form for the group boxes.
        /// </summary>
        private void UpdateDateLabel()
        {
            if (rbDate.Checked)
            {
                grpDateSelector.Text = "Date Selector";
            }
            else if (rbWeekly.Checked)
            {
                grpDateSelector.Text = string.Format("Date Selector - {0}",
                    ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    1,
                    07, 00, 00, 00));
            }
            else if (rbDaily.Checked)
            {
                grpDateSelector.Text = string.Format("Date Selector - {0}",
                    ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    Convert.ToInt16(numDay.Value),
                    07, 00, 00, 00));
            }
            else
            {
                DateTime startOfCurrentShift = TimeFunctions.StartOfShift_PT(DateTime.Now);

                if (rbLastShift.Checked)
                {//Last Shift
                    grpDateSelector.Text = string.Format("Date Selector - {0}",
                        startOfCurrentShift.AddHours(-12).ToString("dd/MM/yyyy HH:mm"));
                }
                else if (rbLastDay.Checked)
                {//Last Day
                    grpDateSelector.Text = string.Format("Date Selector - {0}",
                        startOfCurrentShift.AddDays(-1).ToString("dd/MM/yyyy HH:mm"));
                }
                else
                {//Current Shift
                    grpDateSelector.Text = string.Format("Date Selector - {0}",
                        startOfCurrentShift.ToString("dd/MM/yyyy HH:mm"));
                }
            }
        }

        /// <summary>
        /// Gets the selected groups Parameters Indices.
        /// </summary>
        /// <returns>A list of indices as ints.</returns>
        private List<int> GetGroupIndices()
        {
            List<int> indices = new List<int>();
            if (cmboGroup.SelectedItem != null &&
                cmboGroup.SelectedItem is GroupConfig)
            {
                GroupConfig groupConfig = (GroupConfig)cmboGroup.SelectedItem;

                if (groupConfig.Par1.HasValue)
                    indices.Add(groupConfig.Par1.Value);
                if (groupConfig.Par2.HasValue)
                    indices.Add(groupConfig.Par2.Value);
                if (groupConfig.Par3.HasValue)
                    indices.Add(groupConfig.Par3.Value);
                if (groupConfig.Par4.HasValue)
                    indices.Add(groupConfig.Par4.Value);
                if (groupConfig.Par5.HasValue)
                    indices.Add(groupConfig.Par5.Value);
                if (groupConfig.Par6.HasValue)
                    indices.Add(groupConfig.Par6.Value);
            }
            return indices;
        }

        /// <summary>
        /// Generates and adds the Graphs to the main area of the form.
        /// </summary>
        private void GenerateGraphs()
        {
            pnlCharts.Controls.Clear();
            this.formCharts = new List<TrendingChart>();

            List<int> groupIndices = GetGroupIndices();
            string filter = GenerateFilter();

            List<TrendDataIndex> trendDataIndices = GetTrendDataIndices(filter);
            List<TrendData> trendDatas = Model.Trending.GetTrendData(trendDataIndices);

            foreach (int index in groupIndices)
            {
                Panel pnl = new Panel();
                TrendingChart chart = new TrendingChart();
                chart.Name = "Chart" + index;
                this.formCharts.Add(chart);//Store for later

                chart.SetupUserControl(
                    index, trendDataIndices, trendDatas,
                    (GroupHighlight)cmboHighlight.SelectedItem, this.isMiscastAdmin);

                pnl.Controls.Add(chart);
                chart.Dock = DockStyle.Fill;
                pnlCharts.Controls.Add(pnl);
                pnl.Dock = DockStyle.Top;
                pnl.Height = chartHeight;
                pnl.BringToFront();
            }
        }

        /// <summary>
        /// Generates and adds the Legend to the main area of the form.
        /// </summary>
        private void GenerateLegend()
        {
            grpLegend.Controls.Clear();

            if (this.highlightBy.Description.Equals("None") ||
                !legendToolStripMenuItem.Checked)
            {
                pnlLegend.Height = 0;
            }
            else
            {
                pnlLegend.Height = legendHeight;

                List<string> legendItems = Model.Trending.GetTrendHighlightList(this.highlightBy);
                int highlightNo = 1;

                foreach (string legend in legendItems)
                {
                    TrendLegendItem legendItem = new TrendLegendItem();
                    legendItem.SetupUserControl(legend,
                        Colours.GetTrendHighlightColour(legend),
                        highlightNo);

                    grpLegend.Controls.Add(legendItem);
                    legendItem.Dock = DockStyle.Left;
                    legendItem.BringToFront();
                    highlightNo++;
                }
            }
        }

        /// <summary>
        /// Checks the drops down to see if there has been a heat set wrap.
        /// </summary>
        /// <returns>True for wrap, false for normal.</returns>
        private bool CheckForHeatWrap()
        {
            if (cmboHeatFrom.SelectedItem != null &&
                cmboHeatTo.SelectedItem != null)
            {
                TrendDataIndex dataIndexFrom = (TrendDataIndex)cmboHeatFrom.SelectedItem;
                TrendDataIndex dataIndexTo = (TrendDataIndex)cmboHeatTo.SelectedItem;
                if (dataIndexTo.HNS > dataIndexFrom.HNS)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Generates the Dynamic filter text ready for
        /// filtering the data.
        /// </summary>
        private string GenerateFilter()
        {
            StringBuilder sbFilter = new StringBuilder();

            #region Heat Range Filter
            //Filter on Heat Range
            if (cmboHeatFrom.SelectedValue != null &&
                cmboHeatTo.SelectedValue != null &&
                !chbAllHeats.Checked)
            {
                if (CheckForHeatWrap())
                {
                    TrendDataIndex dataIndexFrom = (TrendDataIndex)cmboHeatFrom.SelectedItem;
                    TrendDataIndex dataIndexTo = (TrendDataIndex)cmboHeatTo.SelectedItem;
                    if (dataIndexFrom.HeatNumber.HasValue &&
                        dataIndexTo.HeatNumber.HasValue &&
                        dataIndexFrom.HNS.HasValue &&
                        dataIndexTo.HNS.HasValue)
                    {
                        sbFilter.AppendFormat("(it.HeatNumber >= {0}", dataIndexFrom.HeatNumber.Value);
                        sbFilter.Append(" AND ");
                        sbFilter.AppendFormat("it.HeatNumber <= {0}", Settings.Default.MaxHeatNumber);
                        sbFilter.Append(" AND ");
                        sbFilter.AppendFormat("it.HNS = {0})", dataIndexFrom.HNS.Value);

                        sbFilter.Append(" OR ");

                        sbFilter.AppendFormat("(it.HeatNumber >= {0}", Settings.Default.MinHeatNumber);
                        sbFilter.Append(" AND ");
                        sbFilter.AppendFormat("it.HeatNumber <= {0}", dataIndexTo.HeatNumber.Value);
                        sbFilter.Append(" AND ");
                        sbFilter.AppendFormat("it.HNS = {0})", dataIndexTo.HNS.Value);
                    }
                }
                else
                {
                    sbFilter.AppendFormat("it.HeatNumber >= {0}", cmboHeatFrom.SelectedValue);
                    sbFilter.Append(" AND ");
                    sbFilter.AppendFormat("it.HeatNumber <= {0}", cmboHeatTo.SelectedValue);
                }
            }
            #endregion

            #region Grades Filter
            //Filter on Grades
            if (!chbAllGrades.Checked &&
                ccbGrades.Items.Count > 0 &&
                ccbGrades.CheckedItems.Count < ccbGrades.Items.Count)//Only filter if more than one item has been deselected.
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                if (ccbGrades.CheckedItems.Count == 0)
                {//Unchecked all so no data should be returned.
                    sbFilter.Append("it.Grade = 0");
                }
                else
                {
                    //Find last item in the list.
                    CCBoxItem lastItem = (CCBoxItem)ccbGrades.CheckedItems[ccbGrades.CheckedItems.Count - 1];

                    sbFilter.Append("(");
                    foreach (CCBoxItem item in ccbGrades.CheckedItems)
                    {//Build grade filter from selected grades.
                        sbFilter.AppendFormat("it.Grade = {0}", item.Value);
                        if (item != lastItem)
                            sbFilter.Append(" OR ");
                    }
                    sbFilter.Append(")");
                }
            }
            #endregion

            #region XHeat Filter
            //Filter on XHeat
            if (!chbAllXHeats.Checked &&
                ccbXHeats.Items.Count > 0 &&
                ccbXHeats.CheckedItems.Count < ccbXHeats.Items.Count)//Only filter if more than one item has been deselected.
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                if (ccbXHeats.CheckedItems.Count == 0)
                {//Unchecked all so no data should be returned.
                    sbFilter.Append("it.XHeat = 0");
                }
                else
                {
                    //Find last item in the list.
                    CCBoxItem lastItem = (CCBoxItem)ccbXHeats.CheckedItems[ccbXHeats.CheckedItems.Count - 1];

                    sbFilter.Append("(");
                    foreach (CCBoxItem item in ccbXHeats.CheckedItems)
                    {//Build XHeat filter from selected XHeats.
                        sbFilter.AppendFormat("it.XHeat = {0}", item.Value);
                        if (item != lastItem)
                            sbFilter.Append(" OR ");
                    }
                    sbFilter.Append(")");
                }
            }
            #endregion

            #region Rota Filter
            //Filter on Rota
            if (!string.IsNullOrWhiteSpace(cmboRota.Text) &&
                !cmboRota.Text.Equals("All"))
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                sbFilter.AppendFormat("it.Rota == \"{0}\"", cmboRota.Text);
            }
            #endregion

            #region Unit Filter
            //Filter on Units
            if (ucUnits != null && ucUnits.FilterMe)
            {
                if (!ucUnits.FilterHotMetal.Equals("NoFilter"))
                {
                    if (sbFilter.Length > 0)
                        sbFilter.Append(" AND ");

                    sbFilter.AppendFormat("it.HMPour = {0}", ucUnits.FilterHotMetal);
                }

                if (!ucUnits.FilterDesulph.Equals("NoFilter"))
                {
                    if (sbFilter.Length > 0)
                        sbFilter.Append(" AND ");

                    sbFilter.AppendFormat("it.HMDesulph = {0}", ucUnits.FilterDesulph);
                }

                if (!ucUnits.FilterVessels.Equals("NoFilter"))
                {
                    if (sbFilter.Length > 0)
                        sbFilter.Append(" AND ");

                    sbFilter.AppendFormat("it.Vessel = {0}", ucUnits.FilterVessels);
                }

                if (!ucUnits.FilterSecSteel.Equals("NoFilter"))
                {
                    string[] ssUnits = ucUnits.FilterSecSteel.Split('|');
                    if (ssUnits.Contains("9"))// CAS 1
                    {
                        if (sbFilter.Length > 0)
                            sbFilter.Append(" AND ");

                        sbFilter.Append("it.Cas1 = 9");
                    }
                    if (ssUnits.Contains("10"))// CAS 2
                    {
                        if (sbFilter.Length > 0)
                            sbFilter.Append(" AND ");

                        sbFilter.Append("it.Cas2 = 10");
                    }
                    if (ssUnits.Contains("7"))// RH Degasser
                    {
                        if (sbFilter.Length > 0)
                            sbFilter.Append(" AND ");

                        sbFilter.Append("it.RH = 7");
                    }
                    if (ssUnits.Contains("8"))// RD Degasser
                    {
                        if (sbFilter.Length > 0)
                            sbFilter.Append(" AND ");

                        sbFilter.Append("it.RD = 8");
                    }
                }

                if (!ucUnits.FilterCasters.Equals("NoFilter"))
                {
                    if (sbFilter.Length > 0)
                        sbFilter.Append(" AND ");

                    sbFilter.AppendFormat("it.Caster = {0}", ucUnits.FilterCasters);
                }
            }
            #endregion

            if (sbFilter.Length <= 0)//No Filter Value
                sbFilter.Append("1 = 1");

            SaveFilterTextForPrinting();

            return sbFilter.ToString();
        }

        /// <summary>
        /// Builds a User Readable version of the Filter for printing.
        /// </summary>
        private void SaveFilterTextForPrinting()
        {
            sbPrintFilterText = new StringBuilder();
            sbPrintFilterText.AppendFormat("From {0} to {1} \r\n", this.dateFrom, this.dateTo);

            #region Heat Numbers
            if (!chbAllHeats.Checked)
            {
                TrendDataIndex dataIndexFrom = (TrendDataIndex)cmboHeatFrom.SelectedItem;
                TrendDataIndex dataIndexTo = (TrendDataIndex)cmboHeatTo.SelectedItem;
                sbPrintFilterText.AppendFormat("Heat Range: from {0} to {1} \r\n", dataIndexFrom.HeatNumber, dataIndexTo.HeatNumber);
            }
            #endregion

            #region Grades
            if (!chbAllGrades.Checked &&
                ccbGrades.CheckedItems != null &&
                ccbGrades.CheckedItems.Count > 0)
            {
                sbPrintFilterText.Append("Grades: ");
                int spacerCount = 0;
                //Find last item in the list.
                CCBoxItem lastItem = (CCBoxItem)ccbGrades.CheckedItems[ccbGrades.CheckedItems.Count - 1];
                foreach (CCBoxItem item in ccbGrades.CheckedItems)
                {//Build grade filter from selected grades.
                    spacerCount++;

                    sbPrintFilterText.Append(item.Value.ToString());
                    if (item != lastItem)
                        sbPrintFilterText.Append(", ");
                    //Adds Spaces every 15 grades.
                    if (spacerCount == 15)
                        sbPrintFilterText.Append("\r\n");
                    if (spacerCount == 30)
                        sbPrintFilterText.Append("\r\n");
                    if (spacerCount == 45)
                        sbPrintFilterText.Append("\r\n");
                    if (spacerCount == 60)
                        sbPrintFilterText.Append("\r\n");
                    if (spacerCount == 75)
                        sbPrintFilterText.Append("\r\n");
                }
                sbPrintFilterText.Append("\r\n");
            }
            #endregion

            #region XHeats
            if (!chbAllXHeats.Checked &&
                ccbXHeats.CheckedItems != null &&
                ccbXHeats.CheckedItems.Count > 0)
            {
                sbPrintFilterText.Append("XHeats: ");
                int spacerCount = 0;
                //Find last item in the list.
                CCBoxItem lastItem = (CCBoxItem)ccbXHeats.CheckedItems[ccbXHeats.CheckedItems.Count - 1];
                foreach (CCBoxItem item in ccbXHeats.CheckedItems)
                {//Build Xheats filter from selected Xheats.
                    spacerCount++;

                    sbPrintFilterText.Append(item.Value.ToString());
                    if (item != lastItem)
                        sbPrintFilterText.Append(", ");
                    //Adds Spaces every 15 XHeats.
                    if (spacerCount == 15)
                        sbPrintFilterText.Append("\r\n");
                    if (spacerCount == 30)
                        sbPrintFilterText.Append("\r\n");
                    if (spacerCount == 45)
                        sbPrintFilterText.Append("\r\n");
                    if (spacerCount == 60)
                        sbPrintFilterText.Append("\r\n");
                    if (spacerCount == 75)
                        sbPrintFilterText.Append("\r\n");
                }
                sbPrintFilterText.Append("\r\n");
            }
            #endregion

            #region Rota Filter
            if (!string.IsNullOrWhiteSpace(cmboRota.Text) &&
                !cmboRota.Text.Equals("All"))
            {
                sbPrintFilterText.AppendFormat("Rota: {0} \r\n", cmboRota.Text);
            }
            #endregion

            #region Units
            if (ucUnits != null && ucUnits.FilterMe)
            {
                StringBuilder sbUnits = new StringBuilder();
                sbPrintFilterText.Append("Units: ");

                if (!ucUnits.FilterHotMetal.Equals("NoFilter"))
                {
                    if (ucUnits.FilterHotMetal.Equals("1"))
                        sbUnits.Append("HM Pour North");
                    else
                        sbUnits.Append("HM Pour South");
                }

                if (!ucUnits.FilterDesulph.Equals("NoFilter"))
                {
                    if (sbUnits.Length > 0)
                        sbUnits.Append(", ");

                    if (ucUnits.FilterDesulph.Equals("3"))
                        sbUnits.Append("HM DeSulph North");
                    else
                        sbUnits.Append("HM DeSulph South");
                }

                if (!ucUnits.FilterVessels.Equals("NoFilter"))
                {
                    if (sbUnits.Length > 0)
                        sbUnits.Append(", ");

                    if (ucUnits.FilterVessels.Equals("5"))
                        sbUnits.Append("BOS Vessel 1");
                    else
                        sbUnits.Append("BOS Vessel 2");
                }

                if (!ucUnits.FilterSecSteel.Equals("NoFilter"))
                {
                    string[] ssUnits = ucUnits.FilterSecSteel.Split('|');
                    if (ssUnits.Contains("9"))// CAS 1
                    {
                        if (sbUnits.Length > 0)
                            sbUnits.Append(", ");

                        sbUnits.Append("CAS 1");
                    }
                    if (ssUnits.Contains("10"))// CAS 2
                    {
                        if (sbUnits.Length > 0)
                            sbUnits.Append(", ");

                        sbUnits.Append("CAS 2");
                    }
                    if (ssUnits.Contains("7"))// RH Degasser
                    {
                        if (sbUnits.Length > 0)
                            sbUnits.Append(", ");

                        sbUnits.Append("RH Degasser");
                    }
                    if (ssUnits.Contains("8"))// RD Degasser
                    {
                        if (sbUnits.Length > 0)
                            sbUnits.Append(", ");

                        sbUnits.Append("RD Degasser");
                    }
                }

                if (!ucUnits.FilterCasters.Equals("NoFilter"))
                {
                    if (sbUnits.Length > 0)
                        sbUnits.Append(", ");

                    if (ucUnits.FilterCasters.Equals("11"))
                        sbUnits.Append("Caster 1");
                    else if (ucUnits.FilterCasters.Equals("12"))
                        sbUnits.Append("Caster 2");
                    else
                        sbUnits.Append("Caster 3");
                }

                sbPrintFilterText.Append(sbUnits.ToString());
            }
            #endregion
        }

        /// <summary>
        /// Used for waiting until the drop downs are populated
        /// so we can then load parameters if needed.
        /// </summary>
        private void LoadParameters()
        {
            if (cmboGroup.Items != null &&
                cmboGroup.Items.Count > 0)
            {
                cmboGroup.SelectedValue = this.groupIndexToLoad;

                if (cmboHighlight.Items != null &&
                    cmboGroup.SelectedItem is GroupConfig)
                {
                    cmboHighlight.SelectedItem = GetGroupHighlight();
                }

                btnGenerate.PerformClick();
            }
        }

        #region Events
        /// <summary>
        /// Enables or disables date pickers when changing the 
        /// format radio buttons
        /// </summary>
        private void rbFormat_CheckedChanged(object sender, EventArgs e)
        {
            SetupDateSelector();
            UpdateDateLabel();
            btnGenerate.Enabled = false;

            if (!workHeatData.IsBusy)
            {
                this.Cursor = Cursors.AppStarting;
                workHeatData.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void TrendingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Button click event for the Sub Splitter's 
        /// Show/Hide Button.
        /// </summary>
        private void btnShowHide2_Click(object sender, EventArgs e)
        {
            if (btnShowHide2.Tag.ToString() == "Hide")
            {
                ShowSubFilter(false);
            }
            else
            {
                ShowSubFilter(true);
            }
        }

        /// <summary>
        /// Button click event for the Main Splitter's 
        /// Show/Hide Button.
        /// </summary>
        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (btnShowHide.Tag.ToString() == "Hide")
            {
                ShowMainFilter(false);
            }
            else
            {
                ShowMainFilter(true);
            }
        }

        /// <summary>
        /// Generate button click event handler.
        /// </summary>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.dateFrom = GetFromDate();
            this.dateTo = GetToDate();

            lblDateStatus.Text = 
                this.dateFrom.ToString("dd/MM/yyyy HH:mm") + 
                " - " + 
                this.dateTo.ToString("dd/MM/yyyy HH:mm"); 

            if (cmboGroup.Items.Count > 0)
            {
                GenerateGraphs();
                GenerateLegend();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Reset button click event handler.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.formCharts = new List<TrendingChart>();
            this.groupIndexToLoad = 0;
            rbFixed.Checked = true;
            rbCurrentShift.Checked = true;
            chbAllHeats.Checked = true;
            chbAllGrades.Checked = true;
            chbAllXHeats.Checked = true;
            btnGenerate.Enabled = false;
            if (cmboGroup.Items.Count > 0)
                cmboGroup.SelectedIndex = 0;
            if (cmboHighlight.Items.Count > 0)
                cmboHighlight.SelectedItem = GetGroupHighlight();

            pnlCharts.Controls.Clear();
            SetupForm();
            InitialDateSetup(DateTime.Now);
            SetupWeekNo();
            GenerateLegend();

            if (this.ucUnits != null)
            {
                this.ucUnits.ResetSelections();
            }

            if (!workHeatData.IsBusy)
            {
                this.Cursor = Cursors.AppStarting;
                workHeatData.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Gets the Group to Highlight from the 
        /// selected Group Config.
        /// </summary>
        /// <returns>The GroupHighlight object to select.</returns>
        private GroupHighlight GetGroupHighlight()
        {
            if (cmboGroup.Items.Count > 0 &&
                cmboGroup.SelectedItem is GroupConfig)
            {
                GroupConfig config = (GroupConfig)cmboGroup.SelectedItem;
                return this.highlightByList.FirstOrDefault(h =>
                    h.HighlightID == config.DefaultHighlight);
            }
            return null;
        }

        /// <summary>
        /// Check changed event for the fixed radio buttons on the 
        /// date filters.
        /// </summary>
        private void rbLastX_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDateLabel();
            btnGenerate.Enabled = false;

            if (!workHeatData.IsBusy)
            {
                this.Cursor = Cursors.AppStarting;
                workHeatData.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Updates the visual date label in group box on value change.
        /// </summary>
        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateDateLabel();
            btnGenerate.Enabled = false;

            if (!workHeatData.IsBusy)
            {
                this.Cursor = Cursors.AppStarting;
                workHeatData.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Sets up week no everytime the year is changed to check for week 53.
        /// </summary>
        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            SetupWeekNo();
            UpdateDateLabel();
            btnGenerate.Enabled = false;

            if (!workHeatData.IsBusy)
            {
                this.Cursor = Cursors.AppStarting;
                workHeatData.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Event handler for the value changed event on the date pickers.
        /// </summary>
        private void dp_ValueChanged(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;

            if (this.formLoaded)
            {
                if (!this.alreadyErrored &&
                    dpFrom.Value > dpTo.Value)
                {//Invalid data and user is not aware.
                    this.alreadyErrored = true;
                    MessageBox.Show(
                        "'From' date must be before 'To' date.",
                        "Date Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                        );
                }
                else if (dpFrom.Value < dpTo.Value)
                {//Valid selection so go go go!
                    this.alreadyErrored = false;
                    if (!workHeatData.IsBusy)
                    {
                        this.Cursor = Cursors.AppStarting;
                        workHeatData.RunWorkerAsync();
                    }
                }
            }
        }

        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        private void workHeatData_DoWork(object sender, DoWorkEventArgs e)
        {
            GetTrendDataIndices();

            if (this.groupConfigData == null)
                GetGroupSelectData();

            if (this.highlightByList == null)
                GetHighlightByData();
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        private void workHeatData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PopulateDropDowns();
            this.Cursor = Cursors.Default;
            btnGenerate.Enabled = true;
            if (this.groupIndexToLoad > 0)
            {
                if (this.runWorkerAgain)
                {
                    this.runWorkerAgain = false;
                    workHeatData.RunWorkerAsync();
                    LoadParameters();
                }
            }
        }

        /// <summary>
        /// Checked changed event handler for the show all heats checkbox.
        /// Enables or disables the heat number selections.
        /// </summary>
        private void chbShowAllHeats_CheckedChanged(object sender, EventArgs e)
        {
            lblHeatFrom.Enabled = lblHeatTo.Enabled =
            cmboHeatFrom.Enabled = cmboHeatTo.Enabled =
                !chbAllHeats.Checked;
        }

        /// <summary>
        /// Checked changed event handler for the show all grades checkbox.
        /// Enables or disables the grades combobox.
        /// </summary>
        private void chbAllGrades_CheckedChanged(object sender, EventArgs e)
        {
            ccbGrades.Enabled = !chbAllGrades.Checked;
            if (ccbGrades.Enabled)
            {
                for (int i = 0; i < ccbGrades.Items.Count; i++)
                {
                    ccbGrades.SetItemChecked(i, false);
                }
            }
        }

        /// <summary>
        /// Checked changed event handler for the show all XHeats checkbox.
        /// Enables or disables the XHeats combobox.
        /// </summary>
        private void chbAllXHeats_CheckedChanged(object sender, EventArgs e)
        {
            ccbXHeats.Enabled = !chbAllXHeats.Checked;
            if (ccbXHeats.Enabled)
            {
                for (int i = 0; i < ccbXHeats.Items.Count; i++)
                {
                    ccbXHeats.SetItemChecked(i, false);
                }
            }
        }

        /// <summary>
        /// Export to Excel menu item click event handler.
        /// </summary>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string filter = GenerateFilter();
            List<TrendDataIndex> trendDataIndices = GetTrendDataIndices(filter);
            List<TrendData> trendDatas = Model.Trending.GetTrendData(trendDataIndices);

            CommonMethods.ExportDataToExcel(trendDatas, true);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Shows or Hides the legend.
        /// </summary>
        private void legendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateLegend();
            Settings.Default.TrendShowLegend = legendToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Identical to Generate button click.
        /// </summary>
        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnGenerate.PerformClick();
        }

        /// <summary>
        /// Identical to Reset button click.
        /// </summary>
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnReset.PerformClick();
        }

        /// <summary>
        /// Highlight combobox value changed event handler.
        /// </summary>
        private void cmboHighlight_SelectedValueChanged(object sender, EventArgs e)
        {
            this.highlightBy = (GroupHighlight)cmboHighlight.SelectedItem;
        }

        /// <summary>
        /// Group combobox value changed event handler.
        /// </summary>
        private void cmboGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            cmboHighlight.SelectedItem = GetGroupHighlight();
        }
        #endregion

        #region Printing
        /// <summary>
        /// Prints out the Charts Generated.
        /// </summary>
        private void printCharts_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (this.chartsToPrint != null)
            {
                GroupConfig groupConfig = (GroupConfig)cmboGroup.SelectedItem;//Find the selected Group Config.

                //Need a local variable to store charts so we can modify the global without errors.
                List<TrendingChart> localChartsToPrint = new List<TrendingChart>();
                localChartsToPrint.AddRange(this.chartsToPrint);

                int filterLineCount = 0;//Counts how many lines of filters we have to offset the charts positioning.
                double roomLeftOnPage = e.PageSettings.PrintableArea.Height;//Keeps track of paging.
                //Font setup for the pages.
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font filterFont = new Font("Arial", 11);
                Font dateFont = new Font("Arial", 10);

                //Print Header Onto Page.
                e.Graphics.DrawString(string.Format(
                    "Elvis Trending Charts Printout - {0} ",
                    groupConfig.GroupDesc),
                    headerFont, Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);

                //Print Footer Onto Page.
                e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    dateFont, Brushes.Black,
                    e.PageSettings.PrintableArea.Width - e.MarginBounds.X - 60,
                    e.PageSettings.PrintableArea.Height - e.MarginBounds.Y + 30);

                if (!this.highlightBy.Description.Equals("None"))
                {//Print Legend if needed.
                    PrintLegend(e, dateFont);
                }

                roomLeftOnPage -= 30;//Deduct enough room for the header.

                if (sbPrintFilterText != null)
                {//Add some filter text if it exists.
                    e.Graphics.DrawString(this.sbPrintFilterText.ToString(),
                        filterFont,
                        Brushes.Black,
                        e.MarginBounds.X,
                        e.MarginBounds.Y + 23);
                    filterLineCount = this.sbPrintFilterText.ToString().Split('\n').Length;
                    roomLeftOnPage -= ((filterLineCount * 25) + 30);//Keep track of the space left on page.
                }

                int chartGap = 40;
                int titleOffset = 66;
                int yAxisOffset = e.MarginBounds.Y + (filterLineCount++ * 25) + 30;

                foreach (TrendingChart chart in localChartsToPrint)
                {//Loop through each Chart that's left to print them onto the pages.
                    if (chart.CurrentChart.Name.Equals("chartTrend"))
                    {
                        //These properties are required otherwise we get funny looking charts.
                        chart.CurrentChart.Series["DataCore"].MarkerBorderWidth = 1;
                        chart.CurrentChart.Series["DataCore"].MarkerSize = 1;
                        chart.CurrentChart.Series["Data1"].MarkerBorderWidth = 1;
                        chart.CurrentChart.Series["Data1"].MarkerSize = 1;
                        chart.CurrentChart.Series["Data2"].MarkerBorderWidth = 1;
                        chart.CurrentChart.Series["Data2"].MarkerSize = 1;
                        chart.CurrentChart.Series["Data3"].MarkerBorderWidth = 1;
                        chart.CurrentChart.Series["Data3"].MarkerSize = 1;
                        chart.CurrentChart.Series["Data4"].MarkerBorderWidth = 1;
                        chart.CurrentChart.Series["Data4"].MarkerSize = 1;
                    }
                    else if (chart.CurrentChart.Name.Equals("chartDist"))
                    {
                        //These properties are required otherwise we get funny looking charts.
                        chart.CurrentChart.Series[0].MarkerBorderWidth = 1;
                        chart.CurrentChart.Series[0].MarkerSize = 1;

                        if (chart.CurrentChart.Series.Count > 1)
                        {
                            chart.CurrentChart.Series[1].MarkerBorderWidth = 1;
                            chart.CurrentChart.Series[1].MarkerSize = 1;
                        }
                        if (chart.CurrentChart.Series.Count > 2)
                        {
                            chart.CurrentChart.Series[2].MarkerBorderWidth = 1;
                            chart.CurrentChart.Series[2].MarkerSize = 1;
                        }
                        if (chart.CurrentChart.Series.Count > 3)
                        {
                            chart.CurrentChart.Series[3].MarkerBorderWidth = 1;
                            chart.CurrentChart.Series[3].MarkerSize = 1;
                        }
                    }

                    //Build the Rectangle that the chart will sit in.
                    Rectangle myRec = new Rectangle(
                        e.MarginBounds.X, yAxisOffset,
                        printCharts.DefaultPageSettings.PaperSize.Width - (e.MarginBounds.X * 2),
                        chart.Height);

                    yAxisOffset += (chart.Height + chartGap);//Keep track of the Y Positioning
                    roomLeftOnPage -= (chart.Height + chartGap + 2);//Keep track of the room.

                    if (roomLeftOnPage > chart.Height)
                    {//There is room for another chart so add it.
                        e.HasMorePages = false;
                        chart.CurrentChart.Printing.PrintPaint(e.Graphics, myRec);

                        //Adds the stats portion of the TrendingChart Control to the page.
                        AddExtraStatsToPrintPage(e, chart,
                            (yAxisOffset - myRec.Height - titleOffset));

                        this.chartsToPrint.Remove(chart);//Removes this chart as it has been printed onto the page.
                    }
                    else
                    {//No More room for charts, new page required.
                        e.HasMorePages = true;
                        return;
                    }
                }

                if (this.chartsToPrint.Count == 0 && printCharts.PrintController.IsPreview)
                {//Re-populate the charts to print on the print preview
                    //Otherwise we get a blank page.
                    this.chartsToPrint = new List<TrendingChart>();
                    this.chartsToPrint.AddRange(this.formCharts);
                }
            }
        }

        /// <summary>
        /// Prints the legend onto the bottom of the page to be printed.
        /// </summary>
        /// <param name="e">The PrintPageEventArgs</param>
        /// <param name="font">The Font for the legend items.</param>
        private void PrintLegend(System.Drawing.Printing.PrintPageEventArgs e, Font font)
        {
            //Print Legend onto page if needed
            float yRectangleLocation = e.PageSettings.PrintableArea.Height - e.MarginBounds.Y + 30;
            float xRectangleLocation = e.MarginBounds.X + 2;
            float xOffset = 0;
            float wordGap = 35;

            e.Graphics.DrawString(
                "Legend", new Font("Arial", 12, FontStyle.Bold), Brushes.Black,
                xRectangleLocation - 2, yRectangleLocation - 28);

            List<string> serieses = Model.Trending.GetTrendHighlightList(this.highlightBy);
            foreach (string series in serieses)
            {
                Brush brush = new SolidBrush(
                    Colours.GetTrendHighlightColour(series));

                Rectangle legendColourBox = new Rectangle(
                    Convert.ToInt32(xRectangleLocation + xOffset),
                    Convert.ToInt32(yRectangleLocation),
                    18, 18
                    );

                e.Graphics.FillRectangle(
                    brush, legendColourBox
                    );

                xOffset += 20;//Gap between Colour box and text

                e.Graphics.DrawString(
                    " - " + series,
                    font, Brushes.Black,
                    xRectangleLocation + xOffset,
                    yRectangleLocation);

                //Gap between legend items
                xOffset += HelperFunctions.GetFontSizeInPixels(series, font).Width + wordGap;
            }
        }

        /// <summary>
        /// Adds the additional chart stats data to the print page.
        /// </summary>
        /// <param name="e">The PrintPageEventArgs</param>
        /// <param name="chart">The TrendingChart.</param>
        /// <param name="yLocation">The Y Location for the text.</param>
        private void AddExtraStatsToPrintPage(PrintPageEventArgs e, TrendingChart chart, int yLocation)
        {
            if (chart != null)
            {
                //Setup Fonts.
                Font statsFont = new Font("Arial", 11);
                //Gather all the details.
                string title = chart.Parameter + " - ";
                string min = "Min: " + chart.ChartStats.Min.ToString("0.#");
                string max = "Max: " + chart.ChartStats.Max.ToString("0.#");
                string avg = "AVG: " + chart.ChartStats.Average.ToString("0.#");
                string srDev = "SrDev: " + chart.ChartStats.StandardDeviation.ToString("0.#");
                string cpk = "CPK: " + chart.ChartStats.CapabilityIndex.ToString("0.##");
                //Setup offsets.
                float xAxisOffset = 20;
                float wordGap = 10;

                //Draw Title
                e.Graphics.DrawString(title,
                    statsFont,
                    Brushes.Black,
                    e.MarginBounds.X + xAxisOffset,
                    yLocation);

                xAxisOffset += HelperFunctions.GetFontSizeInPixels(title, statsFont).Width + wordGap;

                //Draw Min
                e.Graphics.DrawString(min,
                    statsFont,
                    Brushes.Black,
                    e.MarginBounds.X + xAxisOffset,
                    yLocation);

                xAxisOffset += HelperFunctions.GetFontSizeInPixels(min, statsFont).Width + wordGap;

                //Draw Max
                e.Graphics.DrawString(max,
                    statsFont,
                    Brushes.Black,
                    e.MarginBounds.X + xAxisOffset,
                    yLocation);

                xAxisOffset += HelperFunctions.GetFontSizeInPixels(max, statsFont).Width + wordGap;

                //Draw AVG
                e.Graphics.DrawString(avg,
                    statsFont,
                    Brushes.Black,
                    e.MarginBounds.X + xAxisOffset,
                    yLocation);

                xAxisOffset += HelperFunctions.GetFontSizeInPixels(avg, statsFont).Width + wordGap;

                //Draw Std Dev
                e.Graphics.DrawString(srDev,
                    statsFont,
                    Brushes.Black,
                    e.MarginBounds.X + xAxisOffset,
                    yLocation);

                xAxisOffset += HelperFunctions.GetFontSizeInPixels(srDev, statsFont).Width + wordGap;

                //Draw CPK
                e.Graphics.DrawString(cpk,
                    statsFont,
                    Brushes.Black,
                    e.MarginBounds.X + xAxisOffset,
                    yLocation);

                xAxisOffset += HelperFunctions.GetFontSizeInPixels(cpk, statsFont).Width + wordGap;
            }
        }

        /// <summary>
        /// Print Event Handler
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.chartsToPrint = new List<TrendingChart>();
                this.chartsToPrint.AddRange(this.formCharts);
                printCharts.Print();
            }
        }

        /// <summary>
        /// Print Preview Event Handler
        /// </summary>
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.formCharts != null)
            {
                this.chartsToPrint = new List<TrendingChart>();
                this.chartsToPrint.AddRange(this.formCharts);
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
        #endregion

        private void TrendingForm_Load(object sender, EventArgs e)
        {
            this.formLoaded = true;
        }

        #endregion
    }
}
