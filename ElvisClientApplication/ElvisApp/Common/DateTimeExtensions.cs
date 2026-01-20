using System;
using System.Collections.Generic;

namespace Elvis.Common
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Truncates the date to the whole hour. i.e. the minutes and seconds
        /// are set to zero. 
        /// E.g. 02/10/2013 17:28:02 becomes 02/10/2013 17:00:00
        /// </summary>
        /// <param name="date"></param>
        /// <returns>The date rounded down to the nearest whole hour.</returns>
        public static DateTime TruncateToHour(this DateTime date)
        {
            return date.Date.AddHours(date.Hour);
        }

        /// <summary>
        /// Get the Week number of the year
        /// (In the range 1..53)
        /// This conforms to ISO 8601 specification for week number.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Week of year.</returns>
        public static int WeekOfYear(this DateTime date)
        {
            /// <summary>
            /// Offsets to move the day of the year on a week, allowing
            /// for the current year Jan 1st day of week, and the Sun/Mon 
            /// week start difference between ISO 8601 and Microsoft
            /// </summary>
            int[] moveByDays = { 6, 7, 8, 9, 10, 4, 5 };

            DateTime startOfYear = new DateTime(date.Year, 1, 1);
            DateTime endOfYear = new DateTime(date.Year, 12, 31);
            // ISO 8601 weeks start with Monday 
            // The first week of a year includes the first Thursday 
            // This means that Jan 1st could be in week 51, 52, or 53 of the previous year...
            int numberDays = date.Subtract(startOfYear).Days +
                            moveByDays[(int)startOfYear.DayOfWeek];
            int weekNumber = numberDays / 7;
            switch (weekNumber)
            {
                case 0:
                    // Before start of first week of this year - in last week of previous year
                    weekNumber = WeekOfYear(startOfYear.AddDays(-1));
                    break;
                case 53:
                    // In first week of next year.
                    if (endOfYear.DayOfWeek < DayOfWeek.Thursday)
                    {
                        weekNumber = 1;
                    }
                    break;
            }
            return weekNumber;
        }

        /// <summary>
        /// Function to trim down a DateTime so that it has 0 seconds and 0 milliseconds
        /// Used for comparisons between DateTime's where seconds are not important.
        /// </summary>
        /// <param name="dt">The DateTime you wish to trim.</param>
        /// <returns>The trimmed DateTime</returns>
        public static DateTime TrimSeconds(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0);
        }

        /// <summary>
        /// Function to trim down a DateTime so that it has 0 milliseconds.
        /// Used for comparisons between DateTime's where milliseconds are not important.
        /// </summary>
        /// <param name="dt">The DateTime you wish to trim.</param>
        /// <returns>The trimmed DateTime</returns>
        public static DateTime TrimMiliSeconds(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0);
        }

        /// <summary>
        /// Helper Function that converts a DateTime? into a string of format HH:mm
        /// and adds any minutes if needed (use negative values to subtract or 0 if no minutes to add)
        /// </summary>
        /// <param name="value">The DateTime to Convert</param>
        /// <param name="minutesToAdd">Amount of minutes to add/subtract</param>
        /// <returns>Time in format HH:mm OR ##:## if null</returns>
        public static string FormatAndGetDateTime(DateTime? value, int minutesToAdd)
        {
            if (value.HasValue)
            {
                DateTime time = Convert.ToDateTime(value);
                time = time.AddMinutes(minutesToAdd);
                return time.ToString("HH:mm");
            }
            else
                return "##:##";
        }

        /// <summary>
        /// Checks if there is a week 53 in the year given.
        /// </summary>
        /// <param name="yearNo">The Year to Check.</param>
        /// <returns>True = Week 53 Exists, False = Only 52 Weeks in Year.</returns>
        public static bool IsWeek53Valid(int yearNo)
        {
            int y, w, d, s = 0;//shift info
            DateTime lastDayOfYear = new DateTime(yearNo, 12, 31);
            ShiftDateTime.ConvertTo_ShiftDateTime(12, lastDayOfYear, out y, out w, out d, out s);

            if (w == 53)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Sets a certain DateTime to a specific Hour give.
        /// </summary>
        /// <param name="date">The Date to Format.</param>
        /// <param name="hour">The Hour to set the DateTime to</param>
        /// <returns>The formatted DateTime.</returns>
        public static DateTime SetToSpecificHour(this DateTime dt, int hour)
        {
            return Convert.ToDateTime(dt.ToString(string.Format("yyyy-MM-dd {0}:00:00", hour)));
        }

        /// <summary>
        /// Gets the date for the start of the week for the given date. The start of the
        /// week can be on any day, as specified by the startOfWeek parameter.
        /// </summary>
        /// <param name="startOfWeek">The day the week starts on</param>
        /// <returns>Midnight on the first day of the week</returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Not an extension but still relevant to DateTime.
        /// Allows you to ForEach loop through each day 
        /// between two given dates.
        /// </summary>
        /// <param name="from">The From Date</param>
        /// <param name="thru">Through to the To Date</param>
        /// <param name="interval">Controls the difference between days. Pass one for every day, 
        /// pass 3 for every 3rd day etc.</param>
        /// <returns>A list of Days as DateTime</returns>
        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru, int interval)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(interval))
                yield return day;
        }
    }
}
