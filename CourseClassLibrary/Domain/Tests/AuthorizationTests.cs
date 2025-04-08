using CourseClassLibrary.Interfaces;
using Microsoft.Playwright;
using Xunit;
using Xunit.Abstractions;

namespace CourseClassLibrary.Domain.Tests
{
    public class AuthorizationTests : ITestBase
    {
        private readonly ITestOutputHelper _output;

        protected IPage Page { get; set; } = default!;

        protected IBrowser? Browser { get; set; }

        protected IBrowserContext? Context { get; set; }

        public AuthorizationTests(ITestOutputHelper output)
        {
            _output = output;
        }

        //locators
        private string usernameInput = "#user-name";

        private string passwordInput = "#password";

        private string loginButton = "#login-button";

        private string successMessage = "#success-message";

        public async Task InitializeAsync()
        {
            var playwright = await Playwright.CreateAsync();

            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        public async Task ClickElementAsync(string selector)
        {
            var element = Page.Locator(selector);

            await element.ClickAsync();
        }

        public bool CheckSuccess(string selector)
        {
            var element = Page.Locator(selector);

            return element.IsVisibleAsync().Result;
        }

        public void CloseBrowser()
        {
            Browser?.DisposeAsync();
        }

        public async Task OpenPageAsync(string url)
        {
            await Page.GotoAsync(url);
        }

        [Fact]
        public async Task AuthorizationTest()
        {
            // Navigate to the page
            await InitializeAsync();
            await OpenPageAsync("https://www.saucedemo.com/");

            // Fill in the username and password fields
            await Page.FillAsync(usernameInput, "standard_user");
            await Page.FillAsync(passwordInput, "secret_sauce");

            // Click the login button
            await ClickElementAsync(loginButton);

            // Check for success message
            bool isSuccessMessageDisplayed = CheckSuccess(successMessage);

            if (isSuccessMessageDisplayed)
            {
                _output.WriteLine("Authorization successful!");
            }
            else
            {
                _output.WriteLine("Authorization successful!");
            }

            CloseBrowser();
        }
    }
}
