using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Meekys.Common.Helpers;

using Xunit;

namespace Meekys.Common.Tests.Extensions
{
    public class MethodHelperTests
    {
        [Fact]
        public void GetMethodInfo()
        {
            // Arrange
            var refString = string.Empty;

            // Act
            var result = MethodHelpers.GetMethodInfo(() => refString.ToUpper());

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ToUpper", result.Name);
        }

        [Fact]
        public void GetPropertyInfo()
        {
            // Arrange
            var refString = string.Empty;

            // Act
            var result = MethodHelpers.GetPropertyInfo(() => refString.Length);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Length", result.Name);
        }
    }
}