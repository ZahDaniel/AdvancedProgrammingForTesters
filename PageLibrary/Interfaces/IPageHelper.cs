namespace PageLibrary.Interfaces
{
    public interface IPageHelper
    {
        // Interface segregation
        void Click(string selector);
        void Fill(string selector, string text);
        //void UploadFile(string selector, string filePath);
    }
}