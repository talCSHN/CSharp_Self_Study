namespace Ch04_Equals
{
    internal class Program
    {
        class Book
        {
            decimal _isbn;

            public Book(decimal isbn)
            {
                _isbn = isbn;
            }
        }
        static void Main(string[] args)
        {
            // Equals -> 값 형식에 대해서는 해당 인스턴스가 소유하고 있는 값을 대상으로 비교
            // 참조 형식에 대해서는 할당된 메모리 위치를 가리키는 식별자 값이 같은지 비교
            int n1 = 5;
            int n2 = 5;
            Console.WriteLine(n1.Equals(n2));   // True

            Book book1 = new Book(n1);
            Book book2 = new Book(n2);
            Console.WriteLine(book1.Equals(book2)); // False
            // 힙에 할당된 데이터 주소를 가리키고 있는 스택 변수의 값을 비교하기 때문

            // string은 참조타입이지만 예외
            // string이 Equals의 기본 동작 재정의
            string txt1 = new string(new char[] { 't', 'e', 'x', 't' });
            string txt2 = new string(new char[] { 't', 'e', 'x', 't' });
            Console.WriteLine(txt1.Equals(txt2));   // True

            // GetHashCode() : 특정 인스턴스를 고유하게 식별할 수 있는 4바이트 int값 반환
            // int 이하의 타입에서는 반환값과 1:1 매핑 가능
            // long - 8바이트 -> 32비트 정수 범위 내에서 표현 불가. long값에 대해 GetHashCode 호출하면 값이 다른데도
            // 동일한 해시 코드 반환될 수 있음
            short s1 = 256;
            short s2 = 32750;
            short s3 = 256;

            Console.WriteLine(s1.GetHashCode());
            Console.WriteLine(s2.GetHashCode());
            Console.WriteLine(s3.GetHashCode());

            Book book3 = new Book(s1);
            Book book4 = new Book(s1);

            Console.WriteLine(book3.GetHashCode());
            Console.WriteLine(book4.GetHashCode());
        }
    }
}
