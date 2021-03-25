using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Display
{
    public interface IDisplay
    {
        void notifyCharge(string msg);
        void notifyStation(string msg);
    }
}
