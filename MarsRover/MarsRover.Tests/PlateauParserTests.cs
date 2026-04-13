using NUnit.Framework;
using MarsRover.Console.Parsers;

namespace MarsRover.Tests;

public class PlateauParserTests
{
    [Test]
    public void ParseRawPlateau_ShouldReturnEmptyArrayOfInts_WhenGivenEmptyString()
    {
        string input = "";
        int[] expected = [];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }
}