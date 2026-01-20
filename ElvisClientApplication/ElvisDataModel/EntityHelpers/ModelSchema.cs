using System.Collections.Generic;
using System.Linq;
using ElvisDataModel.EDMX;

// CBM: Charge Balance Model 

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region CbmDisplayAnalysis
        public static class CbmDisplayAnalysis
        {
            /// <summary>
            /// Gets the Display Analysis data by Heat Number and HNS.
            /// </summary>
            /// <param name="heatNumber">The Heat Number.</param>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <returns>A list of CbmDisplayAnalysis objects.</returns>
            public static List<ElvisDataModel.EDMX.CbmDisplayAnalysis> GetByHeat(
                int? heatNumber,
                int? heatNumberSet)
            {
                using (ModelSchemaEntities ctx = new ModelSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.CbmDisplayAnalysis1
                        .Where(m =>
                            m.HEAT_NUMBER == heatNumber &&
                            m.HEAT_NUMBER_SET == heatNumberSet)
                        .ToList();
                }
            }

            /// <summary>
            /// Gets the Display Analysis data by Heat Number, HNS and Run Number.
            /// </summary>
            /// <param name="heatNumber">The Heat Number.</param>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <param name="runNumber">The run number.</param>
            /// <returns>A CbmDisplayAnalysis object.</returns>
            public static ElvisDataModel.EDMX.CbmDisplayAnalysis GetByHeatAndRunNumber(
                int? heatNumber,
                int? heatNumberSet,
                int runNumber)
            {
                using (ModelSchemaEntities ctx = new ModelSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.CbmDisplayAnalysis1
                        .FirstOrDefault(m =>
                            m.HEAT_NUMBER == heatNumber &&
                            m.HEAT_NUMBER_SET == heatNumberSet && 
                            m.CbmRunNumber == runNumber);
                }
            }
        }
        #endregion

        #region CbmDisplayMaterial
        public static class CbmDisplayMaterial
        {
            /// <summary>
            /// Gets the Display Material data by Heat Number and HNS.
            /// </summary>
            /// <param name="heatNumber">The Heat Number.</param>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <returns>A list of CbmDisplayMaterial objects.</returns>
            public static List<ElvisDataModel.EDMX.CbmDisplayMaterial> GetByHeat(
                int? heatNumber,
                int? heatNumberSet)
            {
                using (ModelSchemaEntities ctx = new ModelSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.CbmDisplayMaterials
                        .Where(m =>
                            m.HEAT_NUMBER == heatNumber &&
                            m.HEAT_NUMBER_SET == heatNumberSet)
                        .ToList();
                }
            }
        }
        #endregion

        #region CbmMaterialReq
        public static class CbmMaterialReq
        {
            /// <summary>
            /// Gets the Material Required data by Heat Number and HNS.
            /// </summary>
            /// <param name="heatNumber">The Heat Number.</param>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <returns>A list of CbmMaterialReq objects.</returns>
            public static List<ElvisDataModel.EDMX.CbmMaterialReq> GetByHeat(
                int? heatNumber, 
                int? heatNumberSet)
            {
                using (ModelSchemaEntities ctx = new ModelSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.CbmMaterialReqs
                        .Where(m => 
                            m.HEAT_NUMBER == heatNumber && 
                            m.HEAT_NUMBER_SET == heatNumberSet)
                        .ToList();
                }
            }
        }
        #endregion

        #region CbmMessage
        public static class CbmMessage
        {
            /// <summary>
            /// Gets the Message data by Heat Number and HNS.
            /// </summary>
            /// <param name="heatNumber">The Heat Number.</param>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <returns>A list of CbmMessage objects.</returns>
            public static List<ElvisDataModel.EDMX.CbmMessage> GetByHeat(
                int? heatNumber,
                int? heatNumberSet)
            {
                using (ModelSchemaEntities ctx = new ModelSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.CbmMessages
                        .Where(m =>
                            m.HEAT_NUMBER == heatNumber &&
                            m.HEAT_NUMBER_SET == heatNumberSet)
                        .ToList();
                }
            }
        }
        #endregion

        #region CbmResult
        public static class CbmResult
        {
            /// <summary>
            /// Gets the Result data by Heat Number and HNS.
            /// </summary>
            /// <param name="heatNumber">The Heat Number.</param>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <returns>A list of CbmResult objects.</returns>
            public static List<ElvisDataModel.EDMX.CbmResult> GetByHeat(
                int? heatNumber,
                int? heatNumberSet)
            {
                using (ModelSchemaEntities ctx = new ModelSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.CbmResults
                        .Where(m =>
                            m.HEAT_NUMBER == heatNumber &&
                            m.HEAT_NUMBER_SET == heatNumberSet)
                        .ToList();
                }
            }
        }
        #endregion

        #region EbmDisplayAnalysis
        public static class EbmDisplay
        {
            public static EDMX.EbmDisplay GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (ModelSchemaEntities ctx = new ModelSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.EbmDisplays
                        .FirstOrDefault(e => 
                            e.HNS == heatNumberSet && 
                            e.HeatNumber == heatNumber
                        );
                }
            }
        }
        #endregion

        #region HmdsmResult
        public static class HmdsmResult
        {
            /// <summary>
            /// Gets the HmdsmResult records by Heat Number and HNS.
            /// </summary>
            /// <param name="heatNumber">The Heat Number.</param>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <returns>A list of HmdsmResult objects.</returns>
            public static List<ElvisDataModel.EDMX.HmdsmResult> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (ModelSchemaEntities ctx = new ModelSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.HmdsmResults
                        .Where(r =>
                            r.HNS == heatNumberSet
                            && r.HeatNumber == heatNumber)
                        .ToList();
                }
            }
        }
        #endregion

    }
}
