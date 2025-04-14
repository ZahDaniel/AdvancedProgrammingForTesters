namespace TestLogger
{
    public class TestLogging
    {
        public void Log(string message, string type)
        {
            if (type == "console")
            {
                Console.WriteLine(message);
            }
            else if (type == "file")
            {
                File.AppendAllText("testlog.txt", message + "\n");
            }
            else
            {
                throw new NotSupportedException("Unknown log type");
            }
        }
    }
}