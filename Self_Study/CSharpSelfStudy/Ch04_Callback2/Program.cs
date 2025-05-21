namespace Ch04_Callback2
{
    internal class Program
    {
        public delegate bool CompareDelegate(object arg1, object arg2);
        class SortObject
        {
            object[] things;
            public SortObject(object[] things)
            {
                this.things = things;
            }
            public void Sort(CompareDelegate compareMethod)
            {
                object temp;
                for (int i = 0; i < things.Length; i++)
                {
                    int lowPos = i;
                    for (int j = i + 1; j < things.Length; j++)
                    {
                        if (compareMethod(things[j], things[lowPos]))
                        {
                            lowPos = j;
                        }

                    }
                    temp = things[lowPos];
                    things[lowPos] = things[i];
                    things[i] = temp;
                }
            }
            public void Display()
            {
                for (int i = 0; i < things.Length; i++)
                {
                    Console.Write(things[i] + " ");
                }
                Console.WriteLine();
            }
        }
        static bool Ascending(object arg1, object arg2)
        {
            return arg1.GetHashCode() < arg2.GetHashCode();
        }
        static bool Descending(object arg1, object arg2)
        {
            return arg1.GetHashCode() > arg2.GetHashCode();
        }
        static void Main(string[] args)
        {
            object[] objArray = new object[] { 5, 2, 3, 1, 0, 4 };
            SortObject so = new SortObject(objArray);
            Console.WriteLine("Test: " + objArray[0].GetHashCode());
            Console.WriteLine("Test2: " + objArray[0].GetHashCode().GetType());
            so.Sort(Ascending);
            so.Display();
            so.Sort(Descending);
            so.Display();
        }
    }
}
