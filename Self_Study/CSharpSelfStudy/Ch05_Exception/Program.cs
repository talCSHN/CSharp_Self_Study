namespace Ch05_Exception
{
    internal class Program
    {
        private static void HasNoProblem()
        {
            WriteText("Argument is not NULL");
        }
        private static void HasProblem()
        {
            WriteText(null);    // NullReferenceException 발생
        }
        private static void WriteText(string txt)
        {
            Console.WriteLine(txt.ToLower());
        }
        class InvalidPasswordException : Exception
        {
            public InvalidPasswordException(string msg) : base(msg) { }
        }
        static void Main(string[] args)
        {
            string txt = Console.ReadLine();

            if (txt != "123")
            {
                InvalidPasswordException ex = new InvalidPasswordException("틀린 암호");
                throw ex;
            }
            Console.WriteLine(txt);

            try
            {
                HasProblem();
            }
            catch (Exception ex)
            {
                throw;
            }

            string passwd = Console.ReadLine();

            if (passwd != "123")
            {
                ApplicationException ex = new ApplicationException("틀린 암호");
                throw ex;
            }

            Console.WriteLine("올바른 암호");

            HasNoProblem();
            HasProblem();   // NullReferenceException 발생

            int divisor = 0;
            string txt = null;

            try
            {
                Console.WriteLine(txt.ToUpper());
                int quotient = 10 / divisor;
                Console.WriteLine(quotient);
            }
            catch (Exception e)
            {
                Console.WriteLine("예외 발생 : " + e);
            }
            finally
            {
                Console.WriteLine("항상 실행");
            }
        }
    }
}
