using System;
using System.Collections.Generic;

namespace MyLinq.Logic
{
    public static class IEnumerableExtensions
    {
        //public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> filter) //oder mit predicate
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

        public static T[] ToArray<T>(this IEnumerable<T> source)
        {
            source.CheckArgument(nameof(source));
            return new List<T>(source).ToArray();
        }

        public static List<T> ToList<T>(this IEnumerable<T> source)
        {
            source.CheckArgument(nameof(source));
            return new List<T>(source);
        }
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
        public static void Print<T>(this T source)
        {
            Console.WriteLine(source);
        }
    }
}
