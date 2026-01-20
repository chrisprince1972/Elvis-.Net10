using System.Collections.Generic;
using System.Linq;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region ELEMENT_TAG Table Functions
        public static class ELEMENT_TAG
        {
            /// <summary>
            /// Gets a full list of ELEMENT_TAG.
            /// </summary>
            /// <returns>Returns a list of ELEMENT_TAG objects.</returns>
            public static List<ElvisDataModel.EDMX.ELEMENT_TAG> GetAll()
            {
                using (SpecsSchemaEntities ctx = new SpecsSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.ELEMENT_TAG.ToList();
                }
            }
        }
        #endregion

        #region GRADE Table Functions
        public static class GRADE
        {
            /// <summary>
            /// Gets a GRADE via the primary key, GRADE_NUMBER.
            /// </summary>
            /// <param name="gradeNo">The Grade Number.</param>
            /// <returns>Returns a GRADE object.</returns>
            public static ElvisDataModel.EDMX.GRADE GetByID(int gradeNo)
            {
                using (SpecsSchemaEntities ctx = new SpecsSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GRADEs.FirstOrDefault(g => g.GRADE_NUMBER == gradeNo);
                }
            }
        }
        #endregion

        #region GRADE_ADDITION Table Functions
        public static class GRADE_ADDITION
        {
            /// <summary>
            /// Gets a list of GRADE_ADDITION by the Grade Number.
            /// </summary>
            /// <returns>Returns a List of GRADE_ADDITION objects.</returns>
            public static List<ElvisDataModel.EDMX.GRADE_ADDITION> GetByGradeNo(int gradeNo)
            {
                using (SpecsSchemaEntities ctx = new SpecsSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GRADE_ADDITION.Where(g => g.GRADE_NUMBER == gradeNo).ToList();
                }
            }
        }
        #endregion

        #region GRADE_ANALYSIS Table Functions
        public static class GRADE_ANALYSIS
        {
            /// <summary>
            /// Gets a list of GRADE_ANALYSIS by the Grade Number.
            /// </summary>
            /// <returns>Returns a List of GRADE_ANALYSIS objects.</returns>
            public static List<ElvisDataModel.EDMX.GRADE_ANALYSIS> GetByGradeNo(int gradeNo)
            {
                using (SpecsSchemaEntities ctx = new SpecsSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GRADE_ANALYSIS.Where(g => g.GRADE_NUMBER == gradeNo).ToList();
                }
            }
        }
        #endregion

        #region GRADE_INSTRUCTIONS Table Functions
        public static class GRADE_INSTRUCTIONS
        {
            /// <summary>
            /// Gets a list of GRADE_INSTRUCTIONS by the Grade Number
            /// </summary>
            /// <returns>Returns a List of GRADE_INSTRUCTIONS objects.</returns>
            public static List<ElvisDataModel.EDMX.GRADE_INSTRUCTIONS> GetByGradeNo(int gradeNo)
            {
                using (SpecsSchemaEntities ctx = new SpecsSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GRADE_INSTRUCTIONS.Where(g => g.GRADE_NUMBER == gradeNo).ToList();
                }
            }
        }
        #endregion

        #region GRADE_TEMPERATURE Table Functions
        public static class GRADE_TEMPERATURE
        {
            /// <summary>
            /// Gets a list of GRADE_TEMPERATURE by the Grade Number
            /// </summary>
            /// <returns>Returns a List of GRADE_TEMPERATURE objects.</returns>
            public static List<ElvisDataModel.EDMX.GRADE_TEMPERATURE> GetByGradeNo(int gradeNo)
            {
                using (SpecsSchemaEntities ctx = new SpecsSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GRADE_TEMPERATURE.Where(g => g.GRADE_NUMBER == gradeNo).ToList();
                }
            }
        }
        #endregion

        #region GRADE_TREATMENT Table Functions
        public static class GRADE_TREATMENT
        {
            /// <summary>
            /// Gets a list of GRADE_TREATMENT by the Grade Number
            /// </summary>
            /// <returns>Returns a List of GRADE_TREATMENT objects.</returns>
            public static List<ElvisDataModel.EDMX.GRADE_TREATMENT> GetByGradeNo(int gradeNo)
            {
                using (SpecsSchemaEntities ctx = new SpecsSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GRADE_TREATMENT.Where(g => g.GRADE_NUMBER == gradeNo).ToList();
                }
            }
        }
        #endregion

        #region TREATMENT Table Functions
        public static class TREATMENT
        {
            /// <summary>
            /// Gets all of TREATMENT from the table TREATMENT.
            /// </summary>
            /// <returns>Returns a List of TREATMENT objects.</returns>
            public static List<ElvisDataModel.EDMX.TREATMENT> GetAll()
            {
                using (SpecsSchemaEntities ctx = new SpecsSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.TREATMENTs.ToList();
                }
            }
        }
        #endregion

        #region UNIT Table Functions
        public static class GRADE_UNIT
        {
            /// <summary>
            /// Gets all of GRADE_UNITS from the table UNIT.
            /// </summary>
            /// <returns>Returns a List of GRADE_UNIT objects.</returns>
            public static List<ElvisDataModel.EDMX.GRADE_UNIT> GetAll()
            {
                using (SpecsSchemaEntities ctx = new SpecsSchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.GRADE_UNIT.OrderBy(g => g.UNIT_ORDER).ToList();
                }
            }
        }
        #endregion
    }
}
