using System;
using System.Collections.Generic;

namespace Ladeskab.Display
{
    public class Display : IDisplay
    {
        public void NotifyCharge(string msg)
        {
            string notifyMsg = "######### " +"Charge - "+ DateTime.Now.ToString() + " #########";
            // When calling CursorTop and WindowWidth on console, when there is no console being tested, will cause a handle error.
            // To ensure code will run through test and check the write and read, we have implemented try/catch/finally. 
            // It is an unfortunate loop-hole, but it ensures that tests won't fail due to being headless and the actual program running fine.
            // We are not implementing error handling, as we have to assume that the console WILL work as we haven't implemented it and the test fixture is the cause of trouble.
            try
            {
                Console.SetCursorPosition((Console.WindowWidth - notifyMsg.Length) / 2, Console.CursorTop);
            }
            catch{}
            finally
            {
                Console.WriteLine(notifyMsg);
            }
            try
            {
                Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.CursorTop);
            }
            catch{}
            finally
            {
                Console.WriteLine(msg);
            }
        }
        public void NotifyStation(string msg)
        {
            string notifyMsg = "######### " + "Station - " + DateTime.Now.ToString() + " #########";

            // When calling CursorTop and WindowWidth on console, when there is no console being tested, will cause a handle error.
            // To ensure code will run through test and check the write and read, we have implemented try/catch/finally. 
            // It is an unfortunate loop-hole, but it ensures that tests won't fail due to being headless and the actual program running fine.
            // We are not implementing error handling, as we have to assume that the console WILL work as we haven't implemented it and the test fixture is the cause of trouble.
            try
            {
                Console.SetCursorPosition((Console.WindowWidth - notifyMsg.Length) / 2, Console.CursorTop);
            }
            catch{}
            finally
            {
                Console.WriteLine(notifyMsg);
            }
            try
            {
                Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.CursorTop);
            }
            catch{}
            finally
            {
                Console.WriteLine(msg);
            }
        }
        public string ReadInput()
        {
            Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
            
            return Console.ReadLine();
        }
    }
}
