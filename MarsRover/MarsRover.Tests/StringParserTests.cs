using MarsRover.Console.Directions;
using MarsRover.Console.Parsers;
using NUnit.Framework;

namespace MarsRover.Tests;

public class InstructionParserTests
{
    [Test]
    public void ParseInstruction_ShouldReturnEmpty_WhenGivenEmptyString()
    {
        string input = "";
        string expected = "";

        string result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ParseInstruction_ShouldReturnEmpty_WhenGivenNull()
    {
        string input = null;
        string expected = "";

        string result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ParseInstruction_ShouldReturnNothing_WhenGivenSingleInvalidInstruction()
    {
        string input = "A";
        string expected = "";

        string result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ParseInstruction_ShouldReturnSingleInstruction_WhenGivenSingleValidInstruction()
    {
        string input = "L";
        string expected = "L";

        string result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ParseInstruction_ShouldReturnSingleInstruction_WhenGivenLowerCaseSingleValidInstruction()
    {
        string input = "l";
        string expected = "L";

        string result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase("L", "L")]
    [TestCase("R", "R")]
    [TestCase("M", "M")]
    public void ParseInstruction_ShouldReturnSingleInstruction_WhenGivenSingleUpperCaseValidInstruction(string input, string expected)
    {
        string result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}