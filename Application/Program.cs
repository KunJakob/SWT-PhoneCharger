using Ladeskab.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using DoorSimulator;

class Program
{

    static void Main(string[] args)
    {
        //set up DI
        ServiceProvider ServiceProvider;
        ServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        //local vars
        IDoor door = ServiceProvider.GetService<IDoor>();
        IRfidReader rfidReader = ServiceProvider.GetService<IRfidReader>();
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
                    door.OnDoorOpen();
                    break;

                case 'C':
                    door.OnDoorClose();
                    break;

                case 'R':
                    Console.WriteLine("Indtast RFID id: ");
                    string idString = System.Console.ReadLine();

                    int id = Convert.ToInt32(idString);
                    rfidReader.OnRfidRead(id);
                    break;

                default:
                    break;
            }

        } while (!finish);
    }

    static void ConfigureServices(ServiceCollection services)
    {

        services.AddSingleton<IDoor>(new Door());

    }
}
