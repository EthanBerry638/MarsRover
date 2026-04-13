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

        public CompassDirection Rotate (CompassDirection start, CompassDirection rotation)
        {
            return CompassDirection.N;
        }
    }
}