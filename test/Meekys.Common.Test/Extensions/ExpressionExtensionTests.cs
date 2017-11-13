using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Meekys.Common.Extensions;

using Xunit;

namespace Meekys.Common.Tests.Extensions
{
    public class ExpressionExtensionTests
    {
        [Fact]
        public void LambdaExpression()
        {
            // Arrange
            Expression<Func<object, bool>> expression = x => true;

            // Act
            var lambda = expression.LambdaExpression();

            // Assert
            Assert.True(expression is LambdaExpression);
            Assert.Equal("x => True", expression.ToString());
        }

        [Fact]
        public void LambdaExpression_Exception()
        {
            // Arrange
            Expression expression = Expression.Constant(true);

            // Act + Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                expression.LambdaExpression());
            Assert.Equal("Expected LambdaExpression\r\nParameter name: expression", exception.Message);
        }

        [Fact]
        public void MemberExpression()
        {
            // Arrange
            Expression<Func<string, int>> expression = x => x.Length;

            // Act
            var memberExpression = expression.MemberExpression();

            // Assert
            Assert.NotNull(memberExpression);
            Assert.Equal("Length", memberExpression.Member.Name);
        }

        [Fact]
        public void MemberExpression_Exception()
        {
            // Arrange
            Expression<Func<int, int>> expression = x => x * 2;

            // Act + Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                expression.PropertyInfo());
            Assert.Equal("Expected MemberExpression\r\nParameter name: expression", exception.Message);
        }

        [Fact]
        public void MethodInfo()
        {
            // Arrange
            var str = string.Empty;
            Expression<Func<string>> expression = () => str.Trim();

            // Act
            var methodInfo = expression.MethodInfo();

            // Assert
            Assert.NotNull(methodInfo);
            Assert.Equal("Trim", methodInfo.Name);
        }

        [Fact]
        public void MethodInfo_Exception()
        {
            // Arrange
            var str = string.Empty;
            Expression<Func<int>> expression = () => str.Length;

            // Act + Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                expression.MethodInfo());
            Assert.Equal("Expected MethodCallExpression\r\nParameter name: expression", exception.Message);
        }

        [Fact]
        public void PropertyInfo()
        {
            // Arrange
            var str = string.Empty;
            Expression<Func<int>> expression = () => str.Length;

            // Act
            var propertyInfo = expression.PropertyInfo();

            // Assert
            Assert.NotNull(propertyInfo);
            Assert.Equal("Length", propertyInfo.Name);
        }

        [Fact]
        public void PropertyInfo_Exception()
        {
            // Arrange
            var str = string.Empty;
            Expression<Func<string>> expression = () => str.Trim();

            // Act + Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                expression.PropertyInfo());
            Assert.Equal("Expected MemberExpression\r\nParameter name: expression", exception.Message);
        }

        [Fact]
        public void Convert_Same_Type()
        {
            // Arrange
            Expression expression = Expression.Constant(5.0);

            // Act
            var result = expression.Convert(typeof(double));

            // Assert
            Assert.Equal(expression, result);
        }

        [Fact]
        public void Convert_Different_Type()
        {
            // Arrange
            Expression expression = Expression.Constant(5);

            // Act
            var result = expression.Convert(typeof(double));
            var castResult = result as UnaryExpression;

            // Assert
            Assert.NotEqual(expression, result);
            Assert.NotNull(castResult);
            Assert.Equal(typeof(double), castResult.Type);
        }
    }
}