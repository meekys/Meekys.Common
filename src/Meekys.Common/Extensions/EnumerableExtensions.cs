using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meekys.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> items, Action<T> body)
        {
            foreach (var item in items)
            {
                body(item);
            }

            return items;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> items, Action<T, int> body)
        {
            var index = 0;

            foreach (var item in items)
            {
                body(item, index++);
            }

            return items;
        }

        public static string Join(this IEnumerable<string> items, string separator)
        {
            return string.Join(separator, items.ToArray());
        }

        public static string ToCsv<T>(this IEnumerable<T> items)
        {
            return items.ToCsv(x => x.ToString());
        }

        public static string ToCsv<T>(this IEnumerable<T> items, Func<T, string> selector)
        {
            return items.Select(selector).Join(", ");
        }
    }
}