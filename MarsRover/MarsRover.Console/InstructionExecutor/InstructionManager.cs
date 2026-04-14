using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Console.Data;
using MarsRover.Console.Rovers;
using MarsRover.Console.Plateaus;
using MarsRover.Console.Directions;

namespace MarsRover.Console.InstructionExecutor
{
    public static class InstructionManager
    {
        public static Position PerformInstructions(List<Instruction> instructions, Rover rover, Plateau plateau)
        {
            return new Position(0, 0, CompassDirection.N);
        }
    }
}

/* TODO: Multiple moves will be handled in a different method called PerformInstructions. 
         * This will take the List of instructions and orchestrate the move, rotation and collision logic.
         * Both Move and Rotate only need to know about one instruction and do it.
         * The new method will tell each method what to do.
         * This also means later on we don't need to check the instruction but it doesn't hurt to keep it for now.
        */