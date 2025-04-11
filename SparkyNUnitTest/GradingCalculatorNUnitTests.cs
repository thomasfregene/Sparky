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
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator gradCalc;
        private GradingCalculator gradCalc1;
        private GradingCalculator gradCalc2;
        private GradingCalculator gradCalc3;
        [SetUp]
        public void Setup()
        {
            gradCalc = new GradingCalculator();
            gradCalc1 = new GradingCalculator();
            gradCalc2 = new GradingCalculator();
            gradCalc3 = new GradingCalculator();
        }

        [Test]
        public void CalculateGrade_ScoreIs95AndAttendanceIs90_ReturnsGradeA()
        {
            //Arrange
            gradCalc.Score = 95;
            gradCalc.AttendancePercentage = 90;

            //Act
            var result = gradCalc.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void CalculateGrade_ScoreIs85AndAttendanceIs90_ReturnsGradeB()
        {
            //Arrange
            gradCalc.Score = 85;
            gradCalc.AttendancePercentage = 90;

            //Act
            var result = gradCalc.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void CalculateGrade_InputScore65AndAttendance90_ReturnsGradeC()
        {
            //Arrange
            gradCalc.Score = 65;
            gradCalc.AttendancePercentage = 90;

            //Act
            var result = gradCalc.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void CalculateGrade_ScoreIs95AndAttendanceIs65_ReturnsGradeA()
        {
            //Arrange
            gradCalc.Score = 95;
            gradCalc.AttendancePercentage = 65;

            //Act
            var result = gradCalc.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("B"));
        }
        //[Test]
        //public void CalculateGrade_InputMultipleScoreAndAttendance_ReturnsGradeF()
        //{
        //    //Arrange 
        //    gradCalc1.Score = 95;
        //    gradCalc1.AttendancePercentage = 55;

        //    gradCalc2.Score = 65;
        //    gradCalc2.AttendancePercentage = 55;

        //    gradCalc3.Score = 50;
        //    gradCalc3.AttendancePercentage = 90;

        //    //Act
        //    var grade1 = gradCalc1.GetGrade();
        //    var grade2 = gradCalc2.GetGrade();
        //    var grade3 = gradCalc3.GetGrade();

        //    //Assert Multiple
        //    Assert.Multiple(() =>
        //    {
        //        Assert.That(grade1, Is.EqualTo("F"));
        //        Assert.That(grade2, Is.EqualTo("F"));
        //        Assert.That(grade3, Is.EqualTo("F"));
        //    });

        //}

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void CalculateGrade_InputMultipleScoreAndAttendance_ReturnsGradeF(int score, int attendance)
        {
            //Arrange
            gradCalc.Score = score;
            gradCalc.AttendancePercentage = attendance;

            //Act
            var result = gradCalc.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string CalculateGrade_AllGradeLogicalScenario_ReturnAllGrades(int score, int attendance)
        {
            gradCalc.Score = score;
            gradCalc.AttendancePercentage = attendance;

            return gradCalc.GetGrade();


        }
    }
}
