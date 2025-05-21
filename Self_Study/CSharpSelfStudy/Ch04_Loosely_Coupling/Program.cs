// Tight Coupling 예시
namespace Ch04_Loosely_Coupling
{
    internal class Program
    {
        class Computer
        {
            public void TurnOn()
            {
                Console.WriteLine("Computer : Turn On");
            }
        }
        class Monitor
        {
            public void TurnOn()
            {
                Console.WriteLine("Monitor : Turn On");
            }
        }
        class Switch
        {
            public void PowerOn(Monitor machine)   // Monitor 타입 직접 사용
            {
                // Tight Coupling
                machine.TurnOn();
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
