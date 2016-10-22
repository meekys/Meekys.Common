using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Meekys.Common.Extensions;

using Xunit;

namespace Meekys.Common.Tests.Extensions
{
    public class EnumerableExtensionTests
    {
        [Fact]
        public void ForEach()
        {
            // Arrange
            var data = Enumerable.Range(1, 10);
            var current = 0;

            // Act
            var result = data.ForEach(item => {
                current++;

                // Assert
                Assert.Equal(current, item); // item is 1 based
            });

            // Assert
            Assert.Equal(result, data);
        }

        [Fact]
        public void ForEach_With_Index()
        {
            // Arrange
            var data = Enumerable.Range(1, 10);
            var current = 0;

            // Act
            var result = data.ForEach((item, index) => {
                // Assert
                Assert.Equal(current, index); // index is 0 based

                current++;

                // Assert
                Assert.Equal(current, item); // item is 1 based
            });

            // Assert
            Assert.Equal(result, data);
        }

        [Fact]
        public void Join_With_Empty_Separator()
        {
            // Arrange
            var data = new[] { "Items", "In", "A", "List" };

            // Act
            var result = data.Join(string.Empty);

            // Arrange
            Assert.Equal("ItemsInAList", result);
        }

        [Fact]
        public void Join_With_Multiple_Items()
        {
            // Arrange
            var data = new[] { "Items", "In", "A", "List" };

            // Act
            var result = data.Join("-");

            // Arrange
            Assert.Equal("Items-In-A-List", result);
        }

        [Fact]
        public void Join_With_Single_Item()
        {
            // Arrange
            var data = new[] { "Item" };

            // Act
            var result = data.Join("-");

            // Arrange
            Assert.Equal("Item", result);
        }

        [Fact]
        public void Join_With_No_Items()
        {
            // Arrange
            var data = new string[] {};

            // Act
            var result = data.Join("-");

            // Arrange
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ToCsv_With_Multiple_Items()
        {
            // Arrange
            var data = new[] { "Items", "In", "A", "List" };

            // Act
            var result = data.ToCsv();

            // Arrange
            Assert.Equal("Items, In, A, List", result);
        }

        [Fact]
        public void ToCsv_With_Single_Item()
        {
            // Arrange
            var data = new[] { "Item" };

            // Act
            var result = data.ToCsv();

            // Arrange
            Assert.Equal("Item", result);
        }

        [Fact]
        public void ToCsv_With_No_Items()
        {
            // Arrange
            var data = new string[] { };

            // Act
            var result = data.ToCsv();

            // Arrange
            Assert.Equal(string.Empty, result);
        }
    }
}