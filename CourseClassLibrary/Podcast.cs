
namespace CourseClassLibrary
{
    public class Podcast
    {
        public string Name { get; set; }
        public string Host { get; set; }    
        public int Year { get; }

        private const int EpisodeLimit = 10; 
        private readonly Guid _uniqueId;

        public Podcast(string name, string host, int year)
        {
            Name = name;
            Host = host;
            Year = year;
            _uniqueId = Guid.NewGuid();
        }
        public string GetThePodcastDetails()
        {
            return $"{Name} hosted by {Host}, released in {Year}";
        }

        public bool WasLaunchedBefore2010()
        {
            return Year < 2010;
        }

        public Guid GetUniqueId()
        {
            return _uniqueId;
        }
    }
}
