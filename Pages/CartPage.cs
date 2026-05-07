using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CartPage
{
    private readonly IPage _page;

    public CartPage(IPage page)
    {
        _page = page;
    }

    private ILocator CartItem =>
        _page.Locator(".inventory_item_name");

    public async Task<string> GetCartItemNameAsync()
    {
        return await CartItem.InnerTextAsync();
    }
    public async Task ClickCheckoutAsync()
    {
        await _page
            .Locator("[data-test='checkout']")
            .ClickAsync();
    }
}