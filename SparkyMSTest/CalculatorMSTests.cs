using Sparky;

namespace SparkyMSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator cal = new();

            //Act
            int result = cal.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
