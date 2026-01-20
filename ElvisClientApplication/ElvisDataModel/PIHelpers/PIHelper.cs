//using System;
//using System.Collections.Generic;
//using System.Linq;
//using ElvisDataModel.PSPIServiceReference;

//namespace ElvisDataModel.PIHelpers
//{
//    public static class PIHelper
//    {
//        /// <summary>
//        /// Gets interpolated PI data from the PSPI Service Reference. 
//        /// </summary>
//        /// <param name="piTag">The PI tag to search for.</param>
//        /// <param name="start">The Start DatTime.</param>
//        /// <param name="end">The Start DatTime.</param>
//        /// <param name="intervalSecs">The Interval Time in Seconds.</param>
//        /// <returns>A List of PIValueObjects.</returns>
//        public static List<PIValueObject> GetInterpolatedPIData(string piTag,
//            DateTime start, DateTime end,
//            float intervalSecs)
//        {
//            using (PIContractsClient pi = new PIContractsClient())
//            {
//                return pi.GetInterpolatedValues(
//                        piTag,
//                        start, end,
//                        intervalSecs, false)
//                    .ToList();
//            }
//        }
//        /// <summary>
//        /// Checks if a tag exists in PI. 
//        /// </summary>
//        /// <param name="piTag">The PI tag to find.</param>
//        /// <returns>True if the tag exists, else false.</returns>
//        public static bool TagExists(string piTag)
//        {
//            using (PIContractsClient pi = new PIContractsClient())
//            {
//                return pi.TagExists(piTag);
//            }
//        }
//    }
//}
