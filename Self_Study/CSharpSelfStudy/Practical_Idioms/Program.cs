namespace Practical_Idioms
{
    public class Person
    {
        public string Name {  get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber {  get; set; }
        public Person()
        {
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 배열/리스트 초기화. 가급적 마지막 요소 뒤 콤마 붙일 것
            var langs = new string[] { "C#", "JAVA", "C++", };
            var nums = new List<int> { 10, 20, 30, 40, };
            // Dictionary 초기화
            var dict = new Dictionary<string, string>()
            {
                ["ko"] = "한국어",
                ["en"] = "영어",
                ["jp"] = "일본어",
            };
            // 객체 초기화
            var person = new Person
            {
                Name = "홍길동",
                Birthday = new DateTime(1995, 11, 26),
                PhoneNumber = "010-1234-5678"
            };
            // List<T> 요소 처리
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            list.ForEach(n => Console.Write($"{n}\t"));
        }
    }
}
