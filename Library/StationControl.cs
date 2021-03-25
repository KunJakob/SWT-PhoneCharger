using Ladeskab.ChargeControl;
using Ladeskab.Door;
using Ladeskab.Events;
using Ladeskab.RfidReader;
using Ladeskab.Logger;
using Ladeskab.Display;
using System;
using System.IO;
namespace Ladeskab.StationControl
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        //state vars
        private LadeskabState _state;
        private int _oldId;

        //dependeny instances
        private IChargeControl _charger;
        private IDoor _door;
        private IRfidReader _rfidReader;
        private ILogger _logger;
        private IDisplay _display;

        private readonly string logFile = "logfile.txt"; // Navnet på systemets log-fil


        public StationControl(IChargeControl Charger, IDoor Door, IRfidReader RfidReader, IDisplay Display, ILogger Logger)
        {
            _charger = Charger;
            _door = Door;
            _rfidReader = RfidReader;
            _logger = Logger;
            _display = Display;
            _state = LadeskabState.Available;
            _door.DoorChangeEvent += new EventHandler<DoorOpenEventArgs>(HandleDoorChange);
            _rfidReader.ReadIdEvent += new EventHandler<RfidReadEventArgs>(HandleRfidRead);
        }

        protected virtual void HandleDoorChange(object sender, DoorOpenEventArgs e)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    if (e.IsOpen)
                        _state = LadeskabState.DoorOpen;
                    _display.notifyStation("Connect your phone");
                    break;
                case LadeskabState.DoorOpen:
                    if (!e.IsOpen)
                        _state = LadeskabState.Available;
                    _display.notifyStation("Scan RFID");
                    break;
                case LadeskabState.Locked:
                    //ignore
                    break;
            }
        }


        protected virtual void HandleRfidRead(object sender, RfidReadEventArgs e)
        {
            RfidDetected(e.Id);
        }


        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected)
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        _logger.WriteToLog("Locked with RFID: " + id);

                        _display.notifyStation("The locker is locked and your phone is charging. Use your RFID tag to unlock it.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.notifyStation("Your phone is not connected properly. Try again");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();

                        _logger.WriteToLog("Locker unlocked with RFID: " + id);


                        _display.notifyStation("Grab your phone and close the door");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.notifyStation("Wrong RFID tag");
                    }

                    break;
            }
        }
    }
}
