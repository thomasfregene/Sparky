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
    public class FiboNUnitTest
    {
        [Test]
        public void FiboChecker_Input1_ReturnsFiboSeries()
        {
            //Arrange
            List<int> expectedRange = new() { 0 };

            Fibo fibo = new();
            fibo.Range = 1;

            //Act
            List<int> result = fibo.GetFiboSeries();

            //Assert
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }

        [Test]
        public void FiboChecker_Input6_ReturnsFiboSeries()
        {
            //Arrange
            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };

            Fibo fibo = new();
            fibo.Range = 6;

            //Act
            List<int> result = fibo.GetFiboSeries();

            //Assert
            Assert.That(result, Does.Contain(3));
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result, Has.No.Member(4));
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }
    }
}
