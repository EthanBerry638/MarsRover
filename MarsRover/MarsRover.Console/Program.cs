using MarsRover.Console.Data;
using MarsRover.Console.Directions;
using MarsRover.Console.Parsers;

string rawInstruction = InstructionParser.ParseInstruction("LMLMLMLMM");
List<Instruction> instructions = InstructionParser.GetInstructions(rawInstruction);

foreach (Instruction instruction in instructions) Console.WriteLine(instruction);

int[] rawPlateau = PlateauParser.ParseRawPlateau("5 5");
PlateauSize plateau = PlateauParser.GetPlateauSize(rawPlateau);

Console.WriteLine("\n" + plateau);

string rawPosition = PositionParser.RawPositionParser("3 3 E");
Position position = PositionParser.GetPosition(rawPosition, plateau);

Console.WriteLine("\n" + position);