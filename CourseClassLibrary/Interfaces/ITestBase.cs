using Microsoft.Playwright;

namespace CourseClassLibrary.Interfaces
{
    public interface ITestBase
    {
        Task InitializeAsync();

        Task OpenPageAsync(string url);

        void CloseBrowser();

        Task ClickElementAsync(string selector);

        bool CheckSuccess(string selector);
    }
}
