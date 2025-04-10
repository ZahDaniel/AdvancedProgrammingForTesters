using DipTest;
using Microsoft.Playwright;

public class CookiePopup : IButtonClicker
{
    private readonly IPage _page;

    public CookiePopup(IPage page)
    {
        _page = page;
    }

    public async Task AcceptCookiesAsync()
    {
        await _page.Locator("#acceptCookiesButton").ClickAsync();
    }

    public async Task RejectCookiesAsync()
    {
        await _page.Locator("#rejectCookiesButton").ClickAsync();
    }
}


