using NUnit;
using MarsRover.Console.InstructionExecutor;
using MarsRover.Console.Data;
using MarsRover.Console.Directions;
using MarsRover.Console.Rovers;
using MarsRover.Console.Plateaus;

namespace MarsRover.Tests
{
    public class InstructionManagerTests
    {
        [Test]
        public void PerformInstruction_ShouldReturnCurrentPosition_WhenNoInstructionsAreGiven()
        {
            List<Instruction> testInstructions = [];

            Position testPos = new(3, 3, CompassDirection.N);
            Rover testRover = new(testPos);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Position expected = new(3, 3, CompassDirection.N);

            Position result = InstructionManager.PerformInstructions(testInstructions, testRover, testPlateau);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void PerformInstruction_ShouldReturnUpdatedDirection_WhenOnlyARightRotationIsGiven()
        {
            List<Instruction> testInstructions = [Instruction.R];

            Position testPos = new(3, 3, CompassDirection.N);
            Rover testRover = new(testPos);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Position expected = new(3, 3, CompassDirection.E);

            Position result = InstructionManager.PerformInstructions(testInstructions, testRover, testPlateau);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void PerformInstruction_ShouldReturnUpdatedDirection_WhenOnlyALeftRotationIsGiven()
        {
            List<Instruction> testInstructions = [Instruction.L];

            Position testPos = new(3, 3, CompassDirection.N);
            Rover testRover = new(testPos);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Position expected = new(3, 3, CompassDirection.W);

            Position result = InstructionManager.PerformInstructions(testInstructions, testRover, testPlateau);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void PerformInstruction_ShouldReturnUpdatedXAxis_WhenGivenAMoveInstructionAndFacingWest()
        {
            List<Instruction> testInstructions = [Instruction.M];

            Position testPos = new(3, 3, CompassDirection.W);
            Rover testRover = new(testPos);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Position expected = new(2, 3, CompassDirection.W);

            Position result = InstructionManager.PerformInstructions(testInstructions, testRover, testPlateau);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void PerformInstruction_ShouldReturnUpdatedYAxis_WhenGivenAMoveInstructionAndFacingNorth()
        {
            List<Instruction> testInstructions = [Instruction.M];

            Position testPos = new(3, 3, CompassDirection.N);
            Rover testRover = new(testPos);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Position expected = new(3, 4, CompassDirection.N);

            Position result = InstructionManager.PerformInstructions(testInstructions, testRover, testPlateau);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void PerformInstruction_ShouldReturnExpectedYAxis_WhenGivenMultipleMoveInstructionAndFacingNorth()
        {
            List<Instruction> testInstructions = [Instruction.M, Instruction.M, Instruction.M];

            Position testPos = new(3, 2, CompassDirection.N);
            Rover testRover = new(testPos);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Position expected = new(3, 5, CompassDirection.N);

            Position result = InstructionManager.PerformInstructions(testInstructions, testRover, testPlateau);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void PerformInstruction_ShouldReturnExpectedXAxis_WhenGivenMultipleMoveInstructionAndFacingEast()
        {
            List<Instruction> testInstructions = [Instruction.M, Instruction.M, Instruction.M];

            Position testPos = new(2, 3, CompassDirection.E);
            Rover testRover = new(testPos);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Position expected = new(5, 3, CompassDirection.E);

            Position result = InstructionManager.PerformInstructions(testInstructions, testRover, testPlateau);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void PerformInstruction_ShouldReturnExpectedDirection_WhenGivenMultipleRotationInstructionAndNorth()
        {
            List<Instruction> testInstructions = [Instruction.L, Instruction.R, Instruction.L, Instruction.L];

            Position testPos = new(3, 3, CompassDirection.N);
            Rover testRover = new(testPos);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Position expected = new(3, 3, CompassDirection.S);

            Position result = InstructionManager.PerformInstructions(testInstructions, testRover, testPlateau);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void PerformInstruction_ShouldReturnExpectedDirection_WhenGivenMultipleRotationInstructionAndWest()
        {
            List<Instruction> testInstructions = [Instruction.R, Instruction.L, Instruction.R, Instruction.R];

            Position testPos = new(3, 3, CompassDirection.W);
            Rover testRover = new(testPos);

            PlateauSize testPlateauSize = new(5, 5);
            Plateau testPlateau = new(testPlateauSize);

            Position expected = new(3, 3, CompassDirection.E);

            Position result = InstructionManager.PerformInstructions(testInstructions, testRover, testPlateau);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CorrectCollision_ShouldReturnNewRoverPosition_WhenCollidingWithYAxis()
        {
            Position testPos = new(3, -1, CompassDirection.W);
            Rover testRover = new(testPos);

            Dictionary<string, int> testBorderingAxis = new Dictionary<string, int>
            {
                { "Y", -1 }
            };

            Position expected = new(3, 0, CompassDirection.W);

            Position result = InstructionManager.CorrectCollision(testBorderingAxis, testRover);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CorrectCollision_ShouldReturnNewRoverPosition_WhenCollidingWithXAxis()
        {
            Position testPos = new(-1, 3, CompassDirection.W);
            Rover testRover = new(testPos);

            Dictionary<string, int> testBorderingAxis = new Dictionary<string, int>
            {
                { "X", -1 }
            };

            Position expected = new(0, 3, CompassDirection.W);

            Position result = InstructionManager.CorrectCollision(testBorderingAxis, testRover);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CorrectCollision_ShouldReturnNewRoverPosition_WhenCollidingWithXAndYAxis()
        {
            Position testPos = new(-1, -1, CompassDirection.W);
            Rover testRover = new(testPos);

            Dictionary<string, int> testBorderingAxis = new Dictionary<string, int>
            {
                { "X", -1 },
                { "Y", -1 }
            };

            Position expected = new(0, 0, CompassDirection.W);

            Position result = InstructionManager.CorrectCollision(testBorderingAxis, testRover);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
