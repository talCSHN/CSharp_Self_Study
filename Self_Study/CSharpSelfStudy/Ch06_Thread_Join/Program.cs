namespace Ch06_Thread_Join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(threadFunc);
            t.IsBackground = true;
            t.Start();

            t.Join();   // t 스레드 종료까지 현재 스레드 무한 대기
            Console.WriteLine("메인 스레드 종료");
        }
        static void threadFunc()
        {
            Console.WriteLine("10초 후 프로그램 종료");
            Thread.Sleep(1000 * 10);
            Console.WriteLine("t 스레드 종료");
        }
    }
}
