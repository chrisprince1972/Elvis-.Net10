using System;

namespace Elvis.Common
{
    public static class TimeFunctions
    {
        static int Hour7AM = 7;
        static int Hour19PM = 19;

        public static int WeekNr_ISO(DateTime DT)
        {
            return DT.WeekOfYear();
        }

        public static int DayOfWeek_ISO(DateTime DT)
        {
            if ((int)DT.DayOfWeek == 1)
                return 7;
            else
                return (int)DT.DayOfWeek - 1;
        }

        public static DateTime StartOfWeek_ISO(DateTime DT)
        {
            int DOW;

            DT = DT.Date;
            DOW = (int)DT.DayOfWeek;

            if (DOW == 1)
                // It is a Sunday, the week started 6 days ago
                return DT.AddDays(-6);
            else
                // It's a Mon .. Sat, began the week (DOW + 2) days ago
                return DT.AddDays(-DOW).AddDays(2);
        }

        public static int GetWeekNumber(DateTime DT)
        {
            if ((int)DT.DayOfWeek > 1)
            {
                return WeekNr_ISO(DT);
            }
            else
            {
                if (DT.Hour < Hour7AM)
                {
                    return WeekNr_ISO(DT);
                }
                else
                {
                    return WeekNr_ISO(DT.AddDays(1));
                }
            }
        }

        public static int DayOfWeek_PT(DateTime DT)
        {
            if (DT.Hour < Hour7AM)
            {
                return (int)DT.AddDays(-1).DayOfWeek;
            }
            else
            {
                return (int)DT.DayOfWeek;
            }
        }

        public static DateTime StartOfWeek_PT(DateTime DT)
        {
            DateTime BeginOfWeek;

            if ((int)DT.DayOfWeek > 1)
            {
                DT = DT.Date;
                BeginOfWeek = DT.AddDays((int)DT.DayOfWeek * -1).AddDays(1);
                return BeginOfWeek.AddHours(Hour7AM);
            }
            else
            {
                if (DT.Hour < Hour7AM)
                {
                    BeginOfWeek = DT.Date.AddDays(-7);
                    return BeginOfWeek.AddHours(Hour7AM);
                }
                else
                {
                    DT = DT.Date;
                    return DT.AddHours(Hour7AM);
                }
            }
        }

        public static DateTime StartOfShift_PT(DateTime DT)
        {
            if ((DT.Hour >= 7) && (DT.Hour < 19))
            {
                return DT.Date.AddHours(Hour7AM);
            }
            else
            {
                if (DT.Hour >= 19)
                {
                    return DT.Date.AddHours(Hour19PM);
                }
                else
                {
                    return DT.Date.AddDays(-1).AddHours(Hour19PM);
                }
            }
        }

        public static DateTime Now()
        {
            return TruncDatumTijdOpMinuten(DateTime.Now);
        }

        public static DateTime TruncDatumTijdOpMinuten(DateTime DT)
        {
            return new DateTime(DT.Year, DT.Month, DT.Day, DT.Hour, DT.Minute, 0);
        }
    }
}

