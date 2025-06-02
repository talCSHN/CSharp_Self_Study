
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
        public static int Count1(int[] numbers, int num)
        {
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
        // 델리게이트 사용
        public delegate bool Judgement(int value);
        public static int Count2(int[] numbers, Judgement judge)
        {
            int count = 0;
            foreach (var n in numbers)
            {
                if(judge(n) == true)
                {
                    count++;
                }
            }
            return count;
        }
        public void Do()
        {
            var numbers = new[] { 5,3,2,1 };
            Judgement judge = IsEven;   // 콜백
            var count = Count2(numbers, judge);
            Console.WriteLine(count);
        }
        public void Do1()
        {
            var numbers = new[] { 5,2,3,1 };
            var count = Count2(numbers, IsEven);    // IsEven 직접 전달
            Console.WriteLine(count);
        }

        public bool IsEven(int n)
        {
            return n % 2 == 0;
        }
        // 익명메서드 사용
        public int Count3(int[] numbers, Predicate<int> judge)
        {
            int count = 0;
            foreach (var n in numbers)
            {
                if (judge(n) == true)
                {
                    count++;
                }
            }
            return count;
        }
        public void Do2()
        {
            var numbers = new[] { 5, 1, 2, 1 };
            // delegate (int n) { return n % 2 == 0; } -> 익명 메서드
            var count = Count3(numbers, delegate (int n) { return n % 2 == 0; });
            Console.WriteLine(count);
        }
        // 람다식 사용
        public void Do3()
        {
            var numbers = new[] { 5, 1, 2, 1 };
            var count = Count3(numbers, n => n % 2 == 0);
            Console.WriteLine(count);
        }
        // 람다식 풀어 쓴 버전
        Predicate<int> judge =
            (int n) =>
            {
                if (n % 2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
        // 위의 judge 대입 -> var count = Count3(numbers, judge);
        // 위의 식 생략 버전 1
        public void Do4()
        {
            var numbers = new[] { 5, 1, 2, 1 };
            var count = Count3(numbers, (int n) =>
            {
                if ((n % 2) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
            Console.WriteLine(count);
        }
        // 위의 식 생략 버전 2
        public void Do5()
        {
            var numbers = new[] { 5, 1, 2, 1 };
            var count = Count3(numbers, (int n) => { return n % 2 == 0; });
            
            Console.WriteLine(count);
        }
        // 위의 식 생략 버전 3
        public void Do6()
        {
            var numbers = new[] { 5, 1, 2, 1 };
            var count = Count3(numbers, (int n) => n % 2 == 0);
        }
        // 위의 식 생략 버전 4
        public void Do7()
        {
            var numbers = new[] { 5, 1, 2, 1 };
             var count = Count3(numbers, n => n % 2 == 0);  // 괄호 생략 가능
            //var count = Count3(numbers, (n) => n % 2 == 0);
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

            // 람다 미사용
            int count = Count(5);
            Console.WriteLine(count);

            var numbers = new[] { 1,2,3,4,5,6,7,8,9 };
            var count1 = Count1(numbers, 5);
            Console.WriteLine($"count1 : {count1}");

            // 델리게이트 사용
        }
    }
}
