using System;

public class UploadPopup
{
    public class UploadPopup : IUploadPopup
    {
        private string _title;
        private string _message;

        public void Show()
        {
            Console.WriteLine("Showing upload popup");
        }

        public void Close()
        {
            Console.WriteLine("Closing upload popup");
        }

        //from IDialogPopup
        public void SetTitle(string title)
        {
            _title = title;
            Console.WriteLine($"Title set: {title}");
        }

        //from IDialogPopup
        public void SetMessage(string message)
        {
            _message = message;
            Console.WriteLine($"Message set: {message}");
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
}
