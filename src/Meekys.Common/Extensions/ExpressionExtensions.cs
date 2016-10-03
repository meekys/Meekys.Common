using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Meekys.Common.Extensions
{
    public static class ExpressionExtensions
    {
        public static MethodInfo MethodInfo(this Expression expression)
        {               
            var method = expression.LambdaExpression().Body as MethodCallExpression;

            if (method == null)
                throw new ArgumentException("Expected MethodCallExpression", nameof(expression));
                
            return method.Method;
        }

        public static PropertyInfo PropertyInfo(this Expression expression)
        {
            var propertyInfo = expression.MemberExpression().Member as PropertyInfo;

            if (propertyInfo == null)
                throw new ArgumentException("Expected PropertyInfo");
                
            return propertyInfo;
        }
        
        public static LambdaExpression LambdaExpression(this Expression expression)
        {
            var lambdaExpression = expression as LambdaExpression;

            if (lambdaExpression == null)
                throw new ArgumentException("Expected LambdaExpression", nameof(expression));
                
            return lambdaExpression;
        }

        public static MemberExpression MemberExpression(this Expression expression)
        {
            var member = expression.LambdaExpression().Body as MemberExpression;
            
            if (member == null)
                throw new ArgumentException("Expected MemberExpression", nameof(expression));

            return member;
        }

        public static Expression Convert<T>(this Expression expression)
        {
            return expression.Convert(typeof(T));
        }

        public static Expression Convert(this Expression expression, Type type)
        {
            if(expression.Type == type)
                return expression;

            return Expression.Convert(expression, type);
        }
    }
}