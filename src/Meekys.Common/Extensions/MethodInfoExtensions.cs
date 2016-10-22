using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Meekys.Common.Extensions
{
    public static class MemberInfoExtensions
    {
        public static bool HasCustomAttribute<T>(this MemberInfo member)
            where T : Attribute
        {
            return member.GetCustomAttribute<T>() != null;
        }
    }
}