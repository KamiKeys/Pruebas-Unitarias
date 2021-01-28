using NUnit.Framework;
using System;

namespace PicassoTest.Tests
{
    class FizzBuzzTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //TODO: Preguntar si es necesario ponerle '?' para hacer esta prueba.
        [Test]
        public void Number_IsNull_ThrowsNullException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => FizzBuzz.GetOutput(null));
        }

        //TODO: Comprobar cuando se le pase algo diferente a un número.
        //TODO: Preguntar si es necesario hacer prueba para que acepte decimales.

        [Test]
        public void Number_IsDivisibleBy3_ReturnsFizz()
        {
            //Arrange
            int number = 3;

            //Act
            var result = FizzBuzz.GetOutput(number);

            //Assert
            Assert.AreEqual(result, "Fizz");
        }

        [Test]
        public void Number_IsDivisibleBy5_ReturnsBuzz()
        {
            //Arrange
            int number = 5;

            //Act
            var result = FizzBuzz.GetOutput(number);

            //Assert
            Assert.AreEqual(result, "Buzz");
        }

        [Test]
        public void Number_IsDivisibleBy3And5_ReturnsFizzBuzz()
        {
            //Arrange
            int number = 150;

            //Act
            var result = FizzBuzz.GetOutput(number);

            //Assert
            Assert.AreEqual(result, "FizzBuzz");
        }

        [Test]
        public void Number_IsNotDivisibleBy3Or5_ReturnsNumber()
        {
            //Arrange
            int number = 1;

            //Act
            var result = FizzBuzz.GetOutput(number);

            //Assert
            Assert.AreEqual(result, number.ToString());
        }
    }
}
