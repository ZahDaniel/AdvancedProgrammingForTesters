public class UploadPopup : IUploadPopup
{
    public void Show()
    {
        Console.WriteLine("Showing upload popup");
    }

    public void Close()
    {
        Console.WriteLine("Closing upload popup");
    }

    public void SetUploadProgress(int percentage)
    {
        Console.WriteLine($"Upload progress: {percentage}%");
    }

    public bool ValidateFileType(string fileName)
    {
        return fileName.EndsWith(".jpg") || fileName.EndsWith(".png");
    }
}