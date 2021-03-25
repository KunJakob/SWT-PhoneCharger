using Ladeskab.Door;
using Ladeskab.RfidReader;
using Ladeskab.Events;
using NSubstitute;
using NUnit.Framework;

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
        public void LockDoor_Raises_Event_With_IsLocked_True()
        {

            bool WasRaised = false;
            bool IsLocked = false;
            object _sender = null;

            void MockHandler(object sender, DoorLockEventArgs e)
            {
                WasRaised = true;
                IsLocked = e.isLocked;
                _sender = sender;
            }

            _uut.DoorLockEvent += MockHandler;
            _uut.LockDoor();

            Assert.That(WasRaised, Is.EqualTo(true));
            Assert.That(IsLocked, Is.EqualTo(true));
            Assert.That(_sender, Is.EqualTo(_uut));
        }

        [Test]
        public void Unlock_Door_Raises_Event_With_IsLocked_False()
        {
            bool WasRaised = false;
            bool IsLocked = true;
            object _sender = null;

            void MockHandler(object sender, DoorLockEventArgs e)
            {
                WasRaised = true;
                IsLocked = e.isLocked;
                _sender = sender;
            }

            _uut.DoorLockEvent += MockHandler;
            _uut.UnlockDoor();

            Assert.That(WasRaised, Is.EqualTo(true));
            Assert.That(IsLocked, Is.EqualTo(false));
            Assert.That(_sender, Is.EqualTo(_uut));
        }

        [Test]
        public void OpenDoor_Raises_Event_With_IsOpen_True()
        {
            bool WasRaised = false;
            bool IsOpen = false;
            object _sender = null;

            void MockHandler(object sender, DoorOpenEventArgs e)
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
        public void CloseDoor_Raises_Event_With_IsOpen_False()
        {
            bool WasRaised = false;
            bool IsOpen = true;
            object _sender = null;

            void MockHandler(object sender, DoorOpenEventArgs e)
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



    }
}
