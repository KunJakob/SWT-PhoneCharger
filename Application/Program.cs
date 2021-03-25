
using Ladeskab.ChargeControl;
using Ladeskab.Door;
using Microsoft.Extensions.DependencyInjection;
using Ladeskab.RfidReader;
using System;
using Ladeskab.UsbCharger;
using Ladeskab.StationControl;

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

        //local vars
        bool finish = false;
        do
        {
            Console.WriteLine("Indtast E, O, C, R: ");
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
                    Console.WriteLine("Indtast RFID id: ");
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
    }
}
