namespace TestLogger
{
    public class ConsoleLogger : ILoggingMethod
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
