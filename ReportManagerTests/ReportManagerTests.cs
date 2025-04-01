using ReportManagerFunctions;

namespace ReportManagerTests
{
    public class ReportManagerTests
    {
        private readonly ReportManager _reportManager;

        public ReportManagerTests()
        {
            _reportManager = new ReportManager();
        }

        [Fact]
        public void GenerateReport_ShouldPrintGeneratingMessage()
        {
            var result = _reportManager.GenerateReport();

            Assert.Equal("Generating Report...", result);  // Example assert
        }

        // Test all functionalities together (which is hard to isolate for unit testing)
        [Fact]
        public void FullReportProcess_ShouldWorkTogether()
        {
            // Act
            var reportGeneration = _reportManager.GenerateReport();
            var savedReportResult = _reportManager.SaveReport("some/file/path");
            var sendEmailResult = _reportManager.SendReportByEmail("test@example.com");

            // Assert
            Assert.Equal("Generating Report...", reportGeneration);
            Assert.Equal("Saving report to some/file/path...", savedReportResult);
            Assert.Equal("Sending report to test@example.com", sendEmailResult);
        }
    }
}
