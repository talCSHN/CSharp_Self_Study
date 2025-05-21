namespace ch04_OOP_Class
{
    internal class Program
    {
        class Book
        {
            public string Title;
            decimal ISBN13;
            string Contents;
            string Author;
            static public int PageCount;
            //static public Book President = new Book("노무현", 1);  // Singleton
            static public Book President;

            static Book()
            {
                President = new Book("노무현", 1); // 정적 필드 초기화
                Console.WriteLine("static Constructor call");
            }

            private Book(string name, int num)
            {
                Author = name;
            }

            public Book()
            {
                Author = "노무현";
                Console.WriteLine("Constructor Call");
            }

            public Book(string name)
            {
                PageCount++;
                Author = name;
            }

            public int f(int x)
            {
                return x * x;
            }

            static public void testFunc()
            {
                Console.WriteLine(PageCount);
                //Console.WriteLine(Author); // 정적 메서드 안에서는 인스턴스 멤버 접근 불가
            }
        }
        static void Main(string[] args)
        {
            Book gulliver = new Book();
            gulliver.Title = "걸리버 여행기";
            //gulliver.Contents = "...."; // 오류

            int result = gulliver.f(2);
            Console.WriteLine(result);

            Book gulliver2 = new Book("몰라");
            Book harryPotter = new Book("Rolling");
            Console.WriteLine($"test : {Book.PageCount}");

            //Book gulliver3 = new Book("문재인", 2); // 안 됨
            Book.testFunc();
        }
    }
}
