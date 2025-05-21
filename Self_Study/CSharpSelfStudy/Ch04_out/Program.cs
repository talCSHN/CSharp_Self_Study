namespace Ch04_out
{
    internal class Program
    {
        static bool Divide(int n1, int n2, out int result)
        {
            if (n2 == 0)
            {
                result = 0; // main에서 넘겨주는 quotient 초기화 역할. 없으면 컴파일 에러
                return false;
            }
            result = n1 / n2;
            return true;
        }
        static void Main(string[] args)
        {
            int quotient;
            if (Divide(15, 3, out quotient))
            {
                Console.WriteLine(quotient);
            }
        }
    }
}
