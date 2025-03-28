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
        public void Book_CanBeInstantiated()
        {
            var book = new Book("The Book", "The Author");

            _output.WriteLine($"Book title => {book.Title}");
            _output.WriteLine($"Book author => {book.Author}");

            Assert.Equal("The Book", book.Title);
            Assert.Equal("The Author", book.Author);
        }

        [Fact]
        public void GetBookInfo_ReturnsCorrectFormat()
        {
            var book = new Book("The Book", "The Author");

            _output.WriteLine($"Book info => {book.GetBookInfo()}");
        }

        [Fact]
        public void HasManyPages_ReturnsTrue_WhenBookMoreThanMaxPages()
        {
            var book = new Book("War and Peace", "Leo Tolstoy");
            var nrPages = 1001;

            if (book.HasManyPages(nrPages))
                _output.WriteLine("Book has many pages");
            else
                _output.WriteLine("Book does not have many pages");
        }

        [Fact]
        public void UniqueId_IsDifferentForEachInstance()
        {
            var book1 = new Book("The Book", "The Author");
            var book2 = new Book("The Book", "The Author");

            _output.WriteLine($"Book1 id => {book1.UniqueId}");
            _output.WriteLine($"Book2 id => {book2.UniqueId}");

            Assert.NotEqual(book1.UniqueId, book2.UniqueId);
        }
    }
}