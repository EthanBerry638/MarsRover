using MarsRover.Console.Data;

namespace MarsRover.Console.Plateaus
{
    public class Plateau(PlateauSize size)
    {
        public PlateauSize Size { get; private set; } = size;
    }
}