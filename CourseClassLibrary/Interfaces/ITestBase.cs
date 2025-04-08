using Microsoft.Playwright;

namespace CourseClassLibrary.Interfaces
{
    public interface ITestBase
    {
        IPage Page { get; }
        IBrowser? Browser { get;}
        IBrowserContext? Context { get; set; }

        Task InitializeAsync();

        Task OpenPageAsync(string url);

        void CloseBrowser();

        Task ClickElementAsync(string selector);

        bool CheckSuccess(string selector);
    }
}
