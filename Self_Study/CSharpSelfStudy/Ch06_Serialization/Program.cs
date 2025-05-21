using System.Text;

namespace Ch06_Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 기본 타입을 바이트 배열로 반환
            byte[] boolBytes = BitConverter.GetBytes(true);
            byte[] shortBytes = BitConverter.GetBytes((short)32000);
            byte[] intBytes = BitConverter.GetBytes(1652300);

            // 바이트 배열을 기본 타입으로 복원
            bool boolResult = BitConverter.ToBoolean(boolBytes, 0);
            short shortResult = BitConverter.ToInt16(shortBytes, 0);
            int intResult = BitConverter.ToInt32(intBytes, 0);

            // 바이트 배열을 16진수로 출력
            Console.WriteLine(BitConverter.ToString(boolBytes));
            Console.WriteLine(BitConverter.ToString(shortBytes));
            Console.WriteLine(BitConverter.ToString(intBytes));

            int n = 1652300;
            string text = n.ToString(); // 숫자 1652300을 문자열로 직렬화
            int result = int.Parse(text);   // 문자열로부터 숫자를 역직렬화해서 복원

            MemoryStream ms = new MemoryStream();
            // offset = 현재 주소와 기준 주소 사이 떨어진 거리
            // int[] arr = { 1, 2 } 에서 arr[1]은 4
            ms.Write(shortBytes, 0, shortBytes.Length);
            ms.Write(intBytes, 0, intBytes.Length);

            ms.Position = 0;

            // MemoryStream으로부터 short 데이터 역직렬화
            byte[] outBytes = new byte[2];
            ms.Read(outBytes, 0, 2);
            int shortRes = BitConverter.ToInt16(outBytes, 0);
            Console.WriteLine(shortRes);

            // int 데이터 역직렬화
            outBytes = new byte[4];
            ms.Read(outBytes, 0, 4);
            int intRes = BitConverter.ToInt32(outBytes, 0);
            Console.WriteLine(intRes);

            byte[] shortBytes1 = BitConverter.GetBytes((short)32000);
            byte[] intBytes1 = BitConverter.GetBytes(1652300);

            MemoryStream ms1 = new MemoryStream();
            ms1.Write(shortBytes1, 0, shortBytes1.Length);
            ms1.Write(intBytes1, 0, intBytes1.Length);

            byte[] buf = ms1.ToArray(); // MemoryStream에 담긴 바이트 배열 반환

            // 바이트 배열로부터 short 데이터 역직렬화
            int shortRes1 = BitConverter.ToInt16(buf, 0);
            Console.WriteLine(shortRes1);

            // int 데이터 역직렬화
            int intRes1 = BitConverter.ToInt32(buf, 2);
            Console.WriteLine(intRes1);

            // string 직렬화/역직렬화
            MemoryStream ms2 = new MemoryStream();

            StreamWriter sw = new StreamWriter(ms2, Encoding.UTF8);
            sw.WriteLine("Hello World");
            sw.WriteLine("Ronaldo");
            sw.WriteLine(32000);
            sw.Flush();

            ms2.Position = 0;   // 읽기 작업 전 항상 Position 0으로 되돌리는 것 잊으면 안 됨

            StreamReader sr = new StreamReader(ms2, Encoding.UTF8);
            string txt = sr.ReadToEnd();
            Console.WriteLine(txt);


        }
    }
}
