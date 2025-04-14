public interface IReportProcessor
{
    string GenerateReport(string reportName);
    string SaveReport(string filePath);
    string SendReportByEmail(string email);
}
