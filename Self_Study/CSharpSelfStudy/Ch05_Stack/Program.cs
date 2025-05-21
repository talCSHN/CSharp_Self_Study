namespace Ch05_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = Sum(5, 6);
            Console.WriteLine(result);

            static int Sum(int v1, int v2)
            {
                int v3 = v1 + v2;
                return v3;
            }
        }
    }
}
