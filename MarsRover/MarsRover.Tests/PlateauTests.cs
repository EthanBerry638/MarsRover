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
        public void IsBordering_ShouldReturnTrue_WhenPositionOfRoverIsExceedingPlateauSize()
        {
            Position testPosition = new(6, 6, CompassDirection.N);
            Rover testRover = new(testPosition);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            bool expected = true;

            bool result = testPlateau.IsBordering(testRover);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
