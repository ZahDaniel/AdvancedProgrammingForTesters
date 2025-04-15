using Xunit.Abstractions;

namespace Session4
{
    public class LambdaExpressionsTests
    {
        private readonly ITestOutputHelper _output;

        public LambdaExpressionsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Lambda_BasicSyntaxExamples()
        {
            // Traditional delegate method
            Func<int, int> square = delegate (int x) { return x * x; };
            _output.WriteLine($"Delegate syntax: Square of 3 = {square(3)}");

            // Simplified lambda expression

            // No parameters

            // Multiple parameters

            // Statement body instead of expression body
        }
    }
}
