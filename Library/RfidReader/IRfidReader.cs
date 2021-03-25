using Ladeskab.Events;
using System;

namespace Ladeskab.RfidReader
{
    public interface IRfidReader
    {

        public event EventHandler<RfidReadEventArgs> ReadIdEvent;
        public void Read(int id);
    }
}
