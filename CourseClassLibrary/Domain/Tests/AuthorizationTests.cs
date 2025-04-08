using CourseClassLibrary.Interfaces;
using Microsoft.Playwright;
using Xunit.Abstractions;
using Xunit;

namespace CourseClassLibrary.Domain.Tests
{
    public class AuthorizationTests : ITestBase
    {
        protected IPage Page { get; set; } = default!;
        protected IBrowser? Browser { get; set; }
        protected IBrowserContext? Context { get; set; }

        public async Task InitializeAsync()
        {
            // Create Playwright instance
            var playwright = await Playwright.CreateAsync();

            // Launch Chromium browser
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });

            // Create a new browser context and page
            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        public async Task ClickElementAsync(string selector)
        {
            var element = Page.Locator(selector);
            await element.ClickAsync();
        }

        public virtual bool CheckSuccess(string selector)
        {
            return Page.Locator(selector).IsVisibleAsync().Result;
        }

        public async Task OpenPageAsync(string url)
        {
            await Page.GotoAsync(url);
        }

        public void CloseBrowser()
        {
            Browser?.DisposeAsync();
        }

        private readonly ITestOutputHelper _output;

        public AuthorizationTests(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public void AuthorizationTest()
        {
            //Initialize the browser
             InitializeAsync();

            //Navigate to the authorization page
            string authorizationPageUrl = "https://example.com/authorization"; 
            OpenPageAsync(authorizationPageUrl);

            //Fill in the form with credentials
             Page.FillAsync("#username", "admin"); 
             Page.FillAsync("#password", "admin123"); 

            //Click the authorization button
             ClickElementAsync("#loginButton"); 

            //Verify if authorization was successful
            bool isAuthorized = CheckSuccess("#welcomeMessage");
            Assert.True(isAuthorized, "Authorization fail : Welcome message not found.");
        }
    }
}
