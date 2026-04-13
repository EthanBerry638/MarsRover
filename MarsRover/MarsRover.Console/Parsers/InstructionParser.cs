using MarsRover.Console.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Console.Parsers
{
    public static class InstructionParser
    {
        public static string ParseInstruction(string rawInstruction)
        {
            if (string.IsNullOrWhiteSpace(rawInstruction)) return "";

            string parsedString = "";

            foreach (char letter in rawInstruction)
            {
                char currentLetter = char.ToUpper(letter) switch
                {
                    'L' => 'L',
                    'M' => 'M',
                    'R' => 'R',
                };

                parsedString += currentLetter;
            }

            return parsedString;
        }
    }
}
