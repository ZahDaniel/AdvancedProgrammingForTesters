using CourseClassLibrary.Interfaces;
using Microsoft.Playwright;

namespace Session2
{
    public class AuthorizationTests : ITestBase
    {
        protected IPage Page { get; set; } = default!;

        protected IBrowser? Browser { get; set; }

        protected IBrowserContext? Context { get; set; }

        // Define locators for the authorization page
        private const string UsernameSelector = "#username";

        private const string PasswordSelector = "#password";

        private const string LoginButtonSelector = "#loginButton";

        private const string SuccessMessageSelector = "#successMessage";

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

        public void CloseBrowser()
        {
            Browser?.DisposeAsync();
        }

        public async Task ClickElementAsync(string selector)
        {
            var element = Page.Locator(selector);
            await element.ClickAsync();
        }

        public bool CheckSuccess(string selector)
        {
            return Page.Locator(selector).IsVisibleAsync().Result;
        }

        [Fact]
        public async Task AuthorizationTest()
        {
            await InitializeAsync();
            await OpenPageAsync("https://example.com/authorization");

            // Fill in the form with credentials
            await Page.FillAsync(UsernameSelector, "admin");
            await Page.FillAsync(PasswordSelector, "password");

            // Click the authorization button
            await ClickElementAsync(LoginButtonSelector);

            // Verify if authorization was successful
            bool isSuccess = CheckSuccess(SuccessMessageSelector);

            // Add assertions or further test logic here
            if (isSuccess)
            {
                System.Console.WriteLine("Authorization successful!");
            }
            else
            {
                System.Console.WriteLine("Authorization failed.");
            }

            CloseBrowser();
        }
    }
}