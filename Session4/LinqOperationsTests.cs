using CourseClassLibrary.Domain.Library;
using Xunit.Abstractions;

namespace Session4
{
    public class LinqOperationsTests
    {
        private readonly ITestOutputHelper _output;

        public LinqOperationsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private void DisplayText(string text)
        {
            _output.WriteLine(text);
            _output.WriteLine(Environment.NewLine);
        }

        private void PrintBooks(IEnumerable<Book> books, string? header = null)
        {
            if (!string.IsNullOrEmpty(header))
                _output.WriteLine(header);

            var info = string.Join(", ", books.Select(b => b.GetBookInfo()));
            DisplayText(info);
        }

        [Fact]
        public void Filtering_ByAuthor()
        {
            var books = new List<Book>
            {
                new Book("Clean Code", "Robert"),
                new Book("Automation Patterns", "Alice"),
                new Book("Unit Testing", "Robert")
            };

            // Classic filtering
            var filteredClassic = new List<Book>();
            foreach (var book in books)
            {
                if (book.Author == "Robert")
                    filteredClassic.Add(book);
            }
            PrintBooks(filteredClassic, "Classic filtering:");

            // LINQ filtering
            var filteredLinq = books.Where(b =>b.Author == "Robert").ToList();
            PrintBooks(filteredLinq, "LINQ filtering");
        }

        [Fact]
        public void Sorting_ByTitle()
        {
            var originalBooks = new List<Book>
            {
                new Book("Zebra Guide", "Zara"),
                new Book("Alpha Manual", "Alice"),
                new Book("Mid-Level Testing", "Mike")
            };

            // Classic sorting
            var classicSortedBooks = new List<Book>(originalBooks);
            classicSortedBooks.Sort((a, b) => a.Title.CompareTo(b.Title));
            PrintBooks(classicSortedBooks, "Classic sorting:");

            // LINQ sorting
            var linqSortedBooks = originalBooks.OrderBy(b =>b.Title).ToList();
            PrintBooks(linqSortedBooks, "LINQ sorting");

            // LINQ descending sort
            var linqSortedBookDesc = originalBooks.OrderByDescending(b =>b.Title).ToList();
            PrintBooks(linqSortedBookDesc, "LINQ sorting descending");

            // LINQ then by
            var multiKeySorted = originalBooks
                .OrderBy(b => b.Author)
                .ThenBy(b => b.Title);

            PrintBooks(multiKeySorted, "LINQ multi-key sorting");
        }

        [Fact]
        public void Aggregation_SumAndMax()
        {
            var pageCounts = new List<int> { 120, 240, 180, 90 };

            // Classic aggregation
            int sum = 0, max = pageCounts[0];
            foreach (var p in pageCounts)
            {
                sum += p;
                if (p > max)
                    max = p;
            }
            DisplayText($"Classic - Sum: {sum}, Max: {max}");

            // LINQ aggregation
            var linqSum = pageCounts.Sum();
            var linqMax = pageCounts.Max();

            DisplayText($"LINQ - Sum: {linqSum}, Max: {linqMax}");
        }

        [Fact]
        public void Projection_SelectTitles()
        {
            var books = new List<Book>
            {
                new Book("QA 101", "Alice"),
                new Book("Automation Edge", "Bob")
            };

            // Classic projection
            var titlesClassic = new List<string>();
            foreach (var book in books)
                titlesClassic.Add(book.Title);
            DisplayText("Classic titles: " + string.Join(", ", titlesClassic));

            // LINQ projection
            var titleLinq = books.Select(b => b.Title).ToList();
            DisplayText("LINQ titles: " + string.Join(", ", titleLinq));

            // LINQ projection with selectMany
            var bookTags = new List<(string Title, string[] Tags)>
            {
                ("Clean Code", new[] { "clean", "style" }),
                ("QA Guide", new[] { "testing", "automation" })
            };

            var tagsLinq = bookTags.SelectMany(b => b.Tags).ToList();
            DisplayText("LINQ tags: " + string.Join(", ", tagsLinq));
        }

        [Fact]
        public void Quantifiers_AnyAndAll()
        {
            var titles = new List<string> { "UI Test", "API Test", "Integration Test" };

            // Classic quantifiers
            bool anyApiClassic = false;
            bool allTestClassic = true;
            foreach (var title in titles)
            {
                if (title.Contains("API")) anyApiClassic = true;
                if (!title.Contains("Test")) allTestClassic = false;
            }
            DisplayText($"Classic - Any 'API': {anyApiClassic}, All contain 'Test': {allTestClassic}");

            // LINQ quantifiers
            bool anyApiLinq = titles.Any(t => t.Contains("API"));
            bool allTestLinq = titles.All(t => t.Contains("Test"));

            DisplayText($"LINQ - Any 'API': {anyApiLinq}, All contain 'Test': {allTestLinq}");
        }

        [Fact]
        public void SetOperations_DistinctAuthors()
        {
            var books = new List<Book>
            {
                new Book("T1", "Ana"),
                new Book("T2", "Bob"),
                new Book("T3", "Ana")
            };

            // Classic distinct
            var distinctAuthorsClassic = new List<string>();
            foreach (var book in books)
            {
                if (!distinctAuthorsClassic.Contains(book.Author))
                    distinctAuthorsClassic.Add(book.Author);
            }
            DisplayText("Classic distinct authors: " + string.Join(", ", distinctAuthorsClassic));

            // LINQ distinct
            var distinctAuthorsLinq = books.Select(book => book.Author).Distinct().ToList();

            DisplayText("LINQ distinct authors: " + string.Join(", ", distinctAuthorsLinq));
        }

