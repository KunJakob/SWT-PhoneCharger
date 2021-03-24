using NUnit.Framework;
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
        private DoorSimulator _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new DoorSimulator();
        }

        

        [Test]
        public void SimulateDisconnected_Start_ReceivesZeroValueImmediately()
        {
        }

        [Test]
        public void StopCharge_IsCharging_ReceivesZeroValue()
        {
        }

        [Test]
        public void StopCharge_IsCharging_PropertyIsZero()
        {
        }

        [Test]
        public void StopCharge_IsCharging_ReceivesNoMoreValues()
        {
        }

    }
}
