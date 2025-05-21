namespace Ch03_variable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Stack / Heap
            // 개별 스레드마다 전용으로 사용할 수 있는 저장소가 메모리에 할당됨 -> 그 영역을 Stack이라고 함
            // Heap -> 필요에 의해 메모리 사용 요청 시 사용할 수 있는 저장소

            int n = 5;  // Stack 메모리에 5가 저장되고 n은 5를 담고 있는 저장소 이름임. int는 데이터 크기(4바이트) 할당
            // 참조형 변수
            string text = "Hello";  // text : 스택 저장소 이름. 힙의 데이터 주소 담고 있음(0x0400..) 힙 메모리에 Hello 담겨 있음
            
            // 초기화되지 않은 모든 참조형 변수는 null값 가짐
            string text1;
            string text2 = null;
            // null 할당
            text = null;

            int n1 = 5;
            int n2 = n1;    // n1, n2는 스택의 각각 다른 위치에 동일한 값(5)이 복사되어 개별 값을 가리킴

            string txt1 = "C#";
            string txt2 = txt1; // 스택 변수값들이 동일한 힙 메모리주소를 참조

            // 기본값
            bool result;    // false
            int n3;         // 0
            string text3;   // null

            // 컴파일 타임/런타임
            // 컴파일 타임 : 코드 작성하고 빌드(컴파일)할 때의 시간. Visual Studio나 dotnet이 코드를 검사하고 .exe 또는 .dll로 컴파일. 문법 오류, 타입 오류 등을 이때 검사
            // 런타임 : 프로그램이 실제로 실행되고 동작할 때의 시간. 컴파일된 .exe가 실행됨. 메모리 할당, 변수 값 계산, 사용자 입력 처리, 예외 발생 등. Main() 함수 진입은 이 시점부터 시작

        }
    }
}
