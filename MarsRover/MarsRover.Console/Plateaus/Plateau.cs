using MarsRover.Console.Data;
using MarsRover.Console.Rovers;
using System.ComponentModel.Design;

namespace MarsRover.Console.Plateaus
{
    public class Plateau (PlateauSize size)
    {
        public PlateauSize Size { get; private set; } = size;
    }
}