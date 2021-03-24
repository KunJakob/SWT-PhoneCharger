using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
