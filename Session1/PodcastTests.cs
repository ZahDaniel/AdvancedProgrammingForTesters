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
        }

        [Fact]
        public void CanCreatePodcast_WithRequiredFields()
        {
            var podcast = new Podcast("Starea Natiei", "Dragos Patraru", 2025);

            _output.WriteLine($"Podcast name: {podcast.Name}");
            _output.WriteLine($"Podcast host: {podcast.Host}");
            _output.WriteLine($"Podcast launch year: {podcast.LaunchYear}");

            Assert.Equal("Starea Natiei", podcast.Name);
            Assert.Equal("Dragos Patraru", podcast.Host);
            Assert.Equal(2025, podcast.LaunchYear);
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
            var podcast = new Podcast("Starea Natiei", "Dragos Patraru", 2025);

            _output.WriteLine($"Podcast info: {podcast.GetPodcastInfo()}");
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            var podcast = new Podcast("This Week in Tech", "Leo Laporte", 2005);

            Assert.True(podcast.IsPodcastLaunchedBefore2010());
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            var podcast1 = new Podcast("Starea Natiei", "Dragos Patraru", 2025);
            var podcast2 = new Podcast("This Week in Tech", "Leo Laporte", 2005);

            _output.WriteLine($"Podcast1 unique id: {podcast1.UniqueId}");
            _output.WriteLine($"Podcast2 unique id: {podcast2.UniqueId}");

            Assert.NotEqual(podcast1.UniqueId, podcast2.UniqueId);
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedState()
        {
            var podcast1 = new Podcast("Starea Natiei", "Dragos Patraru", 2025);
            var podcast2 = podcast1;

            _output.WriteLine($"Podcast1 info => {podcast1.GetPodcastInfo()}");
            _output.WriteLine($"Podcast2 info => {podcast2.GetPodcastInfo()}");

            podcast2.Name = "This Week in Tech";

            _output.WriteLine($"Podcast1 info => {podcast1.GetPodcastInfo()}");
            _output.WriteLine($"Podcast2 info => {podcast2.GetPodcastInfo()}");
        }
    }
}