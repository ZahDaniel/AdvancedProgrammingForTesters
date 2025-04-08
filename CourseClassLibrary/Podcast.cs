namespace CourseClassLibrary
{

    public class Podcast
    {
        public string Name { get; set; }

        public string HostName { get; set; }

        public int LaunchYear { get; }

        private readonly int _episodeLimit = 20; 

        private readonly string _podcastId; //Guid type

        public Podcast(string name, string hostName, int launchYear)
        {
            Name = name;
            HostName = hostName;
            LaunchYear = launchYear;
            _podcastId = Guid.NewGuid().ToString();
        }

        public string GetPodcastInfo() => $"{Name} hosted by {HostName}, released in {LaunchYear}";

        public bool IsPodcastLaunchedBefore2010() => LaunchYear < 2010;

        public string GetPodcastId() => _podcastId;
    }
}
