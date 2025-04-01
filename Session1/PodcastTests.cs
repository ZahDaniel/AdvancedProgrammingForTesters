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
            var podcast = new Podcast("Boost your energy & immunity", "Andrew Huberman", 2020);

            _output.WriteLine($"Podcast name => {podcast.Name}");
            _output.WriteLine($"Podcast host => {podcast.Host}");
            _output.WriteLine($"Podcast launch year => {podcast.LaunchYear}");

            Assert.Equal("Boost your energy & immunity", podcast.Name);
            Assert.Equal("Andrew Huberman", podcast.Host);
            Assert.Equal(2020, podcast.LaunchYear);
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
            var podcast = new Podcast("Mind Architect", "Paul Olteanu", 2019);

            _output.WriteLine($"Podcast info => {podcast.GetPodcastInfo()}");
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            var podcast = new Podcast("Classic Streams Podcast", "Dwight Allen", 1960);

            Assert.True(podcast.IsPodcastLaunchedBefore2010());
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            var podcast1 = new Podcast("How to learn skills faster", "Andrew Huberman", 2021);
            var podcast2 = new Podcast("The power of habits", "Charles Duhigg", 2012);

            _output.WriteLine($"Podcast1 has unique id => {podcast1.UniqueId}");
            _output.WriteLine($"Podcast2 has unique id => {podcast2.UniqueId}");

            Assert.NotEqual(podcast1.UniqueId, podcast2.UniqueId);
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedState()
        {
            var podcast1 = new Podcast("The Joe Rogan Experience", "Joe Rogan", 2009);
            var podcast2 = podcast1;

            _output.WriteLine($"Podcast1 info => {podcast1.GetPodcastInfo()}");
            _output.WriteLine($"Podcast2 info => {podcast2.GetPodcastInfo()}");

            podcast2.Name = "MCN Podcast";

            _output.WriteLine($"Podcast1 info => {podcast1.GetPodcastInfo()}");
            _output.WriteLine($"Podcast2 info => {podcast2.GetPodcastInfo()}");
        }
    }
}
