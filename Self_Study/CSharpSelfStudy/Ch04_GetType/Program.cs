namespace Ch04_GetType
{
    internal class Program
    {
        public class Computer
        {

        }
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            Type type = computer.GetType();

            Console.WriteLine(type);
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.Name);
            Console.WriteLine(type.IsClass);
            Console.WriteLine(type.IsArray);

            Type type1 = typeof(double);
            Console.WriteLine(type1.FullName);
            Console.WriteLine(typeof(System.Int16).FullName);
        }
    }
}
