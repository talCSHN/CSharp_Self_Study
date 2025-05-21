using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Network_Socket_TCP_Server_test
{
    public class AsyncStateData
    {
        public byte[] Buffer;
        public Socket Socket;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread serverThread = new Thread(serverFunc);
            serverThread.IsBackground = true;
            serverThread.Start();

            Thread.Sleep(500);  // 서버 소켓 스레드가 실행될 시간 주기 위해
            Console.WriteLine("서버 실행");
            serverThread.Join();

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

                    AsyncStateData data = new AsyncStateData();
                    data.Buffer = new byte[1024];
                    data.Socket = clntSocket;

                    clntSocket.BeginReceive(data.Buffer, 0, data.Buffer.Length, SocketFlags.None, asyncReceiveCallback, data);
                }
            }
        }
        private static void asyncReceiveCallback(IAsyncResult asyncResult)
        {
            AsyncStateData rcvData = asyncResult.AsyncState as AsyncStateData;

            int nRecv = rcvData.Socket.EndReceive(asyncResult);
            string txt = Encoding.UTF8.GetString(rcvData.Buffer, 0, nRecv);

            Console.WriteLine("Received From Client" + txt);

            byte[] sendBytes = Encoding.UTF8.GetBytes(txt);
            rcvData.Socket.BeginSend(sendBytes, 0, sendBytes.Length, SocketFlags.None, asyncSendCallback, rcvData.Socket);
        }
        private static void asyncSendCallback(IAsyncResult asyncResult)
        {
            Socket socket = asyncResult.AsyncState as Socket;
            socket.EndSend(asyncResult);

            socket.Close();
        }
    }
}
