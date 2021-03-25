using ChargerLocker.Events;
using System;

namespace ChargerLocker.Door
{
    public interface IDoor
    {
        public event EventHandler<DoorOpenEventArgs> DoorChangeEvent;
        public void LockDoor();
        public void UnlockDoor();
        public bool OpenDoor();
        public bool CloseDoor();
    }
}
