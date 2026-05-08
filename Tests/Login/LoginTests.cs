using NUnit.Framework;
using PlaywrightTests.Base;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests.Login;

public class LoginTests : BaseTest
{
    [Test]
    public async Task Login_ValidUser()
    {
        var login = new LoginPage(Page);

        await login.OpenAsync();
        await login.LoginAsync("standard_user", "secret_sauce");

        Assert.That(Page.Url, Does.Contain("inventory"));
    }

    [Test]
    public async Task Login_InvalidPassword()
    {
        var login = new LoginPage(Page);

        await login.OpenAsync();
        await login.LoginAsync("standard_user", "wrong");

        var error = await login.GetErrorMessageAsync();

        Assert.That(error, Does.Contain("Username and password do not match"));
    }

    [Test]
    public async Task Login_LockedUser()
    {
        var login = new LoginPage(Page);

        await login.OpenAsync();
        await login.LoginAsync("locked_out_user", "secret_sauce");

        var error = await login.GetErrorMessageAsync();

        Assert.That(error, Does.Contain("locked out"));
    }

    [Test]
    public async Task Login_EmptyFields()
    {
        var login = new LoginPage(Page);

        await login.OpenAsync();
        await login.LoginAsync("", "");

        var error = await login.GetErrorMessageAsync();

        Assert.That(error, Does.Contain("Username is required"));
    }
}