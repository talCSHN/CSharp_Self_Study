using System.Text;

namespace Practical_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////// 문자열 비교 ////////////////////////////
            string str1 = "ABC";
            string str2 = "abc";
            // == 연산자 : 대소문자 구분
            if (str1 == str2)
            {
                Console.WriteLine("Same");
            }
            else
            {
                Console.WriteLine("Different");
            }
            // String.Compare : 대소문자 구분 x 가능
            if (String.Compare(str1, str2, ignoreCase:true) == 0)
            {
                Console.WriteLine("Same");
            }

            ////////////////////////// 문자열 변환 ////////////////////////////

            // null, 빈 문자열 판정
            if (String.IsNullOrEmpty(str1))
            {
                Console.WriteLine("Empty or Null");
            }
            else
            {
                Console.WriteLine("Exist");
            }
            // 빈 문자열 판정
            if (str1 == String.Empty)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                Console.WriteLine("Exist");
            }
            // null, 빈 문자열, 공백 문자열 판정
            if (String.IsNullOrWhiteSpace(str2))
            {
                Console.WriteLine("null or empty or space");
            }
            else
            {
                Console.WriteLine("Exist");
            }
            // 지정한 부분 문자열로 시작 여부
            if (str1.StartsWith("abc"))
            {
                Console.WriteLine("True");
            }
            // 지정한 부분 문자열로 끝남 여부
            if (str1.EndsWith("abc"))
            {
                Console.WriteLine("True");
            }
            // 지정한 부분 문자열 포함 여부
            if (str1.Contains("abc"))
            {
                Console.WriteLine("True");
            }
            var contains = str1.Contains('a');
            Console.WriteLine(contains);
            // 조건을 만족하는 문자 포함돼 있는지 여부
            var target = "C# Programming";
            var isExists = target.Any(c => Char.IsLower(c));
            // 모든 문자가 조건 만족하는지 여부
            var target1 = "123456789";
            var isAllDigits = target1.All(c => Char.IsDigit(c));

            ////////////////////////// 문자열 검색, 추출 ////////////////////////////
            
            // 부분 문자열 검색 후 위치 반환
            var target2 = "Novelist=호날두;BestWork=내마위";
            var index = target2.IndexOf("BestWork=");
            Console.WriteLine(index);

            // 문자열 일부 추출
            var bestWork = target2.Substring(index, target2.Length - index);
            Console.WriteLine(bestWork);

            ////////////////////////// 문자열 변환 ////////////////////////////

            // 문자열 앞뒤 공백 제거
            var target3 = " 호날두 메시 ";
            var replaced = target3.Trim();
            Console.WriteLine(replaced);
            // 한 쪽 공백만 제거
            var replaced1 = target3.TrimStart();
            var replaced2 = target3.TrimEnd();
            Console.WriteLine(replaced1 + replaced2);
            // 지정 위치부터 임의 개수 문자 삭제
            var result = target2.Remove(5, 3);
            Console.WriteLine(result);
            // 문자열에 다른 문자열 삽입
            var result1 = target2.Insert(2, "abc");
            // 문자열 일부 다른 문자열로 치환
            var replaced3 = target2.Replace("BestWork", "GOAT");
            // 대소문자 변환
            var replaced4 = target2.ToUpper();
            var replaced5 = target2.ToLower();

            ////////////////////////// 문자열 연결, 분할 ////////////////////////////
            var name = "호" + "날두";
            var name1 = "호날두";
            name1 += ": GOAT";
            // 지정한 구분 문자로 문자열 배열 연결
            var people = new[] { "호날두", "메시", "벨링엄", "음바페", };
            var seperator = ", ";
            var result5 = String.Join(seperator, people);
            Console.WriteLine(result5);

            // StringBuilder
            // 문자열은 불변 객체임. 문자열에 변동사항이 생길때마다 새로운 인스턴스가 생성됨
            // 아래 코드를 실행하면 ABC뒤에 XYZ가 연결되는 것이 아니라 새로운 6자 크기의 인스턴스가 생성되고
            // 그 인스턴스에 ABC가 복사되고 그 뒤에 XYZ가 복사됨
            // 즉 메모리 자원낭비 발생
            var s1 = "ABC";
            s1 = s1 + "XYZ";
            // 이를 해결하기 위해 StringBuilder 사용. 다만 반복처리를 하지 않을 경우에는 + 연산자로 문자열 연결 권장
            var sb = new StringBuilder();   // StringBuilder 객체 생성
            foreach (var word in name1)
            {
                sb.Append(word);
            }
            var text = sb.ToString();
            Console.WriteLine(text);

            // 문자열 하나씩 꺼낼 때 - foreach 사용
            // 문자 배열로 문자열 생성
            var chars = new char[] { 'a', 'b', 'c', 'd', };
            var str = new string(chars);
        }
    }
}
