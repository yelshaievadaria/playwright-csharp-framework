using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CheckoutOverviewPage
{
    private readonly IPage _page;

    public CheckoutOverviewPage(IPage page)
    {
        _page = page;
    }

    private ILocator FinishButton =>
        _page.Locator("[data-test='finish']");

    public async Task FinishCheckoutAsync()
    {
        await FinishButton.ClickAsync();
    }
}