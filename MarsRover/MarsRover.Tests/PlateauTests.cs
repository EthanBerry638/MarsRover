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

        [Test]
        public void IsBordering_ShouldReturnTrue_WhenYPositionOfRoverIsLessThan0()
        {
            Position testPosition = new(3, -1, CompassDirection.N);
            Rover testRover = new(testPosition);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            bool expected = true;

            bool result = testPlateau.IsBordering(testRover);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetCollidingAxis_ShouldReturnXAxisOnly_WhenOnlyXPositionIsOutOfBounds()
        {
            Position testPosition = new(10, 3, CompassDirection.N);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                { "X", 10 }
            };

            Dictionary<string, int> result = testPlateau.GetCollidingAxis(testPosition); 

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetCollidingAxis_ShouldReturnYAxisOnly_WhenOnlyYPositionIsOutOfBounds()
        {
            Position testPosition = new(3, 20, CompassDirection.N);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                { "Y", 20 }
            };

            Dictionary<string, int> result = testPlateau.GetCollidingAxis(testPosition);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetCollidingAxis_ShouldReturnXAndYAxis_WhenBothPositionsAreOutOfBounds()
        {
            Position testPosition = new(30, 20, CompassDirection.N);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                { "X", 30 },
                { "Y", 20 }
            };

            Dictionary<string, int> result = testPlateau.GetCollidingAxis(testPosition);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}