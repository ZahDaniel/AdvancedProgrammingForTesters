using CourseClassLibrary;
using Xunit.Abstractions;

namespace Session1
{
    public class PodcastTests
    {
        private readonly ITestOutputHelper _output;

        public PodcastTests(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Setup for test started.");
        }

        [Fact]
        public void CanCreatePodcast_WithRequiredFields()
        {
            var podcast = new Podcast("MyPodcast", "The Host", 2020);

            _output.WriteLine($"Podcast title => {podcast.Title}");
            _output.WriteLine($"Podcast host => {podcast.Host}");
            _output.WriteLine($"Podcast year => {podcast.Year}");

            Assert.Equal("MyPodcast", podcast.Title);
            Assert.Equal("The Host", podcast.Host);
            Assert.Equal(2020, podcast.Year);
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
            var podcast = new Podcast("MyPodcast", "The Host", 2020);

            Assert.Contains("MyPodcast hosted by The Host, released in 2020", podcast.GetPodcastInfo());
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            var podcast = new Podcast("MyPodcast", "The Host", 2009);

            Assert.True(podcast.IsPodcastLaunchedBefore2010(), "The podcast is not released before 2010");
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            var firstPodcast = new Podcast("MyPodcast", "The Host", 2020);
            var secondPodcast = new Podcast("MyPodcast", "The Host", 2020);

            Assert.NotEqual(firstPodcast.UniqueId, secondPodcast.UniqueId);

            _output.WriteLine($"First Podcast uniqueId => {firstPodcast.UniqueId}");
            _output.WriteLine($"Second Podcast uniqueId => {secondPodcast.UniqueId}");
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedState()
        {
            var podcast = new Podcast("MyPodcast", "The Host", 2020);
            var anotherPodcast = podcast;

            anotherPodcast.Title = "New Podcast";

            Assert.Equal("New Podcast", podcast.Title);
            Assert.Equal("New Podcast", anotherPodcast.Title);

            _output.WriteLine($"Podcast title => {podcast.Title}");
            _output.WriteLine($"Another Podcast title => {anotherPodcast.Title}");
        }
    }
}