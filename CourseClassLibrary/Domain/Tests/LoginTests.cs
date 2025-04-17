using CourseClassLibrary.Abstractions;

namespace CourseClassLibrary.Domain.Tests
{
    public class LoginTests : PlaywrightTestBase
    {
        public override async Task ClickElementAsync(string selector)
        {
            var element = Page.Locator(selector);
            if (!await element.IsVisibleAsync())
                throw new InvalidOperationException($"Element with selector '{selector}' is not visible.");
            await base.ClickElementAsync(selector);
        }

        public override bool CheckSuccess(string selector)
        {
            var element = Page.Locator(selector);
            if (!element.IsVisibleAsync().Result) //var isVisible = element.IsVisibleAsync().GetAwaiter().GetResult(); e indicat sa nu folosim .Result, doarece asa reducem riscul de deadlock
                throw new InvalidOperationException($"Element with selector '{selector}' is not visible.");
            return base.CheckSuccess(selector);
        }
    }
}
