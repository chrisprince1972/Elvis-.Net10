// -----------------------------------------------------------------------
// <copyright file="ShiftHeatCountSummary.cs" company="TSSP UK">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Elvis.Model.ViewModels
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Provides summary totals of the heats produced across all Casters
    /// for a given Shift.
    /// </summary>
    public class ShiftHeatCountSummary
    {
        public string Shift { get; set; }
        public ShiftType ShiftType { get; set; }
        public DateTime ShiftDate { get; set; }

        public string DisplayDay
        {
            get
            {
                string[] names = CultureInfo.InstalledUICulture.DateTimeFormat.AbbreviatedDayNames;
                return names[(int)ShiftDate.DayOfWeek];
            }
        }

        public string DisplayShift
        {
            get
            {
                switch (ShiftType)
                {
                    case ShiftType.Day:
                        return ShiftDate.ToString("dd-MM 07:00");
                    case ShiftType.Night:
                        return ShiftDate.ToString("dd-MM 19:00");
                    case ShiftType.TenAMPlan:
                        return ShiftDate.ToString("dd-MM 10:00");
                    case ShiftType.SevenAMPlan:
                        return ShiftDate.ToString("dd-MM 07:00");
                    default:
                        return "Unknown";
                }
            }
        }

        public int CC1PlannedCount { get; set; }
        public int CC2PlannedCount { get; set; }
        public int CC3PlannedCount { get; set; }

        public int PlannedCountTotal
        {
            get { return CC1PlannedCount + CC2PlannedCount + CC3PlannedCount; }
        }

        public int CC1DeviationsCount { get; set; }
        public int CC2DeviationsCount { get; set; }
        public int CC3DeviationsCount { get; set; }

        public int DeviationsCountTotal
        {
            get { return CC1DeviationsCount + CC2DeviationsCount + CC3DeviationsCount; }
        }

        public int CC1ActualCount { get; set; }
        public int CC2ActualCount { get; set; }
        public int CC3ActualCount { get; set; }

        public int ActualCountTotal
        {
            get { return CC1ActualCount + CC2ActualCount + CC3ActualCount; }
        }
    }
}
