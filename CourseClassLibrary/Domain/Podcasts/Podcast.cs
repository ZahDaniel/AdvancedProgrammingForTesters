namespace CourseClassLibrary.Domain.Podcasts
{
    public class Podcast
    {
        public string Name { get; set; }

        public string Host { get; set; }

        public int LaunchYear { get; }

        private const int EpisodesLimit = 20;
        private readonly string _podcastUniqueId;

        public Podcast(string name, string host, int launchYear)
        {
            Name = name;
            Host = host;
            LaunchYear = launchYear;

            _podcastUniqueId = Guid.NewGuid().ToString();
        }

        public string GetPodcastInfo() => $"{Name} hosted by {Host}, released in {LaunchYear}";

        public bool IsLaunchedBefore2010(int launchYear) => launchYear < 2010;

        public string UniqueId => _podcastUniqueId;
    }
}
