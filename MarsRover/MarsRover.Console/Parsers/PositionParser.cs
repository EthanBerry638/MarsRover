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

            if (rawPosition.Length == 5)
            {
                string[] parts = rawPosition.Split(' ');
                parts[2] = parts[2].ToUpper();

                if (int.TryParse(parts[0], out int value) && int.TryParse(parts[1], out int value2))
                {
                    return $"{parts[0]} {parts[1]} {parts[2]}";
                }
            }

            return "";
        }
    }
}