namespace Ch04_Class_Casting2
{
    internal class Program
    {
        public class Computer
        {
            public void Run() { }
        }
        public class Notebook : Computer
        {
            public void Run1()
            {
                Run();
            }
        }
        static void Main(string[] args)
        {
            Computer pc = new Computer();
            Notebook nb = pc as Notebook;   // 오류발생하지 않고 Downcasting
            // as는 형변환이 가능하면 지정된 타입의 인스턴스 값 반환 / 가능하지 않으면 null 반환
            // as는 참조형 변수에 대해서만 적용 가능, 참조형 타입으로만 체크 가능
            int n = 5;
            //if ((n as string) != null) { Console.WriteLine("변수 n은 string 타입") }    // 오류 발생
            string txt = "text";
            //if ((txt as int) != null) { Console.WriteLine("변수 txt는 int 타입") }      // 이것도 오류 발생

            if (nb != null)
            {
                nb.Run1();
            }

            // is 연산자 -> 형변환 가능성 유무를 boolean형 결과값(true/false)로 반환
            // is는 참조형 뿐만 아니라 값 형식에도 사용 가능
            int n1 = 5;
            if (n is string)
            {
                Console.WriteLine("변수 n1은 string");
            }
            string txt1 = "text";
            if (txt1 is int)
            {
                Console.WriteLine("변수 txt1은 int");
            }

        }
    }
}
