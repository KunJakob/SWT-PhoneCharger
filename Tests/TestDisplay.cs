using NUnit.Framework;
using System;
using System.IO;

namespace Ladeskab.Display.Text
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
                "\r\n"+ testVar +"\r\n";

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
                "\r\n"+ testVar + "\r\n";

            Assert.That(output.ToString(), Is.EqualTo(expectedOutput));
        }

        //The method behind this test is, our output into console should still only be one call worth of text, as the 2nd call will fail due to being the same call.
        [Test]
        public void Notify_DuplicateCallFails()
        {

            var output = new StringWriter();
            Console.SetOut(output);

            _uut.NotifyCharge("test");
            _uut.NotifyCharge("test");

            var expectedOutput = "######### " + "Charge - " + DateTime.Now.ToString() + " #########" +
                "\r\n" + "test" + "\r\n";

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
