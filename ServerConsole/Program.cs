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
            const int BufferSize = 8192;    // 缓存大小，8192字节
            Console.WriteLine("Server is running ... ");
            // 获得IPAddress对象的另外几种常用方法：
            IPAddress ip = IPAddress.Parse("10.1.1.107");
            //IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            //IPAddress ip = new IPAddress(new byte[] { 192, 168, 253, 1 });
            TcpListener listener = new TcpListener(ip, 8500);

            listener.Start();           // 开始侦听
            Console.WriteLine("Start Listening ...");

            //使用一个do/while循环，并将listener.AcceptTcpClient()方法和TcpClient.GetStream().Read()方法都放在这个循环以内，
            //那么服务端将可以处理多个客户端的一条请求
            do
            {
                //获取一个连接，中断方法
                TcpClient remoteClient = listener.AcceptTcpClient();
                // 打印连接到的客户端信息
                Console.WriteLine("Client Connected！{0} <-- {1}",
                    remoteClient.Client.LocalEndPoint, remoteClient.Client.RemoteEndPoint);

                //获得流并写入buffer中
                NetworkStream streamToClient = remoteClient.GetStream();
                byte[] buffer = new byte[BufferSize];
                int bytesRead = streamToClient.Read(buffer, 0, BufferSize);
                Console.WriteLine("Reading data, {0} bytes ...", bytesRead);

                // 获得请求的字符串
                String msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received: {0}", msg);
            } while (true);
        }
    }
}
