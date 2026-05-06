using NUnit.Framework;
using PlaywrightTests.Base;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests;

public class LoginTests : BaseTest
{
    [Test]
    public async Task ValidLogin()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.GoToAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await Page.WaitForTimeoutAsync(2000);

        Assert.That(Page.Url, Does.Contain("inventory"));
    }

    [Test]
    public async Task InvalidPassword()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.GoToAsync();
        await loginPage.LoginAsync("standard_user", "wrong_password");

        var error = Page.Locator("[data-test='error']");

        Assert.That(await error.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task EmptyUsername()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.GoToAsync();
        await loginPage.LoginAsync("", "secret_sauce");

        var error = Page.Locator("[data-test='error']");

        Assert.That(await error.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task LockedUser()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.GoToAsync();
        await loginPage.LoginAsync("locked_out_user", "secret_sauce");

        var error = Page.Locator("[data-test='error']");

        Assert.That(await error.InnerTextAsync(), Does.Contain("locked out"));
    }
}