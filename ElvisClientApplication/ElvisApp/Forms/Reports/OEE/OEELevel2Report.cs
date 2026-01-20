using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Properties;
using Elvis.Common;
using Microsoft.Reporting.WinForms;
using NLog;
using ElvisDataModel.EDMX;
using ElvisDataModel;

namespace Elvis.Forms.Reports.OEE
{
    public partial class OEELevel2Report : Form
    {
        #region Variables
        private DateTime fromDate;
        private DateTime toDate;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        bool isSingleUnit = true;
        #endregion

        #region Constructor + Form Load
        /// <summary>
        /// The constructor for the form.
        /// </summary>
        public OEELevel2Report()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The form load event.
        /// </summary>
        private void OEELevel2Report_Load(object sender, EventArgs e)
        {
            BindDropDown(true);
            SetupDateSelector();
            InitialDateSetup();
            SetupWeekNo();
            CustomiseColours();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Binds the combobox with relevant data.
        /// </summary>
        private void BindDropDown(bool isSingleUnit)
        {
            List<Unit> unitList = EntityHelper.Units.GetAll().Where(u => u.UnitGroupSort != null).ToList();
            //cmboUnit.DataSource = EntityHelper.Units.GetAll().Where(u => u.UnitGroupSort != null).ToList();

            if (unitList != null)
            {
                if (isSingleUnit)
                {
                    cmboUnit.DataSource = unitList;
                    cmboUnit.DisplayMember = "UnitText";
                    cmboUnit.ValueMember = "UnitNumber";
                    grpUnit.Text = "Unit";
                }
                else
                {
                    cmboUnit.DataSource = unitList.GroupBy(u => u.UnitGroupNumber).Select(u => u.First()).ToList();
                    cmboUnit.DisplayMember = "UnitGroupText";
                    cmboUnit.ValueMember = "UnitGroupNumber";
                    grpUnit.Text = "Unit Group";
                }
            }
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlReportGen.BackColor = 
                grpReport.BackColor = 
                pnlReport.BackColor =
                pnlUnit.BackColor =
                grpUnit.BackColor =
                grpFormat.BackColor =
                pnlFormat.BackColor = 
                grpDateSelector.BackColor =
                pnlReportType.BackColor =
                grpReportType.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlReportGen.ForeColor = 
                grpReport.ForeColor = 
                pnlReport.ForeColor = 
                pnlUnit.ForeColor =
                grpUnit.ForeColor =
                grpFormat.ForeColor =
                pnlFormat.ForeColor = 
                grpDateSelector.ForeColor =
                pnlReportType.ForeColor =
                grpReportType.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Resets the filters and report to default.
        /// </summary>
        private void ResetFilters()
        {
            TibOEEReportBindingSource.DataSource = null;
            reportViewer1.Clear();
            reportViewer1.Refresh();
            SetupDateSelector();
            InitialDateSetup();
            SetupWeekNo();
            cmboUnit.SelectedIndex = 0;
            rbDate.Checked = true;
        }

        /// <summary>
        /// Builds the Report for the Report Viewer.
        /// </summary>
        private void BuildReport()
        {
            try
            {
                //List of TIB delay events with associated delay details
                List<TibOEEReport> oeeData = new List<TibOEEReport>();
                //List of all TIB delay events for comparison with list that has associated delay details
                List<TibReportDelaysView> allDelayData = new List<TibReportDelaysView>();

                this.fromDate = GetFromDate();
                this.toDate = GetToDate();

                if (isSingleUnit)
                {
                    oeeData = EntityHelper.TibOEEReport.GetByDateAndUnit(
                    this.fromDate, this.toDate, GetUnitNumber());
                    allDelayData = 
                        EntityHelper.TibReportDelaysView.GetByDateRangeAndUnit(this.fromDate, this.toDate, GetUnitNumber());
                }
                else
                {
                    oeeData = EntityHelper.TibOEEReport.GetByDateAndUnitGroup(
                    this.fromDate, this.toDate, GetUnitNumber());
                    allDelayData =
                        EntityHelper.TibReportDelaysView.GetByDateRangeAndUnitGroup(this.fromDate, this.toDate, GetUnitNumber());
                }
                //temp
                foreach (TibReportDelaysView v in allDelayData)
                {
                    System.Diagnostics.Debug.WriteLine("TibIndex\t" + v.TibIndex);
                }
                //
                //2015-08-06 new method to match this report with Delays To Enter - add a new OEE report item where the Tib duration is greater than the total delay duration 
                //for the Tib
                AddPartiallyCompletedTibs(allDelayData,oeeData);
                //2015-08-06 new method to match this report with Delays To Enter - add end dates and durations to Tibs where the end date is null
                FixEndDates(allDelayData);
                //Combine the 2 lists into a single TibOeeReport list for display purposes
                oeeData = CreateListIncludingNulls(oeeData, allDelayData);
                               
                //Les Jones 10/4/2015 - Although SOW is being moved back into the main body of the report, the data source is steill being
                //added so that the RDLC doesn't break. The table has been hidden on the RDLC.
                //Clear out the SpeedOfWork data source if it already exists (i.e. this will be needed if the report is generated for different units within the same 'session')  
                if (reportViewer1.LocalReport.DataSources.Any(r => r.Name == "SpeedOfWork"))
                    reportViewer1.LocalReport.DataSources.Remove(reportViewer1.LocalReport.DataSources["SpeedOfWork"]);
             
                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("SpeedOfWork", AmendSOWItems(oeeData.Where(r => r.LossType == "Speed of Work").ToList())));
                //***************************************************************************************

                //Les Jones 10/4/2015 Leaving SOW items in the list for now, will be removed again in future
                //Remove speed of work delay items
                //oeeData = oeeData.Where(r => r.LossType != "Speed of Work").ToList(); 
                //***************************************************************************************

                HelperFunctions.RemoveInvalidDelayData(
                    oeeData, this.fromDate, this.toDate);
                TibOEEReportBindingSource.DataSource = OrderOEEData(oeeData);

                ReportParameter p1 = new ReportParameter("DateFrom", this.fromDate.ToString("dd/MMM/yyyy HH:mm"));
                reportViewer1.LocalReport.SetParameters(p1);

                ReportParameter p2 = new ReportParameter("DateTo", this.toDate.ToString("dd/MMM/yyyy HH:mm"));
                reportViewer1.LocalReport.SetParameters(p2);

                ReportParameter p3 = new ReportParameter("DateCreated", DateTime.Now.ToString("dd/MMM/yyyy HH:mm"));
                reportViewer1.LocalReport.SetParameters(p3);

                ReportParameter p4 = new ReportParameter("Unit", cmboUnit.Text);
                reportViewer1.LocalReport.SetParameters(p4);

                ReportParameter p5 = new ReportParameter("L1BackColour",
                    Colours.ConvertSystemColourToHex(Settings.Default.OEELevel1Background));
                reportViewer1.LocalReport.SetParameters(p5);

                ReportParameter p6 = new ReportParameter("L1TextColour",
                    Colours.ConvertSystemColourToHex(Settings.Default.OEEL1Text));
                reportViewer1.LocalReport.SetParameters(p6);

                ReportParameter p7 = new ReportParameter("L2BackColour",
                   Colours.ConvertSystemColourToHex(Settings.Default.OEELevel2Background));
                reportViewer1.LocalReport.SetParameters(p7);

                ReportParameter p8 = new ReportParameter("L2TextColour",
                    Colours.ConvertSystemColourToHex(Settings.Default.OEEL2Text));
                reportViewer1.LocalReport.SetParameters(p8);
                
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- OEELevel2Report -- BuildReport() -- ",
                    ex);
            }
        }

