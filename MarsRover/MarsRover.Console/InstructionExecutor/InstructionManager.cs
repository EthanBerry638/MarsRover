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
            if (instructions.Count == 0) return rover.CurrentPosition;

            foreach (Instruction instruction in instructions)
            {
                if (instruction == Instruction.M) rover.Move(instruction);
                else rover.Rotate(instruction);

                rover.CollisionCheck(plateau);
            }

            return rover.CurrentPosition;
        }
    }
}