namespace Ch04_Interface
{
    internal class Program
    {
        class Computer
        {

        }
        interface Imonitor
        {
            void TurnOn();
            // 인터페이스에 프로퍼트 포함도 가능
            int Inch { get; set; }
            int Width { get; }
        }
        interface Ikeyboard { }
        
        class Notebook : Computer, Imonitor, Ikeyboard
        {
            public void TurnOn()    // 인터페이스의 메서드를 자식 클래스에서 구현할 때는 반드시 public 접근제한자 명시
            {
                Console.WriteLine("Imonitor 인터페이스 메서드 구현");
            }
            // 상속받은 인터페이스의 프로퍼티 재정의
            int inch;
            public int Inch
            {
                get { return inch; }
                set { inch = value; }
            }
            int width;
            public int Width
            {
                get { return width; }
            }
        }
        interface IDrawObject
        {
            void Draw();
        }
        class Line : IDrawObject
        {
            public void Draw()
            {
                Console.WriteLine("Line클래스에서 DrawObject 인터페이스 Draw 메서드 구현");
            }
        }
        class Rectangle : IDrawObject
        {
            public void Draw()
            {
                Console.WriteLine("Rectangle클래스에서 DrawObject 인터페이스 Draw 메서드 구현");
            }
        }
        interface IObjectToString { }   // ToString 재정의한 클래스에만 사용될 빈 인터페이스 정의
        class Person : IObjectToString
        {
            string name;
            public Person(string name)
            {
                this.name = name;
            }
            public override string ToString()   // ToString()은 Object 클래스에 정의되어 있기 때문에 모든 클래스에서 오버라이딩 가능
            {
                return "Person: " + this.name;
            }
        }
        private static void DisplayObject(object obj)
        {
            if (obj is IObjectToString) // 인터페이스로 형변환 가능하면
            {  
                Console.WriteLine(obj.ToString());
            }
        }
        static void Main(string[] args)
        {
            Notebook notebook = new Notebook();
            notebook.TurnOn();

            IDrawObject[] instances = new IDrawObject[] { new Line(), new Rectangle() };
            foreach (IDrawObject item in instances)
            {
                item.Draw(); // 인터페이스를 상속받은 객체의 Draw 메서드 호출됨
            }
            // 자식 클래스로부터 암시적 형변환 가능
            IDrawObject obj = new Line();
            obj.Draw();

            DisplayObject(new Computer());  // Computer 클래스는 IObjectToString 인터페이스를 상속받지 않기 때문에 아무것도 출력되지 않음
            DisplayObject(new Person("호날두"));   // Person 클래스는 IObjectToString 인터페이스를 상속받았기 때문에 ToString() 메서드 호출됨
        }
    }
}
