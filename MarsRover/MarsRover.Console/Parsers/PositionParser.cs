using MarsRover.Console.Custom_Exceptions;
using MarsRover.Console.Data;
using MarsRover.Console.Directions;

namespace MarsRover.Console.Parsers
{
    public static class PositionParser
    {
        public static string RawPositionParser(string rawPosition)
        {
            if (string.IsNullOrEmpty(rawPosition)) return "";


            string[] parts = rawPosition.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3) return "";

            parts[2] = parts[2].ToUpper();

            if (int.TryParse(parts[0], out int value) && int.TryParse(parts[1], out int value2)
                && Enum.TryParse(parts[2], out CompassDirection direction))
            {
                if (value >= 0 && value2 >= 0) return $"{value} {value2} {direction}";
            }

            return "";
        }

        public static Position GetPosition(string parsedPosition, PlateauSize plateau)
        {
            if (parsedPosition == "") throw new InvalidPositionException("\nInvalid format. Please enter two positive integers within the plateau bounds and a direction separated by spaces.\n");

            string[] parts = parsedPosition.Split(' ');

            if (plateau.X < int.Parse(parts[0]) || plateau.Y < int.Parse(parts[1]))
            {
                throw new InvalidPositionException("\nInvalid format. Please enter two positive integers within the plateau bounds and a direction separated by spaces.\n");
            }

            Enum.TryParse(parts[2], out CompassDirection direction);

            return new Position(int.Parse(parts[0]), int.Parse(parts[1]), direction);
        }
    }
}