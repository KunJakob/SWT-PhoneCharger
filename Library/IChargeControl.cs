using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeControl
{
    public interface IChargeControl
    {
        //TODO
        public bool Connected { get; set; }

        public void StartCharge();
        public void StopCharge();
    }
}
