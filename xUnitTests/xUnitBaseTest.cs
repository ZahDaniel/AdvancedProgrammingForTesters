using CourseClassLibrary.Domain.Math;

//[assembly: CollectionBehavior(DisableTestParallelization = true)] // All test methods run sequentially

namespace xUnitTests
{
    public class xUnitBaseTest
    {
        public readonly Calculator _calculator;

        public xUnitBaseTest()
        {
            _calculator = new Calculator();
        }
    }
}
