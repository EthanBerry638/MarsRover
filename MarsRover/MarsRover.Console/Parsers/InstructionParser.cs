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

            StringBuilder sb = new();

            foreach (char letter in rawInstruction)
            {
                char upperLetter = char.ToUpper(letter);

                if (upperLetter == 'L' || upperLetter == 'M' || upperLetter == 'R')
                {
                   sb.Append(upperLetter);
                }
            }

            return sb.ToString();
        }

        private static List<Instruction> GetInstruction(string parsedInstruction)
        {
            
        }
    }
}
