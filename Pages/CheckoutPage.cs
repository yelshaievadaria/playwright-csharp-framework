using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CheckoutPage
{
    private readonly IPage _page;

    public CheckoutPage(IPage page)
    {
        _page = page;
    }

    private ILocator CheckoutButton =>
        _page.Locator("[data-test='checkout']");

    private ILocator FirstName =>
        _page.Locator("[data-test='firstName']");

    private ILocator LastName =>
        _page.Locator("[data-test='lastName']");

    private ILocator PostalCode =>
        _page.Locator("[data-test='postalCode']");

    private ILocator ContinueButton =>
        _page.Locator("[data-test='continue']");

    public async Task StartCheckoutAsync()
    {
        await CheckoutButton.ClickAsync();
    }

    public async Task FillCheckoutInformationAsync(
        string firstName,
        string lastName,
        string postalCode)
    {
        await FirstName.FillAsync(firstName);

        await LastName.FillAsync(lastName);

        await PostalCode.FillAsync(postalCode);

        await ContinueButton.ClickAsync();
    }
}