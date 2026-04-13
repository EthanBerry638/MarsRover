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
}