// 은닉화(Encapsulation) 원칙
// 특별한 이유를 제외하고 필드를 절대 public으로 선언하지 않는다.
// 접근이 필요할 때는 getter/setter 메서드를 통해 외부에서 접근하는 경로를 클래스 개발자의 관리 하에 둔다.

namespace Ch04_Encapsulation
{
    internal class Program
    {
        class Circle
        {
            double pi = 3.14;

            public double GetPi()
            {
                return pi;
            }
            public void SetPi(double value)
            {
                pi = value;
            }
            
        }
        static void Main(string[] args)
        {
            Circle o = new Circle();
            o.SetPi(3.141592);
            double piValue = o.GetPi();
            Console.WriteLine(piValue);
        }
    }
}
