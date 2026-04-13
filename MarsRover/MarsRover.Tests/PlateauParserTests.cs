using NUnit.Framework;
using MarsRover.Console.Parsers;

namespace MarsRover.Tests;

public class PlateauParserTests
{
    [Test]
    public void ParseRawPlateau_ShouldReturnEmptyArray_WhenGivenEmptyString()
    {
        string input = "";
        int[] expected = new int[0];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void ParseRawPlateau_ShouldReturnEmptyArray_WhenGivenNull()
    {
        string input = null;
        int[] expected = new int[0];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void ParseRawPlateau_ShouldReturnArrayWithSizeOf2But1Value_WhenGivenStringWithOneNumber()
    {
        string input = "3";
        int[] expected = new int[2];
        expected[0] = 3;

        int [] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void ParseRawPlateau_ShouldReturnArrayWithSizeOf2ButNoValue_WhenGivenStringWithOneLetter()
    {
        string input = "A";
        int[] expected = new int[2];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }
}