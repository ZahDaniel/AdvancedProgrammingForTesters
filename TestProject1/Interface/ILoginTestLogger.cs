namespace LoggerTests.Interface
{
    public interface ILoginTestLogger
    {
        void LogLoginStart(string username);
        void LogLoginSuccess();
    }
}
