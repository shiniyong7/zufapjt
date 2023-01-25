using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace zufapjt3
{
    class ServerSocket
    {
        Socket socket = null;

        NetworkStream stream = null;

        StreamReader reader = null;

        StreamWriter writer = null;


        public ServerSocket(Socket socket)
        {
            this.socket = socket;
        }

        public void chat(object param)
        {
            stream = new NetworkStream(socket);

            Encoding encode = Encoding.GetEncoding("utf-8");

            reader = new StreamReader(stream, encode);

            writer = new StreamWriter(stream, encode) { AutoFlush = true };

            byte[] binary = new byte[30];

            try
            {
                while (true)
                {

                    socket.Receive(binary);
                    var data = Encoding.UTF8.GetString(binary).Trim('\0');

                    Console.WriteLine(data);

                    socket.Send(binary);
                }
            }
            catch (Exception e)
            {
                reader.Close();
                writer.Close();
                stream.Close();
                socket.Close();
            }
        }
    }
}
