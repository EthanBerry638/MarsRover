using MarsRover.Console.Parsers;

namespace MarsRover.Tests
{
    public class RoverNameParserTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("              ")]
        public void RoverNameParser_ShouldReturnNull_WhenGivenNullOrEmptyString(string? input)
        {
            string? result = RoverNameParser.GetRawName(input!);

            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        public void RoverNameParser_ShouldReturnName_WhenGivenAValidString()
        {
            string input = "Ethan";

            string? result = RoverNameParser.GetRawName(input);

            Assert.That(result, Is.EqualTo(input));
        }

        [Test]
        public void RoverName_ShouldFormatNameIntoACleanString_WhenGivenNameWithLeadingAndTrailingWhitespace()
        {
            string input = "    Ethan      ";
            string expected = "Ethan";

            string? result = RoverNameParser.GetRawName(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
