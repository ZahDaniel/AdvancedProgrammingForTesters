namespace TestLogger
{
    public class TestLogging
    {
        // Open/Closed Principle, replace if statements with interface to allow for generic logging behavior
        public void Log(string message, ILoggingMethod loggingMethod)
        {
            loggingMethod.Log(message);
        }
    }
}
