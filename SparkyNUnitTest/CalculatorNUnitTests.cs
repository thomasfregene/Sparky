using NUnit.Framework;
using Sparky;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        private Calculator calculator;
        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange

            //Act
            int result = calculator.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddNumber_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange
            //Calculator calculator = new();

            //Act
            bool result = calculator.IsOddNumber(a);

            //Asset
            Assert.That(result, Is.True);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsOddNumber_InputEveneNumber_ReturnFalse()
        {
            //Arrange
            //Calculator calculator = new();

            //Act
            bool result = calculator.IsOddNumber(6);

            //Asset
            Assert.That(result, Is.False);
            //Assert.IsFalse(result);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            //Calculator calculator = new();

            return calculator.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4, 10.5)] //15.9
        [TestCase(5.43, 10.53)] //15.93
        [TestCase(5.49, 10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            //Calculator calculator = new();

            //Act
            double result = calculator.AddNumbersDouble(a,b);

            //Assert
            Assert.AreEqual(15.9, result, 1);
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            //Arrange
           
            List<int> expectedOddRange = new() { 5, 7, 9 }; //5-10

            //Act
            List<int> result = calculator.GetOddRange(5, 10);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            //Assert.AreEqual(expectedOddRange, result);
            //Assert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
