
namespace Elvis.Forms.Reports
{
    /// <summary>
    /// DTO class to hold the data for the "Uncompleted Reports per Plant Unit" and "% Completion Rate" charts
    /// on the TIB "Delays To Enter" report.
    /// </summary>
    public class UncompletedReportSummary
    {
        public string Unit { get; set; }
        public int? EventsCount { get; set; }
        public int? TotalEventMinutes { get; set; }

        public int? CompletedReportsCount { get; set; }
        public int? NotCompletedReportsCount { get; set; }

        public int? CompletedDelayMinutes { get; set; }
        //public int? TotalDelayMinutes { get; set; }
        public int? MissingMinutesTotal { get; set; }

        public decimal? PercentageReportsComplete
        {
            get
            {
                // Start with the number of events as a base value.
                int totalReportsCount = 0;
                if (EventsCount.HasValue)
                {
                    totalReportsCount = EventsCount.Value;
                }

                // Get the total number of reports. Can't use the number of events because an event can have
                // multiple reports and therefore be partially complete which distorts the percentage.
                if (CompletedReportsCount.HasValue)
                {
                    totalReportsCount = CompletedReportsCount.Value + NotCompletedReportsCount.Value;                   
                }

                if (totalReportsCount == 0 || EventsCount == 0)
                    return 0;
                else
                    return (((decimal)totalReportsCount - (decimal)NotCompletedReportsCount) / (decimal)totalReportsCount) * 100;
            }
        }

        public decimal? PercentageMinutesComplete
        {
            get
            {
                if (!TotalEventMinutes.HasValue || TotalEventMinutes == 0)
                    return 0;
                else
                    return (((decimal)TotalEventMinutes - (decimal)MissingMinutesTotal) / (decimal)TotalEventMinutes) * 100;
            }
        }
    }
}