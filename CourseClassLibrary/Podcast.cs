namespace CourseClassLibrary
{
    public class Podcast
    {
        public string PodcastName { get; set; }
        public string PodcastHost { get; set; }
        public int PodcastYear { get; }

        private const int MaxPodcastEpisods = 9; //small typo
        private readonly string _podcastId;

        public Podcast(string podcastName, string postcastHost, int postcastYear)
        {
            PodcastName = podcastName;
            PodcastHost = postcastHost;
            PodcastYear = postcastYear;
            _podcastId = Guid.NewGuid().ToString();
        }

        public string GetPodcastInfo() => $"{PodcastName} hosted by {PodcastHost}, released in {PodcastYear}";

        public bool PodcastLaunchedBeforeYear(int year) => PodcastYear < year;

        public string PodcastId => _podcastId;
    }
}
