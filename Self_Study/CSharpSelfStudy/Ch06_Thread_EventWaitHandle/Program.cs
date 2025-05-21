namespace Ch06_Thread_EventWaitHandle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Non-Signal 상태 이벤트 객체 생성
            // 생성자의 첫 번째 인자가 false면 Non-Signal 상태로 시작
            // true면 Signal 상태로 시작
            EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.ManualReset);
            Thread t = new Thread(threadFunc);
            t.IsBackground = true;
            t.Start(ewh);
            // Non-Signal 상태에서 WaitOne 호출했으므로 Signal 상태로 바뀔 때까지 대기
            ewh.WaitOne();
            Console.WriteLine("메인 스레드 종료");
        }
        static void threadFunc(object state)
        {
            EventWaitHandle ewh = state as EventWaitHandle;

            Console.WriteLine("5초 후 프로그램 종료");
            Console.WriteLine("스레드 종료");
            Thread.Sleep(1000 * 5); // 5초 동안 실행 중지

            // Non-Signal 상태 이벤트를 Signal 상태로 전환
            ewh.Set();
            
        }
    }
}
