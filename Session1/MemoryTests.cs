using CourseClassLibrary;
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

            _output.WriteLine(book1.GetBookInfo());
            _output.WriteLine(book2.GetBookInfo());

            book2.Title = "The New Book";

            _output.WriteLine(book1.GetBookInfo());
            _output.WriteLine(book2.GetBookInfo());
        }

        [Fact]
        public void ValueType_DoesNotChangeOriginal()
        {
            var pageCount1 = new PageCount(100);
            var pageCount2 = pageCount1;

            _output.WriteLine(pageCount1.GetNumberOfPages());
            _output.WriteLine(pageCount2.GetNumberOfPages());

            pageCount2 = new PageCount(200);

            _output.WriteLine(pageCount1.GetNumberOfPages());
            _output.WriteLine(pageCount2.GetNumberOfPages());
        }
    }
}