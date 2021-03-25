using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerLocker.ChargeControl
{
    public interface IChargeControl
    {
        //TODO
        public bool Connected { get; }

        public void StartCharge();
        public void StopCharge();
    }
}
