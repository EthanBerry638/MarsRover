using MarsRover.Console.Custom_Exceptions;
using MarsRover.Console.Data;

namespace MarsRover.Console.Parsers
{
    public static class PlateauParser
    {
        public static int[] ParseRawPlateau(string rawPlateau)
        {
            if (string.IsNullOrEmpty(rawPlateau)) return [];

            string[] parts = rawPlateau.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2) return [];

            if (int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
            {
                if (x > 0 && y > 0)
                {
                    return [x, y];
                }
            }

            return [];
        }

        public static PlateauSize GetPlateauSize(int[] parsedPlateau)
        {
            if (parsedPlateau.Length != 2)
            {
                throw new InvalidPlateauSizeException("\nInvalid format. Please enter two positive integers separated by a space.\n");
            }

            return new PlateauSize(parsedPlateau[0], parsedPlateau[1]);
        }
    }
}