﻿using Ladeskab.Events;
using Ladeskab.RfidReader;
using NUnit.Framework;

namespace RfidReaderTest
{
    [TestFixture]
    public class TestRfidReader
    {
        private RfidReader _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new RfidReader();

        }



        [Test]
        public void RfidRead_Raises_Event()
        {
            
            bool WasRaised = false;
            int Id = -1;
            object _sender = null;

            void MockHandler(object sender, RfidReadEventArgs e)
            {
                WasRaised = true;
                Id = e.Id;
                _sender = sender;
            }

            _uut.ReadIdEvent += MockHandler;
            _uut.Read(5);

            Assert.That(WasRaised, Is.EqualTo(true));
            Assert.That(Id, Is.EqualTo(5));
            Assert.That(_sender, Is.EqualTo(_uut));

        }

    }
}
