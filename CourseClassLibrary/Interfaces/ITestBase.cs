namespace CourseClassLibrary.Interfaces
{
    public interface ITestBase
    {
        public Task InitializeAsync();
        public Task OpenPageAsync(string url);

        public void CloseBrowser();

        public Task ClickElementAsync(string selector);

        public bool CheckSuccess(string selector);
    }
}
