using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class LoginPage : BasePage
{
    private readonly ILocator _username;
    private readonly ILocator _password;
    private readonly ILocator _loginButton;
    private readonly ILocator _error;

    public LoginPage(IPage page) : base(page)
    {
        _username = Page.Locator("[data-test='username']");
        _password = Page.Locator("[data-test='password']");
        _loginButton = Page.Locator("[data-test='login-button']");
        _error = Page.Locator("[data-test='error']");
    }

    public async Task OpenAsync()
    {
        await Page.GotoAsync("https://www.saucedemo.com");
    }

    public async Task LoginAsync(string user, string pass)
    {
        await _username.FillAsync(user);
        await _password.FillAsync(pass);
        await _loginButton.ClickAsync();
    }

    public async Task<string> GetErrorMessageAsync()
    {
        return await _error.InnerTextAsync();
    }
}