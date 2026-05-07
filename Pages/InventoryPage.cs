using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class InventoryPage
{
    private readonly IPage _page;

    public InventoryPage(IPage page)
    {
        _page = page;
    }

    private ILocator AddToCartButton =>
        _page.Locator("[data-test='add-to-cart-sauce-labs-backpack']");

    private ILocator CartIcon =>
        _page.Locator(".shopping_cart_link");

    public async Task AddItemToCartAsync()
    {
        await AddToCartButton.ClickAsync();
    }

    public async Task OpenCartAsync()
    {
        await CartIcon.ClickAsync();
    }
}