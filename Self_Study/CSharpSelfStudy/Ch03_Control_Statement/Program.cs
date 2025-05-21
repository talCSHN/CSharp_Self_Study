namespace Ch03_Control_Statement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ^(XOR) 배타적 논리합 연산자 -> 둘이 같으면 false / 다르면 true
            bool result = true ^ true;
            bool result2 = true ^ false;
            //Console.WriteLine(result);
            //Console.WriteLine(result2);

            int value = 5;
            string result3 = (value % 2 == 0) ? "짝수" : "홀수";
            //Console.WriteLine(result3);

            char ch = 'M';

            switch (ch)
            {
                case 'M':
                    Console.WriteLine("Male");
                    break;
                case 'F':
                    Console.WriteLine("Female");
                    break ;
            }

            int [] arr3 = new int[] { 1, 2, 3, 4, 5 };

            foreach (int i in arr3)
            {
                Console.Write(i + " ");
            }

            int sum = 0;
            int n = 1;
            while (n <= 1000)
            {
                if (n % 2 == 0)
                {
                    sum += n;
                }
                n++;
            }
            Console.WriteLine(sum);

            int sum1 = 0;
            int n2 = 0;
            do
            {
                if (n % 2 == 0)
                {
                    sum += n;
                }
            } while (++n <= 1000);

            int n5 = 1, sum5 = 0;
            while(n5 < 1000)
            {
                if (n5%3 == 0 || n5%5 == 0)
                {
                    sum5 += n5;
                }
                n5++;
            }
            Console.WriteLine(sum5);
        }
    }
}
