using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ladeskab.Log
{
    public class Logger : ILogger
    {
        private readonly string _filepath;
        private readonly string _filename;

        public Logger(string Filepath, string Filename)
        {
            _filepath = Filepath;
            _filename = Filename;
        }

        private string GetFormattedTime()
        {
            //s formatter gives the following format: 06/15/2008 21:15:07
            return DateTime.Now.ToString("s");
        }
        public void WriteToLog(string Message)
        {

            var preparedMessage = GetFormattedTime() + ": " + Message + Environment.NewLine;

            //appends to existing logfile because of the true parameter
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_filepath, _filename), true))
            {
                outputFile.WriteAsync(preparedMessage);
            }
        }
    }
}
