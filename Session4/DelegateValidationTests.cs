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
                "IsAllUppercase" => validator.IsAllUppercase,
                "HasMinimumLength" => validator.HasMinimumLength,
                "IsNotEmpty" => validator.IsNotEmpty,
                _ => throw new ArgumentException("Invalid strategy name")
            };

            var result = strategy(input);

            _output.WriteLine($"Input: {input}, Strategy: {strategyName}, Result: {result}");

            Assert.True(result, $"Validation failed for input '{input}' using strategy '{strategyName}'");
        }
    }
}
