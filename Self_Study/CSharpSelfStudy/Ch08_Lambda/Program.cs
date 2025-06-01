namespace Ch08_Lambda
{
    internal class Program
    {
        // 범용성 없는 기존의 메서드
        // 다른 배열로 같은 작업 하려고 할 때 재사용 불가
        public static int Count(int num)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int count = 0;
            foreach (var n in numbers)
            {
                if (n == num)
                {
                    count++;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            //    Thread thread = new Thread(
            //        delegate (object obj)
            //        {
            //            Console.WriteLine("Anonymous Method");
            //        });

            //    // 위의 코드를
            //    // 아래처럼 람다식을 사용하여 단순화할 수 있음
            //    Thread thread1 = new Thread((obj) =>
            //    {
            //        Console.WriteLine("Anonymous Method");
            //    });

            int count = Count(5);
            Console.WriteLine(count);
        }
    }
}
