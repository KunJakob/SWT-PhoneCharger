using Ladeskab.ChargeControl;
using Ladeskab.Door;
using Ladeskab.Events;
using Ladeskab.RfidReader;
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
        private bool _doorState;
        private int _oldId;
        private int _currentId;

        //dependeny instances
        private IChargeControl _charger;
        private IDoor _door;
        private IRfidReader _rfidReader;

        private readonly string logFile = "logfile.txt"; // Navnet på systemets log-fil

        
        public StationControl(IChargeControl Charger, IDoor Door, IRfidReader RfidReader)
        {
            _charger = Charger;
            _door = Door;
            _rfidReader = RfidReader;
            _door.DoorChangeEvent += HandleDoorChange;
            _rfidReader.ReadIdEvent += HandleRfidRead;
        }

        public void HandleDoorChange(object sender, DoorChangeEventArgs e)
        {
            _doorState = e.IsOpen;
            if (_doorState)
            {
                //?
            } else
            {
                //?
            }
        }

        public void HandleRfidRead(object sender, RfidReadEventArgs e)
        {
            _currentId = e.Id;
            RfidDetected(_currentId);
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
    }
}
