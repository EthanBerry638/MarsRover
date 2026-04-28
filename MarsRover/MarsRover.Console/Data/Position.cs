using MarsRover.Console.Directions;

namespace MarsRover.Console.Data
{
    public class Position (int x, int y, CompassDirection facing)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public CompassDirection Facing { get; set; } = facing;

        public override bool Equals(object? obj)
        {
            if (obj is Position other)
            {
                return X == other.X && Y == other.Y && Facing == other.Facing;
            }

            return false;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y, Facing);
    }
}