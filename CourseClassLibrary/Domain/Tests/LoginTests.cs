using CourseClassLibrary.Abstractions;

namespace CourseClassLibrary.Domain.Tests
{
    public class LoginTests : PlaywrightTestBase
    {
        public override async Task ClickElementAsync(string selector)
        {
            // Custom implementation
            var element = Page.Locator(selector);
            await element.ClickAsync();
        }

        public override bool CheckSuccess(string selector)
        {
            // Custom implementation
            return Page.Locator(selector).IsVisibleAsync().Result;
        }
    }
}
