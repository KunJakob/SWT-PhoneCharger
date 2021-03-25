using ChargerLocker.Events;
using System;

namespace ChargerLocker.Door
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

        public event EventHandler<DoorOpenEventArgs> DoorChangeEvent;

        protected virtual void OnDoorChange(DoorOpenEventArgs e)
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
                OnDoorChange(new DoorOpenEventArgs { IsOpen = true });
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
                OnDoorChange(new DoorOpenEventArgs { IsOpen = false });
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
