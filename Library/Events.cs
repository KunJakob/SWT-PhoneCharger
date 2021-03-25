using System;

namespace Ladeskab.Events
{
    public class RfidReadEventArgs : EventArgs
    {
        public int Id { get; set; }
    }
    public class DoorChangeEventArgs : EventArgs
    {
        public bool IsOpen { get; set; }
    }

    public class CurrentEventArgs : EventArgs
    {
        // Value in mA (milliAmpere)
        public double Current { set; get; }
    }



}
