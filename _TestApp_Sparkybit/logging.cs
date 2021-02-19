using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _TestApp_Sparkybit
{
    public class logging
    {
        public event MessageHandler LogMessage;
        StreamWriter sw = new StreamWriter("logfile.txt");
        List<string> listLog = new List<string>();

        public void CloseLogFile()
        {
            LogMessage.Invoke(DateTime.Now, "Save logfile.");
            foreach (string line in listLog)
            {
                sw.WriteLine(line);
            }
            sw.Close();
        }

        public void AddLogRecord(DateTime timeEvent, string message)
        {
            string logMessage = ($"{timeEvent}" + " : " + message);
            listLog.Add(logMessage);
        }

        public void ReadLogFile()
        {
            Console.WriteLine("\nCurrent log:\n");
            LogMessage.Invoke(DateTime.Now, "Read log file.");
            foreach (string line in listLog)
            {
                Console.WriteLine(line); ;
            }
        }
    }
}
