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
    }
}
