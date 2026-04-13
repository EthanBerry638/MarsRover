using NUnit.Framework;
using MarsRover.Console.Parsers;

namespace MarsRover.Tests;

public class PlateauParserTests
{
    [Test]
    public void ParseRawPlateau_ShouldReturnArrayWith2Elements_WhenGivenEmptyString()
    {
        string input = "";
        int[] expected = new int[2];

        int[] result = PlateauParser.ParseRawPlateau(input);

        Assert.That(expected, Is.EqualTo(result));
    }
}