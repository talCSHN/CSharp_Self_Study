using System.Net;
using System.Net.Sockets;
namespace Ch06_Network_Socket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 서버 소켓이 동작하는 스레드
            Thread serverThread = new Thread(serverFunc);
            serverThread.IsBackground = true;
            serverThread.Start();

            Thread.Sleep(500);  // 서버 소켓 스레드가 실행될 시간 주기 위해

            // 클라이언트 소켓 동작하는 스레드
            Thread clientThread = new Thread(clientFunc);
            clientThread.IsBackground = true;
            clientThread.Start();

            Console.WriteLine("종료하려면 아무 키나 누르시오");
            Console.ReadLine();
        }
        private static void serverFunc(object obj)
        {
            Socket socket = 
                new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress ipAddress = GetCurrentIPAddress();
            if (ipAddress == null)
            {
                Console.WriteLine("IPv4용 랜 카드 없음");
                return;
            }
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 10200);

            socket.Bind(endPoint);
        }
        private static IPAddress GetCurrentIPAddress()
        {
            IPAddress[] addrs = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

            foreach (IPAddress ipAddr in addrs)
            {
                if (ipAddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddr;
                }
            }
            return null;
        }
        private static void clientFunc()
        {
            // 클라이언트 소켓 코드 작성
        }
    }
}
