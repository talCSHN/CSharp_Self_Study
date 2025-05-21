using System.Collections;
using System.Reflection.Metadata.Ecma335;
namespace Ch06_ArrayList
{
    internal class Program
    {
        public class Person : IComparable
        {
            public int Age;
            public string Name;
            public Person(int age, string name)
            {
                this.Age = age;
                this.Name = name;
            }
            public int CompareTo(object obj)    // 나이 순으로 정렬
            {
                Person target = obj as Person;

                if (this.Age > target.Age)
                {
                    return 1;
                }
                else if (this.Age == target.Age)
                {
                    return 0;
                }
                return -1;
            }
            public override string ToString()
            {
                return string.Format("{0} {1}", this.Name, this.Age);
            }
        }
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();

            // 4개의 요소 컬렉션에 추가
            al.Add("Hello");
            al.Add(6);
            al.Add("World");
            al.Add(true);

            // 숫자 6 포함하고 있는지 판단
            Console.WriteLine("6 존재 여부 : " + al.Contains(6));

            // "World"문자열 컬렉션에서 삭제
            al.Remove("World");

            // 2번째 요소값 false로 변경
            al[2] = false;

            Console.WriteLine();

            // 컬렉션의 모든 요소 출력
            foreach (object obj in al)
            {
                Console.WriteLine(obj);
            }

            ArrayList al1 = new ArrayList();

            al1.Add("Hello");
            al1.Add("World");
            al1.Add("Sample");
            al1.Add("Test");

            al1.Sort();
            foreach (string txt in al1)
            {
                Console.WriteLine(txt);
            }

            ArrayList pal = new ArrayList();

            pal.Add(new Person(41, "Ronaldo"));
            pal.Add(new Person(39, "Messi"));
            pal.Add(new Person(31, "Pan"));
            pal.Add(new Person(16, "Kyotaro"));

            pal.Sort();
            foreach (Person p in pal)
            {
                Console.WriteLine(p);   // ToString 오버라이딩 해놔서 따로 호출 안해도 됨
            }

        }
    }
}
