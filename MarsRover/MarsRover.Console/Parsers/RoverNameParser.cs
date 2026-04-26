using System.Text;

namespace MarsRover.Console.Parsers
{
    public static class RoverNameParser
    {
        public static string? GetFormattedName(string rawInput)
        {
            if (string.IsNullOrWhiteSpace(rawInput)) return null;

            var sb = new StringBuilder();

            foreach (char c in rawInput)
            {
                if (char.IsLetter(c))
                {
                    if (sb.Length == 0)
                    {
                        sb.Append(char.ToUpper(c));
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }

            if (sb.Length == 0) return null;
 
            return sb.ToString().Trim();
        }
    }
}