namespace MarsRover.Console.Custom_Exceptions
{
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException(string message) : base(message) { }
    }
}
