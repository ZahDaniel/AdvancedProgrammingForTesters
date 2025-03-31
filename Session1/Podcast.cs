using System;

namespace Session1
{
    public class Podcast
    {
        // Properties
        public string Name { get; set; }
        public string Host { get; set; }
        public int Year { get; }

        // Fields
        private const int EpisodeLimit = 100; // Example limit
        private readonly Guid _uniqueId;

        // Constructor
        public Podcast(string name, string host, int year)
        {
            Name = name;
            Host = host;
            Year = year;
            _uniqueId = Guid.NewGuid();
        }

        // Methods
        public string GetFormattedString()
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