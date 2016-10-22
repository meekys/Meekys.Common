using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

using Meekys.Common.Extensions;

using Xunit;

namespace Meekys.Common.Tests.Extensions
{
    public class MethodInfoExtensionTests
    {
        [Fact]
        public void HasCustomAttribute()
        {
            // Arrange
            var methodInfo = GetType().GetProperty("ItemWithAttribute");

            // Act
            var result = methodInfo.HasCustomAttribute<BrowsableAttribute>();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasCustomAttribute_No_Attributes()
        {
            // Arrange
            var methodInfo = GetType().GetProperty("ItemWithoutAttribute");

            // Act
            var result = methodInfo.HasCustomAttribute<BrowsableAttribute>();

            // Assert
            Assert.False(result);
        }

        [Browsable(true)]
        [CategoryAttribute("Test")]
        public int ItemWithAttribute { get; set; }
        public int ItemWithoutAttribute { get; set; }
    }
}