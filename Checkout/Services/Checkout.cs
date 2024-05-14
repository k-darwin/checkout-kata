using Checkout.Interfaces;
using Checkout.Models;

namespace Checkout.Services;

public class Checkout : ICheckout
{
    private readonly Dictionary<string, Product> _products;
    private readonly Dictionary<string, int> _scannedItems;

    public Checkout(IEnumerable<Product> products)
    {
        _products = new Dictionary<string, Product>();
        _scannedItems = new Dictionary<string, int>();

        foreach (var product in products)
        {
            _products[product.Sku] = product;
        }
    }

    public void Scan(string item)
    {
        if (!_scannedItems.TryAdd(item, 1))
        {
            _scannedItems[item]++;
        }
    }

    public int GetTotalPrice()
    {
        var totalPrice = 0;

        foreach (var (sku, quantity) in _scannedItems)
        {
            var product = _products[sku];
            totalPrice += product.PricingStrategy.CalculatePrice(quantity);
        }

        return totalPrice;
    }
}