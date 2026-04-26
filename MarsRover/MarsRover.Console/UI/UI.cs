using MarsRover.Console.Data;
using MarsRover.Console.InstructionExecutor;
using MarsRover.Console.Parsers;
using MarsRover.Console.Plateaus;
using MarsRover.Console.Rovers;
using static System.Console;

namespace MarsRover.Console.UI
{
    public class UI
    {
        public void StartMission()
        {
            WriteLine("Welcome to the Mars Rover mission!\n");

            while (true)
            {
                PlateauSize? size = GetStartingPlateau();
                if (size == null) continue;
                Plateau plateau = new(size);

                Position? startingPos = GetInitialPosition(plateau);
                if (startingPos == null) continue;
                Rover rover = new Rover(startingPos);

                List<Instruction>? instructions = GetInstructions();
                if (instructions == null) continue;

                InstructionManager.PerformInstructions(instructions, rover, plateau);
                OutputResult(rover);

                if (ShouldExit()) break;
            }
        }

        private PlateauSize? GetStartingPlateau()
        {
            Write("Enter Plateau Size (e.g., 5 5): ");
            string? input = ReadLine();
            int[] rawData = PlateauParser.ParseRawPlateau(input!);

            try
            {
                return PlateauParser.GetPlateauSize(rawData);
            }
            catch (ArgumentException)
            {
                WriteLine("\nInvalid format. Please enter two positive integers separated by a space.\n");
                return null;
            }
        }

        private Position? GetInitialPosition(Plateau plateau)
        {
            Write("Enter Initial Rover Position (e.g., 2 4 W): ");
            string? input = ReadLine();
            string parsedPos = PositionParser.RawPositionParser(input!);

            try
            {
                return PositionParser.GetPosition(parsedPos, plateau.Size);
            }
            catch (ArgumentException)
            {
                WriteLine("\nInvalid format. Please enter two positive integers within the plateau bounds and a direction separated by spaces.\n");
                return null;
            }
        }

        private List<Instruction>? GetInstructions()
        {
            Write("Enter Movement and Direction Instructions (e.g., LRM): ");
            string? input = ReadLine();

            string parsedInstruction = InstructionParser.ParseInstruction(input!);
            List<Instruction> instructions = InstructionParser.GetInstructions(parsedInstruction);

            if (instructions.Count == 0)
            {
                WriteLine("\nInvalid format. Please enter instructions containing only L, M, or R.\n");
                return null;
            }

            return instructions;
        }

        private void OutputResult(Rover rover)
        {
            //TODO: add rover name to rover for better output
            WriteLine($"\nRover moved to X: {rover.CurrentPosition.X}, Y: {rover.CurrentPosition.Y}.\nIt is now facing: {rover.CurrentPosition.Facing}.");
        }

        private bool ShouldExit()
        {
            Write("\nWould you like to deploy another rover? (Y/N): \n");
            string? input = ReadLine()?.ToUpper();
            return input == "N" || input == "EXIT";
        }
    }
}