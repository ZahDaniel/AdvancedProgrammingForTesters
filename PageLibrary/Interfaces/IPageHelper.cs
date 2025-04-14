namespace PageLibrary.Interfaces
{
    public interface IPageHelper
    {
        void Click(string selector);
        void Fill(string selector, string text);

        //Removed UploadFile method, due to Interface Segregation Principle 
    }
}
