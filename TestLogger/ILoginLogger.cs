    namespace LoggerTests
    {
        public interface ILoginLogger
        {
            void LogLoginStart(string username);

            void LogLoginSuccess();
        }
    }

