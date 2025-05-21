namespace Ch06_Thread_ThreadPool
{
    internal class Program
    {
        class MyData
        {
            int number = 0;

            public int Number { get { return number; } }

            public void Increment()
            {
                number++;
            }
        }
        static void Main(string[] args)
        {
            MyData data = new MyData();

            ThreadPool.QueueUserWorkItem(threadFunc, data);
            ThreadPool.QueueUserWorkItem(threadFunc, data);

            Thread.Sleep(1000);

            Console.WriteLine(data.Number);
        }
        static void threadFunc(object inst)
        {
            MyData data = inst as MyData;

            for (int i = 0; i < 100000; i++)
            {
                lock (data)
                {
                    data.Increment();
                }
            }

        }
    }
}
