using Checkout.Pricing_Strategies;

namespace Checkout.Tests;

[TestFixture]
public class StandardPricingStrategyTests
{
    [Test]
    public void CalculatePrice_SingleItem_ReturnsCorrectPrice()
    {
        // Arrange
        var strategy = new StandardPricingStrategy(50);

        // Act
        var price = strategy.CalculatePrice(1);

        // Assert
        Assert.That(price, Is.EqualTo(50));
    }

    [Test]
    public void CalculatePrice_MultipleItems_ReturnsCorrectPrice()
    {
        var strategy = new StandardPricingStrategy(50);

        var price = strategy.CalculatePrice(3);

        Assert.That(price, Is.EqualTo(150));
    }
}