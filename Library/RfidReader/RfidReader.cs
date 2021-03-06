using ChargerLocker.Events;
using System;

namespace ChargerLocker.RfidReader
{
    public class RfidReader : IRfidReader
    {

        public event EventHandler<RfidReadEventArgs> ReadIdEvent;

        protected virtual void OnRfidRead(RfidReadEventArgs e)
        {
            ReadIdEvent?.Invoke(this, e);
        }

        public void Read(int id)
        {
            OnRfidRead(new RfidReadEventArgs { Id = id });
        }
    }
}
