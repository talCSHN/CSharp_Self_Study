using System.Collections;
namespace Ch06_Hashtable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();

            // 컬렉션에 4개의 요소 추가
            ht.Add("key1", "add");
            ht.Add("key2", "remove");
            ht.Add("key3", "update");
            ht.Add("key4", "search");

            // "key4" 키 값에 해당하는 값 출력
            Console.WriteLine(ht["key4"]);

            // "key3" 키 값에 해당하는 요소를 컬렉션에서 삭제
            ht.Remove("key3");

            // "key2" 키 값에 해당하는 값 "delete"로 변경
            ht["key2"] = "delete";

            Console.WriteLine();

            // 컬렉션의 모든 키 값 열람, 그 키에 대응되는 값 출력
            foreach (object key in ht.Keys)
            {
                Console.WriteLine("{0} ==> {1}", key, ht[key]);
            }
        }
    }
}
