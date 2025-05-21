namespace Ch06_Thread_Monitor02
{
    internal class Program
    {
        int number = 0;
        static void Main(string[] args)
        {
            Program pg = new Program();

            Thread t1 = new Thread(threadFunc);
            Thread t2 = new Thread(threadFunc);

            t1.Start(pg);
            t2.Start(pg);

            t1.Join();
            t2.Join();

            Console.WriteLine(pg.number);
        }
        static void threadFunc(object inst)
        {
            Program pg = inst as Program;

            for (int i = 0; i < 100000; i++)
            {
                Monitor.Enter(pg);
                try
                {
                    pg.number = pg.number + 1;
                }
                finally
                {
                    Monitor.Exit(pg);
                }
            }
        }
    }
}
