using ChargerLocker.ChargeControl;
using ChargerLocker.Display;
using ChargerLocker.Door;
using ChargerLocker.Logger;
using ChargerLocker.RfidReader;
using ChargerLocker.StationControl;
using ChargerLocker.UsbCharger;
using Microsoft.Extensions.DependencyInjection;
using System;

class Program
{

    static void Main(string[] args)
    {
        //set up DI
        ServiceProvider ServiceProvider;
        ServiceCollection services = new ServiceCollection();

        //register services and build service provider
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        //get instances
        IDoor door = ServiceProvider.GetService<IDoor>();
        IRfidReader rfidReader = ServiceProvider.GetService<IRfidReader>();
        IDisplay Display = ServiceProvider.GetService<IDisplay>();
        StationControl _stationControl = ServiceProvider.GetService<StationControl>();
        //local vars
        bool finish = false;
        do
        {
            Display.NotifyStation("Indtast E, O, C, R: ");
            string input = Display.ReadInput();
            if (string.IsNullOrEmpty(input)) continue;

            switch (input[0])
            {
                case 'E':
                    finish = true;
                    break;

                case 'O':
                    door.OpenDoor();
                    break;

                case 'C':
                    door.CloseDoor();
                    break;

                case 'R':
                    Display.NotifyStation("Input RFID id: ");
                    string idString = Display.ReadInput();
                    //fix maybe?
                    try
                    {
                        int id = Convert.ToInt32(idString);
                        rfidReader.Read(id);
                    }
                    catch (FormatException e)
                    {
                        Display.NotifyStation("You must input a valid number!");

                    }
                    break;

                default:
                    break;
            }

        } while (!finish);
    }

    static void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<StationControl>();
        services.AddSingleton<IDoor, Door>();
        services.AddSingleton<IChargeControl, ChargeControl>();
        services.AddSingleton<IRfidReader, RfidReader>();
        services.AddSingleton<IUsbCharger, UsbChargerSimulator>();
        string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/";
        services.AddSingleton<ILogger>(new Logger(LogPath, "LogFile.txt"));
        services.AddSingleton<IDisplay, Display>();
    }
}
