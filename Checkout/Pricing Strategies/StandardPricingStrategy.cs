using Checkout.Interfaces;

namespace Checkout.Pricing_Strategies;

public class StandardPricingStrategy(int unitPrice) : IPricingStrategy
{
    public int CalculatePrice(int quantity)
    {
        return quantity * unitPrice;
    }
}