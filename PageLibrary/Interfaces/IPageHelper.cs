namespace PageLibrary.Interfaces
{

    public interface IClickable
    {
        void Click(string selector);
    }

    public interface IFillable
    {
        void Fill(string selector, string text);
    }

    public interface IFileUploadable
    {
        void UploadFile(string selector, string filePath);
    }
}