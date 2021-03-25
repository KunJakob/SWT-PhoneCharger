using Ladeskab.Door;
using Ladeskab.RfidReader;
using Ladeskab.Events;
using NSubstitute;
using NUnit.Framework;
using System;

namespace DoorSimulator.Test
{
    [TestFixture]
    public class TestDoor
    {
        private Door _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Door();

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

            void MockHandler(object sender, DoorOpenEventArgs e)
            {
                WasRaised = true;
                IsOpen = e.IsOpen;
                _sender = sender;
            } /*
               * See my comment on the next MockHandler
               */

            _uut.DoorChangeEvent += new EventHandler<DoorOpenEventArgs>(MockHandler);
            _uut.OpenDoor();

            Assert.That(WasRaised, Is.EqualTo(true));
            Assert.That(IsOpen, Is.EqualTo(true));
            Assert.That(_sender, Is.EqualTo(_uut));
        }

        [Test]
        public void OpenDoor_Does_Not_Raise_Event_If_Locked()
        {
            bool WasRaised = false;
            bool IsOpen = false;
            object _sender = null;

            _uut.LockDoor();

            void MockHandler(object sender, DoorOpenEventArgs e)
            {
                WasRaised = true;
                IsOpen = e.IsOpen;
                _sender = sender;
            } /* This is a mock for the test, it is supposed to fail, so the coverage report on jenkins gives some warnings.
               * This is supposed to happen. */

            _uut.DoorChangeEvent += new EventHandler<DoorOpenEventArgs>(MockHandler);
            _uut.OpenDoor();

            Assert.That(WasRaised, Is.EqualTo(false));
            Assert.That(IsOpen, Is.EqualTo(false));
            Assert.That(_sender, Is.EqualTo(null));
        }

        [Test]
        public void CloseDoor_Raises_Event_If_Unlocked()
        {
            bool WasRaised = false;
            bool IsOpen = true;
            object _sender = null;

            _uut.UnlockDoor();

            void MockHandler(object sender, DoorOpenEventArgs e)
            {
                WasRaised = true;
                IsOpen = e.IsOpen;
                _sender = sender;
            }

            _uut.DoorChangeEvent += new EventHandler<DoorOpenEventArgs>(MockHandler);
            _uut.CloseDoor();

            Assert.That(WasRaised, Is.EqualTo(true));
            Assert.That(IsOpen, Is.EqualTo(false));
            Assert.That(_sender, Is.EqualTo(_uut));
        }

        [Test]
        public void CloseDoor_Does_Not_Raise_Event_If_Locked()
        {
            bool WasRaised = false;
            bool IsOpen = true;
            object _sender = null;

            _uut.LockDoor();

            void MockHandler(object sender, DoorOpenEventArgs e)
            {
                WasRaised = true;
                IsOpen = e.IsOpen;
                _sender = sender;
            }

            _uut.DoorChangeEvent += new EventHandler<DoorOpenEventArgs>(MockHandler);
            _uut.CloseDoor();

            Assert.That(WasRaised, Is.EqualTo(false));
            Assert.That(IsOpen, Is.EqualTo(true));
            Assert.That(_sender, Is.EqualTo(null));
        }



    }
}
