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
            string? result = RoverNameParser.GetFormattedName(input!);

            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        public void RoverNameParser_ShouldReturnName_WhenGivenAValidString()
        {
            string input = "Ethan";
            string expected = "Ethan";

            string? result = RoverNameParser.GetFormattedName(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RoverNameParser_ShouldFormatNameIntoACleanString_WhenGivenNameWithLeadingAndTrailingWhitespace()
        {
            string input = "    Ethan      ";
            string expected = "Ethan";

            string? result = RoverNameParser.GetFormattedName(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RoverNameParser_ShouldCapitaliseFirstLetterOfString_WhenGivenNameWithLowerCaseFirstChar()
        {
            string input = "ethan";
            string expected = "Ethan";

            string? result = RoverNameParser.GetFormattedName(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("%%3##';#3")]
        [TestCase("0595850450")]
        public void RoverNameParser_ShouldReturnNull_WhenOnlyGivenPunctuationOrNumbers(string input)
        {
            string? expected = null;

            string? result = RoverNameParser.GetFormattedName(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RoverNameParser_ShouldCleanUpperCaseLettersInMiddleOfStringToLowerCase_WhenGivenStringWithSomeLowerCaseLetters()
        {
            string input = "EtHAn";
            string expected = "Ethan";

            string? result = RoverNameParser.GetFormattedName(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
