using CourseClassLibrary;
using Xunit.Abstractions;

namespace Session1
{
    public class PodcastTests
    {
        private readonly ITestOutputHelper _output;
        private readonly string title = "Around the world";
        private readonly string host = "Cassie Taller";
        private readonly int releaseYear = 2021;

        public PodcastTests(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Setup for test started.");
        }

        [Fact]
        public void CanCreatePodcast_WithRequiredFields()
        {
            var podcast = new Podcast(title, host, releaseYear);

            Assert.Equal(title, podcast.PodcastName);
            Assert.Equal(host, podcast.PodcastHost);
            Assert.Equal(releaseYear, podcast.PodcastYear);

            _output.WriteLine($"Podcast created with Title: {podcast.PodcastName}, Host: {podcast.PodcastHost}, Release Year: {podcast.PodcastYear}");
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
            var podcast = new Podcast(title, host, releaseYear);
            var podcastInfo = podcast.GetPodcastInfo();

            Assert.Contains(title, podcastInfo);
            Assert.Contains(host, podcastInfo);
            Assert.Contains(releaseYear.ToString(), podcastInfo);

            _output.WriteLine($"Podcast info: {podcastInfo}");
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            var podcastOlder = new Podcast("Classic Trip", "Jane Pitt", 2005);

            var isClassic = podcastOlder.PodcastLaunchedBeforeYear(2010);
            Assert.True(isClassic);

            _output.WriteLine($"Podcast '{podcastOlder.PodcastName}' is classic: {isClassic}");
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            var podcast1 = new Podcast("Magic Trip", "First Host", 2021);
            var podcast2 = new Podcast("Great Trip", "Second Host", 2022);

            var id1 = podcast1.PodcastId;
            var id2 = podcast2.PodcastId;

            Assert.NotEqual(id1, id2);

            _output.WriteLine($"Podcast One ID: {id1}, Podcast Two ID: {id2}");
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedState()
        {
            var firstPodcast = new Podcast("First Podcast", "Original Host", 2021);
            var updatedPodcast = firstPodcast;

            updatedPodcast.PodcastName = "Updated Podcast";

            Assert.Equal("Updated Podcast", firstPodcast.PodcastName);
            Assert.Equal("Updated Podcast", updatedPodcast.PodcastName);

            _output.WriteLine($"Original Podcast Name: {firstPodcast.PodcastName}, Reference Podcast Name: {updatedPodcast.PodcastName}");
        }
    }
}
