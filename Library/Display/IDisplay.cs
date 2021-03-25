namespace ChargerLocker.Display
{
    public interface IDisplay
    {
        void NotifyCharge(string msg);
        void NotifyStation(string msg);
        string ReadInput();
    }
}
