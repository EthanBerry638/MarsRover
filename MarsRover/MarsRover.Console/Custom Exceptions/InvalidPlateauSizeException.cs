namespace MarsRover.Console.Custom_Exceptions
{
    public class InvalidPlateauSizeException : Exception
    {
        public InvalidPlateauSizeException(string message) : base(message) {}
    }
}