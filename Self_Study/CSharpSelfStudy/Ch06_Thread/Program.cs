namespace Ch06_Thread
{
    internal class Program
    {
        static void threadFunc()
        {
            Console.WriteLine("threadFunc run");
        }
        static void Main(string[] args)
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine(thread.ThreadState);  // 출력 결과 : Running

            Console.WriteLine(DateTime.Now);
            Thread.Sleep(1000); // 1초 동안 스레드 중지
            Console.WriteLine(DateTime.Now);

            Thread t = new Thread(threadFunc);
            t.Start();
        }
    }
}
