using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _TestApp_Sparkybit
{
    public delegate void MessageHandler(DateTime timeEvent, string message);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Test app*****");

            ManipuleWithFile file = new ManipuleWithFile();
            logging logFile = new logging();
            logFile.AddLogRecord(DateTime.Now, "Start program.");

            file.FileMessage += logFile.AddLogRecord;
            logFile.LogMessage += logFile.AddLogRecord;
            
            file.LoadFile();

            file.EditFile();

            file.SaveFile();

            logFile.ReadLogFile();

            Console.ReadLine();
            logFile.AddLogRecord(DateTime.Now, "Close program.");
            logFile.CloseLogFile();
        }
    }        
}
