using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerConsole
{
    class Server
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server is running ... ");
            IPAddress ip = new IPAddress(new byte[] { 192, 168, 253, 1 });
            TcpListener listener = new TcpListener(ip, 8500);

            listener.Start();           // 开始侦听
            Console.WriteLine("Start Listening ...");

            Console.WriteLine("\n\n输入\"Q\"键退出。");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
        }
    }
}
