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
            var podcast = new Podcast("The Daily", "Michael Barbaro", 2009);

            _output.WriteLine(podcast.Name);
            _output.WriteLine(podcast.Host);
            _output.WriteLine(podcast.ReleaseYear.ToString());

            Assert.Equal("The Daily", podcast.Name);
            Assert.Equal("Michael Barbaro", podcast.Host);
            Assert.Equal(2009, podcast.ReleaseYear);
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
             var podcast = new Podcast("The Daily", "Michael Barbaro", 2009);
            _output.WriteLine(podcast.GetPodcastInfo());

            Assert.Contains(podcast.Name, podcast.GetPodcastInfo());
            Assert.Contains(podcast.Host, podcast.GetPodcastInfo());
            Assert.Contains(podcast.ReleaseYear.ToString(), podcast.GetPodcastInfo());
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            var podcast = new Podcast("The Daily", "Michael Barbaro", 2009);
            _output.WriteLine(podcast.IsPodcastReleasedBefore2010().ToString());

            Assert.True(podcast.IsPodcastReleasedBefore2010());
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            var podcast1 = new Podcast("The Daily", "Michael Barbaro", 2009);
            var podcast2 = new Podcast("Vreau sa stiu", "Catalin Oprisan", 2019);

            _output.WriteLine($"The unique id of the first podcast is: {podcast1.UniqueId}");
            _output.WriteLine($"The unique id of the second podcast is: {podcast2.UniqueId}");

            Assert.True(podcast1.UniqueId != podcast2.UniqueId);
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedState()
        {
            var podcast1 = new Podcast("The Daily", "Michael Barbaro", 2009);

            var podcast2 = podcast1;

            _output.WriteLine($"The value of podcast1 before changing property is: {podcast1.GetPodcastInfo()}");
            _output.WriteLine($"The value of podcast2 before changing property is: {podcast2.GetPodcastInfo()}");

            podcast2.Name = "Vreau sa stiu";

            _output.WriteLine($"The value of podcast1 after changing property is: {podcast1.GetPodcastInfo()}");
            _output.WriteLine($"The value of podcast2 after changing property is: {podcast2.GetPodcastInfo()}");
        }
    }
}
