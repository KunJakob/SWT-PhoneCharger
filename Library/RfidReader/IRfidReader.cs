using ChargerLocker.Events;
using System;

namespace ChargerLocker.RfidReader
{
    public interface IRfidReader
    {

        public event EventHandler<RfidReadEventArgs> ReadIdEvent;
        public void Read(int id);
    }
}
