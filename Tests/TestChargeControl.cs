using NUnit.Framework;
using Ladeskab.ChargeControl;
using Ladeskab.Events;
using Ladeskab.UsbCharger;
using Ladeskab.Display;
using NSubstitute;

namespace Tests
{
    [TestFixture]
    class TestChargeControl
    {
        private ChargeControl _uut;
        private IDisplay _mockDisplay;
        private IUsbCharger _mockUsbCharger;

        [SetUp]
        public void Setup()
        {
            _mockDisplay = Substitute.For<IDisplay>();
            _mockUsbCharger = Substitute.For<IUsbCharger>();
            _uut = new ChargeControl(_mockUsbCharger, _mockDisplay);
        }

        [Test]
        [TestCase(0.0, "")]
        [TestCase(2.3, "Phone fully charged. It can be safely removed.")]
        [TestCase(152.7, "Phone is charging.")]
        [TestCase(515.1, "ERROR: Potential short circuit. Disconnect phone immediately.")]
        public void Calls_Display_Correctly_On_Current_Event(double Current, string ExpectedMessage)
        {
            //Arrange
            var e = new CurrentEventArgs() { Current = Current };
            //Act
            _mockUsbCharger.CurrentValueEvent += Raise.EventWith<CurrentEventArgs>(_mockUsbCharger, e);
            //Assert
            _mockDisplay.Received().notifyCharge(ExpectedMessage);
        }
        [Test]
        public void Connected_Returns_Usb_Connected()
        {
            //Arrange
            _mockUsbCharger.Connected.Returns(true);
            //Act
            var conn = _uut.Connected;
            //Assert
            Assert.That(conn, Is.EqualTo(true));

        }
        [Test]
        public void StartCharge_Calls_Usb_StartCharge()
        {
            //Act
            _uut.StartCharge();
            //Assert
            _mockUsbCharger.Received().StartCharge();
        }
        [Test]
        public void StopCharge_Calls_Usb_StopCharge()
        {
            //Act
            _uut.StopCharge();
            //Assert
            _mockUsbCharger.Received().StopCharge();
        }
    }
}
