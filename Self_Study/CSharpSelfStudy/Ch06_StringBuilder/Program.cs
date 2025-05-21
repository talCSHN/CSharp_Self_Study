using System.Text;

namespace Ch06_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 아래 실행하면 실행시간 약 27초 걸림
            //string txt = "Hello World";
            //for (int i = 0; i < 300000; i++)
            //{
            //    txt = txt + "1";
            //}

            // 개선
            string txt = "Hello World";
            StringBuilder sb = new StringBuilder();
            sb.Append(txt);
            for (int i = 0; i < 300000; i++)
            {
                sb.Append("1");
            }
            string newText = sb.ToString();
            Console.WriteLine(newText);
        }
    }
}
