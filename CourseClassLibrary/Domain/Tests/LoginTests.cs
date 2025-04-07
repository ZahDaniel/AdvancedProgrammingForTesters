using CourseClassLibrary.Abstractions;

namespace CourseClassLibrary.Domain.Tests
{
    public class LoginTests : PlaywrightTestBase
    {
        public override Task ClickElementAsync(string selector)
        {
            return base.ClickElementAsync(selector);
        }

        public override bool CheckSuccess(string selector)
        {
            return base.CheckSuccess(selector);
        }
    }
}
