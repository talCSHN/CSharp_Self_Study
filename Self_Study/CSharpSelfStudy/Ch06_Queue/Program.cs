using System.Collections;
namespace Ch06_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();

            q.Enqueue(1);
            q.Enqueue(5);
            q.Enqueue(3);

            int first = (int)q.Dequeue();

            q.Enqueue(7);

            while (q.Count > 0)
            {
                Console.Write(q.Dequeue() + " ");
            }
            // 큐를 Dequeue 과정없이 비우고 싶으면 Clear() 메서드 사용
        }
    }
}
