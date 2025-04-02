namespace CourseClassLibrary
{
    public class Podcast
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public int ReleaseYear { get; set; }

        private const int MaxEpisodes = 100;
        private readonly string _uniqueId;

        public Podcast(string name, string host, int releaseYear)
        {
            Name = name;
            Host = host;
            ReleaseYear = releaseYear;
            _uniqueId = Guid.NewGuid().ToString();
        }

        public string GetPodcastInfo() => $"{Name} by {Host}, released in {ReleaseYear}";

        public bool IsPodcastReleasedBefore2010() => ReleaseYear < 2010;

        public string UniqueId => _uniqueId;
    }
}
