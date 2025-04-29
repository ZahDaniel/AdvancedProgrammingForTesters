using Xunit.Abstractions;

namespace xUnitTests
{
    public class xUnitCalculatorTests : IClassFixture<xUnitBaseTest>, IDisposable
    {
        private readonly xUnitBaseTest _xUnitBaseTest;
        private readonly ITestOutputHelper _output;

        // Constructor-based setup
        public xUnitCalculatorTests(xUnitBaseTest xUnitBaseTest, ITestOutputHelper output)
        {
            _xUnitBaseTest = xUnitBaseTest;
            _output = output;

            _output.WriteLine("Setup for test started.");
            Thread.Sleep(2400);
        }

        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            _output.WriteLine($"Executing {nameof(Add_ShouldReturnCorrectSum)}.");
            Assert.Equal(5, _xUnitBaseTest._calculator.Add(2, 3));
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(4, 5, 20)]
        public void Multiply_ShouldReturnCorrectProduct(int a, int b, int expected)
        {
            _output.WriteLine($"Executing {nameof(Multiply_ShouldReturnCorrectProduct)} with parameters {a}, {b}, {expected}.");
            Assert.Equal(expected, _xUnitBaseTest._calculator.Multiply(a, b));
        }

        // IDisposable implementation for cleanup
        public void Dispose()
        {
            _output.WriteLine($"Cleaning up resources for {nameof(xUnitCalculatorTests)}.");
        }
    }
}
