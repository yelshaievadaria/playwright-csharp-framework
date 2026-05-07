using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CheckoutCompletePage
{
    private readonly IPage _page;

    public CheckoutCompletePage(IPage page)
    {
        _page = page;
    }

    private ILocator CompleteHeader =>
        _page.Locator(".complete-header");

    public async Task<string> GetSuccessMessageAsync()
    {
        return await CompleteHeader.InnerTextAsync();
    }
}