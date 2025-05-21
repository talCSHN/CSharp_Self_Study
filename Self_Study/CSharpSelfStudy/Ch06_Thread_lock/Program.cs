namespace Ch06_Thread_lock
{
    internal class Program
    {
        class MyData
        {
            int number = 0;
            //public int number { get; set; }

            public int Number { get { return number;  } }
            //public int Number { get; }

            public void Increment()
            {
                number++;
            }
        }
        static void Main(string[] args)
        {
            MyData data = new MyData();

            Thread t1 = new Thread(threadFunc);
            Thread t2 = new Thread(threadFunc);

            t1.Start(data);
            t2.Start(data);

            t1.Join();
            t2.Join();

            Console.WriteLine(data.Number);
            //Console.WriteLine(data.number);
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
