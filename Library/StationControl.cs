using Ladeskab.ChargeControl;
using Ladeskab.Door;
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

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private int _oldId;
        private readonly IDoor _door;

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        public StationControl(IDoor Door, IChargeControl ChargeControl)
        {
            _door = Door;
            _charger = ChargeControl;
            _charger.Connected = false;
            _state = LadeskabState.Available;
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
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                        }

                        Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
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
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                        }

                        Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        Console.WriteLine("Forkert RFID tag");
                    }
                    

                    break;
            }
        }


        // Her mangler de andre trigger handlere
        public void OnDoorClose()
        {
            if (_state == LadeskabState.Locked)
            {
                Console.WriteLine("Door is Locked, please scan your RFID card to open.");
                return;
            }
            if (_state == LadeskabState.Available)
            {
                Console.WriteLine("You close the door without locking it.");
                return;
            }
            if (_state == LadeskabState.DoorOpen)
            {
                Console.WriteLine("Please scan your RFID card to lock.");
                _state = LadeskabState.Available;
            }
            
        }

        public void OnDoorOpen()
        {
            if(_state == LadeskabState.Locked)
            {
                Console.WriteLine("Door is locked, scan your RFID card to open.");
                return;
            }
            if (_state != LadeskabState.DoorOpen)
            {
                _state = LadeskabState.DoorOpen;
                Console.WriteLine("Door is open, type \"ok\" to connect your phone to the charger.");
                string input = Console.ReadLine();
                if (input == "ok")
                {
                    _charger.Connected = true;
                }
            }
        }

        public void OnRfidReadEvent(int id)
        {
            RfidDetected(id);
        }
    }
}
