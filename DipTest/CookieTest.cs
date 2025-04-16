using DipTest;
using Microsoft.Playwright;

public class CookieTest
{
    private readonly IButtonClicker _buttonClicker;

    public CookieTest(IButtonClicker buttonClicker)
    {
        _buttonClicker = buttonClicker; 
    }

    [Fact]
    public async Task TestAcceptCookies()
    {
        await _buttonClicker.AccepCookiesAsync();
    }
}
