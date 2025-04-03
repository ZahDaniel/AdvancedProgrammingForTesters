using CourseClassLibrary.Domain.Library;
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

        private void PrintBooks(IEnumerable<Book> books, string? header = null)
        {
            if (!string.IsNullOrEmpty(header))
                _output.WriteLine(header);

            var bookInfo = string.Join(", ", books.Select(b => b.GetBookInfo()));
            DisplayText(bookInfo);
        }

        private void PrintControlLocators(Dictionary<string, List<string>> controlLocators, string? header = null)
        {
            if (!string.IsNullOrEmpty(header))
                _output.WriteLine(header);

            foreach (var control in controlLocators)
                _output.WriteLine($"{control.Key} => {string.Join(" | ", control.Value)}");

            _output.WriteLine(Environment.NewLine);
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
            int first = numbers[0];
            int last = numbers[numbers.Length - 1];
            _output.WriteLine($"First number: {first}");
            _output.WriteLine($"Last number: {last}");

            // Update a value
            numbers[2] = 7;
            _output.WriteLine($"Updated 3rd number to: {numbers[2]}");

            // Sum
            int sum = numbers.Sum();
            _output.WriteLine($"Sum of numbers: {sum}");

            // Min and Max
            int min = numbers.Min();
            int max = numbers.Max();
            _output.WriteLine($"Min of numbers: {min}");
            _output.WriteLine($"Max of numbers: {max}");

            // Average
            double average = numbers.Average();
            _output.WriteLine($"Average: {average:F2}");

            // Contains
            bool containsNumber10 = numbers.Contains(10);
            _output.WriteLine($"Contains 10: {containsNumber10}");

            // Sorting ascending
            Array.Sort(numbers);
            _output.WriteLine("Sorted ascending: " + string.Join(", ", numbers));

            // Reversing for descending
            Array.Reverse(numbers);
            _output.WriteLine("Sorted descending: " + string.Join(", ", numbers));
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
            DisplayText($"First book: {books[0].GetBookInfo()}");
            DisplayText($"Last book: {books[books.Length - 1].GetBookInfo()}");

            PrintBooks(books, "Library contains these books:");

            // Update
            books[1].Author = "UpdatedAuthor2";
            DisplayText($"Updated author: {books[1].GetBookInfo()}");

            // Find book with a specific title with for
            string titleToFind = "Book1";
            Book? found = null;

            for (int i = 0; i < books.Length - 1; i++)
            {
                if (books[i].Title == titleToFind)
                {
                    found = books[i];
                    break;
                }
            }
            DisplayText(found != null ? $"Found: {found.GetBookInfo()}" : "Book not found");

            // Find book with a specific title with foreach
            titleToFind = "Book2";
            found = null;

            foreach (var book in books)
            {
                if (book.Title == titleToFind)
                {
                    found = book;
                    break;
                }
            }
            DisplayText(found != null ? $"Found: {found.GetBookInfo()}" : "Book not found");

            // Find book with a specific title with LINQ
            titleToFind = "Book3";
            found = books.FirstOrDefault(b => b.Title == titleToFind);

            DisplayText(found != null ? $"Found: {found.GetBookInfo()}" : "Book not found");

            // Partitioning
            var chunkSize = 2;
            var batch1 = books.Take(chunkSize).ToArray();
            var batch2 = books.Skip(chunkSize).Take(books.Length - chunkSize).ToArray();

            PrintBooks(batch1, "Batch1:");
            PrintBooks(batch2, "Batch2:");
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
            PrintBooks(books, "Initial books in the library:");

            // Add a new book
            books.Add(new Book("OtherBook1", "OtherAuthor1"));
            PrintBooks(books, "Library after add:");

            // Insert at specific position
            books.Insert(1, new Book("InstertedBook", "InsertedAuthor"));
            PrintBooks(books, "Library after insert at index 1:");

            // Update book at index
            books[2].Author = "UpdatedAuthor";
            DisplayText($"Updated book at index 2: {books[2].GetBookInfo()}");

            // Remove by object
            var toRemove = books.FirstOrDefault(b => b.Title == "MathBook1");
            if (toRemove != null)
                books.Remove(toRemove);

            PrintBooks(books, "Librabry after remove:");

            // Remove by index
            books.RemoveAt(0);
            PrintBooks(books, "Librabry after remove at index 0:");

            // Find book by condition
            var found = books.Find(b => b.Author.Contains("Updated"));
            DisplayText(found != null ? $"Found: {found.GetBookInfo()}" : "Book not found");

            // FindAll books by a condition
            var results = books.FindAll(b => b.Title.Contains("English"));
            PrintBooks(results, "All english books are:");

            // Contains check
            bool hasBook = books.Any(b => b.Title == "OtherBook1");
            DisplayText(hasBook ? "Library contains 'OtherBook1'" : "Library does not contain 'OtherBook1'");

            // Clear list
            books.Clear();
            DisplayText($"The number of books left in the library is: {books.Count}");
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
            PrintControlLocators(controlLocators, "Initial control locators mapping:");

            // Add - will throw if key already exists
            controlLocators.Add("button2", new List<string> { "//custom-button" });
            PrintControlLocators(controlLocators, "Control locators mapping after adding button2:");

            // TryAdd - safe add
            bool added = controlLocators.TryAdd("footer", new List<string> { "//footer", "//app-footer" });

            if (added)
                PrintControlLocators(controlLocators, "Control locators mapping after adding footer: ");
            else
                DisplayText("TryAdd failed");

            // Indexer access - will throw if key doesn't exist
            var buttonLocators = controlLocators["button"];
            DisplayText($"Button locators are: {string.Join(" | ", buttonLocators)}");

            // TryGetValue - safe read
            if (controlLocators.TryGetValue("dropdown", out var dropdownLocators))
                DisplayText($"Dropdown locators are: {string.Join(" | ", dropdownLocators)}");
            else
                DisplayText("TryGetValue failed");

            // ContainsKey 
            bool hasInput = controlLocators.ContainsKey("input");
            DisplayText(hasInput ? "Input control was found" : "Input control was not found");

            // Contains locator
            string locatorToFind = "//button";
            string? matchingControl = controlLocators.FirstOrDefault(kpv => kpv.Value.Contains(locatorToFind)).Key;

            DisplayText(matchingControl != null
                ? $"Locator '{locatorToFind}' belongs to control: {matchingControl}"
                : $"Locator '{locatorToFind}' does not belong to any control");

            // Add a locator to existing control type
            controlLocators["checkbox"].Add("//custom-checkbox");
            PrintControlLocators(controlLocators, "Control locators mapping after adding new locator for checkbox:");

            // Remove a locator from a control type
            controlLocators["title"].Remove("//h2");
            PrintControlLocators(controlLocators, "Control locators mapping after removing //h2 from title:");

            // Remove entire control type
            controlLocators.Remove("sidemenu");
            PrintControlLocators(controlLocators, "Control locators mapping after removing sidemenu control:");

            // Keys & Values
            DisplayText("All controls: " + string.Join(", ", controlLocators.Keys));
            DisplayText("All locators: " + string.Join(" | ", controlLocators.SelectMany(x => x.Value)));

            // Count
            DisplayText($"Total controls: {controlLocators.Count}");

            // Clear
            controlLocators.Clear();
            DisplayText($"The number of controls is: {controlLocators.Count}");
        }
    }
}
