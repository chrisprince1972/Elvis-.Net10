using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;

namespace ElvisDataModel
{
    public static class Extensions
    {
        /// <summary>
        /// Extension to Linq.  Allows the Distinct method to be used.
        /// Groups the List to the specified column (same as SQL Distinct).
        /// </summary>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static EntityCollection<T> ToEntityCollection<T>(this IEnumerable<T> source) where T : class, IEntityWithRelationships
        {
            EntityCollection<T> collection = new EntityCollection<T>();
            foreach (var item in source)
            {
                collection.Add(item);
            }
            return collection;

        } // ToEntityCollection

        /// <summary>
        /// Extension for IEnumerable that calculates the
        /// Normal Standard Deviation for a data set.
        /// </summary>
        /// <param name="values">The values to calculate the SD for.</param>
        /// <returns>A double representing the standard deviation.</returns>
        public static double StdDev(this IEnumerable<double> values)
        {
            // ref: http://www.johndcook.com/blog/standard_deviation/
            // ref: http://www.johndcook.com/blog/2008/09/28/theoretical-explanation-for-numerical-results/

            double mean = 0.0;
            double sum = 0.0;
            double stdDev = 0.0;
            int n = 0;
            foreach (double val in values)
            {
                n++;
                double delta = val - mean;
                mean += delta / n;
                sum += delta * (val - mean);
            }
            if (1 < n)
                stdDev = Math.Sqrt(sum / (n));

            return stdDev;
        }
    }
}
