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
            var podcast = new Podcast("Mind Architect", "Paul Olteanu", 2018);

            _output.WriteLine($"Podcast title => {podcast.Title}");
            _output.WriteLine($"Podcast host => {podcast.Host}");
            _output.WriteLine($"Podcast year launched => {podcast.YearLaunched}");

            Assert.Equal("Mind Architect", podcast.Title);
            Assert.Equal("Paul Olteanu", podcast.Host);
            Assert.Equal(2018, podcast.YearLaunched);
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
            var podcast = new Podcast("Fain&Simplu", "Mihai Morar", 2022);
            string podcastInformations = podcast.GetPodcastInfo();

            Assert.Contains("Fain&Simplu", podcastInformations);
            Assert.Contains("Mihai Morar", podcastInformations);
            Assert.Contains("2022", podcastInformations);
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            var podcast = new Podcast("The Food Chain", "BBC", 2006);
            
            Assert.True(podcast.WasLaunchedBefore2010());
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            var podcast1 = new Podcast("Mind Architect", "Paul Olteanu", 2018);
            var podcast2 = new Podcast("The Courage to Change: A Recovery Podcast", "Ashley Loeb Blassingame", 2018);
           
            _output.WriteLine($"Podcast1 id => {podcast1.UniqueId}");
            _output.WriteLine($"Podcast2 id => {podcast2.UniqueId}");
            
            Assert.NotEqual(podcast1.UniqueId, podcast2.UniqueId);
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedStates()
        {
            var podcast1 = new Podcast("Mind Architect", "Paul Olteanu", 2018);
            var podcast2 = podcast1;
            podcast2.Title = "The Courage to Change: A Recovery Podcast";
           
            Assert.Equal(podcast1.Title, podcast2.Title);
        }
    } 
}
