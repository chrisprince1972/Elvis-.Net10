
namespace Elvis.Forms.Reports
{
    /// <summary>
    /// DTO class to hold the data for the "Figures by Plant Unit" and "Aggregated Figures" tables
    /// on the TIB "Delays To Enter" report.
    /// </summary>
    public class PlantUnitReportSummary
    {
        public string Unit { get; set; }
        public string UnitText { get; set; }
        public int? CountNotDone { get; set; }
        public int? TotalMinsNotDone { get; set; }

        public int? RotaATotal { get; set; }
        public int? RotaBTotal { get; set; }
        public int? RotaCTotal { get; set; }
        public int? RotaDTotal { get; set; }
        public int? RotaETotal { get; set; }

        public int? CountDone { get; set; }
        public int? TotalMinsDone { get; set; }

        public decimal? CountPercentageComplete
        {
            get
            {
                // Check for null and potential divide-by-zero.
                if (!CountDone.HasValue || !CountNotDone.HasValue) return 0;
                if (CountDone + CountNotDone == 0) return 0;

                return ((decimal)CountDone / ((decimal)CountDone + (decimal)CountNotDone));
            }
        }

        public decimal? TotalMinsPercentageComplete
        {
            get
            {
                // Check for null and potential divide-by-zero.
                if (!TotalMinsDone.HasValue || !TotalMinsNotDone.HasValue) return 0;
                if (TotalMinsDone + TotalMinsNotDone == 0) return 0;

                return ((decimal)TotalMinsDone / ((decimal)TotalMinsDone + (decimal)TotalMinsNotDone));
            }
        }

        public PlantUnitReportSummary()
        {
        }

        public PlantUnitReportSummary(UncompletedReportSummary uncompletedReport)
        {
            Unit = uncompletedReport.Unit;
            CountNotDone = uncompletedReport.NotCompletedReportsCount.Value;
            TotalMinsNotDone = uncompletedReport.MissingMinutesTotal;

            CountDone = uncompletedReport.EventsCount.Value - uncompletedReport.NotCompletedReportsCount.Value;
            TotalMinsDone = uncompletedReport.TotalEventMinutes - uncompletedReport.MissingMinutesTotal;
        }
    }
}
