using MarsRover.Console.Data;
using MarsRover.Console.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Console.Rovers
{
    public class Rover (Position startingPosition)
    {
        public Position CurrentPosition { get; private set; } = startingPosition;

        public CompassDirection Rotate (Instruction instruction)
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
    }
}