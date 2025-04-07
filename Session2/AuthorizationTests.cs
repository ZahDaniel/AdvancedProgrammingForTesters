using CourseClassLibrary.Interfaces;
using Microsoft.Playwright;

namespace Tests
{
    public class AuthorizationTests : ITestBase
    {
        private IPage _page;
        private IBrowser _browser;

        public async Task InitializeAsync()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            _page = await _browser.NewPageAsync();
        }
        public async Task OpenPageAsync(string url)
        {
            await _page.GotoAsync(url);
        }

        public async Task ClickElementAsync(string selector)
        {
            await _page.ClickAsync(selector);
        }

        public bool CheckSuccess(string selector)
        {
            var element = _page.QuerySelectorAsync(selector).Result;
            return element != null;
        }

        public void CloseBrowser()
        {
            _browser?.DisposeAsync();
        }

        [Fact]
        public async Task AuthorizationTest()
        {
            await InitializeAsync();
            await _page.GotoAsync("https://practicesoftwaretesting.com");

            await _page.ClickAsync("//*[@data-test=\"nav-sign-in\"]");

            await _page.FillAsync("//*[@id=\"email\"]", "gigi@becali.ro");
            await _page.FillAsync("//*[@id=\"password\"]", "Haharelelor1@");

            await ClickElementAsync("//*[@data-test=\"login-submit\"]");

            bool isSuccess = CheckSuccess("//h1[normalize-space()='My account']");
            Assert.True(isSuccess, "Authorization failed.");

            CloseBrowser();
        }
    }
}
