using Checkout.Interfaces;

namespace Checkout.Pricing_Strategies;

public class SpecialPricingStrategy(int unitPrice, int specialQuantity, int specialPrice) : IPricingStrategy
{
    public int CalculatePrice(int quantity)
    {
        var specialBundleCount = quantity / specialQuantity;
        var remainder = quantity % specialQuantity;
        return (specialBundleCount * specialPrice) + (remainder * unitPrice);
    }
}