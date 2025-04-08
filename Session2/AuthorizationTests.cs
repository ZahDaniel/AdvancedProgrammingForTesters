using CourseClassLibrary.Interfaces;
using Microsoft.Playwright;
using Xunit.Abstractions;

namespace Session2
{
    public class AuthorizationTests : ITestBase
    {
        private readonly ITestOutputHelper _output;

        public AuthorizationTests(ITestOutputHelper output)
        {
            _output = output;
        }

        protected IPage Page { get; set; } = default!;

        protected IBrowser? Browser { get; set; }

        protected IBrowserContext? Context { get; set; }

        private const string UsernameElement = "#username";

        private const string PasswordElement = "#password";

        private const string LoginButtonElement = ".btnSubmit";

        private const string SuccessMessageElement = "#successMessage";

        public bool CheckSuccess(string selector)
        {
            return Page.Locator(selector).IsVisibleAsync().Result;
        }

        public async Task ClickElementAsync(string selector)
        {
            var element = Page.Locator(selector);
            await element.ClickAsync();
        }

        public void CloseBrowser()
        {
            Browser?.DisposeAsync();
        }

        public async Task InitializeAsync()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        public async Task OpenPageAsync(string url)
        {
            await Page.GotoAsync(url);
        }

        [Fact]
        public async Task AuthorizationTest()
        {
            await InitializeAsync();
            await OpenPageAsync("https://example.com/authorization");

            await Page.FillAsync(UsernameElement, "test@centric.eu");
            await Page.FillAsync(PasswordElement, "Raluca12##");

            await ClickElementAsync(LoginButtonElement);

            bool isSuccess = CheckSuccess(SuccessMessageElement);

            if (isSuccess)
                _output.WriteLine("Authorization successful!");
            else
                _output.WriteLine("Authorization failed.");

            CloseBrowser();
        }
    }
}
