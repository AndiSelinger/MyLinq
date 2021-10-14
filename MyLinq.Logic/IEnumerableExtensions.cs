using System;
using System.Collections.Generic;

namespace MyLinq.Logic
{
    public static class IEnumerableExtensions
    {
        //public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> filter) //oder mit predicate

        /// <summary>
        /// Filters a sequence of values based on a predicate
        /// </summary>
        /// <typeparam name="T">The type of the elements of source</typeparam>
        /// <param name="source">An IEnumerable<T> to filter.</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>An IEnumberable<T> that contains elements from the input sequence that satisfy the condition.</returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            source.CheckArgument(nameof(source)); //CheckArgument ist in ObjectExtensions
            source.CheckArgument(nameof(predicate));

            List<T> result = new List<T>();
            foreach (var item in source)
            {
                if (predicate(item))
                    result.Add(item);
            }
            return result;
        }
        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="mapping">A transform function to apply to each element.</param>
        /// <returns>An IEnumerable<T> whose elements are the result of invoking the transform function on each element of source.</returns>
        public static IEnumerable<TResult> Map<T, TResult>(this IEnumerable<T> source, Func<T, TResult> mapping)
        {
            source.CheckArgument(nameof(source));
            mapping.CheckArgument(nameof(mapping));
            var result = new List<TResult>();
            foreach (var item in source)
            {
                result.Add(mapping(item));
            }
            return result;
        }
        /// <summary>
        /// Creates an array from a IEnumerable<T>
        /// </summary>
        /// <typeparam name="T">The type of the elements</typeparam>
        /// <param name="source">An IEnumerable<T> to create an array from</param>
        /// <returns>An array that contains the elements from the input sequence.</returns>
        public static T[] ToArray<T>(this IEnumerable<T> source)
        {
            source.CheckArgument(nameof(source));
            return new List<T>(source).ToArray();
        }
        /// <summary>
        /// Creates a List<T> from an IEnumerable<T>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The IEnumerable<T> to create a List<T> from.</param>
        /// <returns>A List<T> that contains elements from the input sequence.</returns>
        public static List<T> ToList<T>(this IEnumerable<T> source)
        {
            source.CheckArgument(nameof(source));
            return new List<T>(source);
        }
        /// <summary>
        /// Computes the sum of a sequence of numeric values.
        /// </summary>
        /// <typeparam name="T">The tyoe of the elements of source.</typeparam>
        /// <param name="source">The IEnumberable<T> to calculate the sum of.</param>
        /// <param name="transform">A transform function to apply to each element.</param>
        /// <returns>The sum of values from the input sequence.</returns>
        public static double Sum<T>(this IEnumerable<T> source, Func<T, double> transform)
        {
            source.CheckArgument(nameof(source));
            source.CheckArgument(nameof(transform));
            double result = 0;
            foreach (var item in source)
            {
                result += transform(item);
            }
            return result;
        }
        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to determine the minimum value of.</param>
        /// <param name="transform">A transform function to apply to each element.</param>
        /// <returns>The minimum value from the input sequence.</returns>
        public static double? Min<T>(this IEnumerable<T> source, Func<T, double> transform)
        {
            source.CheckArgument(nameof(source));
            source.CheckArgument(nameof(transform));
            double? result = null;
            double? comparison = null;
            foreach (var item in source)
            { //Müsste ich Kontrolle hinzufügen, dass ein double reingekommen ist?
                if (result == null)
                    result = transform(item);
                else
                {
                    comparison = transform(item);
                    result = comparison < result ? comparison : result;
                }
            }
            return result;
        }
        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source</typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="transform">A transform function to apply to each element.</param>
        /// <returns>The minimum value from the input sequence.</returns>
        public static double? Max<T>(this IEnumerable<T> source, Func<T, double> transform)
        {
            source.CheckArgument(nameof(source));
            source.CheckArgument(nameof(transform));
            double? result = null;
            double? comparison = null;
            foreach (var item in source)
            { //Müsste ich Kontrolle hinzufügen, dass ein double reingekommen ist?
                if (result == null)
                    result = transform(item);
                else
                {
                    comparison = transform(item);
                    result = comparison > result ? comparison : result;
                }
            }
            return result;
        }
        /// <summary>
        /// Computes the average of a sequence of numeric values.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to determine the average value of.</param>
        /// <param name="transform">A transform function to apply to each element.</param>
        /// <returns>The average value from the input sequence.</returns>
        public static double? Average<T>(this IEnumerable<T> source, Func<T, double> transform)
        {
            source.CheckArgument(nameof(source));
            source.CheckArgument(nameof(transform));
            double? result = null;
            int count = 0;
            foreach (var item in source)
            {
                count++;
                if (result == null)
                    result = transform(item);
                else
                {
                    result += transform(item);
                }
            }
            result = count > 0 ? result / count : 0;
            return result;
        }
        /// <summary>
        /// Performs an action on a sequence of values.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to perform the action with.</param>
        /// <param name="action">An action that is applied to each element.</param>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            source.CheckArgument(nameof(source));
            
            if (action != null)
            {
                foreach (var item in source)
                {
                    action(item);
                }
            } 
            return source;
        }
        /// <summary>
        /// Performs an action on a sequence of values and provides an iterator.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to perferm the action with.</param>
        /// <param name="action">An action that is applied to each element and an iterator.</param>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<int, T> action) //int = iterator
        {
            source.CheckArgument(nameof(source));
            int count = 0;  //iterator = just a counter?
            if (action != null)
            {
                foreach (var item in source)
                {
                    count++;
                    action(count, item);
                }
            }
            return source;
        }
        /// <summary>
        /// Sorts the elements of a sequence in order.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="orderBy">A function to extract a key from an element.</param>
        /// <returns>An ordered IEnumerable<T> whose elements are sorted according to a key.</returns>
        public static IEnumerable<T> SortBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> orderBy) where TKey : IComparable
        {
            source.CheckArgument(nameof(source));
            source.CheckArgument(nameof(orderBy));
            var result = source.ToArray();
            Array.Sort(result, new SortByComparer<T, TKey>(orderBy));
            return result;
        }
        private class SortByComparer<T, TKey> : IComparer<T> where TKey : IComparable 
                    //T ist uneingeschränkt. TKey ist durch das "where TKey : IComparable" eingeschränkt.
        {
            private Func<T, TKey> OrderBy { get; } //property
            public SortByComparer(Func<T, TKey> orderBy)
            {
                orderBy.CheckArgument(nameof(orderBy));
                OrderBy = orderBy;
            }
            public int Compare(T x, T y)
            {
                return OrderBy(x).CompareTo(OrderBy(y));
            }
        }
        /// <summary>
        /// Returns distinct elements from a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values to remove duplicate elements from.</param>
        /// <returns>An IEnumerable<T> that contains distinct elements from the source sequence.</returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source)
        {
            HashSet<T> hs = new HashSet<T>();
            foreach (var item in source)
            {
                hs.Add(item);
            }
            return hs;
        }

        //ist nicht vorgegeben, aber habs zum Testen verwendet
        /// <summary>
        /// Prints a value.
        /// </summary>
        /// <typeparam name="T">The type of the element of source.</typeparam>
        /// <param name="source">A single value to be printed.</param>
        public static void Print<T>(this T source)
        {
            Console.WriteLine(source);
        }
    }
}
