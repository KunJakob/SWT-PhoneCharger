using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfidSimulator
{
    public class RfidReaderSimulator : IRfidReader
    {
        public int _id { get; private set; }
        public void OnRfidRead(int id)
        {
            _id = id;
        }
    }
}
