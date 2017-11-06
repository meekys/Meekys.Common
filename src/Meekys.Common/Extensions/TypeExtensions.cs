using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Meekys.Common.Extensions
{
    public static class TypeExtensions
    {
        public static string GenericName(this Type type)
        {
            var arguments = type.GenericTypeArguments;

            if (!arguments.Any())
            {
                return type.Name;
            }

            return string.Format(
                CultureInfo.CurrentCulture,
                "{0}<{1}>",
                type.Name.Split('`').First(),
                arguments.Select(a => a.GenericName()).ToCsv());
        }

        public static bool IsNullable(this Type type)
        {
            if (type.GenericTypeArguments.Length == 0)
            {
                return false;
            }

            return type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static Type MakeNullable(this Type type)
        {
            if (type.IsNullable())
            {
                return type;
            }

            return typeof(Nullable<>).MakeGenericType(type);
        }
    }
}