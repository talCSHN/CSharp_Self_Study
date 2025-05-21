namespace Ch04_Loosely_Coupling2
{
    internal class Program
    {
        interface IPower
        {
            void TurnOn();
        }
        class Monitor : IPower
        {
            public void TurnOn()
            {
                Console.WriteLine("Monitor : Turn On");
            }
        }
        class Computer : IPower
        {
            public void TurnOn()
            {
                Console.WriteLine("Computer : Turn On");
            }
        }
        class Switch
        {
            public void PowerOn(IPower machine)
            {
                machine.TurnOn();
            }
        }
        static void Main(string[] args)
        {
            Switch switch1 = new Switch();
            Monitor monitor = new Monitor();
            Computer computer = new Computer();
            switch1.PowerOn(monitor);
            switch1.PowerOn(computer);
        }
    }
}
