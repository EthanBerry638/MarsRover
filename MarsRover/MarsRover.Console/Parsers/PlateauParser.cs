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
            int[] parsedXAndY = new int[2];

            if (string.IsNullOrEmpty(rawPlateau)) return parsedXAndY;

            parsedXAndY[0] = int.Parse(rawPlateau);

            return parsedXAndY;
        }
    }
}