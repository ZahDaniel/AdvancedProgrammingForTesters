using CourseClassLibrary.Domain.Math;

namespace MSTestTests
{
    [TestClass]
    public class MSTestCalculatorTests
    {
        private Calculator? _calculator;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            _calculator = new Calculator();
            Console.WriteLine($"Test '{TestContext.TestName}' started.");
            Thread.Sleep(2400);
        }

        [TestMethod]
        public void Add_ShouldReturnCorrectSum()
        {
            Assert.AreEqual(5, _calculator!.Add(2, 3));
        }

        [DataTestMethod]
        [DataRow(2, 3, 6)]
        [DataRow(4, 5, 20)]
        public void Multiply_ShouldReturnCorrectProduct(int a, int b, int expected)
        {
            Assert.AreEqual(expected, _calculator!.Multiply(a, b));
        }

        [TestCleanup]
        public void TearDown()
        {
            Console.WriteLine($"Test '{TestContext.TestName}' completed.");
        }
    }
}
