using CourseClassLibrary.Abstractions;

namespace CourseClassLibrary.Domain.Tests
{
    public class LoginTests : PlaywrightTestBase
    {
        public override async Task ClickElementAsync(string selector)
        {
            // Custom behavior for clicking a button
            var element = Page.Locator(selector);
            await element.ClickAsync();
        }

        public override bool CheckSuccess(string selector)
        {
            // Custom behavior to check if a specific element is visible
            return Page.Locator(selector).IsVisibleAsync().Result;
        }
    }
}