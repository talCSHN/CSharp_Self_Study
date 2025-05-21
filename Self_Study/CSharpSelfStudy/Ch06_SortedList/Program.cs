using System.Collections;

namespace Ch06_SortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList sl = new SortedList();

            sl.Add(41, "Ronaldo");
            sl.Add(39, "Messi");
            sl.Add(31, "Pan");
            sl.Add(16, "Kyotaro");

            foreach (int key in sl.GetKeyList())
            {
                Console.WriteLine(string.Format("{0} {1}", key, sl[key]));
            }
        }
    }
}
