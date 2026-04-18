using Xunit;
using NorthwindMVC.Models;

namespace Northwind.test
{
    public class ProductTests
    {
        [Fact]
        public void InventoryValue_Should_Return_Correct_Value()
        {
            // Arrange
            var product = new ProductDto
            {
                ProductName = "Test Product",
                UnitPrice = 10,
                UnitsInStock = 5
            };

            // Act
            var result = product.InventoryValue;

            // Assert
            Assert.Equal(50, result);
        }
    }
}