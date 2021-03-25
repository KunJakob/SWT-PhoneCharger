using Ladeskab.Events;
using System;

namespace Ladeskab.Door
{
    public class Door : IDoor
    {



        private enum LockState
        {
            LOCKED,
            UNLOCKED
        }

        private LockState _lockState;

        public Door()
        {
            _lockState = LockState.UNLOCKED;
        }

        public event EventHandler<DoorChangeEventArgs> DoorChangeEvent;

        protected virtual void OnDoorChange(DoorChangeEventArgs e)
        {
            DoorChangeEvent?.Invoke(this, e);
        }

        public void LockDoor()
        {
            _lockState = LockState.LOCKED;
        }
        public void UnlockDoor()
        {
            _lockState = LockState.UNLOCKED;
        }

        public bool OpenDoor()
        {
            if (_lockState == LockState.UNLOCKED)
            {
                OnDoorChange(new DoorChangeEventArgs { IsOpen = true });
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CloseDoor()
        {
            //Probably can't happen, but added for insurance
            if (_lockState == LockState.UNLOCKED)
            {
                OnDoorChange(new DoorChangeEventArgs { IsOpen = false });
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
