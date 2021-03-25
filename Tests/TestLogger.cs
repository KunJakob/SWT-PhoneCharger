using Ladeskab.Logger;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LoggerTest
{
    [TestFixture]
    public class TestLogger
    {
        private Logger _uut;
        string testText;
        string LogPath;
       [SetUp]
        public void Setup()
        {
           
            LogPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"/";
            testText = "test";
            _uut = new Logger(LogPath, "TestLogFile.txt");


            if (File.Exists(LogPath+"TestLogFile.txt"))
            {
                File.Delete(LogPath + "TestLogFile.txt");
            }
        }

        [Test]
        public void WriteToLog_Succesful()
        {
            
            _uut.WriteToLog(testText);
            string[] lines = File.ReadAllLines(LogPath + "TestLogFile.txt");
            //Using contains as matching the timestamp creates dependency on the test running on a fast computer.
            Assert.That(lines[0].Contains(testText), Is.EqualTo(true));

        }

       

    }
}
