namespace CourseClassLibrary
{
    public class Podcast
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public int LaunchYear { get; set; }
        private const int MaxEpisodes = 200;
        private readonly Guid _uniqueId;

        public Podcast(string name, string host, int launchYear)
        {
            Name = name;
            Host = host;
            LaunchYear = launchYear;
            _uniqueId = Guid.NewGuid();
        }

        public string GetPodcastInfo()
        {
            return $"{Name} hosted by {Host}, launched in {LaunchYear}";
        }

        public bool IsPodcastLaunchedBefore2010()
        {
            return LaunchYear < 2010;
        }

        public Guid UniqueId => _uniqueId;
    }
}