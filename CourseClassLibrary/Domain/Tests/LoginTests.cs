﻿using CourseClassLibrary.Abstractions;

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
            if (!element.IsVisibleAsync().Result)
                throw new InvalidOperationException($"Element with selector '{selector}' is not visible.");
            return base.CheckSuccess(selector);
        }
    }
}
