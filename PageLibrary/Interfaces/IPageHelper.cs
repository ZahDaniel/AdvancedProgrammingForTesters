namespace PageLibrary.Interfaces
{
    public interface IPageHelper
    {
        void Click(string selector);
        void Fill(string selector, string text);
        void UploadFile(string selector, string filePath);
    }
}