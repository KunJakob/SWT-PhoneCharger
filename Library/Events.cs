using System;

namespace Ladeskab.Events
{
    public class RfidReadEventArgs : EventArgs
    {
        public int Id { get; set; }
    }
    public class DoorOpenEventArgs : EventArgs
    {
        public bool IsOpen { get; set; }
    }

    public class DoorLockEventArgs : EventArgs
    {
        public bool isLocked { get; set; }
    }

    public class CurrentEventArgs : EventArgs
    {
        // Value in mA (milliAmpere)
        public double Current { set; get; }
    }



}
