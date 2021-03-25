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
    }
}
