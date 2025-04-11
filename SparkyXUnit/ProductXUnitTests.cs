using Sparky;
using Xunit;

namespace SparkyNUnitTest
{
    
    public class ProductXUnitTests
    {
        [Fact]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith200Discount()
        {
            Product product = new() { Price = 50 };
            var result = product.GetPrice(new Customer() { IsPlatinum = true });

            Assert.Equal(40, result);
        }
    }
}
