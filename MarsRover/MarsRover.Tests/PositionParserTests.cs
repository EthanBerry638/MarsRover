using MarsRover.Console.Custom_Exceptions;
using MarsRover.Console.Data;
using MarsRover.Console.Directions;
using MarsRover.Console.Parsers;

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
    public void GetPosition_ShouldReturnExpected_WhenGivenAParsedString()
    {
        string input = "1 2 N";
        Position expected = new(1, 2, CompassDirection.N);
        PlateauSize plateau = new(5, 5);

        Position result = PositionParser.GetPosition(input, plateau);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetPosition_ShouldThrowException_WhenGivenAParsedStringButThePositionIsNotOnTheGrid()
    {
        string input = "20 20 N";

        PlateauSize plateau = new(5, 5);

        Assert.Throws<InvalidPositionException>(() => PositionParser.GetPosition(input, plateau));
    }

    [Test]
    [TestCase("")]
    public void GetPosition_ShouldThrowInvalidFormatException_WhenGivenBadInput(string input)
    {
        PlateauSize plateau = new(5, 5);

        Assert.Throws<InvalidPositionException>(() => PositionParser.GetPosition(input, plateau));
    }
}