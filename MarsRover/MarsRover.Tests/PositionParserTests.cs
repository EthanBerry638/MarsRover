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

    [Test]
    public void RawPositionParser_ShouldReturnEmptyString_WhenGivenTwoNumbersButADirectionThatIsNotOnTheCompass()
    {
        string input = "1 2 A";
        string expected = "";

        string result = PositionParser.RawPositionParser(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void RawPositionParser_ShouldReturnEmptyString_WhenGivenANegativeNumber()
    {
        string input = "-1 5 E";
        string expected = "";

        string result = PositionParser.RawPositionParser(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void RawPositionParser_ShouldReturnEmptyString_WhenGivenANumberThatIsNotAnInteger()
    {
        string input = "1.2 3 W";
        string expected = "";

        string result = PositionParser.RawPositionParser(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void IsValidPosition_ShouldReturnFalse_WhenGivenAnEmptyString()
    {
        string input = "";
        bool expected = false;

        bool result = PositionParser.IsValidPosition(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void IsValidPosition_ShouldReturnTrue_WhenGivenAStringThatIsNotEmpty()
    {
        string input = "1 2 A";

        bool result = PositionParser.IsValidPosition(input);

        Assert.That(result, Is.True);
    }
}