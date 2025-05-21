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
        private static void serverFunc()
        {
            // 서버 소켓 코드 작성
        }
        private static void clientFunc()
        {
            // 클라이언트 소켓 코드 작성
        }
    }
}
