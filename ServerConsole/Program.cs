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
            // 获得IPAddress对象的另外几种常用方法：
            //IPAddress ip = IPAddress.Parse("127.0.0.1");
            //IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            IPAddress ip = new IPAddress(new byte[] { 192, 168, 253, 1 });
            TcpListener listener = new TcpListener(ip, 8500);

            listener.Start();           // 开始侦听
            Console.WriteLine("Start Listening ...");

            // 获取一个连接，中断方法
            TcpClient remoteClient = listener.AcceptTcpClient();

            // 打印连接到的客户端信息
            Console.WriteLine("Client Connected！{0} <-- {1}",
               remoteClient.Client.LocalEndPoint, remoteClient.Client.RemoteEndPoint);

            Console.WriteLine("\n\n输入\"Q\"键退出。");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
        }
    }
}
