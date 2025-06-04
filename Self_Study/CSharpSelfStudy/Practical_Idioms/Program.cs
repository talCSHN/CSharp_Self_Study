using System.Security.Cryptography.X509Certificates;

namespace Practical_Idioms
{
    public class Person
    {
        public string Name {  get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber {  get; set; }
        // 읽기 전용 속성
        public string GivenName { get; private set; }
        public string FamilyName { get; private set; }
        public string FullName => GivenName + " " + FamilyName;
        public Person()
        {
        }
    }
    public class MySample
    {
        // 읽기 전용 속성이 참조형인 경우(string 제외) 참조는 수정 불가, 속성이 가리키고 있는 객체는 수정 가능
        // 즉 List<int> 컬렉션의 내용은 수정 가능
        public List<int> MyList { get; private set; }
        // 더 강력한 방법. 컬렉션 자체를 수정할 수 없도록
        public IReadOnlyList<int> MyList1 { get; private set; }
        public MySample()
        {
            MyList = new List<int>() { 1, 2, 3, 4, 5 };
            MyList1 = new List<int>() { 6, 7, 8, 9, 10 };
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
            Console.WriteLine();
            // do-while
            bool finish;
            do
            {
                finish = DoSomething();
            } while (finish);
            // 루프 중단 처리
            var items = new List<string> { "21대", " 대선", };
            var line = "";
            foreach (var item in items)
            {
                if (line.Length + item.Length > 40)
                {
                    break;
                }
                line += item;
            }
            Console.WriteLine(line);

            loop();

            // null 조건 연산자
            Console.WriteLine(items[1]?.ToString());

            // 읽기 전용 속성
            var obj = new MySample();
            obj.MyList.Add(6);  // 가능
            //obj.MyList = new List<int>();   // 빌드 오류

            // 예외처리
            try
            {

            }
            catch (Exception ex)
            {

                throw;  // 권장
                //throw ex; // 권장하지 않음. 이유 : 예외의 스택 트레이스 정보 사라짐
            }

            // 외부 자원에 접근해야할 때는 가급적 using 사용 권장.
            // 이유 : 자동으로 Dispose가 호출되어 메모리 누수 방지 가능

        }
        // 가변 인수
        public static double Median(params double[] args)
        {
            var sorted = args.OrderBy(n => n).ToArray();
            int index = sorted.Length / 2;
            if (sorted.Length % 2 == 0)
            {
                return (sorted[index] + sorted[index - 1]) / 2;
            }
            else
            {
                return sorted[index];
            }
        }
        public static int loop()
        {
            var numbers = new int[] { 1, 2, 3 };
            foreach (var n in numbers)
            {
                if (n > 2)
                {
                    return n;
                }
            }
            return -1;
        }

        private static bool DoSomething()
        {
            return false;
        }
    }
}
