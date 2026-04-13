using MarsRover.Console.Data;
using MarsRover.Console.Directions;
using MarsRover.Console.Rover;

using NUnit;

namespace MarsRover.Tests;

public class RoverTests
{
    [Test]
    public void Rotate_ShouldReturnEast_WhenGivenARotaionOfRightFromNorth()
    {
        Position position = new Position(3, 3, CompassDirection.N);
        var rover = new Rover(position);
        var rotation = Instruction.R;
        var expected = CompassDirection.E;

        CompassDirection result = rover.Rotate(rotation);

        Assert.That(result, Is.EqualTo(expected));
    }
}
