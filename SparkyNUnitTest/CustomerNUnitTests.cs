using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sparky;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void SetUp()
        {
            customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
  

            //Act
            customer.GreetAndCombineNames("Ben", "Sparky");


            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(customer.GreetMessage, "Hello, Ben Sparky");
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Sparky"));
                Assert.That(customer.GreetMessage, Does.Contain(","));
                Assert.That(customer.GreetMessage, Does.Contain("ben Sparky").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
                Assert.That(customer.GreetMessage, Does.EndWith("Sparky"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));

            });

            
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange
           

            //Act
            //customer.GreetAndCombineNames("Ben", "Sparky");

            //Assert
            Assert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            int discount = customer.Discount;
            Assert.That(discount, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            Assert.IsNotNull(customer.GreetMessage);

            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);

            Assert.That(()=>customer.GreetAndCombineNames("","sparky"), 
                Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));

            Assert.That(() => customer.GreetAndCombineNames("", "sparky"),
                Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatinumCustomer()
        {
            customer.OrderTotal = 105;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }

    }
}
