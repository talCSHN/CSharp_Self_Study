namespace Ch04_base
{
    internal class Program
    {
        class Book
        {
            decimal isbn13;
            public Book(decimal isbn13)
            {
                this.isbn13 = isbn13;
            }
        }
        class EBook : Book
        {
            // 자식 클래스 생성 -> 부모 클래스 생성자도 함께 호출
            // 현재 부모 클래스에는 기본 생성자가 없음
            //public EBook()  // 에러 발생
            //{

            //}
            public EBook() : base(0)
            {

            }
            public EBook(decimal isbn) : base(isbn)
            {

            }

        }
        static void Main(string[] args)
        {
            
        }
    }
}
