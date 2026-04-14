using MarsRover.Console.Data;

namespace MarsRover.Console.Plateau
{
    public class Plateau (PlateauSize size)
    {
        public PlateauSize Size { get; private set; } = size;

        public bool IsColliding()
        {
            return false;
        }
    }
}