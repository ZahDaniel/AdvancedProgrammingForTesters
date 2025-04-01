namespace CourseClassLibrary
{
    public class Podcast
    {
        public string Title { get; set; }
        public string Host { get; set; }
        public int YearLaunched { get; }

        private const int EpisodeLimit = 8;
        private readonly string _uniqueId;

        public Podcast(string name, string host, int yearLaunched)
        {
            Title = name;
            Host = host;
            YearLaunched = yearLaunched;
            _uniqueId = Guid.NewGuid().ToString();
        }

        public string GetPodcastInfo() => $"{Title} hosted by {Host}, released in {YearLaunched}";

        public bool WasLaunchedBefore2010() => YearLaunched < 2010;

        public string UniqueId => _uniqueId;

    }
}
