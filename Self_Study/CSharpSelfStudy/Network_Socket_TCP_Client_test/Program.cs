using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Network_Socket_TCP_Client_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread clientThread = new Thread(clientFunc);
            clientThread.IsBackground = true;
            clientThread.Start();


            Thread.Sleep(500);  // 클라이언트 소켓 스레드가 실행될 시간 주기 위해

            Console.WriteLine("클라이언트 실행");
            clientThread.Join();

            Console.ReadLine();
        }
        private static void clientFunc(object obj)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 11200);

            socket.Connect(serverEP);
            while (true)
            {

                byte[] buf = Encoding.UTF8.GetBytes(Console.ReadLine());
                socket.Send(buf);

                byte[] recvBytes = new byte[1024];
                int nRecv = socket.Receive(recvBytes);
                string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

                Console.WriteLine("Received From Server" + txt);
            }
            
            socket.Close();
            Console.WriteLine("TCP Client Socket Closed");
        }
    }
}
