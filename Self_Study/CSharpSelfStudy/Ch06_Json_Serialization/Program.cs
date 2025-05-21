using System.Text.Json;

namespace Ch06_Json_Serialization
{
    public class Person
    {
        public int Age;
        public string Name;

        public Person()
        {

        }
        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Age, this.Name);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(41, "Ronaldo");
            // 기본적으로 System.Text.Json 에서는 field는 무시하고 property만 직렬화
            // IncludeFields=true 옵션으로 public 필드도 직렬화 대상에 포함
            JsonSerializerOptions options = new JsonSerializerOptions { IncludeFields=true };
            string text = JsonSerializer.Serialize(person, options);
            Console.WriteLine(text);

            Person clone = JsonSerializer.Deserialize<Person>(text, options);
            Console.WriteLine(clone);
        }
    }
}
