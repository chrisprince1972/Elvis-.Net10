using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using Elvis.Common;
using Elvis.Forms.Reports;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using Microsoft.Reporting.WinForms;
using NLog;
using ElvisDataModel;
using BusinessLogic.Constants;

namespace Elvis.Forms
{
    public partial class DelayAnalysisReport : Form
    {
        public enum GroupBy
        {
            Area,
            Class,
            Discipline,
            Category,
            OeeLossCategory,
            LossType,
            Owner,
            ReportLevel1,
            ReportLevel2
        }
        #region Variables
        private DateTime fromDate;
        private DateTime toDate;
        private MainForm main;
        private string unitSelectedText = string.Empty;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private GroupBy? ResultsGroupBy { get; set; }
        private List<UnitGroup> CheckedUnitGroups { get; set; }
        #endregion

        public DelayAnalysisReport(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            ResultsGroupBy = null;
            CheckedUnitGroups = new List<UnitGroup>();
        }

        public DelayAnalysisReport(MainForm main, GroupBy gb)
        {
            InitializeComponent();
            this.main = main;
            ResultsGroupBy = gb;
            CheckedUnitGroups = new List<UnitGroup>();
        }

        public DelayAnalysisReport(MainForm main, List<UnitGroup> selectedUnitGroups)
        {
            InitializeComponent();
            this.main = main;
            ResultsGroupBy = null;
            CheckedUnitGroups = selectedUnitGroups;
        }

        #region Methods
        /// <summary>
        /// Form Load event, sets up the intitial config of the form.
        /// </summary>
        private void DelayAnalysisReport_Load(object sender, EventArgs e)
        {
            SetupFilter();
            SetupDateSelector();
            InitialDateSetup();
            SetupWeekNo();
            CustomiseColours();

            if (AutoLoad())
            {
                BuildReport();
            }
        }

        private void SetupFilter()
        {
            SetupUnitFilter();
            SetupGroupByFilter();
        }

        private bool AutoLoad()
        {
            return ResultsGroupBy != null || CheckedUnitGroups != null;
        }

        //requirement to setup filters depending on where the user came from.
        private void SetupUnitFilter()
        {
            if (CheckedUnitGroups.Count > 0)
            {
                List<BusinessLogic.Constants.Unit> units = UnitHelper.GetUnits(CheckedUnitGroups);
                foreach (Control c in grpUnits.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox ch = (CheckBox)c;
                        int tagVal = int.Parse(c.Tag.ToString());
                        ch.Checked = units.Contains((BusinessLogic.Constants.Unit)tagVal);
                    }
                }
            }
            else
            {
                CommonMethods.SetupFilters(
                    grpUnits, Settings.Default.DelayAnalysisReportFilters);
            }
        }

        private void SetupGroupByFilter()
        {
            if (ResultsGroupBy == null)
            {
                if (string.IsNullOrWhiteSpace(Settings.Default.DelayAnalysisReportGroupBy))
                    cmbGroupBy.SelectedIndex = 0;
                else
                    cmbGroupBy.SelectedItem = Settings.Default.DelayAnalysisReportGroupBy;
            }
            else
            {
                cmbGroupBy.SelectedIndex = (int)ResultsGroupBy;
            }
        }


        /// <summary>
        /// Sets the number picker for the year.
        /// </summary>
        private void InitialDateSetup()
        {
            //Conversion of DayOfWeek range 0-6, we want 1-7 so add 1
            numDay.Value = (int)DateTime.Now.DayOfWeek + 1;
            numWeek.Value = DateTime.Now.WeekOfYear();
            numYear.Maximum = numYear.Value = DateTime.Now.Year;
            numYear.Minimum = DateTime.Now.Year - 5;

            dpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 00, 00);
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
            grpReport.BackColor =
            grpDateSelector.BackColor =
            grpFormat.BackColor =
            grpGroupBy.BackColor =
            grpUnits.BackColor =
                Settings.Default.ColourBackground;

