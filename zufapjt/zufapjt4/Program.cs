using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zufapjt4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Serial Read
            SerialPort sp = new SerialPort()
            {
                PortName = "COM3",
                BaudRate = 9600,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One
            };

            sp.ReadTimeout = 5000;
            sp.WriteTimeout = 500;

            try
            {
                sp.Open();

                string data = sp.ReadLine();

                Console.WriteLine(data);

                Console.WriteLine("Press Enter to Quit");
                Console.ReadLine();

                sp.WriteLine("Hello Zu~");
            }
            catch (System.Exception ex)
            {
             
            }
            finally
            {
                sp.Close();

            }
        }
    }
}
