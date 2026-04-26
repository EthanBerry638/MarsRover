using MarsRover.Console.Data;
using MarsRover.Console.Directions;
using MarsRover.Console.Plateaus;
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

        private Position CorrectCollision(Dictionary<string, int> borderingAxis, Plateau plateau)
        {
            if (borderingAxis.Count == 0) return CurrentPosition;

            foreach (var keyValue in borderingAxis)
            {
                if (keyValue.Key == "X")
                {
                    if (keyValue.Value > 0) CurrentPosition.X = plateau.Size.X;
                    else CurrentPosition.X = 0;
                }

                if (keyValue.Key == "Y")
                {
                    if (keyValue.Value > 0) CurrentPosition.Y = plateau.Size.Y;
                    else CurrentPosition.Y = 0;

                }
            }

            return CurrentPosition;
        }

        public Position CollisionCheck(Plateau plateau)
        {
            if (plateau.IsBordering(CurrentPosition))
            {
                Dictionary<string, int> borderingAxis = plateau.GetCollidingAxis(CurrentPosition);

                return CorrectCollision(borderingAxis, plateau);
            }
            else return CurrentPosition;
        }
    }
}