            pnlReport.ForeColor =
            pnlFilter.ForeColor =
            grpReport.ForeColor =
            grpDateSelector.ForeColor =
            grpFormat.ForeColor =
            grpGroupBy.ForeColor =
            grpUnits.ForeColor =
                Settings.Default.ColourText;
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
        /// Builds and shows the report in the report viewer.
        /// </summary>
        private void BuildReport()
        {
            try
            {
                List<TibReportsView> delayData = new List<TibReportsView>();
                List<TibReportDelaysView> tibsWithoutDelays = new List<TibReportDelaysView>();
                List<TibOEEReport> oeeDelayData = new List<TibOEEReport>();
                List<TibReportsView> partialDelays = new List<TibReportsView>();

                if (fromDate == DateTime.MinValue && toDate == DateTime.MinValue && AutoLoad())
                {
                    this.fromDate = dpFrom.Value = DateTime.Now.AddDays(-1);
                    this.toDate = dpTo.Value = DateTime.Now;
                }
                else
                {
                    this.fromDate = GetFromDate();
                    this.toDate = GetToDate();
                }

                //Default behaviour will be to show only delays and OEE data so populate those lists first
                delayData = EntityHelper.TibReportsView.GetByDateAndUnit(
                    GetSelectedUnits(), this.fromDate, this.toDate);

                //Get OEE data so that the extra groupings can be applied
                oeeDelayData = EntityHelper.TibOEEReport.GetByDateAndUnit(
                    GetSelectedUnits(), this.fromDate, this.toDate);

                //If unnamed delays are to be included with all other delays, get them then add them to both existing
                //delay lists
                if (rbIUnnamedInclude.Checked)
                {
                    partialDelays = AddPartiallyComplete(delayData);
                    if (partialDelays.Count > 0)
                    {
                        delayData.AddRange(partialDelays);
                        AddNewOEEDelays(partialDelays, oeeDelayData);
                    }
                    tibsWithoutDelays = EntityHelper.TibReportDelaysView.GetByDateAndUnit(
                        GetSelectedUnits(), this.fromDate, this.toDate);
                    BuildReportWithNulls(delayData, oeeDelayData, tibsWithoutDelays);
                }

                //If unnamed delays only are to be shown, get them then clear the
                //delay lists
                if (rbUnnamedOnly.Checked)
                {
                    partialDelays = AddPartiallyComplete(delayData);
                    tibsWithoutDelays = EntityHelper.TibReportDelaysView.GetByDateAndUnit(
                        GetSelectedUnits(), this.fromDate, this.toDate);
                    delayData.Clear();
                    delayData = partialDelays;
                    oeeDelayData.Clear();
                    AddNewOEEDelays(partialDelays, oeeDelayData);
                    BuildReportWithNulls(delayData, oeeDelayData, tibsWithoutDelays);
                }
                
                HelperFunctions.RemoveInvalidDelayData(
                    delayData, this.fromDate, this.toDate);
                HelperFunctions.RemoveInvalidDelayData(
                    oeeDelayData, this.fromDate, this.toDate);
               
                TibReportsViewBindingSource.DataSource = delayData;
                OEEDelayDataBindingSource.DataSource = oeeDelayData;
                                
                ReportParameter p1 = new ReportParameter("GroupBy", cmbGroupBy.Text);
                reportViewer1.LocalReport.SetParameters(p1);

                ReportParameter p2 = new ReportParameter("DateTitle", GetDateTitle());
                reportViewer1.LocalReport.SetParameters(p2);

                ReportParameter p3 = new ReportParameter("Unit", unitSelectedText);
                reportViewer1.LocalReport.SetParameters(p3);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR DelayAnalysisReport -- BuildReport() -- " +
                    "Getting TIB Anlysis data from database and binding to report -- ", ex);
            }
        }

        /// <summary>
        /// Gets the units that are selected and create an int 
        /// list for filtering.
        /// </summary>
        /// <returns>A list of the unit numbers to be used in the filered data.</returns>
        private List<int> GetSelectedUnits()
        {
            bool first = true;
            List<int> selectedUnits = new List<int>();

            foreach (CheckBox chb in grpUnits.Controls)
            {
                if (chb.Checked)
                {
                    selectedUnits.Add(Convert.ToInt16(chb.Tag));
                    if (first)
                    {
                        unitSelectedText = chb.Text;
                        first = false;
                    }
                    else
                        unitSelectedText += ", " + chb.Text;
                }
            }
            return selectedUnits;
        }

        /// <summary>
        /// Builds the date title for the report.
        /// </summary>
        /// <returns>The Date Title as string.</returns>
        private string GetDateTitle()
        {
            return string.Format(
                "From {0} To {1} ",
                this.fromDate.ToString("dd-MM-yyyy HH:mm"),
                this.toDate.ToString("dd-MM-yyyy HH:mm")
                );
        }

        /// <summary>
        /// Resets the filters and report to default.
        /// </summary>
        private void ResetFilters()
        {
            TibReportsViewBindingSource.DataSource = null;
            reportViewer1.Clear();
            reportViewer1.Refresh();
            SetupDateSelector();
            InitialDateSetup();
            SetupWeekNo();
            cmbGroupBy.SelectedIndex = 0;
            rbDate.Checked = true;

            foreach (CheckBox chb in grpUnits.Controls)
            {
                chb.Checked = true;
            }
        }

        /// <summary>
        /// If unnamed items are to be included on the report this adds them to delayData and oeeData base delay lists.
        /// Void return as the unnamed items will be added to the existing lists.
        /// </summary>
        /// <param name="delays">Delay data without unnamed items</param>
        /// <param name="oeeDelays">oeeData data without unnamed items</param>
        /// <param name="tibsWithoutDelays">Tibs delay events with no delay data (unnamed items)</param>
        private void BuildReportWithNulls(List<TibReportsView> delays, List<TibOEEReport> oeeDelays, List<TibReportDelaysView> tibsWithoutDelays)
        {
            foreach (TibReportDelaysView tibWithoutDelay in tibsWithoutDelays.Where(d => d.TibDelayIndex == null).ToList()
                .OrderBy(d => d.EventStart))
            {
                delays.Add(new TibReportsView
                {
                    TibIndex = tibWithoutDelay.TibIndex,
                    PlantArea = "Unnamed",
                    DelayStart = tibWithoutDelay.EventStart, //spoofing the delays start with event start here so there will be
                                                            //a time on the report
                    DelayDuration = tibWithoutDelay.TibDuration,
                    DelayEnd = tibWithoutDelay.EventEnd,
                    DelayReason1 = "Unnamed delay",
                    UnitShort = tibWithoutDelay.UnitShort,
                    TIBClassText = "Unnamed",
                    TIBDisText = "Unnamed",
                    TIBCategoryText = "Unnamed",
                    HeatNumber = tibWithoutDelay.HeatNumber
                });

                oeeDelays.Add(new TibOEEReport
                {
                    TibIndex = tibWithoutDelay.TibIndex,
                    PlantArea = "UNNAMED",
                    OEECategory = "Unnamed",
                    DelayStart = tibWithoutDelay.EventStart,
                    DelayEnd = tibWithoutDelay.EventEnd,
                    DelayDuration = tibWithoutDelay.TibDuration,
                    DelayReason1 = "Unnamed delay",
                    UnitShort = tibWithoutDelay.UnitShort,
                    TIBClassText = "Unnamed",
                    TIBDisText = "Unnamed",
                    TIBCategoryText = "Unnamed",
                    LossType = "Unnamed",
                    Owner = "Unnamed",
                    ReportingTextLevel1 = "Unnamed",
                    ReportingTextLevel2 = "Unnamed",
                    HeatNumber = tibWithoutDelay.HeatNumber
                });
            }
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
                                DelayDuration = tibDuration - delayDuration,
                                PlantArea = "Unnamed",
                                DelayEnd = t.EventEnd,
                                DelayReason1 = "Unnamed delay",
                                TIBClassText = "Unnamed",
                                TIBDisText = "Unnamed",
                                TIBCategoryText = "Unnamed",
                                HeatNumber = t.HeatNumber
                            });
                        }
                    }
                }
                //Get the tib duration for the tib index
            }
            return partiallyCompletedEvents;
        }


        private void AddNewOEEDelays(List<TibReportsView> delayData, List<TibOEEReport> oeeData)
        {
            foreach (TibReportsView r in delayData)
            {
                oeeData.Add(new TibOEEReport
                {
                    TibIndex = r.TibIndex,
                    DelayStart = r.DelayStart,
                    UnitShort = r.UnitShort,
                    DelayDuration = r.DelayDuration,
                    PlantArea = "UNNAMED",
                    OEECategory = "Unnamed",
                    DelayEnd = r.DelayEnd,
                    DelayReason1 = "Unnamed delay",
                    TIBClassText = "Unnamed",
                    TIBDisText = "Unnamed",
                    TIBCategoryText = "Unnamed",
                    LossType = "Unnamed",
                    Owner = "Unnamed",
                    ReportingTextLevel1 = "Unnamed",
                    ReportingTextLevel2 = "Unnamed",
                    HeatNumber = r.HeatNumber
                });
            }
        }
        #region Events
        /// <summary>
        /// Updates the visual date label in group box on value change.
        /// </summary>
        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateDateLabel();
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
        /// Button click event for generating a new report.
        /// </summary>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (rbDate.Checked &&
                HelperFunctions.VerifyFilterSelections(dpFrom.Value, dpTo.Value))
            {
                BuildReport();
            }
            else if (!rbDate.Checked)
            {
                BuildReport();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Button click event for resetting the filtering.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        /// <summary>
        /// Close Form using Escape
        /// </summary>
        private void DelayAnalysisReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Saves User Settings on Close.
        /// </summary>
        private void DelayAnalysisReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save User Settings
            Settings.Default.DelayAnalysisReportFilters =
                CommonMethods.BuildSettingsString(grpUnits);
            //dont save if selected by system
            if (ResultsGroupBy == null)
            {
                Settings.Default.DelayAnalysisReportGroupBy = cmbGroupBy.SelectedItem.ToString();
            }
            CommonMethods.SaveElvisSettings();
        }

        #region Menu Items
        /// <summary>
        /// Closes the form from the menu bar.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
        #endregion

        
        #endregion

        #endregion
    }
}
