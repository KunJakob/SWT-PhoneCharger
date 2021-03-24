
using System;

namespace Ladeskab.ChargeControl
{
    public class ChargeControl : IChargeControl
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
