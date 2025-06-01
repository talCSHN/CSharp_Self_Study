using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Ch07_Generics
{
    public class OldStack
    {
        object[] _objList;
        int _pos;

        public OldStack(int size)
        {
            _objList = new object[size];
        }
        public void Push(object newValue)
        {
            _objList[_pos] = newValue;
            _pos++;
        }
        public object Pop()
        {
            _pos--;
            return _objList[_pos];
        }
    }
    // 제네릭 클래스
    public class NewStack<T>
    {
        T[] _objList;
        int _pos;

        public NewStack(int size)
        {
            _objList = new T[size];
        }
        public void Push(T newValue)
        {
            _objList[_pos] = newValue;
            _pos++;
        }
        public T Pop()
        {
            _pos--;
            return _objList[_pos];
        }
    }
    internal class Program
    {
        // 일반 메서드
        // 박싱으로 인한 불필요한 힙 메모리 사용 방지하기 위해 타입별로 메서드를 중복해서 구현해야함
        public static void WriteLog(object item)
        {
            Console.WriteLine(item);
        }
        // 이를 해결하기 위해 제네릭 메서드 사용
        public static void WriteLog1<T>(T item)
        {
            Console.WriteLine(item);
        }
        static void Main(string[] args)
        {
            // 박싱/언박싱 발생
            int n = 5;
            ArrayList ar = new ArrayList();
            ar.Add(n);
            // 제네릭을 사용하여 해결
            List<int> list = new List<int>();
            list.Add(n);
            
            
            OldStack stack = new OldStack(10);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            // OldStack의 문제점 
            // 구현하고자 하는 타입별 스택 클래스를 별도로 생성해야함
            // 제네릭을 통해 해결
            NewStack<int> intStack = new NewStack<int>(10);
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);
            
            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());

            // 제네릭 메서드 사용
            WriteLog1(true);
            WriteLog1(1);
            WriteLog1("Generic Method");

            // 제네릭 적용한 BCL
            /*
            ArrayList -> List<T>
            Hashtable -> Dictionary<TKey, TValue>
            SortedList -> SortedDictionary<TKey, TValue>
            Stack -> Stack<T>
            Queue -> Queue<T>
            */
            // 제네릭 적용한 인터페이스
            /*
            IComparable -> IComparable<T>
            IComparer -> IComparer<T>
            IEnumerable -> IEnumerable<T>
            IEnumerator -> IEnumerator<T>
            ICollection -> ICollection<T>
            */

        }
    }
}
