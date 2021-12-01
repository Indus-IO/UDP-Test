using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            if (args.Length > 0)
            {
                if (args[0].Equals("/server"))
                    new Server();
                else if (args[0].Equals("/client"))
                    new Client();
            }
        }

        public static int InputPort()
        {
            int port = -1;
            do
            {
                Console.WriteLine("Enter the Port Number(0 - 65535)");
                if (int.TryParse(Console.ReadLine(), out port) && 0 <= port && port <= 65535)
                    break;
                else
                    Console.WriteLine("Invalid Port Range");
            } while (true);

            return port;
        }
    }
}
