using System.Text;

namespace MarsRover.Console.Parsers
{
    public static class RoverNameParser
    {
        public static string? GetFormattedName(string rawInput)
        {
            if (string.IsNullOrWhiteSpace(rawInput)) return null;

            var sb = new StringBuilder();

            sb.Append(char.ToUpper(rawInput[0]));

            for (int i = 1; i < rawInput.Length; i++)
            {
                sb.Append(rawInput[i]);
            }
 
            return sb.ToString().Trim();
        }
    }
}