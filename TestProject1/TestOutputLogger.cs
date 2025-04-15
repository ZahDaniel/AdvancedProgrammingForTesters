using Xunit.Abstractions;

namespace LoggerTests
{

    public class TestOutputLogger : ILogger
    {
        private readonly ITestOutputHelper _output;

        public TestOutputLogger(ITestOutputHelper output)
        {
            _output = output;
        }

        public void Log(string message)
        {
            _output.WriteLine(message);
        }
    }

}
