using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Meekys.Common.Extensions;

using Xunit;

namespace Meekys.Common.Tests.Extensions
{
    public class ObjectExtensionTests
    {
        [Fact]
        public void In_Inline()
        {
            // Arrange
            var item = "Test";

            // Act
            var result = item.In("A", "List", "Of", "Test", "Items");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void In_Inline_No_Match()
        {
            // Arrange
            var item = "Not Found";

            // Act
            var result = item.In("A", "List", "Of", "Test", "Items");

            // Assert
            Assert.False(result);
        }

        public void In_Enumerable()
        {
            // Arrange
            var item = "Test";
            var list = new List<string> { "A", "List", "Of", "Test", "Items" };

            // Act
            var result = item.In(list);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void In_Enumerable_No_Match()
        {
            // Arrange
            var item = "Not Found";
            var list = new List<string> { "A", "List", "Of", "Test", "Items" };

            // Act
            var result = item.In(list);

            // Assert
            Assert.False(result);
        }
    }
}