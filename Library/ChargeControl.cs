using ChargeControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeControl
{
    class ChargeControl : IChargeControl
    {
        public bool Connected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void StartCharge()
        {
            throw new NotImplementedException();
        }

        public void StopCharge()
        {
            throw new NotImplementedException();
        }
    }
}
