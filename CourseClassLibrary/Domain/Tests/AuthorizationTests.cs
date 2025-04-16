using CourseClassLibrary.Abstractions;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace CourseClassLibrary.Domain.Tests
{
    public class AuthorizationTests : ITestBase
    {
        private IPage _page = default!;
        private IBrowser? _browser;
        private IBrowserContext? _context;

        // Locators for the authorization page
        private const string UsernameFieldSelector = "#username";
        private const string PasswordFieldSelector = "#password";
        private const string LoginButtonSelector = "#loginButton";
        private const string SuccessMessageSelector = "#welcomeMessage";

        public async Task InitializeAsync()
        {
            // Create Playwright instance
            var playwright = await Playwright.CreateAsync();

            // Launch Chromium browser
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });

            // Create a new browser context and page
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }

        public async Task OpenPageAsync(string url)
        {
            await _page.GotoAsync(url);
        }

        public void CloseBrowser()
        {
            _browser?.DisposeAsync();
        }

        public async Task ClickElementAsync(string selector)
        {
            Console.WriteLine($"Attempting to click element with selector: {selector}");
            var element = _page.Locator(selector);
            await element.ClickAsync();
            Console.WriteLine($"Successfully clicked element with selector: {selector}");
        }

        public bool CheckSuccess(string selector)
        {
            Console.WriteLine($"Checking visibility of element with selector: {selector}");
            var isVisible = _page.Locator(selector).IsVisibleAsync().Result;
            Console.WriteLine(isVisible
                ? $"Element with selector: {selector} is visible."
                : $"Element with selector: {selector} is not visible.");
            return isVisible;
        }

        public async Task AuthorizationTest()
        {
            // Initialize the browser and navigate to the authorization page
            await InitializeAsync();
            await OpenPageAsync("https://example.com/authorization");

            // Fill in the form with credentials
            await _page.FillAsync(UsernameFieldSelector, "admin");
            await _page.FillAsync(PasswordFieldSelector, "password123");

            // Click the authorization button
            await ClickElementAsync(LoginButtonSelector);

            // Verify if authorization was successful
            bool isAuthorized = CheckSuccess(SuccessMessageSelector);
            Console.WriteLine(isAuthorized
                ? "Authorization successful!"
                : "Authorization failed.");

            // Close the browser
            CloseBrowser();
        }
    }
}