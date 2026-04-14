using MarsRover.Console.Data;
using MarsRover.Console.Rovers;

namespace MarsRover.Console.Plateau
{
    public class Plateau (PlateauSize size)
    {
        public PlateauSize Size { get; private set; } = size;

        public bool IsBordering(Rover rover)
        {
            return false;
        }
    }
}