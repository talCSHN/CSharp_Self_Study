namespace Ch04_DeepCopy_ShallowCopy
{
    internal class Program
    {
        struct Vector
        {
            public int X;
            public int Y;

            public override string ToString()
            {
                return "X: " + this.X + ", Y: " + this.Y;
            }
        }
        class Point
        {
            public int X;
            public int Y;

            public override string ToString()
            {
                return "X: " + this.X + ", Y: " + this.Y;
            }
        }
        static void Change(Vector vector)
        {
            vector.X = 100;
            vector.Y = 200;
        }
        static void Change(Point point)
        {
            point.X = 100;
            point.Y = 200;
        }
        static void Main(string[] args)
        {
            Vector v1;
            v1.X = 5;
            v1.Y = 10;

            Vector v2 = v1;     // 값 형식 대입. 깊은 복사

            v2.X = 7;
            v2.Y = 14;

            Console.WriteLine(v1.ToString());
            Console.WriteLine(v2.ToString());

            Point pt1 = new Point();
            pt1.X = 6;
            pt1.Y = 12;

            Point pt2 = pt1;    // 참조 형식 대입. 얕은 복사

            pt2.X = 8;
            pt2.Y = 16;

            Console.WriteLine(pt1.ToString());
            Console.WriteLine(pt2.ToString());

            Change(v1);
            Console.WriteLine(v1.ToString());

            Change(pt1);
            Console.WriteLine(pt1.ToString());
        }
    }
}
