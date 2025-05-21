// 타입은 값을 담을 수 있음
// 값의 범위에 메서드도 포함됨
// 델리게이트는 메서드의 참조를 담을 수 있는 타입
// delegate 예약어로 표현
// C/C++의 함수 포인터와 비슷한 개념
using System.Runtime.CompilerServices;

namespace Ch04_Delegate
{
    internal class Program
    {
        delegate int FuncDelegate(object arg); // 델리게이트 정의.
                                               // FuncDelegate 타입은 int 반환값과 object 인자를 하나 받는 메서드를 가리킬 수 있음

        delegate void WorkDelegate(char arg1, int arg2, int arg3);

        delegate void CalculateDelegate(int x, int y);
        static void Add(int x, int y) { Console.WriteLine( x + y ); }
        static void Subtract(int x, int y) { Console.WriteLine(x - y); }
        static void Multiply(int x, int y) { Console.WriteLine(x * y); }
        static void Divide(int x, int y) { Console.WriteLine(x / y); }

        public class Disk
        {
            public int Clean(object arg)
            {
                Console.WriteLine("작업 실행");
                return 0;
            }
            
        }
        public class Mathematics
        {
            public delegate int CalcDelegate(int x, int y);

            static int Add(int x, int y) { return x + y; }
            static int Subtract(int x, int y) { return x - y; }
            static int Multiply(int x, int y) { return x * y; }
            static int Divide(int x, int y) { return x / y; }

            CalcDelegate[] methods;
            public Mathematics()
            {
                // static 메서드 가리키는 델리게이트 배열 초기화
                methods = new CalcDelegate[]
                {
                    Mathematics.Add,
                    Mathematics.Subtract,
                    Mathematics.Multiply,
                    Mathematics.Divide
                };
            }
            public void Calculate(char opCode, int operand1, int operand2)
            {
                switch (opCode)
                {
                    case '+':
                        Console.WriteLine("+: " + methods[0](operand1, operand2));
                        break;
                    case '-':
                        Console.WriteLine("-: " + methods[1](operand1, operand2));
                        break;
                    case '*':
                        Console.WriteLine("*: " + methods[2](operand1, operand2));
                        break;
                    case '/':
                        Console.WriteLine("/: " + methods[3](operand1, operand2));
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Disk disk = new Disk();
            FuncDelegate cleanFunc = new FuncDelegate(disk.Clean);
            FuncDelegate workFunc = disk.Clean; // new 없이 일반 숫자형 타입처럼 대입도 가능. 위의 코드와 동일함
            // 둘 다 같음
            disk.Clean(null);   // Clean 메서드 직접 호출
            cleanFunc(null);    // 델리게이트 인스턴스를 통해 Clean 메서드 호출

            Mathematics math = new Mathematics();
            WorkDelegate work = math.Calculate;

            work('+', 20, 10);
            work('-', 20, 10);
            work('*', 20, 10);
            work('/', 20, 10);

            // 메서드 반환값으로 델리게이트 사용 가능 -> 메서드의 반환값으로 메서드 사용 가능
            // 메서드 인자로 델리게이트 전달 가능 -> 메서드의 인자로 메서드 전달 가능
            // 클래스 멤버로 델리게이트 정의 가능 -> 클래스의 멤버로 메서드 정의 가능
            
            // 델리게이트에 메서드 등록
            CalculateDelegate calc = Add;
            calc += Subtract;
            calc += Multiply;
            calc += Divide;

            calc(10, 5); // 델리게이트에 등록된 모든 메서드 호출
            // 델리게이트에서 메서드 제거
            calc -= Divide;
            calc(10, 5);

        }
    }
}
