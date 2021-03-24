using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorSimulator
{
    public interface IDoor
    {

        public void OnDoorOpen();
        public void OnDoorClose();
        public void LockDoor();
        public void UnlockDoor();
    }

    public class Door : IDoor
    {
        public void LockDoor()
        {
            Console.WriteLine("Door is locked");
            //throw new NotImplementedException();
        }

        public void OnDoorClose()
        {
            Console.WriteLine("Door is closed");
            //throw new NotImplementedException();
        }

        public void OnDoorOpen()
        {
            Console.WriteLine("Door is opened");
            //throw new NotImplementedException();
        }

        public void UnlockDoor()
        {
            Console.WriteLine("Door is unlocked");
            //throw new NotImplementedException();
        }
    }
}
