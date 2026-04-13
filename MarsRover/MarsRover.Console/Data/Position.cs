using MarsRover.Console.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Console.Data
{
    public record Position (int X, int Y, CompassDirection Facing)
    {
        public int x = X;
        public int y = Y;
        public CompassDirection facing { get; set; } = Facing;
    }
}