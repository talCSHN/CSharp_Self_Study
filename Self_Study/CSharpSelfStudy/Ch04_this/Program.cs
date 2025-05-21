using System.Security.Cryptography;

namespace Ch04_this
{
    internal class Program
    {
        class Book
        {
            decimal _isbn;
            public decimal ISBN
            {
                get { return this._isbn; }
            }

            public Book(decimal isbn)
            {
                this._isbn = isbn;
            }

            public decimal GetISBN()
            {
                return this.ISBN;
            }

            public void Sell()
            {
                Console.WriteLine("Sell: " + this.GetISBN());
            }
        }

        // this 예약어 사용해서 생성자 내에서 다른 생성자 호출
        class Book1
        {
            string title;
            decimal isbn13;
            string author;

            public Book1(string title) : this(title, 0)
            {

            }
            public Book1(string title, decimal isbn13) : this(title, isbn13, string.Empty)
            {

            }
            public Book1(string title, decimal isbn13, string author)
            {
                this.title = title;
                this.isbn13 = isbn13;
                this.author = author;
            }
            public Book1() : this(string.Empty, 0, string.Empty)
            {

            }
        }

        class Book2
        {
            string title;
            static int count;

            public Book2(string title)  // 인스턴스 생성자
            {
                this.title = title; // this로 인스턴스 필드 식별 가능
                this.Open();        // this로 인스턴스 메서드 식별 가능
                Increment();        // static 메서드 사용 가능
            }

            static void Increment() // static 메서드
            {
                count++;    // static 필드 사용 가능
                // static 메서드에는 this가 없으므로 인스턴스 멤버 사용 불가능
            }
            public void Close()
            {
                Console.WriteLine(this.title + "책 덮기");
            }

            public void Open()
            {
                Console.WriteLine(this.title + "Siuuuu");   // 인스턴스 멤버 사용 가능
                Console.WriteLine(count);   // static 멤버 사용 가능
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
