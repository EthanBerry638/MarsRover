using NUnit;
using MarsRover.Console.Data;
using System.ComponentModel.DataAnnotations;
using MarsRover.Console.Rovers;
using MarsRover.Console.Directions;
using MarsRover.Console.Plateau;

namespace MarsRover.Tests
{
    public class PlateauTests
    {
        [Test]
        public void IsBordering_ShouldReturnTrue_WhenXPositionOfRoverIsExceedingPlateauSize()
        {
            Position testPosition = new(6, 3, CompassDirection.N);
            Rover testRover = new(testPosition);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            bool expected = true;

            bool result = testPlateau.IsBordering(testRover);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void IsBordering_ShouldReturnFalse_WhenBothPositionOfRoverIsNotExceedingPlateauSize()
        {
            Position testPosition = new(3, 3, CompassDirection.N);
            Rover testRover = new(testPosition);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            bool expected = false;

            bool result = testPlateau.IsBordering(testRover);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void IsBordering_ShouldReturnTrue_WhenYPositionOfRoverIsExceedingPlateauSize()
        {
            Position testPosition = new(3, 6, CompassDirection.N);
            Rover testRover = new(testPosition);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            bool expected = true;

            bool result = testPlateau.IsBordering(testRover);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
