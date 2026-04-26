using MarsRover.Console.Data;
using MarsRover.Console.Parsers;
using MarsRover.Console.Plateaus;
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
                PlateauSize size = GetStartingPlateau();
                if (size == null) continue;
                Plateau plateau = new(size);

                break;
            }
        }

        private PlateauSize GetStartingPlateau()
        {
            Write("Enter Plateau Size (e.g., 5 5): ");
            string input = ReadLine()!;
            int[] rawData = PlateauParser.ParseRawPlateau(input);

            try
            {
                return PlateauParser.GetPlateauSize(rawData);
            }
            catch (ArgumentException)
            {
                WriteLine("Invalid format. Please enter two positive integers separated by a space.");
                return null!;
            }
        }
    }
}
