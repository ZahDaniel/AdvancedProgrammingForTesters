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
        }

        [Fact]
        public void ImmediateExecution_WithToList()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // LINQ Immediate Execution: using ToList forces execution right away
        }
    }
}