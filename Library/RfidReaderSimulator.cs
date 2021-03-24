using Ladeskab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.RfidReader
{
    public class RfidReaderSimulator : IRfidReader
    {
        public RfidReaderSimulator()
        {
            _id = 0;
        }
        public int _id { get; private set; }
        public void OnRfidRead(int id)
        {
            _id = id;
            //?
        }
    }
}
