using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Test
{
    public class Client
    {
        UdpClient client = new UdpClient();

        public Client()
        {
            Console.WriteLine("Enter the host");
            string host = Console.ReadLine();
            int port = Program.InputPort();

            Console.WriteLine("".PadLeft(100, '='));
            IPEndPoint server = new IPEndPoint(IPAddress.Parse(host), port);

            byte[] byteArray = Encoding.UTF8.GetBytes("ping!");

            client.Send(byteArray, byteArray.Length, server);
            client.BeginReceive(ReceiveCallback, null);
            while(true)
            {

            }
        }

        void ReceiveCallback(IAsyncResult ar)
        {
            IPEndPoint remoteEndPoint = null;
            byte[] receiveBytes = client.EndReceive(ar, ref remoteEndPoint);

            if (receiveBytes != null && receiveBytes.Length > 0)
            {
                Console.WriteLine(Encoding.UTF8.GetString(receiveBytes));
            }

            client.BeginReceive(ReceiveCallback, null);
        }
    }
}
