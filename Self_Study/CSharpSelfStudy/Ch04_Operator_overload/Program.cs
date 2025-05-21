namespace Ch04_Operator_overload
{
    internal class Program
    {
        public class Kilogram
        {
            double mass;

            public Kilogram(double mass)
            {
                this.mass = mass;
            }
            public static Kilogram operator +(Kilogram op1, Kilogram op2)
            {
                return new Kilogram(op1.mass + op2.mass);
            }

            public double GetMass()
            {
                return this.mass;
            }
        }
        static void Main(string[] args)
        {
            Kilogram kg1 = new Kilogram(5);

            Kilogram kg2 = new Kilogram(10);

            Kilogram kg3 = kg1 + kg2;
            Console.WriteLine($"kg3: {kg3.GetMass()}");
        }
    }
}
