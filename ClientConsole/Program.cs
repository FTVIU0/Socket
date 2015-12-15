using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Client
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Client Running ...");
            IPAddress ip = IPAddress.Parse("10.1.1.107");
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(ip, 8500);      // 与服务器连接
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            // 打印连接到的服务端信息
            Console.WriteLine("Server Connected！{0} --> {1}",
                client.Client.LocalEndPoint, client.Client.RemoteEndPoint);

            string msg = "\"Welcome To TraceFact.Net\"";
            NetworkStream streamToServer = client.GetStream();

            byte[] buffer = Encoding.Unicode.GetBytes(msg);
            streamToServer.Write(buffer, 0, buffer.Length);
            Console.WriteLine("Sent: {0}", msg);

            // 按Q退出
            Console.WriteLine("\n\n输入\"Q\"键退出。");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
        }
    }
}
