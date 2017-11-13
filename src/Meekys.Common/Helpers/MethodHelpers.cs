using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using Meekys.Common.Extensions;

namespace Meekys.Common.Helpers
{
    public static class MethodHelpers
    {
        public static MethodInfo GetMethodInfo<TReturn>(Expression<Func<TReturn>> expression)
        {
            return expression.MethodInfo();
        }

        [SuppressMessage("StyleCop.Analyzers", "CA1801:ReviewUnusedParameters", Justification = "Unused variables used to match function signature")]
        public static MethodInfo GetMethodInfo<T1, TReturn>(Func<T1, TReturn> func, T1 unused1)
        {
            return func.GetMethodInfo();
        }

        [SuppressMessage("StyleCop.Analyzers", "CA1801:ReviewUnusedParameters", Justification = "Unused variables used to match function signature")]
        public static MethodInfo GetMethodInfo<T1, T2, TReturn>(Func<T1, T2, TReturn> func, T1 unused1, T2 unused2)
        {
            return func.GetMethodInfo();
        }

        [SuppressMessage("StyleCop.Analyzers", "CA1801:ReviewUnusedParameters", Justification = "Unused variables used to match function signature")]
        public static MethodInfo GetMethodInfo<T>(Action<T> func, T unused)
        {
            return func.GetMethodInfo();
        }

        [SuppressMessage("StyleCop.Analyzers", "CA1801:ReviewUnusedParameters", Justification = "Unused variables used to match function signature")]
        public static MethodInfo GetMethodInfo<T1, T2>(Action<T1, T2> func, T1 unused1, T2 unused2)
        {
            return func.GetMethodInfo();
        }

        [SuppressMessage("StyleCop.Analyzers", "CA1801:ReviewUnusedParameters", Justification = "Unused variables used to match function signature")]
        public static MethodInfo GetMethodInfo<T1, T2, T3>(Action<T1, T2, T3> func, T1 unused1, T2 unused2, T3 unused3)
        {
            return func.GetMethodInfo();
        }

        public static PropertyInfo GetPropertyInfo<TReturn>(Expression<Func<TReturn>> expression)
        {
            return expression.PropertyInfo();
        }
    }
}