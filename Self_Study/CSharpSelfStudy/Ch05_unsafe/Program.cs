namespace Ch05_unsafe
{
    internal class Program
    {
        unsafe static void GetAddResult(int* p, int a, int b)
        {
            *p = a + b;
        }
        static void Main(string[] args)
        {
            int i;
            unsafe
            {
                GetAddResult(&i, 5, 10);
            }
            Console.WriteLine(i);
        }
    }
}
