using ChargerLocker.StationControl;
using ChargerLocker.Door;
using ChargerLocker.Display;
using ChargerLocker.Events;
using ChargerLocker.Logger;
using ChargerLocker.RfidReader;
using ChargerLocker.Events;
using ChargerLocker.ChargeControl;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace Tests
{
    [TestFixture]
    class TestStationControl
    {
        private StationControl _uut;
        private IChargeControl _chargeControl;
        private IDoor _door;
        private IRfidReader _rfidReader;
        private IDisplay _display;
        private ILogger _logger;
        [SetUp]
        public void SetUp()
        {
            _chargeControl = Substitute.For<IChargeControl>();
            _door = Substitute.For<IDoor>();
            _rfidReader = Substitute.For<IRfidReader>();
            _display = Substitute.For<IDisplay>();
            _logger = Substitute.For<ILogger>();

            _uut = new StationControl(
                _chargeControl,
                _door,
                _rfidReader,
                _display,
                _logger
                );
        }

        [Test]
        public void HandleDoorChange_Goes_From_Available_To_Open_If_Door_Opened()
        {
            //Act
            _door.DoorChangeEvent += Raise.EventWith<DoorOpenEventArgs>(_door, new DoorOpenEventArgs() { IsOpen = true });
            //Assert
            _display.Received().NotifyStation("Connect your phone");
        }

        [Test]
        public void HandleDoorChange_Stays_Available_If_Door_Closed()
        {
            //Act
            _door.DoorChangeEvent += Raise.EventWith<DoorOpenEventArgs>(_door, new DoorOpenEventArgs() { IsOpen = false });
            //Assert
            _display.DidNotReceive().NotifyStation(Arg.Any<string>());
        }

        [Test]
        public void HandleDoorChange_Goes_From_Open_To_Available_If_Door_Closed()
        {
            //Arrange
            _door.DoorChangeEvent += Raise.EventWith<DoorOpenEventArgs>(_door, new DoorOpenEventArgs() { IsOpen = true });
            //Act
            _door.DoorChangeEvent += Raise.EventWith<DoorOpenEventArgs>(_door, new DoorOpenEventArgs() { IsOpen = false });
            //Assert
            _display.Received().NotifyStation("Scan RFID");
        }

        [Test]
        public void HandleDoorChange_Ignores_Events_If_Locked()
        {
            //Arrange
            _rfidReader.ReadIdEvent += Raise.EventWith<RfidReadEventArgs>(_rfidReader, new RfidReadEventArgs() { Id = 5 });
            
            //Act
            _door.DoorChangeEvent += Raise.EventWith<DoorOpenEventArgs>(_door, new DoorOpenEventArgs() { IsOpen = false });
            //Assert
            _display.DidNotReceive().NotifyStation("Connect your phone");
            _display.DidNotReceive().NotifyStation("Scan RFID");
        }

        [Test]
        public void HandleRfidRead_Goes_From_Available_To_Locked_If_Connected()
        {
            _chargeControl.Connected.Returns(true);
            //Act
            _rfidReader.ReadIdEvent += Raise.EventWith<RfidReadEventArgs>(_rfidReader, new RfidReadEventArgs() { Id = 5 });
            //Assert
            _door.Received().LockDoor();
            _chargeControl.Received().StartCharge();
            _display.Received().NotifyStation("The locker is locked and your phone is charging. Use your RFID tag to unlock it.");
            _logger.Received().WriteToLog("Locked with RFID: 5");
        }

        [Test]
        public void HandleRfidRead_Errors_If_Disconnected()
        {
            //Arrange
            _chargeControl.Connected.Returns(false);
            //Act
            _rfidReader.ReadIdEvent += Raise.EventWith<RfidReadEventArgs>(_rfidReader, new RfidReadEventArgs() { Id = 5 });
            //Assert
            _display.Received().NotifyStation("Your phone is not connected properly. Try again");
        }

        [Test]
        public void HandleRfidRead_Goes_From_Locked_To_Available_If_Rfid_Match()
        {
            //Arrange
            _chargeControl.Connected.Returns(true);
            _rfidReader.ReadIdEvent += Raise.EventWith<RfidReadEventArgs>(_rfidReader, new RfidReadEventArgs() { Id = 5 });
            //Act
            _rfidReader.ReadIdEvent += Raise.EventWith<RfidReadEventArgs>(_rfidReader, new RfidReadEventArgs() { Id = 5 });
            //Assert
            _door.Received().UnlockDoor();
            _chargeControl.Received().StopCharge();
            _display.Received().NotifyStation("Grab your phone and close the door");
            _logger.Received().WriteToLog("Locker unlocked with RFID: 5");
        }
        [Test]
        public void HandleRfidRead_Errors_If_Locked_And_Rfid_Not_Match()
        {
            //Arrange
            _chargeControl.Connected.Returns(true);
            _rfidReader.ReadIdEvent += Raise.EventWith<RfidReadEventArgs>(_rfidReader, new RfidReadEventArgs() { Id = 5 });
            //Act
            _rfidReader.ReadIdEvent += Raise.EventWith<RfidReadEventArgs>(_rfidReader, new RfidReadEventArgs() { Id = 3 });
            //Assert
            _display.Received().NotifyStation("Wrong RFID tag");
        }
    }
}
