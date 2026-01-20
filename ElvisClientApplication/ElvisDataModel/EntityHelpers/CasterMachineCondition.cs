using System;
using System.Collections.Generic;
using System.Linq;
using ElvisDataModel.EDMX;
using System.Data.Entity.Core.Objects.DataClasses;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        public static class CasterMachineCondition
        {
            /// <summary>
            /// Generic method to get all entities of type 'T' with or without wherefiltering string
            /// </summary>
            /// <typeparam name="T">The entity type</typeparam>
            /// <param name="filter">query string</param>
            /// <returns>list of entities</returns>
            public static IEnumerable<T> GetAll<T>(string filter = "") where T : EntityObject
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    if (string.IsNullOrWhiteSpace(filter))
                    {
                        return ctx.CreateObjectSet<T>().ToList();
                    }
                    else
                    {
                        return ctx.CreateObjectSet<T>().Where(filter).ToList();
                    }
                }
            }

            /// <summary>
            /// Generic method to get all entities of type 'T' with or without where filter and Orderby filter
            /// </summary>
            /// <typeparam name="T">Entity type</typeparam>
            /// <param name="orderByFilter">orderby string filter</param>
            /// <param name="whereFilter">where string filter</param>
            /// <returns>list of entities</returns>
            public static IEnumerable<T> GetAllWithOrder<T>(string orderByFilter, string whereFilter = "") where T : EntityObject
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    //Orderby parameter can not be null
                    if (string.IsNullOrWhiteSpace(orderByFilter))
                    {
                        throw new ArgumentNullException("Orderby parameter can not be null !");
                    }
                    //Both parameters are supplied
                    if (!string.IsNullOrWhiteSpace(orderByFilter) && !string.IsNullOrWhiteSpace(whereFilter))
                    {
                        return ctx.CreateObjectSet<T>().Where(whereFilter).OrderBy(orderByFilter).ToList();
                    }
                    //Where filter is not supplied, only orderby provided
                    if (string.IsNullOrWhiteSpace(whereFilter))
                    {
                        return ctx.CreateObjectSet<T>().OrderBy(orderByFilter).ToList();
                    }
                    else
                    {
                        return ctx.CreateObjectSet<T>().Where(whereFilter).ToList();
                    }
                }
            }

            /// <summary>
            /// Generic method to get a single entity of type 'T' with or without wherefiltering string
            /// </summary>
            /// <typeparam name="T">The entity type</typeparam>
            /// <param name="filter">query string</param>
            /// <returns>single entity</returns>
            public static T GetSingle<T>(string filter = "") where T : EntityObject
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    if (string.IsNullOrWhiteSpace(filter))
                    {
                        return ctx.CreateObjectSet<T>().FirstOrDefault();
                    }
                    else
                    {
                        return ctx.CreateObjectSet<T>().Where(filter).FirstOrDefault();
                    }
                }
            }

            /// <summary>
            /// Generic method to get a single entity of type 'T' with or without wherefiltering string and Orderby string
            /// </summary>
            /// <typeparam name="T">The entity type</typeparam>
            /// <param name="whereFilter">where query string</param>
            /// <param name="orderFilter">orderby query string</param>
            /// <returns>single entity</returns>
            public static T GetTopSingle<T>(string whereFilter, string orderFilter) where T : EntityObject
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    if (string.IsNullOrWhiteSpace(orderFilter))
                    {
                        new Exception("Blank Parameter Error !");
                    }
                    if (!string.IsNullOrWhiteSpace(whereFilter) && !string.IsNullOrWhiteSpace(orderFilter))
                    {
                        return ctx.CreateObjectSet<T>().Where(whereFilter).OrderBy(orderFilter).FirstOrDefault();
                    }
                    if (string.IsNullOrWhiteSpace(whereFilter) && !string.IsNullOrWhiteSpace(orderFilter))
                    {
                        return ctx.CreateObjectSet<T>().OrderBy(orderFilter).FirstOrDefault();
                    }

                    return null;
                }
            }

            /// <summary>
            /// Generic method to include entities with or without wherefilter string
            /// </summary>
            /// <typeparam name="T">Entity type</typeparam>
            /// <param name="includeFilter">include string</param>
            /// <param name="filter">where string filter</param>
            /// <returns>list of entities</returns>
            public static IEnumerable<T> GetAllWithInclude<T>(string includeFilter, string filter = "") where T : EntityObject
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    if (string.IsNullOrWhiteSpace(filter))
                    {
                        return ctx.CreateObjectSet<T>().Include(includeFilter).ToList();
                    }
                    else
                    {
                        return ctx.CreateObjectSet<T>().Include(includeFilter).Where(filter).ToList();
                    }
                }
            }

            /// <summary>
            /// Generic method to include a sinlge entity with or without wherefilter string
            /// </summary>
            /// <typeparam name="T">Entity type</typeparam>
            /// <param name="includeFilter">include string</param>
            /// <param name="filter">where string filter</param>
            /// <returns>list of entities</returns>
            public static T GetSingleWithInclude<T>(string include, string filter = "") where T : EntityObject
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    if (string.IsNullOrWhiteSpace(filter))
                    {
                        return ctx.CreateObjectSet<T>().Include(include).FirstOrDefault();
                    }
                    else
                    {
                        return ctx.CreateObjectSet<T>().Include(include).Where(filter).FirstOrDefault();
                    }
                }
            }
        }


        public static class StrandSprayWater
        {
            public static List<GetStrandDetail_Result> GetByCasterStrandDate(DateTime testDate, int caster, int strand)
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    return ctx.GetStrandDetail(caster, strand, testDate).ToList();
                }
            }
        }

        public static class SulphurPrintDetails
        {
            public static GetSulphutPrintDetails_Result GetByCasterStrandDate(DateTime castDate, int caster, int strand)
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    return ctx.GetSulphutPrintDetails(caster, strand, castDate, "SulphurPrintICValue").FirstOrDefault<GetSulphutPrintDetails_Result>();
                }
            }
        }

        public static class SegmentSnapshotDetails
        {
            public static List<GetSegmentSnapshotDetails_Result> GetByCasterStrandDate(DateTime snapShotDate, int caster, int strand)
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    return ctx.GetSegmentSnapshotDetails(caster, strand, snapShotDate).ToList();
                }
            }
        }

        public static class SarcladDetails
        {
            public static List<GetSarcladDetail_Result> GetByCasterStrandDate(DateTime testDate, int caster, int strand)
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    return ctx.GetSarcladDetail(caster, strand, testDate).ToList();
                }
            }
        }

        public static class SuplhurPrintStrandAssessment
        {
            public static GetSPStrandAssessment_Result GetByCasterStrandDate(DateTime dateCast, int caster, int strand)
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    return ctx.GetSPStrandAssessment(caster, strand, dateCast).FirstOrDefault<GetSPStrandAssessment_Result>();
                }
            }
        }

        public static class StrandSegmentConfig
        {
            public static List<GetStrandSegmentConfig_Result> GetByCasterStrandDate(string snapshotDate, int caster, int strand)
            {
                using (CMCEntities ctx = new CMCEntities())
                {
                    return ctx.GetStrandSegmentConfig(caster, strand, snapshotDate).ToList<GetStrandSegmentConfig_Result>();
                }
            }
        }
    }
}
