using NUnit.Framework;
using PlaywrightTests.Base;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests.Inventory;

public class InventoryTests : BaseTest
{
    [Test]
    public async Task AddItem_ShouldIncreaseCartBadge()
    {
        var login = new LoginPage(Page);
        var inventory = new InventoryPage(Page);

        await login.OpenAsync();
        await login.LoginAsync("standard_user", "secret_sauce");

        await inventory.AddItemToCartAsync("Sauce Labs Backpack");

        var count = await inventory.GetCartCountAsync();

        Assert.That(count, Is.EqualTo("1"));
    }

    [Test]
    public async Task AddItem_ShouldBeVisibleInCart()
    {
        var login = new LoginPage(Page);
        var inventory = new InventoryPage(Page);
        var cart = new CartPage(Page);

        await login.OpenAsync();
        await login.LoginAsync("standard_user", "secret_sauce");

        await inventory.AddItemToCartAsync("Sauce Labs Backpack");
        await inventory.OpenCartAsync();

        var items = await cart.GetItemsCountAsync();

        Assert.That(items, Is.EqualTo(1));
    }

    [Test]
    public async Task Cart_ShouldContainCorrectItem()
    {
        var login = new LoginPage(Page);
        var inventory = new InventoryPage(Page);
        var cart = new CartPage(Page);

        await login.OpenAsync();
        await login.LoginAsync("standard_user", "secret_sauce");

        await inventory.AddItemToCartAsync("Sauce Labs Backpack");
        await inventory.OpenCartAsync();

        var itemName = await cart.GetFirstItemNameAsync();

        Assert.That(itemName, Does.Contain("Sauce Labs Backpack"));
    }
}