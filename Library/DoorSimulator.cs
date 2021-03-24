using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorSimulator
{
    public class DoorClassSimulator : IDoor
    {

        public bool IsDoorUnlocked { get; set; }
        public bool IsDoorOpen { get; set; }
        public DoorClassSimulator()
        {
            IsDoorUnlocked = true;
            IsDoorOpen = false;
        }

        public void LockDoor()
        {
            IsDoorUnlocked = false;
        }
        public void UnlockDoor()
        {
            IsDoorUnlocked = true;
        }

        public void OnDoorClose()
        {
            if (IsDoorUnlocked)
            {
                if (IsDoorOpen)
                {
                    IsDoorOpen = false;
                    Console.WriteLine("Door is closed");
                }
            }
        }

        public void OnDoorOpen()
        { 
            if (!IsDoorOpen) 
            { 
                IsDoorOpen = true;
                Console.WriteLine("Door is open, please connect your phone to the charger.");
            }
        }

    }
}
