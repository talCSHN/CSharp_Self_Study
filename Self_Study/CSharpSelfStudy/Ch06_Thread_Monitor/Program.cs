namespace Ch06_Thread_Monitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 다중 스레드 생성
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(threadFunc);
                t.Start(i);
            }
        }
        static void threadFunc(object value)
        {
            Console.WriteLine(value + "번째 스레드");
        }
    }
}
