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

    [Test]
    public void ParseRawPlateau_ShouldReturnArrayWith2Numbers_WhenGivenStringWithTwoNumbersSeperatedBySpace()
    {
        string input = "5 5";
        int[] expected = [5, 5];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void ParseRawPlateau_ShouldReturnEmptyArray_WhenGivenThreeNumbers()
    {
        string input = "5 5 5";
        int[] expected = [];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void ParseRawPlateau_ShouldReturnArrayWith2Numbers_WhenGivenNumberWithExtraSpaces()
    {
        string input = " 5  5  ";
        int[] expected = [5, 5];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void ParseRawPlateau_ShouldReturnEmptyArray_WhenGivenOneNumberAndOneLetter()
    {
        string input = "5 A";
        int[] expected = [];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void ParseRawPlateau_ShouldReturnEmptyArray_WhenGivenTwoNegativeNumbers()
    {
        string input = "-4 -3";
        int[] expected = [];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void GetPlateauSize_ShouldThrowExceptionWhenGivenEmptyArray()
    {
        int[] input = [];

        var ex = Assert.Throws<ArgumentException>(() => PlateauParser.GetPlateauSize(input));
    }
}