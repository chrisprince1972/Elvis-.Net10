using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Forms.Tib;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using Microsoft.Reporting.WinForms;
using NLog;
using System.ComponentModel;

namespace Elvis.Forms.Reports
{
    public partial class TIBDelaysToEnterReport : Form
    {
        #region Variables + Properties
        private DateTime fromDate;
        private DateTime toDate;
        private MainForm main;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        //New

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DirtyDelays { get; set; }
        #endregion

        #region Constructor
        public TIBDelaysToEnterReport(MainForm main)
        {
            InitializeComponent();
            this.main = main;
        }
        #endregion

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
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            pnlReport.BackColor =
            pnlFilter.BackColor =
            grpFilter.BackColor =
            grpFormat.BackColor =
            grpMinDuration.BackColor =
            grpDateSelector.BackColor = 
                Settings.Default.ColourBackground;

            pnlReport.ForeColor =
            pnlFilter.ForeColor =
            grpFilter.ForeColor =
            grpFormat.ForeColor =
            grpMinDuration.ForeColor = 
            grpDateSelector.ForeColor = 
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Resets the filters and report to default.
        /// </summary>
        private void ResetFilters()
        {
            DelayByRotaBindingSource.DataSource = null;
            DelayByShiftBindingSource.DataSource = null;
            UncompletedReportSummaryBindingSource.DataSource = null;
            TibReportDelaysViewBindingSource.DataSource = null;
            FiguresByPlantUnitBindingSource.DataSource = null;

            reportViewer1.Clear();
            reportViewer1.Refresh();
            SetupDateSelector();
            InitialDateSetup();
            SetupWeekNo();
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
        /// Gets the Delays Data and populates the report.
        /// </summary>
        private void GetDelaysData()
        {
            this.fromDate = GetFromDate();
            this.toDate = GetToDate();
            
            // Abort on invalid dates. The helper method displays appropriate user messages.
            if (!HelperFunctions.VerifyFilterSelections(fromDate, toDate)) return;

            try
            {
                // Disable the report form whilst processing the data.
                Enabled = false;

                using (var progressForm = new ProgressForm())
                {
                    // Setup the Progress form.
                    progressForm.Text = "Processing Delays to Enter...";
                    progressForm.Current = 0;
                    progressForm.Maximum = 100;
                    progressForm.Show(this);

                    // Get the minimum duration of delays to report on.
                    int minDuration = (int)numMinDuration.Value;

                    // Get the raw data rows for the report period.
                    progressForm.Description = "Getting raw delays data...";
                    Application.DoEvents();
                    List<TibReportDelaysView> rawDelaysData = Model.Tib.GetDelaysToEnterView(fromDate, toDate, minDuration);

                    if (progressForm.UserAborted) return;

                    // Group on the unit for the first two charts.
                    progressForm.Description = "Grouping the delays by unit...";
                    progressForm.Current += 20;
                    Application.DoEvents();
                    IEnumerable<UncompletedReportSummary> delaysByUnit = GroupDelaysByUnit(rawDelaysData);

                    if (progressForm.UserAborted) return;

                    // Group on the shift for the Breakdown by Shift chart and table.
                    progressForm.Description = "Grouping the delays by shift...";
                    progressForm.Current += 20;
                    Application.DoEvents();
                    IEnumerable<UncompletedReportSummary> delaysByShift = GroupDelaysByShift(rawDelaysData);

                    if (progressForm.UserAborted) return;

                    // Group on the Rota for the Breakdown by Rota chart and table.
                    progressForm.Description = "Grouping the delays by rota...";
                    progressForm.Current += 20;
                    Application.DoEvents();
                    IEnumerable<UncompletedReportSummary> delaysByRota = GroupDelaysByRota(rawDelaysData);

                    if (progressForm.UserAborted) return;

                    // Get the data for the "Figures by Plant Unit" report table.
                    progressForm.Description = "Summarising delays by plant unit...";
                    progressForm.Current += 20;
                    Application.DoEvents();
                    var plantUnitSummaries = GetPlantUnitSummaries(rawDelaysData, delaysByUnit);

                    if (progressForm.UserAborted) return;

                    // Aggregate the "Figures by Plant Unit" values for the "Aggregated Figures" table.
                    progressForm.Description = "Aggregating delays by areas...";
                    progressForm.Current += 20;
                    Application.DoEvents();
                    var aggregateSummaries = GetAggregatedPlantUnitFigures(plantUnitSummaries);

                    if (progressForm.UserAborted) return;

                    // Bind the data to the data sources.
                    //2015-09-16 Les Jones - TibReportDelaysViewBindingSource now using a new list
                    //that includes Tib events with no delays or partially completed delays
                    TibReportDelaysViewBindingSource.DataSource = BuildDelaysToEnterByUnit(rawDelaysData); 
                    //TibReportDelaysViewBindingSource.DataSource = rawDelaysData.Where(e => e.TibDelayIndex == null);

                    UncompletedReportSummaryBindingSource.DataSource = delaysByUnit;
                    DelayByShiftBindingSource.DataSource = delaysByShift;
                    DelayByRotaBindingSource.DataSource = delaysByRota;
                    FiguresByPlantUnitBindingSource.DataSource =
                        plantUnitSummaries.OrderByDescending(s => s.TotalMinsNotDone);
                    AggregatedFiguresBindingSource.DataSource = aggregateSummaries;

                    reportViewer1.RefreshReport();
                }
            }
            finally
            {
                Enabled = true;
                Activate();
            }
        }

        private static List<PlantUnitReportSummary> GetAggregatedPlantUnitFigures(List<PlantUnitReportSummary> plantUnitSummaries)
        {
            // Aggregate the "Figures by Plant Unit" values for the "Aggregated Figures" table.
            // For reasons currently unknown, the units are grouped as follows with units appearing
            // in multiple categories by design.

            /* -----------------------------------------------------------------------------
             * |              |BOS Plant|Hot Metal Prep|Materials|Vessels|Secondary|Casters|
             * -----------------------------------------------------------------------------
             * |North Scrap WB|    *    |              |    *    |       |         |       |
             * |South Scrap WB|    *    |              |    *    |       |         |       |
             * |North HM      |    *    |      *       |         |       |         |       |
             * |South HM      |    *    |      *       |         |       |         |       |
             * |North Desulph |    *    |      *       |         |       |         |       |
             * |South Desulph |    *    |      *       |         |       |         |       |
             * |Vessel 1      |    *    |              |         |   *   |         |       |
             * |Vessel 2      |    *    |              |         |   *   |         |       |
             * |CAS1          |    *    |              |         |       |    *    |       |
             * |CAS2          |    *    |              |         |       |    *    |       |
             * |RH            |    *    |              |         |       |    *    |       |
             * |RD            |    *    |              |         |       |    *    |       |
             * |Caster 1      |         |              |         |       |         |   *   |
             * |Caster 2      |         |              |         |       |         |   *   |
             * |Caster 3      |         |              |         |       |         |   *   |
             * |Lime Plant    |    *    |              |    *    |       |         |       |
             * -----------------------------------------------------------------------------
             */

            // 1. Local constants for readability.
            const int BOS = 0;
            const int HMPREP = 1;
            const int MATERIALS = 2;
            const int VESSELS = 3;
            const int SECONDARY = 4;
            const int CASTERS = 5;

            const string SCRAP_NORTH = "ScrapNorth";
            const string SCRAP_SOUTH = "ScrapSouth";
            const string HOT_METAL_NORTH = "HotMetalNorth";
            const string HOT_METAL_SOUTH = "HotMetalSouth";
            const string DESULPH_NORTH = "DesulphNorth";
            const string DESULPH_SOUTH = "DesulphSouth";
            const string VESSEL1 = "Vessel1";
            const string VESSEL2 = "Vessel2";
            const string CAS1 = "CAS1";
            const string CAS2 = "CAS2";
            const string RH = "RH";
            const string RD = "RD";
            const string CC1 = "CC1";
            const string CC2 = "CC2";
            const string CC3 = "CC3";
            const string LIME_PLANT = "LimePlant";

            // 2. A collection to hold the aggregated results. A PlantUnitReportSummary type will do fine.
            var aggregateSummaries = new List<PlantUnitReportSummary>
            {
                new PlantUnitReportSummary {UnitText = "BOS",
                    CountDone = 0, CountNotDone = 0, TotalMinsDone = 0, TotalMinsNotDone = 0 },
                new PlantUnitReportSummary { UnitText = "Hot Metal Prep",
                    CountDone = 0, CountNotDone = 0, TotalMinsDone = 0, TotalMinsNotDone = 0},
                new PlantUnitReportSummary { UnitText = "Materials",
                    CountDone = 0, CountNotDone = 0, TotalMinsDone = 0, TotalMinsNotDone = 0},
                new PlantUnitReportSummary { UnitText = "Vessels",
                    CountDone = 0, CountNotDone = 0, TotalMinsDone = 0, TotalMinsNotDone = 0},
                new PlantUnitReportSummary { UnitText = "Secondary",
                    CountDone = 0, CountNotDone = 0, TotalMinsDone = 0, TotalMinsNotDone = 0},
                new PlantUnitReportSummary { UnitText = "Casters",
                    CountDone = 0, CountNotDone = 0, TotalMinsDone = 0, TotalMinsNotDone = 0}
            };

            // 3. Iterate through the "Figures by Plant Unit" collection and add the values to the aggregate
            //    summary according to the groupings in the table above.

            foreach (var summary in plantUnitSummaries)
            {
                switch (summary.Unit)
                {
                    case SCRAP_NORTH: // Fall through
                    case SCRAP_SOUTH: // Fall through
                    case LIME_PLANT:
                        aggregateSummaries[BOS].CountNotDone += summary.CountNotDone;
                        aggregateSummaries[BOS].TotalMinsNotDone += summary.TotalMinsNotDone;
                        aggregateSummaries[BOS].CountDone += summary.CountDone;
                        aggregateSummaries[BOS].TotalMinsDone += summary.TotalMinsDone;
                        aggregateSummaries[MATERIALS].CountNotDone += summary.CountNotDone;
                        aggregateSummaries[MATERIALS].TotalMinsNotDone += summary.TotalMinsNotDone;
                        aggregateSummaries[MATERIALS].CountDone += summary.CountDone;
                        aggregateSummaries[MATERIALS].TotalMinsDone += summary.TotalMinsDone;
                        break;
                    case HOT_METAL_NORTH: // Fall through
                    case HOT_METAL_SOUTH: // Fall through
                    case DESULPH_NORTH:   // Fall through
                    case DESULPH_SOUTH:   // Fall through
                        aggregateSummaries[BOS].CountNotDone += summary.CountNotDone;
                        aggregateSummaries[BOS].TotalMinsNotDone += summary.TotalMinsNotDone;
                        aggregateSummaries[BOS].CountDone += summary.CountDone;
                        aggregateSummaries[BOS].TotalMinsDone += summary.TotalMinsDone;
                        aggregateSummaries[HMPREP].CountNotDone += summary.CountNotDone;
                        aggregateSummaries[HMPREP].TotalMinsNotDone += summary.TotalMinsNotDone;
                        aggregateSummaries[HMPREP].CountDone += summary.CountDone;
                        aggregateSummaries[HMPREP].TotalMinsDone += summary.TotalMinsDone;
                        break;
                    case VESSEL1: // Fall through
                    case VESSEL2:
                        aggregateSummaries[BOS].CountNotDone += summary.CountNotDone;
                        aggregateSummaries[BOS].TotalMinsNotDone += summary.TotalMinsNotDone;
                        aggregateSummaries[BOS].CountDone += summary.CountDone;
                        aggregateSummaries[BOS].TotalMinsDone += summary.TotalMinsDone;
                        aggregateSummaries[VESSELS].CountNotDone += summary.CountNotDone;
                        aggregateSummaries[VESSELS].TotalMinsNotDone += summary.TotalMinsNotDone;
                        aggregateSummaries[VESSELS].CountDone += summary.CountDone;
                        aggregateSummaries[VESSELS].TotalMinsDone += summary.TotalMinsDone;
                        break;
                    case CAS1: // Fall through
                    case CAS2: // Fall through
                    case RH:   // Fall through
                    case RD:
                        aggregateSummaries[BOS].CountNotDone += summary.CountNotDone;
                        aggregateSummaries[BOS].TotalMinsNotDone += summary.TotalMinsNotDone;
                        aggregateSummaries[BOS].CountDone += summary.CountDone;
                        aggregateSummaries[BOS].TotalMinsDone += summary.TotalMinsDone;
                        aggregateSummaries[SECONDARY].CountNotDone += summary.CountNotDone;
                        aggregateSummaries[SECONDARY].TotalMinsNotDone += summary.TotalMinsNotDone;
                        aggregateSummaries[SECONDARY].CountDone += summary.CountDone;
                        aggregateSummaries[SECONDARY].TotalMinsDone += summary.TotalMinsDone;
                        break;
                    case CC1: // Fall through
                    case CC2: // Fall through
                    case CC3:
                        aggregateSummaries[CASTERS].CountNotDone += summary.CountNotDone;
                        aggregateSummaries[CASTERS].TotalMinsNotDone += summary.TotalMinsNotDone;
                        aggregateSummaries[CASTERS].CountDone += summary.CountDone;
                        aggregateSummaries[CASTERS].TotalMinsDone += summary.TotalMinsDone;
                        break;
                    default:
                        break;
                }
            }
            return aggregateSummaries;
        }

        private static List<PlantUnitReportSummary> GetPlantUnitSummaries(List<TibReportDelaysView> rawDelaysData,
            IEnumerable<UncompletedReportSummary> delaysByUnit)
        {
            // Build the data collection for the "Figures by Plant Unit" table on the report,
            // pre-dimensioned to the number of units, and populated from the existing collection
            // which has been pre-processed for correctness.
            var plantUnitSummaries = new List<PlantUnitReportSummary>(delaysByUnit.Count());
            foreach (var delayByUnit in delaysByUnit)
            {
                plantUnitSummaries.Add(new PlantUnitReportSummary(delayByUnit));
            }

            foreach (var plantUnitSummary in plantUnitSummaries)
            {
                // Get the full unit name from the raw data, using the short name as the lookup key.
                var unit = rawDelaysData.FirstOrDefault(u => u.UnitShort == plantUnitSummary.Unit);
                plantUnitSummary.UnitText = unit != null ? unit.UnitText : String.Empty;

                // Get the count for missing reports not done by each rota
                var rotas = (from r in rawDelaysData
                             where r.UnitShort == plantUnitSummary.Unit && r.DelayStart == null
                             group r by r.Rota into g
                             select new
                             {
                                 Rota = g.Key,
                                 ReportCount = g.Count()
                             }).ToList();

                // Get the sum of missing reports for each rota.
                plantUnitSummary.RotaATotal = rotas.SingleOrDefault(r => r.Rota == "A") == null ? 0 :
                    rotas.SingleOrDefault(r => r.Rota == "A").ReportCount;

                plantUnitSummary.RotaBTotal = rotas.SingleOrDefault(r => r.Rota == "B") == null ? 0 :
                    rotas.SingleOrDefault(r => r.Rota == "B").ReportCount;

                plantUnitSummary.RotaCTotal = rotas.SingleOrDefault(r => r.Rota == "C") == null ? 0 :
                    rotas.SingleOrDefault(r => r.Rota == "C").ReportCount;

                plantUnitSummary.RotaDTotal = rotas.SingleOrDefault(r => r.Rota == "D") == null ? 0 :
                    rotas.SingleOrDefault(r => r.Rota == "D").ReportCount;

                plantUnitSummary.RotaETotal = rotas.SingleOrDefault(r => r.Rota == "E") == null ? 0 :
                    rotas.SingleOrDefault(r => r.Rota == "E").ReportCount;
            }
            return plantUnitSummaries;
        }

        private static IEnumerable<UncompletedReportSummary> GroupDelaysByRota(List<TibReportDelaysView> rawDelaysData)
        {
            // Filter to distinct events only by TIBEvent.TibIndex
            var rawEvents = Enumerable.DistinctBy(rawDelaysData,d => d.TibIndex).ToList();

            // Count the number of TIB Events by Rota and sum the total number of minutes.
            var eventsData = from t in rawEvents
                             where !String.IsNullOrEmpty(t.Rota)
                             group t by t.Rota into g
                             let count = g.Count()
                             let total = g.Sum(d => d.TibDuration)
                             orderby g.Key
                             select new
                             {
                                 Rota = g.Key,
                                 EventsCount = count,
                                 TotalEventMinutes = total == null ? 0 : total
                             };

            // Ensure there are no duplicates in the data we've been sent to work with.
            var rawDelays = rawDelaysData.Distinct().ToList();

            // Sum the total number of completed delay minutes per Rota, ie ones where the user has entered a reason.
            var delaysData = from t in rawDelays
                             group t by t.Rota into g
                             let total = g.Sum(d => d.DelayDuration)
                             orderby g.Key
                             select new
                             {
                                 Rota = g.Key,
                                 CompletedDelayMinutes = total == null ? 0 : total
                             };

            // Total up the number of completed delay reports by Rota. A delay can have 1 or more completed reports.
            var completedDelays = from t in rawDelays
                                  where t.TibDelayIndex != null
                                  group t by t.Rota into g
                                  let count = g.Count()
                                  orderby g.Key
                                  select new
                                  {
                                      Rota = g.Key,
                                      CompletedReportsCount = count
                                  };

            // Total up the number of events which don't have fully completed reports. NB: an event can have one or
            // more reports associated with it, but will have a missing report if the duration of the event is greater
            // than the sum of the durations of any associated delay entries.
            var notCompletedDelays = from t in rawEvents
                                     where t.TibDelayIndex == null
                                     group t by t.Rota into g
                                     let count = g.Count()
                                     orderby g.Key
                                     select new
                                     {
                                         Rota = g.Key,
                                         NotCompletedReportsCount = count
                                     };

            // Dictionary to hold total delay durations for each event for use as a lookup table later.
            Dictionary<int, int> totalDelaysDurationByTibIndex = new Dictionary<int, int>();

            // Group the events by TibIndex
            var processedDelaysGrouped = (from p in rawDelaysData
                                          group p by p.TibIndex into pg
                                          select new { Key = pg.Key, Delays = pg }).ToList();

            // For each event (grouped by TibIndex), iterate over the delay records to sum the DelayDurations.
            foreach (var delayGroup in processedDelaysGrouped)
            {
                int tibIndex = delayGroup.Key;
                int totalDelayDuration = (int)delayGroup.Delays.Sum(d => d.DelayDuration);
                if (totalDelayDuration > 0)
                {
                    totalDelaysDurationByTibIndex.Add(tibIndex, totalDelayDuration);
                }
            }

            var processedDelaysGroupedByRota =
                from t in rawDelaysData
                group t by t.Rota into g
                select new
                {
                    Rota = g.Key,
                    Events = g
                };

            Dictionary<string, int> totalIncompleteReportsByRota = new Dictionary<string, int>();
            foreach (var f in processedDelaysGroupedByRota)
            {
                var nullDelaysCount = f.Events.Where(e => !e.TibDelayIndex.HasValue).Count();

                var tibIndexes = f.Events.Select(e => e.TibIndex).Distinct();

                // Counter for TIB Events where some delays have been entered but not all.
                int counter = 0;

                foreach (var tibIndex in tibIndexes)
                {
                    if (totalDelaysDurationByTibIndex.ContainsKey(tibIndex))
                    {
                        int totalDelayDuration = (int)totalDelaysDurationByTibIndex[tibIndex];
                        var processedDelay = rawDelaysData.First(d => d.TibIndex == tibIndex);
                        if (processedDelay.TibDuration > totalDelayDuration)
                        {
                            counter++;
                        }
                    }
                }

                var totalOutstandingReports = nullDelaysCount + counter;
                totalIncompleteReportsByRota.Add(f.Rota, totalOutstandingReports);
            }

            var combined = eventsData.Join
            (
                delaysData, e => e.Rota, d => d.Rota,
                (e, d) => new UncompletedReportSummary
                {
                    Unit = e.Rota,
                    EventsCount = e.EventsCount,
                    TotalEventMinutes = e.TotalEventMinutes,

                    CompletedReportsCount =
                        completedDelays.FirstOrDefault(r => r.Rota == e.Rota) != null
                        ? completedDelays.FirstOrDefault(r => r.Rota == e.Rota).CompletedReportsCount : 0,

                    NotCompletedReportsCount = totalIncompleteReportsByRota[e.Rota],
                    CompletedDelayMinutes = d.CompletedDelayMinutes,
                    MissingMinutesTotal = e.TotalEventMinutes - d.CompletedDelayMinutes
                }
            );
            return combined;
        }

        private static IEnumerable<UncompletedReportSummary> GroupDelaysByShift(List<TibReportDelaysView> rawDelaysData)
        {
            // Filter to distinct events only by TIBEvent.TibIndex
            var rawEvents =  Enumerable.DistinctBy(rawDelaysData,d => d.TibIndex).ToList();

            // Count the number of TIB Events by Shift and sum the total number of minutes.
            var eventsData = from t in rawEvents
                             where !String.IsNullOrEmpty(t.Shift)
                             group t by t.Shift into g
                             let count = g.Count()
                             let total = g.Sum(d => d.TibDuration)
                             orderby g.Key
                             select new
                             {
                                 Shift = g.Key,
                                 EventsCount = count,
                                 TotalEventMinutes = total == null ? 0 : total
                             };

            // Ensure there are no duplicates in the data we've been sent to work with.
            var rawDelays = rawDelaysData.Distinct().ToList();

            // Sum the total number of completed delay minutes per shift, ie ones where the user has entered a reason.
            var delaysData = from t in rawDelays
                             group t by t.Shift into g
                             let total = g.Sum(d => d.DelayDuration)
                             orderby g.Key
                             select new
                             {
                                 Shift = g.Key,
                                 CompletedDelayMinutes = total == null ? 0 : total
                             };

            // Total up the number of completed delay reports by shift. A delay can have 1 or more completed reports.
            var completedDelays = from t in rawDelays
                                  where t.TibDelayIndex != null
                                  group t by t.Shift into g
                                  let count = g.Count()
                                  orderby g.Key
                                  select new
                                  {
                                      Shift = g.Key,
                                      CompletedReportsCount = count
                                  };

            // Total up the number of events which don't have fully completed reports. NB: an event can have one or
            // more reports associated with it, but will have a missing report if the duration of the event is greater
            // than the sum of the durations of any associated delay entries.
            var notCompletedDelays = from t in rawEvents
                                     where t.TibDelayIndex == null
                                     group t by t.Shift into g
                                     let count = g.Count()
                                     orderby g.Key
                                     select new
                                     {
                                         Shift = g.Key,
                                         NotCompletedReportsCount = count
                                     };

            // Dictionary to hold total delay durations for each event for use as a lookup table later.
            Dictionary<int, int> totalDelaysDurationByTibIndex = new Dictionary<int, int>();

            // Group the events by TibIndex
            var processedDelaysGrouped = (from p in rawDelaysData
                                          group p by p.TibIndex into pg
                                          select new { Key = pg.Key, Delays = pg }).ToList();

            // For each event (grouped by TibIndex), iterate over the delay records to sum the DelayDurations.
            foreach (var delayGroup in processedDelaysGrouped)
            {
                int tibIndex = delayGroup.Key;
                int totalDelayDuration = (int)delayGroup.Delays.Sum(d => d.DelayDuration);
                if (totalDelayDuration > 0)
                {
                    totalDelaysDurationByTibIndex.Add(tibIndex, totalDelayDuration);
                }
            }

            var processedDelaysGroupedByShift =
                from t in rawDelaysData
                group t by t.Shift into g
                select new
                {
                    Shift = g.Key,
                    Events = g
                };

            Dictionary<string, int> totalIncompleteReportsByShift = new Dictionary<string, int>();
            foreach (var f in processedDelaysGroupedByShift)
            {
                var nullDelaysCount = f.Events.Where(e => !e.TibDelayIndex.HasValue).Count();

                var tibIndexes = f.Events.Select(e => e.TibIndex).Distinct();

                // Counter for TIB Events where some delays have been entered but not all.
                int counter = 0;

                foreach (var tibIndex in tibIndexes)
                {
                    if (totalDelaysDurationByTibIndex.ContainsKey(tibIndex))
                    {
                        int totalDelayDuration = (int)totalDelaysDurationByTibIndex[tibIndex];
                        var processedDelay = rawDelaysData.First(d => d.TibIndex == tibIndex);
                        if (processedDelay.TibDuration > totalDelayDuration)
                        {
                            counter++;
                        }
                    }
                }

                var totalOutstandingReports = nullDelaysCount + counter;
                totalIncompleteReportsByShift.Add(f.Shift, totalOutstandingReports);
            }

            var combined = eventsData.Join
            (
                delaysData, e => e.Shift, d => d.Shift,
                (e, d) => new UncompletedReportSummary
                {
                    Unit = e.Shift,
                    EventsCount = e.EventsCount,
                    TotalEventMinutes = e.TotalEventMinutes,

                    CompletedReportsCount =
                        completedDelays.FirstOrDefault(r => r.Shift == e.Shift) != null
                        ? completedDelays.FirstOrDefault(r => r.Shift == e.Shift).CompletedReportsCount : 0,

                    NotCompletedReportsCount = totalIncompleteReportsByShift[e.Shift],
                    CompletedDelayMinutes = d.CompletedDelayMinutes,
                    MissingMinutesTotal = e.TotalEventMinutes - d.CompletedDelayMinutes
                }
            );
            return combined;
        }

        /// <summary>
        /// Groups the raw delays data by Unit
        /// </summary>
        /// <param name="rawDelaysData">The raw delays</param>
        /// <returns>A collection grouped by unit</returns>
        private static IEnumerable<UncompletedReportSummary> GroupDelaysByUnit(List<TibReportDelaysView> rawDelaysData)
        {
            // Filter to distinct events only by TIBEvent.TibIndex
            var rawEvents = Enumerable.DistinctBy(rawDelaysData, d => d.TibIndex).ToList();
                        
            // Count the number of TIB Events by unit and sum the total number of minutes.
            var eventsData = from t in rawEvents
                             group t by t.UnitShort into g
                             let count = g.Count()
                             let total = g.Sum(d => d.TibDuration)
                             let unitGroup = g.Max(d => d.UnitGroup)
                             orderby unitGroup
                             select new
                             {
                                 Unit = g.Key,
                                 EventsCount = count,
                                 TotalEventMinutes = total == null ? 0 : total
                             };

            // Ensure there are no duplicates in the data we've been sent to work with.
            var rawDelays = rawDelaysData.Distinct().ToList();

            // Sum the total number of completed delay minutes per unit, ie ones where the user has entered a reason.
            var delaysData = from t in rawDelays
                             group t by t.UnitShort into g
                             let total = g.Sum(d => d.DelayDuration)
                             let unitGroup = g.Max(d => d.UnitGroup)
                             orderby unitGroup
                             select new DelayDataSummary
                             {
                                 Unit = g.Key,
                                 CompletedDelayMinutes = total == null ? 0 : total
                             };
            
            //2015-10-27 Les Jones Modify CompletedDelayMinutes to take into account over booking against a Tib event
            //This is a bit of a hack that needs to be removed when the reports are rewritten
            List<DelayDataSummary> dataSummary = new List<DelayDataSummary>();
            foreach (var delaydata in delaysData)
            {
                dataSummary.Add(new DelayDataSummary
                {
                    Unit = delaydata.Unit,
                    CompletedDelayMinutes = delaydata.CompletedDelayMinutes
                });
            }

            foreach (DelayDataSummary summary in dataSummary)
            {
                var delaysByUnit = rawDelaysData.Where(u => u.UnitShort == summary.Unit && u.TibDelayIndex.HasValue);
                var distinctEvents = Enumerable.DistinctBy(delaysByUnit,t => t.TibIndex).ToList();
                int minsToRemove = 0;
                foreach (var distinctEvent in distinctEvents)
                {
                    var tibEvent = rawDelaysData.Where(e => e.TibIndex == distinctEvent.TibIndex).ToList();
                    if (tibEvent != null)
                    {
                        int? tibDuration = distinctEvent.TibDuration;
                        int? delayDuration = tibEvent.Sum(e => e.DelayDuration);

                        if (delayDuration > tibDuration)
                        {
                            minsToRemove += Convert.ToInt16(delayDuration - tibDuration);
                        }
                    }
                }
                summary.CompletedDelayMinutes = summary.CompletedDelayMinutes - minsToRemove;
            }
            //end of modify

            // Total up the number of completed delay reports by unit. A delay can have 1 or more completed reports.
            var completedDelays = from t in rawDelays
                                  where t.TibDelayIndex != null
                                  group t by t.UnitShort into g
                                  let count = g.Count()
                                  let unitGroup = g.Max(d => d.UnitGroup)
                                  orderby unitGroup
                                  select new
                                  {
                                      Unit = g.Key,
                                      CompletedReportsCount = count
                                  };
            // Total up the number of events which don't have fully completed reports. NB: an event can have one or
            // more reports associated with it, but will have a missing report if the duration of the event is greater
            // than the sum of the durations of any associated delay entries.
            var notCompletedDelays = from t in rawEvents
                                     where t.TibDelayIndex == null
                                     group t by t.UnitShort into g
                                     let count = g.Count()
                                     let unitGroup = g.Max(d => d.UnitGroup)
                                     orderby unitGroup
                                     select new
                                     {
                                         Unit = g.Key,
                                         NotCompletedReportsCount = count
                                     };
            // Dictionary to hold total delay durations for each event for use as a lookup table later.
            Dictionary<int, int> totalDelaysDurationByTibIndex = new Dictionary<int, int>();

            // Group the events by TibIndex
            var processedDelaysGrouped = (from p in rawDelaysData
                                          group p by p.TibIndex into pg
                                          select new { Key = pg.Key, Delays = pg }).ToList();

            // For each event (grouped by TibIndex), iterate over the delay records to sum the DelayDurations.
            foreach (var delayGroup in processedDelaysGrouped)
            {
                int tibIndex = delayGroup.Key;
                int totalDelayDuration = (int)delayGroup.Delays.Sum(d => d.DelayDuration);
                               
                if (totalDelayDuration > 0)
                {
                    totalDelaysDurationByTibIndex.Add(tibIndex, totalDelayDuration);
                }
            }

            var processedDelaysGroupedByUnit =
                from t in rawDelaysData
                group t by t.UnitShort into g
                select new
                {
                    Unit = g.Key,
                    Events = g
                };

            Dictionary<string, int> totalIncompleteReportsByUnit = new Dictionary<string, int>();
            foreach (var f in processedDelaysGroupedByUnit)
            {
                var nullDelaysCount = f.Events.Where(e => !e.TibDelayIndex.HasValue).Count();
                var tibIndexes = f.Events.Select(e => e.TibIndex).Distinct();

                // Counter for TIB Events where some delays have been entered but not all.
                int counter = 0;

                foreach (var tibIndex in tibIndexes)
                {
                    if (totalDelaysDurationByTibIndex.ContainsKey(tibIndex))
                    {
                        int totalDelayDuration = (int)totalDelaysDurationByTibIndex[tibIndex];
                        var processedDelay = rawDelaysData.First(d => d.TibIndex == tibIndex);
                        if (processedDelay.TibDuration > totalDelayDuration)
                        {
                            counter++;
                        }
                    }
                }

                var totalOutstandingReports = nullDelaysCount + counter;
                totalIncompleteReportsByUnit.Add(f.Unit, totalOutstandingReports);
            }
            
            var combined = eventsData.Join
            (
                //delaysData, e => e.Unit, d => d.Unit,
                dataSummary, e => e.Unit, d => d.Unit,
                (e, d) => new UncompletedReportSummary
                {
                    Unit = e.Unit,
                    EventsCount = e.EventsCount,
                    TotalEventMinutes = e.TotalEventMinutes,

                    CompletedReportsCount =
                        completedDelays.FirstOrDefault(r => r.Unit == e.Unit) != null
                        ? completedDelays.FirstOrDefault(r => r.Unit == e.Unit).CompletedReportsCount : 0,

                    NotCompletedReportsCount = totalIncompleteReportsByUnit[e.Unit],
                    CompletedDelayMinutes = d.CompletedDelayMinutes,
                    MissingMinutesTotal = e.TotalEventMinutes - d.CompletedDelayMinutes
                }
            );
            return combined;
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
                    GenerateReport();
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
        /// Opens the Heat Details Form for a specific heat.
        /// </summary>
        /// <param name="parameters">The parameters passed from the hyperlink clicked.</param>
        private void OpenHeatDetails(string[] parameters)
        {
            int heatNo = Convert.ToInt32(
                parameters[0].Substring(parameters[0].IndexOf('=') + 1)
                );
            int heatNoSet = Convert.ToInt32(
                parameters[1].Substring(parameters[1].IndexOf('=') + 1)
                );

            HeatDetails heatDetails = new HeatDetails(
                heatNo,
                false,
                false,
                main.IsMiscastAdmin,
                heatNoSet
                );
            heatDetails.Show();
        }

        /// <summary>
        /// Generates a new report for the user.
        /// </summary>
        private void GenerateReport()
        {
            Cursor current = Cursor;
            Cursor = Cursors.WaitCursor;
            try
            {
                btnGenerate.Enabled = false;
                GetDelaysData();
            }
            finally
            {
                btnGenerate.Enabled = true;
                Cursor = current;
            }
        }

        /// <summary>
        /// Builds a list of delays to be used on the Delays By Unit page on the Tib Delays To Enter RDLC report.
        /// This will iterate over the original dlay list, distinct by TibIndex and add any Tib events without
        /// a TibDelayIndex and any where the total DelayDuration is less than TibDuration to the returned list.
        /// The list is the source to the BindingSource used for the table on the report.
        /// </summary>
        /// <param name="rawDelays">Original list  of processed delays</param>
        /// <returns>List of Tib events that need delays entered against them</returns>
        private List<TibReportDelaysView> BuildDelaysToEnterByUnit(List<TibReportDelaysView> rawDelays)
        {
            List<TibReportDelaysView> delaysByUnit = new List<TibReportDelaysView>();
            foreach(var d in Enumerable.DistinctBy(rawDelays, e => e.TibIndex))
            {
                //add the tib delays where tibdelayindex is null
                if (!d.TibDelayIndex.HasValue)
                {
                    delaysByUnit.Add(d);
                }
                else
                {
                    //add the tib delays where delay duration <> tibduration
                    int tibDuration = (int)d.TibDuration;
                    var allDelaysForTib = rawDelays.Where(e => e.TibIndex == d.TibIndex).ToList();
                    int delayDuration = (int)allDelaysForTib.Sum(e => e.DelayDuration);
                    if (tibDuration > delayDuration)
                    {
                        delaysByUnit.Add(d);
                    }
                }
            }
            return delaysByUnit;
        }

        #region Events
        /// <summary>
        /// Load event for the Report Form
        /// </summary>
        private void TIBDelaysToEnterReport_Load(object sender, EventArgs e)
        {
            SetupDateSelector();
            InitialDateSetup();
            SetupWeekNo();
            CustomiseColours();
        }

        /// <summary>
        /// Generate button click event
        /// </summary>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        /// <summary>
        /// Button click event for resetting the filtering.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        /// <summary>
        /// Changes the selected date from and to for every
        /// time the user changes a numeric up down.
        /// </summary>
        private void numPickers_ValueChanged(object sender, EventArgs e)
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
        /// Close Form using Escape
        /// </summary>
        private void TIBDelaysToEnterReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Handles the hyerlinks clicked on the report viewer.
        /// </summary>
        private void reportViewer_Hyperlink(object sender, HyperlinkEventArgs e)
        {
            //Remove non parameter text
            string parameters = e.Hyperlink.Substring(e.Hyperlink.IndexOf('?') + 1);
            if (e.Hyperlink.ToUpper().Contains("HEATDETAILS"))
            {
                OpenHeatDetails(parameters.Split('&'));
            }
            else if (e.Hyperlink.ToUpper().Contains("DELAYENTRY"))
            {
                OpenDelayEntry(parameters.Split('&'));
            }
            e.Cancel = true;
        }

        #region Menu Events
        /// <summary>
        /// Close form click event.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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

        /// <summary>
        /// Handles the form closing event. Checks to see if the tib display needs refreshing.
        /// </summary>
        private void TIBDelaysToEnterReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DirtyDelays)
            {
                main.CountDown = TimeSpan.Zero;
            }
        }

        #endregion

        #endregion
    }
}


public class DelayDataSummary
{
    public string Unit { get; set; }
    public int? CompletedDelayMinutes { get; set; }
}

public class CompletedDelayAdjust
{
    public string Unit { get; set; }
    public int Offset { get; set; }
}