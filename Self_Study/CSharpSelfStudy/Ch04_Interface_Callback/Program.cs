namespace Ch04_Interface_Callback
{
    internal class Program
    {
        interface ISource
        {
            int GetResult();
        }
        class Source : ISource
        {
            public int GetResult()
            {
                return 10;
            }
            public void Test()
            {
                Target target = new Target();
                target.Do(this);
            }
        }
        class  Target
        {
            public void Do(ISource obj) // Source 타입 말고 ISource 인터페이스를 받음
            {
                Console.WriteLine(obj.GetResult()); // 콜백 메서드 호출
            }
        }
        static void Main(string[] args)
        {
            Target target = new Target();
            target.Do(new Source()); // Source 객체를 ISource 인터페이스로 전달
        }
    }
}
