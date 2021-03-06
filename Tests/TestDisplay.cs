using NUnit.Framework;
using System;
using System.IO;

namespace ChargerLocker.Display.Test
{
    [TestFixture]
    public class DisplayTest
    {
        private Display _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new Display();
            

        }

        [TestCase("Test")]
        [TestCase("1234")]
        [TestCase("")]
        public void NotifyStation_OutputIsCorrect(string testVar)
        {

            var output = new StringWriter();
            Console.SetOut(output);

            _uut.NotifyStation(testVar);

            var expectedOutput = "######### " +"Station - " + DateTime.Now.ToString() + " #########" +
                "\r\n"+ testVar + "\n\r\n";

            Assert.That(output.ToString(), Is.EqualTo(expectedOutput));
        }
        [TestCase("Test")]
        [TestCase("1234")]
        [TestCase("")]
        public void NotifyCharge_OutputIsCorrect(string testVar)
        {

            var output = new StringWriter();
            Console.SetOut(output);

            _uut.NotifyCharge(testVar);

            var expectedOutput = "######### "+ "Charge - " + DateTime.Now.ToString() + " #########" +
                "\r\n"+ testVar + "\n\r\n";

            Assert.That(output.ToString(), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void NotifyCharge_DuplicateCall_ReturnsNoPrint()
        {

            _uut.NotifyCharge("test");
            var output = new StringWriter();
            Console.SetOut(output);

            _uut.NotifyCharge("test");

            var expectedOutput = "";

            Assert.That(output.ToString(), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void NotifyStation_DuplicateCall_ReturnsNoPrint()
        {

            _uut.NotifyStation("test");
            var output = new StringWriter();
            Console.SetOut(output);

            _uut.NotifyStation("test");

            var expectedOutput = "";

            Assert.That(output.ToString(), Is.EqualTo(expectedOutput));
        }

        [TestCase("Test")]
        [TestCase("1234")]
        public void ReadInput_DifferentTypesOfInput_Success(string testVar)
        {
            var input = new StringReader(testVar);
            Console.SetIn(input);
            string output = _uut.ReadInput();


            Assert.That(output, Is.EqualTo(testVar));
        }
        [Test]
        public void ReadInput_emptystring_returnsNull()
        {
            var input = new StringReader("");
            Console.SetIn(input);
            string output = _uut.ReadInput();


            Assert.That(output, Is.EqualTo(null));
        }
    }
}
