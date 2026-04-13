using MarsRover.Console.Directions;
using MarsRover.Console.Parsers;
using NUnit.Framework;

namespace MarsRover.Tests;

public class InstructionParserTests
{
    [Test]
    public void ParseInstruction_ShouldReturnNull_WhenGivenEmptyString()
    {
        string input = "";
        string expected = "";

        string result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}