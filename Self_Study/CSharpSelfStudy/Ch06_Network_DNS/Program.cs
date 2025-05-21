using System.Net;
namespace Ch06_Network_DNS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry entry = Dns.GetHostEntry("www.microsoft.com");
            foreach (IPAddress ipAddress in entry.AddressList)
            {
                Console.WriteLine(ipAddress);
            }

            string myPC = Dns.GetHostName();
            Console.WriteLine("PC 이름: " + myPC);

            IPHostEntry entry1 = Dns.GetHostEntry(myPC);
            foreach (IPAddress ipAddress in entry.AddressList)
            {
                Console.WriteLine(ipAddress.AddressFamily + " : " + ipAddress);
            }
        }
    }
}
