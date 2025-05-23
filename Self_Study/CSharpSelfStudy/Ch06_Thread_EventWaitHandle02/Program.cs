﻿using System.Collections;
namespace Ch06_Thread_EventWaitHandle02
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

            Hashtable ht1 = new Hashtable();
            ht1["data"] = data;
            ht1["event"] = new EventWaitHandle(false, EventResetMode.ManualReset);
            // 데이터와 함께 이벤트 객체를 스레드 풀의 스레드에 전달
            ThreadPool.QueueUserWorkItem(threadFunc, ht1);

            Hashtable ht2 = new Hashtable();
            ht2["data"] = data;
            ht2["event"] = new EventWaitHandle(false, EventResetMode.ManualReset);
            // 데이터와 함께 이벤트 객체를 스레드 풀의 스레드에 전달
            ThreadPool.QueueUserWorkItem(threadFunc, ht2);

            // 2개의 이벤트 객체가 Signal 상태로 바뀔 때까지 대기
            (ht1["event"] as EventWaitHandle).WaitOne();
            (ht2["event"] as EventWaitHandle).WaitOne();

            Console.WriteLine(data.Number);
        }
        static void threadFunc(object inst)
        {
            Hashtable ht = inst as Hashtable;

            MyData data = ht["data"] as MyData;

            for (int i = 0; i < 100000; i++)
            {
                data.Increment();
            }

            // 주어진 이벤트 객체를 Signal 상태로 전환
            (ht["event"] as EventWaitHandle).Set();
        }
    }
}
