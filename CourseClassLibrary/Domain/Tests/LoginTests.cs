using CourseClassLibrary.Abstractions;

namespace CourseClassLibrary.Domain.Tests
{
    public class LoginTests : PlaywrightTestBase
    {
        public Dictionary<string, List<string>> loginPageControls = new Dictionary<string, List<string>>
            {
                { "button", new List<string> { "//button", "//app-button" } },
                { "input", new List<string> { "//input", "//app-input" } } 
        };

        public override async Task ClickElementAsync(string selector)
        {
            if (loginPageControls.TryGetValue(selector.ToLower(), out var elements))
            {
                var element = elements.First();
            }
            else
            {
                throw new ArgumentException($"Selector '{selector}' is not valid.");
            }
        }

        public override bool CheckSuccess(string selector)
        {
            return Page.Locator(selector).IsVisibleAsync().Result;
        }
    }
}
