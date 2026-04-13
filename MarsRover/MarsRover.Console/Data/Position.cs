using MarsRover.Console.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Console.Data
{
    public record Position (int x, int y, CompassDirection facing)
    {
        public int X = x;
        public int Y = y;
        public CompassDirection Facing { get; set; } = facing;
    }
}