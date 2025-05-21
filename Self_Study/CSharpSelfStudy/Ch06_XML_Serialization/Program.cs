using System.Text;
using System.Xml.Serialization;

namespace Ch06_XML_Serialization
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
            MemoryStream ms = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(Person));

            Person person = new Person(41, "Ronaldo");

            // MemoryStream에 문자열로 person 객체 직렬화
            xs.Serialize(ms, person);

            ms.Position = 0;

            // MemoryStream으로부터 객체를 역직렬화해서 복원
            Person clone = xs.Deserialize(ms) as Person;

            Console.WriteLine(clone);

            byte[] buf = ms.ToArray();
            Console.WriteLine(Encoding.UTF8.GetString(buf));

            // XML 텍스트 역직렬화
            string text = @"<?xml version=""1.0"" encoding=""utf-8""?>
                            <Person xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                              <Age>41</Age>
                              <Name>Ronaldo</Name>
                            </Person>";

            byte[] buf1 = Encoding.UTF8.GetBytes(text);
            MemoryStream ms1 = new MemoryStream(buf1);
            XmlSerializer xs1 = new XmlSerializer(typeof(Person));
            Person clone1 = xs1.Deserialize(ms1) as Person;
            Console.WriteLine(clone1);

        }
    }
}
