using CourseClassLibrary.Domain.Library;
using Xunit.Abstractions;

namespace Session1
{
    public class MemoryTests
    {
        private readonly ITestOutputHelper _output;

        public MemoryTests(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Setup for test started.");
        }

        [Fact]
        public void ReferenceType_ChangesOriginalObject()
        {
            var book1 = new Book("The Book", "The Author");
            var book2 = book1;

            _output.WriteLine($"Book1 info => {book1.GetBookInfo()}");
            _output.WriteLine($"Book2 info => {book2.GetBookInfo()}");

            book2.Title = "The New Book";

            _output.WriteLine($"Book1 info => {book1.GetBookInfo()}");
            _output.WriteLine($"Book2 info => {book2.GetBookInfo()}");
        }

        [Fact]
        public void ValueType_DoesNotChangeOriginal()
        {
            var pages1 = new PageCount(200);
            var pages2 = pages1;

            _output.WriteLine($"Pages1 => {pages1.GetNumberOfPages()}");
            _output.WriteLine($"Pages2 => {pages2.GetNumberOfPages()}");

            pages2 = new PageCount(500);

            _output.WriteLine($"Pages1 => {pages1.GetNumberOfPages()}");
            _output.WriteLine($"Pages2 => {pages2.GetNumberOfPages()}");
        }
    }
}