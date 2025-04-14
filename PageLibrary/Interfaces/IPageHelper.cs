namespace PageLibrary.Interfaces
{
    public interface IClick
    {
        void Click(string selector);
    }

    public interface IFill
    {
        void Fill(string selector, string text);
    }

    public interface IUploadFile
    {
        void UploadFile(string selector, string filePath);
    }
}
