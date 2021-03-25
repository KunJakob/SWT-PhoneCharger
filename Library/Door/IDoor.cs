﻿using Ladeskab.Events;
using System;

namespace Ladeskab.Door
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
