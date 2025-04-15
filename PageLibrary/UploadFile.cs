using PageLibrary.Interfaces;

namespace PageLibrary
{
    public class UploadFile : IUploadFile
    {
        void IUploadFile.UploadFile(string selector, string filePath)
        {
            Console.WriteLine($"[Ignored] Upload file called in LoginPageHelper for {filePath} at {selector}");
        }
    }
}
