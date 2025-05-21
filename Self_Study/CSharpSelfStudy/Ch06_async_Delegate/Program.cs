using System.Security.Cryptography.X509Certificates;

namespace Ch06_async_Delegate
{
    public class Calc
    {
        public static long Cumsum(int start, int end)
        {
            long sum = 0;
            
            for (int i = start; i <= end; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
    internal class Program
    {
        public delegate long CalcMethod(int start, int end);
        static void Main(string[] args)
        {
            CalcMethod calc = new CalcMethod(Calc.Cumsum);
            // Delegate 타입의 BeginInvoke 메서드 호출
            // 이 때문에 Calc.Cumsum 메서드는 ThreadPool의 스레드에서 실행됨
            IAsyncResult ar = calc.BeginInvoke(1, 100, null, null);

            // BeginInvoke로 반환받은 IAsyncResult 타입의 AsyncWaitHandle 속성은 EventWaitHandle 타입임
            // AsyncWaitHandle 객체는 스레드 풀에서 실행된 Calc.Cumsum 동작이 완료됐을 때 Signal 상태로 바뀜
            // 따라서 아래와 같이 호출하면 Calc.Cumsum 메서드 수행 완료될 때까지 현재 스레드 대기시킴
            ar.AsyncWaitHandle.WaitOne();

            // Calc.Cumsum 반환값 얻기 위해 EndInvoke 메서드 호출
            // 반환값 없어도 EndInvoke는 반드시 호출하는 것 권장
            long result = calc.EndInvoke(ar);

            Console.WriteLine(result);
        }
    }
}
