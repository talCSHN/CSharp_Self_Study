namespace Practical_LINQ_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 지연실행 테스트
            string[] names =
            {
                "Seoul", "Busan","Tokyo","Fukuoka","Osaka","Kumamoto","Sapporo",
            };
            var query = names.Where(s => s.Length <= 5);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------");

            names[0] = "Busan";
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------");
            // 결과 - Where 메서드 호출했을 때 검색 처리 동작하고 그 결과가 query에 저장됐으면 names 수정 여부와 상관없이 결과가 같아야 하지만
            /*
            Seoul
            Busan
            Tokyo
            Osaka
            ----------------
            Busan
            Busan
            Tokyo
            Osaka 
            */
            // 위처럼 결과가 다르게 나옴
            // 즉 query 변수에는 검색된 결과가 대입되는 것이 아님
            // Where 메서드가 호출돼도 검색은 해당 시점에서 실행되지 않고 실제 값이 필요할 때 쿼리가 실행됨
            // 이를 지연실행이라 함
            // LINQ 특징 - 실제 데이터가 필요할 때(위의 경우에서는 foreach에서 요소를 꺼냈을 때) 쿼리 실행됨.

            // 경우에 따라 쿼리를 명시적으로 실행하고 싶을 때 - ToArray, ToList 사용
            // 즉시 실행
            string[] names1 =
            {
                "Seoul", "Busan","Tokyo","Fukuoka","Osaka","Kumamoto","Sapporo",
            };
            var query1 = names.Where(s => s.Length <= 5).ToArray(); // 여기서 배열로 변환되면서 결과가 저장됨
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------");

            names1[0] = "Busan";
            foreach (var item in query1)
            {
                Console.WriteLine(item);
            }
            // Count도 즉시 실행 메서드
            string[] names2 =
            {
                "Seoul", "Busan","Tokyo","Fukuoka","Osaka","Kumamoto","Sapporo",
            };
            var nCount = names.Count(s => s.Length <= 5);
            Console.WriteLine(nCount);
        }
    }
}
