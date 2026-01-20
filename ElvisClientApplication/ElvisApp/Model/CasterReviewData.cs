using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Elvis.Common;
using Elvis.Model.ViewModels;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Model
{
    public static class CasterReviewData
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the planned Caster heat schedule for the given day, fixed at 07:00, 10:00 and 19:00.
        /// </summary>
        /// <param name="date">The date</param>
        /// <param name="hour">The hour for the plan, 07, 10 or 19</param>
        /// <returns>A List of ProductionEvents.</returns>
        public static List<ProductionEvent> GetPlanCasterSchedule(DateTime date, int hour)
        {
            List<ProductionEvent> heatList = new List<ProductionEvent>();
            List<DailyPlanCasterHeat> plannedHeats = EntityHelper
                .DailyPlanCasterHeats.GetByFixDate(date.SetToSpecificHour(hour));

            foreach (DailyPlanCasterHeat planHeat in plannedHeats)
            {
                if (planHeat.CASTER_NUMBER.HasValue &&
                    planHeat.PLANNED_START_CAST_TIME.HasValue)
                {
                    heatList.Add(new ProductionEvent
                    {
                        HeatNumber = planHeat.HEAT_NUMBER,
                        HeatNumberSet = planHeat.HNS,
                        ProgramNumber = planHeat.PROGRAM_NUMBER ?? 0,
                        Grade = planHeat.GRADE_1 ?? 0,
                        CasterName = GetCasterName(planHeat.CASTER_NUMBER),
                        UnitId = planHeat.CASTER_NUMBER.Value + 10,
                        StartTime = planHeat.PLANNED_START_CAST_TIME ?? DateTime.Now,
                        EndTime = planHeat.PLANNED_END_CAST_TIME,
                        CastDuration = planHeat.PlannedCastTime ?? 0,
                        IdealCastingTime = planHeat.BestCastTime ?? 0,
                        IsPlanningBlock = true
                    });
                }
            }
            return heatList;
        }

        /// <summary>
        /// Gets the Caster Name from the caster number
        /// </summary>
        /// <param name="casterNo">The caster number.</param>
        /// <returns>The Caster Name as a string.</returns>
        public static string GetCasterName(short? casterNo)
        {
            if (casterNo.HasValue)
            {
                switch (casterNo.Value)
                {
                    case 1:
                        return "CC1";
                    case 2:
                        return "CC2";
                    case 3:
                        return "CC3";
                    default:
                        return "Unknown";
                }
            }
            return "Unknown";
        }

        /// <summary>
        /// Gets the Caster Name from the unit number
        /// </summary>
        /// <param name="unitNo">The Unit Number</param>
        /// <returns>The Caster Name as a string.</returns>
        public static string GetCasterName(int unitNo)
        {
            switch (unitNo)
            {
                case 11:
                    return "CC1";
                case 12:
                    return "CC2";
                case 13:
                    return "CC3";
                default:
                    return "Unknown";
            }
        }

        /// <summary>
        /// Gets the actual Caster heats produced on the given day.
        /// </summary>
        /// <param name="schedulerDate">The production date</param>
        /// <param name="hour">The hour you wish to get, 7 or 10</param>
        /// <returns>A collection of the heats made.</returns>
        public static List<TibEvent> GetActualCasterTib(DateTime schedulerDate, int hour)
        {
            List<TibEvent> tibEventList = new List<TibEvent>();
            DateTime dateFrom = new DateTime(
                schedulerDate.Year, 
                schedulerDate.Month, 
                schedulerDate.Day, 
                hour, 0, 0);
            DateTime dateTo = dateFrom.AddHours(24);

            //TODO: check where this method went maybe lost on conversion
            //tibEventList = Tib.GetCasterReviewActualEvents(dateFrom, dateTo);
            tibEventList = null;
            // Fix missing end times by creating an end time that is 2 minutes before the start time
            // of the next heat processed by the same caster.
            foreach (TibEvent tibEvent in tibEventList)
            {
                if (!tibEvent.EndTime.HasValue)
                {
                    if (tibEvent != tibEventList.Last())
                    {
                        TibEvent nextTibEvent = tibEventList
                            .FirstOrDefault(h => 
                                h.UnitNumber == tibEvent.UnitNumber && 
                                h.StartTime > tibEvent.StartTime);

                        if (nextTibEvent == null)
                        {
                            tibEvent.EndTime = DateTime.Now;
                        }
                        else if (nextTibEvent.StartTime.HasValue)
                        {
                            tibEvent.EndTime = nextTibEvent.StartTime.Value.AddMinutes(-2);
                        }
                    }
                    else
                    {
                        // It's the last one so default to now
                        tibEvent.EndTime = DateTime.Now;
                    }
                }
            }
            return tibEventList;
        }

        /// <summary>
        /// Gets the actual Caster heats produced on the given day.
        /// </summary>
        /// <param name="productionDate">The production date</param>
        /// <param name="hour">The hour you wish to get, 7 or 10</param>
        /// <returns>A collection of the heats made.</returns>
        public static List<ProductionEvent> GetActualCasterProduction(DateTime productionDate, int hour)
        {
            var heatList = new List<ProductionEvent>();
            if (hour == 7)
            {//7 AM
                foreach (CastersProductionItem heat in EntityHelper.GetDailyActualCasterHeats7AM
                    .GetByDate(productionDate))
                {
                    heatList.Add(new ProductionEvent
                    {
                        HeatNumber = heat.HeatNumber,
                        HeatNumberSet = heat.HNS,
                        ProgramNumber = heat.ProgramNumber ?? 0,
                        Grade = heat.Grade1 ?? 0,
                        CasterName = heat.ActualCaster,
                        UnitId = heat.UnitNumber,
                        StartTime = heat.ActualStartDate,
                        EndTime = heat.ActualEndDate,
                        IsPlanningBlock = false
                    });
                }
            }
            else if (hour == 10)
            {//10 AM
                foreach (CastersProductionItem heat in EntityHelper.GetDailyActualCasterHeats
                    .GetByDate(productionDate))
                {
                    heatList.Add(new ProductionEvent
                    {
                        HeatNumber = heat.HeatNumber,
                        HeatNumberSet = heat.HNS,
                        ProgramNumber = heat.ProgramNumber ?? 0,
                        Grade = heat.Grade1 ?? 0,
                        CasterName = heat.ActualCaster,
                        UnitId = heat.UnitNumber,
                        StartTime = heat.ActualStartDate,
                        EndTime = heat.ActualEndDate,
                        IsPlanningBlock = false
                    });
                }
            }

            // Fix missing end times by creating an end time that is 2 minutes before the start time
            // of the next heat processed by the same caster.
            foreach (ProductionEvent heat in heatList)
            {
                if (!heat.EndTime.HasValue)
                {
                    if (heat != heatList.Last())
                    {
                        var nextHeat = heatList
                            .Where(h => h.CasterName == heat.CasterName)
                            .Where(h => h.StartTime > heat.StartTime)
                            .OrderBy(h => h.StartTime)
                            .FirstOrDefault();

                        if (nextHeat == null)
                        {
                            heat.EndTime = DateTime.Now;
                        }
                        else
                        {
                            heat.EndTime = nextHeat.StartTime.AddMinutes(-2);
                        }
                    }
                    else
                    {
                        // It's the last one so default to now
                        heat.EndTime = DateTime.Now;
                    }
                }
            }
            return heatList;
        }

        public static HeatsPerDayByCasterViewModel GetCasterTotals(DateTime selectedDate, PeriodType periodType)
        {
            var viewModel = new HeatsPerDayByCasterViewModel
            {
                SelectedDate = selectedDate,
                Period = periodType
            };

            var shiftSummaries = new List<ShiftHeatCountSummary>();

            if (periodType == PeriodType.Day)
            {
                viewModel.PeriodStart =
                    new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 7, 0, 0);

                viewModel.PeriodEnd =
                    new DateTime(selectedDate.AddDays(1).Year,
                        selectedDate.AddDays(1).Month,
                        selectedDate.AddDays(1).Day,
                        6, 59, 59);

                // Heats planned at start of the day shift (7:00am plan)
                foreach (CasterTotalsByShiftForDay shiftTotals in
                    EntityHelper.GetDayShiftPlanByCaster.GetByDate(selectedDate))
                {
                    var shiftSummary = new ShiftHeatCountSummary
                    {
                        ShiftDate = selectedDate,
                        Shift = shiftTotals.Shift,
                        ShiftType = ShiftType.Day,
                        CC1PlannedCount = shiftTotals.CC1 ?? 0,
                        CC2PlannedCount = shiftTotals.CC2 ?? 0,
                        CC3PlannedCount = shiftTotals.CC3 ?? 0
                    };

                    // Get the heats actually produced on the day shift.
                    CasterTotalsByShiftForDay dayActuals = EntityHelper
                        .GetCasterTotalsByShiftForDay
                        .GetFirstOrDefaultByDate(selectedDate, "Day");

                    if (dayActuals != null)
                    {
                        shiftSummary.CC1ActualCount = dayActuals.CC1 ?? 0;
                        shiftSummary.CC2ActualCount = dayActuals.CC2 ?? 0;
                        shiftSummary.CC3ActualCount = dayActuals.CC3 ?? 0;
                    }

                    LoadDayShiftPlanDeviations(shiftSummary);
                    shiftSummaries.Add(shiftSummary);
                }

                // Heats planned at start of the night shift (7:00pm plan)
                foreach (CasterTotalsByShiftForDay shiftTotals in
                    EntityHelper.GetNightShiftPlanByCaster.GetByDate(selectedDate))
                {
                    var shiftSummary = new ShiftHeatCountSummary
                    {
                        ShiftDate = selectedDate,
                        Shift = shiftTotals.Shift,
                        ShiftType = ViewModels.ShiftType.Night,
                        CC1PlannedCount = shiftTotals.CC1 ?? 0,
                        CC2PlannedCount = shiftTotals.CC2 ?? 0,
                        CC3PlannedCount = shiftTotals.CC3 ?? 0
                    };

                    // Get the heats actually produced on the night shift.
                    CasterTotalsByShiftForDay nightActuals = EntityHelper
                        .GetCasterTotalsByShiftForDay
                        .GetFirstOrDefaultByDate(selectedDate, "Night");

                    if (nightActuals != null)
                    {
                        shiftSummary.CC1ActualCount = nightActuals.CC1 ?? 0;
                        shiftSummary.CC2ActualCount = nightActuals.CC2 ?? 0;
                        shiftSummary.CC3ActualCount = nightActuals.CC3 ?? 0;
                    }

                    LoadNightShiftPlanDeviations(shiftSummary);
                    shiftSummaries.Add(shiftSummary);
                }
            }
            else
            {
                List<CasterTotalsByShiftForWeek> casterShiftTotals =
                    EntityHelper.GetCasterTotalsByShiftForWeek.GetByDate(selectedDate);

                if (casterShiftTotals != null && 
                    casterShiftTotals.Count > 0)
                {
                    viewModel.PeriodStart = casterShiftTotals.First().ShiftDate;
                    viewModel.PeriodEnd = casterShiftTotals.Last().ShiftDate.AddDays(1);

                    foreach (var shiftTotal in casterShiftTotals)
                    {
                        var shiftSummary = new ShiftHeatCountSummary
                        {
                            ShiftDate = shiftTotal.ShiftDate,
                            Shift = shiftTotal.Shift,
                            CC1ActualCount = shiftTotal.CC1 ?? 0,
                            CC2ActualCount = shiftTotal.CC2 ?? 0,
                            CC3ActualCount = shiftTotal.CC3 ?? 0
                        };

                        if (shiftSummary.Shift == "Day")
                        {
                            shiftSummary.ShiftType = ShiftType.Day;

                            CasterTotalsByShiftForDay dayPlannedHeats =
                                EntityHelper.GetDayShiftPlanByCaster
                                .GetByDateAndShift(shiftTotal.ShiftDate, "Day");

                            if (dayPlannedHeats != null)
                            {
                                shiftSummary.CC1PlannedCount = dayPlannedHeats.CC1 ?? 0;
                                shiftSummary.CC2PlannedCount = dayPlannedHeats.CC2 ?? 0;
                                shiftSummary.CC3PlannedCount = dayPlannedHeats.CC3 ?? 0;
                            }

                            LoadDayShiftPlanDeviations(shiftSummary);
                        }
                        else
                        {
                            shiftSummary.ShiftType = ShiftType.Night;

                            CasterTotalsByShiftForDay nightPlannedHeats =
                                EntityHelper.GetNightShiftPlanByCaster
                                .GetByDateAndShift(shiftTotal.ShiftDate, "Night");

                            if (nightPlannedHeats != null)
                            {
                                shiftSummary.CC1PlannedCount = nightPlannedHeats.CC1 ?? 0;
                                shiftSummary.CC2PlannedCount = nightPlannedHeats.CC2 ?? 0;
                                shiftSummary.CC3PlannedCount = nightPlannedHeats.CC3 ?? 0;
                            }

                            LoadNightShiftPlanDeviations(shiftSummary);
                        }

                        shiftSummaries.Add(shiftSummary);
                    }
                }
            }
            viewModel.ShiftHeatCountSummaries = shiftSummaries;
            return viewModel;
        }

        /// <summary>
        /// Utility function to create a view model with cumulative running counts per shift
        /// from an existing model.
        /// </summary>
        /// <param name="shiftTotalsViewModel">The existing model</param>
        /// <returns>A new model with cumulative totals per shift</returns>
        public static HeatsPerDayByCasterViewModel GetCumulativeHeatsViewModel(
            HeatsPerDayByCasterViewModel shiftTotalsViewModel)
        {
            var viewModel = new HeatsPerDayByCasterViewModel
            {
                SelectedDate = shiftTotalsViewModel.SelectedDate,
                Period = shiftTotalsViewModel.Period,
                PeriodStart = shiftTotalsViewModel.PeriodStart,
                PeriodEnd = shiftTotalsViewModel.PeriodEnd,
                HasCumulativeSummaries = true
            };

            var cumulativeSummaries = new List<ShiftHeatCountSummary>();

            // convert the source view model summaries to a list so they can be accessed more easily.
            var sourceSummaries = shiftTotalsViewModel.ShiftHeatCountSummaries.ToList();

            int counter = 0;
            foreach (ShiftHeatCountSummary shiftHeatCountSummary in shiftTotalsViewModel.ShiftHeatCountSummaries)
            {
                var cumulativeSummary = new ShiftHeatCountSummary
                {
                    ShiftDate = shiftHeatCountSummary.ShiftDate,
                    ShiftType = shiftHeatCountSummary.ShiftType,
                    Shift = shiftHeatCountSummary.Shift
                };

                // Start with the first summary 'as-is' as the basis for the running totals.
                if (shiftHeatCountSummary == shiftTotalsViewModel.ShiftHeatCountSummaries.First())
                {
                    cumulativeSummary = shiftHeatCountSummary;
                }
                else
                {
                    // Add the current source summary value to the corresponding value in the
                    // previous summary line, to create a running total.
                    cumulativeSummary.CC1PlannedCount = shiftHeatCountSummary.CC1PlannedCount +
                        cumulativeSummaries[counter].CC1PlannedCount;

                    cumulativeSummary.CC2PlannedCount = shiftHeatCountSummary.CC2PlannedCount +
                        cumulativeSummaries[counter].CC2PlannedCount;

                    cumulativeSummary.CC3PlannedCount = shiftHeatCountSummary.CC3PlannedCount +
                        cumulativeSummaries[counter].CC3PlannedCount;

                    cumulativeSummary.CC1DeviationsCount = shiftHeatCountSummary.CC1DeviationsCount +
                        cumulativeSummaries[counter].CC1DeviationsCount;

                    cumulativeSummary.CC2DeviationsCount = shiftHeatCountSummary.CC2DeviationsCount +
                        cumulativeSummaries[counter].CC2DeviationsCount;

                    cumulativeSummary.CC3DeviationsCount = shiftHeatCountSummary.CC3DeviationsCount +
                        cumulativeSummaries[counter].CC3DeviationsCount;

                    cumulativeSummary.CC1ActualCount = shiftHeatCountSummary.CC1ActualCount +
                        cumulativeSummaries[counter].CC1ActualCount;

                    cumulativeSummary.CC2ActualCount = shiftHeatCountSummary.CC2ActualCount +
                        cumulativeSummaries[counter].CC2ActualCount;

                    cumulativeSummary.CC3ActualCount = shiftHeatCountSummary.CC3ActualCount +
                        cumulativeSummaries[counter].CC3ActualCount;

                    counter++;
                }
                cumulativeSummaries.Add(cumulativeSummary);
            }

            viewModel.ShiftHeatCountSummaries = cumulativeSummaries;
            return viewModel;
        }

        public static HeatsPerDayByCasterViewModel Get24HourPlan(DateTime selectedDate, PeriodType periodType)
        {
            var viewModel = new HeatsPerDayByCasterViewModel
            {
                SelectedDate = selectedDate,
                Period = periodType,
                HasDailyPlanSummaries = true
            };

            var shiftSummaries = new List<ShiftHeatCountSummary>();

            if (periodType == PeriodType.Day)
            {
                viewModel.PeriodStart =
                    new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 7, 0, 0);

                viewModel.PeriodEnd =
                    new DateTime(selectedDate.AddDays(1).Year,
                        selectedDate.AddDays(1).Month,
                        selectedDate.AddDays(1).Day,
                        6, 59, 59);

                ShiftHeatCountSummary summary = new ShiftHeatCountSummary();
                summary.ShiftDate = selectedDate;
                summary.ShiftType = ShiftType.SevenAMPlan;
                summary.Shift = "7 am plan";

                var plannedHeats = EntityHelper.GetDailyPlannedCasterHeats.GetByDate(selectedDate, 7, 7);
                summary.CC1PlannedCount = plannedHeats.Where(c => c.CasterNumber == 1).Count();
                summary.CC2PlannedCount = plannedHeats.Where(c => c.CasterNumber == 2).Count();
                summary.CC3PlannedCount = plannedHeats.Where(c => c.CasterNumber == 3).Count();

                var actualHeats = EntityHelper.GetDailyActualCasterHeats.GetByDate(selectedDate);
                summary.CC1ActualCount = actualHeats.Where(c => c.CasterNumber == 1).Count();
                summary.CC2ActualCount = actualHeats.Where(c => c.CasterNumber == 2).Count();
                summary.CC3ActualCount = actualHeats.Where(c => c.CasterNumber == 3).Count();

                Load7amPlanDeviations(summary, selectedDate);

                shiftSummaries.Add(summary);
            }
            else
            {
                // Get the date of the Sunday before the selected date for the start of the week.
                DateTime weekStartDate = selectedDate.AddDays((int)selectedDate.DayOfWeek * (-1));

                for (int i = 0; i < 7; i++)
                {
                    DateTime weekDay = weekStartDate.AddDays(i);
                    ShiftHeatCountSummary summary = new ShiftHeatCountSummary();
                    summary.ShiftDate = weekDay;
                    summary.ShiftType = ShiftType.SevenAMPlan;
                    summary.Shift = "7 am plan";

                    var plannedHeats = EntityHelper.GetDailyPlannedCasterHeats.GetByDate(weekDay, 7, 7);
                    summary.CC1PlannedCount = plannedHeats.Where(c => c.CasterNumber == 1).Count();
                    summary.CC2PlannedCount = plannedHeats.Where(c => c.CasterNumber == 2).Count();
                    summary.CC3PlannedCount = plannedHeats.Where(c => c.CasterNumber == 3).Count();

                    var actualHeats = EntityHelper.GetDailyActualCasterHeats.GetByDate(weekDay);
                    summary.CC1ActualCount = actualHeats.Where(c => c.CasterNumber == 1).Count();
                    summary.CC2ActualCount = actualHeats.Where(c => c.CasterNumber == 2).Count();
                    summary.CC3ActualCount = actualHeats.Where(c => c.CasterNumber == 3).Count();

                    Load7amPlanDeviations(summary, weekDay);

                    shiftSummaries.Add(summary);
                }

                viewModel.PeriodStart =
                    new DateTime(weekStartDate.Year, weekStartDate.Month, weekStartDate.Day, 7, 0, 0);

                viewModel.PeriodEnd =
                    new DateTime(weekStartDate.AddDays(7).Year,
                        weekStartDate.AddDays(7).Month,
                        weekStartDate.AddDays(7).Day,
                        6, 59, 59);
            }
            viewModel.ShiftHeatCountSummaries = shiftSummaries;
            return viewModel;
        }

        private static void Load7amPlanDeviations(ShiftHeatCountSummary shiftSummary, DateTime selectedDate)
        {
            List<ProductionEvent> plannedHeats = GetPlanCasterSchedule(selectedDate, 7).ToList();
            List<ProductionEvent> actualHeats = GetActualCasterProduction(selectedDate, 7).ToList();

            foreach (ProductionEvent productionEvent in actualHeats)
            {
                bool isDeviation = false;

                ProductionEvent plannedEvent = plannedHeats.Find(h => h.HeatNumber == productionEvent.HeatNumber);
                if (plannedEvent != null)
                {
                    bool casterNameMatch = productionEvent.CasterName == plannedEvent.CasterName;
                    bool gradeMatch = productionEvent.Grade == plannedEvent.Grade;
                    bool programMatch = productionEvent.ProgramNumber == plannedEvent.ProgramNumber;

                    if (!casterNameMatch || !gradeMatch || !programMatch)
                    {
                        isDeviation = true;
                    }
                }
                else
                {
                    isDeviation = true;
                }

                if (isDeviation)
                {
                    switch (productionEvent.UnitId)
                    {
                        case 11:
                            shiftSummary.CC1DeviationsCount++;
                            break;
                        case 12:
                            shiftSummary.CC2DeviationsCount++;
                            break;
                        case 13:
                            shiftSummary.CC3DeviationsCount++;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void LoadDayShiftPlanDeviations(ShiftHeatCountSummary shiftSummary)
        {
            using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                //Get the list of heats planned as at 7:00am on the date of the shift summary.
                List<ShiftStartHeatPlanItem> plannedHeats = EntityHelper
                    .GetDayShiftPlan.GetByDate(shiftSummary.ShiftDate);

                //Get the actual heats for the day shift
                var heats = from t in ctx.Trackings
                            join p in ctx.LastProgramNumbers on t.HeatNumber equals p.HeatNumber into ps
                            from p in ps.DefaultIfEmpty()
                            where t.TimeStampStart != null
                            where t.UnitNumber >= 11 && t.UnitNumber <= 13
                            where (DbFunctions.TruncateTime(t.TimeStampStart) ==
                                       DbFunctions.TruncateTime(shiftSummary.ShiftDate) &&
                                   t.TimeStampStart.Hour >= 7 &&
                                   t.TimeStampStart.Hour < 19)
                            select new
                            {
                                HeatNumber = t.HeatNumber,
                                Grade1 = p.TargetGrade ?? 0,
                                ProgramNumber = p.ProgramNumber ?? 0,
                                CasterNumber = t.UnitNumber,
                                UnitNumber = t.UnitNumber
                            };

                foreach (var plannedHeat in plannedHeats)
                {
                    bool hasDeviation = false;
                    var actualHeat = heats.FirstOrDefault(h => h.HeatNumber == plannedHeat.HeatNumber);

                    if (actualHeat == null)
                    {
                        // Not found so not made.
                        hasDeviation = true;
                    }
                    else
                    {
                        if (plannedHeat.ProgramNumber != actualHeat.ProgramNumber ||
                            plannedHeat.Grade != actualHeat.Grade1 ||
                            plannedHeat.CasterNumber != (actualHeat.CasterNumber - 10))
                        {
                            hasDeviation = true;
                        }
                    }

                    if (hasDeviation)
                    {
                        switch (plannedHeat.CasterNumber)
                        {
                            case 1:
                                shiftSummary.CC1DeviationsCount++;
                                break;
                            case 2:
                                shiftSummary.CC2DeviationsCount++;
                                break;
                            case 3:
                                shiftSummary.CC3DeviationsCount++;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private static void LoadNightShiftPlanDeviations(ShiftHeatCountSummary shiftSummary)
        {
            using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                // Get the list of heats planned as at 7:00am on the date of the shift summary.
                List<ShiftStartHeatPlanItem> plannedHeats = EntityHelper
                    .GetNightShiftPlan
                    .GetByDate(shiftSummary.ShiftDate);
                DateTime endDate = shiftSummary.ShiftDate.AddDays(1);

                // Get the actual heats for the Night shift
                var heats = from t in ctx.Trackings
                            join p in ctx.LastProgramNumbers on t.HeatNumber equals p.HeatNumber into ps
                            from p in ps.DefaultIfEmpty()
                            where t.TimeStampStart != null
                            where t.UnitNumber >= 11 && t.UnitNumber <= 13
                            where (DbFunctions.TruncateTime(t.TimeStampStart) ==
                                       DbFunctions.TruncateTime(shiftSummary.ShiftDate) &&
                                            t.TimeStampStart.Hour >= 19) ||
                                  (DbFunctions.TruncateTime(t.TimeStampStart) ==
                                       DbFunctions.TruncateTime(endDate) &&
                                            t.TimeStampStart.Hour < 7)
                            select new
                            {
                                HeatNumber = t.HeatNumber,
                                Grade1 = p.TargetGrade ?? 0,
                                ProgramNumber = p.ProgramNumber ?? 0,
                                CasterNumber = t.UnitNumber,
                                UnitNumber = t.UnitNumber
                            };

                foreach (var plannedHeat in plannedHeats)
                {
                    bool hasDeviation = false;
                    var actualHeat = heats.FirstOrDefault(h => h.HeatNumber == plannedHeat.HeatNumber);

                    if (actualHeat == null)
                    {
                        // Not found so not made.
                        hasDeviation = true;
                    }
                    else
                    {
                        if (plannedHeat.ProgramNumber != actualHeat.ProgramNumber ||
                            plannedHeat.Grade != actualHeat.Grade1 ||
                            plannedHeat.CasterNumber != (actualHeat.CasterNumber - 10))
                        {
                            hasDeviation = true;
                        }
                    }

                    if (hasDeviation)
                    {
                        switch (plannedHeat.CasterNumber)
                        {
                            case 1:
                                shiftSummary.CC1DeviationsCount++;
                                break;
                            case 2:
                                shiftSummary.CC2DeviationsCount++;
                                break;
                            case 3:
                                shiftSummary.CC3DeviationsCount++;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the planned heats for day or night shift on the given date. The plan comes from the 7:00am or
        /// 7:00pm grab.
        /// </summary>
        /// <param name="shiftDate">The date of the shift</param>
        /// <param name="shiftType">The type of shift (day or night)</param>
        /// <returns>A collection of planned heats</returns>
        public static List<HeatSummaryViewItem> GetPlannedHeatsForShift(DateTime shiftDate, ShiftType shiftType)
        {
            using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                List<ShiftStartHeatPlanItem> plannedHeats = null;

                // Get the planned heats for the day or night shift
                switch (shiftType)
                {
                    case ShiftType.Day:
                        //plannedHeats = GetDayShiftPlan(shiftDate, ctx);
                        plannedHeats = EntityHelper.GetDayShiftPlan.GetByDate(shiftDate);
                        break;
                    case ShiftType.Night:
                        //plannedHeats = GetNightShiftPlan(shiftDate, ctx);
                        plannedHeats = EntityHelper.GetNightShiftPlan.GetByDate(shiftDate);
                        break;
                    default:
                        break;
                }

                var heatSummaryViewItems = new List<HeatSummaryViewItem>();

                // Convert to the return type.
                if (plannedHeats != null)
                {
                    plannedHeats.ForEach(x =>
                        {
                            heatSummaryViewItems.Add(new HeatSummaryViewItem
                            {
                                CasterName = String.Format("CC{0}", x.CasterNumber),
                                CombinedWidth = x.CombinedWidth ?? 0,
                                Duration = x.Duration ?? 0,
                                Grade = x.Grade ?? 0,
                                HeatNumber = x.HeatNumber,
                                ProgramNumber = x.ProgramNumber ?? 0,
                                StartTime = (DateTime)x.PlannedStartCastTime,
                                SummaryType = HeatSummaryViewItem.HeatSummaryType.Planned
                            });
                        });
                }

                return heatSummaryViewItems;
            }
        }

        /// <summary>
        /// Gets the actual heats for day or night shift on the given date. The plan comes from the 7:00am or
        /// 7:00pm grab.
        /// </summary>
        /// <param name="shiftDate">The date of the shift</param>
        /// <param name="shiftType">The type of shift (day or night)</param>
        /// <returns>A collection of planned heats</returns>
        public static List<HeatSummaryViewItem> GetActualHeatsForShift(DateTime shiftDate, ShiftType shiftType)
        {
            using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                var heatSummaryViewItems = new List<HeatSummaryViewItem>();

                if (shiftType == ShiftType.Day)
                {
                    // Get the actual heats for the day shift
                    var heats = from t in ctx.Trackings
                                join p in ctx.LastProgramNumbers on t.HeatNumber equals p.HeatNumber into ps
                                from p in ps.DefaultIfEmpty()
                                where t.TimeStampStart != null
                                where t.UnitNumber >= 11 && t.UnitNumber <= 13
                                where (DbFunctions.TruncateTime(t.TimeStampStart) ==
                                           DbFunctions.TruncateTime(shiftDate) &&
                                       t.TimeStampStart.Hour >= 7 &&
                                       t.TimeStampStart.Hour < 19)
                                select new
                                {
                                    HeatNumber = t.HeatNumber,
                                    Grade1 = p.TargetGrade ?? 0,
                                    ProgramNumber = p.ProgramNumber ?? 0,
                                    CasterNumber = t.UnitNumber,
                                    UnitNumber = t.UnitNumber,
                                    ActualStartDate = t.TimeStampStart,
                                    ActualEndDate = t.TimeStampEnd
                                };

                    // Convert to the return type here as heats is an anonymous type.
                    if (heats != null && heats.Count() > 0)
                    {
                        foreach (var heat in heats)
                        {
                            var summary = new HeatSummaryViewItem
                            {
                                HeatNumber = heat.HeatNumber,
                                Grade = heat.Grade1,
                                ProgramNumber = heat.ProgramNumber,
                                CasterName = String.Format("CC{0}", heat.CasterNumber - 10),
                                StartTime = (DateTime)heat.ActualStartDate,
                                CombinedWidth = 0,
                                SummaryType = HeatSummaryViewItem.HeatSummaryType.Actual
                            };

                            if (heat.ActualEndDate.HasValue)
                            {
                                TimeSpan duration = heat.ActualEndDate.Value - heat.ActualStartDate;
                                summary.Duration = (int)duration.TotalMinutes;
                            }

                            heatSummaryViewItems.Add(summary);
                        }
                    }
                }
                else if (shiftType == ShiftType.Night)
                {
                    DateTime endDate = shiftDate.AddDays(1);

                    // Get the actual heats for the Night shift
                    var heats = from t in ctx.Trackings
                                join p in ctx.LastProgramNumbers on t.HeatNumber equals p.HeatNumber into ps
                                from p in ps.DefaultIfEmpty()
                                where t.TimeStampStart != null
                                where t.UnitNumber >= 11 && t.UnitNumber <= 13
                                where (DbFunctions.TruncateTime(t.TimeStampStart) ==
                                           DbFunctions.TruncateTime(shiftDate) &&
                                                t.TimeStampStart.Hour >= 19) ||
                                      (DbFunctions.TruncateTime(t.TimeStampStart) ==
                                           DbFunctions.TruncateTime(endDate) &&
                                                t.TimeStampStart.Hour < 7)
                                select new
                                {
                                    HeatNumber = t.HeatNumber,
                                    Grade1 = p.TargetGrade ?? 0,
                                    ProgramNumber = p.ProgramNumber ?? 0,
                                    CasterNumber = t.UnitNumber,
                                    UnitNumber = t.UnitNumber,
                                    ActualStartDate = t.TimeStampStart,
                                    ActualEndDate = t.TimeStampEnd,
                                };

                    // Convert to the return type here as heats is an anonymous type.
                    if (heats != null && heats.Count() > 0)
                    {
                        foreach (var heat in heats)
                        {
                            var summary = new HeatSummaryViewItem
                            {
                                HeatNumber = heat.HeatNumber,
                                Grade = heat.Grade1,
                                ProgramNumber = heat.ProgramNumber,
                                CasterName = String.Format("CC{0}", heat.CasterNumber - 10),
                                StartTime = (DateTime)heat.ActualStartDate,
                                CombinedWidth = 0,
                                Duration = 0,
                                SummaryType = HeatSummaryViewItem.HeatSummaryType.Actual
                            };

                            if (heat.ActualEndDate.HasValue)
                            {
                                TimeSpan duration = heat.ActualEndDate.Value - heat.ActualStartDate;
                                summary.Duration = (int)duration.TotalMinutes;
                            }

                            heatSummaryViewItems.Add(summary);
                        }
                    }
                }

                return heatSummaryViewItems;
            }
        }

        /// <summary>
        /// Gets the planned heats for 24 hours from the 07:00am plan.
        /// </summary>
        /// <param name="productionDate">The date of the plan</param>
        /// <returns>A collection of planned heats</returns>
        public static List<HeatSummaryViewItem> GetPlannedHeatsFor24Hours(DateTime productionDate)
        {
            using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                var heatSummaryViewItems = new List<HeatSummaryViewItem>();
                DateTime endDate = productionDate.AddDays(1);

                var heats = from c in ctx.CoordFixes
                            where c.PLANNED_START_CAST_TIME.HasValue
                            where (DbFunctions.TruncateTime(c.FixDate) ==
                                    DbFunctions.TruncateTime(productionDate) &&
                                    c.FixDate.Hour == 7)
                            where ((DbFunctions.TruncateTime(c.PLANNED_START_CAST_TIME) ==
                                        DbFunctions.TruncateTime(productionDate) &&
                                        c.PLANNED_START_CAST_TIME.Value.Hour >= 7) ||
                                  (DbFunctions.TruncateTime(c.PLANNED_START_CAST_TIME) ==
                                        DbFunctions.TruncateTime(endDate) &&
                                        c.PLANNED_START_CAST_TIME.Value.Hour < 7))
                            orderby c.PLANNED_START_CAST_TIME.Value
                            select new
                            {
                                HeatNumber = c.HEAT_NUMBER,
                                Grade = c.GRADE_1,
                                ProgramNumber = c.PROGRAM_NUMBER,
                                CasterNumber = c.CASTER_NUMBER,
                                CombinedWidth = c.COMBINED_WIDTH,
                                Duration = c.CAST_DURATION,
                                StartTime = c.PLANNED_START_CAST_TIME
                            };

                // Convert the anonymous type to the concrete return type.
                foreach (var heat in heats)
                {
                    heatSummaryViewItems.Add(new HeatSummaryViewItem
                    {
                        CasterName = String.Format("CC{0}", heat.CasterNumber),
                        CombinedWidth = heat.CombinedWidth ?? 0,
                        Duration = heat.Duration ?? 0,
                        Grade = heat.Grade ?? 0,
                        HeatNumber = heat.HeatNumber,
                        ProgramNumber = heat.ProgramNumber ?? 0,
                        StartTime = (DateTime)heat.StartTime,
                        SummaryType = HeatSummaryViewItem.HeatSummaryType.Planned
                    });
                }

                return heatSummaryViewItems;
            }
        }

        /// <summary>
        /// Gets the actual heats produced for 24 hours from 07:00am.
        /// </summary>
        /// <param name="productionDate">The date of production</param>
        /// <returns>A collection of actual heats</returns>
        public static List<HeatSummaryViewItem> GetActualHeatsFor24Hours(DateTime productionDate)
        {
            using (EventSchemaEntities ctx = new EventSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
            {
                var heatSummaryViewItems = new List<HeatSummaryViewItem>();
                DateTime endDate = productionDate.AddDays(1);

                // Get the actual heats produced
                var heats = from t in ctx.Trackings
                            join p in ctx.LastProgramNumbers on t.HeatNumber equals p.HeatNumber into ps
                            from p in ps.DefaultIfEmpty()
                            where t.TimeStampStart != null
                            where t.UnitNumber >= 11 && t.UnitNumber <= 13
                            where (DbFunctions.TruncateTime(t.TimeStampStart) ==
                                       DbFunctions.TruncateTime(productionDate) &&
                                            t.TimeStampStart.Hour >= 7) ||
                                  (DbFunctions.TruncateTime(t.TimeStampStart) ==
                                       DbFunctions.TruncateTime(endDate) &&
                                            t.TimeStampStart.Hour < 7)
                            select new
                            {
                                HeatNumber = t.HeatNumber,
                                Grade1 = p.TargetGrade ?? 0,
                                ProgramNumber = p.ProgramNumber ?? 0,
                                CasterNumber = t.UnitNumber,
                                UnitNumber = t.UnitNumber,
                                ActualStartDate = t.TimeStampStart,
                                ActualEndDate = t.TimeStampEnd,
                            };

                // Convert to the return type here as heats is an anonymous type.
                if (heats != null && heats.Count() > 0)
                {
                    foreach (var heat in heats)
                    {
                        var summary = new HeatSummaryViewItem
                        {
                            HeatNumber = heat.HeatNumber,
                            Grade = heat.Grade1,
                            ProgramNumber = heat.ProgramNumber,
                            CasterName = String.Format("CC{0}", heat.CasterNumber - 10),
                            StartTime = (DateTime)heat.ActualStartDate,
                            CombinedWidth = 0,
                            Duration = 0,
                            SummaryType = HeatSummaryViewItem.HeatSummaryType.Actual
                        };

                        if (heat.ActualEndDate.HasValue)
                        {
                            TimeSpan duration = heat.ActualEndDate.Value - heat.ActualStartDate;
                            summary.Duration = (int)duration.TotalMinutes;
                        }

                        heatSummaryViewItems.Add(summary);
                    }
                }

                return heatSummaryViewItems;
            }
        }


        /// <summary>
        /// Compares a set of planned heats against a set of actual heats by Heat Number,
        /// and sets boolean flags in the <c>HeatSummaryViewItem</c> classes in the collections to
        /// indicate deviations.
        /// </summary>
        /// <remarks>Deviations include variances in Caster Number, Program Number and Grade,
        /// along with whether a Heat has been planned but not made, or made but not planned.</remarks>        
        /// <param name="plannedHeats">Collection of planned heats</param>
        /// <param name="actualHeats">Collection of actual heats</param>
        public static void ConfigureHeatDeviations(List<HeatSummaryViewItem> plannedHeats,
            List<HeatSummaryViewItem> actualHeats)
        {
            // Iterate through the planned heats, looking for deviations from plan in the actual heats
            foreach (var plannedHeat in plannedHeats)
            {
                HeatSummaryViewItem actualHeat =
                    actualHeats.FirstOrDefault(h => h.HeatNumber == plannedHeat.HeatNumber);

                if (actualHeat == null)
                {
                    plannedHeat.HasPlannedNotMadeDeviation = true;
                }
                else
                {
                    plannedHeat.HasProgramNumberDeviation = plannedHeat.ProgramNumber != actualHeat.ProgramNumber;
                    plannedHeat.HasGradeDeviation = plannedHeat.Grade != actualHeat.Grade;
                    plannedHeat.HasCasterNameDeviation = plannedHeat.CasterName != actualHeat.CasterName;
                }
            }

            // Iterate through the actual heats, looking for any that weren't planned.
            foreach (var actualHeat in actualHeats)
            {
                HeatSummaryViewItem plannedHeat =
                    plannedHeats.FirstOrDefault(h => h.HeatNumber == actualHeat.HeatNumber);

                if (plannedHeat == null)
                {
                    actualHeat.HasMadeNotPlannedDeviation = true;
                }
                else
                {
                    actualHeat.HasProgramNumberDeviation = actualHeat.ProgramNumber != plannedHeat.ProgramNumber;
                    actualHeat.HasGradeDeviation = actualHeat.Grade != plannedHeat.Grade;
                    actualHeat.HasCasterNameDeviation = actualHeat.CasterName != plannedHeat.CasterName;
                }
            }
        }

        /// <summary>
        /// Gets a view model containing data on the Steel in Mould and Speed Ratio
        /// for the 3 casters for a given day or week.
        /// </summary>
        /// <param name="selectedDate">The date required</param>
        /// <param name="periodType">The day or week period</param>
        /// <returns>A single populated view model</returns>
        public static SteelInMouldViewModel GetSteelInMouldViewModel(DateTime selectedDate, PeriodType periodType)
        {
            var viewModel = new SteelInMouldViewModel();

            viewModel.SelectedDate = selectedDate;
            viewModel.Period = periodType;

            if (periodType == PeriodType.Day)
            {
                DateTime dt = selectedDate.AddDays(1);
                viewModel.PeriodStart = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 7, 0, 0);
                viewModel.PeriodEnd = new DateTime(dt.Year, dt.Month, dt.Day, 7, 0, 0);

                CasterSum casterSum = EntityHelper.CasterSum.GetCasterSumForDay(selectedDate);
                if (casterSum != null)
                {
                    viewModel.Items.Add(new SteelInMouldSpeedRatioItem
                    {
                        SumDate = casterSum.SumDate,
                        CC1SteelInMould = casterSum.CC1SteelInMould,
                        CC2SteelInMould = casterSum.CC2SteelInMould,
                        CC3SteelInMould = casterSum.CC3SteelInMould,
                        CC1SpeedRatio = casterSum.CC1SpeedRatio,
                        CC2SpeedRatio = casterSum.CC2SpeedRatio,
                        CC3SpeedRatio = casterSum.CC3SpeedRatio
                    });
                }
            }
            else
            {
                DateTime dt = selectedDate.StartOfWeek(DayOfWeek.Sunday);
                viewModel.PeriodStart = new DateTime(dt.Year, dt.Month, dt.Day, 7, 0, 0);
                //viewModel.PeriodEnd = selectedDate.StartOfWeek(DayOfWeek.Sunday).AddDays(6).AddHours(23).AddMinutes(59);
                viewModel.PeriodEnd = viewModel.PeriodStart.AddDays(7);

                List<CasterSum> casterSums = EntityHelper.CasterSum.GetCasterSumsForWeek(selectedDate);
                if (casterSums != null && casterSums.Count > 0)
                {
                    foreach (var casterSum in casterSums)
                    {
                        viewModel.Items.Add(new SteelInMouldSpeedRatioItem
                        {
                            SumDate = casterSum.SumDate,
                            CC1SteelInMould = casterSum.CC1SteelInMould,
                            CC2SteelInMould = casterSum.CC2SteelInMould,
                            CC3SteelInMould = casterSum.CC3SteelInMould,
                            CC1SpeedRatio = casterSum.CC1SpeedRatio,
                            CC2SpeedRatio = casterSum.CC2SpeedRatio,
                            CC3SpeedRatio = casterSum.CC3SpeedRatio
                        });
                    }
                }
            }

            return viewModel;
        }
    }
}
