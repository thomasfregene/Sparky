using Sparky;
using Xunit;

namespace SparkyNUnitTest
{   
    public class CustomerXUnitTests
    {
        private Customer customer;
        
        public CustomerXUnitTests()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange


            //Act
            customer.GreetAndCombineNames("Ben", "Sparky");


            //Assert
           
                Assert.Equal("Hello, Ben Sparky", customer.GreetMessage);
                Assert.Contains("ben Sparky".ToLower(), customer.GreetMessage.ToLower());
                Assert.StartsWith("Hello,", customer.GreetMessage);
                Assert.EndsWith("Sparky", customer.GreetMessage);
                Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);


        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange


            //Act
            //customer.GreetAndCombineNames("Ben", "Sparky");

            //Assert
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            int discount = customer.Discount;
            Assert.InRange(discount, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            Assert.NotNull(customer.GreetMessage);

            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            Assert.Equal("Empty First Name", exceptionDetails.Message);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatinumCustomer()
        {
            customer.OrderTotal = 105;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }

    }
}
