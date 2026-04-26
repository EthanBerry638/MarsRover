using MarsRover.Console.Data;
using MarsRover.Console.Directions;
using MarsRover.Console.Plateaus;

namespace MarsRover.Console.Rovers
{
    public class Rover(Position startingPosition)
    {
        public Position CurrentPosition { get; private set; } = startingPosition;

        public CompassDirection Rotate(Instruction instruction)
        {
            if (instruction == Instruction.M) return CurrentPosition.Facing;

            int currentDir = (int)CurrentPosition.Facing;
            int newDir;

            if (instruction == Instruction.L)
            {
                newDir = (currentDir + 3) % 4;
            }
            else
            {
                newDir = (currentDir + 1) % 4;
            }

            CurrentPosition.Facing = (CompassDirection)(newDir);
            return CurrentPosition.Facing;
        }

        public Position Move(Instruction instruction)
        {
            if (instruction != Instruction.M) return CurrentPosition;

            switch (CurrentPosition.Facing)
            {
                case CompassDirection.N:
                    CurrentPosition.Y += 1;
                    break;
                case CompassDirection.E:
                    CurrentPosition.X += 1;
                    break;
                case CompassDirection.S:
                    CurrentPosition.Y -= 1;
                    break;
                case CompassDirection.W:
                    CurrentPosition.X -= 1;
                    break;
            }

            return CurrentPosition;
        }

        public void CollisionCheck(Plateau plateau)
        {
            if (CurrentPosition.X < 0) CurrentPosition.X = 0;
            else if (CurrentPosition.X > plateau.Size.X) CurrentPosition.X = plateau.Size.X;

            if (CurrentPosition.Y < 0) CurrentPosition.Y = 0;
            else if (CurrentPosition.Y > plateau.Size.Y) CurrentPosition.Y = plateau.Size.Y;
        }
    }
}