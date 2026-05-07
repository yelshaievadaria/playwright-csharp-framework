using NUnit.Framework;
using PlaywrightTests.Base;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests;

public class LoginTests : BaseTest
{
    [Test]
    public async Task ValidLogin()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.GoToAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await Page.WaitForTimeoutAsync(2000);

        Assert.That(Page.Url, Does.Contain("inventory"));
    }

    [Test]
    public async Task InvalidPassword()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.GoToAsync();
        await loginPage.LoginAsync("standard_user", "wrong_password");

        var error = Page.Locator("[data-test='error']");

        Assert.That(await error.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task EmptyUsername()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.GoToAsync();
        await loginPage.LoginAsync("", "secret_sauce");

        var error = Page.Locator("[data-test='error']");

        Assert.That(await error.IsVisibleAsync(), Is.True);
    }

    [Test]
    public async Task LockedUser()
    {
        var loginPage = new LoginPage(Page);

        await loginPage.GoToAsync();
        await loginPage.LoginAsync("locked_out_user", "secret_sauce");

        var error = Page.Locator("[data-test='error']");

        Assert.That(await error.InnerTextAsync(), Does.Contain("locked out"));
    }
    [Test]
    public async Task LoginAndAddItemToCart()
    {
        var loginPage = new LoginPage(Page);

        var inventoryPage = new InventoryPage(Page);

        var cartPage = new CartPage(Page);

        await loginPage.GoToAsync();

        await loginPage.LoginAsync(
            "standard_user",
            "secret_sauce");

        await inventoryPage.AddItemToCartAsync();

        await inventoryPage.OpenCartAsync();

        await Page.WaitForTimeoutAsync(2000);

        var itemName =
            await cartPage.GetCartItemNameAsync();

        Assert.That(
            itemName,
            Does.Contain("Sauce Labs Backpack"));
    }
    [Test]
    // FULL E2E FLOW 
    public async Task CompleteCheckoutFlow()
    {
        var loginPage = new LoginPage(Page);

        var inventoryPage = new InventoryPage(Page);

        var cartPage = new CartPage(Page);

        var checkoutPage = new CheckoutPage(Page);

        var overviewPage =
            new CheckoutOverviewPage(Page);

        var completePage =
            new CheckoutCompletePage(Page);

        await loginPage.GoToAsync();

        await loginPage.LoginAsync(
            "standard_user",
            "secret_sauce");

        await inventoryPage.AddItemToCartAsync();

        await inventoryPage.OpenCartAsync();

        var itemName =
            await cartPage.GetCartItemNameAsync();

        Assert.That(
            itemName,
            Does.Contain("Sauce Labs Backpack"));

        await cartPage.ClickCheckoutAsync();

        await checkoutPage.FillCheckoutInformationAsync(
            "Totoro",
            "Miyazaki",
            "FR34 7WQ");

        await overviewPage.FinishCheckoutAsync();

        var successMessage =
            await completePage.GetSuccessMessageAsync();

        Assert.That(
            successMessage,
            Does.Contain("Thank you"));
    }
}