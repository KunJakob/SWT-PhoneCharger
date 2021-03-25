using Ladeskab.Door;
using Ladeskab.RfidReader;
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
        public void Simulate_Door_Open()
        {
            _uut.UnlockDoor();
            //Assert.That(_uut.IsDoorUnlocked, Is.EqualTo(true));
        }

        [Test]
        public void Simulate_Door_Close()
        {
            _uut.LockDoor();
            //Assert.That(_uut.IsDoorUnlocked, Is.EqualTo(false));
        }

    }
}