        /// <summary>
        /// Gets the unit number safely from the combo box.
        /// </summary>
        /// <returns>The unit number as an int.</returns>
        private int GetUnitNumber()
        {
            int unitNo = 0;
            if (cmboUnit.SelectedValue != null &&
                int.TryParse(cmboUnit.SelectedValue.ToString(), out unitNo))
            {
                return unitNo;
            }
            return 0;
        }

        private List<TibOEEReport> AmendSOWItems(List<TibOEEReport> sowItems)
        {
            //Les Jones 20150413 temporarily commented out so that SOW goes back into correct position in standard report
            //foreach (TibOEEReport sowItem in sowItems)
            //{
            //    sowItem.OEECategory = "Speed Of Work";
            //}
            return sowItems;
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
        /// Orders the OEE data found in the EntityHelper.TibOEEReport.GetByDateAndUnit into Utilisation/Planned/Unplanned
        /// order for display on the OEELevel2 RDLC report.
        /// Sorting has been removed from the report so that this list order is maintained in display.
        /// <param>TibOEEReport list for the search parameters provided.</param>
        /// <returns>TibOEEReport list in the the desired order.</returns>
        /// </summary>
        private List<TibOEEReport> OrderOEEData(List<TibOEEReport> baseOEEData)
        {
            List<TibOEEReport> orderedOEEData = new List<TibOEEReport>();
            List<TibOEEReport> notCategorised = baseOEEData.Where(oee => oee.OEECategory == "Not categorised").ToList();
            //Les Jones 20150513 make items where OEE Category is 'not categorised' display as 'Unplanned loss' items
            foreach (TibOEEReport notCatReport in notCategorised)
            {
                notCatReport.OEECategory = "Unplanned Loss";
            }
            orderedOEEData.AddRange(baseOEEData.Where(o => o.OEECategory.Contains("Utilisation")));
            orderedOEEData.AddRange(baseOEEData.Where(o => o.OEECategory.Contains("Planned")));
            orderedOEEData.AddRange(baseOEEData.Where(o => o.OEECategory.Contains("Unplanned")));
            //Les Jones 10/4/2015 Added SOW back in to main report list. Will need to come out in future
            orderedOEEData.AddRange(baseOEEData.Where(o => o.OEECategory.Contains("Speed Of Work")));
            //***************************************************************************************
            
            orderedOEEData.AddRange(baseOEEData.Where(o => o.OEECategory.Contains("Not categorised")));
            return orderedOEEData;
        }

        /// <summary>
        /// Creates a fill list of TibOEERport items, including TIB events with no associated delays.
        /// <param>TibOEEReport list for the search parameters provided.</param>
        /// <param>All TIB delay list for the search parameters provided.</param>
        /// <returns>TibOEEReport list in the the desired order.</returns>
        /// </summary>
        private List<TibOEEReport> CreateListIncludingNulls(List<TibOEEReport> baseOEEData, List<TibReportDelaysView> allDelayData)
        {
            List<TibOEEReport> fullOEEData = new List<TibOEEReport>();
            //List<TibReportDelaysView> tibsWithoutData = allDelayData.Where(t => t.TibDelayIndex.Equals(null)).ToList();
            //2015-08-05 Les modified in an attempt to match Tib deays to enter count
            List<TibReportDelaysView> tibsWithoutData = allDelayData.Where(t => t.TibDelayIndex.Equals(null) &&
                t.TibDuration > 0).ToList();
            fullOEEData.AddRange(baseOEEData);
            foreach (TibReportDelaysView tibWithoutData in tibsWithoutData)
            {
                fullOEEData.Add(new TibOEEReport
                {
                    OEECategory = "Not categorised",
                    ReportingTextLevel1 = "Unnamed",
                    TibDelayIndex = -1,
                    DelayDuration = tibWithoutData.TibDuration,
                    TibIndex = tibWithoutData.TibIndex,
                    EventStart = tibWithoutData.EventStart,
                    DelayStart = tibWithoutData.EventStart,
                    DelayEnd = tibWithoutData.EventEnd
                });
            }
            return fullOEEData;
        }

        #region Events
        /// <summary>
        /// Reset Button Event.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        /// <summary>
        /// Generate Report button event.
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
        /// Close tool strip menu item click event.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Closes form on ESC Key press.
        /// </summary>
        private void OEELevel2Report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Changes the contents of cmboUnit dependent on which of
        /// rbSingleUnit or rbGroupUnits is checked.
        /// </summary>
        private void rbReportType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Name == "rbSingleUnit")
            {
                if (rb.Checked == true)
                    isSingleUnit = true;
                else
                    isSingleUnit = false;
            }
            BindDropDown(isSingleUnit);
        }
        
