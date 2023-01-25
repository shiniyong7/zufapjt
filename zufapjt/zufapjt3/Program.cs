using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zufapjt3
{
    class Program
    {
        private static string ByteToString(byte[] strByte)
        {
            string str = Encoding.Default.GetString(strByte);
            return str;
        }
        private static byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }
        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////////////////////////ClientSocket Use
            //ClientSocket connect = new ClientSocket();

            //try
            //{

            //    connect.tryConnect();

            //    NetworkStream stream = connect.client.GetStream();

            //    Encoding encode = Encoding.GetEncoding("utf-8");

            //    StreamReader reader = new StreamReader(stream, encode);

            //    StreamWriter writer = new StreamWriter(stream, encode)

            //    { AutoFlush = true };

            //    byte[] binary = new byte[30];
            //    byte[] send = new byte[30];
            //    string sendstr;

            //    while (true)
            //    {
            //        if (!connect.client.Connected) continue;

            //        connect.socket.Receive(binary);

            //        string str = Encoding.UTF8.GetString(binary);

            //        Console.WriteLine(str);

            //        sendstr = @"Hello Zu~";

            //        send = StringToByte(sendstr);

            //        string str2 = Encoding.UTF8.GetString(send);

            //        connect.socket.Send(send);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.ToString());

            //}
            //finally
            //{

            //    connect.client.Close();

            //}


            //////////////////////////////////////////////////////////////////////////ServerSocket Use

            TcpListener tcpListener = null;

            Socket clientsocket = null;

            try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1");

                tcpListener = new TcpListener(ipAd, 1000);

                tcpListener.Start();8

                while (true)

                {
                    clientsocket = tcpListener.AcceptSocket();


                    ServerSocket cHandler = new ServerSocket(clientsocket);

                    Thread t = new Thread(new ParameterizedThreadStart(cHandler.chat));

                    t.Start();

                    cHandler = null;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                clientsocket.Close();
            }
        }
    }
}
