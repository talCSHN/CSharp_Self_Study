namespace Practical_Idioms
{
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
            Console.WriteLine(dict["ko"]);
        }
    }
}
