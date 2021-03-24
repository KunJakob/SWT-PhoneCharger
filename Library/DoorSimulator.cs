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
        public DoorClassSimulator()
        {
            IsDoorUnlocked = true;
        }

        public void LockDoor()
        {
            IsDoorUnlocked = false;
        }
        public void UnlockDoor()
        {
            IsDoorUnlocked = true;
        }

    }
}
