using CourseClassLibrary;
using Xunit.Abstractions;

namespace Session1
{
    public class BookTests
    {   
        private readonly ITestOutputHelper _output;

        public BookTests(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Setup for test started.");
        }

        [Fact]
        public void Book_CanBeInstantieted()
        {
            var book = new Book("The Book", "The Author");

            _output.WriteLine(book.Title);
            _output.WriteLine(book.Author);

            Assert.Equal("The Book", book.Title);
            Assert.Equal("The Author", book.Author);
        }

        [Fact]
        public void GetBookInfo()
        {
            var book = new Book("The Book", "The Author");

            _output.WriteLine(book.GetBookInfo());
        }

        [Fact]
        public void UniqueId_IsGeneratedForEachBookObject()
        {
            var book1 = new Book("The Book", "The Author");
            var book2 = new Book("The Book", "The Author");
            _output.WriteLine(book1.UniqueId);
            _output.WriteLine(book2.UniqueId);

            Assert.NotEqual(book1.UniqueId, book2.UniqueId);
        }
    }
}