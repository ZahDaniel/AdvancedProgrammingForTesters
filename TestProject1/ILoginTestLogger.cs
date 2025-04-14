namespace LoggerTests
{
    public interface ILoginTestLogger
    {
        void LogLoginStart(string username);
        void LogLoginSuccess();
    }
}