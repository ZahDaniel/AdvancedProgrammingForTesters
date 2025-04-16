using CourseClassLibrary.Delegates;
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
            var processor = new FieldProcessor();

            Func<string, string> toUpper = s => s.ToUpper();
            Func<string, string> addPrefix = s => $"[TEST] {s}";

            var input = "automation";

            var result1 = processor.TransformField(input, toUpper);
            var result2 = processor.TransformField(input, addPrefix);

            _output.WriteLine($"Original {input}");
            _output.WriteLine($"ToUpper: {result1}");
            _output.WriteLine($"Added Prefix: {result2}");

            Assert.Equal("AUTOMATION", result1);
            Assert.Equal("[TEST] automation", result2);
        }

        [Fact]
        public void Action_LogsInput()
        {
            var processor = new FieldProcessor();
            
            Action<string> logToConsole = s => _output.WriteLine($"[LOG] {s}");
            Action<string> logLength = s => _output.WriteLine($"Length {s.Length}");

            var input = "SampleText";

            processor.LogField(input, logToConsole);
            processor.LogField(input, logLength);
        }
    }
}
