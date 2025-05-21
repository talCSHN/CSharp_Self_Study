namespace Ch04_Nested_Class
{
    internal class Program
    {
        class HardDisk      // class의 경우 접근 제한자 생략하면 기본적으로 internal
        {
            class Platter   // 중첩 클래스의 경우 접근 제한자 생략되면 다른 멤버와 마찬가지로 private 지정
            {

            }
            class Head
            {

            }
        }
        static void Main(string[] args)
        {
            //HardDisk.Head head = new HardDisk.Head(); // 접근 제한 컴파일 오류
        }
    }
}
