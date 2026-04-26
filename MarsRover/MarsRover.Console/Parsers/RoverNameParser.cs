namespace MarsRover.Console.Parsers
{
    public static class RoverNameParser
    {
        public static string? GetFormattedName(string rawInput)
        {
            if (string.IsNullOrWhiteSpace(rawInput)) return null;
            return rawInput.Trim();
        }
    }
}
