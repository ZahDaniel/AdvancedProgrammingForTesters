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
            var podcast = new Podcast("MarutaPodcast", "Maruta", 2021);

            Assert.Equal("MarutaPodcast", podcast.Name);
            Assert.Equal("Maruta", podcast.Host);
            Assert.Equal(2021, podcast.Year);
            _output.WriteLine($"Podcast created with Name: {podcast.Name}, Host: {podcast.Host}, Year: {podcast.Year}");
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
            var podcast = new Podcast("MarutaPodcast", "Maruta", 2021);

            var info = podcast.GetThePodcastDetails();

            Assert.Contains("MarutaPodcast", info);
            Assert.Contains("Maruta", info);
            Assert.Contains("2021", info);
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            var podcast = new Podcast("MarutaPodcast", "Maruta", 2009);
            var isClassic = podcast.WasLaunchedBefore2010();
            Assert.True(isClassic);
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            var podcast1 = new Podcast("MarutaPodcast", "Cancan", 2021);
            var podcast2 = new Podcast("MarutaShow", "Maruta", 2025);

            var id1 = podcast1.GetUniqueId();
            var id2 = podcast2.GetUniqueId();

            Assert.NotEqual(id1, id2);
            _output.WriteLine($"Podcast1 Id: {id1}, Podcast2 Id: {id2}");
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedState()
        {
            var podcast1 = new Podcast("MarutaPodcast", "Maruta", 2021);
            var podcast2 = podcast1;

            podcast2.Name = "Maruta Updated";

            Assert.Equal("Maruta Updated", podcast1.Name);
            Assert.Equal("Maruta Updated", podcast2.Name);
        }
    }
}
