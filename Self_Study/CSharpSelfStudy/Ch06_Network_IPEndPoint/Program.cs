using System.Net;
namespace Ch06_Network_IPEndPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipAdrr = IPAddress.Parse("192.168.1.10");
            IPEndPoint endPoint = new IPEndPoint(ipAdrr, 9000);
            Console.WriteLine(endPoint);
        }
    }
}
