namespace Checkout.Interfaces;

public interface IPricingStrategy
{
    int CalculatePrice(int quantity);
}