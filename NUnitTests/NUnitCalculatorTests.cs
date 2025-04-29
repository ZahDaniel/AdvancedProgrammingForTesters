using CourseClassLibrary.Domain.Math;
using NUnit.Framework.Internal;

namespace NUnitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)] // All test methods run in parallel
    //[Parallelizable(ParallelScope.Children)] // Test classes run sequentially, but methods inside a class run in parallel
    //[Parallelizable(ParallelScope.Fixtures)] // Test classes run in parallel, but methods inside a class run sequentially
    //[Parallelizable(ParallelScope.None)] // All test methods run sequentially
    public class NUnitCalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
            Console.WriteLine($"Test '{TestContext.CurrentContext.Test.Name}' started.");
            Thread.Sleep(2400);
        }

        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            Assert.That(_calculator.Add(2, 3), Is.EqualTo(5));
        }

        [TestCase(2, 3, 6)]
        [TestCase(4, 5, 20)]
        public void Multiply_ShouldReturnCorrectProduct(int a, int b, int expected)
        {
            Assert.That(_calculator.Multiply(a, b), Is.EqualTo(expected));
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine($"Test '{TestContext.CurrentContext.Test.Name}' completed with status: {TestContext.CurrentContext.Result.Outcome.Status}");
        }
    }
}
