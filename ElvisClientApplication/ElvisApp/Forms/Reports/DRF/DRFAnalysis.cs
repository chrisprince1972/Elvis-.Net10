using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using Microsoft.Reporting.WinForms;
using NLog;

namespace Elvis.Forms.Reports.DRF
{
    public partial class DRFAnalysis : Form
    {
        #region Variables
        private DateTime fromDate;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string areaChosen = string.Empty;
        private StringBuilder queryString = new StringBuilder();
        private string reportDataSourceName = string.Empty;
        private string reportPath = string.Empty;
        private bool isCloseOutRate = false;
        private bool isRota = false;
        private bool isDelayByAreaLocFreq = false;
        private bool isDelayByAreaLocTime = false;
        private bool isOpenRequired = false;
        private bool isClosedRequired = false;
        #endregion

        public DRFAnalysis()
        {
            InitializeComponent();
        }

        private void DRFAnalysis_Load(object sender, EventArgs e)
        {
            SetupDateSelector();
            InitialDateSetup();
            SetupWeekNo();
            CustomiseColours();
            cmboReport.SelectedIndex = 0;
        }

        #region Methods
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
        /// Sets the number picker for the year.
        /// </summary>
        private void InitialDateSetup()
        {
            this.fromDate = DateTime.Now;
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
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlReportGen.BackColor =
                grpReport.BackColor =
                grpFormat.BackColor =
                pnlFormat.BackColor =
                grpDateSelector.BackColor =
                pnlDateSelector.BackColor =
                pnlReportSelector.BackColor =
                gbxReport.BackColor =
                grpArea.BackColor =
                grpLocationSelect.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlReportGen.ForeColor =
                grpReport.ForeColor =
                grpFormat.ForeColor =
                pnlFormat.ForeColor =
                grpDateSelector.ForeColor =
                pnlDateSelector.ForeColor =
                gbxReport.ForeColor =
                pnlReport.ForeColor =
                grpArea.ForeColor =
                grpLocationSelect.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Resets the filters and report to default.
        /// </summary>
        private void ResetFilters()
        {
            pnlReport.Controls.Clear();
            SetupDateSelector();
            InitialDateSetup();
            SetupWeekNo();
            cmboReport.SelectedIndex = 0;
            rbDate.Checked = true;
        }

        /// <summary>
        /// Build the report and binds it to the report viewer.
        /// </summary>
        private void BuildReport()
        {
            if (queryString != null)
                queryString.Clear();

            CollectReportRequirements();
            List<DateTime> fromAndToDates = SetFromAndToDates();
            BuildQueryString();
            pnlReport.Controls.Clear();

            if (fromAndToDates != null)
            {
                try
                {
                    List<DRFReport> drfList = GetReportData(fromAndToDates);
                    if (drfList != null)
                    {
                        ReportDataSource localReportDataSrc = new ReportDataSource()
                            {
                                Name = reportDataSourceName,
                                Value = drfList
                            };

                        ReportViewer reportViewer1 = new ReportViewer();
                        reportViewer1.LocalReport.ReportEmbeddedResource = this.reportPath;
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(localReportDataSrc);

                        foreach (ReportParameter rp in CreateReportParameters(fromAndToDates, drfList))
                        {
                            reportViewer1.LocalReport.SetParameters(rp);
                        }

                        reportViewer1.RefreshReport();
                        pnlReport.Controls.Add(reportViewer1);
                        reportViewer1.Dock = DockStyle.Fill;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Write(ex.ToString() + '\r' + '\n');
                    logger.ErrorException("DATA ERROR -- DRF Analysis -- BuildReport() -- ", ex);
                }
            }
        }

        /// <summary>
        /// Get the report data and manipulate the list dependent on the report options chosen.
        ///<parameter>DateTime list holding the from and to dates for the report.</parameter>
        /// <returns>List of DRF reports for the times in question, manipulated to suit the report options.</returns>
        /// </summary>
        private List<DRFReport> GetReportData(List<DateTime> fromAndToDates)
        {
            List<DRFReport> drfList = new List<DRFReport>();
            drfList = EntityHelper.DRFReport.GetDRFList(queryString.ToString(), fromAndToDates[0], fromAndToDates[1]);//(sb.ToString(), this.fromDate, this.toDate);
            //If this is the open by rota report, order the list by rota
            if (isRota == true)
                drfList = drfList.OrderBy(r => r.Rota).ToList();
            //If this the delay time/frequency by area report, create a new DRF report list to be the source
            if (isDelayByAreaLocFreq || isDelayByAreaLocTime)
                drfList = CreateLocationParetoList(drfList);
            //If All areas have been selected, order the list by works area / location
            if (areaChosen == "All")
                drfList = drfList.OrderBy(w => w.Works).ThenBy(w => w.Location).ToList();
            return drfList;
        }

        /// <summary>
        /// Creates the ReportParameters required for the respective RDLC report based on the options chosen.
        /// <parameter>DateTime list holding the from and to dates for the report.</parameter>
        /// <parameter>List of DRF reports extracted from the database.</parameter>
        /// <returns>List of RDLC report parameters.</returns>
        /// </summary>
        private List<ReportParameter> CreateReportParameters(List<DateTime> fromAndToDates, List<DRFReport> drfList)
        {
            List<ReportParameter> reportParams = new List<ReportParameter>();
            if (fromAndToDates != null)
            {
                //These parameters are added to every report
                reportParams.Add(new ReportParameter("DateFrom", fromAndToDates[0].ToString("dd/MMM/yyyy HH:mm")));
                reportParams.Add(new ReportParameter("DateTo", fromAndToDates[1].ToString("dd/MMM/yyyy HH:mm")));
                reportParams.Add(new ReportParameter("DateCreated", DateTime.Now.ToString("dd/MMM/yyyy HH:mm")));
                reportParams.Add(new ReportParameter("Area", areaChosen));
            }

            //Has the delay type by area/location frequency report been selected, if so add in a new parameter value, to show that
            //the report chart should show a count of all delays in the data
            if (isDelayByAreaLocFreq)
                reportParams.Add(new ReportParameter("ReportType", "Freq"));

            //Has the delay type by area/location time report been selected, if so add in a new parameter value, to show that
            //the report chart should show a sum of delay type duration in the data
            if (isDelayByAreaLocTime)
                reportParams.Add(new ReportParameter("ReportType", "Time"));

            //Has the close out rate report been selected, if so add in new parameters based on the contents of the base data in drfList
            if (drfList != null && isCloseOutRate)
            {
                //Add in the total number of reports in the list
                reportParams.Add(new ReportParameter("TotalReports", drfList.Count.ToString()));
                //Add in the total number of open reports in the list
                reportParams.Add(new ReportParameter("OpenReports", drfList.Where(r => r.ReportStatus == 0).ToList().Count.ToString()));
                //Add in the total number of closed reports in the list
                reportParams.Add(new ReportParameter("ClosedReports", drfList.Where(r => r.ReportStatus == 1).ToList().Count.ToString()));
            }
            return reportParams;
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
        /// If a report that requires further location selections for the respective area, 
        /// this method makes pnlLocation visible and expands the areaChosen string.
        /// </summary>
        private void SetUpFormForDelayPareto()
        {
            string worksArea = string.Empty;
            List<DRFLocationLookUp> areaLocations = new List<DRFLocationLookUp>();
            if (cmboReport.SelectedItem.ToString() == "Delay Frequency By Location Chart"
                || cmboReport.SelectedItem.ToString() == "Delay Time By Location Chart")
            {
                try
                {
                    //Get the locations for the area selected (i.e. Steelmaking, concast or all)
                    //If all is selected, omit the extra where.
                    //If Concast is selected, use that in the extra where
                    //If neither of those are selected, must be Steelmaking use that in the extra where
                    if (rdoAll.Checked == true)
                        areaLocations = EntityHelper.DRFLocationLookUp.GetAll();
                    else if (rdoConcast.Checked == true)
                        areaLocations = EntityHelper.DRFLocationLookUp.GetAll().Where(l => l.Works == rdoConcast.Tag.ToString()).ToList();
                    else
                        areaLocations = EntityHelper.DRFLocationLookUp.GetAll().Where(l => l.Works == rdoSteelmaking.Tag.ToString()).ToList();

                    if (areaLocations != null && areaLocations.Count > 0)
                    {
                        pnlLocation.Visible = true;
                        cmboLocation.ValueMember = "Location";
                        cmboLocation.DataSource = areaLocations.GroupBy(l => l.Location)
                            .Select(l => l.First()).OrderBy(l => l.Works).ThenBy(l => l.Location).ToList();
                    }
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "DATA ERROR -- SetUpFormForDelayPareto() -- Error getting DRF Location Lookup data from database -- ",
                        ex);
                }
            }
            else
            {
                pnlLocation.Visible = false;//In case it was visible on the last selection
            }
        }

        /// <summary>
        /// If a report that requires a pareto per area - location is required, this method
        /// creates a dummy DRFReport list to send to the respective RDLC report as the data source.
        /// </summary>
        /// <param name="drfList"></param>
        /// <returns>Dummy DRFReport list for use as the RDLC data source.</returns>
        private List<DRFReport> CreateLocationParetoList(List<DRFReport> drfList)
        {
            List<DRFReport> areaDelaySummary = new List<DRFReport>();

            if (drfList != null && cmboLocation.SelectedValue != null)
            {
                string location = cmboLocation.SelectedValue.ToString();
                List<DRFReport> locationList = drfList
                    .Where(l =>
                        l.Location == location
                    .ToString())
                    .ToList();

                if (locationList != null && locationList.Count > 0)
                {
                    //Create a secondary list for the area that just contains sums of delay durations per delay type in the overall list
                    List<DRFReport> areaDelayTypes = locationList
                        .GroupBy(l => l.DelayType)
                        .Select(l => l.First())
                        .ToList();

                    if (areaDelayTypes != null && areaDelayTypes.Count > 0)
                    {
                        foreach (DRFReport areaDelayType in areaDelayTypes)
                        {
                            //DelayDuration will hold either the sum of the dlay times OR the count of delay instances dependent on
                            //which location based report has been chosen:
                            //- sum if Delay Time By Location Chart chosen
                            //- count if Delay Frequency By Location Chart chosen
                            if (cmboReport.SelectedItem.ToString() == "Delay Time By Location Chart")
                                areaDelayType.DelayDuration = locationList.Where(d => d.DelayType == areaDelayType.DelayType).Sum(d => d.DelayDuration);
                            else
                                areaDelayType.DelayDuration = locationList.Where(d => d.DelayType == areaDelayType.DelayType).ToList().Count;

                            areaDelaySummary.Add(new DRFReport
                            {
                                Location = areaDelayType.Location,
                                DelayType = areaDelayType.DelayType,
                                DelayDuration = areaDelayType.DelayDuration
                            });
                        }
                        //Expand the area chosen text to include the location as well as the area
                        areaChosen = areaChosen + " - " + location;
                    }
                }
            }
            return areaDelaySummary = areaDelaySummary.OrderByDescending(d => d.DelayDuration).ToList();
        }

        /// <summary>
        /// Builds the query string based on the report requirements.
        /// </summary>
        protected void BuildQueryString()
        {
            AddWorksAreaToQueryString();
            AddOpenClosedRequirementToQueryString();
        }

        /// <summary>
        /// Adds the works area to the query string based on the radio button checked in grpArea.
        /// </summary>
        protected void AddWorksAreaToQueryString()
        {
            List<RadioButton> rbAreas = new List<RadioButton>();
            rbAreas.Add(rdoAll);
            rbAreas.Add(rdoConcast);
            rbAreas.Add(rdoSteelmaking);
            RadioButton rbSelected = rbAreas.FirstOrDefault(rb => rb.Checked == true);
            if (rbSelected.Tag.ToString() == "All")
            {
                queryString.AppendFormat("(it.Works == \"{0}\" || it.Works == \"{1}\")",
                    rdoConcast.Tag.ToString(), rdoSteelmaking.Tag.ToString());
            }
            else
                queryString.AppendFormat("(it.Works == \"{0}\")", rbSelected.Tag.ToString());
            areaChosen = rbSelected.Tag.ToString();
        }

        /// <summary>
        /// Amends the query string if a report requiring filtering by open or closed status is chosen.
        /// </summary>
        protected void AddOpenClosedRequirementToQueryString()
        {
            if (isOpenRequired)
                queryString.AppendFormat(" and it.ReportStatus == {0}", 0);
            else if (isClosedRequired)
                queryString.AppendFormat(" and it.ReportStatus == {0}", 1);
        }

        /// <summary>
        /// Sets the From and To dates for the required report.
        /// <returns>Date time list holding the From date in position 0 and To date in position 1.</returns>
        /// </summary>
        protected List<DateTime> SetFromAndToDates()
        {
            List<DateTime> fromAndToDates = new List<DateTime>();
            if (isCloseOutRate)
            {
                fromAndToDates.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 7, 0, 0).AddMonths(-6));
                fromAndToDates.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 7, 0, 0));
            }
            else
            {
                this.fromDate = GetFromDate();
                fromAndToDates.Add(this.fromDate);
                fromAndToDates.Add(GetToDate());
            }
            return fromAndToDates;
        }

        /// <summary>
        /// Sets the flags to indicate what data the report should be collecting and how it should be displayed. The setting
        /// is based on the selections made in cmboReport
        /// Sets:
        /// - isOpenOrClosed to true if a stacked bar chart showing Open/Closed split is to be generated.
        /// - isDelayByAreaLoc to true if a pareto chart of delay type by location within a works area is to be generated.
        /// - isCloseOut to true if the DRF close out report is to be displayed.
        /// - isRota to true if a report requiring sorting by rota is to be displayed.
        /// Also indicates the name of the data source to be used for the respective report and the path to the required RDLC file.
        /// </summary>
        protected void CollectReportRequirements()
        {
            isRota = false;
            isDelayByAreaLocFreq = false;
            isDelayByAreaLocTime = false;
            isCloseOutRate = false;
            isOpenRequired = false;
            isClosedRequired = false;
            if (cmboReport.SelectedItem != null)
            {
                switch (cmboReport.SelectedItem.ToString())
                {
                    case "Area Chart":
                        reportPath = "Elvis.Forms.Reports.RDLC.DRF.DRFChartByArea.rdlc";
                        reportDataSourceName = "DRFReportsByArea";
                        break;
                    case "Function Chart":
                        reportPath = "Elvis.Forms.Reports.RDLC.DRF.DRFChartByFunction.rdlc";
                        reportDataSourceName = "DRFReportsByFunction";
                        break;
                    case "Delay Type Frequency Chart":
                        reportPath = "Elvis.Forms.Reports.RDLC.DRF.DRFChartByDelayTypeFreq.rdlc";
                        reportDataSourceName = "DRFReportsByDelayTypeFreq";
                        break;
                    case "Delay Type Total Time Chart":
                        reportPath = "Elvis.Forms.Reports.RDLC.DRF.DRFChartByDelayTypeTotTime.rdlc";
                        reportDataSourceName = "DRFReportsByDelayTypeTotTime";
                        break;
                    case "Open Reports By Owner":
                        reportPath = "Elvis.Forms.Reports.RDLC.DRF.DRFOpenByOwner.rdlc";
                        reportDataSourceName = "OpenReportsByOwner";
                        isOpenRequired = true;
                        break;
                    case "Open Reports By Rota":
                        reportPath = "Elvis.Forms.Reports.RDLC.DRF.DRFOpenByRota.rdlc";
                        reportDataSourceName = "OpenReportsByRota";
                        isOpenRequired = true;
                        isRota = true;
                        break;
                    case "Closed Reports By Owner":
                        reportPath = "Elvis.Forms.Reports.RDLC.DRF.DRFClosedByOwner.rdlc";
                        reportDataSourceName = "OpenReportsByOwner";
                        isClosedRequired = true;
                        break;
                    case "Close Out Rate":
                        reportPath = "Elvis.Forms.Reports.RDLC.DRF.DRFCloseOutRate.rdlc";
                        reportDataSourceName = "CloseOutRate";
                        isCloseOutRate = true;
                        break;
                    case "Delay Frequency By Location Chart":
                        reportPath = "Elvis.Forms.Reports.RDLC.DRF.DRFChartDelayTimeByLoc.rdlc";
                        reportDataSourceName = "DRFDelayTimeByLocation";
                        isDelayByAreaLocFreq = true;
                        break;
                    case "Delay Time By Location Chart":
                        reportPath = "Elvis.Forms.Reports.RDLC.DRF.DRFChartDelayTimeByLoc.rdlc";
                        reportDataSourceName = "DRFDelayTimeByLocation";
                        isDelayByAreaLocTime = true;
                        break;
                }
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Close tool strip menu item click event.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Reset Button Event.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        /// <summary>
        /// Generate Button Event.
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
        /// Closes form is ESC is pressed.
        /// Generates new report if ENTER is pressed.
        /// </summary>
        private void DRFAnalysis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnGenerate.PerformClick();
            }
        }

        /// <summary>
        /// When the selected item in cmboReport (i.e. which report is required)
        /// is changed the SetUpFormForDelayPareto() method is called to check
        /// whether or not pnlLocation should be displayed.
        /// </summary>
        private void cmboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetUpFormForDelayPareto();
        }

        /// <summary>
        /// When one of the Area selection radion buttons is checked the 
        /// SetUpFormForDelayPareto() method is called to check
        /// whether or not pnlLocation should be displayed (in this case
        /// is the report in cmboReport of the type requiring location selections).
        /// </summary>
        private void rdoArea_CheckedChanged(object sender, EventArgs e)
        {
            SetUpFormForDelayPareto();
        }

        /// <summary>
        /// If the form is closed either from the Close menu item or by the 'X'
        /// this event runs to make sure the dynamically created reportviewer in pnlReport
        /// releases the SandBoxAppDomain. This bug may only be an issue when the solution
        /// is run in VS2010, but kept in the event that it could also affect a compiled
        /// version.
        /// </summary>
        private void DRFAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReportViewer rv1 = new ReportViewer();
            foreach (Control ctl in pnlReport.Controls)
            {
                if (ctl is ReportViewer)
                {
                    rv1 = (ReportViewer)ctl;
                    rv1.LocalReport.ReleaseSandboxAppDomain();
                }
            }
        }
        #endregion
    }
}
