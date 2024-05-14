using Checkout.Interfaces;

namespace Checkout.Models;

public class Product(string sku, IPricingStrategy pricingStrategy)
{
    public string Sku { get; } = sku;
    public IPricingStrategy PricingStrategy { get; } = pricingStrategy;
}