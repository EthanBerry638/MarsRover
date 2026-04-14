using MarsRover.Console.Data;
using MarsRover.Console.Rovers;

namespace MarsRover.Console.Plateau
{
    public class Plateau (PlateauSize size)
    {
        public PlateauSize Size { get; private set; } = size;

        public bool IsBordering(Rover rover)
        {
            if (rover.CurrentPosition.X > Size.X || rover.CurrentPosition.Y > Size.Y) return true;
            return false;
        }

        public Dictionary<string, int> GetCollidingAxis(Position position) // position will be given by the rover. this will be called in the move method
        {
            return new Dictionary<string, int> { { "X", 10 }};
        }
    }
}