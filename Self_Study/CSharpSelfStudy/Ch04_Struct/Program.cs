namespace Ch04_Struct
{
    internal class Program
    {
        struct Vector
        {
            public int X;
            public int Y;

            public Vector(int x, int y) // 매개변수를 가진 생성자 정의
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                return "X: " + this.X + ", Y: " + this.Y;
            }
        }
        static void Main(string[] args)
        {
            Vector v1 = new Vector();   // new 사용하여 인스턴스 생성 가능
            Vector v2;                  // new 없어도 인스턴스 생성 가능

            Vector v3 = new Vector(5, 10);  // 명시적으로 생성자 지정 가능

            Console.WriteLine(v1);
            // 클래스는 참조타입이기 때문에 초기화되지 않아도 null값을 기본으로 가질 수 있지만
            // struct는 값 타입이라 모든 필드가 초기화되지 않으면 메모리 접근이 허용되지 않음
            // C#에서 지역변수는 반드시 초기화되어야지만 사용 가능
            //Console.WriteLine(v2);  // new없이 구조체 선언은 가능하지만 초기화 되지 않았으므로 v2 사용 불가
            // 모든 필드에 값을 할당하기 전까지 사용하면 컴파일 에러뜸
            Console.WriteLine(v3);

            // 아래 코드는 모두 같은 의미
            Vector v4 = new Vector();
            Vector v5;
            v5.X = 0;
            v5.Y = 0;

            Vector v6 = new Vector(0, 0);

            // 기본형에도 똑같이 적용됨
            // 아래는 모두 동일
            int n1 = new int();
            int n2;
            n2 = 0;
            int n3 = 0;

            Console.WriteLine(n1);
        }
    }
}
