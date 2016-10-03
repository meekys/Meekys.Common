using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meekys.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static bool In<T>(this T item, params T[] collection)
        {
            return collection.Contains(item);
        }
        
        public static bool In<T>(this T item, IEnumerable<T> collection)
        {
            return collection.Contains(item);
        }
    }
}