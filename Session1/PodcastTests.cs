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
            // Arrange
            var podcastName = "Home Cooking";
            var podcastHost = "Samin Nosra";
            var podcastLaunchedYear = 2020;

            // Act
            var podcast = new Podcast(podcastName, podcastHost, podcastLaunchedYear);

            // Assert
            Assert.Equal(podcastName, podcast.PodcastName);
            Assert.Equal(podcastHost, podcast.PodcastHost);
            Assert.Equal(podcastLaunchedYear, podcast.PodcastLaunchedYear);

            // Output for debugging
            _output.WriteLine($"PodcastName: {podcast.PodcastName}");
            _output.WriteLine($"PodcastHost: {podcast.PodcastHost}");
            _output.WriteLine($"PodcastLaunchedYear: {podcast.PodcastLaunchedYear}");
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
            // Arrange
            var podcast = new Podcast("Tort de ciocolata", "Jamila", 2021);

            // Act
            var formattedString = podcast.GetFormattedString();

            // Assert
            Assert.Contains("Tort de ciocolata hosted by Jamila, released in 2021", formattedString);
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            // Arrange
            var podcast = new Podcast("Tort diplomat", "Jamila", 2008);

            // Act
            var isClassic = podcast.WasLaunchedBefore2010();

            // Assert
            Assert.True(isClassic);
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            // Arrange
            var podcast1 = new Podcast("Tort de ciocolata", "Jamila", 2021);
            var podcast2 = new Podcast("Tort de vanilie", "Blenche", 2024);

            // Act
            var id1 = podcast1.GetUniqueId();
            var id2 = podcast2.GetUniqueId();

            // Assert
            Assert.NotEqual(id1, id2);

            // Output for debugging
            _output.WriteLine($"Podcast1 ID: {id1}");
            _output.WriteLine($"Podcast2 ID: {id2}");
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedState()
        {
            // Arrange
            var podcast1 = new Podcast("Tort de ciocolata", "Jamila", 2021);
            var podcast2 = podcast1;

            // Act
            podcast2.PodcastName = "Tort de vanilie";

            // Assert
            Assert.Equal("Tort de vanilie", podcast1.PodcastName);
            Assert.Equal("Tort de vanilie", podcast2.PodcastName);
        }
    }
}

