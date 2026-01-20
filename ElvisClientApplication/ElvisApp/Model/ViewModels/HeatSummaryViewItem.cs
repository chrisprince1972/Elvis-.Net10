// -----------------------------------------------------------------------
// <copyright file="HeatSummaryViewItem.cs" company="TSSP UK">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Elvis.Model.ViewModels
{
    using System;

    [Serializable]
    public class HeatSummaryViewItem
    {
        /// <summary>
        /// Enumeration showing whether this instance is a planned or actual heat,
        /// allowing clients to treat instances accordingly.
        /// </summary>
        public enum HeatSummaryType { Planned, Actual };

        public HeatSummaryType SummaryType { get; set; }
        public string CasterName { get; set; }
        public int HeatNumber { get; set; }
        public int ProgramNumber { get; set; }
        public int Grade { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int CombinedWidth { get; set; }

        public string StartTimeDisplayDate
        {
            get { return StartTime.ToString("dd-MM HH:mm"); }
        }

        // Deviations, used for colour coding etc.
        public bool HasCasterNameDeviation { get; set; }
        public bool HasProgramNumberDeviation { get; set; }
        public bool HasGradeDeviation { get; set; }
        public bool HasCombinedWidthDeviation { get; set; }

        public bool HasPlannedNotMadeDeviation { get; set; }
        public bool HasMadeNotPlannedDeviation { get; set; }
    }
}