        #endregion

        #endregion

        //New code introduced to try and match Tib Delays to Enter to this report


        /// <summary>
        /// Fixes end times for any Tibs with no delays and no end dates.
        /// <param eventList>The list of Tib delay events for the unit or group.</param>
        /// </summary>
        private void FixEndDates(List<TibReportDelaysView> eventList)
        {
            TIBEvent nextEvent = new TIBEvent();
            int referenceNumber = isSingleUnit ? eventList.FirstOrDefault().UnitNumber : eventList.FirstOrDefault().UnitGroup.GetValueOrDefault();

            //Get all of the Tib events for respective unit or unit group within the given date range
            List<TIBEvent> allEvents = isSingleUnit ? EntityHelper.TIBEvents.GetByDateRangeForUnit(fromDate, toDate, referenceNumber) :
                EntityHelper.TIBEvents.GetByDateRangeForUnitGroup(fromDate, toDate, referenceNumber);
            
            //Iterate over the delays with no ened times and fix as necessary
            foreach (TibReportDelaysView v in eventList.Where(e => !e.TibDelayIndex.HasValue).OrderBy(e => e.TibIndex).ToList())
            {
                if (v.TibDuration > 0 && v.EventEnd == null)
                {
                    //Get the next event in the list of events for the unit/group within the given date range (if there is one) this is probably not a delay
                    nextEvent = isSingleUnit ? allEvents.FirstOrDefault(e => e.TibIndex > v.TibIndex && e.UnitNumber == v.UnitNumber) :
                        allEvents.FirstOrDefault(e => e.TibIndex > v.TibIndex && e.UnitGroup == v.UnitGroup);
                    
                    if (nextEvent != null)
                    {
                        //Fix 1: If there is a next event within the data returned for the date range, use the start of that event as the end of the current event
                        v.EventEnd = nextEvent.EventStart;
                    }
                    else
                    {
                        //Fix 2: If there is no next event, get the next event outside the date range and set the end date to the start of that event
                        nextEvent = Elvis.Model.Tib.GetNextEvent(referenceNumber, v.TibIndex, isSingleUnit);
                        if (nextEvent != null)
                            v.EventEnd = nextEvent.EventStart;
                        //Fix 3: Only if there is no next event outside of the range use the current date
                        else
                            v.EventEnd = DateTime.Now;
                    }
                    v.TibDuration = Convert.ToInt32((v.EventEnd.Value - v.EventStart.Value).TotalMinutes);
                }
            }
        }

