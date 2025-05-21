namespace Ch04_overload
{
    internal class Program
    {
        class Mathmatics
        {
            public int Abs(int value)
            {
                return (value >= 0) ? value : -value;
            }
            public double Abs(double value)
            {
                return (value >= 0) ? value : -value;
            }
            public decimal Abs(decimal value)
            {
                return (value >= 0) ? value : -value;
            }
        }
        static void Main(string[] args)
        {
            Mathmatics math = new Mathmatics();
            Console.WriteLine(math.Abs(-5));
            Console.WriteLine(math.Abs(-3.141592));
            Console.WriteLine(math.Abs(-20.01m));
        }
    }
}
