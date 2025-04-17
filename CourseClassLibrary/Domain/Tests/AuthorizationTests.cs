using CourseClassLibrary.Interfaces;
using Microsoft.Playwright;
using Xunit;
using Xunit.Abstractions;

namespace CourseClassLibrary.Domain.Tests
{
    public class AuthorizationTests : ITestBase
    {
        private readonly ITestOutputHelper _output;

        public AuthorizationTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private IPage _page = default!;
        private IBrowser? _browser;
        private IBrowserContext? _context;

        // Define locators for the authorization page
        private const string UsernameFieldLocator = "#username-field";
        private const string PasswordFieldLocator = "#password-field";
        private const string SubmitButtonLocator = "#submit-button";
        private const string SuccessMessageLocator = "#success-message";
        private const string AuthorizationPageUrl = "https://example.com/login";

        public async Task InitializeAsync()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }

        public async Task ClickElementAsync(string selector)
        {
            var element = _page.Locator(selector);
            await element.ClickAsync();
        }

        public bool CheckSuccess(string selector)
        {
            return _page.Locator(selector).IsVisibleAsync().Result;
        }

        public void CloseBrowser()
        {
            _browser?.DisposeAsync();
        }

        public async Task OpenPageAsync(string url)
        {
            await _page.GotoAsync(url);
        }

        [Fact]  //install package
        public async Task AuthorizationTest()
        {
            {
                // Initialize the browser and navigate to the authorization page
                await InitializeAsync();
                await OpenPageAsync(AuthorizationPageUrl);

                // Fill in the form with credentials
                await _page.FillAsync(UsernameFieldLocator, "ionelastoica@centric.eu");
                await _page.FillAsync(PasswordFieldLocator, "password");

                // Click the authorization button
                await ClickElementAsync(SubmitButtonLocator);

                // Verify if authorization was successful
                bool isSuccess = CheckSuccess(SuccessMessageLocator);
                _output.WriteLine(isSuccess ? "Authorization successful!" : "Authorization failed.");
                
                // Ensure the browser is closed
                CloseBrowser();
            }
        }
    }
}

