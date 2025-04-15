using Xunit.Abstractions;

namespace Session4
{
    public class DelegateValidationTests
    {
        private readonly ITestOutputHelper _output;

        public DelegateValidationTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("USERNAME", "IsAllUppercase")]
        [InlineData("ValidInput", "HasMinimumLength")]
        [InlineData("SomeText", "IsNotEmpty")]
        public void FieldValidation_UsingDelegates(string input, string strategyName)
        {

        }
    }
}
