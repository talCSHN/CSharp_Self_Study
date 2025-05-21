namespace Ch04_enum
{
    internal class Program
    {
        enum Days
        {
            Sunday, Monday, Tuesday, Wednesday, Friday, Saturday
        }
        // 이런 식으로 시작 요소 값에 0이 아닌 다른 정수 지정도 가능
        // 그 이후의 요소에 대해서도 1씩으로 자동 증가하는 것이 아닌 임의의 값 지정 가능
        // 대신 상속받은 부모의 숫자 타입 범위에 있는 값 지정해야함
        enum Days1
        {
            Sunday = 5, Monday = 10, Tuesday, Wednesday, Thursday = 15, Friday, Saturday
        }
        [Flags]
        enum Days2
        {
            Sunday = 1, Monday = 2, Tuesday = 4, Wednesday = 8, Thursday = 16, Friday = 32, Saturday = 64
        }
        enum CalcType
        {
            Add, Minus, Multiply, Divide
        }
        static void Main(string[] args)
        {
            Days today = Days.Sunday;
            Console.WriteLine(today);
            int n = (int)today;
            Console.WriteLine(n);
            //today = (int)today; // Days 타입 변수에 int 형 값을 넣는 암시적 형변환은 불가
            today = (Days)5;
            Console.WriteLine(today);

            Days2 workingDays = Days2.Monday | Days2.Tuesday | Days2.Wednesday | Days2.Thursday | Days2.Friday;
            Console.WriteLine(workingDays.HasFlag(Days2.Sunday));   // Sunday를 포함하고 있는가
            Days2 today2 = Days2.Friday;
            Console.WriteLine(workingDays.HasFlag(today2));

            Console.WriteLine(workingDays);

            int Calc(CalcType opType, int operand1, int operand2)
            {
                switch (opType)
                {
                    case CalcType.Add:
                        return operand1 + operand2;
                    case CalcType.Minus:
                        return operand1 - operand2;
                    case CalcType.Multiply:
                        return operand1 * operand2;
                    case CalcType.Divide:
                        return operand1 / operand2;
                }
                return 0;
                
            }
            Calc(CalcType.Add, 10, 5);  // enum 인스턴스로 전달
        }
    }
}
