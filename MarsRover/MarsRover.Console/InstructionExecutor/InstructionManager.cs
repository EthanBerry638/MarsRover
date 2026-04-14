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

                if (plateau.IsBordering(rover.CurrentPosition))
                {
                    Dictionary<string, int> borderingAxis = plateau.GetCollidingAxis(rover.CurrentPosition);
                };
            }

            return rover.CurrentPosition;
        }

        public static Position CorrectCollision(Dictionary<string, int> borderingAxis, Rover rover, Plateau plateau)
        {
            if (borderingAxis.Count == 0) return rover.CurrentPosition;

            foreach (var keyValue in borderingAxis)
            {
                if (keyValue.Key == "X")
                {
                    if (keyValue.Value > 0) rover.CurrentPosition.X = plateau.Size.X;
                    else rover.CurrentPosition.X = 0;
                }

                if (keyValue.Key == "Y")
                {
                    if (keyValue.Value > 0) rover.CurrentPosition.Y = plateau.Size.Y;
                    else rover.CurrentPosition.Y = 0;

                }
            }

            return rover.CurrentPosition;
        }
    }
}