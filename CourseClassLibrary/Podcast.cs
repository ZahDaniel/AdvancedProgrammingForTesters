namespace CourseClassLibrary
{
    public class Podcast
    {
        private const int PodcastEpisodesLimit = 10;
        private readonly int _podcastId; //Guid type

        public string PodcastName { get; set; } 
        public string PodcastHost { get; set; }
        public int PodcastLaunchedYear { get; set; } // Property should be read-only. Only get accessor is needed.

        public Podcast(string podcastName, string podcastHost, int podcastLaunchedYear)
        {
            PodcastName = podcastName;
            PodcastHost = podcastHost;
            PodcastLaunchedYear = podcastLaunchedYear;
            _podcastId = Guid.NewGuid().GetHashCode();
        }

        public string GetFormattedString()
        {
            return $"{PodcastName} hosted by {PodcastHost}, released in {PodcastLaunchedYear}";
        }

        public bool WasLaunchedBefore2010()
        {
            return PodcastLaunchedYear < 2010;
        }

        public int GetUniqueId()
        {
            return _podcastId;
        }
    }
}
