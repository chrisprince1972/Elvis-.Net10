using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Core.Objects;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region Configurable Parameters SP Functions
        public static class GetSetConfigurableParameters
        {
            /// <summary>
            /// STORED PROCEDURE - GetParameter -
            /// Gets a configurable parameter by index number.
            /// </summary>
            /// <param name="paramIndexNumber">The index number of the parameter to retrieve.</param>
            /// <returns>The parameter as a string.</returns>
            public static string GetParameter(int paramIndexNumber)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetParameter(paramIndexNumber).SingleOrDefault();
                }
            }

            /// <summary>
            /// STORED PROCEDURE - GetParameter -
            /// Updates a configurable parameter by index number.
            /// </summary>
            /// <param name="paramIndexNumber">The index number of the parameter to update.</param>
            /// <param name="paramValue">The value of the parameter to update.</param>
            public static void SetParameter(int paramIndexNumber, string paramValue)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    ctx.SetParameter(paramIndexNumber, paramValue);
                }
            }
        }
        #endregion

        #region DateInfo SP Functions
        public static class DateInfo
        {
            /// <summary>
            /// Gets the Rota by a Specific Date
            /// </summary>
            /// <param name="dt">The Date Time you wish to find out the Rota for.</param>
            /// <returns>The Rota as a string e.g. 'A'</returns>
            public static string GetRotaByDate(DateTime dt)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.CreateQuery<string>(
                        "SELECT VALUE ElvisDBModel.Store.GetRota(@dt) FROM {1}",
                        new ObjectParameter("dt", dt)
                    ).First();
                }
            }
        }
        #endregion

        #region GetCasterTotalsByShiftForDay SP Functions
        public static class GetCasterTotalsByShiftForDay
        {
            /// <summary>
            /// STORED PROCEDURE - GetCasterTotalsByShiftForDay - 
            /// Get the heats actually produced on the day/night shift.
            /// </summary>
            /// <param name="selectedDate">The Date you wish to filter on.</param>
            /// <param name="shift">'Day' or 'Night'</param>
            /// <returns>A CasterTotalsByShiftForDay item.</returns>
            public static CasterTotalsByShiftForDay GetFirstOrDefaultByDate(DateTime selectedDate, string shift)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetCasterTotalsByShiftForDay(selectedDate)
                        .FirstOrDefault(c => c.Shift == shift);
                }
            }
        }
        #endregion

        #region GetCasterTotalsByShiftForWeek SP Functions
        public static class GetCasterTotalsByShiftForWeek
        {
            /// <summary>
            /// STORED PROCEDURE - GetCasterTotalsByShiftForWeek - 
            /// Get the heats actually produced for the week.
            /// </summary>
            /// <param name="selectedDate">The Date you wish to filter on.</param>
            /// <returns>A List of CasterTotalsByShiftForWeek items.</returns>
            public static List<CasterTotalsByShiftForWeek> GetByDate(DateTime selectedDate)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetCasterTotalsByShiftForWeek(selectedDate)
                        .ToList();
                }
            }
        }
        #endregion

        #region GetDailyActualCasterHeats SP Functions
        public static class GetDailyActualCasterHeats
        {
            /// <summary>
            /// STORED PROCEDURE - GetDailyActualCasterHeats - 
            /// Gets the actual Caster heats produced on the given day.
            /// </summary>
            /// <param name="productionDate">The Date you wish to filter on.</param>
            /// <returns>A list of caster production items.</returns>
            public static List<CastersProductionItem> GetByDate(DateTime productionDate)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetDailyActualCasterHeats(productionDate).ToList();
                }
            }
        }
        #endregion

        #region GetDailyActualCasterHeats7AM SP Functions
        public static class GetDailyActualCasterHeats7AM
        {
            /// <summary>
            /// STORED PROCEDURE - GetDailyActualCasterHeats7AM - 
            /// Gets the actual Caster heats produced on the given day.
            /// </summary>
            /// <param name="productionDate">The Date you wish to filter on.</param>
            /// <returns>A list of caster production items.</returns>
            public static List<CastersProductionItem> GetByDate(DateTime productionDate)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetDailyActualCasterHeats7AM(productionDate).ToList();
                }
            }
        }
        #endregion

        #region GetDailyPlannedCasterHeats SP Functions
        public static class GetDailyPlannedCasterHeats
        {
            /// <summary>
            /// STORED PROCEDURE - GetDailyPlannedCasterHeats - 
            /// Gets the planned schedule for the given day, fixed at 10:00am.
            /// Used for Hot Metal Buffer predictions.
            /// </summary>
            /// <param name="scheduleDate">The schedule date</param>
            /// <param name="startHour">The starting hour for the plan (0 - 23)</param>
            /// <param name="planHour">The fixed plan hour, must be either 10
            /// for the 10am plan or 22 for the 10pm plan</param>
            /// <returns>A collection of scheduled heats.</returns>
            public static List<CastersScheduleItem> GetByDate(DateTime scheduleDate, int startHour, int planHour)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetDailyPlannedCasterHeats(scheduleDate, startHour, planHour).ToList();
                }
            }
        }
        #endregion

        #region GetDayShiftPlan SP Functions
        public static class GetDayShiftPlan
        {
            /// <summary>
            /// STORED PROCEDURE - GetDayShiftPlan - 
            /// Gets the Day Shift Plan on the given day.
            /// Gets the list of heats planned as at 7:00am on the date of the shift summary.
            /// </summary>
            /// <param name="selectedDate">The Date you wish to filter on.</param>
            /// <returns>A list of ShiftStartHeatPlanItem.</returns>
            public static List<ShiftStartHeatPlanItem> GetByDate(DateTime selectedDate)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetDayShiftPlan(selectedDate).ToList();
                }
            }
        }
        #endregion

        #region GetDayShiftPlanByCaster SP Functions
        public static class GetDayShiftPlanByCaster
        {
            /// <summary>
            /// STORED PROCEDURE - GetDayShiftPlanByCaster - 
            /// Gets the Day Shift Plan By Caster on the given day.
            /// </summary>
            /// <param name="selectedDate">The Date you wish to filter on.</param>
            /// <returns>A list of CasterTotalsByShiftForDay.</returns>
            public static List<CasterTotalsByShiftForDay> GetByDate(DateTime selectedDate)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetDayShiftPlanByCaster(selectedDate).ToList();
                }
            }

            /// <summary>
            /// STORED PROCEDURE - GetDayShiftPlanByCaster - 
            /// Gets the Day Shift Plan By Caster on the given day, 
            /// specifically for a day/night shift.
            /// </summary>
            /// <param name="selectedDate">The Date you wish to filter on.</param>
            /// <param name="shift">'Day' or 'Night'</param>
            /// <returns>A CasterTotalsByShiftForDay object.</returns>
            public static CasterTotalsByShiftForDay GetByDateAndShift(DateTime selectedDate, string shift)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetDayShiftPlanByCaster(selectedDate)
                        .FirstOrDefault(s => s.Shift == shift);
                }
            }
        }
        #endregion

        #region GetNightShiftPlanByCaster SP Functions
        public static class GetNightShiftPlanByCaster
        {
            /// <summary>
            /// STORED PROCEDURE - GetNightShiftPlanByCaster - 
            /// Get the night shift plan by caster.
            /// </summary>
            /// <param name="selectedDate">The Date you wish to filter on.</param>
            /// <returns>A CasterTotalsByShiftForDay item.</returns>
            public static List<CasterTotalsByShiftForDay> GetByDate(DateTime selectedDate)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetNightShiftPlanByCaster(selectedDate)
                        .ToList(); 
                }
            }

            /// <summary>
            /// STORED PROCEDURE - GetNightShiftPlanByCaster - 
            /// Get the night shift plan by caster,
            /// specifically for a night shift.
            /// </summary>
            /// <param name="selectedDate">The Date you wish to filter on.</param>
            /// <param name="shift">'Day' or 'Night'</param>
            /// <returns>A CasterTotalsByShiftForDay object.</returns>
            public static CasterTotalsByShiftForDay GetByDateAndShift(DateTime selectedDate, string shift)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetNightShiftPlanByCaster(selectedDate)
                        .FirstOrDefault(s => s.Shift == shift);
                }
            }
        }
        #endregion

        #region GetNightShiftPlan SP Functions
        public static class GetNightShiftPlan
        {
            /// <summary>
            /// STORED PROCEDURE - GetNightShiftPlan - 
            /// Gets the Night Shift Plan on the given day.
            /// Get the planned heats for the night shift as at 7:00pm
            /// </summary>
            /// <param name="selectedDate">The Date you wish to filter on.</param>
            /// <returns>A list of ShiftStartHeatPlanItem.</returns>
            public static List<ShiftStartHeatPlanItem> GetByDate(DateTime selectedDate)
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetNightShiftPlan(selectedDate).ToList();
                }
            }
        }
        #endregion

        #region GetTodayDate SP Functions
        public static class GetTodayDate
        {
            /// <summary>
            /// STORED PROCEDURE - GetTodayDate - 
            /// Contains lots of info about the current day.
            /// </summary>
            /// <returns>A TodayDate object.</returns>
            public static TodayDate GetSingle()
            {
                using (ElvisDBEntities ctx = new ElvisDBEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GetTodayDate().FirstOrDefault();
                }
            }
        }
        #endregion
    }
}
