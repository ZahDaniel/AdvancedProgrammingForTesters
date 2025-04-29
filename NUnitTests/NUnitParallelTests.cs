namespace NUnitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)] // All test methods run in parallel
    //[Parallelizable(ParallelScope.Children)] // Test classes run sequentially, but methods inside a class run in parallel
    //[Parallelizable(ParallelScope.Fixtures)] // Test classes run in parallel, but methods inside a class run sequentially
    //[Parallelizable(ParallelScope.None)] // All test methods run sequentially
    public class NUnitParallelTests
    {
        [Test]
        public void Test1()
        {
            Thread.Sleep(2400);
            Console.WriteLine("Test1 completed");
        }

        [Test]
        public void Test2()
        {
            Thread.Sleep(2400);
            Console.WriteLine("Test2 completed");
        }

        [Test]
        public void Test3()
        {
            Thread.Sleep(2400);
            Console.WriteLine("Test3 completed");
        }
    }
}
