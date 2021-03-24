using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Door
{
    public class DoorClassSimulator : IDoor
    {

        private bool IsDoorUnlocked { get; set; }
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

        public void OnDoorOpen()
        {
            throw new NotImplementedException();
        }

        public void OnDoorClose()
        {
            throw new NotImplementedException();
        }
    }
}
