using Xunit.Abstractions;

namespace xUnitTests
{
    public class xUnitParallelTests
    {
        private readonly ITestOutputHelper _output;

        public xUnitParallelTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1()
        {
            Thread.Sleep(2400);
            _output.WriteLine("Test1 completed");
        }

        [Fact]
        public void Test2()
        {
            Thread.Sleep(2400);
            _output.WriteLine("Test2 completed");
        }

        [Fact]
        public void Test3()
        {
            Thread.Sleep(2400);
            _output.WriteLine("Test3 completed");
        }
    }
}
