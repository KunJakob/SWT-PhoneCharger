using Ladeskab;
using Ladeskab.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.RfidReader
{
    public class RfidReader : IRfidReader
    {
        public RfidReader()
        {
        }

        public event EventHandler<RfidReadEventArgs> ReadIdEvent;

        public void OnRfidRead(RfidReadEventArgs e)
        {
            ReadIdEvent?.Invoke(this, e);
        }

        public void Read(int id)
        {
            throw new NotImplementedException();
        }
    }
}
