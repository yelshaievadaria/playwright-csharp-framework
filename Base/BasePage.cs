using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class BasePage
{
    protected readonly IPage Page;

    public BasePage(IPage page)
    {
        Page = page;
    }
}