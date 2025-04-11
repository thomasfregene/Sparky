using Sparky;
using Xunit;

namespace SparkyNUnitTest
{

    public class FiboXUnitTest
    {
        [Fact]
        public void FiboChecker_Input1_ReturnsFiboSeries()
        {
            //Arrange
            List<int> expectedRange = new() { 0 };

            Fibo fibo = new();
            fibo.Range = 1;

            //Act
            List<int> result = fibo.GetFiboSeries();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(result.OrderBy(u=>u), result);
            Assert.Equal(expectedRange, result);
            Assert.True(result.SequenceEqual(expectedRange));
        }

        [Fact]
        public void FiboChecker_Input6_ReturnsFiboSeries()
        {
            //Arrange
            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };

            Fibo fibo = new();
            fibo.Range = 6;

            //Act
            List<int> result = fibo.GetFiboSeries();

            //Assert
            Assert.Contains(3, result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(expectedRange, result);
        }
    }
}
