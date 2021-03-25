using Ladeskab.ChargeControl;
using Ladeskab.Display;
using Ladeskab.Door;
using Ladeskab.Logger;
using Ladeskab.RfidReader;
using Ladeskab.StationControl;
using Ladeskab.UsbCharger;
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

        //local vars
        bool finish = false;
        do
        {
            Display.notifyStation("Indtast E, O, C, R: ");
            string input = Console.ReadLine();
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
                    Display.notifyStation("Indtast RFID id: ");
                    string idString = System.Console.ReadLine();

                    int id = Convert.ToInt32(idString);
                    rfidReader.Read(id);
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
        string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"/";
        services.AddSingleton<ILogger>(new Logger(LogPath, "LogFile.txt"));
        services.AddSingleton<IDisplay,Display>();
    }
}
