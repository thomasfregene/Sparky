using Sparky;
using Xunit;

namespace SparkyNUnitTest
{

    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator gradCalc;
        
        public GradingCalculatorXUnitTests()
        {
            gradCalc = new GradingCalculator();
        }

        [Fact]
        public void CalculateGrade_ScoreIs95AndAttendanceIs90_ReturnsGradeA()
        {
            //Arrange
            gradCalc.Score = 95;
            gradCalc.AttendancePercentage = 90;

            //Act
            var result = gradCalc.GetGrade();

            //Assert
            Assert.Equal("A", result);
        }

        [Fact]
        public void CalculateGrade_ScoreIs85AndAttendanceIs90_ReturnsGradeB()
        {
            //Arrange
            gradCalc.Score = 85;
            gradCalc.AttendancePercentage = 90;

            //Act
            var result = gradCalc.GetGrade();

            //Assert
            Assert.Equal("B", result);
        }

        [Fact]
        public void CalculateGrade_InputScore65AndAttendance90_ReturnsGradeC()
        {
            //Arrange
            gradCalc.Score = 65;
            gradCalc.AttendancePercentage = 90;

            //Act
            var result = gradCalc.GetGrade();

            //Assert
            Assert.Equal("C", result);
        }

        [Fact]
        public void CalculateGrade_ScoreIs95AndAttendanceIs65_ReturnsGradeA()
        {
            //Arrange
            gradCalc.Score = 95;
            gradCalc.AttendancePercentage = 65;

            //Act
            var result = gradCalc.GetGrade();

            //Assert
            Assert.Equal("B", result);
        }


        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void CalculateGrade_InputMultipleScoreAndAttendance_ReturnsGradeF(int score, int attendance)
        {
            //Arrange
            gradCalc.Score = score;
            gradCalc.AttendancePercentage = attendance;

            //Act
            var result = gradCalc.GetGrade();

            //Assert
            Assert.Equal("F", result);
        }

        [Theory]
        [InlineData(95, 90,  "A")]
        [InlineData(85, 90,  "B")]
        [InlineData(65, 90,  "C")]
        [InlineData(95, 55,  "F")]
        [InlineData(65, 55,  "F")]
        [InlineData(50, 90,  "F")]
        public void CalculateGrade_AllGradeLogicalScenario_ReturnAllGrades(int score, int attendance, string expectedResult)
        {
            gradCalc.Score = score;
            gradCalc.AttendancePercentage = attendance;

            string result = gradCalc.GetGrade();

            Assert.Equal(expectedResult, result);
        }
    }
}
