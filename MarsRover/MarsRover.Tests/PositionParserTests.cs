using MarsRover.Console.Parsers;
using NUnit.Framework;

namespace MarsRover.Tests;

public class PositionParserTests
{
    [Test]
    public void RawPositionParser_ShouldReturnEmptyString_WhenGivenNull()
    {
        string? input = null;
        string expected = "";

        string result = PositionParser.RawPositionParser(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void RawPositionParser_ShouldReturnEmptyString_WhenGivenEmptyString()
    {
        string? input = "";
        string expected = "";

        string result = PositionParser.RawPositionParser(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test] 
    public void RawPositionParser_ShouldReturnEmptyString_WhenGivenStringWithOneLetter()
    {
        string? input = "A";
        string expected = "";

        string result = PositionParser.RawPositionParser(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void RawPositionParser_ShouldReturnInput_WhenGivenCorrectlyFormattedString()
    {
        string? input = "1 2 N";
        string expected = "1 2 N";

        string result = PositionParser.RawPositionParser(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void RawPositionParser_ShouldReturnEmptyString_WhenGivenCorrectLengthStringButIncorrectFormat()
    {
        string? input = "A 2 N";
        string expected = "";

        string result = PositionParser.RawPositionParser(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void RawPositionParser_ShouldReturnInput_WhenGivenCorrectlyFormattedStringButLowerCaseLetter()
    {
        string input = "1 2 n";
        string expected = "1 2 N";

        string result = PositionParser.RawPositionParser(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void RawPositionParser_ShouldReturnInput_WhenGivenCorrectlyFormattedStringButWithExtraWhiteSpace()
    {
        string input = "    1     2       N    ";
        string expected = "1 2 N";

        string result = PositionParser.RawPositionParser(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}