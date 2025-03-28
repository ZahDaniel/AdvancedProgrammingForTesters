using CourseClassLibrary;
using Xunit.Abstractions;

namespace Session2
{
    public class CollectionsTests
    {
        private readonly ITestOutputHelper _output;

        public CollectionsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private void DisplayText(string text)
        {
            _output.WriteLine(text);
            _output.WriteLine(Environment.NewLine);
        }

        // ARRAYS

        [Fact]
        public void IntArray_BasicOperations()
        {
            var numbers = new int[] { 5, 8, 3, 10, 6 };

            // Access individual elements

            // Update a value

            // Sum

            // Min and Max

            // Average

            // Contains

            // Sorting ascending

            // Reversing for descending
        }

        [Fact]
        public void BookArray_BasicOperations()
        {
            var books = new Book[]
            {   new Book("Book1", "Author1"),
                new Book("Book2", "Author2"),
                new Book("Book3", "Author3"),
                new Book("Book4", "Author4")
            };

            // Access

            // Update

            // Find book with a specific title with for

            // Find book with a specific title with foreach

            // Find book with a specific title with LINQ

            // Partitioning
        }

        // LISTS

        [Fact]
        public void BookList_BasicOperations()
        {
            var books = new List<Book>
            {
                new Book("MathBook1", "MathAuthor1"),
                new Book("MathBook2", "MathAuthor2"),
                new Book("EnglishBook1", "EnglishAuthor1"),
                new Book("EnglishBook2", "EnglishAuthor2"),
            };

            // Display all books

            // Add a new book

            // Insert at specific position

            // Update book at index

            // Remove by object

            // Remove by index

            // Find book by condition

            // FindAll books by a condition

            // Contains check

            // Clear list
        }

        // DICTIONARY

        [Fact]
        public void ControlLocatorsDictionary_Actions()
        {
            var controlLocators = new Dictionary<string, List<string>>
            {
                { "button", new List<string> { "//button", "//app-button" } },
                { "input", new List<string> { "//input", "//app-input", "//textarea" } },
                { "dropdown", new List<string> { "//select", "//app-dropdown" } },
                { "checkbox", new List<string> { "//input[@type='checkbox']", "//app-checkbox" } },
                { "title", new List<string> { "//h1", "//h2", "//div[@class='title']" } },
                { "sidemenu", new List<string> { "//nav", "//aside", "//div[@id='side-menu']" } }
            };

            // Display initial control locators mapping

            // Add - will throw if key already exists

            // TryAdd - safe add

            // Indexer access - will throw if key doesn't exist

            // TryGetValue - safe read

            // ContainsKey 

            // Contains locator

            // Add a locator to existing control type

            // Remove a locator from a control type

            // Remove entire control type

            // Keys & Values

            // Count

            // Clear
        }
    }
}
