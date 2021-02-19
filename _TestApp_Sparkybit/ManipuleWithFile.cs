using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _TestApp_Sparkybit
{
    public class ManipuleWithFile
    {
        public event MessageHandler FileMessage;
        List<string> outputFile = new List<string>();
        List<string> listFile = new List<string>();
        public void LoadFile()
        {
            listFile.Add(" ");

            FileMessage.Invoke(DateTime.Now, "Load file.");

            Console.WriteLine("Load data from file...\n");
            string line;

            using (StreamReader sr = new StreamReader("source.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    listFile.Add(line);
                }
            }
            Console.WriteLine("File is load!\n");
        }

        public void EditFile()
        {
            Console.WriteLine("Create new data...");
            FileMessage.Invoke(DateTime.Now, "Edit file.");

            List<string> list = new List<string>();
            list.Add("");
            List<int> num = new List<int>();

            int first = 0;
            int second = 1;
            int sum;

            for (int i = 0; i < listFile.Count; i++)
            {
                sum = first;
                first = second;
                second = second + sum;
                if (second <= listFile.Count)
                {
                    string input = listFile[second];
                    string output = new string(input.ToCharArray().Reverse().ToArray());
                    outputFile.Add(output);
                }
            }
        }

        public void SaveFile()
        {
            Console.WriteLine("Please name your new file:");
            string nameFile = Console.ReadLine();

            if (nameFile == "")
            {
                Console.WriteLine("Save data in output.txt ...");
                FileMessage.Invoke(DateTime.Now, "Save file.");
                nameFile = "output";
                StreamWriter sw = new StreamWriter("output.txt");
                foreach (string line in outputFile)
                {
                    sw.WriteLine(line);
                    Console.WriteLine(line);
                }
                sw.Close();
            }
            else
            {
                Console.WriteLine($"Save data in {nameFile} ...");
                FileMessage.Invoke(DateTime.Now, "Save file.");
                StreamWriter sw = new StreamWriter($"{nameFile}.txt");
                foreach (string line in outputFile)
                {
                    sw.WriteLine(line);
                }
                sw.Close();
            }

        }
    }
}
