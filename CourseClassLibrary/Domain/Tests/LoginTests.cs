using CourseClassLibrary.Abstractions;

namespace CourseClassLibrary.Domain.Tests
{
    public class LoginTests : PlaywrightTestBase
    {
        public override async Task ClickElementAsync(string selector)
        {
            var element = Page.Locator(selector);
            await element.ClickAsync();
        }

        public override bool CheckSuccess(string selector)
        {
            //check if a specific element (such as a welcome message or user profile) is visible after a successful login
            var element = Page.Locator(selector);
            var isVisible = element.IsVisibleAsync().Result;
            if (isVisible)
            {
                var text = element.InnerTextAsync().Result;
                if (text.Contains("Welcome"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }

}

