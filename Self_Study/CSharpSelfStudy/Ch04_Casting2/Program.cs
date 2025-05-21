namespace Ch04_Casting2
{
    internal class Program
    {
        public class Computer
        {
            public void Boot() { }
            public void Shutdown() { }
        }
        public class NoteBook : Computer
        {
            public void Run()
            {
                Boot();
            }
        }
        public class Desktop : NoteBook
        {

        }
        public class DeviceManager
        {
            public void TurnOff(Computer device)
            {
                device.Shutdown();
            }
        }
        static void Main(string[] args)
        {
            NoteBook noteBook = new NoteBook();

            Computer pc1 = noteBook;    // Upcasting -> 암시적 형변환 가능
            pc1.Boot();
            pc1.Shutdown();

            Computer pc = new Computer();
            NoteBook nb = (NoteBook)pc; // Downcasting -> 명시적 형변환. 컴파일 단계까지만 가능
            // 실행하면 오류남
            /*
             Unhandled exception. System.InvalidCastException: Unable to cast object of type 'Computer' to type 'NoteBook'.
             at Ch04_Casting2.Program.Main(String[] args) in C:\Source\IoT_CSharp_WinApp_2025\Self_Study\CSharpSelfStudy\Ch04_Casting2\Program.cs:line 26
             */

            // 아래는 가능
            NoteBook noteBook1 = new NoteBook();
            Computer pc2 = noteBook1;   // 부모 타입으로 암시적 형변환했다가

            NoteBook nb2 = (NoteBook)pc2;   // 다시 원래 타입으로 명시적 형변환해서 돌아옴
            nb2.Run();

            // 이런식으로 암시적 형변환 많이 씀
            NoteBook nb5 = new NoteBook();
            DeviceManager dm = new DeviceManager();

            dm.TurnOff(nb5);

            // 자식 클래스 인스턴스를 부모 객체의 배열에 담을 수 있음
            Computer[] machines = new Computer[] { new NoteBook(), new Desktop() }; // 암시적 형변환

            DeviceManager dm4 = new DeviceManager();
            foreach (Computer device in machines)
            {
                dm4.TurnOff(device);
            }
        }
    }
}
