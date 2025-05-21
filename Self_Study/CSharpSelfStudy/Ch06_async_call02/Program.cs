using System.Text;
namespace Ch06_async_call02
{
    class FileState
    {
        public byte[] Buffer;
        public FileStream File;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Windows\System32\drivers\etc\hosts",
                            FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 4096, true);

            FileState state = new FileState();
            state.Buffer = new byte[fs.Length];
            state.File = fs;

            fs.BeginRead(state.Buffer, 0, state.Buffer.Length, readCompleted, state);

            // BeginRead 비동기 메서드 호출은 스레드로 곧바로 제어를 반환하기 때문에
            // 이 곳에서 자유롭게 다른 연산 동시에 진행 가능

            Console.ReadLine();
            fs.Close();
        }
        static void readCompleted(IAsyncResult ar)
        {
            FileState state = ar.AsyncState as FileState;
            state.File.EndRead(ar);

            string txt = Encoding.UTF8.GetString(state.Buffer);
            Console.WriteLine(txt);
        }
    }
}
