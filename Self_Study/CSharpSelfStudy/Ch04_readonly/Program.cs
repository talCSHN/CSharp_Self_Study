using System.Drawing;

namespace Ch04_readonly
{
    internal class Program
    {
        public class Scheduler
        {
            readonly int second = 1;    // 읽기 전용 필드 정의 및 값 대입
            readonly string name;       // 읽기 전용 필드 정의

            public Scheduler()
            {
                this.name = "일정 관리";    // 읽기 전용 필드는 생성자에서도 대입 가능
            }

            public void Run()
            {
                //this.second = 5;    // 컴파일 에러. 일반 메서드에서는 값 대입 불가
            }
            // 읽기 전용 필드는 변수 정의할 때, 생성자 내부 제외하고 값 변경 불가
            // 기본적으로 일반적인 객체는 필드의 값이 변경될 수 있는데 이를 mutable object(가변 객체)라고 함
            // readonly 지정으로 객체의 상태가 한 번 지정되면 다시 바뀔 수 없을때 immutable object(불변 객체)라고 함

            // 아래의 경우도 불변 객체에 해당
            public class Point
            {
                int x, y;
                public int X
                {
                    get { return x; }
                }
                public int Y
                {
                    get { return y; }
                }
                public Point(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
            }
        }
        static void Main(string[] args)
        {
            Point pt = new Point(5, 10);
            Point pt2 = new Point(pt.X + 1, pt.Y + 1);
            // 위의 경우는 기존 pt값에서 X, Y 방향으로 1씩 증가한 상태를 얻고 싶은데, setter가 없어서 내부 값 변경이 불가함
            // 별도의 Point 객체를 만들어야만 한다
            // 즉, 불변객체이므로 객체의 내부값을 변경할 수 없는 상태
        }
    }
}
