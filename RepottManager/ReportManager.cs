namespace ReportManagerFunctions
{
    public class ReportManager
    {
        public string GenerateReport()
        {
            return "Generating Report...";
        }

        public string SaveReport(string filePath)
        {
            return $"Saving report to {filePath}...";
        }

        public string SendReportByEmail(string email)
        {
           return $"Sending report to {email}";
        }
    }
}
