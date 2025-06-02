namespace Practical_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>
            {
                "Seoul", "Busan","Tokyo","Fukuoka","Osaka","Kumamoto","Sapporo",
            };

            IEnumerable<string> query = names.Where(s => s.Length <= 5);
            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
            // IEnumerable<T> 인터페이스를 구현하고 있는 형이기만 하면 Where 메서드를 해당 객체를 대상으로 이용 가능
            // 위의 코드와 같은 결과를 만드는 FindAll은 List<T>만 가능
            // LINQ는 서로 다른 형의 컬렉션이어도 IEnumerable<T> 인터페이스를 구현한다면 같은 메서드 이용 가능

            // Where 메서드의 반환값은 IEnumerable<T> 타입
            IEnumerable<string> query1 = names.Where(s => s.Length <= 5).Select(s => s.ToLower());
            // Select 메서드도 IEnumerable<T>에 대해 이용할 수 있는 메서드. Where 반환값이 IEnumerable<T>기 때문에 메서드 체인 형태로 Select 사용 가능
            // 
            foreach (string s in query1)
            {
                Console.WriteLine(s);
            }
            // 실제 코드에서는 일반적으로 var query로 사용
            var query2 = names.Select(s => s.Length);
            foreach (var n in query2)
            {
                Console.Write("{0} ", n);
            }
        }
    }
}
