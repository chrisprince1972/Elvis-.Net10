using System;
using System.Collections.Generic;
using System.Linq;
using ElvisDataModel.EDMX;
using ElvisDataModel;

namespace Elvis.Model
{
    public static class SlabFailures
    {
        /// <summary>
        /// Generates a list of Slab Failures by gathering all failures
        /// and inserting them into one failure list.
        /// </summary>
        /// <param name="heatNumberSet">The Heat Number Set.</param>
        /// <param name="heatNumber">The Heat Number.</param> 
        /// <returns>A list of slab failure objects.</returns>
        public static List<SlabFailure> GetSlabFailures(int heatNumber, int heatNumberSet)
        {
            List<SlabFailure> slabFailures = new List<SlabFailure>();
            List<cct_grade_failures> gradeFailures = EntityHelper.CCT_Grade_Failure.GetByHeat(heatNumber, heatNumberSet);
            List<cct_width_failures> widthFailures = EntityHelper.CCT_Width_Failure.GetByHeat(heatNumber, heatNumberSet);
            List<cct_length_failures> lengthFailures = EntityHelper.CCT_Length_Failure.GetByHeat(heatNumber, heatNumberSet);

            AddRecords(slabFailures, gradeFailures);
            AddRecords(slabFailures, widthFailures);
            AddRecords(slabFailures, lengthFailures);

            return slabFailures
                .OrderBy(s => s.FailureType)
                .ThenBy(l => l.SlabNumber)
                .ToList();
        }

        /// <summary>
        /// Adds grade failures to the generic slab failures list.
        /// </summary>
        /// <param name="slabFailures">The Generic Slab Failures List.</param>
        /// <param name="gradeFailures">The Grade Failures List.</param>
        private static void AddRecords(List<SlabFailure> slabFailures, List<cct_grade_failures> gradeFailures)
        {
            foreach (cct_grade_failures gradeFailure in gradeFailures)
            {
                SlabFailure slabFailure = new SlabFailure();

                slabFailure.FailureType = "Grade";
                slabFailure.SlabNumber = gradeFailure.SLAB_NUMBER;
                slabFailure.Reason1 = gradeFailure.REASON_1;
                slabFailure.Reason2 = gradeFailure.REASON_2;
                slabFailure.Reason3 = gradeFailure.REASON_3;
                slabFailure.Comment = gradeFailure.COMMENT;
                slabFailure.Created = gradeFailure.CREATED;

                slabFailures.Add(slabFailure);
            }
        }

        /// <summary>
        /// Adds Width failures to the generic slab failures list.
        /// </summary>
        /// <param name="slabFailures">The Generic Slab Failures List.</param>
        /// <param name="widthFailures">The Width Failures List.</param>
        private static void AddRecords(List<SlabFailure> slabFailures, List<cct_width_failures> widthFailures)
        {
            foreach (cct_width_failures widthFailure in widthFailures)
            {
                SlabFailure slabFailure = new SlabFailure();

                slabFailure.FailureType = "Width";
                slabFailure.SlabNumber = widthFailure.SLAB_NUMBER;
                slabFailure.Reason1 = widthFailure.REASON_1;
                slabFailure.Reason2 = widthFailure.REASON_2;
                slabFailure.Reason3 = widthFailure.REASON_3;
                slabFailure.Comment = widthFailure.COMMENT;
                slabFailure.Created = widthFailure.CREATED;

                slabFailures.Add(slabFailure);
            }
        }

        /// <summary>
        /// Adds Length failures to the generic slab failures list.
        /// </summary>
        /// <param name="slabFailures">The Generic Slab Failures List.</param>
        /// <param name="lengthFailures">The Length Failures List.</param>
        private static void AddRecords(List<SlabFailure> slabFailures, List<cct_length_failures> lengthFailures)
        {
            foreach (cct_length_failures lengthFailure in lengthFailures)
            {
                SlabFailure slabFailure = new SlabFailure();

                slabFailure.FailureType = "Length";
                slabFailure.SlabNumber = lengthFailure.SLAB_NUMBER;
                slabFailure.Reason1 = lengthFailure.REASON_1;
                slabFailure.Reason2 = lengthFailure.REASON_2;
                slabFailure.Reason3 = lengthFailure.REASON_3;
                slabFailure.Comment = lengthFailure.COMMENT;
                slabFailure.Created = lengthFailure.CREATED;

                slabFailures.Add(slabFailure);
            }
        }
    }

    #region Supporting Classes
    /// <summary>
    /// Stores the Slab failure data.
    /// </summary>
    public class SlabFailure
    {
        public string FailureType { get; set; }
        public int SlabNumber { get; set; }
        public string Reason1 { get; set; }
        public string Reason2 { get; set; }
        public string Reason3 { get; set; }
        public string Comment { get; set; }
        public DateTime? Created { get; set; }
    }
    #endregion
}
