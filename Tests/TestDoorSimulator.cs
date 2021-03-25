﻿using Ladeskab.Door;
using Ladeskab.RfidReader;
using Ladeskab.Events;
using NSubstitute;
using NUnit.Framework;

namespace DoorSimulator.Test
{
    [TestFixture]
    public class TestDoorSimulator
    {
        private Door _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Door();
            var _rfidsub = Substitute.For<IRfidReader>();

        }

        [Test]
        public void LockDoor_Disables_Door_Open_And_Close()
        {
            _uut.LockDoor();
            Assert.That(_uut.OpenDoor(), Is.EqualTo(false));
            Assert.That(_uut.CloseDoor(), Is.EqualTo(false));
        }

        [Test]
        public void UnLockDoor_Enables_Door_Open_And_Close()
        {
            _uut.UnlockDoor();
            Assert.That(_uut.OpenDoor(), Is.EqualTo(true));
            Assert.That(_uut.CloseDoor(), Is.EqualTo(true));
        }

        [Test]
        public void OpenDoor_Raises_Event_If_Unlocked()
        {
            _uut.UnlockDoor();
            bool WasRaised = false;
            bool IsOpen = false;
            object _sender = null;
            void MockHandler(object sender, DoorChangeEventArgs e)
            {
                WasRaised = true;
                IsOpen = e.IsOpen;
                _sender = sender;
            }
            _uut.DoorChangeEvent += MockHandler;
            _uut.OpenDoor();
            Assert.That(WasRaised, Is.EqualTo(true));
            Assert.That(IsOpen, Is.EqualTo(true));
            Assert.That(_sender, Is.EqualTo(_uut));
        }

        [Test]
        public void OpenDoor_Does_Not_Raise_Event_If_Locked()
        {
            _uut.LockDoor();
            bool WasRaised = false;
            bool IsOpen = false;
            object _sender = null;
            void MockHandler(object sender, DoorChangeEventArgs e)
            {
                WasRaised = true;
                IsOpen = e.IsOpen;
                _sender = sender;
            }
            _uut.DoorChangeEvent += MockHandler;
            _uut.OpenDoor();
            Assert.That(WasRaised, Is.EqualTo(false));
            Assert.That(IsOpen, Is.EqualTo(false));
            Assert.That(_sender, Is.EqualTo(null));
        }

        [Test]
        public void CloseDoor_Raises_Event_If_Unlocked()
        {
            _uut.UnlockDoor();
            bool WasRaised = false;
            bool IsOpen = true;
            object _sender = null;
            void MockHandler(object sender, DoorChangeEventArgs e)
            {
                WasRaised = true;
                IsOpen = e.IsOpen;
                _sender = sender;
            }
            _uut.DoorChangeEvent += MockHandler;
            _uut.CloseDoor();
            Assert.That(WasRaised, Is.EqualTo(true));
            Assert.That(IsOpen, Is.EqualTo(false));
            Assert.That(_sender, Is.EqualTo(_uut));
        }

        [Test]
        public void CloseDoor_Does_Not_Raise_Event_If_Locked()
        {
            _uut.LockDoor();
            bool WasRaised = false;
            bool IsOpen = true;
            object _sender = null;
            void MockHandler(object sender, DoorChangeEventArgs e)
            {
                WasRaised = true;
                IsOpen = e.IsOpen;
                _sender = sender;
            }
            _uut.DoorChangeEvent += MockHandler;
            _uut.CloseDoor();
            Assert.That(WasRaised, Is.EqualTo(false));
            Assert.That(IsOpen, Is.EqualTo(true));
            Assert.That(_sender, Is.EqualTo(null));
        }



    }
}
