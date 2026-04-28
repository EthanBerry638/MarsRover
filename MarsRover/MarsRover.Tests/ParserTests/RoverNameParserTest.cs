using MarsRover.Console.Parsers;

namespace MarsRover.Tests.ParserTests
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

        [Test]
        [TestCase("Ethan123")]
        [TestCase("123Ethan")]
        [TestCase("E1t2h3a4n")]
        public void RoverNameParser_ShouldStripNumbers_WhenStringIsAlphaNumeric(string input)
        {
            string expected = "Ethan";

            string? result = RoverNameParser.GetFormattedName(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("e")]
        [TestCase("E")]
        public void RoverNameParser_ShouldWorkCorrectly_WhenGivenASingleCharacter(string input)
        {
            string expected = "E";

            string? result = RoverNameParser.GetFormattedName(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("rené", "René")]
        [TestCase("ÖZIL", "Özil")]
        public void RoverNameParser_ShouldSupportUnicodeLetters(string input, string expected)
        {
            string? result = RoverNameParser.GetFormattedName(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("Bob Smith", "Bobsmith")]
        [TestCase("Ethan-Berry", "Ethanberry")]
        public void RoverNameParser_ShouldRetainSingleNameFormatting_WhenGivenStringsSeperatedByHyphensOrSpaces(string input, string expected)
        {
            string? result = RoverNameParser.GetFormattedName(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
