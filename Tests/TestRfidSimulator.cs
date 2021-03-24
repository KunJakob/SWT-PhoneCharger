using Ladeskab.ChargeControl;
using Ladeskab.Door;
using Ladeskab.RfidReader;
using Ladeskab.StationControl;
using NSubstitute;
using NUnit.Framework;

namespace RfidSimulator.Test
{
    [TestFixture]
    public class TestRfidSimulator
    {
        private RfidReaderSimulator _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new RfidReaderSimulator();

        }



        [Test]
        public void Simulate_RfidRead()
        {
            int TestID = 50;

            _uut.OnRfidRead(TestID);

            Assert.That(_uut._id, Is.EqualTo(50));
        }

    }
}
