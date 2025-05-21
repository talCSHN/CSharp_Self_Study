namespace Ch04_Property
{
    internal class Program
    {
        class Circle
        {
            double pi = 3.14;
            
            // 자동 구현 프로퍼티는 간단 저장/조회용. private 필드에 접근하려면 직접 get/set 구현해야함
            public int radius { get; set; }

            public double pi1
            {
                get { return pi; }
                set { pi = value; }
            }
        }
        static void Main(string[] args)
        {
            Circle o = new Circle();
            o.pi1 = 3.141592;
            double piValue = o.pi1;
            o.radius = 1;
            int radVal = o.radius;
        }
    }
}
