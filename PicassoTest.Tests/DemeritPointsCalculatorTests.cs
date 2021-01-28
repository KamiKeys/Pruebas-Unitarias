using NUnit.Framework;
using System;

namespace PicassoTest.Tests
{
    class DemeritPointsCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Speed_less0_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            DemeritPointsCalculator demeritPointsCalculator = new DemeritPointsCalculator();
            int speed = -1;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => demeritPointsCalculator.CalculateDemeritPoints(speed));
        }

        [Test]
        public void Speed_higherMaxSpeed_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            DemeritPointsCalculator demeritPointsCalculator = new DemeritPointsCalculator();
            int speed = 301;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => demeritPointsCalculator.CalculateDemeritPoints(speed));
        }

        [Test]
        public void Speed_lessSpeedLimit_Return0()
        {
            //Arrange
            DemeritPointsCalculator demeritPointsCalculator = new DemeritPointsCalculator();
            int speed = 64;

            //Act
            var result = demeritPointsCalculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void Speed_rSameSpeedLimit_Return0()
        {
            //Arrange
            DemeritPointsCalculator demeritPointsCalculator = new DemeritPointsCalculator();
            int speed = 65;

            //Act
            var result = demeritPointsCalculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void Speed_rSameSpeedLimit_Return27()
        {
            //Arrange
            DemeritPointsCalculator demeritPointsCalculator = new DemeritPointsCalculator();
            int speed = 200;

            //Act
            var result = demeritPointsCalculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.AreEqual(result, 27);
        }
    }
}
