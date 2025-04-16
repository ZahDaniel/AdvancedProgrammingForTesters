using CourseClassLibrary.Domain.Library;
using Xunit.Abstractions;

namespace Session4
{
    public class LinqOverviewTests
    {
        private readonly ITestOutputHelper _output;

        public LinqOverviewTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void FilterBooks_QuerySyntax()
        {
            var books = new List<Book>
            {
                new Book("Testing Fundamentals", "Alice"),
                new Book("Refactoring UI", "Bob"),
                new Book("Clean Automation", "Alice"),
            };

            // LINQ Query Syntax
            var filterBooks = from book in books
                              where book.Author == "Alice"
                              select book;

            foreach (var book in filterBooks)
            {
                _output.WriteLine(book.GetBookInfo());
            }
        }

        [Fact]
        public void FilterBooks_MethodSyntax()
        {
            var books = new List<Book>
            {
                new Book("Testing Fundamentals", "Alice"),
                new Book("Refactoring UI", "Bob"),
                new Book("Clean Automation", "Alice"),
            };

            // LINQ Method Syntax
            var filterBooks = books.Where(book => book.Author == "Alice");

            foreach (var book in filterBooks)
            {
                _output.WriteLine(book.GetBookInfo());
            }
        }

        [Fact]
        public void DeferredExecution_Demonstration()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // LINQ Deferred Execution: the query is not executed until iterated
            var evenNumbers = numbers.Where(n =>
                {
                    _output.WriteLine($"Evaluating: {n}");
                    return n % 2 == 0;
                });

            _output.WriteLine("LINQ created, but not executed.");

            _output.WriteLine("Now iterating");
            foreach (var number in evenNumbers)
            {
                _output.WriteLine($"Even number {number}");
            }
        }

        [Fact]
        public void ImmediateExecution_WithToList()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // LINQ Immediate Execution: using ToList forces execution right away
            var evenNumbers = numbers.Where(n =>
                {
                    _output.WriteLine($"Evauating: {n}");
                    return n % 2 == 0;
                }).ToList();

            _output.WriteLine("Evens calculated immediately with toList: ");

            foreach(var number in evenNumbers)
            {
                _output.WriteLine($"Even number {number}");
            }
        }
    }
}