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
            // Arrange
            var podcast = new Podcast("Tech Talk", "John Doe", 2021);

            // Act & Assert
            Assert.Equal("Tech Talk", podcast.Name);
            Assert.Equal("John Doe", podcast.Host);
            Assert.Equal(2021, podcast.Year);
            _output.WriteLine($"Podcast created: {podcast.Name}, {podcast.Host}, {podcast.Year}");
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
            // Arrange
            var podcast = new Podcast("Tech Talk", "John Doe", 2021);

            // Act
            var info = podcast.GetFormattedString();

            // Assert
            Assert.Contains("Tech Talk", info);
            Assert.Contains("John Doe", info);
            Assert.Contains("2021", info);
            Assert.Equal("Tech Talk hosted by John Doe, released in 2021", info);
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            // Arrange
            var podcast = new Podcast("History Hour", "Jane Smith", 2005);

            // Act
            var isClassic = podcast.WasLaunchedBefore2010();

            // Assert
            Assert.True(isClassic);
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            // Arrange
            var podcast1 = new Podcast("Tech Talk", "John Doe", 2021);
            var podcast2 = new Podcast("History Hour", "Jane Smith", 2005);

            // Act
            var id1 = podcast1.GetUniqueId();
            var id2 = podcast2.GetUniqueId();

            // Assert
            Assert.NotEqual(id1, id2);
            _output.WriteLine($"Podcast 1 ID: {id1}");
            _output.WriteLine($"Podcast 2 ID: {id2}");
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedState()
        {
            // Arrange
            var podcast1 = new Podcast("Tech Talk", "John Doe", 2021);
            var podcast2 = podcast1;

            // Act
            podcast2.Name = "Tech Talk Updated";

            // Assert
            Assert.Equal("Tech Talk Updated", podcast1.Name);
            Assert.Equal("Tech Talk Updated", podcast2.Name);
        }
    }
}
