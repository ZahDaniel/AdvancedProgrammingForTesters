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
        }

        [Fact]
        public void DeferredExecution_Demonstration()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // LINQ Deferred Execution: the query is not executed until iterated
            var evenNumbers = numbers.Where(n =>
            {
                _output.WriteLine($"Evaluating {n}");
                return n % 2 == 0;
            });
            _output.WriteLine("Query created, but not executed yet.");

            _output.WriteLine("Iterating over the results:");
            foreach (var number in evenNumbers)
            {
                _output.WriteLine($"Even number: {number}");
            }
        }

        [Fact]
        public void ImmediateExecution_WithToList()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // LINQ Immediate Execution: using ToList forces execution right away
            var evenNumbers = numbers.Where(n =>
            {
                _output.WriteLine($"Evaluating {n}");
                return n % 2 == 0;
            }).ToList();

            _output.WriteLine("Evens caluclated immediately with ToList.");

            foreach (var number in evenNumbers)
            {
                _output.WriteLine($"Even number: {number}");
            }
        }
    }
}