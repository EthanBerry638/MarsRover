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

    [Test]
    [TestCase("l", "L")]
    [TestCase("r", "R")]
    [TestCase("m", "M")]
    public void ParseInstruction_ShouldReturnSingleInstruction_WhenGivenSingleLowerCaseValidInstruction(string input, string expected)
    {
        string result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ParseInstruction_ShouldReturnEveryLetter_WhenGivenMultipleCorrectLetters()
    {
        string input = "LRM";
        string expected = "LRM";

        string result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ParseInstruction_ShouldReturnNothing_WhenGivenMultipleIncorrectCorrectLetters()
    {
        string input = "OGTIKNSFDBG";
        string expected = "";

        string result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ParseInstructions_ShouldOnlyReturnValidLetters_WhenGivenAMixOfValidAndInvalidLetters()
    {
        string input = "jssjefnjLajjwjRaderrrM";
        string expected = "LRRRRM";

        string result = InstructionParser.ParseInstruction(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetInstructions_ShouldReturnEmptyList_WhenGivenEmptyString()
    {
        string input = "";
        List<Instruction> expected = new List<Instruction>();

        List<Instruction> result = InstructionParser.GetInstructions(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetInstructions_ShouldReturnListWithOneItem_WhenGivenOneInstruction()
    {
        string input = "L";
        List<Instruction> expected = new List<Instruction> { Instruction.L };

        List<Instruction> result = InstructionParser.GetInstructions(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetInstructions_ShouldReturnListWithMultipleItems_WhenGivenMultipleInstructions()
    {
        string input = "LLRMRL";
        List<Instruction> expected = new List<Instruction>
        {
            Instruction.L,
            Instruction.L,
            Instruction.R,
            Instruction.M,
            Instruction.R,
            Instruction.L
        };

        List<Instruction> result = InstructionParser.GetInstructions(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}