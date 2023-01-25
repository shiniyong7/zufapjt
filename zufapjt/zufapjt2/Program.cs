using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zufapjt2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Writer
            string fileName = "README.txt";
            string textToAdd = "Hello Zu~";

            FileStream fswrite = null;
            try
            {
                fswrite = new FileStream(fileName, FileMode.Append);
                using (StreamWriter writer = new StreamWriter(fswrite, Encoding.Default))
                {
                    writer.Write(textToAdd);
                }
            }
            finally
            {
                if (fswrite != null)
                    fswrite.Dispose();
            }


            //Read
            FileStream fsread = null;
            try
            {
                fsread = new FileStream(fileName, FileMode.Open);
                using (StreamReader reader = new StreamReader(fsread, Encoding.Default))
                {
                    while (reader.Peek() >= 0)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }
            }
            finally
            {
                if (fsread != null)
                    fsread.Dispose();
            }

        }
    }
}
