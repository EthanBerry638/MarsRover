using MarsRover.Console.Custom_Exceptions;
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
                string? roverName = GetRoverName();
                Rover rover = CreateRover(startingPos, roverName);

                List<Instruction>? instructions = GetInstructions();

                if (instructions != null)
                {
                    InstructionManager.PerformInstructions(instructions, rover, plateau);
                    WriteLine($"\n{rover.Name} moved to X: {rover.CurrentPosition.X}, Y: {rover.CurrentPosition.Y}.\nIt is now facing: {rover.CurrentPosition.Facing}.");
                }
                else
                {
                    WriteLine($"\n{rover.Name} didn't recieve any valid instructions so it stayed at X: {rover.CurrentPosition.X}, Y: {rover.CurrentPosition.Y}.\nIt is facing: {rover.CurrentPosition.Facing}.");
                }

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
            catch (InvalidPlateauSizeException ex)
            {
                WriteLine(ex.Message);
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
            catch (InvalidPositionException ex)
            {
                WriteLine(ex.Message);
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
                return null;
            }

            return instructions;
        }

        private string? GetRoverName()
        {
            Write("Enter Rover Name (optional, leave blank if you want): ");
            string? input = ReadLine();

            return RoverNameParser.GetFormattedName(input!);
        }

        private Rover CreateRover(Position startingPos, string? roverName)
        {
            if (roverName == null)
            {
                return new Rover(startingPos);
            }

            return new Rover(startingPos, roverName);
        }

        private bool ShouldExit()
        {
            Write("\nWould you like to deploy another rover? (Y/N):");
            string? input = ReadLine()?.ToUpper();
            WriteLine();
            return input == "N" || input == "EXIT";
        }
    }
}