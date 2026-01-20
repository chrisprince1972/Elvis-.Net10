using System;
using System.Collections.Generic;
using System.Linq;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region HMPour Table Functions
        public static class HMPour
        {
            /// <summary>
            /// Gets HM Pour data for the last X days.
            /// </summary>
            /// <returns>List of HMPour Objects.</returns>
            public static List<EDMX.HMPour> GetLastXDays(int xDays)
            {
                using (UnitSchemaEntities ctx = new UnitSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.HMPours
                        .Where(p => p.TimeCreated >= dtXDaysAgo)
                        .ToList();
                }
            }
        }
        #endregion

        #region HMDesulphResult Table Functions
        public static class HMDesulphResult
        {
            /// <summary>
            /// Gets desulph reports.
            /// </summary>
            /// <returns>List of HMPour Objects.</returns>
            public static List<EDMX.HMDesulphReport> GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (UnitSchemaEntities ctx = new UnitSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.HMDesulphReports
                        .Where(r => 
                            r.HNS == heatNumberSet && 
                            r.HeatNumber == heatNumber)
                        .ToList();
                }
            }
        }
        #endregion

        #region Vessel Table Functions
        public static class Vessel
        {
            /// <summary>
            /// Gets Vessels.
            /// </summary>
            /// <returns>Vessel Object or null.</returns>
            public static EDMX.Vessel GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (UnitSchemaEntities ctx = new UnitSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Vessels.FirstOrDefault(r => 
                        r.HNS == heatNumberSet && 
                        r.HeatNumber == heatNumber
                        );
                }
            }

            /// <summary>
            /// Get a list of vessels that started tap between the date range provided.
            /// </summary>
            /// <param name="from">Start of the date range.</param>
            /// <param name="to">End of the date range.</param>
            /// <returns>List of Vessels.</returns>
            public static List<EDMX.Vessel> GetRangeByStartTapTime(DateTime from, DateTime to)
            {
                using (UnitSchemaEntities ctx = new UnitSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx
                        .Vessels
                        .Where
                        (
                            r => r.StartTapTime >= from
                                && r.StartTapTime < to
                        )
                        .ToList();
                }
            }
        }
        #endregion
    }
}
