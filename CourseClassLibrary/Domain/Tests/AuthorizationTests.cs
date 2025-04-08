using CourseClassLibrary.Interfaces;
using Microsoft.Playwright;
using Xunit.Abstractions;

namespace CourseClassLibrary.Domain.Tests
{
    public class AuthorizationTests : ITestBase
    {
        private readonly ITestOutputHelper _output;

        public AuthorizationTests(ITestOutputHelper output) => _output = output;

        public IPage Page { get; private set; } = null!;
        public IBrowser? Browser { get; private set; }
        public IBrowserContext? Context { get; set; }

        private readonly string authorizationUrl = "https://example.com/login";
        private readonly string username = "admin";
        private readonly string password = "password";

        private readonly Dictionary<string, string> elements = new Dictionary<string, string>
        {
            { "UsernameElement", "#username" },
            { "PasswordElement", "#password" },
            { "LoginBtnElement", ".btnLogin" },
            { "SuccessMessageElement", "#successMessage" }
        };

        public async Task InitializeAsync()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        public async Task OpenPageAsync(string url)
        {
            await Page.GotoAsync(url);
        }

        public void CloseBrowser()
        {
            Browser?.CloseAsync();
        }

        public async Task ClickElementAsync(string elementName)
        {
            if (elements.TryGetValue(elementName, out var selector))
            {
                await Page.ClickAsync(selector);
            }
        }

        public bool CheckSuccess(string elementName)
        {
            if (elements.TryGetValue(elementName, out var selector))
            {
                var element = Page.QuerySelectorAsync(selector).Result;
                return element != null && element.IsVisibleAsync().Result;
            }
            return false;
        }

        public async Task AuthorizationTest()
        {
            await InitializeAsync();
            await OpenPageAsync(authorizationUrl);

            await Page.FillAsync(elements["UsernameElement"], username);
            await Page.FillAsync(elements["PasswordElement"], password);
            await ClickElementAsync("LoginBtnElement");

            bool isSuccess = CheckSuccess("SuccessMessageElement");

            if (isSuccess)
                _output.WriteLine("Authorization is successful!");
            else
                _output.WriteLine("Authorization has failed.");

            CloseBrowser();
        }
    }
}
