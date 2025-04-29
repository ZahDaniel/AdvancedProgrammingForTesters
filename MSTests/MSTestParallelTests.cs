namespace MSTestTests
{
    [TestClass]
    public class MSTestParallelTests
    {
        [TestMethod]
        public void Test1()
        {
            Thread.Sleep(2400);
            Console.WriteLine("Test1 completed");
        }

        [TestMethod]
        public void Test2()
        {
            Thread.Sleep(2400);
            Console.WriteLine("Test2 completed");
        }

        [TestMethod]
        public void Test3()
        {
            Thread.Sleep(2400);
            Console.WriteLine("Test3 completed");
        }
    }
}
