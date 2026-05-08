using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class InventoryPage : BasePage
{
    public InventoryPage(IPage page) : base(page)
    {
    }

    public async Task AddItemToCartAsync(string itemName)
    {
        var normalized = itemName.ToLower().Replace(" ", "-");

        await Page.Locator($"[data-test='add-to-cart-{normalized}']").ClickAsync();
    }

    public async Task<string?> GetCartCountAsync()
    {
        var badge = Page.Locator(".shopping_cart_badge");

        if (await badge.CountAsync() == 0)
            return "0";

        return await badge.InnerTextAsync();
    }

    public async Task OpenCartAsync()
    {
        await Page.Locator(".shopping_cart_link").ClickAsync();
    }
}