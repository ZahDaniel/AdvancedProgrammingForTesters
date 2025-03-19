using Xunit.Abstractions;

namespace Session1
{
    public class BookTests
    {   
        private readonly ITestOutputHelper _output;

        public BookTests(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Setup for test started.");
        }

    }
}