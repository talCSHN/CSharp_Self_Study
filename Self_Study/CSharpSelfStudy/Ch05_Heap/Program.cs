namespace Ch05_Heap
{
    internal class Program
    {
        static int GetMaxValue(object v1, object v2)
        {
            int a = (int)v1;
            int b = (int)v2;

            if (a >= b)
            {
                return a;
            }

            return b;
        }
        static void Main(string[] args)
        {
            int a = 5;
            object obj = a;     // 박싱 - 값 형식인 int를 참조 형식인 object에 대입
            int b = (int)obj;   // 언박싱 - 참조 형식인 object를 값 형식인 int에 대입

            int c = 5;
            int d = 6;

            int e = GetMaxValue(c, d);
        }
    }
}
