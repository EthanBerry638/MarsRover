using MarsRover.Console.Data;
using MarsRover.Console.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Console.Rover
{
    public class Rover (Position startingPosition)
    {
        public Position _startingPosition { get; private set; } = startingPosition;

        public CompassDirection Rotate (Instruction instruction)
        {
            if (instruction == Instruction.M) return _startingPosition.Facing;

            int currentDir = (int)_startingPosition.Facing - 1;
            int newDir;

            if (instruction == Instruction.L)
            {
                newDir = (currentDir + 3) % 4;
            }
            else
            {
                newDir = (currentDir + 1) % 4;
            }

            _startingPosition.Facing = (CompassDirection)(newDir + 1);
            return _startingPosition.Facing; 
        }
    }
}