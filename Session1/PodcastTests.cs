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
            var podcast = new Podcast("Fain si simplu", "Mihai Morar", 2023);

            _output.WriteLine($"Podcast name => {podcast.Name}");
            _output.WriteLine($"Podcast host => {podcast.HostName}");
            _output.WriteLine($"Podcast year => {podcast.LaunchYear}");

            Assert.Equal("Fain si simplu", podcast.Name);
            Assert.Equal("Mihai Morar", podcast.HostName);
            Assert.Equal(2023, podcast.LaunchYear);
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
            var podcast = new Podcast("Fain si simplu", "Mihai Morar", 2023);
            Assert.Equal("Fain si simplu hosted by Mihai Morar, released in 2023", podcast.GetPodcastInfo());
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            var podcast = new Podcast("Fain si simplu", "Mihai Morar", 2008);
            Assert.True(podcast.IsPodcastLaunchedBefore2010());
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            var podcast1 = new Podcast("Podcast 1", "Host1", 2023);
            var podcast2 = new Podcast("Podcast 2", "Host2", 2021);

            _output.WriteLine($"Podcast id => {podcast1.GetPodcastId()}");
            _output.WriteLine($"Podcast id => {podcast2.GetPodcastId()}");

            Assert.NotEqual(podcast1.GetPodcastId(), podcast2.GetPodcastId());
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedState()
        {
            var podcast1 = new Podcast("Podcast 1", "Host1", 2023);
            var podcast2 = podcast1;
            podcast2.Name = "Podcast object reference";

            _output.WriteLine($"Podcast 1 => {podcast1.GetPodcastInfo()}");
            _output.WriteLine($"Podcast 2 => {podcast2.GetPodcastInfo()}");

            Assert.Equal(podcast1.Name, podcast2.Name);
        }
    }
}
