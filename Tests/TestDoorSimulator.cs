using NSubstitute;
using NUnit.Framework;
using RfidSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoorSimulator.Test
{
    [TestFixture]
    public class TestDoorSimulator
    {
        private DoorClassSimulator _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new DoorClassSimulator();
            var _rfidsub = Substitute.For<IRfidReader>();

        }

        

        [Test]
        public void Simulate_Door_Open()
        {
            _uut.UnlockDoor();
            Assert.That(_uut.IsDoorUnlocked, Is.EqualTo(true));
        }

        [Test]
        public void Simulate_Door_Close()
        {
            _uut.LockDoor();
            Assert.That(_uut.IsDoorUnlocked, Is.EqualTo(false));
        }

        [Test]
        public void Simulate_UnlockedDoor_OnDoorOpen_ReturnsOpen()
        {
            _uut.UnlockDoor();
            _uut.OnDoorOpen();
            Assert.That(_uut.IsDoorOpen, Is.EqualTo(true));
        }

        [Test]
        public void Simulate_LockedDoor_OnDoorOpen_ReturnsClosed()
        {
            _uut.LockDoor();
            _uut.OnDoorOpen();
            Assert.That(_uut.IsDoorOpen, Is.EqualTo(false));
        }

        [Test]
        public void Simulate_UnlockedDoor_OnDoorClose_ReturnsClosed()
        {
            _uut.UnlockDoor();
            _uut.OnDoorClose();
            Assert.That(_uut.IsDoorOpen, Is.EqualTo(false));
        }

        [Test]
        public void Simulate_LockedDoor_OnDoorClose_ReturnsOpen()
        {
            _uut.UnlockDoor();
            _uut.OnDoorOpen();
            _uut.LockDoor();
            _uut.OnDoorClose();
            Assert.That(_uut.IsDoorOpen, Is.EqualTo(true));
        }

    }
}
