namespace MarsRover.Console.Parsers
{
    public static class RoverNameParser
    {
        public static string? GetRawName(string rawInput)
        {
            if (string.IsNullOrWhiteSpace(rawInput)) return null;
            return rawInput;
        }
    }
}
