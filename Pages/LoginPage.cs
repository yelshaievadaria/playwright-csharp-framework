using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    // locators
    private ILocator Username => _page.Locator("#user-name");
    private ILocator Password => _page.Locator("#password");
    private ILocator LoginButton => _page.Locator("#login-button");

    // actions
    public async Task GoToAsync()
    {
        await _page.GotoAsync("https://www.saucedemo.com");
    }

    public async Task LoginAsync(string username, string password)
    {
        await Username.FillAsync(username);
        await Password.FillAsync(password);
        await LoginButton.ClickAsync();
    }
}