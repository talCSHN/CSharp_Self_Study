namespace Ch04_explicit
{
    internal class Program
    {
        public class Currency
        {
            decimal money;
            public decimal Money { get { return money;  } }

            public Currency(decimal money)
            {
                this.money = money;
            }
        }
        public class Won : Currency
        {
            public Won(decimal money) : base(money)
            {

            }
            public override string ToString()
            {
                return Money + "Won";
            }
        }
        public class  Dollar : Currency
        {
            public Dollar(decimal money) : base(money)
            {

            }
            public override string ToString()
            {
                return Money + "Dollar";
            }
            static public explicit operator Won(Dollar dollar)
            {
                return new Won(dollar.Money * 1000m);
            }
        }
        public class  Yen : Currency
        {
            public Yen(decimal money) : base(money)
            {

            }
            public override string ToString()
            {
                return Money + "Yen";
            }
        }
        static void Main(string[] args)
        {
            Won won = new Won(1000);
            Dollar dollar = new Dollar(1);
            Yen yen = new Yen(13);

            Console.WriteLine(won.ToString());

            //Won won1 = dollar; // 암시적 형변환 불가능. 컴파일 오류
            Won won2 = (Won)dollar; // 명시적 형변환 가능

            Console.WriteLine(won2);

            //won = yen;    // 컴파일 오류
        }
    }
}
