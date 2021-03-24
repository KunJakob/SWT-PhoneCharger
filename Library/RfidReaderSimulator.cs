using Ladeskab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfidReader
{
    public class RfidReaderSimulator : IRfidReader
    {
        private StationControl _SC;
        public RfidReaderSimulator(StationControl SC)
        {
            _SC = SC;
            _id = 0;
        }
        public int _id { get; private set; }
        public void OnRfidRead(int id)
        {
            _id = id;
            _SC.OnRfidReadEvent(_id);
        }
    }
}
