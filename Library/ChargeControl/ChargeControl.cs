
using System;
using Ladeskab.UsbCharger;
using Ladeskab.Events;
using Ladeskab.Display;
namespace Ladeskab.ChargeControl
{
    public class ChargeControl : IChargeControl
    {

        private IUsbCharger _charger;
        public ChargeControl(IUsbCharger Charger)
        {
            _charger = Charger;
            _charger.CurrentValueEvent += CurrentChangeHandler;
        }


        protected virtual void CurrentChangeHandler(object sender, CurrentEventArgs e)
        {
            double Current = e.Current;
            if (Current == 0)
            {
                //Der er ingen forbindelse til en telefon, eller ladning er ikke startet. Displayet viser ikke noget om ladning.
            } else if (0 < Current && Current <= 5) {
                //Opladningen er tilendebragt, og USB ladningen kan stoppes. Displayet viser, at telefonen er fuldt opladet.
            } else if (5 < Current && Current <= 500)
            {
                //Opladningen foregår normalt. Displayet viser, at ladning foregår.
            } else if (Current > 500)
            {
                //Der er noget galt, fx en kortslutning. USB ladningen skal straks stoppes. Displayet viser en fejlmeddelelse.
            }
            
        }

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
