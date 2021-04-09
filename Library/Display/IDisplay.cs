namespace ChargerLocker.Display
{//IDisplay interface
    public interface IDisplay
    {
        void NotifyCharge(string msg);
        void NotifyStation(string msg);
        string ReadInput();
    }
}
