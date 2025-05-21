// recursive call
using System.Runtime.CompilerServices;

namespace Ch05_stack_overflow
{
    
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine(factorial(51524));

            static long factorial(long n)
            {
                if (n == 0)
                {
                    return 1;
                }
                return n * factorial(n - 1);
            }
        }

        
    }
}
