using NUnit.Framework;
using PlaywrightTests.Base;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests.Checkout;

public class CheckoutTests : BaseTest
{
    [Test]
    public async Task Checkout_ShouldCompleteSuccessfully()
    {
        var login = new LoginPage(Page);
        var inventory = new InventoryPage(Page);
        var cart = new CartPage(Page);
        var checkout = new CheckoutPage(Page);

        await login.OpenAsync();
        await login.LoginAsync("standard_user", "secret_sauce");

        await inventory.AddItemToCartAsync("Sauce Labs Backpack");
        await inventory.OpenCartAsync();

        await cart.ClickCheckoutAsync();

        await checkout.FillCustomerInfoAsync("John", "Doe", "12345");
        await checkout.ContinueAsync();
        await checkout.FinishAsync();

        var message = await checkout.GetSuccessMessageAsync();

        Assert.That(message, Does.Contain("Thank you"));
    }
}