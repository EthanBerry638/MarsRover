using MarsRover.Console.Data;
using MarsRover.Console.Rovers;
using System.ComponentModel.Design;

namespace MarsRover.Console.Plateau
{
    public class Plateau (PlateauSize size)
    {
        public PlateauSize Size { get; private set; } = size;

        public bool IsBordering(Position position)
        {
            if (position.X > Size.X || position.Y > Size.Y || position.Y < 0 || position.X < 0) return true;
            return false;
        }

        public Dictionary<string, int> GetCollidingAxis(Position position) // TODO: refactor into switch statement
        {
            if (position.X > Size.X && position.Y > Size.Y) return new Dictionary<string, int>
            {
                { "X", position.X },
                { "Y", position.Y }
            };
            else if (position.X < 0 && position.Y < 0) return new Dictionary<string, int>
            {
                { "X", position.X },
                { "Y", position.Y }
            };

            if (position.X < 0) return new Dictionary<string, int>
            {
                { "X", position.X }
            };
            else if (position.Y < 0) return new Dictionary<string, int>
            {
                { "Y", position.Y }
            };

            if (position.X > Size.X) return new Dictionary<string, int>
            {
                { "X", position.X }
            };
            else if (position.Y > Size.Y) return new Dictionary<string, int>
            {
                { "Y", position.Y }
            };

            return new Dictionary<string, int>(); 
        }
    }
}