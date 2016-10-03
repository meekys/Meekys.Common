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
                body(item);
                
            return items;
        }
        
        public static string Join(this IEnumerable<string> items, string separator)
        {
            return String.Join(separator, items.ToArray());
        }
        
        public static string ToCsv<T>(this IEnumerable<T> items)
        {
            return items.Select(x => x.ToString()).Join(",");
        }
    }
}