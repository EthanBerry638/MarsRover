using MarsRover.Console.Directions;
using MarsRover.Console.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (value >= 0 && value2 >= 0) return $"{value} {value2} {direction.ToString()}";
            }

            return "";
        }

        public static bool IsValidPosition(string parsedPosition) 
        {
            /* All parsing has happened in rawpositionparse. It will return empty if invalid so that's all we check.
            // This will be used later so instead of throwing an exception we can call this before we try to make a 
            record of type Position. */
            if (parsedPosition == "") return false;

            return true;
        }

        public static Position GetPosition(string parsedPosition)
        {
            string[] parts = parsedPosition.Split(' ');

            Enum.TryParse(parts[2], out CompassDirection direction);

            return new Position(int.Parse(parts[0]), int.Parse(parts[1]), direction);
        }
    }
}