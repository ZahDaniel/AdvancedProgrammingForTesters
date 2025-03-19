using Xunit.Abstractions;

namespace Session1
{
    public class MemoryTests
    {
        private readonly ITestOutputHelper _output;

        public MemoryTests(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Setup for test started.");
        }
    }
}