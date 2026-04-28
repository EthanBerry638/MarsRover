using MarsRover.Console.Data;
using MarsRover.Console.Directions;
using MarsRover.Console.InstructionExecutor;
using MarsRover.Console.Parsers;
using MarsRover.Console.Plateaus;
using MarsRover.Console.Rovers;

namespace MarsRover.Tests.IntegrationTests
{
    public class IntegrationTests
    {
        [Test]
        public void FullMission_ShouldNavigateRoverToCorrectFinalPosition()
        {
            string rawPlateau = "5 5";
            string rawPosition = "1 2 N";
            string rawInstructions = "LMLMLMLMM";

            int[] plateauData = PlateauParser.ParseRawPlateau(rawPlateau);
            PlateauSize plateauSize = PlateauParser.GetPlateauSize(plateauData);
            Plateau plateau = new Plateau(plateauSize);

            string parsedPos = PositionParser.RawPositionParser(rawPosition);
            Position startPos = PositionParser.GetPosition(parsedPos, plateauSize);
            Rover rover = new Rover(startPos);

            string cleanInstructions = InstructionParser.ParseInstruction(rawInstructions);
            List<Instruction> instructions = InstructionParser.GetInstructions(cleanInstructions);

            InstructionManager.PerformInstructions(instructions, rover, plateau);

            Position expectedPosition = new Position(1, 3, CompassDirection.N);

            Assert.That(rover.CurrentPosition.X, Is.EqualTo(expectedPosition.X));
            Assert.That(rover.CurrentPosition.Y, Is.EqualTo(expectedPosition.Y));
            Assert.That(rover.CurrentPosition.Facing, Is.EqualTo(expectedPosition.Facing));

        }
    }
}