using Ladeskab.Events;
using System;

namespace Ladeskab.Door
{
    public interface IDoor
    {
        public event EventHandler<DoorChangeEventArgs> DoorChangeEvent;
        public void LockDoor();
        public void UnlockDoor();
        public void OpenDoor();
        public void CloseDoor();
    }
}
