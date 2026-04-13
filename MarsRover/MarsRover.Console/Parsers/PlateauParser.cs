using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return [x, y];
            }

            return [];
        }
    }
}