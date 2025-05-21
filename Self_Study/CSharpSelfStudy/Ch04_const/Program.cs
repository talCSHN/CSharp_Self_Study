// 간단하게 상수는 리터럴에 const 식별자 붙인 것
// 상수는 static 예약어 사용 불가(의미상 이미 static에 해당됨)
// 기본자료형에만 상수 정의 허용
// 반드시 상수 정의와 동시에 값 대입해야 함. 즉 생성자에서 접근 불가
// 상수는 컴파일할 때 해당 소스코드에 값이 직접 치환되는 방식으로 구현됨
namespace Ch04_const
{
    internal class Program
    {
        const string TEXT = " 변수의 값: ";
        class Test
        {
            const int a = 1;
            // 아래 주석은 불가
            //public Test(int num) : this(a, 0)
            //{

            //}
            //public Test(int num1, int num2)
            //{
            //    this.a = num2;
            //}
        }
        static void Main(string[] args)
        {
            int x = 5;
            int y = 10;

            Console.WriteLine("x" + TEXT + x);
            Console.WriteLine("y" + TEXT + y);

            // MaxValue, MinValue는 상수로 제공된 상한값, 하한값
            Console.WriteLine(int.MinValue);
            Console.WriteLine(int.MaxValue);
            Console.WriteLine((int)char.MinValue);
            Console.WriteLine((int)char.MaxValue);

        }
    }
}
