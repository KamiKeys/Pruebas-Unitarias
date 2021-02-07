using NUnit.Framework;
using System;

namespace PicassoTest.Tests
{
    class ReservationComplexTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new ReservationComplex();

            //Act
            var result = reservation.CanBeCancelledBy(new UserComplex()
            {
                IsAdmin = true
            });

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_UserIsMadeBy_ReturnsTrue()
        {
            //Arrange
            var persona = new UserComplex();
            var reservation = new ReservationComplex { MadeBy = persona };

            //Act
            var result = reservation.CanBeCancelledBy(persona);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotMadeBy_ReturnsTrue()
        {
            //Arrange
            var persona = new UserComplex();
            var persona2 = new UserComplex();
            var reservation = new ReservationComplex { MadeBy = persona };

            //Act
            var result = reservation.CanBeCancelledBy(persona2);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNull_ThrowsNullException()
        {
            //Arrange
            var reservation = new ReservationComplex { };

            //Assert
            Assert.Throws<ArgumentNullException>(() => reservation.CanBeCancelledBy(null));
        }

        [Test]
        public void MoneyUser_IsHigherPrice_Returns0()
        {
            //Arrange
            var persona = new UserComplex() { IsAdmin = false, Money = 50 };
            var reservation = new ReservationComplex() { MadeBy = persona, Price = 30};

            //Act
            var result = reservation.PayReservation(persona);

            //Assert
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void MoneyUser_IsLowerPrice_Returns0()
        {
            //Arrange
            var persona = new UserComplex() { IsAdmin = false, Money = 20 };
            var reservation = new ReservationComplex() { MadeBy = persona, Price = 30 };

            //Act
            var result = reservation.PayReservation(persona);

            //Assert
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void MoneyUser_IsEqualPrice_Returns0()
        {
            //Arrange
            var persona = new UserComplex() { IsAdmin = false, Money = 50 };
            var reservation = new ReservationComplex() { MadeBy = persona, Price = 50 };

            //Act
            var result = reservation.PayReservation(persona);

            //Assert
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void MoneyUser_IsHigherPrice_ReturnsResultOperation()
        {
            //Arrange
            var persona = new UserComplex() { IsAdmin = false, Money = 50 };
            var reservation = new ReservationComplex() { MadeBy = persona, Price = 30 };

            //Act
            var result = reservation.PayReservation(persona);

            //Assert
            Assert.AreEqual(persona.Money, 20);
        }
    }
}
