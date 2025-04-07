﻿using CourseClassLibrary.Abstractions;

namespace Tests
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
            var element = Page.Locator(selector).IsVisibleAsync().Result;
            return element;
        }
    }
}