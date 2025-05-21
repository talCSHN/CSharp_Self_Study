using System.Collections;
namespace Ch04_Interface_IEnumerable
{
    internal class Program
    {
        class Hardware { }
        class USB
        {
            string name;
            public USB(string name)
            {
                this.name = name;
            }
            public override string ToString()
            {
                return this.name;
            }
        }
        class Notebook : Hardware, IEnumerable  // IEnumarable 인터페이스 구현
        {
            USB[] usbList = new USB[] { new USB("USB1"), new USB("USB2") };
            public IEnumerator GetEnumerator()  // IEnumerator를 구현한 열거자 인스턴스 반환
            {
                return new USBEnumerator(usbList);
            }
            public class USBEnumerator : IEnumerator   // 중첩클래스로 정의된 열거자 타입
            {
                int pos = -1;
                int length = 0;
                object[] list;
                public USBEnumerator(USB[] usb)
                {
                    list = usb;
                    length = usb.Length;
                }
                public object Current
                {
                    get { return list[pos]; }
                }
                public bool MoveNext()  // INumerator 인터페이스 내에 있는 메서드 재정의
                {
                    if (pos >= length - 1)
                    {
                        return false;
                    }
                    pos++;
                    return true;
                }
                public void Reset() // 처음부터 열거하고 싶을 때 호출하면 되는 메서드
                                    // INumerator 인터페이스 내에 있는 메서드 재정의
                {
                    pos = -1;

                }
            }
        }
        
        static void Main(string[] args)
        {
            int[] intArr = new int[] { 1, 2, 3, 4, 5 };
            IEnumerator enumerator = intArr.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.Write(enumerator.Current + " ");
            }
            Console.WriteLine();
            Notebook notebook = new Notebook();
            foreach (USB usb in notebook)
            {
                Console.WriteLine(usb);
            }
        }
    }
}
