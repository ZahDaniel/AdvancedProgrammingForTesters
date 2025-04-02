namespace CourseClassLibrary
{
    public class Podcast
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public int LaunchYear { get; set; }

        private const int MaxEpisodes = 200;
        private readonly string _uniqueId; //Guid type

        public Podcast(string Name, string Host, int LaunchYear) //parameters should be camelCase
        {
            this.Name = Name;
            this.Host = Host;
            this.LaunchYear = LaunchYear;
            _uniqueId = Guid.NewGuid().ToString();
        }

        public string GetPodcastInfo() => $"{Name} hosted by {Host}, released in {LaunchYear}";

        public bool IsPodcastLaunchedBefore2010() => LaunchYear < 2010;

        public string UniqueId => _uniqueId;
    }
}