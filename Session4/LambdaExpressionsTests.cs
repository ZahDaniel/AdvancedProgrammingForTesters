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
            Func<int, int> squareLambda = x => x * x;

            // No parameters
            Func<string> getMessage = () => "Test passed!";

            // Multiple parameters
            Func<int, int, int> sum = (x, y) => x + y;
            _output.WriteLine($"Sum of 5 and 7 = {sum(5, 7)}");

            // Statement body instead of expression body
            Func<int, string> isEven = number =>
            {
                if (number % 2 == 0)
                    return $"{number} is even";
                else
                    return $"{number} is odd";
            };

            _output.WriteLine(isEven(4));
        }
    }
}
