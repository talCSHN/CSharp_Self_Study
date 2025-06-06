namespace Practical_List_Collection
{
    internal class Program
    {
        public class Book
        {
            public string Title { get; set; }
            public int Price { get; set; }
            public int Pages { get; set; }
           
        }
        
        static void Main(string[] args)
        {
            var Books = new List<Book>
            {
                new Book { Title = "C# Programming", Price = 30000, Pages = 500 },
                new Book { Title = "ASP.NET Core", Price = 40000, Pages = 600 },
                new Book { Title = "Entity Framework Core", Price = 35000, Pages = 450 },
                new Book { Title = "LINQ in C#", Price = 25000, Pages = 300 },
                new Book { Title = "Ronaldo", Price = 77777, Pages = 400 },
                new Book { Title = "Messi", Price = 4416, Pages = 550 },
                new Book { Title = "GOAT", Price = 12345, Pages = 600 },
            };
            // IEnumerable<T> 인터페이스 가지고 있음 -> LINQ 사용 가능
            // 요소 설정
            // 동일한 값으로 채우기
            var numbers = Enumerable.Repeat(-1, 20).ToList();
            numbers.ForEach(n => Console.Write($"{n}, "));
            Console.WriteLine();
            // 연속된 값으로 채우기
            var numbers1 = Enumerable.Range(1, 20).ToList();
            numbers1.ForEach(n => Console.Write($"{n}, "));
            Console.WriteLine();
            // 평균 구하기
            var average = numbers1.Average();
            Console.WriteLine(average);
            // 합계
            var sum = numbers1.Sum();
            Console.WriteLine(sum);
            // 최대 / 최소
            var numbers2 = new List<int> { 1, 2, 5, 7, 3, 6, 8, 2, -1, -2, -3 };
            var min = numbers2.Where(n => n > 0).Min();
            Console.WriteLine(min);
            var pages = Books.Max(x => x.Pages);
            // 요소 개수 세기
            var count = numbers2.Count(n => n < 0);
            Console.WriteLine(count);
            var count1 = Books.Count(x => x.Title.Contains("C#"));
            Console.WriteLine(count1);
            // 컬렉션 판정
            // 조건 일치 요소 존재
            bool exists = numbers2.Any(n => n % 7 == 0);
            Console.WriteLine(exists);
        }
    }
}
