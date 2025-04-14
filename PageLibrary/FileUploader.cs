using PageLibrary.Interfaces;

namespace PageLibrary
{
    public class FileUploader : IFileUploader
    {
        public void UploadFile(string selector, string filePath)
        {
            Console.WriteLine($"Upload file called in LoginPageHelper for {filePath} at {selector}");
        }
    }
}
