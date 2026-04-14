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

        /* TODO: Multiple moves will be handled in a different method called PerformInstructions. 
         * This will take the List of instructions and orchestrate the move, rotation and collision logic.
         * Both Move and Rotate only need to know about one instruction and do it.
         * The new method will tell each method what to do.
         * This also means later on we don't need to check the instruction but it doesn't hurt to keep it for now.
        */

        public Position Move(Instruction instructions) // TODO: Return to this and finish tests after fixing collision logic
        {
            if (CurrentPosition.Facing == CompassDirection.W)
            {
                CurrentPosition.X -= 1;
                return CurrentPosition;
            }
            CurrentPosition.Y += 1;
            return CurrentPosition;
        }
    }
}