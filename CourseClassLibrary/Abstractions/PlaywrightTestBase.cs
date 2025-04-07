using Microsoft.Playwright;

namespace CourseClassLibrary.Abstractions
{
    public abstract class PlaywrightTestBase
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

        public async Task OpenPageAsync(string url)
        {
            await Page.GotoAsync(url);
        }

        public void CloseBrowser()
        {
            Browser?.DisposeAsync();
        }

        public virtual async Task ClickElementAsync(string selector)
        {
            var element = Page.Locator(selector);
            await element.ClickAsync();
        }

        public virtual bool CheckSuccess(string selector)
        {
            return Page.Locator(selector).IsVisibleAsync().Result;
        }
    }
}