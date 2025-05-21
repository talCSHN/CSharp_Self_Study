using System.Security.Cryptography.X509Certificates;

namespace Ch06_DateTime
{
    internal class Program
    {
        static long Sum()
        {
            long sum = 0;

            for (int i = 0; i < 1000000; i++)
            {
                sum += i;
            }

            return sum;
        }
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now);

            DateTime dayForChildren = new DateTime(now.Year, 5, 5);
            Console.WriteLine(dayForChildren);

            DateTime before = DateTime.Now;
            Sum();
            DateTime after = DateTime.Now;

            long gap = after.Ticks - before.Ticks;
            Console.WriteLine("Total Ticks: " + gap);
            Console.WriteLine("Millisecond: " + (gap / 10000));
            Console.WriteLine("Second: " + (gap / 10000 / 1000));

            DateTime endOfYear = new DateTime(DateTime.Now.Year, 12, 31);
            DateTime current = DateTime.Now;
            Console.WriteLine("오늘 날짜: " + current);

            TimeSpan timeGap = endOfYear - current;
            Console.WriteLine("올해 남은 날짜: " + timeGap);
        }
    }
}
