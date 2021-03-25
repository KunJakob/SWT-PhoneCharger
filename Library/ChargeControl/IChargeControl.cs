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
