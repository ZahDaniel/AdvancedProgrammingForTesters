using CourseClassLibrary.Abstractions;


namespace CourseClassLibrary.Domain.Tests
{
    public class LoginTests : PlaywrightTestBase
    {
        public override async Task ClickElementAsync(string selector)
        {
            // Log the action for debugging purposes
            Console.WriteLine($"Attempting to click element with selector: {selector}");

            // Perform the click action
            await base.ClickElementAsync(selector);

            // Log success
            Console.WriteLine($"Successfully clicked element with selector: {selector}");
        }

        public override bool CheckSuccess(string selector)
        {
            // Log the action for debugging purposes
            Console.WriteLine($"Checking visibility of element with selector: {selector}");

            // Check if the element is visible
            bool isVisible = base.CheckSuccess(selector);

            // Log the result
            Console.WriteLine(isVisible
                ? $"Element with selector: {selector} is visible."
                : $"Element with selector: {selector} is not visible.");

            return isVisible;
        }
    }
}