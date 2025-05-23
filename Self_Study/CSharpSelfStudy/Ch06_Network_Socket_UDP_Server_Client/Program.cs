﻿using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Ch06_Network_Socket_UDP_Server_Client
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
            for (int i = 0; i < 3; i++)
            {
                Thread clientThread = new Thread(clientFunc);
                clientThread.IsBackground = true;
                clientThread.Start();
            }
            //Thread clientThread = new Thread(clientFunc);
            //clientThread.IsBackground = true;
            //clientThread.Start();

            Console.WriteLine("종료하려면 아무 키나 누르시오");
            Console.ReadLine();
        }
        private static void serverFunc(object obj)
        {
            using (Socket srvSocket =
                new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                IPAddress ipAddress = IPAddress.Parse("0.0.0.0");
                IPEndPoint endPoint = new IPEndPoint(ipAddress, 10200);

                srvSocket.Bind(endPoint);

                byte[] recvBytes = new byte[1024];
                EndPoint clientEP = new IPEndPoint(IPAddress.None, 0);

                while (true)
                {
                    int nRecv = srvSocket.ReceiveFrom(recvBytes, ref clientEP);
                    string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

                    byte[] sendBytes = Encoding.UTF8.GetBytes("HELLO: " + txt);
                    srvSocket.SendTo(sendBytes, clientEP);
                }
            }
        }
        private static void clientFunc(object obj)
        {
            Socket clntSocket =
                new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 10200);
            EndPoint senderEP = new IPEndPoint(IPAddress.None, 0);

            int nTimes = 5;

            while (nTimes-- > 0)
            {
                byte[] buf = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
                clntSocket.SendTo(buf, serverEP);

                byte[] recvBytes = new byte[1024];
                int nRecv = clntSocket.ReceiveFrom(recvBytes, ref senderEP);
                string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

                Console.WriteLine(txt);
                Thread.Sleep(1000);
            }
            clntSocket.Close();
            Console.WriteLine("UDP Client Socket Closed");
        }
    }
}
