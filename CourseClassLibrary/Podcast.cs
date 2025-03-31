namespace CourseClassLibrary
{
    public class Podcast
    {
        public string Title { get; set; }

        public string Host { get; set; }

        public int Year { get; }

        private const int LimitHowManyEpisodes = 10;

        private readonly string _uniqueId;

        public Podcast(string title, string host, int year)
        {
            Title = title;
            Host = host;
            Year = year;
            _uniqueId = System.Guid.NewGuid().ToString();
        }

        public string GetPodcastInfo() => $"{Title} hosted by {Host}, released in {Year}";

        public bool IsPodcastLaunchedBefore2010() => Year < 2010;

        public string UniqueId => _uniqueId;
    }
}