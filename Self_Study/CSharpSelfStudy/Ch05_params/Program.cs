namespace Ch05_params
{
    internal class Program
    {
        private static void PrintAll(params object[] values)
        {
            foreach (object value in values)
            {
                Console.Write(value + " ");
            }
        }
        static void Main(string[] args)
        {
            PrintAll(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        }
    }
}
