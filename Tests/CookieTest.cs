using DIP;
using Microsoft.Playwright;

public class CookieTest
{
    private readonly IButtonClicker _buttonClicker;

    public CookieTest(IPage page)
    {
        _buttonClicker = new CookiePopup(page); 
    }

    [Fact]
    public async Task TestAcceptCookies()
    {
        await _buttonClicker.AcceptCookiesAsync();
    }
}
