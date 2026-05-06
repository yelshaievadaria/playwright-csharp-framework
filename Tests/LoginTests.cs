using NUnit.Framework;
using PlaywrightTests.Base;

namespace PlaywrightTests.Tests;

public class LoginTests : BaseTest
{
    [Test]
    public async Task OpenSauceDemo()
    {
        await Page.GotoAsync("https://www.saucedemo.com");

        await Page.WaitForTimeoutAsync(5000);

        Assert.That(await Page.TitleAsync(), Does.Contain("Swag"));
    }
}