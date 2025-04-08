namespace CourseClassLibrary.Abstractions
{
    public abstract class LibraryItem
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string UniqueId { get; } = Guid.NewGuid().ToString();

        protected LibraryItem(string title, string author)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Title and Author cannot be empty.");
            }

            Title = title;
            Author = author;
        }

        public abstract string GetItemInfo();
    }

}
