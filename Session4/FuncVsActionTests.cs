using Xunit.Abstractions;

namespace Session4
{
    public class FuncVsActionTests
    {
        private readonly ITestOutputHelper _output;

        public FuncVsActionTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Func_TransformsInput()
        {

        }

        [Fact]
        public void Action_LogsInput()
        {

        }
    }
}
