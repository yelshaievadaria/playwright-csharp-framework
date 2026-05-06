using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests.Base;

public class BaseTest
{
    protected IPlaywright Playwright;
    protected IBrowser Browser;
    protected IBrowserContext Context;
    protected IPage Page;

    [SetUp]
    public async Task Setup()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 500
        });

        Context = await Browser.NewContextAsync();

        Page = await Context.NewPageAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Browser.CloseAsync();
        Playwright.Dispose();
    }
}