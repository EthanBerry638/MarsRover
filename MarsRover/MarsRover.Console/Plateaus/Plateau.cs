using MarsRover.Console.Data;
using MarsRover.Console.Rovers;
using System.ComponentModel.Design;

namespace MarsRover.Console.Plateaus
{
    public class Plateau (PlateauSize size)
    {
        public PlateauSize Size { get; private set; } = size;

        public bool IsBordering(Position position)
        {
            return position.X > Size.X || position.Y > Size.Y || position.Y < 0 || position.X < 0;
        }

        public Dictionary<string, int> GetCollidingAxis(Position position)
        {
            Dictionary<string, int> collisions = [];

            if (position.X < 0 || position.X > Size.X) collisions.Add("X", position.X);

            if (position.Y < 0 || position.Y > Size.Y) collisions.Add("Y", position.Y);

            return collisions;
        }
    }
}