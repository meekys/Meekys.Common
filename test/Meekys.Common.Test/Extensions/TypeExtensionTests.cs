using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Meekys.Common.Extensions;

using Xunit;

namespace Meekys.Common.Tests.Extensions
{
    public class TypeExtensionTests
    {
        [Fact]
        public void GenericName_With_Single_Parameter()
        {
            // Arrange
            var type = typeof(List<string>);

            // Act
            var result = type.GenericName();

            // Assert
            Assert.Equal("List<String>", result);
        }

        [Fact]
        public void GenericName_With_Multiple_Parameters()
        {
            // Arrange
            var type = typeof(KeyValuePair<string, object>);

            // Act
            var result = type.GenericName();

            // Assert
            Assert.Equal("KeyValuePair<String, Object>", result);
        }

        [Fact]
        public void GenericName_With_NonGeneric()
        {
            // Arrange
            var type = typeof(string);

            // Act
            var result = type.GenericName();

            // Assert
            Assert.Equal("String", result);
        }

        [Fact]
        public void GenericName_With_Nested_Types()
        {
            // Arrange
            var type = typeof(KeyValuePair<string, List<object>>);

            // Act
            var result = type.GenericName();

            // Assert
            Assert.Equal("KeyValuePair<String, List<Object>>", result);
        }

        [Fact]
        public void IsNullable_With_NullableInt()
        {
            // Act
            var result = typeof(int?).IsNullable();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsNullable_With_Int()
        {
            // Act
            var result = typeof(int).IsNullable();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsNullable_With_Object()
        {
            // Act
            var result = typeof(object).IsNullable();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void MakeNullable_With_Int()
        {
            // Act
            var result = typeof(int).MakeNullable();

            // Assert
            Assert.Equal(typeof(int?), result);
        }

        [Fact]
        public void MakeNullable_With_NullableInt()
        {
            // Act
            var result = typeof(int?).MakeNullable();

            // Assert
            Assert.Equal(typeof(int?), result);
        }
    }
}