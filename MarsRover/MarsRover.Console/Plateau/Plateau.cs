using MarsRover.Console.Data;
using MarsRover.Console.Rovers;
using System.ComponentModel.Design;

namespace MarsRover.Console.Plateau
{
    public class Plateau (PlateauSize size)
    {
        public PlateauSize Size { get; private set; } = size;

        public bool IsBordering(Rover rover)
        {
            if (rover.CurrentPosition.X > Size.X || rover.CurrentPosition.Y > Size.Y || rover.CurrentPosition.Y < 0) return true;
            return false;
        }

        public Dictionary<string, int> GetCollidingAxis(Position position) // position will be given by the rover. this will be called in the move method
        {
            if (position.X > Size.X && position.Y > Size.Y) return new Dictionary<string, int>
            {
                { "X", position.X },
                { "Y", position.Y }
            };

            if (position.X > Size.X) return new Dictionary<string, int>
            {
                { "X", position.X }
            };
            else return new Dictionary<string, int> 
            { 
                { "Y", position.Y } 
            };
        }
    }
}