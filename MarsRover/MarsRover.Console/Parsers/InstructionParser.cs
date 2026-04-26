using MarsRover.Console.Data;
using System.Text;

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

        public static List<Instruction> GetInstructions(string parsedInstruction)
        {
            List<Instruction> instructions = [];

            if (parsedInstruction == "") return instructions;

            foreach (char letter in parsedInstruction)
            {
                switch (letter)
                {
                    case 'L':
                        instructions.Add(Instruction.L);
                        break;
                    case 'M':
                        instructions.Add(Instruction.M);
                        break;
                    case 'R':
                        instructions.Add(Instruction.R);
                        break;
                }
            }

            return instructions;
        }
    }
}
