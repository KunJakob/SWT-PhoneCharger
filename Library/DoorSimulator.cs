using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorSimulator
{
    public class DoorSimulator : IDoor
    {

        

        public bool IsDoorOpended { get; private set; }

        
        public void LockDoor()
        {
            throw new NotImplementedException();
        }

        public void OnDoorClose()
        {
            throw new NotImplementedException();
        }

        public void OnDoorOpen()
        {
            throw new NotImplementedException();
        }

        public void UnlockDoor()
        {
            throw new NotImplementedException();
        }
    }
}
