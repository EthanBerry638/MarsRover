using NUnit.Framework;
using MarsRover.Console.Parsers;

namespace MarsRover.Tests;

public class PlateauParserTests
{
    [Test]
    public void ParseRawPlateau_ShouldReturnEmptyArray_WhenGivenEmptyString()
    {
        string input = "";
        int[] expected = [];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void ParseRawPlateau_ShouldReturnEmptyArray_WhenGivenNull()
    {
        string? input = null;
        int[] expected = [];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void ParseRawPlateau_ShouldReturnEmptyArray_WhenGivenStringWithOneNumber()
    {
        string input = "3";
        int[] expected = [];

        int [] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void ParseRawPlateau_ShouldReturnEmptyArray_WhenGivenStringWithOneLetter()
    {
        string input = "A";
        int[] expected = [];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }
}