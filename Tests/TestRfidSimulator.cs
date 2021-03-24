using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using Ladeskab;
using Ladeskab.Interfaces;
using DoorSimulator;

namespace RfidSimulator.Test
{
    [TestFixture]
    public class TestRfidSimulator
    {
        private RfidReaderSimulator _uut;

        [SetUp]
        public void Setup()
        {
            var Door = Substitute.For<IDoor>();
            var CC = Substitute.For<IChargeControl>();
            var SC = Substitute.For<StationControl>(Door, CC);
            _uut = new RfidReaderSimulator(SC);

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
