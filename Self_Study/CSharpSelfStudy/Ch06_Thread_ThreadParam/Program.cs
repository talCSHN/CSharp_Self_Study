namespace Ch06_Thread_ThreadParam
{
    internal class Program
    {
        class ThreadParam
        {
            public int Value1;
            public int Value2;
        }
        static void Main(string[] args)
        {
            // 인자가 있는 메서드의 경우 Thread 생성자는 ParameterizedThreadStart 델리게이트 타입 허용
            //Thread t = new Thread(threadFunc);
            //// 따라서 C# 컴파일러는 위 코드를 new Thread(new ParameterizedThreadStart(threadFunc));로 번역하여 컴파일
            //t.Start(10);

            Thread t1 = new Thread(threadFunc1);
            ThreadParam param = new ThreadParam();
            param.Value1 = 10;
            param.Value2 = 20;

            t1.Start(param);
        }
        static void threadFunc(object initalValue)
        {
            int intValue = (int)initalValue;
            Console.WriteLine(intValue);
        }
        static void threadFunc1(object initialValue)
        {
            ThreadParam value = (ThreadParam)initialValue;
            Console.WriteLine("{0} {1}", value.Value1, value.Value2);
        }
    }
}
