using System.Collections;
namespace Ch06_Collections_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack st = new Stack();

            st.Push(1);
            st.Push(5);
            st.Push(3);

            int last = (int)st.Pop();

            st.Push(7);

            while (st.Count > 0)
            {
                Console.WriteLine(st.Pop() + " ");
            }
            // 스택을 Pop 과정없이 비우고 싶으면 Clear() 메서드 사용
        }
    }
}
