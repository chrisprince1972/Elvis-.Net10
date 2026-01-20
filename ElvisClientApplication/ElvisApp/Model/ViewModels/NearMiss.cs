using System;
using System.Collections.Generic;
using System.Linq;
using Elvis.Forms.Reports.NearMiss;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Model
{
    public static class NearMiss
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the nearmiss records within the given date span.
        /// </summary>
        /// <param name="dateFrom">The Date From.</param>
        /// <param name="dateTo">The Date To.</param>
        /// <returns>A list of NearMissRecord objects, which contains all the data
        /// with regards to a nearmiss.</returns>
        public static List<Elvis.Forms.Reports.NearMiss.NearMissRecord> GetNearMiss(DateTime dateFrom, DateTime dateTo, string filter)
        {
            List<Elvis.Forms.Reports.NearMiss.NearMissRecord> listNearMiss = new List<Elvis.Forms.Reports.NearMiss.NearMissRecord>();
            try
            {
                List<ElvisDataModel.EDMX.SAS_NM_DataWithDateAndTimeJoinedForElvis> listSafteySystemNearMissData
                        = ElvisDataModel.EntityHelper.SAS_NM_DataWithDateAndTimeJoinedForElvis.GetByDateAndFilter(dateFrom, dateTo, filter);

                foreach (SAS_NM_DataWithDateAndTimeJoinedForElvis sasNMData in listSafteySystemNearMissData)
                {
                    listNearMiss.Add
                        (new Elvis.Forms.Reports.NearMiss.NearMissRecord
                            {
                                No = sasNMData.ID,
                                Initiator = sasNMData.InitiatorsName,
                                Rota = sasNMData.ROTA,
                                NearMissType = sasNMData.Nearmiss_type,
                                Date = sasNMData.Date.Value,
                                Priority =
                                    ElvisDataModel
                                    .EntityHelper
                                    .SAS_NM_DataWithDateAndTimeJoinedForElvis
                                    .GetPriorityAsString
                                    ((EntityHelper.SAS_NM_DataWithDateAndTimeJoinedForElvis.NearMissRecordPriority)
                                        sasNMData.Priority.Value
                                    ),
                                Status =
                                    ElvisDataModel
                                    .EntityHelper
                                    .SAS_NM_DataWithDateAndTimeJoinedForElvis
                                    .GetStatusAsString
                                    ((EntityHelper.SAS_NM_DataWithDateAndTimeJoinedForElvis.NearMissRecordStatus)
                                        sasNMData.status.Value
                                    ),
                                Location = sasNMData.Location,
                                Description = sasNMData.DescriptionOfAccident
                            }
                        );
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Error getting/building Near Miss data -- GetNearMiss() -- ", ex);
            }

            return listNearMiss;
        }
    }
}
