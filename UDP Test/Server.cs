using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Test
{
    public class Server
    {
        UdpClient server;

        public Server()
        {
            int port = Program.InputPort();
            Console.WriteLine("".PadLeft(100, '='));
            new TcpListener(IPAddress.Any, port).Start();
            server = new UdpClient(port);
            server.BeginReceive(ReceiveCallback, null);
            while(true)
            {

            }
        }

        void ReceiveCallback(IAsyncResult ar)
        {
            IPEndPoint node = null;
            try
            {
                byte[] receiveBytes = server.EndReceive(ar, ref node);

                Console.WriteLine(Encoding.UTF8.GetString(receiveBytes));
                byte[] data = Encoding.UTF8.GetBytes("pong!");
                server.Send(data, data.Length, node);

                server.BeginReceive(ReceiveCallback, null);
            } catch { }
        }
    }
}
