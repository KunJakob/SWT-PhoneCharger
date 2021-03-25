using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Logger
{
    public interface ILogger
    {
        public void WriteToLog(string Message);

    }
}
