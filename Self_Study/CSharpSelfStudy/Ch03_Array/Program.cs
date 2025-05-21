namespace Ch03_Array
{
    internal class Program
    {
        private static void OutputArrayInfo(Array arr)
        {
            Console.WriteLine("배열 차원 수 : " + arr.Rank);  // Rank 프로퍼티
            Console.WriteLine("배열 요소 수 : " + arr.Length);   // Length 프로퍼티
            Console.WriteLine();
        }

        private static void OutputArrayElements(string title, Array arr)
        {
            Console.WriteLine("[" + title + "]");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr.GetValue(i) + ", ");  // GetValue 인스턴스 메서드
            }

            Console.WriteLine();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            // 배열은 System.Array로부터 상속받은 참조형 타입
            // Rank - 타입 : 인스턴스 프로퍼티. 동작 : 배열 인스턴스의 차원(dimension) 수 반환
            // Length - 타입 : 인스턴스 프로퍼티. 동작 : 배열 인스턴스의 요소(element) 수 반환
            // GetValue - 타입 : 인스턴스 메서드. 동작 : 지정된 인덱스의 배열 요소 값 반환
            // Sort - 타입 : static method. 동작 : 배열 요소를 값 순서대로 정렬
            // Copy - 타입 : static method. 동작 : 배열 내용을 다른 배열에 복사
            int[] products = new int[5] { 1, 2, 3, 4, 5 };
            int[] nums = new int[] { 1, 2, 3, 4, 5 };
            string[] names = new string[5];

            int[,] arr2 = new int[2, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };
            int[][] arr = new int[5][];
            arr[0] = new int[10];

            bool[,] boolArray = new bool[,] { {  true, false }, { false, false } };
            OutputArrayInfo(boolArray);

            int[] intArray = new int[] { 5, 4, 3, 2, 1, 0 };
            OutputArrayInfo(intArray);
            OutputArrayElements("원본 intArray", intArray);
            Array.Sort(intArray);
            OutputArrayElements("Array.Sort 후 intArray", intArray);

            int[] copyArr = new int[intArray.Length];
            Array.Copy(intArray, copyArr, intArray.Length);

            OutputArrayElements("intArray로부터 복사된 copyArr", copyArr);
        }
    }
}