        [Fact]
        public void Partitioning_TakeAndSkip()
        {
            var books = new List<Book>
            {
                new Book("Book1", "Author1"),
                new Book("Book2", "Author2"),
                new Book("Book3", "Author3"),
                new Book("Book4", "Author4")
            };

            // Classic partitioning
            var top2Classic = new List<Book>();
            for (int i = 0; i < 2 && i < books.Count; i++)
                top2Classic.Add(books[i]);

            var skip2Classic = new List<Book>();
            for (int i = 2; i < books.Count; i++)
                skip2Classic.Add(books[i]);

            PrintBooks(top2Classic, "Classic Top 2:");
            PrintBooks(skip2Classic, "Classic Skipped first 2:");

            // LINQ partitioning
            var top2Linq = books.Take(2).ToList();
            var skip2Linq = books.Skip(2).ToList();

            PrintBooks(top2Linq, "LINQ Top 2:");
            PrintBooks(skip2Linq, "LINQ Skipped first 2:");
        }

        [Fact]
        public void Join_BooksWithAuthors()
        {
            var books = new List<Book>
            {
                new Book("Advanced QA", "Dana"),
                new Book("Basics", "Eli")
            };

            var authorCountries = new List<(string Author, string Country)>
            {
                ("Dana", "USA"),
                ("Eli", "Germany")
            };

            // Classic join (nested loop)
            var joinedClassic = new List<string>();
            foreach (var book in books)
            {
                foreach (var author in authorCountries)
                {
                    if (book.Author == author.Author)
                        joinedClassic.Add($"{book.Title} written from {author.Country}");
                }
            }
            foreach (var entry in joinedClassic)
                DisplayText("Classic join: " + entry);

            // LINQ join using method syntax
            var joinedLinq = books.Join(authorCountries,
                book => book.Author,
                author => author.Author,
                (book, author) => $"{book.Title} written from {author.Country}");

            foreach (var entry in joinedLinq)
            {
                DisplayText("LINQ join: " + entry);
            }
        }

        [Fact]
        public void Grouping_BooksByAuthor()
        {
            var books = new List<Book>
            {
                new Book("Book 1", "Author Cosmin"),
                new Book("Book 2", "Author Andra"),
                new Book("Book 3", "Author Cosmin")
            };

            // Classic grouping using Dictionary
            var groupedClassic = new Dictionary<string, List<Book>>();
            foreach (var book in books)
            {
                if (!groupedClassic.ContainsKey(book.Author))
                {
                    groupedClassic[book.Author] = new List<Book>();
                }

                groupedClassic[book.Author].Add(book);
            }

            foreach (var group in groupedClassic)
            {
                DisplayText($"Classic Author: {group.Key}");
                foreach (var book in group.Value)
                {
                    DisplayText($" - {book.GetBookInfo()}");
                }
            }

            // LINQ grouping
            var groupedLinq = books.GroupBy(b => b.Author).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var group in groupedLinq)
            {
                DisplayText($"LINQ Author: {group.Key}");
                foreach (var book in group.Value)
                {
                    DisplayText($" - {book.GetBookInfo()}");
                }
            }
        }

        [Fact]
        public void Generation_RangeOfIds()
        {
            // LINQ generation
            var ids = Enumerable.Range(1000, 3);
            DisplayText("Generated IDs: " + string.Join(", ", ids));
        }

        [Fact]
        public void ElementAccess_LinqMethods()
        {
            var books = new List<Book>
            {
                new Book("First Book", "A"),
                new Book("Middle Book", "B"),
                new Book("Last Book", "C")
            };

            var emptyBooks = new List<Book>();

            // LINQ element access - First

            DisplayText("First: " + books.First().GetBookInfo());
            DisplayText("First: " + emptyBooks.FirstOrDefault()?.GetBookInfo() ?? "None");

            // LINQ element access - Last
            DisplayText("Last: " + books.Last().GetBookInfo());
            DisplayText("Last: " + emptyBooks.LastOrDefault()?.GetBookInfo() ?? "None");

            // LINQ element access - ElementAt
            DisplayText("ElementAt(1): " + books.ElementAt(1).GetBookInfo());
            DisplayText("ElementAt(1): " + emptyBooks.ElementAtOrDefault(1)?.GetBookInfo() ?? "None");
        }

        [Fact]
        public void Concatenation_JoinTwoLists()
        {
            var list1 = new List<string> { "Login", "Logout" };
            var list2 = new List<string> { "Register", "Reset" };

            // Classic concatenation
            var combinedClassic = new List<string>(list1);
            combinedClassic.AddRange(list2);
            DisplayText("Classic combined actions: " + string.Join(", ", combinedClassic));

            // LINQ concatenation
            var combinedLinq = list1.Concat(list2).ToList();
            DisplayText("LINQ combined actions: " + string.Join(", ", combinedLinq));
        }
    }
}