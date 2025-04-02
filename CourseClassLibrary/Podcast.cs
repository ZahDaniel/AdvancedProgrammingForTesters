namespace CourseClassLibrary
{
    public class Podcast
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; }

        private const int NumberOfEpisodes = 10;
        private readonly string _uniqueId;

        public Podcast(string name, string author, int year)
        {
            Name = name;
            Author = author;
            Year = year;
            _uniqueId = Guid.NewGuid().ToString();
        }

        public string GetPodcastInfo() => $"{Name} hosted by {Author}, released in {Year}";

        public bool isLaunchedBefore2010() => Year < 2010; //method should start with PascalCase: public bool IsLaunchedBefore2010()

        public string UniqueId () => _uniqueId; // this should be a property: public string UniqueId => _uniqueId;
    }
}
