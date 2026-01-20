using System;
using System.Collections.Generic;
using System.Linq;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region RFTData Table Functions

        public static class RFTData
        {
            /// <summary>
            /// Get the RFTData from the database by date.
            /// </summary>
            /// <param name="date">The Date to search for.</param>
            /// <returns>An RFTData object.</returns>
            public static EDMX.RFTData GetByDate(DateTime date)
            {
                using (OasisSchemaEntities ctx = new OasisSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);//Ignore any time values
                    DateTime dateTo = date.AddDays(1);
                    return ctx.RFTDatas.FirstOrDefault(r =>
                                r.RFTDate >= date &&
                                r.RFTDate < dateTo);
                }
            }
        }

        #endregion RFTData Table Functions

        #region SlabStocks Table Functions

        public static class SlabStocks
        {
            /// <summary>
            /// Get the SlabStocks from the database by date.
            /// </summary>
            /// <param name="date">The Date to search for.</param>
            /// <returns>A SlabStock object.</returns>
            public static List<EDMX.SlabStock> GetByDate(DateTime date)
            {
                using (OasisSchemaEntities ctx = new OasisSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);//Ignore any time values
                    DateTime dateTo = date.AddDays(1);

                    return ctx.SlabStocks
                        .Where(r =>
                            r.SSDate >= date &&
                            r.SSDate < dateTo)
                        .ToList();
                }
            }
        }

        #endregion SlabStocks Table Functions

        #region Hot Connect Table Functions

        public static class HotConnects
        {
            /// <summary>
            /// Gets Hot Connect Data for the last X days.
            /// </summary>
            /// <returns>List of HotConnect Objects.</returns>
            public static List<ElvisDataModel.EDMX.HotConnect> GetLastXDays(int xDays)
            {
                using (OasisSchemaEntities ctx = new OasisSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    DateTime dtXDaysAgo = DateTime.Now.AddDays(-xDays);
                    return ctx.HotConnects
                        .Where(p => p.LastUpdate >= dtXDaysAgo)
                        .OrderByDescending(o => o.LastUpdate)
                        .ToList();
                }
            }
        }
        #endregion
    }
}