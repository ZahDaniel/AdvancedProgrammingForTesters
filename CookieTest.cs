using System;

public class CookieTest
{
    private readonly CookiePopup _cookiePopup;

    public CookieTest(IPage page)
    {
        _cookiePopup = new CookiePopup(page); 
    }

    [Fact]
    public async Task TestAcceptCookies()
    {
        await _cookiePopup.AcceptCookiesAsync();
    }
}
