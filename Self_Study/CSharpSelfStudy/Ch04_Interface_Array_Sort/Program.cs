using System.Collections;   // IComparer 정의된 네임스페이스 사용
namespace Ch04_Interface_Array_Sort
{
    internal class Program
    {
        class IntegerCompare : IComparer    // IComparer 상속받는 타입 정의
        {
            // IComparer 인터페이스의 Compare 메서드 구현
            // 이 메서드는 Array.Sort() 메서드내에서 콜백으로 호출됨
            public int Compare(object x, object y)
            {
                int xValue = (int)x;   // object를 int로 변환
                int yValue = (int)y;   // object를 int로 변환

                if (xValue > yValue) return -1; // 내림차순 정렬이 되도록 -1 반환
                else if (xValue == yValue) return 0;

                return 1;
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };

            // IComparer 인터페이스를 상속한 IntegerCompare 인스턴스 전달
            Array.Sort(arr, new IntegerCompare()); // 콜백 메서드 호출
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
        }
    }
}
