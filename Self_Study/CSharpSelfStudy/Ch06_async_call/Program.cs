using System.Text;

namespace Ch06_async_call
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 동기 방식 파일 읽기
            // HOSTS 파일 읽어서 내용 출력
            using (FileStream fs =
                   new FileStream(@"C:\Windows\System32\drivers\etc\hosts", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                byte[] buf = new byte[fs.Length];
                fs.Read(buf, 0, buf.Length);

                string txt = Encoding.UTF8.GetString(buf);
                Console.WriteLine(txt);
            }
        }
    }
}
