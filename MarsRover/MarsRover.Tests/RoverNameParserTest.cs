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
    }
}
