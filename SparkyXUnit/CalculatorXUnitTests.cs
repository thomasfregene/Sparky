using Sparky;
using Xunit;

namespace SparkyNUnitTest
{
    public class CalculatorXUnitTests
    {
       
        
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calculator = new();
            //Act
            int result = calculator.AddNumbers(10, 20);

            //Assert
            Assert.Equal(30, result);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsOddNumber_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange
            //Calculator calculator = new();
            Calculator calculator = new();
            //Act
            bool result = calculator.IsOddNumber(a);

            //Asset
            //Assert.That(result, Is.True);
            Assert.True(result);
        }

        [Fact]
        public void IsOddNumber_InputEveneNumber_ReturnFalse()
        {
            //Arrange
            //Calculator calculator = new();
            Calculator calculator = new();
            //Act
            bool result = calculator.IsOddNumber(6);

            //Asset
            //Assert.That(result, Is.False);
            Assert.False(result);
        }

        [Theory]
        [InlineData(10,  false)]
        [InlineData(11,  true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            //Calculator calculator = new();
            Calculator calculator = new();
            var result = calculator.IsOddNumber(a);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(5.4, 10.5)] //15.9
        [InlineData(5.43, 10.53)] //15.96
        [InlineData(5.49, 10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator calculator = new();

            //Act
            double result = calculator.AddNumbersDouble(a, b);

            //Assert
            Assert.Equal(15.9, result, 0);
        }

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            //Arrange
            Calculator calculator = new();
            List<int> expectedOddRange = new() { 5, 7, 9 }; //5-10

            //Act
            List<int> result = calculator.GetOddRange(5, 10);

            //Assert
            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u=>u), result);
            //Assert.That(result, Is.Unique);
        }
    }
}