        /// <summary>
        /// Creates new OEE report entry for partially completed Tibs.
        /// Adds 1 to the number of Unnamed reports and increases the minutes by the difference between the Tib duration and sum of the duration for all associated delays.
        /// <param allDelays>The list of Tib delay events for the unit or group.</param>
        /// <param oeeData>The list of TibOEERport objects for the unit or group, used to create the report.</param>
        /// </summary>
        private void AddPartiallyCompletedTibs(List<TibReportDelaysView> allDelays, List<TibOEEReport> oeeData)
        {
            //Get a list of all Tib index numbers
            var tibIndexList = Enumerable.DistinctBy(allDelays,i => i.TibIndex);
            int delayDuration = 0;
            TibReportDelaysView tibItem = new TibReportDelaysView();

            //Get a list of delay items for each index
            foreach (var tibIndex in Enumerable.DistinctBy(allDelays,e => e.TibIndex).ToList())// tibIndexList)//.Distinct().ToList())
            {
                var delayItems = allDelays.Where(d => d.TibIndex == tibIndex.TibIndex).ToList();
                //Sum the delay duration for each Tib index
                delayDuration = Convert.ToInt32(delayItems.Sum(d => d.DelayDuration));
                tibItem = allDelays.FirstOrDefault(d => d.TibIndex == tibIndex.TibIndex);
                //If the total delay duration is less than the Tib duration, add a new TibOEEReport where the duration is the
                //difference between Tib Duration and total delay duration
                if (tibIndex.TibDelayIndex.HasValue)//delayDuration > 0)
                {
                    if (tibItem.TibDuration > delayDuration)
                    {
                        int i = Convert.ToInt16(tibItem.TibDuration - delayDuration);
                        oeeData.Add(new TibOEEReport
                        {
                            OEECategory = "Not categorised",
                            ReportingTextLevel1 = "Unnamed",
                            TibDelayIndex = -1,
                            DelayDuration = tibItem.TibDuration - delayDuration,
                            TibIndex = tibIndex.TibIndex,
                            EventStart = tibIndex.EventStart
                        });
                    }
                }
            }
        }
    }
}
