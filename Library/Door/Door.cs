using Ladeskab.Events;
using System;

namespace Ladeskab.Door
{
    public class Door : IDoor
    {





        public Door()
        {
        }

        public event EventHandler<DoorOpenEventArgs> DoorChangeEvent;
        public event EventHandler<DoorLockEventArgs> DoorLockEvent;

        protected virtual void OnDoorChange(DoorOpenEventArgs e)
        {
            DoorChangeEvent?.Invoke(this, e);
        }

        protected virtual void OnDoorLock(DoorLockEventArgs e)
        {
            DoorLockEvent?.Invoke(this, e);
        }


        public void LockDoor()
        {
            OnDoorLock(new DoorLockEventArgs() { isLocked = true });
        }
        public void UnlockDoor()
        {
            OnDoorLock(new DoorLockEventArgs() { isLocked = false });
        }

        public void OpenDoor()
        {
            OnDoorChange(new DoorOpenEventArgs { IsOpen = true });

        }

        public void CloseDoor()
        {
            OnDoorChange(new DoorOpenEventArgs { IsOpen = false });
        }

    }
}
