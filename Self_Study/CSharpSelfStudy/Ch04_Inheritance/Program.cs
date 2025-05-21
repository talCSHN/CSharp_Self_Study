namespace Ch04_Inheritance
{
    internal class Program
    {
        public class Computer
        {
            protected bool powerOn;
            public void Boot() { }
            public void Shutdown() { }
            public void Reset() { }
        }
        public class Notebook : Computer
        {
            bool fingerScan;
            public bool HasFingerScanDevice() {  return fingerScan; }
            public void CloseLid()
            {
                if (powerOn == true)
                {
                    Shutdown();
                }
            }
        }
        public class Desktop : Computer
        {

        }
        public class Netbook : Computer
        {

        }
        //public class MacBook : Computer, Notebook { } // 단일 상속만 가능. 컴파일 오류 발생
        sealed class Pen
        {

        }
        //public class ElectricPen : Pen { }    // sealed 클래스는 상속 불가 컴파일 오류 발생

        static void Main(string[] args)
        {
            Notebook noteBook = new Notebook();
            noteBook.Boot();
        }
    }
}
