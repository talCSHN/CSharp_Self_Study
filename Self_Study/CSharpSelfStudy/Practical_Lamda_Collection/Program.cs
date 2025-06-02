namespace Practical_Lamda_Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List<T>
            var list = new List<string>
            {
                "Seoul", "Busan","Tokyo","Fukuoka","Osaka","Kumamoto","Sapporo",
            };
            // Exists
            var exists = list.Exists(s => s[0] == 'A');
            Console.WriteLine(exists);
            // Find
            var name = list.Find(s => s.Length == 5);
            Console.WriteLine($"name : {name}");
            // FindIndex
            int index = list.FindIndex(s => s == "Tokyo");
            Console.WriteLine(index);
            // FindAll
            var names = list.FindAll(s => s.Length <= 5);
            Console.WriteLine(names.GetType()); // List<string>형 반환
            foreach (var s in names)
            {
                Console.WriteLine(s);
            }
            // RemoveAll
            var removedCount = list.RemoveAll(s => s.Contains("po"));
            Console.WriteLine(removedCount);
            Console.WriteLine(list[list.Count - 1]);
            // ForEach - Predicate<T> 델리게이트 대신 Action<T> 델리게이트를 인수로 받음
            list.ForEach(s => Console.WriteLine($"ForEach : {s}"));
            // ConvertAll
            var lowerList = list.ConvertAll(s => s.ToLower());
            lowerList.ForEach(s => Console.WriteLine(s));
        }
    }
}
