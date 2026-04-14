using MarsRover.Console.Data;
using MarsRover.Console.Directions;
using MarsRover.Console.Rovers;

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

    [Test]
    public void Rotate_ShouldReturnOriginalDirection_WhenGivenARotationOfM()
    {
        Position position = new Position(3, 3, CompassDirection.N);
        var rover = new Rover(position);
        var rotation = Instruction.M;
        var expected = CompassDirection.N;

        CompassDirection result = rover.Rotate(rotation);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Rotate_ShouldWrapAroundToNorth_WhenGivenARotationOfRightFromWest()
    {
        Position position = new Position(3, 3, CompassDirection.W);
        var rover = new Rover(position);
        var rotation = Instruction.R;
        var expected = CompassDirection.N;

        CompassDirection result = rover.Rotate(rotation);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Rotate_ShouldWrapAroundToWest_WhenRotatedLeftFromNorth()
    {
        Position position = new Position(3, 3, CompassDirection.N);
        var rover = new Rover(position);
        var rotation = Instruction.L;
        var expected = CompassDirection.W;

        CompassDirection result = rover.Rotate(rotation);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Move_ShouldMoveUpOneCoordinateOnYAxis_WhenGivenOneMoveCommandAndFacingNorth()
    {
        Position position = new Position(0, 0, CompassDirection.N);
        var rover = new Rover(position);
        Instruction testInstructions = Instruction.M;
        var expected = new Position(0, 1, CompassDirection.N);

        Position result = rover.Move(testInstructions);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Move_ShouldMoveLeftOneCoordinateOnXAxis_WhenGivenOneMoveCommandAndFacingWest()
    {
        Position position = new Position(1, 0, CompassDirection.W);
        var rover = new Rover(position);
        Instruction testInstruction = Instruction.M;
        var expected = new Position(0, 0, CompassDirection.W);

        Position result = rover.Move(testInstruction);

        Assert.That(result, Is.EqualTo(expected));
    }
}
