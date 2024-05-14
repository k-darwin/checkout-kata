using Checkout.Models;
using Checkout.Pricing_Strategies;

namespace Checkout.Tests;

[TestFixture]
public class CheckoutTests
{
    private Services.Checkout _checkout;

    [SetUp]
    public void Setup()
    {
        var basket = new List<Product>
        {
            new("A", new SpecialPricingStrategy(50, 3, 130)),
            new("B", new SpecialPricingStrategy(30, 2, 45)),
            new("C", new StandardPricingStrategy(20)),
            new("D", new StandardPricingStrategy(15))
        };

        _checkout = new Services.Checkout(basket);
    }

    [Test]
    public void Scan_SingleItem_ReturnsCorrectPrice()
    {
        _checkout.Scan("A");
        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(50));
    }

    [Test]
    public void Scan_MultipleItemsWithoutSpecialPrice_ReturnsCorrectPrice()
    {
        _checkout.Scan("A");
        _checkout.Scan("C");
        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(70));
    }

    [Test]
    public void Scan_MultipleItemsWithSpecialPrice_ReturnsCorrectPrice()
    {
        _checkout.Scan("A");
        _checkout.Scan("A");
        _checkout.Scan("A");
        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(130));
    }

    [Test]
    public void Scan_MixedItemsWithAndWithoutSpecialPrice_ReturnsCorrectPrice()
    {
        _checkout.Scan("A");
        _checkout.Scan("A");
        _checkout.Scan("A");
        _checkout.Scan("B");
        _checkout.Scan("B");
        _checkout.Scan("C");
        _checkout.Scan("D");
        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(210));
    }

    [Test]
    public void Scan_MultipleItemsWithIncompleteSpecialPrice_ReturnsCorrectPrice()
    {
        _checkout.Scan("A");
        _checkout.Scan("A");
        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(100));
    }
    
    [Test]
    public void Scan_MultipleItemsInAnyOrder_ReturnsCorrectPrice()
    {
        _checkout.Scan("B");
        _checkout.Scan("A");
        _checkout.Scan("D");
        _checkout.Scan("C");
        _checkout.Scan("A");
        _checkout.Scan("A");
        _checkout.Scan("B");
        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(210));
    }
}