using CourseClassLibrary.Delegates;
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
            var validator = new FieldValidator();

            ValidationStrategy strategy = strategyName switch
            {
                "IsNotEmpty" => validator.IsNotEmpty,
                "HasMinimumLength" => validator.HasMinimumLength,
                "IsAllUppercase" => validator.IsAllUppercase,
                _ => throw new ArgumentException("Invalid strategy name")
            };

            var result = strategy(input);

            _output.WriteLine($"Input: {input}");
            _output.WriteLine($"Strategy: {strategyName}");
            _output.WriteLine($"Validation result: {result}");

            Assert.True(result);
        }
    }
}
