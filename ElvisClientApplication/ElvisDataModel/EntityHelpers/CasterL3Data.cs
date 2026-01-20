using System.Collections.Generic;
using System.Linq;
using ElvisDataModel.EDMX;
using System;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region cast_slab Table Functions
        public static class cast_slab
        {
            /// <summary>
            /// Gets the Cast Slab View data by Heat Number.
            /// </summary>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <returns>A List of cast_slab_view data.</returns>
            public static Tuple<int, int> GetHeatNumberAndSetBySlab(int slabID)
            {
                using (CasterLevel3Entities ctx = new CasterLevel3Entities())
                {
                    Tuple<int, int> heatNumberAndSet = null;

                    // Get the latest slab of that slab number.
                    ElvisDataModel
                        .EDMX
                        .cast_slab aCastSlab
                        = ctx
                        .cast_slab
                        .OrderBy(r => r.SLAB_NUMBER_SET)
                        .ThenBy(r => r.CAST_SLAB_NUMBER)
                        .FirstOrDefault(r => r.CAST_SLAB_NUMBER == slabID);

                    if (aCastSlab != null && aCastSlab.HEAT_NUMBER_SET.HasValue && aCastSlab.CAST_HEAT_NUMBER.HasValue)
                    {
                        heatNumberAndSet = new Tuple<int, int>
                                (
                                    aCastSlab.HEAT_NUMBER_SET.Value,
                                    aCastSlab.CAST_HEAT_NUMBER.Value
                                );
                    }

                    return heatNumberAndSet;
                }
            }
        }
        #endregion

        #region CCT_Cast_Slab_View Table Functions
        public static class CCT_Cast_Slab_View
        {
            /// <summary>
            /// Gets the Cast Slab View data by Heat Number.
            /// </summary>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <param name="heatNumber">The Heat Number</param>
            /// <returns>A List of cast_slab_view data.</returns>
            public static List<cast_slab_view> GetByHeat(int heatNumber, int heatNumberSet)
            {
                using (CasterLevel3Entities ctx = new CasterLevel3Entities())
                {
                    return ctx.cast_slab_view
                        .Where(h => 
                            h.HEAT_NUMBER_SET == heatNumberSet && 
                            h.CAST_HEAT_NUMBER == heatNumber)
                        .OrderBy(h => h.CAST_SLAB_NUMBER)
                        .ToList();
                }
            }
        }
        #endregion

        #region CCT_Grade_Failure Table Functions
        public static class CCT_Grade_Failure
        {
            /// <summary>
            /// Gets Grade Failures by the Heat Number.
            /// </summary>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <param name="heatNumber">The Heat Number</param>
            /// <returns>List of cct_grade_failures Objects.</returns>
            public static List<ElvisDataModel.EDMX.cct_grade_failures> GetByHeat(
                int heatNumber, 
                int heatNumberSet)
            {
                using (CasterLevel3Entities ctx = new CasterLevel3Entities())
                {
                    return ctx.cct_grade_failures
                        .Where(g => 
                            g.HEAT_NUMBER == heatNumber && 
                            g.HEAT_NUMBER_SET == heatNumberSet)
                        .ToList();
                }
            }
        }
        #endregion

        #region CCT_Length_Failure Table Functions
        public static class CCT_Length_Failure
        {
            /// <summary>
            /// Gets Length Failures by the Heat Number.
            /// </summary>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <param name="heatNumber">The Heat Number</param>
            /// <returns>List of cct_length_failures Objects</returns>
            public static List<ElvisDataModel.EDMX.cct_length_failures> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (CasterLevel3Entities ctx = new CasterLevel3Entities())
                {
                    return ctx.cct_length_failures
                        .Where(g =>
                            g.HEAT_NUMBER == heatNumber &&
                            g.HEAT_NUMBER_SET == heatNumberSet)
                        .ToList();
                }
            }
        }
        #endregion

        #region CCT_Width_Failure Table Functions
        public static class CCT_Width_Failure
        {
            /// <summary>
            /// Gets Width Failures by the Heat Number.
            /// </summary>
            /// <param name="heatNumberSet">The Heat Number Set.</param>
            /// <param name="heatNumber">The Heat Number</param>
            /// <returns>List of cct_width_failures Objects</returns>
            public static List<ElvisDataModel.EDMX.cct_width_failures> GetByHeat(
                int heatNumber,
                int heatNumberSet)
            {
                using (CasterLevel3Entities ctx = new CasterLevel3Entities())
                {
                    return ctx.cct_width_failures
                        .Where(g =>
                            g.HEAT_NUMBER == heatNumber &&
                            g.HEAT_NUMBER_SET == heatNumberSet)
                        .ToList();
                }
            }
        }
        #endregion
    }
}
