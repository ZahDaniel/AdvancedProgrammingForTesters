namespace CourseClassLibrary
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        private const int MaxPages = 1000;
        private readonly string _uniqueId;

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            _uniqueId = Guid.NewGuid().ToString();
        }

        public string GetBookInfo() => $"{Title} by {Author}";

        public bool HasManyPages(int pageCount) => pageCount > MaxPages;

        public string UniqueId => _uniqueId;
    }
}
