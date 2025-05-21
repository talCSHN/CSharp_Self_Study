namespace Ch04_ToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.ToString());

            int n = 500;
            double d = 3.141592;
            string txt = "Hello";

            Console.WriteLine(txt + n.ToString());
            Console.WriteLine(txt + d.ToString());

            txt = d.ToString();
            Console.WriteLine(txt);
            Type type = txt.GetType();
            Console.WriteLine(type);
        }
    }
}
