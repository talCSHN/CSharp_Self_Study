// 부모 클래스의 인스턴스 생성하지 못하게 하고 특정 메서드를 자식 클래스에서 재정의하도록 강제
// Abstract class : 추상 클래스. abstract 예약어가 지정된 클래스
// Abstract method : 추상 메서드. abstract 예약어가 지정되고 구현 코드가 없는 메서드
// Abstract class는 인스턴스를 생성할 수 없음
// 추상메서드는 일반 클래스에 존재 불가. 반드시 추상 클래스 안에서만 선언 가능
namespace Ch04_Abstract_Class
{
    internal class Program
    {
        class Point
        {
            int x, y;

            public Point(int x, int y)
            {
                this.x = x; ; this.y = y;
            }
            public override string ToString()
            {
                return "X: " + x + ", Y : " + y;
            }
        }
        abstract class DrawingObject
        {
            public abstract void Draw();    // 추상 메서드. 구현 코드 없음

            public void Move() { Console.WriteLine("Move"); }   // 일반 메서드도 정의 가능
        }
        class Line : DrawingObject
        {
            Point pt1, pt2;
            public Line(Point pt1, Point pt2)
            {
                this.pt1 = pt1;
                this.pt2 = pt2;
            }
            public override void Draw()
            {
                Console.WriteLine("Draw Line from " + pt1.ToString() + " ~ " + pt2.ToString());
            }
        }
        static void Main(string[] args)
        {
            DrawingObject line = new Line(new Point(10, 10), new Point(20, 20));
            Point pt1 = new Point(100, 100);
            Point pt2 = new Point(200, 200);
            DrawingObject line2 = new Line(pt1, pt2);

            line.Draw();
        }
    }
}
