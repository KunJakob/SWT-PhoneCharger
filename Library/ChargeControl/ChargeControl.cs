
using System;
using Ladeskab.UsbCharger;
using Ladeskab.Events;
using Ladeskab.Display;
namespace Ladeskab.ChargeControl
{
    public class ChargeControl : IChargeControl
    {

        private IUsbCharger _charger;
        private IDisplay _display;

        public ChargeControl(IUsbCharger Charger, IDisplay Display)
        {
            _charger = Charger;
            _charger.CurrentValueEvent += CurrentChangeHandler;
            _display = Display;
        }

        protected virtual void CurrentChangeHandler(object sender, CurrentEventArgs e)
        {
            double Current = e.Current;
            if (Current == 0)
            {
                _display.NotifyCharge("");
            }
            else if (0 < Current && Current <= 5)
            {
                _display.NotifyCharge("Phone fully charged. It can be safely removed.");
            }
            else if (5 < Current && Current <= 500)
            {
                _display.NotifyCharge("Phone is charging.");
            }
            else if (Current > 500)
            {
                _display.NotifyCharge("ERROR: Potential short circuit. Disconnect phone immediately.");
            }

        }

        public bool Connected { get => _charger.Connected; }

        public void StartCharge()
        {
            _charger.StartCharge();
        }

        public void StopCharge()
        {
            _charger.StopCharge();
        }
    }
}
