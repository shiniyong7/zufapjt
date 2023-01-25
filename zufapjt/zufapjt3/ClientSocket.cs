using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace zufapjt3
{
    class ClientSocket
    {
        public void tryConnect()
        {
            client = new TcpClient();

            client.Connect("localhost", 1000);

            socket = client.Client;

        }

        public TcpClient client = null;

        public Socket socket = null;
    }
}
