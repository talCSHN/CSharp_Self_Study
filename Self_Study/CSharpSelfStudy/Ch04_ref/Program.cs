using System.Numerics;

namespace Ch04_ref
{
    internal class Program
    {
        struct Vector
        {
            public int X;
            public int Y;

            public Vector(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                return "X: " + this.X + ", Y: " + this.Y;
            }
        }
        class Point
        {
            public int X;
            public int Y;
            public Point()
            {

            }
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public override string ToString()
            {
                return "X: " + this.X + ", Y: " + this.Y;
            }
        }
        static void Change(ref Vector vector)
        {
            vector.X = 100;
            vector.Y = 200;
        }
        static void Change(ref Point point)
        {
            point.X = 100;
            point.Y = 200;
        }
        static void Change(Point point)
        {
            point = new Point();

            point.X = 100;
            point.Y = 200;
        }
        static void refChange(ref Point point)
        {
            point = new Point();

            point.X = 1000;
            point.Y = 2000;
        }
        static void SwapValue(ref int value1, ref int value2)
        {
            int temp = value1;
            value1 = value2;
            value2 = temp;
        }
        static void Main(string[] args)
        {
            Vector v1;
            v1.X = 5;
            v1.Y = 10;

            Change(ref v1);
            Console.WriteLine("v1.X = " + v1.X + ", v1.Y: " + v1.Y);

            Point pt1 = new Point();
            pt1.X = 5;
            pt1.Y = 10;

            Change(ref pt1);
            Console.WriteLine("pt1.X = " + pt1.X + ", pt1.Y: " + pt1.Y);    // 기존의 얕은 복사와 동일

            Point pt2 = null;
            Change(pt2);    // 얕은 복사
            Console.WriteLine("pt = " + pt2);

            refChange(ref pt2); // ref 이용한 참조에 의한 호출
            Console.WriteLine("pt2.X = " + pt2.X + ", pt2.Y: " + pt2.Y);

            int num1 = 5;
            int num2 = 10;

            SwapValue(ref num1, ref num2);
            Console.WriteLine("num1 : " + num1 + ", num2 : " + num2);
        }
    }
}
