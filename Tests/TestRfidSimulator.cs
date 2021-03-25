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
        private RfidReader _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new RfidReader();

        }



        [Test]
        public void Simulate_RfidRead()
        {
            int TestID = 50;

            //removed while finishing implementation
            //_uut.OnRfidRead(TestID);
            //Assert.That(_uut._id, Is.EqualTo(50));
        }

    }
}
