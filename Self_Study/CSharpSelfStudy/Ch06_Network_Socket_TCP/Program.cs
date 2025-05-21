using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Ch06_Network_Socket_TCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread serverThread = new Thread(serverFunc);
            serverThread.IsBackground = true;
            serverThread.Start();

            Thread.Sleep(500);  // 서버 소켓 스레드가 실행될 시간 주기 위해

            // 클라이언트 소켓 동작하는 스레드
            //for (int i = 0; i < 3; i++)
            //{
            //    Thread clientThread = new Thread(clientFunc);
            //    clientThread.IsBackground = true;
            //    clientThread.Start();
            //}
            Thread clientThread = new Thread(clientFunc);
            clientThread.IsBackground = true;
            clientThread.Start();

            Console.WriteLine("종료하려면 아무 키나 누르시오");
            Console.ReadLine();
        }
        private static void serverFunc(object obj)
        {
            using (Socket srvSocket =
                new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 11200);

                srvSocket.Bind(endPoint);
                srvSocket.Listen(10);

                while (true)
                {
                    Socket clntSocket = srvSocket.Accept();

                    byte[] recvBytes = new byte[1024];

                    int nRecv = clntSocket.Receive(recvBytes);
                    string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

                    byte[] sendBytes = Encoding.UTF8.GetBytes("Server : " + txt);
                    clntSocket.Send(sendBytes);
                    clntSocket.Close();
                }
            }
        }
        private static void clientFunc(object obj)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 11200);

            socket.Connect(serverEP);

            byte[] buf = Encoding.UTF8.GetBytes(Console.ReadLine());
            socket.Send(buf);

            byte[] recvBytes = new byte[1024];
            int nRecv = socket.Receive(recvBytes);
            string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

            Console.WriteLine(txt);
            socket.Close();
            Console.WriteLine("TCP Client Socket Closed");
        }
    }
}
