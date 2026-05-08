using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CheckoutPage : BasePage
{
    public CheckoutPage(IPage page) : base(page)
    {
    }

    public async Task FillCustomerInfoAsync(string firstName, string lastName, string postalCode)
    {
        await Page.FillAsync("[data-test='firstName']", firstName);
        await Page.FillAsync("[data-test='lastName']", lastName);
        await Page.FillAsync("[data-test='postalCode']", postalCode);
    }

    public async Task ContinueAsync()
    {
        await Page.ClickAsync("[data-test='continue']");
    }

    public async Task FinishAsync()
    {
        await Page.ClickAsync("[data-test='finish']");
    }

    public async Task<string?> GetSuccessMessageAsync()
    {
        return await Page.TextContentAsync(".complete-header");
    }
}