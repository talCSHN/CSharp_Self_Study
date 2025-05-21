namespace Ch04_override
{
    internal class Program
    {
        class Mammal
        {
            public void Move()
            {
                Console.WriteLine("이동");
            }
            public void eat()
            {
                Console.WriteLine("섭취");
            }
        }
        class Lion : Mammal
        {
            public void Move()
            {
                Console.WriteLine("사족 보행");
            }
            new public void eat()
            {
                Console.WriteLine("단순히 자식 클래스에서 동일한 이름의 메서드가 필요할 때는 new 예약어 사용");
            }
        }
        class Goat
        {
            virtual public void Play()
            {
                Console.WriteLine("운동");
            }
            virtual public void hunt()
            {
                Console.WriteLine("사냥");
            }
        }
        class Ronaldo : Goat
        {
            override public void Play()
            {
                Console.WriteLine("축구");
            }
            override public void hunt()
            {
                //Console.WriteLine("사냥");  // 부모 클래스에도 있음. 중복 코드 제거 원칙 위배
                base.hunt(); // 이런 식으로 간단하게 해결
                Console.WriteLine("골 사냥");
            }
        }

        public class Point
        {
            int x, y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return "X: " + x + ", Y: " + y;
            }
        }
        class Book
        {
            decimal isbn13;
            string title;
            string contents;

            public Book(decimal isbn13, string title, string contents)
            {
                this.isbn13 = isbn13;
                this.title = title;
                this.contents = contents;
            }

            public override bool Equals(object obj)
            {
                Book book = obj as Book;
                if (book == null)
                {
                    return false;
                }
                return this.isbn13 == book.isbn13;
            }

            public override int GetHashCode()
            {
                return this.isbn13.GetHashCode();
            }
        }
        static void Main(string[] args)
        {
            Lion lion = new Lion();
            Mammal one = lion;  // 암시적 형변환
            one.Move(); // lion 인스턴스지만 부모 타입으로 형변환 되어 부모의 Move() 메서드 호출됨
            lion.eat();
            one.eat();

            Ronaldo ronaldo = new Ronaldo();
            Goat ronaldo7 = ronaldo;
            ronaldo7.Play();    // virtual/override 예약어 사용해서 위의 문제 해결

            Point pt = new Point(10, 20);
            Console.WriteLine(pt.ToString()); // ToString() 메서드 오버라이딩

            Book book1 = new Book(978899098, "C# Programming", "C# Programming");
            Book book2 = new Book(978899098, "C# Programming", "C# Programming");
            Book book3 = new Book(978899099, "Python Programming", "Python Programming");

            Console.WriteLine(book1.Equals(book2)); // True
            Console.WriteLine(book1.Equals(book3)); // False
        }
    }
}
