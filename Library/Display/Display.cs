using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Display
{
    public class Display : IDisplay
    {
        public void notifyCharge(string msg)
        {
            string notifyMsg = "######### " +"Charge - "+ DateTime.Now.ToString() + " #########";
            // When calling CursorTop and WindowWidth on console, when there is no console being tested, will cause a handle error.
            // To ensure code will run through test and check the write and read, we have implemented try/catch/finally. 
            // It is an unfortunate loop-hole, but it ensures that tests won't fail due to being headless and the actual program running fine.
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
        public void notifyStation(string msg)
        {
            string notifyMsg = "######### " + "Station - " + DateTime.Now.ToString() + " #########";

            // When calling CursorTop and WindowWidth on console, when there is no console being tested, will cause a handle error.
            // To ensure code will run through test and check the write and read, we have implemented try/catch/finally. 
            // It is an unfortunate loop-hole, but it ensures that tests won't fail due to being headless and the actual program running fine.
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
    }
}
