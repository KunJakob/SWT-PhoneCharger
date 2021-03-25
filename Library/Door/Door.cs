using Ladeskab.Events;
using System;

namespace Ladeskab.Door
{
    public class Door : IDoor
    {

        public Door()
        {
        }

        public event EventHandler<DoorChangeEventArgs> DoorChangeEvent;

        protected virtual void OnDoorChange(DoorChangeEventArgs e)
        {
            DoorChangeEvent?.Invoke(this, e);
        }

        public void LockDoor()
        {
            throw new NotImplementedException();
        }
        public void UnlockDoor()
        {
            throw new NotImplementedException();
        }

        public void OpenDoor()
        {
            OnDoorChange(new DoorChangeEventArgs { IsOpen = true });
        }

        public void CloseDoor()
        {
            OnDoorChange(new DoorChangeEventArgs { IsOpen = false });
        }
    }
}
