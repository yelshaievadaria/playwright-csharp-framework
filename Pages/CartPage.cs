using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CartPage : BasePage
{
    public CartPage(IPage page) : base(page)
    {
    }

    public async Task ClickCheckoutAsync()
    {
        await Page.ClickAsync("[data-test='checkout']");
    }

    public async Task<int> GetItemsCountAsync()
    {
        return await Page.Locator(".cart_item").CountAsync();
    }

    public async Task<string> GetFirstItemNameAsync()
    {
        return await Page.Locator(".inventory_item_name").First.InnerTextAsync();
    }
}