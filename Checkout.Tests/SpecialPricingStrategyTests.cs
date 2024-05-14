using Checkout.Pricing_Strategies;

namespace Checkout.Tests;

[TestFixture]
public class SpecialPricingStrategyTests
{
    [Test]
    public void CalculatePrice_LessThanSpecialQuantity_ReturnsCorrectPrice()
    {
        // Arrange
        var strategy = new SpecialPricingStrategy(50, 3, 130);

        // Act
        var price = strategy.CalculatePrice(2);

        // Assert
        Assert.That(price, Is.EqualTo(100));
    }

    [Test]
    public void CalculatePrice_ExactSpecialQuantity_ReturnsSpecialPrice()
    {
        var strategy = new SpecialPricingStrategy(50, 3, 130);
        
        var price = strategy.CalculatePrice(3);
        
        Assert.That(price, Is.EqualTo(130));
    }

    [Test]
    public void CalculatePrice_MoreThanSpecialQuantity_ReturnsMixedPrice()
    {
        var strategy = new SpecialPricingStrategy(50, 3, 130);

        var price = strategy.CalculatePrice(5);

        Assert.That(price, Is.EqualTo(230)); // 3 for 130 + 2 for 100
    }

    [Test]
    public void CalculatePrice_MultipleSpecialQuantities_ReturnsCorrectPrice()
    {
        var strategy = new SpecialPricingStrategy(50, 3, 130);

        var price = strategy.CalculatePrice(6);

        Assert.That(price, Is.EqualTo(260)); // 6 for 260 (2 * 130)
    }

    [Test]
    public void CalculatePrice_NoSpecialPriceDefined_ReturnsStandardPrice()
    {
        var strategy = new SpecialPricingStrategy(50, 1, 50); // standard pricing

        var price = strategy.CalculatePrice(4);

        Assert.That(price, Is.EqualTo(200)); // 4 for 200 (4 * 50)
    }
}