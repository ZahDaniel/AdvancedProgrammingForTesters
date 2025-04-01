using CourseClassLibrary.Domain.Podcasts;
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
            var podcast = new Podcast("Cine-i janghina", "ReallyRux", 2020);

            _output.WriteLine($"Podcast name => {podcast.Name}");
            _output.WriteLine($"Podcast host => {podcast.Host}");
            _output.WriteLine($"Podcast launch year => {podcast.LaunchYear}");

            Assert.Equal("Cine-i janghina", podcast.Name);
            Assert.Equal("ReallyRux", podcast.Host);
            Assert.Equal(2020, podcast.LaunchYear);
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
            var podcast = new Podcast("Cine-i janghina", "ReallyRux", 2020);

            _output.WriteLine($"Podcast info => {podcast.GetPodcastInfo()}");

            var podcastInfo = podcast.GetPodcastInfo();
            Assert.True(podcastInfo.Contains(podcast.Name) &&
                        podcastInfo.Contains(podcast.Host) &&
                        podcastInfo.Contains(podcast.LaunchYear.ToString()));
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            var podcast = new Podcast("Fierti pe insula", "Sold out media", 2008);

            Assert.True(podcast.IsLaunchedBefore2010(podcast.LaunchYear));
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            var podcast1 = new Podcast("Cine-i janghina", "ReallyRux", 2020);
            var podcast2 = new Podcast("Cine-i janghina", "ReallyRux", 2020);

            _output.WriteLine($"Podcast1 id => {podcast1.UniqueId}");
            _output.WriteLine($"Podcast2 id => {podcast2.UniqueId}");
            
            Assert.NotEqual(podcast1.UniqueId, podcast2.UniqueId);
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedState()
        {
            var podcast1 = new Podcast("Cine-i janghina", "ReallyRux", 2020);
            var podcast2 = podcast1;
            podcast2.Name = "Cine-i janghina 2";

            _output.WriteLine($"Podcast1 name => {podcast1.Name}");
            _output.WriteLine($"Podcast2 name => {podcast2.Name}");

            Assert.Equal(podcast1.Name, podcast2.Name);
        }
    }
}
