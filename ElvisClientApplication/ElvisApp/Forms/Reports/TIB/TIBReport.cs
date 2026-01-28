using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Forms.Reports;
using Elvis.Forms.Tib;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using Microsoft.Reporting.WinForms;
using NLog;
using System.ComponentModel;

namespace Elvis.Forms
{
    public partial class TIBReport : Form
    {
        #region Variables + Properties

        private DateTime fromDate;
        private DateTime toDate;
        private MainForm main;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private bool isSingleUnit = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DirtyDelays { get; set; }

        private List<string> selectedUnitsOrGroups;

        #endregion Variables + Properties

        #region Constructor

        public TIBReport(MainForm main)
        {
            InitializeComponent();
            this.main = main;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Page Load Event, sets up the form ready for use.
        /// </summary>
        private void TIBReport_Load(object sender, EventArgs e)
        {
            //Do the RDLC set up first so that it loads when this form is opened

            //Enable hyperlinks on the RDLC so that we can open the delay from an item on the report
            reportViewer1.LocalReport.EnableHyperlinks = true;
            //Set a delegate for handling hyperlinks on the RDLC so that they can open forms in the application
            this.reportViewer1.Hyperlink += new Microsoft.Reporting.WinForms.HyperlinkEventHandler(this.reportViewer_Hyperlink);

            //Now set up the rest of the form
            SetupDateSelector();

            //Decides whether or the list of unit groups or single units should be loaded, so the selections are correct
            //once the form is loaded
            SetUpUnits();

            //Load checkbox list
            BindCheckedList();

            //Set up the group or unit check boxes with the selections the user quit on last time
            CommonMethods.SetupFilters(
                pnlUnitList, Settings.Default.TibReportFilters);
            //Set up the plant area check boxes with the selections the user quit on last time
            CommonMethods.SetupFilters(
                grpPlantAreas, Settings.Default.TibReportFilters);
            InitialDateSetup();
            SetupWeekNo();

            if (!string.IsNullOrWhiteSpace(Settings.Default.TibReportFilters) && 
                AtLeastOneUnitCheckboxIsChecked() &&
                AtLeastOnePlantAreaCheckboxIsChecked())
            {
                UpdateReport();
            }
            CustomiseColours();
        }

        #region Quick Fix
        //**************************************************
        //Les - Added as a quick fix for deployment.
        //I'll explain when you get back.
        private bool AtLeastOnePlantAreaCheckboxIsChecked()
        {
            foreach (CheckBox chk in grpPlantAreas.Controls)
            {
                if (chk.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        private bool AtLeastOneUnitCheckboxIsChecked()
        {
            foreach (CheckBox chk in pnlUnitList.Controls)
            {
                if (chk.Checked)
                {
                    return true;
                }
            }
            return false;
        }
        //**************************************************
        #endregion

        /// <summary>
        /// Sets the number picker for the year.
        /// </summary>
        private void InitialDateSetup()
        {
            //Conversion of DayOfWeek range 0-6, we want 1-7 so add 1
            numDay.Value = (int)MyDateTime.Now.DayOfWeek + 1;
            numWeek.Value = MyDateTime.Now.WeekOfYear();
            numYear.Maximum = numYear.Value = MyDateTime.Now.Year;
            numYear.Minimum = MyDateTime.Now.Year - 5;

            dpFrom.Value = new DateTime(MyDateTime.Now.Year, MyDateTime.Now.Month, MyDateTime.Now.Day, 7, 00, 00);
            dpTo.Value = dpFrom.Value.AddDays(1);
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
        /// Enables or disables the date filters depending on the
        /// radio button selected.
        /// </summary>
        private void SetupDateSelector()
        {
            lblFrom.Enabled = dpFrom.Enabled =
            lblTo.Enabled = dpTo.Enabled =
                rbDate.Checked;

            lblDay.Enabled = numDay.Enabled =
            lblWeek.Enabled = numWeek.Enabled =
            lblYear.Enabled = numYear.Enabled =
                !rbDate.Checked;

            lblDay.Enabled = numDay.Enabled =
                rbDaily.Checked;
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            pnlReport.BackColor =
            pnlFilter.BackColor =
            grpFilter.BackColor =
            grpFormat.BackColor =
            grpDateSelector.BackColor =
            grpUnits.BackColor =
            grpPlantAreas.BackColor =
                Settings.Default.ColourBackground;

            pnlFilter.ForeColor =
            grpFilter.ForeColor =
            grpFormat.ForeColor =
            grpDateSelector.ForeColor =
            grpUnits.ForeColor =
            grpPlantAreas.ForeColor =
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Update the RDLC Report
        /// </summary>
        private void UpdateReport()
        {
            List<TibReportsView> partialDelays = new List<TibReportsView>();
            StringBuilder sb = new StringBuilder();
            //string filter = BuildFilter(); - comment this back in to revert to functionality pre inclusion of Tibs without delays
            //Newly added to include Tibs without delays - comment out to revert
            string withDelayfilter = BuildPlantFilters(BuildUnitFilters(BuildDateFilter()));
            string withoutDelayFilter = BuildUnitFilters(BuildDateFilter());

            //Comment out to revert to functionality pre inclusion of Tibs without delays
            //Extend the withoutDelayFilter to get only Tibs with no delay index
            sb.Append(withoutDelayFilter);
            sb.Append("AND (it.TibDelayIndex is null) AND (it.TibDuration > 0)");

            if (withDelayfilter != "CANCEL")
            {
                try
                {
                    //Comment this back in to revert to functionality pre inclusion of Tibs without delays
                    //List<TibReportsView> delays = EntityHelper.TibReportsView.GetByFilter(withDelayfilter);

                    //****************************************************************************************
                    //New code to enable inclusion of Tibs without delays, comment out to revert
                    List<TibReportDelaysView> tibsWithoutDelays = new List<TibReportDelaysView>();
                    List<TibReportsView> delays = new List<TibReportsView>();

                    //If rbExcludeUnnamed is checked, just get the delays, this is the default behaviour
                    //if (rbExcludeUnnamed.Checked)
                    //{
                        delays = EntityHelper.TibReportsView.GetByFilter(withDelayfilter);
                        
                    //}

                    //If rbIncludeUnnamed is checked get the delay data and the Tibs without delays
                    //and combine them
                    if (rbIncludeUnnamed.Checked)
                    {
                        //delays = EntityHelper.TibReportsView.GetByFilter(withDelayfilter);
                        partialDelays = AddPartiallyComplete(delays);
                        if (partialDelays.Count > 0)
                        {
                            delays.AddRange(partialDelays);
                        }
                        tibsWithoutDelays = EntityHelper.TibReportDelaysView.GetDelaysByFilter(sb.ToString());
                        delays = BuildListIncludingNulls(delays, tibsWithoutDelays);
                        delays = delays.OrderBy(d => d.DelayStart).ToList();
                    }

                    //If rbOnlyUnnamed is checked, get only the Tibs without delays and combine with an
                    //empty delayData list
                    if (rbOnlyUnnamed.Checked == true)
                    {
                        partialDelays = AddPartiallyComplete(delays);
                        delays.Clear();
                        delays.AddRange(partialDelays);
                        tibsWithoutDelays = EntityHelper.TibReportDelaysView.GetDelaysByFilter(sb.ToString());
                        delays = BuildListIncludingNulls(delays, tibsWithoutDelays);
                    }
                    //End of new code
                    //****************************************************************************************
                    HelperFunctions.RemoveInvalidDelayData(delays, this.fromDate, this.toDate);

                    TIBDelayBindingSource.DataSource = delays;

                    ReportParameter p1 = new ReportParameter("ReportPeriod", BuildReportHeader());
                    reportViewer1.LocalReport.SetParameters(p1);

                    this.reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    logger.ErrorException("DATA ERROR TIBReport -- UpdateReport() -- " +
                        "Getting TIB Reports View data from database and binding with report -- ", ex);
                }
            }
        }

        /// <summary>
        /// Builds the string to populate the header of the report.
        /// </summary>
        /// <returns>A header as a string.</returns>
        private string BuildReportHeader()
        {
            return string.Format(
                "From {0} To {1} ({2} Delays) ",
                this.fromDate.ToString("dd-MM-yyyy HH:mm"),
                this.toDate.ToString("dd-MM-yyyy 07:00"),
                TIBDelayBindingSource.Count
                );
        }

        /// <summary>
        /// Method that builds the dynamic linq filter for use when returning records.
        /// Commented out code was how the filter worked before introducing Tibs wothout delays to the report.
        /// These sections have been split into 3 new methods:
        /// BuildDateFilter()
        /// BuildUnitFilters()
        /// BuildPlantFilters()
        /// This has been done to allow different filters to be created dependent on how the user wants
        /// to treat Tibs without delays (leave out, include, show only Tibs without delays)
        /// </summary>
        /// <returns>The filter as a string.</returns>
        private string BuildFilter()
        {
            StringBuilder sbFilter = new StringBuilder();
            string dateFilter = BuildDateFilter();
            string filter = string.Empty;
            //if (rbExcludeUnnamed.Checked || )
            //{
            //    //Create a filter that will load the report showing recorded delays only (default behaviour)
            //    filter = BuildPlantFilters(BuildUnitFilters(dateFilter));
            //}

            //if (rbOnlyUnnamed.Checked == true)
            //{
            //    //Create a filter that will load the report showing only Tibs without delays
            //    filter = BuildPlantFilters
            //}

            //if (rbIncludeUnnamed.Checked == true)
            //{
            //     //Create a filter that will load the report showing delays and Tibs without delays
            //}

            //fromDate = GetFromDate();
            //toDate = GetToDate();

            //Date Filters - must be this format for dates
            //sbFilter.AppendFormat("((it.EventStart >= DATETIME '{0}' ",
            //    fromDate.ToString("yyyy-MM-dd HH:mm"));
            //sbFilter.AppendFormat("AND it.EventStart < DATETIME '{0}')",
            //    toDate.ToString("yyyy-MM-dd HH:mm"));

            //sbFilter.Append(" OR ");

            //sbFilter.AppendFormat("(it.EventEnd >= DATETIME '{0}' ",
            //    fromDate.ToString("yyyy-MM-dd HH:mm"));
            //sbFilter.AppendFormat("AND it.EventStart < DATETIME '{0}')",
            //    toDate.ToString("yyyy-MM-dd HH:mm"));

            //sbFilter.Append(" OR ");

            //sbFilter.AppendFormat("(it.EventStart < DATETIME '{0}' ",
            //    fromDate.ToString("yyyy-MM-dd HH:mm"));
            //sbFilter.AppendFormat("AND it.EventEnd >= DATETIME '{0}')) ",
            //    toDate.ToString("yyyy-MM-dd HH:mm"));

            //sbFilter.Append(AddUnitFilters(pnlUnitList, isSingleUnit ? "UnitNumber" : "UnitGroup"));

            //if (sbFilter.ToString().Contains("CANCEL"))
            //{
            //    MessageBox.Show(
            //        "Please select at least one Unit to search for.", "Search Aborted",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Stop);
            //    return "CANCEL";//Cancel query
            //}

            sbFilter.Append(AddCheckboxFilters(grpPlantAreas, "PlantArea"));

            if (sbFilter.ToString().Contains("CANCEL"))
            {
                MessageBox.Show(
                    "Please select at least one Plant Area to search for.", "Search Aborted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return "CANCEL";//Cancel query
            }

            if (sbFilter.ToString().Contains("CANCEL"))
                return "CANCEL";//Cancel query

            return filter;// sbFilter.ToString();
        }

        /// <summary>
        /// Used to build the date part of the dynamic filter - used for queries that include or exclude Tibs without delays
        /// </summary>
        /// <returns>String representing date part of filter</returns>
        private string BuildDateFilter()
        {
            StringBuilder sbFilter = new StringBuilder();
            fromDate = GetFromDate();
            toDate = GetToDate();

            //Date Filters - must be this format for dates
            sbFilter.AppendFormat("((it.EventStart >= DATETIME '{0}' ",
                fromDate.ToString("yyyy-MM-dd HH:mm"));
            sbFilter.AppendFormat("AND it.EventStart < DATETIME '{0}')",
                toDate.ToString("yyyy-MM-dd HH:mm"));

            sbFilter.Append(" OR ");

            sbFilter.AppendFormat("(it.EventEnd > DATETIME '{0}' ",
                fromDate.ToString("yyyy-MM-dd HH:mm"));
            sbFilter.AppendFormat("AND it.EventStart < DATETIME '{0}')",
                toDate.ToString("yyyy-MM-dd HH:mm"));

            sbFilter.Append(" OR ");

            sbFilter.AppendFormat("(it.EventStart < DATETIME '{0}' ",
                fromDate.ToString("yyyy-MM-dd HH:mm"));
            sbFilter.AppendFormat("AND it.EventEnd > DATETIME '{0}')) ",
                toDate.ToString("yyyy-MM-dd HH:mm"));
            return sbFilter.ToString();
        }

        /// <summary>
        /// Used to build the unit or unit group part of the dynamic filter - used for queries that include or exclude Tibs without delays
        /// </summary>
        /// <param name="filter">The date part of the filter</param>
        /// <returns>The filter including unit or unit group numbers</returns>
        private string BuildUnitFilters(string filter)
        {
            StringBuilder sbFilter = new StringBuilder();
            sbFilter.Append(filter);
            sbFilter.Append(AddUnitFilters(pnlUnitList, isSingleUnit ? "UnitNumber" : "UnitGroup"));

            if (sbFilter.ToString().Contains("CANCEL"))
            {
                MessageBox.Show(
                    "Please select at least one Unit to search for.", "Search Aborted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return "CANCEL";//Cancel query
            }
            return sbFilter.ToString();
        }

        /// <summary>
        /// Used to build the plant area part of the dynamic filter - only used to retrieve delay data.
        /// </summary>
        /// <param name="filter">The date and unit or unit group part of the filter</param>
        /// <returns>The filter with plant area details included</returns>
        private string BuildPlantFilters(string filter)
        {
            StringBuilder sbFilter = new StringBuilder();
            sbFilter.Append(filter);
            sbFilter.Append(AddCheckboxFilters(grpPlantAreas, "PlantArea"));

            if (sbFilter.ToString().Contains("CANCEL"))
            {
                MessageBox.Show(
                    "Please select at least one Plant Area to search for.", "Search Aborted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return "CANCEL";//Cancel query
            }

            if (sbFilter.ToString().Contains("CANCEL"))
                return "CANCEL";//Cancel query
            return sbFilter.ToString();
        }

        /// <summary>
        /// Creates a list of TibReportsView objects made up from Tibs with and without delays. Only used when the query is for either
        /// delays and Tibs without delays or Tibs without delays only/
        /// </summary>
        /// <param name="withoutNulls">The list of Tibs with delays</param>
        /// <param name="withNulls">The list of Tibs without delays</param>
        /// <returns>A list of TibReportsView made up of both input lists</returns>
        private List<TibReportsView> BuildListIncludingNulls(List<TibReportsView> withoutNulls, List<TibReportDelaysView> withNulls)
        {
            List<TibReportsView> fullList = withoutNulls;
            foreach (TibReportDelaysView v in withNulls.OrderBy(t => t.UnitGroup).ThenBy(t => t.UnitNumber)
                .ThenBy(t => t.EventStart).ToList())
            {
                fullList.Add(new TibReportsView
                {
                    TibIndex = v.TibIndex,
                    DelayStart = v.EventStart,  //I'm spoofing the delay start here to be the event start, so that this item
                    //shows with a start date on the TibReport rdlc.
                    DelayEnd = v.EventEnd,
                    UnitShort = v.UnitShort,
                    DelayDuration = v.TibDuration
                });
            }
            return fullList;
        }

        /// <summary>
        /// Adds partially completed TIBS to the list of delays (i.e. events that do not have enough delay minutes
        /// to cover the whole event).
        /// A by product of this method is that it also shows TIB events where the delays exceed to event duration,
        /// these can then be corrected. This is why the tibDuration - delayDuration > 0 line has been commented
        /// out. This can be added back in if this feature isn't required.
        /// </summary>
        /// <param name="baseData"></param>
        /// <returns></returns>
        private List<TibReportsView> AddPartiallyComplete(List<TibReportsView> baseData)
        {
            StringBuilder sb = new StringBuilder();
            //Get a list of distinct tib indexes from the base list
            List<TibReportsView> distinctEvents = Enumerable.DistinctBy(baseData,d => d.TibIndex).ToList();
            List<TibReportsView> partiallyCompletedEvents = new List<TibReportsView>();
            int? tibDuration = 0;
            int? delayDuration = 0;
            
            TIBEvent baseTibEvent = new TIBEvent();
            foreach (TibReportsView t in distinctEvents)
            {
                //Sum the delay duration
                 delayDuration = baseData.Where(d => d.TibIndex == t.TibIndex).ToList().Sum(d => d.DelayDuration);
                //Get the tib event for the tib index
                baseTibEvent = EntityHelper.TIBEvents.GetSingle(t.TibIndex);
                if (baseTibEvent != null)
                {
                    tibDuration = baseTibEvent.TibDuration;
                }
                if (tibDuration > 0)
                {
                    if (tibDuration != delayDuration)
                    {
                        if (tibDuration - delayDuration > 0)
                        {
                            partiallyCompletedEvents.Add(new TibReportsView
                            {
                                TibIndex = t.TibIndex,
                                DelayStart = t.EventStart,
                                UnitShort = t.UnitShort,
                                DelayDuration = tibDuration - delayDuration
                            });
                        }
                    }
                }
                //Get the tib duration for the tib index
            }
            return partiallyCompletedEvents;
        }

        /// <summary>
        /// Loops the groupbox to find checkboxes and generates a
        /// filter as a string depending on the checked items.
        /// </summary>
        /// <param name="grpBox">The Group Box to Loop.</param>
        /// <param name="columnName">The Column Name to Filter on.</param>
        /// <returns>The filter as a string.</returns>
        private string AddCheckboxFilters(GroupBox grpBox, string columnName)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;

            foreach (CheckBox chb in grpBox.Controls)
            {
                if (chb.Checked)
                {
                    string[] units = chb.Tag.ToString().Split('|');
                    foreach (string unit in units)
                    {
                        string formatUnit = unit;
                        if (columnName == "PlantArea")//Format for string
                            formatUnit = string.Format("'{0}'", unit);

                        if (first)
                        {//First Added to filter
                            sb.AppendFormat("AND (it.{0} = {1} ",
                                columnName, formatUnit);
                            first = false;
                        }
                        else//All the rest
                            sb.AppendFormat("OR it.{0} = {1} ",
                                columnName, formatUnit);
                    }
                }
            }

            if (sb.Length > 0)
                sb.Append(") ");
            else//Cancel query because none selected
                sb.Append(" CANCEL ");

            return sb.ToString();
        }

        /// <summary>
        /// Adds unit or unit group numbers to the dynamic linq query.
        /// </summary>
        /// <param name="pnUnits"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private string AddUnitFilters(Panel pnUnits, string columnName)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (CheckBox chk in pnlUnitList.Controls)
            {
                if (chk.Checked)
                {
                    if (first)
                    {
                        sb.AppendFormat("AND (it.{0} = {1} ", columnName, Convert.ToInt16(chk.Tag));
                        first = false;
                    }
                    else
                    {
                        sb.AppendFormat("OR it.{0} = {1} ", columnName, Convert.ToInt16(chk.Tag));
                    }
                }
            }
            if (sb.Length > 0)
                sb.Append(") ");
            else//Cancel query because none selected
                sb.Append(" CANCEL ");
            return sb.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        private void SetUpUnits()
        {
            //Work out whether the user quit the report with groups or units selected and bind the list of check boxes accordingly
            if (Settings.Default.TibReportFilters.Contains("|"))
            {
                isSingleUnit = Settings.Default.TibReportFilters.Substring(0, Settings.Default.TibReportFilters.IndexOf("|")).Contains("Groups") ?
                    false : true;
                //Check the respective Unit or Group radio button
                switch (isSingleUnit)
                {
                    case true:
                        rbUnitGroups.Checked = false;
                        rbUnits.Checked = true;
                        break;
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
                return this.fromDate.AddDays(1);
            }
            else if (rbWeekly.Checked)
            {
                return this.fromDate.AddDays(7);
            }
            //Default to Date Picker
            return Convert.ToDateTime(dpTo.Value.ToString("yyyy-MM-dd 07:00"));
        }

        /// <summary>
        /// Resets the Checkboxes and Radio Buttons
        /// </summary>
        private void ResetOptions()
        {
            rbDate.Checked = true;

            foreach (Control ctrl in pnlUnitList.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox chb = (CheckBox)ctrl;
                    chb.Checked = true;
                }
            }
            foreach (Control ctrl in grpPlantAreas.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox chb = (CheckBox)ctrl;
                    chb.Checked = true;
                }
            }
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
            else
            {
                grpDateSelector.Text = string.Format("Date Selector - {0}",
                    ShiftDateTime.ConvertTo_CalendarDateTime(12,
                    Convert.ToInt16(numYear.Value),
                    Convert.ToInt16(numWeek.Value),
                    Convert.ToInt16(numDay.Value),
                    07, 00, 00, 00));
            }
        }

        /// <summary>
        /// Binds the check boxes with text and tag values from the Config.Unit table dependent on the value
        /// of isSingleUnit.
        /// </summary>
        private void BindCheckedList()
        {
            int locX = 10;
            int locY = 0;
            List<Unit> unitSelections = isSingleUnit ? EntityHelper.Units.GetAll().Where(u => u.UnitGroupSort != null).ToList() :
                EntityHelper.Units.GetAll().Where(u => u.UnitGroupSort != null).ToList().GroupBy(u => u.UnitGroupNumber)
                .Select(u => u.First()).ToList();

            grpUnits.Text = isSingleUnit ? "Units" : "Unit Groups";
            pnlUnitList.Controls.Clear();
            foreach (Unit unit in unitSelections)
            {
                CheckBox chk = new CheckBox();
                if (isSingleUnit)
                {
                    chk.Text = unit.UnitText;
                    chk.Tag = unit.UnitNumber;
                }
                else
                {
                    chk.Text = unit.UnitGroupText;
                    chk.Tag = unit.UnitGroupNumber;
                }
                chk.Location = new System.Drawing.Point(locX, locY);
                chk.Font = new Font(chk.Font, FontStyle.Regular);
                chk.Width = 150;
                pnlUnitList.Controls.Add(chk);
                chk.BringToFront();
                locY = chk.Location.Y + 18;
            }
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Close Form Menu Click Event
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Button Click Event to Generate a Report
        /// </summary>
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (rbDate.Checked &&
                HelperFunctions.VerifyFilterSelections(dpFrom.Value, dpTo.Value))
            {
                UpdateReport();
            }
            else if (!rbDate.Checked)
            {
                UpdateReport();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Close Form using Escape
        /// </summary>
        private void TIBReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Sets up week no everytime the year is changed to check for week 53.
        /// </summary>
        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            SetupWeekNo();
            UpdateDateLabel();
        }

        /// <summary>
        /// Enables or disables date pickers when changing the
        /// format radio buttons
        /// </summary>
        private void rbFormat_CheckedChanged(object sender, EventArgs e)
        {
            SetupDateSelector();
            UpdateDateLabel();
        }

        /// <summary>
        /// Resets the filter options to default settings
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetOptions();
            SetupDateSelector();
            InitialDateSetup();
            SetupWeekNo();
            UpdateReport();
        }

        /// <summary>
        /// Updates the visual date label in group box on value change.
        /// </summary>
        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateDateLabel();
        }

        private void delaysToEnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TIBDelaysToEnterReport report = new TIBDelaysToEnterReport(this.main);
            report.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void tibAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DelayAnalysisReport delayAnalysis = new DelayAnalysisReport(this.main);
            delayAnalysis.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void tibReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TIBReport tibReport = new TIBReport(this.main);
            tibReport.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void tibTimeInProductionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TIBTimeInProduction report = new TIBTimeInProduction(this.main);
            report.Show();
            this.Cursor = Cursors.Default;
            this.Close();
        }

        /// <summary>
        /// Form Closing Event. Saves user settings on close.
        /// </summary>
        private void TIBReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save User Settings
            //Define whether or not the unit list refers to groups or units
            Settings.Default.TibReportFilters = isSingleUnit ? "Units|" : "Groups|";
            //Add the actual unit or group numbers and plant areas
            Settings.Default.TibReportFilters +=
                CommonMethods.BuildSettingsString(pnlUnitList);
            Settings.Default.TibReportFilters +=
                CommonMethods.BuildSettingsString(grpPlantAreas);
            CommonMethods.SaveElvisSettings();
        }

        /// <summary>
        /// Handles the hyerlinks clicked on the report viewer.
        /// </summary>
        private void reportViewer_Hyperlink(object sender, HyperlinkEventArgs e)
        {
            //Remove non parameter text
            string parameters = e.Hyperlink.Substring(e.Hyperlink.IndexOf('?') + 1);
            OpenDelayEntry(parameters.Split('&'));
            e.Cancel = true;
        }

        /// <summary>
        /// Opens the delay entry form to enter delays for an event.
        /// </summary>
        /// <param name="parameters">The parameters passed from the hyperlink clicked.</param>
        private void OpenDelayEntry(string[] parameters)
        {
            int tibIndex = Convert.ToInt32(
                parameters[0].Substring(parameters[0].IndexOf('=') + 1)
                );

            using (DelayEntry delayEntryForm =
                new DelayEntry(tibIndex))
            {
                delayEntryForm.ShowDialog();

                if (delayEntryForm != null &&
                    !delayEntryForm.IsDisposed &&
                    delayEntryForm.DirtyDelays)
                {
                    UpdateReport();
                    this.DirtyDelays = true;
                }
                else
                {
                    if (delayEntryForm.IsDisposed)
                    {
                        logger.Info("Delay Entry form is null or disposed in OpenDelayEntry() on TIBDelaysToEnterReport.cs");
                    }
                }
            }
        }

        /// <summary>
        /// Radio button selection for the user to switch between reporting on unit groups or units. Changes
        /// the contents of pnlUnitList and grpUnits text (via BindCheckedList).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbUnitSelection_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Name == "rbUnitGroups")
                isSingleUnit = false;
            else
                isSingleUnit = true;
            BindCheckedList();
        }

        #endregion Events
    }
}