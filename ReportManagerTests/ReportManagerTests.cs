using ReportManagerFunctions;

namespace ReportManagerTests
{
    public class ReportManagerTests
    {
        //private readonly ReportManager _reportManager;
        private readonly ReportGenerator _reportGenerator;
        private readonly ReportSaver _reportSaver;
        private readonly ReportSender _reportSender;

        public ReportManagerTests()
        {
            //_reportManager = new ReportManager();
            _reportGenerator = new ReportGenerator();
            _reportSaver = new ReportSaver();
            _reportSender = new ReportSender();
        }

        [Fact]
        public void GenerateReport_ShouldPrintGeneratingMessage()
        {
            //var result = _reportManager.GenerateReport();
            var result = _reportGenerator.GenerateReport();

            Assert.Equal("Generating Report...", result);  // Example assert
        }

        [Fact]
        public void FullReportProcess_ShouldWorkTogether()
        {
            // Act
            //var reportGeneration = _reportManager.GenerateReport();
            //var savedReportResult = _reportManager.SaveReport("some/file/path");
            //var sendEmailResult = _reportManager.SendReportByEmail("test@example.com");

            var reportGeneration = _reportGenerator.GenerateReport();
            var savedReportResult = _reportSaver.SaveReport("some/file/path");
            var sendEmailResult = _reportSender.SendReportByEmail("test@example.com");

            // Assert
            Assert.Equal("Generating Report...", reportGeneration);
            Assert.Equal("Saving report to some/file/path...", savedReportResult);
            Assert.Equal("Sending report to test@example.com", sendEmailResult);
        }
    }
}
