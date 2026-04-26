using MarsRover.Console.Data;
using MarsRover.Console.Directions;
using MarsRover.Console.Plateaus;
using MarsRover.Console.Rovers;

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

    [Test]
    public void Move_ShouldMoveRightOneCoordinateOnXAxis_WhenGivenOneMoveCommandAndFacingEast()
    {
        Position position = new Position(0, 0, CompassDirection.E);
        var rover = new Rover(position);
        Instruction testInstruction = Instruction.M;
        var expected = new Position(1, 0, CompassDirection.E);

        Position result = rover.Move(testInstruction);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Move_ShouldMoveDownOneCoordinateOnYAxis_WhenGivenOneMoveCommandAndFacingSouth()
    {
        Position position = new Position(0, 1, CompassDirection.S);
        var rover = new Rover(position);
        Instruction testInstruction = Instruction.M;
        var expected = new Position(0, 0, CompassDirection.S);

        Position result = rover.Move(testInstruction);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Move_ShouldDoNothing_WhenGivenAnInstructionOfLeft()
    {
        Position position = new Position(0, 1, CompassDirection.S);
        var rover = new Rover(position);
        Instruction testInstruction = Instruction.L;
        var expected = new Position(0, 1, CompassDirection.S);

        Position result = rover.Move(testInstruction);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Move_ShouldDoNothing_WhenGivenAnInstructionOfRight()
    {
        Position position = new Position(0, 1, CompassDirection.S);
        var rover = new Rover(position);
        Instruction testInstruction = Instruction.R;
        var expected = new Position(0, 1, CompassDirection.S);

        Position result = rover.Move(testInstruction);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CollisionCheck_ShouldReturnNewRoverPosition_WhenCollidingWithYAxisOnLowerBound()
    {
        Position testPos = new(3, -1, CompassDirection.W);
        Rover testRover = new(testPos);

        PlateauSize testPlateauSize = new(5, 5);
        Plateau testPlateau = new(testPlateauSize);

        int expectedY = 0;

        testRover.CollisionCheck(testPlateau);

        Assert.That(testRover.CurrentPosition.Y, Is.EqualTo(expectedY));
    }

    [Test]
    public void CollisionCheck_ShouldReturnNewRoverPosition_WhenCollidingWithXAxisOnLowerBound()
    {
        Position testPos = new(-1, 3, CompassDirection.W);
        Rover testRover = new(testPos);

        PlateauSize testPlateauSize = new(5, 5);
        Plateau testPlateau = new(testPlateauSize);

        int expectedX = 0;

        testRover.CollisionCheck(testPlateau);

        Assert.That(testRover.CurrentPosition.X, Is.EqualTo(expectedX));
    }

    [Test]
    public void CollisionCheck_ShouldReturnNewRoverPosition_WhenCollidingWithXAndYAxisOnLowerBound()
    {
        Position testPos = new(-1, -1, CompassDirection.W);
        Rover testRover = new(testPos);

        PlateauSize testPlateauSize = new(5, 5);
        Plateau testPlateau = new(testPlateauSize);

        int expectedX = 0;
        int expectedY = 0;

        testRover.CollisionCheck(testPlateau);

        Assert.That(testRover.CurrentPosition.X, Is.EqualTo(expectedX));
        Assert.That(testRover.CurrentPosition.Y, Is.EqualTo(expectedY));
    }

    [Test]
    public void CollisionCheck_ShouldReturnExpectedRoverPosition_WhenCollidingWithXAxisOnUpperBound()
    {
        Position testPos = new(6, 3, CompassDirection.W);
        Rover testRover = new(testPos);

        PlateauSize testPlateauSize = new(5, 5);
        Plateau testPlateau = new(testPlateauSize);

        int expectedX = 5;

        testRover.CollisionCheck(testPlateau);

        Assert.That(testRover.CurrentPosition.X, Is.EqualTo(expectedX));
    }

    [Test]
    public void CollisionCheck_ShouldReturnExpectedRoverPosition_WhenCollidingWithYAxisOnUpperBound()
    {
        Position testPos = new(3, 6, CompassDirection.W);
        Rover testRover = new(testPos);

        PlateauSize testPlateauSize = new(5, 5);
        Plateau testPlateau = new(testPlateauSize);

        int expectedY = 5;

        testRover.CollisionCheck(testPlateau);

        Assert.That(testRover.CurrentPosition.Y, Is.EqualTo(expectedY));
    }

    [Test]
    public void CollisionCheck_ShouldReturnNewRoverPosition_WhenCollidingWithXAndYAxisOnUpperBound()
    {
        Position testPos = new(6, 6, CompassDirection.W);
        Rover testRover = new(testPos);

        PlateauSize testPlateauSize = new(5, 5);
        Plateau testPlateau = new(testPlateauSize);

        int expectedX = 5;
        int expectedY = 5;

        testRover.CollisionCheck(testPlateau);

        Assert.That(testRover.CurrentPosition.X, Is.EqualTo(expectedX));
        Assert.That(testRover.CurrentPosition.Y, Is.EqualTo(expectedY));
    }
}
