using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var podcast = new Podcast("Starea Natiei", "Dragos Patraru", 2012);

            _output.WriteLine($"Podcast title => {podcast.Name}");
            _output.WriteLine($"Podcast author => {podcast.Author}");
            _output.WriteLine($"Podcast year => {podcast.Year}");

            Assert.Equal("Starea Natiei", podcast.Name);
            Assert.Equal("Dragos Patraru", podcast.Author);
            Assert.Equal(2012, podcast.Year);
        }

        [Fact]
        public void GetPodcastInfo_ShouldContainFormattedDetails()
        {
            var podcast = new Podcast("Starea Natiei", "Dragos Patraru", 2012);
            Assert.Equal("Starea Natiei hosted by Dragos Patraru, released in 2012", podcast.GetPodcastInfo());
        }

        [Fact]
        public void IsClassic_ShouldReturnTrue_ForOldPodcasts()
        {
            var podcast = new Podcast("Starea Natiei", "Dragos Patraru", 2012);
            Assert.True(podcast.isLaunchedBefore2010());
        }

        [Fact]
        public void UniquePodcastId_IsAssignedCorrectly()
        {
            var podcastSN = new Podcast("Starea Natiei", "Dragos Patraru", 2012);
            var podcastGSP = new Podcast("GSP Live", "Mihai Mironica", 2024);

            _output.WriteLine($"The GUID for {podcastSN.Name} is {podcastSN.UniqueId()}");
            _output.WriteLine($"The GUID for {podcastGSP.Name} is {podcastGSP.UniqueId()}");

            Assert.NotEqual(podcastSN.UniqueId(), podcastGSP.UniqueId());
        }

        [Fact]
        public void Podcast_ObjectReference_ShowsSharedState()
        {
            var backup_podcast = new Podcast("Starea Natiei", "Dragos Patraru", 2012);
            var podcast = backup_podcast;
            _output.WriteLine($"The Author for {backup_podcast.Name} is {backup_podcast.Author}");
            podcast.Author = "Valeriu Nicolae";
            _output.WriteLine($"The Author for {backup_podcast.Name} is {backup_podcast.Author}");
            Assert.Equal(podcast.Author, backup_podcast.Author);
        }
    }
}
