using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using Microsoft.Reporting.WinForms;
using NLog;
using ElvisDataModel;

namespace Elvis.Forms.Reports
{
    public partial class TIBTimeInProduction : Form
    {
        #region Variables
        private DateTime fromDate;
        private DateTime toDate;
        private MainForm main;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor
        public TIBTimeInProduction(MainForm main)
        {
            InitializeComponent();
            this.main = main;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Form Load Event, sets up the form ready for use.
        /// </summary>
        private void TIBTimeInProduction_Load(object sender, EventArgs e)
        {
            SetupDateSelector();
            InitialDateSetup();
            SetupWeekNo();
            CustomiseColours();
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
            grpFilter.BackColor =
            grpFormat.BackColor =
            grpDateSelector.BackColor = 
                Settings.Default.ColourBackground;

            pnlReport.ForeColor =
            pnlFilter.ForeColor =
            grpFilter.ForeColor =
            grpFormat.ForeColor =
            grpDateSelector.ForeColor = 
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Resets the filters and report to default.
        /// </summary>
        private void ResetFilters()
        {
            TibUnitTimeInProductionViewBindingSource.DataSource = null;
            reportViewer1.Clear();
            reportViewer1.Refresh();
            SetupDateSelector();
            InitialDateSetup();
            SetupWeekNo();
        }

        /// <summary>
        /// Gets the data for report and sets up report for viewing.
        /// </summary>
        private void GetProductionData()
        {
            this.fromDate = GetFromDate();
            this.toDate = GetToDate();

            if (HelperFunctions.VerifyFilterSelections(this.fromDate, this.toDate))
            {
                try
                {
                    List<TibTimeInProductionView> rawDelaysData =
                        EntityHelper.TibTimeInProductionView.GetByDate(
                            this.fromDate, this.toDate);

                    HelperFunctions.RemoveInvalidEventData(rawDelaysData,
                        this.fromDate, this.toDate);

                    var unitTimes = from t in rawDelaysData
                                    group t by t.UnitText into g
                                    let total = g.Sum(d => d.TibDuration)
                                    let unitGroup = g.Max(d => d.UnitGroup)
                                    select new TibTimeInProductionView
                                    {
                                        UnitText = g.Key,
                                        TibDuration = total
                                    };

                    TibUnitTimeInProductionViewBindingSource.DataSource = unitTimes;

                    string reportPeriodFrom = this.fromDate.ToString("dd-MM-yyyy HH:mm");
                    string reportPeriodTo = this.toDate.ToString("dd-MM-yyyy HH:mm");

                    reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportPeriodFrom", reportPeriodFrom));
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportPeriodTo", reportPeriodTo));

                    reportViewer1.RefreshReport();
                    reportViewer1.Focus();
                }
                catch (Exception ex)
                {
                    logger.ErrorException("DATA ERROR TIBTimeInProduction -- GetProductionData() -- " +
                        "Getting TIB Time in Production Reports View data from database and generating the report -- ", ex);
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

        #region Events
        /// <summary>
        /// Button click event for generating the data report.
        /// </summary>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                btnGenerate.Enabled = false;
                GetProductionData();
            }
            finally
            {
                btnGenerate.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button click event for resetting the filtering.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
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
        /// Updates the visual date label in group box on value change.
        /// </summary>
        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateDateLabel();
        }

        /// <summary>
        /// Close Form using Escape
        /// </summary>
        private void TIBTimeInProduction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

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
    }
}
