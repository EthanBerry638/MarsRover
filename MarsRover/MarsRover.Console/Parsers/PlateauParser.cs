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
            if (string.IsNullOrEmpty(rawPlateau)) return new int[0];

            string[] parts = rawPlateau.Split(' ');

            if (parts.Length != 2) return new int[0];

            if (int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
            {
                return new int[] { x, y };
            }

            return new int[0];
        }
    }
}